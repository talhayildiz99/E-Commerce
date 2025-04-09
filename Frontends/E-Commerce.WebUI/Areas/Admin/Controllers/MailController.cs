using E_Commerce.WebUI.Areas.Admin.Models;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace E_Commerce.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Mail")]
    public class MailController : Controller
    {
        [HttpGet]
        [Route("SendMail")]
        public IActionResult SendMail()
        {
            return View();
        }

        [HttpPost]
        [Route("SendMail")]
        public IActionResult SendMail(MailRequest mailRequest)
        {
            MimeMessage mimeMessage = new MimeMessage();

            MailboxAddress mailboxAddressFrom = new MailboxAddress("E-Commerce Bülten", "talhayldz4433@gmail.com");

            mimeMessage.From.Add(mailboxAddressFrom);

            MailboxAddress mailboxAddressTo = new MailboxAddress("User", mailRequest.RecieverMail);
            mimeMessage.To.Add(mailboxAddressTo);

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = mailRequest.MessageContent;
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            mimeMessage.Subject = mailRequest.Subject;

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Connect("smtp.gmail.com", 587, false);
            smtpClient.Authenticate("talhayldz4433@gmail.com", "raxk yeks yqrz semh");
            smtpClient.Send(mimeMessage);
            smtpClient.Disconnect(true);


            return RedirectToAction("SendMail", "Mail", new { area = "Admin" });
        }
    }
}
