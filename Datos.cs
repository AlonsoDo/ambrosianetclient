using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ambrosia
{
    class EventoDesconectar
    {
        public string NombreEvento { get; set; }
        public string IdCliente { get; set; }
    }

    class EventoAskForElements
    {
        public string NombreEvento { get; set; }
        public int PadreId { get; set; }
    }

    public class Evento
    {
        public string NombreEvento { get; set; }
    }

    public class Elemento
    {
        public int ElementoId { get; set; }
        public int PadreId { get; set; }
        public string Descripcion { get; set; }
        public string PathImg { get; set; }
        public int Final { get; set; }
        public decimal Precio { get; set; }
        public decimal Impuesto { get; set; }
    }

    public class GetElementsData
    {
        public string NombreEvento { get; set; }
        public List<Elemento> data { get; set; }
    }

    public class InfoNodo
    {
        public int IdNodo { get; set; }
        public int IdPadre { get; set; }
        public int IdRefMenu { get; set; }
        public int Unid { get; set; }
        public string Descripcion { get; set; }
        public int IdElemento { get; set; }
        public decimal Precio { get; set; }
        public decimal Impuesto { get; set; }
    }

    public class Path
    {
        public int PadreId { get; set; }
        public int Final { get; set; } 
    }
}
