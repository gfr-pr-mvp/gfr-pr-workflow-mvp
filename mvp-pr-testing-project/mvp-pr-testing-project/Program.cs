using System;
using System.Collections.Generic;

namespace CopilotTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new UserService();

            // Caso 1: usuario inexistente (null)
            var user = service.GetUserById(10);
            Console.WriteLine(user.Name); // ⚠️ posible NullReferenceException

            // Caso 2: lista sin validar
            var emails = service.GetEmails(null);
            foreach (var email in emails)
            {
                Console.WriteLine(email.ToLower()); // ⚠️ posible null
            }

            // Caso 3: división por cero
            int result = service.Divide(10, 0);
            Console.WriteLine(result);
        }
    }

    public class UserService
    {
        private List<User> users = new List<User>
        {
            new User { Id = 1, Name = "Juan", Email = "juan@test.com" },
            new User { Id = 2, Name = "Maria", Email = null }
        };

        public User GetUserById(int id)
        {
            return users.Find(u => u.Id == id);
        }

        public List<string> GetEmails(List<User> users)
        {
            List<string> emails = new List<string>();

            foreach (var user in users) // ⚠️ users puede ser null
            {
                emails.Add(user.Email);
            }

            return emails;
        }

        public int Divide(int a, int b)
        {
            return a / b; // ⚠️ división por cero
        }
    }

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
``