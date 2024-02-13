using COLORADO.Data.DAL;
using COLORADO.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace COLORADO.Services
{
    public class UserService : IUserInterface
    {
        DataContext context;
        public UserService(DataContext context) {
        this.context = context;
        }
        public async Task<List<User>> GetAll() {
            return await context.Users.ToListAsync();
        }

        public async Task<User>? Get(int id) { 
            return await context.Users.FindAsync(id); 
        }
        public async Task<User>? GetByUsername(string username) {
            return await context.Users.FirstOrDefaultAsync(p => p.username == username); 
        }

        public async Task<User>? GetByEmail(string email) => await context.Users.FirstOrDefaultAsync(p => p.email == email);

        public async Task<User> Add(User user)
        {
            var newUser = new User
            {
                username = user.username,
                email = user.email,
                name = user.name,
                address = user.address,
                password = user.password,
                surname = user.surname,
                phone = user.phone,
            };
            context.Users.Add(user);
            await context.SaveChangesAsync();
            return newUser;
        }

        public async Task<User> Delete(int id)
        {
            var user = await context.Users.FirstOrDefaultAsync(p => p.id == id);
            if (user is null)
                return user;
            context.Users.Remove(user);
            await context.SaveChangesAsync();
            return user;
        }

        public async Task<User> Update(int id, User user)
        {
            var existingUser = await context.Users.FindAsync(id);

            existingUser.name = user.name;
            existingUser.email = user.email;
            existingUser.password = existingUser.password;
            existingUser.phone = user.phone;
            existingUser.username = user.username;
            existingUser.name = user.name;
            existingUser.surname = user.surname;
            existingUser.address = user.address;



            await context.SaveChangesAsync();
            return user;
        }
        
    }
}
