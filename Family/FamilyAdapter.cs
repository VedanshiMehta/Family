using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.CardView.Widget;
using AndroidX.RecyclerView.Widget;
using Family.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Family
{
    class FamilyAdapter : RecyclerView.Adapter
    {
        private List<FamilyDetails> familylist;
        private MainActivity mainActivity;
        private FamilyDatabase _familyDatabase;
        private FamilyDetails _familyDetails;
        private List<string> _chlid = new List<string>();


        public FamilyAdapter(List<FamilyDetails> familylist, MainActivity mainActivity)
        {
            this.familylist = familylist;
            this.mainActivity = mainActivity;
        }

        public override int ItemCount => familylist.Count;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            FamilyViewHolder familyViewHolder = holder as FamilyViewHolder;
            familyViewHolder.BindData(familylist[position]);
            familyViewHolder._cardViewFamilyDetails.Click += (s, e) =>
            {
                Intent update = new Intent(mainActivity, typeof(UpdateFamily));
                update.PutExtra("Familyid", familylist[position].fid);
                mainActivity.StartActivity(update);


            };

            familyViewHolder._delete.Click += (s, e) =>
            {
                _familyDatabase = new FamilyDatabase();
                _familyDetails = _familyDatabase.GetFamilyDataByFamilyID(familylist[position].fid);
                if (_familyDetails != null)
                {
                    var deleted = _familyDatabase.DeleteData(_familyDetails);
                    if (deleted)
                    {
                        Toast.MakeText(mainActivity, "Data Deleted Successfully", ToastLength.Short).Show();
                    }
                    else
                    {
                        Toast.MakeText(mainActivity, "Data Deletion Failed", ToastLength.Short).Show();

                    }
                }

                mainActivity.StartActivity(new Intent(mainActivity, typeof(MainActivity)));
            };
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.FamilyDetailList, parent, false);
            return new FamilyViewHolder(view);
        }

        class FamilyViewHolder : RecyclerView.ViewHolder
        {
            public TextView _fathersName;
            public TextView _mothersName;
            public TextView _childsName;
            public TextView _addresss;
            public CardView _cardViewFamilyDetails;
            public ImageView _delete;

            public FamilyViewHolder(View itemView) : base(itemView)
            {
                _fathersName = itemView.FindViewById<TextView>(Resource.Id.textViewFatherName);
                _mothersName = itemView.FindViewById<TextView>(Resource.Id.textViewMotherName);
                _childsName = itemView.FindViewById<TextView>(Resource.Id.textViewChildName);
                _addresss = itemView.FindViewById<TextView>(Resource.Id.textViewAddressName);
                _cardViewFamilyDetails = itemView.FindViewById<CardView>(Resource.Id.cardViewFamilyDetails);
                _delete = itemView.FindViewById<ImageView>(Resource.Id.imageViewDelete);


            }

            internal void BindData(FamilyDetails familyDetails)
            {


                _fathersName.Text = familyDetails.fatherName;
                _mothersName.Text = familyDetails.motherName;
                _childsName.Text = familyDetails.childName;
                _addresss.Text = familyDetails.address;


            }
        }

    }
}