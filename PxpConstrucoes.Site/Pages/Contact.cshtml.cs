using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PxpConstrucoes.Site.Pages
{
    public class ContactModel : PageModel
    {
        [BindProperty]
        public ContactFormModel Contact { get; set; }
        public class ContactFormModel
        {
            [Required]
            public string Subject { get; set; }
            [Required]
            public string Name { get; set; }
            [Required]
            public string Email { get; set; }
            [Required]
            public string Phone { get; set; }
            [Required]
            public string Message { get; set; }
        }

        private void SendMail(string mailBody)
        {
            using var message = new MailMessage(Contact.Email, "leandro@mandrillus.com.br");
            
            message.To.Add(new MailAddress("leandro@mandrillus.com.br"));
            message.From = new MailAddress(Contact.Email);
            message.Subject = "Nova mensagem recebida pelo site";
            message.Body = mailBody;

            try
            {
                using var smtpClient = new SmtpClient("smtp.mandrillus.com.br", 587);
                smtpClient.Credentials = new NetworkCredential("leandro@mandrillus.com.br", "");
                smtpClient.Send(message);
            }
            catch (Exception ex)
            {
                Response.WriteAsync(ex.Message);
            }
            
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                 return Page();
            }

            var mailBody = $@"Olá,
            Um novo contato foi solicitado através do site:
            
            Assunto: {Contact.Subject}
            Nome: {Contact.Name}
            Email: {Contact.Email}
            Mensagem: ""{Contact.Message}""

            Retorne o contato o mais rápido possível.";

            SendMail(mailBody);
            return RedirectToPage("Index");
        }
    }
}