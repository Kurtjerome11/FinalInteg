using MailKit.Net.Smtp;
using MimeKit;
using ParkingManagementData;
using ParkingManagementModels;
using System;

namespace ParkingBL
{
    public class Email
    {
        public static void AddEmail(string plateNum, string colorCar)
        {

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Oliva's Parking Services", "do-not-reply@Oliva'sPS.com"));
            message.To.Add(new MailboxAddress("Kurt", "kurtxoliva11@gmail.com"));
            message.Subject = "Car Parked";

            message.Body = new TextPart("html")
            {
                Text = $@"<h1>Good day Sir!</h1>
                <p>This is to inform you that a car has been parked in our parking area.</p>
                <p><strong>Car Details:</strong></p>
                <ul>
                    <li>Plate Number: {plateNum}</li>
                    <li>Color: {colorCar}</li>
                </ul>
                <p><strong>Thank you!</strong></p>"
            };

            using (var client = new SmtpClient())
            {
                try
                {
                    client.Connect("sandbox.smtp.mailtrap.io", 2525, MailKit.Security.SecureSocketOptions.StartTls);

                    client.Authenticate("2731fa4d5520a5", "8273f0e187b488");

                    client.Send(message);
                    Console.WriteLine("Email sent successfully through Mailtrap.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error sending email: {ex.Message}");
                }
                finally
                {
                    client.Disconnect(true);
                }
            }
        }

        public static void DeleteEmail(string plateNum, string colorCar)
        {

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Oliva's Parking Services", "do-not-reply@Oliva'sPS.com"));
            message.To.Add(new MailboxAddress("Kurt", "kurtxoliva11@gmail.com"));
            message.Subject = "Car Out";

            message.Body = new TextPart("html")
            {

                Text = $@"<h1>Good day Sir!</h1>
                <p>This is to inform you that the car below is going out.</p>
                <p><strong>Car Details:</strong></p>
                <ul>
                    <li>Plate Number: {plateNum}</li>
                    <li>Color: {colorCar}</li>
                </ul>
                <p><strong>Thank you!</strong></p>"
            };

            using (var client = new SmtpClient())
            {
                try
                {
                    client.Connect("sandbox.smtp.mailtrap.io", 2525, MailKit.Security.SecureSocketOptions.StartTls);

                    client.Authenticate("2731fa4d5520a5", "8273f0e187b488");

                    client.Send(message);
                    Console.WriteLine("Email sent successfully through Mailtrap.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error sending email: {ex.Message}");
                }
                finally
                {
                    client.Disconnect(true);
                }
            }
        }

        public static void DisplayEmail()
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Oliva's Parking Services", "do-not-reply@Oliva'sPS.com"));
            message.To.Add(new MailboxAddress("Kurt", "kurtxoliva11@gmail.com"));
            message.Subject = "All Cars that Parked";
            List<Park> usersFromDB = SqlDbData.GetParked();

            var htmlContent = new System.Text.StringBuilder();
            htmlContent.Append("<h1>Good day Sir!</h1>");
            htmlContent.Append("<p>This is to inform you about all the cars that parked in our parking area.</p>");
            htmlContent.Append("<p><strong>Car Details:</strong></p>");
            htmlContent.Append("<ul>");

            foreach (var item in usersFromDB)
            {
                htmlContent.Append($@"
            <li>
                <strong>Plate Number:</strong> {item.plateNum}<br>
                <strong>Color:</strong> {item.colorCar}
            </li>");
            }

            htmlContent.Append("</ul>");
            htmlContent.Append("<p><strong>Thank you!</strong></p>");

            message.Body = new TextPart("html")
            {
                Text = htmlContent.ToString()
            };

            using (var client = new SmtpClient())
            {
                try
                {
                    client.Connect("sandbox.smtp.mailtrap.io", 2525, MailKit.Security.SecureSocketOptions.StartTls);
                    client.Authenticate("2731fa4d5520a5", "8273f0e187b488");
                    client.Send(message);
                    Console.WriteLine("Email sent successfully through Mailtrap.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error sending email: {ex.Message}");
                }
                finally
                {
                    client.Disconnect(true);
                }
            }
        }

      
        public static void UpdateEmail(string oldPlateNum, string updatedPlateNum, string updatedColorCar)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Oliva's Parking Services", "do-not-reply@Oliva'sPS.com"));
            message.To.Add(new MailboxAddress("Kurt", "kurtxoliva11@gmail.com"));
            message.Subject = "Car Details Updated";

            message.Body = new TextPart("html")
            {
                Text = $@"<h1>Good day Sir!</h1>
            <p>This is to inform you that a car's details have been updated in our parking area.</p>
            <p><strong>Updated Car Details:</strong></p>
            <ul>
                <li>Old Plate Number: {oldPlateNum}</li>
                <li>Updated Plate Number: {updatedPlateNum}</li>
                <li>Updated Color: {updatedColorCar}</li>
            </ul>
            <p><strong>Thank you!</strong></p>"
            };

            using (var client = new SmtpClient())
            {
                try
                {
                    client.Connect("sandbox.smtp.mailtrap.io", 2525, MailKit.Security.SecureSocketOptions.StartTls);
                    client.Authenticate("2731fa4d5520a5", "8273f0e187b488");
                    client.Send(message);
                    Console.WriteLine("Email sent successfully through Mailtrap.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error sending email: {ex.Message}");
                }
                finally
                {
                    client.Disconnect(true);
                }
            }
        }
    }

}