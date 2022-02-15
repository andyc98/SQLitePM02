using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PM02_SQLiteEjericicio1._3.Vistas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VistaPersonas : ContentPage
{

        string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "PM02.db3");
        public VistaPersonas()
        {
            InitializeComponent();
        }
        private async void guardar_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(dbPath);

            var person = new Modelos.Personas
            {
                firstNames = nombres.Text,
                lastNames = apellidos.Text,
                age = Convert.ToInt32(edad.Text),
                address = direccion.Text,
                email = correo.Text
            };

            // db.Insert(person);
            var result = await App.BaseDatos.GuardarPersona(person);
            // DisplayAlert(null, person.firstNames + " " + person.lastNames + " guardado correctamente.", "OK");
            if (result == 1)
            {
                await DisplayAlert("Agregar", "Ingresado correctamente", "OK");
                var ListPersons = await App.BaseDatos.getListPersons();
            }
            else
            {
                await DisplayAlert("Agregar", "No se pudo guardar la información", "OK");
            }
            // Navigation.PopAsync();
            clearFormPerson();
        }

        private void clearFormPerson()
        {
            this.nombres.Text = String.Empty;
            this.apellidos.Text = String.Empty;
            this.edad.Text = String.Empty;
            this.direccion.Text = String.Empty;
            this.correo.Text = String.Empty;

        }
    }
}