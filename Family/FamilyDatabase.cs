using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Family.Model;
using SQLite;
using SQLiteNetExtensions.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Environment = System.Environment;

namespace Family
{
    class FamilyDatabase
    {
        public static string DBName = "SQLite.db3";
        public static string DBPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), DBName);
         public SQLiteConnection sQLiteConnection;

        public FamilyDatabase()
        {
            try
            {
                Console.WriteLine(DBPath);
                sQLiteConnection = new SQLiteConnection(DBPath);
                Console.WriteLine("Database Created Successfully");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
            }

        }
        public void CreateFamily()
        {

            try
            {

                var created = sQLiteConnection.CreateTable<FamilyDetail>();
                var createChild = sQLiteConnection.CreateTable<ChildData>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public bool InstertFamily(FamilyDetail familyDetails)
        {

            var insert = sQLiteConnection.Insert(familyDetails);
            foreach (ChildData child in familyDetails.ChildData)
            {
                sQLiteConnection.Insert(child);
            }
            if (familyDetails.ChildData.Count > 0)
                sQLiteConnection.UpdateWithChildren(familyDetails);
            if (insert == -1)
            {
                return false;
            }
            else
            {


                Console.WriteLine("Data Inserted Successfully");
                return true;
            }




        }

        public bool UpdateFamily(FamilyDetail familyDetails, int id)
        {
            familyDetails.id = id;
            var insert = sQLiteConnection.Update(familyDetails);
            foreach (ChildData child in familyDetails.ChildData)
            {
                sQLiteConnection.Update(child);
            }
            if (familyDetails.ChildData.Count > 0)
                sQLiteConnection.UpdateWithChildren(familyDetails);
            if (insert == -1)
            {
                return false;
            }
            else
            {

                Console.WriteLine("Data Updated Successfully");
                return true;
            }

        }

        public bool DeleteFamily(FamilyDetail familyDetails)
        {
            var insert = sQLiteConnection.Delete(familyDetails);
            if (insert == -1)
            {
                return false;
            }
            else
            {

                Console.WriteLine("Data Inserted Successfully");
                return true;
            }

        }

        public List<FamilyDetail> ReadFamily()
        {
            try
            {
                //var familyDetails = sQLiteConnection.Table<FamilyDetail>().ToList();
                var familyDetails = sQLiteConnection.GetAllWithChildren<FamilyDetail>().ToList();
                return familyDetails;
            }

            catch (Exception ex)
            {
                Console.WriteLine("Database Exception:" + ex);
                return null;
            }

        }

        public FamilyDetail GetByFamilyId(int familyid)
        {
            var userId = sQLiteConnection.GetAllWithChildren<FamilyDetail>().Where(u => u.id == familyid).FirstOrDefault();

            return userId;

        }
    }
}