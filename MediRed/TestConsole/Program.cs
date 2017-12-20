using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            
            try
            {
                MediRed.Utilities.Notification nf = new MediRed.Utilities.Notification();
                MailMessage mnsj = new MailMessage();

                mnsj.Subject = "Hola Mundo";

                mnsj.To.Add(new MailAddress("ecmcaceres@gmail.com"));

                mnsj.From = new MailAddress("MediredMsg@gmail.com", "Equipo Medired");

                mnsj.Body = "  Mensaje de Prueba \n\n Enviado desde C#\n\n TRABAJA";

                /* Enviar */
                nf.MandarCorreo(mnsj);

                Console.WriteLine("Mensaje enviado correctamente");
            }
            catch (Exception)
            {
                Console.WriteLine("Mensaje No Enviado ");
            }

            Console.ReadKey(true);
        }
    }
}
