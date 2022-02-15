using PM02_SQLiteEjericicio1._3.Controlador;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PM02_SQLiteEjericicio1._3
{
    public partial class App : Application
    {
        static DataBases database;
        public static DataBases BaseDatos
        {
            get
            {
                if (database == null)
                {
                    database = new DataBases(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "PM02.db3"));
                }

                return database;
            }


        }

        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
