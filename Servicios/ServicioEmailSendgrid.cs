using Portafolio.Models;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Portafolio.Servicios
{
    public interface IServicioEmail
    {
        Task EnviarEmail(ContactoViewModel contacto);
    }
    public class ServicioEmailSendgrid : IServicioEmail
    {
        private readonly IConfiguration configuration;
        public ServicioEmailSendgrid(IConfiguration configuration)
        {
            this.configuration = configuration;


        }

        public async Task EnviarEmail(ContactoViewModel contacto)
        {
            var apiKey = configuration.GetValue<string>("SENDGRID_API_KEY");
            var email = configuration.GetValue<string>("SENDGRID_FROM");
            var nombre = configuration.GetValue<string>("SENDGRID_NOMBRE");

            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(email, nombre);
            var subject = $"el cliente{ contacto.Email} quiere contactarte";
            var to = new EmailAddress(email, nombre);
            var mensajeTextoPlano = contacto.Mensaje; 
            var contenidoHTML =  @$"<h1>Hola {contacto.Nombre}</h1>
                                    <p>{contacto.Mensaje}</p>";       
            var singleEmail = MailHelper.CreateSingleEmail(from, to, subject, mensajeTextoPlano, contenidoHTML); 

            var response = await client.SendEmailAsync(singleEmail);
    }

    }
}