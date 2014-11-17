var userPosition;

$("#distance-btn").on('click', calculateDistances);

calculateDistances();

function calculateDistances() {   
    getUserPostion();   
}

function getUserPostion() {
    if (userPosition) {
        insertDistances();
    } else {
        navigator.geolocation.getCurrentPosition(function (position) {

            userPosition = {
                lat: position.coords.latitude,
                lng: position.coords.longitude
            }

            insertDistances();
        })
    }
}


function insertDistances() {

    data = $('#service-centers').data('kendoGrid')._data;

    for (var i = 0; i < data.length; i += 1) {
        var coords = data[i].Location.split(";");
        var destination = {
            lat: coords[0] * 1,
            lng: coords[1] * 1
        }

        data[i].DistanceTo = getDistance(userPosition, destination).toFixed(2);        
    }
    
    $('#service-centers').data('kendoGrid').refresh();
}


function rad(x) {
    return x * Math.PI / 180;
};

function getDistance(p1, p2) {
    var R = 6378137; // Earth’s mean radius in meter
    var dLat = rad(p2.lat - p1.lat);
    var dLong = rad(p2.lng - p1.lng);
    var a = Math.sin(dLat / 2) * Math.sin(dLat / 2) +
      Math.cos(rad(p1.lat)) * Math.cos(rad(p2.lat)) *
      Math.sin(dLong / 2) * Math.sin(dLong / 2);
    var c = 2 * Math.atan2(Math.sqrt(a), Math.sqrt(1 - a));
    var d = R * c;
    return d / 1000; // returns the distance in meter
};