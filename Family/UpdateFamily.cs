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
        private FamilyDetail _familyDetails;
        private EditText _childNameU;
        private Button _addChildU;
        private Button _update;
        private FamilyDatabase _familyDatabase;
        List<EditText> _editTextChildnameU = new List<EditText>();
        private LinearLayout _linearLayoutU;
        private ChildData _childDataU;
        private List<ChildData> _childDatasU = new List<ChildData>();
        int ids = 0;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.familyUpdate);
            UIReferences();

            if (Intent.HasExtra("Familyid"))
            {
                ids = Intent.Extras.GetInt("Familyid", 0);

                _familyDatabase = new FamilyDatabase();

                _familyDetails = _familyDatabase.GetByFamilyId(ids);

                _motherNameU.Text = _familyDetails.motherName;
                _addressU.Text = _familyDetails.address;
                _fatherNameU.Text = _familyDetails.fatherName;

                Console.WriteLine(_familyDetails.ChildData);

                List<string> _child = new List<string>();
                _child = _familyDetails.ChildData.Select(x => x.childName).ToList();

                for (int i = 0; i < _child.Count; i++)
                {
                    var inflater = LayoutInflater.From(this).Inflate(Resource.Layout.updateChildEdittextLayout, null);
                    _linearLayoutU.AddView(inflater, _linearLayoutU.ChildCount);

                    for (int j = 0; j < _linearLayoutU.ChildCount; j++)
                    {
                        View _edittextView = _linearLayoutU.GetChildAt(j);

                        _childNameU = _edittextView.FindViewById<EditText>(Resource.Id.editTextUpdateChildName);

                        _childNameU.Text = _child[j];

                    }
                    _editTextChildnameU.Add(_childNameU);
                }




            }
            UIClickEvents();


        }

        private void UIClickEvents()
        {

            _update.Click += _update_Click;
           // _addChildU.Click += _addChildU_Click;
        }

        //private void _addchildu_click(object sender, eventargs e)
        //{
        //    var inflater = layoutinflater.from(this).inflate(resource.layout.updatechildedittextlayout, null);
        //    _linearlayoutu.addview(inflater, _linearlayoutu.childcount);


        //    for (int i = 0; i < _linearlayoutu.childcount; i++)
        //    {
        //        view _edittextview = _linearlayoutu.getchildat(i);

        //        _childnameu = _edittextview.findviewbyid<edittext>(resource.id.edittextupdatechildname);
        //        _edittextchildnameu.add(_childnameu);

        //    }
        //}

        private void _update_Click(object sender, EventArgs e)
        {
            if (_familyDetails != null)
            {
                _familyDetails.fatherName = _fatherNameU.Text;
                _familyDetails.motherName = _motherNameU.Text;

                _familyDetails.address = _addressU.Text;


                for (int i = 0; i < _editTextChildnameU.Count; i++)
                {
                    if (_editTextChildnameU[i] != null)
                    {

                        _childDataU = new ChildData();

                        _childDataU.childName = _editTextChildnameU[i].Text.ToString();
                        _childDataU.familyid = _familyDetails.id;
                       _childDataU.childid = i + 1;

                        //var insertChild = _childDatabase.InstertChild(_childData);

                        _childDatasU.Add(_childDataU);

                    }


                }

                _familyDetails.ChildData = _childDatasU;


                var updated = _familyDatabase.UpdateFamily(_familyDetails, ids);
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