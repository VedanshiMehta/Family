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
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Family.Model
{
    [Table("ChildTable")]
    class ChildData
    {
        [PrimaryKey, AutoIncrement, Column("childid")]
        public int childid { get; set; }

        [Column("Fid"), ForeignKey(typeof(FamilyDetail))]
        public int familyid { get; set; }

        [Column("ChildName")]
        public string childName { get; set; }
    }
}