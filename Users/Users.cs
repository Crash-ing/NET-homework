using System.Diagnostics;

namespace Users
{
    public abstract class User
    {
        private string userName;    // privātie atibūti
        private string email;
        private int userID;
        private bool? isActive;     // nullable backing field for IsActive

        public string UserName
        {
            get => userName; set => userName = value;
        }

        public string Email
        {
            get => email;
            set
            {
                if (value.Contains("@"))    // pārbaude vai e-pasta adrese satur "@" simbolu
                {
                    email = value;
                }
                else     // ja nesatur "@", tad atstāj pēdējo vērtību un izvada kļūdas paziņojumu
                {
                    Debug.WriteLine("Invalid email address.");
                }
            }
        }
        public  int UserID
        {
            get => userID;
            set => userID = value;
        }

        // Public non-nullable property that returns false when the backing field is null
        public bool IsActive 
        { 
            get => isActive ?? false; 
            set => isActive = value; 
        }

        public override string? ToString()
        {
            return $"Username: {UserName}; Email: {Email}; UserID: {UserID}; IsActive: {IsActive}; ";
        }
    }
}