using AllenKRyans.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;

namespace AllenKRyans.Helpers
{
    public static class ModelHelper
    {
        public static List<OrderModel> GetOrders()
        {
            return new List<OrderModel>();
        }

        public static List<ItemModel> GetItems()
        {
            return new List<ItemModel>();
        }

        public static List<UserModel> GetUsers()
        {
            return new List<UserModel>();
        }

        // send emails from: akronlineordering, akr_password to:customer,old_akr_email
        public static void SendOrderConfirmationEmail()
        {
            // get the order info (from controller of the order page -- when send order button is clicked)
            OrderModel order = null; //= OrderPageController.getOrder();
            order = new OrderModel() // used for testing
            {
                Items = new List<ItemModel>(),
                OrderNote = "This is a note"
            };

            //order.Items.Add(new ItemModel(5.0, ItemType.BUCKET, "chicken", "this is frickin chicken"));// test data
            //order.Items.Add(new ItemModel(6.0, ItemType.BUCKET, "taters", "this is not frickin chicken"));// more test data

            // get the user info
            UserModel user = null;// = OrderPageController.getUser();
            user = new UserModel // used for testing
            {
                Email = "mmccoll1996@gmail.com",
                Password = "",
                UserType = UserType.Customer,
                Phone = "810-986-9244",
                FirstName = "Matt",
                LastName = "McColl"
            };

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
            body2 += user.Phone + "\n\n";

            for (int i = 0; i < order.Items.Count; i++)
            {
                body += ((i + 1) + ". " + order.Items[i].Name + " - $" + order.Items[i].Price + "\n");
                body2 += ((i + 1) + ". " + order.Items[i].Name + " - $" + order.Items[i].Price + "\n");
            }

            body += "Total price: $" + order.TotalPrice + "\n\n";
            body += "Order note:\n" + order.OrderNote + "\n\n";
            body += "As always, thanks for your business!\n";
            body += "Allen K. Ryan's";
            message.Body = body;

            body2 += "Total price: $" + order.TotalPrice + "\n\n";
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

        public static void SendAccountRecoveryEmail(string email)
        {
            // get email from email input field from ForgotAccount page
            MailAddress akrEmail = new MailAddress("akronlineordering@gmail.com");
            MailAddress userEmail = new MailAddress(email); ;
            MailMessage message = new MailMessage
            {
                // to, from, and subject of email
                From = new MailAddress(akrEmail.Address),
                Subject = "Your account information"
            };

            message.To.Add(userEmail);

            // need to query database for user information based on email
            // i.e. SELECT name, username, password FROM USER WHERE email=userEmail
            UserModel user = new UserModel
            {
                FirstName = "Matt",
                //LastName = "McColl",
                Email = userEmail.Address,
                Password = "bob"
            }; // 

            // build the body of the email
            /* <name>,
             * 
             * Your password is: <password>
             * 
             * Allen K. Ryan's
             * */

            string body = user.FirstName + ",\n\n";
            body += "Your password is: " + user.Password + "\n\n";
            body += "Allen K. Ryan's";
            message.Body = body;;

            string host = akrEmail.Host;
            SmtpClient smtp = new SmtpClient("smtp." + host)
            {
                Port = 587,
                Credentials = new System.Net.NetworkCredential(akrEmail.Address, "akr_password"),
                EnableSsl = true
            };

            smtp.Send(message); // send email to customer
        }

        public static void SendAccountConfirmationEmail(string email)
        {
            // get email from email input field from ForgotAccount page
            MailAddress akrEmail = new MailAddress("akronlineordering@gmail.com");
            if (String.IsNullOrWhiteSpace(email))
            {
                return;
            }

            MailAddress userEmail = new MailAddress(email);
            MailMessage message = new MailMessage
            {
                // to, from, and subject of email
                From = new MailAddress(akrEmail.Address),
                Subject = "Your account information"
            };

            message.To.Add(userEmail);

            // need to query database for user information based on email
            // i.e. SELECT name, username, password FROM USER WHERE email=userEmail
            UserModel user = new UserModel
            {
                FirstName = "Matt",
                //LastName = "McColl",
                Email = userEmail.Address,
                Password = "bob"
            }; // 

            // build the body of the email
            /* <name>,
             * 
             * Your password is: <password>
             * 
             * Allen K. Ryan's
             * */

            string code = GetUniqueCode(10);

            string body = user.FirstName + ",\n\n";
            body += "Your confirmation code is: " + code + "\n\n";
            body += "Allen K. Ryan's";
            message.Body = body; ;

            string host = akrEmail.Host;
            SmtpClient smtp = new SmtpClient("smtp." + host)
            {
                Port = 587,
                Credentials = new System.Net.NetworkCredential(akrEmail.Address, "akr_password"),
                EnableSsl = true
            };

            smtp.Send(message); // send email to customer
        }

        public static string GetUniqueCode(int maxSize)
        {
            char[] chars = new char[62];
            chars =
            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
            byte[] data = new byte[1];
            using (RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider())
            {
                crypto.GetNonZeroBytes(data);
                data = new byte[maxSize];
                crypto.GetNonZeroBytes(data);
            }
            StringBuilder result = new StringBuilder(maxSize);
            foreach (byte b in data)
            {
                result.Append(chars[b % (chars.Length)]);
            }
            return result.ToString();
        }
    }
}