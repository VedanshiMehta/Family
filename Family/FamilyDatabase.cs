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
    class FamilyDatabase
    {
        public static string DBName = "SQLite.db3";
        public static string DBPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), DBName);
        SQLiteConnection sQLiteConnection;

        public FamilyDatabase()
        {
            try {

                Console.WriteLine(DBPath);
                sQLiteConnection = new SQLiteConnection(DBPath);
                Console.WriteLine("Sucessfully Database Created");

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
                var create = sQLiteConnection.CreateTable<FamilyDetails>();
            }
            catch(Exception ex)
            {

                Console.WriteLine(ex); 
            }
      
        }

        public bool InsertData(FamilyDetails familyDetails)
        {
            var insert = sQLiteConnection.Insert(familyDetails);
            if(insert == -1)
            {

                return false;
            }
            else
            {
                Console.WriteLine("Inserted Data Successfully");
                return true;
            }
      
        }

        public bool UpdateData(FamilyDetails familyDetails)
        {
            var update = sQLiteConnection.Update(familyDetails);
            if (update == -1)
            {

                return false;
            }
            else
            {
                Console.WriteLine("Updated Data Successfully");
                return true;
            }

        }

        public bool DeleteData(FamilyDetails familyDetails)
        {
            var delete = sQLiteConnection.Delete(familyDetails);
            return true;

        }

        public List<FamilyDetails> GetData()
        {
            
                 var data = sQLiteConnection.Table<FamilyDetails>().ToList();
                return data;

           
            
           
            


        }

          public FamilyDetails GetFamilyDataByFatherName(string familyfather)
        {

            var family = sQLiteConnection.Table<FamilyDetails>().Where(u => u.fatherName == familyfather).FirstOrDefault();
            return family;

        }

        public FamilyDetails GetFamilyDataByFamilyID(int familyid)
        {

            var familyDetails = sQLiteConnection.Table<FamilyDetails>().Where(u => u.fid == familyid).FirstOrDefault();
            return familyDetails;

        }

    }
}