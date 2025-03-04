using Lab1.Pages.DataClasses;
using Lab1.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace Lab1.Pages
{
    public class MessageModel : PageModel
    {
        public List<Message> MessageInfo { get; set; } = new List<Message>();
        [BindProperty]
        public Message NewMessage { get; set; } = new Message();

        public void OnGet()
        {
            SqlDataReader productReader = DBClass.MessageReader();
            while (productReader.Read())
            {
                MessageInfo.Add(new Message
                {
                    ActualMessage = productReader["ActualMessage"].ToString(),
                    Name = productReader["Name"].ToString()
                });
            }
            DBClass.Lab1DBConnection.Close();
        }

        public IActionResult OnPost()
        {
            DBClass.InsertMessage(NewMessage);
            DBClass.Lab1DBConnection.Close();
            return RedirectToPage("/MessageCenter/SendMessage");
        }
    }
}
