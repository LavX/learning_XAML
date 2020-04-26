using SQLite;

namespace XAML_learning
{
    public interface ISQLiteDb
    {
        SQLiteAsyncConnection GetConnection();
    }
}

 