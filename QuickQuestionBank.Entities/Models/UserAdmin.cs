namespace QuickQuestionBank.Models
{
    public class UserAdmin
    {
		public int UserId { get; set; }
		public string UserName { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public string First_Name { get; set; }
		public string Last_Name { get; set; }
		public DateTime Createon { get; set; }
		public DateTime UpdateOn { get; set; }
		public DateTime DeletedOn { get; set; }
    }
}
