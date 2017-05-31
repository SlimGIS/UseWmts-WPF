using SlimGis.MapKit.Geometries;
using SlimGis.MapKit.Layers;
using SlimGis.MapKit.Symbologies;
using SlimGis.MapKit.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SlimGIS.Samples.UseWmts
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void map_Loaded(object sender, RoutedEventArgs e)
        {
            map.MapUnit = GeoUnit.Meter;

            WmtsLayer arcgisWmtsLayer = new WmtsLayer("http://sampleserver6.arcgisonline.com/arcgis/rest/services/WorldTimeZones/MapServer/WMTS");
            arcgisWmtsLayer.TileMatrixSet = "GoogleMapsCompatible";
            arcgisWmtsLayer.Encoding = WmtsEncoding.RESTful;
            arcgisWmtsLayer.Layer = "WorldTimeZones";
            arcgisWmtsLayer.Style = "default";
            arcgisWmtsLayer.Format = "image/png";

            LayerOverlay wmtsOverlay = new LayerOverlay(new[] { arcgisWmtsLayer });
            wmtsOverlay.Name = "Wmts";
            map.Overlays.Add(wmtsOverlay);
            map.ZoomTo(new GeoBound(-13450952.9269994, -3680716.09771399, 5764694.11157119, 8588337.56133263));
        }
    }
}
