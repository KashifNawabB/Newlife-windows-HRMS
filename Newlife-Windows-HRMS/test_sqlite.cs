using System;
using System.Data;
using System.Data.SQLite;

public class Test {
    public static void Main() {
        var con = new SQLiteConnection("Data Source=:memory:");
        con.Open();
        var cmd = con.CreateCommand();
        cmd.CommandText = "CREATE TABLE T (t time); INSERT INTO T VALUES ('15:30');";
        cmd.ExecuteNonQuery();
        var da = new SQLiteDataAdapter("SELECT t FROM T", con);
        var dt = new DataTable();
        try { da.Fill(dt); Console.WriteLine("Success: " + dt.Rows[0][0]); }
        catch (Exception ex) { Console.WriteLine("Exception: " + ex.Message); }
        
        var cmd2 = con.CreateCommand();
        cmd2.CommandText = "DELETE FROM T; INSERT INTO T VALUES ('15:30:00');";
        cmd2.ExecuteNonQuery();
        var dt2 = new DataTable();
        try { da.Fill(dt2); Console.WriteLine("Success2: " + dt2.Rows[0][0]); }
        catch (Exception ex) { Console.WriteLine("Exception2: " + ex.Message); }
    }
}
