using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.OleDb;
using System.IO;

namespace QuizManager.Models
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Role")]
        public string Role { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

    }
    public class PrecompileUsers
    {
        public List<RegisterViewModel> Users = new List<RegisterViewModel>();
        public IEnumerable<string> GetAllUsers()
        {
            FileStream file = new FileStream("C:/Users/APearson/Documents/Apprenticeship Evidence/Year 2/Coding Project/Develop/PrecompileUsers.csv", FileMode.Open);
            StreamReader streamReader = new StreamReader(file);
            string headerLine = streamReader.ReadLine();
            string line;
            while ((line = streamReader.ReadLine()) != null)
            {
                yield return line;
            }
            streamReader.Close();
        }
        public void ConvertCSVToUsers()
        {
           var csvLines = GetAllUsers();
            foreach (string line in csvLines)
            {
                string[] userProperties = line.Split(',');
                RegisterViewModel user = new RegisterViewModel()
                {
                    Email = userProperties[0],
                    Role = userProperties[1],
                    Password = userProperties[2]
                };
                Users.Add(user);
            }
        }
    }
}
