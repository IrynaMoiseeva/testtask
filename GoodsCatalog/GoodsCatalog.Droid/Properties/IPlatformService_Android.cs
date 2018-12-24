using Android.Database.Sqlite;

using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using GoodsCatalog.Core.Services;

namespace GoodsCatalog.Droid.Properties
{

   

    public class PlatformService_Android : IPlatformService
    {
        public string GetPlatform() { return "android"; }

        public string DestinationPath
        {
            get { return Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "mydb.sqlite"); }
        }
       

        public void GetConnection()
        {
            
            string[] names = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceNames();
            var destinationPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "mydb.sqlite");
            //DestinationPath = destinationPath;
           /* using (Stream source = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("GoodsCatalog.Droid.Resources.raw.mydb.sqlite"))
            {
                using (var destination = System.IO.File.Create(destinationPath))
                {
                    source.CopyTo(destination);
                }
            }
            try
            {

                 con = new SQLiteConnection(destinationPath);


                con.CreateTable<FavoriteVideos>(SQLite.CreateFlags.ImplicitPK | SQLite.CreateFlags.AutoIncPK);

            }
            catch (Exception ex)
            {

                con.Dispose();
            }
*/
            
        }

       
    }

}






