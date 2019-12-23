using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ConsoleAppCoreSqlTableDep
{
   public class Cliente
    {
        [XmlAttribute]
        // al searializar la clase, toma el id como atributo
        //despues se accede a ese atributo
        public int Id { get; set; }
        public string Documento { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
   
        public byte Hijos { get; set; }
        public decimal Sueldo { get; set; }
    }
}
