namespace SimpleShop.Context.Repositories;

public class DbConnection
{
    public static bool TestOption { get; set; }

    public static string GetConnection()
    {
        if (!TestOption)
        {
            return "Data Source=DatabaseShop.db";
        }

        return "Data Source=Test.db";
    }
}