using System.Diagnostics;

namespace Users
{
    public abstract class User
    {
        private string userName;    // privātie atibūti
        private string email;
        private int userID;

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

        public bool IsActive { get; set; }

        public override string? ToString()  // Pārdefinēta metode ToString(), lai atgrieztu visu īpašību vērtības kā tekstu
        {
            return base.ToString() + " UserName: " + UserName + " Email: " + Email + " UserID: " + UserID + " IsActive: " + IsActive;
        }
    }
}