using System.Collections.ObjectModel;
using System.Data;
using System.Text;
using System.Text.Json;
using System.Timers;
using OpenAI;
using OpenAI.Chat;

namespace AppKids
{
    public partial class JuegoPage : ContentPage
    {
            public ObservableCollection<ChatMessageModel> Messages { get; set; }

            public JuegoPage()
            {
                InitializeComponent();
                Messages = new ObservableCollection<ChatMessageModel>();
                ChatList.ItemsSource = Messages; // Asegúrate de que ChatList esté definido en XAML
            }

            private async void OnSendClicked(object sender, EventArgs e)
            {
                string userText = UserEntry.Text?.Trim();
                if (string.IsNullOrEmpty(userText)) return;

                // Agrega mensaje del usuario
                Messages.Add(new ChatMessageModel { Text = userText, IsUser = true });
                UserEntry.Text = string.Empty;

                try
                {
                    using var http = new HttpClient();
                    http.DefaultRequestHeaders.Authorization =
                        new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer",
                            "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");
                
                    var payload = new
                    {
                        model = "gpt-4o-mini",
                        messages = new[]
                        {
                        new { role = "system", content = "Eres un asistente psicológico amigable que responde de forma breve y clara, si el usuario denota negatividad, lo escuchas y aconsejas responsablemente." },
                        new { role = "user", content = userText }
                    },
                        max_tokens = 300,
                        temperature = 0.7
                    };

                    var json = JsonSerializer.Serialize(payload);
                    using var content = new StringContent(json, Encoding.UTF8, "application/json");

                    var resp = await http.PostAsync("https://api.openai.com/v1/chat/completions", content);
                    var respString = await resp.Content.ReadAsStringAsync();

                    if (!resp.IsSuccessStatusCode)
                    {
                        Messages.Add(new ChatMessageModel
                        {
                            Text = $"⚠️ Error OpenAI ({(int)resp.StatusCode}): {respString}",
                            IsUser = false
                        });
                        return;
                    }

                    using var doc = JsonDocument.Parse(respString);
                    string respuesta = "";

                    if (doc.RootElement.TryGetProperty("choices", out var choices) &&
                        choices.GetArrayLength() > 0)
                    {
                        var first = choices[0];
                        if (first.TryGetProperty("message", out var messageElem) &&
                            messageElem.TryGetProperty("content", out var contentElem))
                        {
                            if (contentElem.ValueKind == JsonValueKind.String)
                                respuesta = contentElem.GetString() ?? "";
                            else if (contentElem.ValueKind == JsonValueKind.Array)
                            {
                                var sb = new StringBuilder();
                                foreach (var it in contentElem.EnumerateArray())
                                    if (it.ValueKind == JsonValueKind.String)
                                        sb.Append(it.GetString());
                                respuesta = sb.ToString();
                            }
                        }
                        else if (first.TryGetProperty("text", out var textElem) && textElem.ValueKind == JsonValueKind.String)
                        {
                            respuesta = textElem.GetString() ?? "";
                        }
                    }

                    if (string.IsNullOrWhiteSpace(respuesta))
                        respuesta = "(No se obtuvo respuesta de texto del modelo)";

                    Messages.Add(new ChatMessageModel { Text = respuesta.Trim(), IsUser = false });
                }
                catch (Exception ex)
                {
                    Messages.Add(new ChatMessageModel
                    {
                        Text = "⚠️ Error al conectar con OpenAI: " + ex.Message,
                        IsUser = false
                    });
                }
            }
    }

        public class ChatMessageModel
        {
            public string Text { get; set; }
            public bool IsUser { get; set; }
        }
}