using Portafolio.Models;

namespace Portafolio.Servicios
{

    public interface IRepositorioProyectos
    {
        List<Proyecto> ObtenerProyectos();
    }
    public class RepositorioProyectos : IRepositorioProyectos
    
    {
        public List<Proyecto> ObtenerProyectos()

        {
            return new List<Proyecto>()
            {

            new Proyecto
            {
            Titulo = "Proyecto 1",
            Descripcion = "Descripcion del proyecto 1",
            Link= "https://www.google.com",
            ImagenUrl = "https://www.google.com/images/branding/googlelogo/2x/googlelogo_color_272x92dp.png"
            }
            ,
            new Proyecto
            {
            Titulo = "Proyecto 2",
            Descripcion = "Descripcion del proyecto 2",
            Link= "https://www.google.com",
            ImagenUrl = "https://www.google.com/images/branding/googlelogo/2x/googlelogo_color_272x92dp.png"
            }
            ,
            new Proyecto
            {
            Titulo = "Proyecto 3",
            Descripcion = "Descripcion del proyecto 3",
            Link= "https://www.google.com",
            ImagenUrl = "https://www.google.com/images/branding/googlelogo/2x/googlelogo_color_272x92dp.png"
            }
            ,
            new Proyecto
            {
            Titulo = "Proyecto 4",
            Descripcion = "Descripcion del proyecto 4",
            Link= "https://www.google.com",
            ImagenUrl = "https://www.google.com/images/branding/googlelogo/2x/googlelogo_color_272x92dp.png"
            }

            };

        }

    }
}
