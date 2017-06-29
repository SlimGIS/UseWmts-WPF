Keywords: wmts, add wmts map, wmts service

# Add WMTS map into your apps

We recently added Wmts service support in our core features. Here is a nice [demo](https://github.com/SlimGIS/UseWmts-WPF) to show you how to use it. I think a sample is not enough. So this guide will discuss how to render a WMTS service from scratch. Let's first take a look at a preview here.

> This project already includes the runtime license. If your trial license is expired, it still can run the project by "ctrl + F5". Or [try executable](https://github.com/SlimGIS/UseWmts-WPF/releases). 

![wmts-wpf-preview](https://github.com/SlimGIS/UseWmts-WPF/blob/master/Screenshot.png?raw=true)

## Step 1, get the WMTS service URI
The first important thing we need to get is a WMTS service URI. This URI will be used as the basic URI to combine the other resource URIs. Here is an example URI from ArcGIS.
```
http://sampleserver6.arcgisonline.com/arcgis/rest/services/WorldTimeZones/MapServer/WMTS
```

## Step 2, visit the capabilities
When we get the service URI, we will peek what the service resource like. WMTS capabilities information will tell us. In WMTS specification, it usually provides two encoding modes for the URI.

- __KVP (Key-Value-Pair)__ means the URI is formed with a key value paired format. For the sample URI above, the capabilities URI becomes:

```
http://sampleserver6.arcgisonline.com/arcgis/rest/services/WorldTimeZones/MapServer/WMTS?service=WMTS&amp;request=GetCapabilities
```

- __RESTful__ means the URI is formed as the RESTful service, like a hierachy resource format. For the sample URI above, the capabilities URI becomes:
```
http://sampleserver6.arcgisonline.com/arcgis/rest/services/WorldTimeZones/MapServer/WMTS/1.0.0/WMTSCapabilities.xml
```

## __Step 3, create the layer__. 
Now we have get everything ready, the next thing is to create the layer instance. This layer is SlimGIS MapKit Core features, it can be used in WPF, WinForms and WebAPI products. Use the code below to create the layer instance. In this demo, we choose to use `RESTful encoding + WorldTimeZones layer + default style + GoogleMapsCompatible with png image format`.

```
WmtsLayer wmtsLayer = new WmtsLayer("http://sampleserver6.arcgisonline.com/arcgis/rest/services/WorldTimeZones/MapServer/WMTS");
wmtsLayer.Encoding = WmtsEncoding.RESTful;
wmtsLayer.Layer = "WorldTimeZones";
wmtsLayer.Style = "default";
wmtsLayer.TileMatrixSet = "GoogleMapsCompatible";
wmtsLayer.Format = "image/png";
```

Now, the last thing is to add the layer into the map. For example WPF:

```
Map1.MapUnit = GeoUnit.Meter;
LayerOverlay wmtsOverlay = new LayerOverlay(new[] { wmtsLayer });
Map1.Overlays.Add(wmtsOverlay);
Map1.ZoomTo(new GeoBound(-13450952.9269994, -3680716.09771399, 5764694.11157119, 8588337.56133263));
```

That's all for this this. If you like to know more, [leave us a message](mailto:support@slimgis.com).

## Related Resources
- [Source code](https://github.com/SlimGIS/UseWmts-WPF)
- [Map Kit Layers](https://slimgis.com/documents/layers)
- [About us](https://slimgis.com)
