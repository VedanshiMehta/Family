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

namespace Family
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme")]
    public class UpdateFamily : AppCompatActivity
    {
        private EditText _fatherNameU;
        private EditText _motherNameU;
        private EditText _addressU;
        private FamilyDetails _familyDetails;
        private EditText _childNameU;
        private Button _addChildU;
        private Button _update;
        private FamilyDatabase _familyDatabase;
        List<EditText> _editTextChildnameU = new List<EditText>();
        private LinearLayout _linearLayoutU;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.familyUpdate);
            UIReferences();
            UIClickEvents();

            var inflater = LayoutInflater.From(this).Inflate(Resource.Layout.updateChildEdittextLayout, null);
            _linearLayoutU.AddView(inflater, _linearLayoutU.ChildCount);


            for (int i = 0; i < _linearLayoutU.ChildCount; i++)
            {
                View _edittextView = _linearLayoutU.GetChildAt(i);

                _childNameU = _edittextView.FindViewById<EditText>(Resource.Id.editTextUpdateChildName);
                _editTextChildnameU.Add(_childNameU);

            }

            if (Intent.Extras != null)
            {
                int id = Intent.Extras.GetInt("Familyid", 0);
                if (id != 0)
                {



                    _familyDatabase = new FamilyDatabase();

                    _familyDetails = _familyDatabase.GetFamilyDataByFamilyID(id);

                    _motherNameU.Text = _familyDetails.motherName;
                    _addressU.Text = _familyDetails.address;
                    _fatherNameU.Text = _familyDetails.fatherName;

                    _childNameU.Text = _familyDetails.childName.ToString();

                }


            }


        }

        private void UIClickEvents()
        {

            _update.Click += _update_Click;
            _addChildU.Click += _addChildU_Click;
        }

        private void _addChildU_Click(object sender, EventArgs e)
        {
            var inflater = LayoutInflater.From(this).Inflate(Resource.Layout.updateChildEdittextLayout, null);
            _linearLayoutU.AddView(inflater, _linearLayoutU.ChildCount);


            for (int i = 0; i < _linearLayoutU.ChildCount; i++)
            {
                View _edittextView = _linearLayoutU.GetChildAt(i);

                _childNameU = _edittextView.FindViewById<EditText>(Resource.Id.editTextUpdateChildName);
                _editTextChildnameU.Add(_childNameU);

            }
        }

        private void _update_Click(object sender, EventArgs e)
        {
            if (_familyDetails != null)
            {
                _familyDetails.fatherName = _fatherNameU.Text;
                _familyDetails.motherName = _motherNameU.Text;

                _familyDetails.address = _addressU.Text;

                for (int i = 0; i < _editTextChildnameU.Count; i++)
                {

                    _familyDetails.childName = _editTextChildnameU[i].Text.ToString();

                }


                var updated = _familyDatabase.UpdateData(_familyDetails);
                if (updated)
                {
                    Toast.MakeText(this, "Data Updated Successfully", ToastLength.Short).Show();
                }
                else
                {

                    Toast.MakeText(this, "Data Updation Failed", ToastLength.Short).Show();
                }

            }

            StartActivity(new Intent(this, typeof(MainActivity)));
        }



        private void UIReferences()
        {
            _fatherNameU = FindViewById<EditText>(Resource.Id.editTextUpdateFatherName);
            _motherNameU = FindViewById<EditText>(Resource.Id.editTextUpdateMotherName);
            _addressU = FindViewById<EditText>(Resource.Id.editTextUpdateAddress);
            _addChildU = FindViewById<Button>(Resource.Id.buttonUpdateAddChild);
            _update = FindViewById<Button>(Resource.Id.buttonUpdate);
            _linearLayoutU = FindViewById<LinearLayout>(Resource.Id.linearLayoutUpdate);
        }
    }
}