using Lab1.Pages.DataClasses;
using Lab1.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;


namespace Lab1.Pages.MessageCenter
{
    public class MessageTestModel : PageModel
    {
        public List<Message> MessageInfo { get; set; }

        public MessageTestModel()
        {
            MessageInfo = new List<Message>();
        }
        [BindProperty]
        public Message NewMessage { get; set; }
        public void OnGet()
        {
            Microsoft.Data.SqlClient.SqlDataReader productReader = DBClass.MessageReader();
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
