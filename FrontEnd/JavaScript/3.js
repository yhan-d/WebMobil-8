console.log("3.js");
var changeColor = () => {
     var redColor = document.getElementById("range-red");
     var greenColor = document.getElementById("range-green");
     var blueColor = document.getElementById("range-blue");
     var pickerDiv = document.getElementById("picker");

     console.log([redColor.value,greenColor.value,blueColor.value]);
     //var color = "rgb("+ redColor.value + "," + greenColor.value + "," + blueColor.value +")";
     var color = `rgb(${redColor.value},${greenColor.value},${blueColor.value})`;
     var colorRev = `rgb(${255 - redColor.value},${255 -greenColor.value},${255 - blueColor.value})`;
     pickerDiv.innerHTML=color;
     pickerDiv.style.backgroundColor = color;
     pickerDiv.style.color = colorRev;
 }

 var copyClipboard = () => { // 
    var pickerDiv = document.getElementById("picker");
    navigator.clipboard.writeText(pickerDiv.innerHTML);
    alert("Copied: "+pickerDiv.innerHTML);

 }
 changeColor();