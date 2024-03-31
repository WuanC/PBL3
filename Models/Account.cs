namespace PBL3.Models
{
    public class Account
    {
        public int UserID { get; set; }
        public string Username { get; set; }

        public string Password { get; set; }

        public string FullName { get; set; }

        public bool Gender { get; set; }

        public bool Status {  get; set; }

        public DateTime Birthday {  get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }
     
        public int RoleID {  get; set; }

        public int AddressID { get; set; }



    }
}
