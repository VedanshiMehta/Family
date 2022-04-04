using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using AndroidX.AppCompat.App;
using AndroidX.RecyclerView.Widget;
using Family.Model;
using Google.Android.Material.FloatingActionButton;
using System;
using System.Collections.Generic;

namespace Family
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private FloatingActionButton _floatingActionButtonAdd;
        private RecyclerView _recyclerViewFamilyDetails;
        private RecyclerView.LayoutManager _layoutManagerFamilyDetails;
        private FamilyAdapter _familyAdapter;
        private List<FamilyDetails> _familylist;
        private FamilyDatabase _familyDatabase;
      
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            UIReferences();
            UIClickEvents();
            

        }

        private void UIClickEvents()
        {
            _floatingActionButtonAdd.Click += _floatingActionButtonAdd_Click;
        }

        private void _floatingActionButtonAdd_Click(object sender, EventArgs e)
        {
            Intent i = new Intent(this, typeof(AddFamilyActivity));
            StartActivity(i);
        }

        private void UIReferences()
        {
            _floatingActionButtonAdd = FindViewById<FloatingActionButton>(Resource.Id.floatingActionButtonAdd);
            _recyclerViewFamilyDetails = FindViewById<RecyclerView>(Resource.Id.recyclerViewFamilyDetails);

            GetFamilyDetails();

            _layoutManagerFamilyDetails = new LinearLayoutManager(this);
            _recyclerViewFamilyDetails.SetLayoutManager(_layoutManagerFamilyDetails);

            _familyAdapter = new FamilyAdapter(_familylist,this);
            _recyclerViewFamilyDetails.SetAdapter(_familyAdapter);

        }

        private List<FamilyDetails> GetFamilyDetails()
        {
            _familyDatabase = new FamilyDatabase();
            var family = _familyDatabase.GetData();

            _familylist = new List<FamilyDetails>();
        
            _familylist.AddRange(family);

            return _familylist;
            
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}