using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace MediRed.Utilities
{
    public class Notification
    {
        SmtpClient server = new SmtpClient("smtp.gmail.com", 587);

        public Notification()
        {
            server.Credentials = new System.Net.NetworkCredential("MediredMsg@gmail.com", "MediredMs");
            server.EnableSsl = true;
        }

        public void MandarCorreo(MailMessage mensaje)
        {
            server.Send(mensaje);
        }
    }

    //using System.Net.Mail;
    //
    //try
    //        {
    //            MediRed.Utilities.Notification nf = new MediRed.Utilities.Notification();
    //MailMessage mnsj = new MailMessage();

    //mnsj.Subject = "Hola Mundo";

    //            mnsj.To.Add(new MailAddress("ecmcaceres@gmail.com"));

    //            mnsj.From = new MailAddress("MediredMsg@gmail.com", "Equipo Medired");

    //mnsj.Body = "  Mensaje de Prueba \n\n Enviado desde C#\n\n TRABAJA";

    //            /* Enviar */
    //            nf.MandarCorreo(mnsj);

    //            Console.WriteLine("Mensaje enviado correctamente");
    //        }
    //        catch (Exception)
    //        {
    //            Console.WriteLine("Mensaje No Enviado ");
    //        }
}