﻿using Android.App;
using Android.OS;
using Itinero.Code.Samples;
using SQLite.Net.Platform.XamarinAndroid;

namespace Itinero.Android.Samples
{
    [Activity(Label = "Itinero.Android.Samples", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            Setup.Do();

            SetContentView(Resource.Layout.Main);

            var mapControl = FindViewById<MapControl>(Resource.Id.mapcontrol);

            //mapControl.Map.Layers.Add(OsmTilesSample.CreateLayer());
            mapControl.Map.Layers.Add(MbTilesSample.CreateLayer(new SQLitePlatformAndroid(), Setup.DatabasePath));
            mapControl.Map.Layers.Add(LineStringSample.CreateLayer());
            mapControl.Map.Layers.Add(CitiesLayerSample.CreateLayer());
            
            mapControl.ShowCurrentLocation = true;



            mapControl.Map.Viewport.RenderResolutionMultiplier = 2;
        }
    }
}

