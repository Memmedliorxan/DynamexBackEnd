$(document).ready(function(){
    $(".calculate").click(function(){
        let dimensions = [];
            dimensions.push(parseInt($("#width").val()));
            dimensions.push(parseInt($("#length").val()));
            dimensions.push(parseInt($("#height").val()));
            dimensions.push(parseFloat($("#weight").val()));

        Calculate(dimensions);

        function Calculate (dimensions){
            $("#result").text("0.00");
            let result = dimensions[0] + dimensions[1] + dimensions[2] + dimensions[3];
            var countUp = new CountUp("result", 0.00, result, 2, 0.4);
            countUp.start();
        }
    });
});