using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace DemoListView.Android
{
    [Activity(Label = "DemoListView.Android", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 1;
        
        private string[] _listaItems;
        private ListView _myLista;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

           
            SetContentView(Resource.Layout.Main);

            _myLista = FindViewById<ListView>(Resource.Id.listView1);
           
            Button button = FindViewById<Button>(Resource.Id.MyButton);

            _listaItems = new string[]//Llenamos nuestra lista 
            {
                "Xamarin.Android",
                "blog's javierflo95",
                "Microsoft",
                "Millonarios",
                "Colombia",
                "Bogotá",
                "Mexico"
            };

            //Mostramos nuestra lista 
            _myLista.Adapter = new ArrayAdapter<String>(this, Android.Resource.Layout.ListaItems, _listaItems);
            _myLista.ItemClick += _myLista_ItemClick;//Creamos el metodo para capturar el item seleccionado
            button.Click += delegate { button.Text = string.Format("{0} clicks!", count++); };
        }

        void _myLista_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var _mensaje = _listaItems[e.Position];//Obtenemos el item seleccionado
            Toast.MakeText(this, _mensaje, ToastLength.Short).Show();//Mostramos el item
        }
    }
}

