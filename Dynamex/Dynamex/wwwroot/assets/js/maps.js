function initMap() {
    
    // The map, centered at Centeral branch
    const map = new google.maps.Map(document.getElementById("maps"), {
      zoom: 10,
      center: {lat: 40.38031458397467, lng: 49.84925676945667}
    });

    // Array of locations
    var locations = [ 
        // Coordinates Centeral branch
        {lat: 40.38031458397467, lng: 49.84925676945667},
        // Coordinates Akhmedli branch
        {lat: 40.376741051366054, lng: 49.956125824783165},
        // Coordinates Khaglar branch
        {lat: 40.39763516177458, lng: 49.95512159983386},
        // Coordinates Bakikhanov branch
        {lat: 40.41659998493887, lng: 49.964640741871435},
        // Coordinates Yasamal branch
        {lat: 40.38550590238793, lng: 49.80311829547735},
        // Coordinates Khirdalan branch
        {lat: 40.44665828042294, lng: 49.75057952844856},
        // Coordinates Sumgayit branch
        {lat: 40.58063089387791, lng: 49.680141946805755},
        // Coordinates Ganja branch
        {lat: 40.69544919843517, lng: 46.389628048059635}
    ];

    // Loop through locations to add markers
    for (var i = 0; i < locations.length; i++) {
        addMarker(locations[i]);
    }

    // Add marker function
    function addMarker(coords){
        const marker = new google.maps.Marker({
            position: coords,
            map: map,
            animation: google.maps.Animation.DROP
        });
    }
  }
