console.log("3.js");
var changeColor = () => {
   var redColor = document.getElementById("range-red");
   var greenColor = document.getElementById("range-green");
   var blueColor = document.getElementById("range-blue");
   var pickerDiv = document.getElementById("picker");

   console.log([redColor.value, greenColor.value, blueColor.value]);
   //var color = "rgb("+ redColor.value + "," + greenColor.value + "," + blueColor.value +")";
   var color = `rgb(${redColor.value},${greenColor.value},${blueColor.value})`;
   var colorRev = `rgb(${255 - redColor.value},${255 - greenColor.value},${255 - blueColor.value})`;
   pickerDiv.innerHTML = color;
   pickerDiv.style.backgroundColor = color;
   pickerDiv.style.color = colorRev;
}

var copyClipboard = () => { // 
   var pickerDiv = document.getElementById("picker");
   navigator.clipboard.writeText(pickerDiv.innerHTML);

   Swal.fire({
      icon: 'info',
      title: 'Copy this?',
      showCancelButton: true,
      confirmButtonText: 'Save',
      cancelButtonText: `Cancel`,
   }).then((result) => {
      /* Read more about isConfirmed, isDenied below */
      if (result.isConfirmed) {
         Swal.fire('Copied!', pickerDiv.innerHTML, 'success')
      } else if (result.isDenied) {
         Swal.fire('Cancel', 'Changes are not copied', 'info')
      }
   })
   //  Swal.fire({
   //    icon: 'info',
   //    title: 'Copied...',
   //    text: pickerDiv.innerHTML,
   //    footer: 'Web Mobil 8 classroom'
   //  })

   //Swal.fire("Copied: "+pickerDiv.innerHTML);

   //alert("Copied: "+pickerDiv.innerHTML);

}

var divMouseOver = () => {
   var pickerDiv = document.getElementById("picker");
   pickerDiv.classList.add("animate__animated");
   pickerDiv.classList.add("animate__pulse");
};

var divMouseLeave = () => {
   var pickerDiv = document.getElementById("picker");
   pickerDiv.classList.remove("animate__animated");
   pickerDiv.classList.remove("animate__pulse");
};
changeColor();