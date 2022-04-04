using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Family.Model
{
   [Table("FamilyDetails")]
    class FamilyDetails
    {
       
       [PrimaryKey,AutoIncrement]
        public int fid { get; set; }

        [Column("FatherName")]
        public string fatherName { get; set; }

        [Column("MotherName")]
        public string motherName { get; set; }

        [Column("Address")]
        public string address { get; set; }

        [Column("ChildName")]
        public string childName { get; set; }


    }
}