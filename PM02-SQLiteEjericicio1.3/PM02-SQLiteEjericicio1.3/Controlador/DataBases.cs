using PM02_SQLiteEjericicio1._3.Modelos;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PM02_SQLiteEjericicio1._3.Controlador
{
    public class DataBases
    {
        readonly SQLiteAsyncConnection db;

        public DataBases(String dirdb)
        {
            db = new SQLiteAsyncConnection(dirdb);
           
            db.CreateTableAsync<Modelos.Personas>().Wait();
        }

        public Task<List<Personas>> getListPersons()
        {
            return db.Table<Personas>().ToListAsync();
        }

        public Task<Personas> getPersonById(int parm)
        {
            return db.Table<Personas>()
                .Where(i => i.id == parm)
                .FirstOrDefaultAsync();
        }

        public Task<int> GuardarPersona(Personas persona)
        {
            if (persona.id != 0)
            {
                return db.UpdateAsync(persona);
            }
            else
            {
                return db.InsertAsync(persona);
            }

        }

        public Task<int> eliminarpersona(Personas persona)
        {
            return db.DeleteAsync(persona);
        }
    }
}
