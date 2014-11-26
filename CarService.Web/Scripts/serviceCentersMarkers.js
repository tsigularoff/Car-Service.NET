var map, lat,lon;

function initialize() {   
    lat = 42.69;
    lon = 23.32;
    var serviceCenters = $(".service-centers");

    var mapOptions = {
        zoom: 15,
        center: new google.maps.LatLng(lat, lon),
        mapTypeId: google.maps.MapTypeId.ROADMAP
    };    

    map = new google.maps.Map(document.getElementById('mapCanvas'),
        mapOptions);
       
    var markers = [];
    var infowindow = new google.maps.InfoWindow();

    for (var i = 0; i < serviceCenters.length; i++) {
        var serviceCenter = $(serviceCenters[i]);
        var scName = serviceCenter.children().first().val();
        

        var lat = serviceCenter.children().first().next().val() * 1;
        var lng = serviceCenter.children().last().val() * 1;
               
        var scLocation = new google.maps.LatLng(lat, lng);
        
        markers.push(new google.maps.Marker({
            position: scLocation,
            map: map,
            title : scName
        }));

        google.maps.event.addListener(markers[i], 'click', function () {           
            var cnt = '<div id="sc-info-cnt"> <h5>' + this.title + '</h5> </div>';

            infowindow.setContent(cnt);
           	infowindow.open(map, this);
            });
    }
}

navigator.geolocation.getCurrentPosition(function (position) {
    lat = position.coords.latitude;
    lon = position.coords.longitude;

    var userLocation = new google.maps.LatLng(lat, lon);
    map.panTo(userLocation); 
})
google.maps.event.addDomListener(window, 'load', initialize());
