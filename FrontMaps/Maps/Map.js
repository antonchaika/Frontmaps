/*
* MvcMaps Preview 1 - A Unified Mapping API for ASP.NET MVC
* Copyright (c) 2009 Chris Pietschmann
* http://mvcmaps.codeplex.com
* Licensed under the Microsoft Reciprocal License (Ms-RL)
* http://mvcmaps.codeplex.com/license
*/
(function() {

    var $ns = function(n) {
        var nsparts = n.split('.');
        var r = window;
        for (var i = 0; i < nsparts.length; i++) {
            var ns = r[nsparts[i]];
            if (!ns) {
                ns = r[nsparts[i]] = {};
            }
            r = ns;
        }
    };

    $ns("MvcMaps");

    MvcMaps.registerNamespace = $ns;

    if (!MvcMaps.MapBase) {
        var $MapBase = MvcMaps.MapBase = function(divid, options) { };
        $MapBase.prototype = $MapBase.fn = {
            id: null,
            divId: null,
            mapObject: null,
            init: function(divid, options) {
                throw "Not Implemented";
            },

            getCenter: NotImplemented,
            getZoom: NotImplemented,

            //            setCenter: NotImplemented,
            //            setZoom: NotImplemented,

            setupDynamicMap: function(options) {
                var that = this;
                this.dynamicMapOptions = options;
                this.attachDynamicMapLoadEvents(options);
                if (options.autoload === true) {
                    window.setTimeout(function() { that.loadDynamicMapData(); }, 100);
                }
            },
            attachDynamicMapLoadEvents: NotImplemented,
            getDynamicMapViewData: NotImplemented,

            loadDynamicMapData: function() {
                var that = this;
                jQuery.post(
                    this.dynamicMapOptions.url,
                    this.getDynamicMapViewData(),
                    function(data) {
                        if (that.dynamicMapOptions.displaydata !== undefined && typeof (that.dynamicMapOptions.displaydata) === "function") {
                            that.dynamicMapOptions.displaydata.apply(that, [data]);
                        } else {
                            if (data.code !== 200) {
                                alert(data.message + " (" + data.code + ")");
                            } else {
                                that.clearDynamicMapData();
                                that.plotPushpins(data.pushpins);
                                if (that.dynamicMapOptions.dataloaded !== undefined) {
                                    if (typeof (that.dynamicMapOptions.dataloaded) === "function") {
                                        that.dynamicMapOptions.dataloaded.apply(that, [data]);
                                    }
                                }
                            }
                        }
                    }, "json");
            },

            clearDynamicMapData: NotImplemented,
            plotPushpins: NotImplemented,
            plotPolylines: NotImplemented,
            plotPolygons: NotImplemented
        };
    }

    $ns("MvcMaps.Utils");
    MvcMaps.Utils.GetLowest = function(a, b) {
        return (a < b ? a : b);
    };

    MvcMaps.Utils.GetHighest = function(a, b) {
        return (a > b ? a : b);
    };


    function NotImplemented() {
        throw "Not Implemented";
    }

})();