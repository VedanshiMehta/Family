using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Family.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Environment = System.Environment;

namespace Family
{
    //class ChildDatabase
    //{
    //    public static string DBName = "SQLite.db3";
    //    public static string DBPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), DBName);
    //    SQLiteConnection sqLiteConnection;

    //    public ChildDatabase()
    //    {
    //        try
    //        {
    //            Console.WriteLine(DBPath);
    //            sqLiteConnection = new SQLiteConnection(DBPath);
    //            Console.WriteLine("Database Created Successfully");
    //        }
    //        catch (Exception ex)
    //        {

    //            Console.WriteLine(ex);
    //        }

    //    }
    //    public void CreateChild()
    //    {

    //        try
    //        {

    //            var created = sqLiteConnection.CreateTable<ChildData>();
    //        }
    //        catch (Exception ex)
    //        {
    //            Console.WriteLine(ex);
    //        }
    //    }

    //    public bool InstertChild(ChildData childData)
    //    {

    //        var insert = sqLiteConnection.Insert(childData);
    //        if (insert == -1)
    //        {
    //            return false;
    //        }
    //        else
    //        {


    //            Console.WriteLine("Data Inserted Successfully");
    //            return true;
    //        }




    //    }

    //    public bool UpdateChild(ChildData childData)
    //    {
    //        var insert = sqLiteConnection.Update(childData);
    //        if (insert == -1)
    //        {
    //            return false;
    //        }
    //        else
    //        {

    //            Console.WriteLine("Data Updated Successfully");
    //            return true;   
    //        }

    //    }

    //    public bool DeleteFamily(ChildData childData)
    //    {
    //        var insert = sqLiteConnection.Delete(childData);
    //        if (insert == -1)
    //        {
    //            return false;
    //        }
    //        else
    //        {

    //            Console.WriteLine("Data Inserted Successfully");
    //            return true;
    //        }

    //    }

    //    public List<ChildData> ReadFamily()
    //    {
    //        try
    //        {
    //            var childDetails = sqLiteConnection.Table<ChildData>().ToList();
    //            return childDetails;
    //        }

    //        catch (Exception ex)
    //        {
    //            Console.WriteLine("Database Exception:" + ex);
    //            return null;
    //        }

    //    }

    //    public ChildData GetByChildId(int childid)
    //    {
    //        var child = sqLiteConnection.Table<ChildData>().Where(u => u.childid == childid).FirstOrDefault();

    //        return child;

    //    }
    //}
}