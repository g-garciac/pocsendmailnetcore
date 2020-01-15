using System;
using System.Net;
using System.Net.Mail;

namespace SendEmailPoc
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Envío de correo usando smtp.gmail.com");
            Console.Write("Cuál es el usuario (user@gmail.com)? ");
            var usuario = Console.ReadLine();
            Console.Write("Cuál es la contraseña? ");
            var contraseña = Console.ReadLine();
            Console.Write("Cuál es el correo destinatario? ");
            var destinatario = Console.ReadLine();
            using (var client = new SmtpClient("smtp.gmail.com"))
            {
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(usuario, contraseña);
                using (var msg = new MailMessage())
                {
                    msg.From = new MailAddress("emisor@alguien.com");
                    msg.To.Add(destinatario);
                    msg.Body = "Contenido del correo de prueba";
                    msg.Subject = "Correo de prueba";
                    try
                    {
                        Console.WriteLine("Enviando correo...");
                        client.Send(msg);
                        Console.WriteLine("Correo enviado!");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Algo salió mal, quizás el problema se resuelva al permitir el acceso de aplicaciones poco seguras en la cuenta de GMail:\nhttps://www.google.com/settings/security/lesssecureapps");

                        Console.WriteLine("Mensaje de error:");
                        Console.WriteLine(e.Message);
                    }
                }
            }
        }
    }
}
