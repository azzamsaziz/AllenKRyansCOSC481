using AllenKRyansCOSC481.Models;

using System.Collections.Generic;
using System.Net.Mail;

namespace AllenKRyans.Helpers
{
    public static class ModelHelper
    {
        // send emails from: akronlineordering, akr_password to:customer,old_akr_email
        public static void SendOrderConfirmationEmail(List<CartItem> cartItems, ApplicationUser user)
        {
            
            // get the order info (from controller of the order page -- when send order button is clicked
            // get the user info

            // send 2 emails (1 to customer from admin, 1 to akr email and a separate online ordering akr email)
            MailAddress userEmail = new MailAddress(user.Email);
            MailAddress akrEmail = new MailAddress("akronlineordering@gmail.com");

            MailMessage message = new MailMessage
            {
                // to, from, and subject of email
                From = new MailAddress(akrEmail.Address),
                Subject = "Your online order at Allen K. Ryan's has sent!"
            };

            MailMessage message2 = new MailMessage
            {
                // to, from, and subject of email
                From = akrEmail,
                Subject = "Online Order from " + user.FirstName + " " + user.LastName
            };

            message.To.Add(userEmail.Address);
            message2.To.Add("mmccoll1996@gmail.com"); // replace with allenkryans3@gmail.com when demoing to ron

            // building the bodies of the emails
            string body = user.FirstName + ":\n\n";
            string body2 = "Customer Information:\n";
            body2 += user.FirstName + " " + user.LastName + "\n";
            body2 += user.Email + "\n";
            body2 += user.PhoneNumber + "\n\n";

            for (int i = 0; i < cartItems.Count; i++)
            {
                body += ((i + 1) + ". " + cartItems[i].Item.Name + " (" + cartItems[i].Count + ") - $" + cartItems[i].Price + "\n");
                body2 += ((i + 1) + ". " + cartItems[i].Item.Name + " (" + cartItems[i].Count + ") - $" + cartItems[i].Price + "\n");
            }

            double sum = 0;
            foreach (var item in cartItems)
            {
                sum += item.Price;
            }

            body += "Total price: $" + sum + "\n\n";
            body += "As always, thanks for your business!\n";
            body += "Allen K. Ryan's";
            message.Body = body;

            body2 += "Total price: $" + sum + "\n\n";
            message2.Body = body2;

            // connect and authenticate
            string host = akrEmail.Host;
            SmtpClient smtp = new SmtpClient("smtp." + host)
            {
                Port = 587,
                Credentials = new System.Net.NetworkCredential(akrEmail.Address, "akr_password"),
                EnableSsl = true
            };

            smtp.Send(message); // send email to customer
            smtp.Send(message2); // send email to old akr email
        }
    }
}