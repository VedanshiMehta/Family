using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Family.Model
{
    [Table("FamilyDetail")]
    class FamilyDetail
    {
        [PrimaryKey, AutoIncrement, Column("Fid")]
        public int id { get; set; }

        [Column("FatherName")]
        public string fatherName { get; set; }

        [Column("MotherName")]
        public string motherName { get; set; }

        [Column("Address")]
        public string address { get; set; }

        [OneToMany]
        public List<ChildData> ChildData { get; set; }
    }
}