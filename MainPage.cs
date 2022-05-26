

namespace MauiArcgisTest
{
    using Esri.ArcGISRuntime.Geometry;
    using Esri.ArcGISRuntime.UI;
    using Map = Esri.ArcGISRuntime.Mapping.Map;

    public partial class MainPage : ContentPage
    {
        private MapView _myMapView;

        public MainPage()
        {
            var map = new Esri.ArcGISRuntime.Mapping.Map(BasemapStyle.ArcGISChartedTerritory);
            var sketchEditor = new SketchEditor();
            _myMapView = new MapView()
            {
                Map = map,
                SketchEditor = sketchEditor
            };
            Build();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await Task.Delay(5000);
            await _myMapView.SetViewpointAsync(new Viewpoint(new MapPoint(-117, 34, SpatialReferences.Wgs84), 1000000));
        }
        private void Build()
        {
            Content = new ScrollView()
            {
                Content = _myMapView
            };
        }


    }
}
