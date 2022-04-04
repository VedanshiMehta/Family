using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using AndroidX.ConstraintLayout.Widget;
using Family.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Android.Views.View;

namespace Family
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme")]
    class AddFamilyActivity : AppCompatActivity
    {
        private EditText _fatherName;
        private EditText _motherName;
        private EditText _address;
        private FamilyDetails _familyDetails;
        private EditText _childName;
        private Button _addChild;
        private Button _save;
        private FamilyDatabase _familyDatabase;
        private LinearLayout _linearLayout;
        private List<EditText> _editTextChildrenData = new List<EditText>();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.addFamilyLayout);
            _familyDatabase = new FamilyDatabase();
            _familyDatabase.CreateFamily();
            UIReferences();
            UIClickEvents();


        }

        private void UIReferences()
        {
            _fatherName = FindViewById<EditText>(Resource.Id.editTextFatherName);
            _motherName = FindViewById<EditText>(Resource.Id.editTextMotherName);
            _address = FindViewById<EditText>(Resource.Id.editTextAddress);
            _addChild = FindViewById<Button>(Resource.Id.buttonAddChild);
            _save = FindViewById<Button>(Resource.Id.buttonSave);
            _linearLayout = FindViewById<LinearLayout>(Resource.Id.linearLayoutAddEditText);

        }
        private void UIClickEvents()
        {
            _addChild.Click += _addChild_Click;
            _save.Click += _save_Click;
        }

        private void _save_Click(object sender, EventArgs e)
        {
            _familyDetails = new FamilyDetails();

            _familyDetails.fatherName = _fatherName.Text;
            _familyDetails.motherName = _motherName.Text;
            _familyDetails.address = _address.Text;



            for (int i = 0; i < _editTextChildrenData.Count; i++)
            {

                _familyDetails.childName = _editTextChildrenData[i].Text.ToString();


            }

           



            var inserted = _familyDatabase.InsertData(_familyDetails);
            if (inserted == true)
            {

                Toast.MakeText(this, "Data Inserted Successfully", ToastLength.Short).Show();
            }

            else
            {
                Toast.MakeText(this, "Data Insertion failed", ToastLength.Short).Show();

            }

            StartActivity(new Intent(this, typeof(MainActivity)));
        }

        private void _addChild_Click(object sender, EventArgs e)
        {

            var inflater = LayoutInflater.From(this).Inflate(Resource.Layout.addChildEdittextLayout, null);
            _linearLayout.AddView(inflater, _linearLayout.ChildCount);


            for (int i = 0; i < _linearLayout.ChildCount; i++)
            {
                View _edittextView = _linearLayout.GetChildAt(i);

                _childName = _edittextView.FindViewById<EditText>(Resource.Id.editTextChildName);


            }

            _editTextChildrenData.Add(_childName);


        }



    }



}
