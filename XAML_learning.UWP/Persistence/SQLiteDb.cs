using System;
using System.IO;
using SQLite;
using Windows.Storage;
using Xamarin.Forms;
using XAML_learning.UWP;

[assembly: Dependency(typeof(SQLiteDb))]

namespace XAML_learning.UWP
{
    public class SQLiteDb : ISQLiteDb
    {
        public SQLiteAsyncConnection GetConnection()
        {
			var documentsPath = ApplicationData.Current.LocalFolder.Path;
        	var path = Path.Combine(documentsPath, "MySQLite.db3");
        	return new SQLiteAsyncConnection(path);
        }
    }
}

