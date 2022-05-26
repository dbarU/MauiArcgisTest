

namespace MauiArcgisTest
{
    using Esri.ArcGISRuntime.Geometry;
    using Esri.ArcGISRuntime.UI;
    using Reactive.Bindings;
    using Map = Esri.ArcGISRuntime.Mapping.Map;

    public partial class MainPage : ContentPage
    {
        public ReactiveProperty<Map> MyMap { get; } = new();
        public ReactiveProperty<MapView> MyMapView { get; } = new();
        public ReactiveProperty<SketchEditor> MySketchEditor { get; } = new(new SketchEditor());

        public MainPage()
        {
            MyMap.Value = new Esri.ArcGISRuntime.Mapping.Map(BasemapStyle.ArcGISChartedTerritory);
            MySketchEditor.Value = new SketchEditor();
            MyMapView.Value = new MapView()
            {
                Map = MyMap.Value,
                SketchEditor = MySketchEditor.Value
            };
            Build();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await Task.Delay(5000);
            await MyMapView.Value.SetViewpointAsync(new Viewpoint(new MapPoint(-117, 34, SpatialReferences.Wgs84), 1000000));
        }
        private void Build()
        {
            Content = new ScrollView()
            {
                Content = MyMapView.Value

            };
        }


    }
}
