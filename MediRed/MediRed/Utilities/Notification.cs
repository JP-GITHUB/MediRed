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

    //mnsj.Subject = "Mensaje Urgente [Medired]";

    //            mnsj.To.Add(new MailAddress("xxxx@gmail.com"));

    //            mnsj.From = new MailAddress("MediredMsg@gmail.com", "Equipo Medired");

    //mnsj.Body = "Estimado Paciente \n\n Necesitamos que se comunique con su medico \n a la brevedad\n\n "+
    //                        "Su diagnostico requiere de atencion especial. \n\n\n\n Medired - Nos preocupamos por ti";

    //            /* Enviar */
    //            nf.MandarCorreo(mnsj);

    //            Console.WriteLine("Mensaje enviado correctamente");
    //        }
    //        catch (Exception)
    //        {
    //            Console.WriteLine("Mensaje No Enviado ");
    //        }
}