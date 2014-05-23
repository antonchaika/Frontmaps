/*
* MvcMaps Preview 1 - A Unified Mapping API for ASP.NET MVC
* Copyright (c) 2009 Chris Pietschmann
* http://mvcmaps.codeplex.com
* Licensed under the Microsoft Reciprocal License (Ms-RL)
* http://mvcmaps.codeplex.com/license
*/
(function($mvc) {
    if (!$mvc.BingMap) {

        var $map = $mvc.BingMap = function(divid, options) {
            return new $map.fn.init(divid, options);
        };
        $map.prototype = $map.fn = new $mvc.MapBase;
        $map.fn.init = function(divid, options) {
            var opts = options;
            var that = this;

            this.id = options.id;
            this.divId = divid;

            var map = this.mapObject = new VEMap(divid);

            if (options.B_ClientToken) {
                map.SetClientToken(options.B_ClientToken);
            }

            map.onLoadMap = function() {
                if (opts.onLoad) {
                    opts.onLoad.apply(that, arguments);
                }

                if (opts.dynamicmap) {
                    that.setupDynamicMap(opts.dynamicmap);
                }
            };

            var latlng = null, zoom = null, maptype = null, vemapmode = null, showswitch = null, tilebuffer = null;
            var mapOptions = new VEMapOptions();

            if (options.lat && options.lng) {
                latlng = new VELatLong(options.lat, options.lng);
            }
            if (options.zoom) {
                zoom = options.zoom;
            }
            if (options.maptype) {
                maptype = options.maptype;
            }

            if (options.B_Mode) {
                vemapmode = options.B_Mode;
            }

            if (options.B_ShowSwitch !== undefined) {
                showswitch = options.B_ShowSwitch;
            }

            if (options.B_TileBuffer !== undefined) {
                tilebuffer = options.B_TileBuffer;
            }

            if (options.B_BirdseyeOrientation) {
                mapOptions.BirdseyeOrientation = options.B_BirdseyeOrientation;
            }

            if (options.B_EnableBirdseye !== undefined) {
                mapOptions.EnableBirdseye = options.B_EnableBirdseye;
            }

            if (options.B_EnableDashboardLabels !== undefined) {
                mapOptions.EnableDashboardLabels = options.B_EnableDashboardLabels;
            }

            if (options.B_LoadBaseTiles !== undefined) {
                mapOptions.LoadBaseTiles = options.B_LoadBaseTiles;
            }

            map.LoadMap(latlng, zoom, maptype,
                (options.fixed === true || options.fixed === false) ? options.fixed : null,
                vemapmode, showswitch, tilebuffer, mapOptions
                );



            var pi;

            if (options.pushpins) {
                this.plotPushpins(options.pushpins);
            }

            if (options.polylines) {
                this.plotPolylines(options.polylines);
            }

            if (options.polygons) {
                this.plotPolygons(options.polygons);
            }

            if (options.B_GeoRSS) {
                map.ImportShapeLayerData(new VEShapeSourceSpecification(VEDataType.GeoRSS, options.B_GeoRSS));
            }

            if (options.B_BingCollection) {
                map.ImportShapeLayerData(new VEShapeSourceSpecification(VEDataType.VECollection, options.B_BingCollection));
            }
        };

        $map.fn.clearDynamicMapData = function() {
            this.mapObject.Clear();
        };

        $map.fn.plotPolygons = function(polygons) {
            var p = null;
            for (pi = 0; pi < polygons.length; pi++) {
                p = polygons[pi];
                if (p.points) {
                    this.mapObject.AddShape($CreatePolygon(p));
                }
            }
        };

        $map.fn.plotPolylines = function(polylines) {
            var p = null;
            for (pi = 0; pi < polylines.length; pi++) {
                p = polylines[pi];
                if (p.points) {
                    this.mapObject.AddShape($CreatePolyline(p));
                }
            }
        };


        $map.fn.plotPushpins = function(pushpins) {
            var pushpinsToAdd = []; var pushpin = null;
            for (var i = 0; i < pushpins.length; i++) {
                pushpin = pushpins[i];
                if (pushpin.lat !== undefined && pushpin.lng !== undefined) {
                    pushpinsToAdd.push($CreatePushpin(pushpin));
                }
            }
            if (pushpinsToAdd.length > 0) {
                this.mapObject.AddShape(pushpinsToAdd);
            }
        };

        function $CreatePushpin(p) {
            var pushpinShape = new VEShape(VEShapeType.Pushpin, new VELatLong(p.lat, p.lng));
            if (p.title) {
                pushpinShape.SetTitle(p.title);
            }
            if (p.desc) {
                pushpinShape.SetDescription(p.desc);
            }

            var customIcon = new VECustomIconSpecification();
            if (p.imageurl) {
                customIcon.Image = p.imageurl;
            }
            pushpinShape.SetCustomIcon(customIcon);

            return pushpinShape;
        }

        function $CreatePolyline(p) {
            var rgb;
            var points = $toLatLngArray(p.points);

            var shape = new VEShape(VEShapeType.Polyline, points);

            if (p.lineweight !== undefined) {
                shape.SetLineWidth(p.lineweight);
            }

            if (p.linecolor) {
                rgb = $ColorConverter.toRGB(p.linecolor);
                shape.SetLineColor(new VEColor(rgb.r, rgb.g, rgb.b,
                    (p.lineopacity !== undefined ? p.lineopacity : 1.0)
                ));
            }

            if (p.B_showicon !== undefined) {
                if (p.B_showicon) {
                    shape.ShowIcon();
                } else {
                    shape.HideIcon();
                }
            }

            if (p.title) {
                shape.SetTitle(p.title);
            }
            if (p.desc) {
                shape.SetDescription(p.desc);
            }

            var customIcon = new VECustomIconSpecification();
            if (p.imageurl) {
                customIcon.Image = p.imageurl;
            }
            shape.SetCustomIcon(customIcon);

            return shape;
        }

        function $CreatePolygon(p) {
            var rgb;
            var points = $toLatLngArray(p.points);

            var shape = new VEShape(VEShapeType.Polygon, points);

            if (p.lineweight !== undefined) {
                shape.SetLineWidth(p.lineweight);
            }

            if (p.linecolor) {
                rgb = $ColorConverter.toRGB(p.linecolor);
                shape.SetLineColor(new VEColor(rgb.r, rgb.g, rgb.b,
                    (p.lineopacity !== undefined ? p.lineopacity : 1.0)
                ));
            }

            if (p.fillcolor) {
                rgb = $ColorConverter.toRGB(p.fillcolor);
                shape.SetFillColor(new VEColor(rgb.r, rgb.g, rgb.b,
                    (p.fillopacity !== undefined ? p.fillopacity : 1.0)
                ));
            }

            if (p.B_showicon !== undefined) {
                if (p.showicon) {
                    shape.ShowIcon();
                } else {
                    shape.HideIcon();
                }
            }

            if (p.title) {
                shape.SetTitle(p.title);
            }
            if (p.desc) {
                shape.SetDescription(p.desc);
            }

            var customIcon = new VECustomIconSpecification();
            if (p.imageurl) {
                customIcon.Image = p.imageurl;
            }
            shape.SetCustomIcon(customIcon);

            return shape;
        }

        function $toLatLngArray(points) {
            var p = [];
            for (var pi = 0; pi < points.length; pi++) {
                var ll = points[pi];
                p.push(new VELatLong(ll.lat, ll.lng));
            }
            return p;
        }

        $map.fn.getCenter = function() {
            var center = this.mapObject.GetCenter();
            return { lat: center.Latitude, lng: center.Longitude };
        };
        $map.fn.getZoom = function() {
            return this.mapObject.GetZoomLevel();
        };

//        $map.fn.setCenter = function(v) {
//            this.mapObject.SetCenter(new VELatLong(v.lat, v.lng));
//            return this;
//        };
//        $map.fn.setZoom = function(v) {
//            this.mapObject.SetZoomLevel(v);
//            return this;
//        };

        $map.fn.attachDynamicMapLoadEvents = function(options) {
            var that = this;
            var map = this.mapObject;
            map.AttachEvent("onchangeview", function() {
                that.loadDynamicMapData();
            });
        };

        $map.fn.getDynamicMapViewData = function() {
            var mapView = this.mapObject.GetMapView();
            var l1 = mapView.BottomRightLatLong;
            var l2 = mapView.TopLeftLatLong;
            return {
                minLat: $mvc.Utils.GetLowest(l1.Latitude, l2.Latitude),
                maxLat: $mvc.Utils.GetHighest(l1.Latitude, l2.Latitude),
                minLng: $mvc.Utils.GetLowest(l1.Longitude, l2.Longitude),
                maxLng: $mvc.Utils.GetHighest(l1.Longitude, l2.Longitude)
            };
        };

        $map.fn.init.prototype = $map.fn;
    }

    var $ColorConverter = (function() {
        return {
            toHTML: function(r, g, b) {
                return $ensureHexLength(r.toString(16)) + $ensureHexLength(g.toString(16)) + $ensureHexLength(b.toString(16));
            },
            toRGB: function(color) {
                var r, g, b;
                var html = color;

                // Parse out the RGB values from the HTML Code
                if (html.substring(0, 1) == "#") {
                    html = html.substring(1);
                }

                if (html.length == 3) {
                    r = html.substring(0, 1);
                    r = r + r;

                    g = html.substring(1, 2);
                    g = g + g;

                    b = html.substring(2, 3);
                    b = b + b;
                }
                else if (html.length == 6) {
                    r = html.substring(0, 2);
                    g = html.substring(2, 4);
                    b = html.substring(4, 6);
                }

                // Convert from Hex (Hexidecimal) to Decimal
                r = parseInt(r, 16);
                g = parseInt(g, 16);
                b = parseInt(b, 16);

                return { r: r, g: g, b: b };
            }
        };

        function $ensureHexLength(str) {
            if (str.length == 1) {
                str = "0" + str;
            }
            return str;
        }
    })();


})(MvcMaps);