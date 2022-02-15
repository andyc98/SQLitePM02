using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace PM02_SQLiteEjericicio1._3.Modelos
{
    public class Personas
    {
        public string firstNames;
        public string lastNames;
        public int age;
        public string address;
        public string email;

        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        [MaxLength(70)]
        public string nombres { get; set; }
        [MaxLength(70)]
        public string apellidos{ get; set; }
        
        public int edad { get; set; }
        [MaxLength(100)]
        public string direccion{ get; set; }
        [MaxLength(100)]
        public string correo{ get; set; }
    }
}
