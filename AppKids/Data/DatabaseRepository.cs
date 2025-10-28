using SQLite;
using SQLiteNetExtensionsAsync.Extensions;
using AppKids.Models;

namespace AppKids.Data
{
    public class DatabaseRepository
    {
        SQLiteAsyncConnection _database;

        public DatabaseRepository()
        {
            string dbName = "app_kids.db3";
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, dbName);

            _database = new SQLiteAsyncConnection(dbPath);

            _database.CreateTableAsync<User>().Wait();
            _database.CreateTableAsync<Annotation>().Wait();
        }

        // --- Métodos de usuarios ---
        public Task<List<User>> GetUsersWithItemsAsync()
        {
            return _database.GetAllWithChildrenAsync<User>();
        }

        public Task<bool> IsRegistered(string email, string password)
        {
            var user = _database.GetAsync<User>(u => u.Email == email && u.Password == password).Result;
            return user.ID > 0 ? Task.FromResult(true) : Task.FromResult(false);
        }

        public Task<User> GetUserByIdAsync(int id)
        {
            return _database.GetAllWithChildrenAsync<User>(u => u.ID == id)
                            .ContinueWith(t => t.Result.FirstOrDefault());
        }

        public Task SaveUserWithItemsAsync(User user)
        {
            if (user.ID != 0)
            {
                return _database.UpdateWithChildrenAsync(user);
            }
            else
            {
                return _database.InsertWithChildrenAsync(user, recursive: true); 
            }
        }

        public Task<int> DeleteUserAsync(User user)
        {
            return _database.DeleteAsync(user);
        }

        // --- Métodos de anotaciones ---
        public Task SaveAnnotationAsync(Annotation annotation)
        {
            return _database.InsertAsync(annotation);
        }

     
        public async Task<List<Annotation>> GetAnnotationsForUserAsync(int userId)
        {
            return await _database.Table<Annotation>()
                              .Where(a => a.UserID == userId)
                              .ToListAsync();
        }

        public Task<Annotation> GetAnnotationWithAuthorAsync(int annotationId)
        {
            return _database.GetWithChildrenAsync<Annotation>(annotationId);
        }
    }
}
