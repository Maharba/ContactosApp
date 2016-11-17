using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite.Net;
using Xamarin.Forms;
using ContactosApp.Droid;

[assembly:Dependency(typeof(SQLiteServicio))]
namespace ContactosApp.Droid
{
    public class SQLiteServicio : ISQLite
    {
        public SQLiteConnection ObtenerConexion()
        {
            var archivoBaseDatos = "contactos.db3";
            string directorioBaseDatos = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string rutaCompleta = System.IO.Path.Combine(directorioBaseDatos, archivoBaseDatos);
            if (System.IO.File.Exists(rutaCompleta))
            {
                var plataforma = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
                var conexion = new SQLiteConnection(plataforma, rutaCompleta);
                return conexion;
            }
            else
            {
                System.IO.File.Create(rutaCompleta);
                var plataforma = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
                var conexion = new SQLiteConnection(plataforma, rutaCompleta);
                return conexion;
            }
        }
    }
}