console.log("2 ok");

//Operatörler
//Matematiksel opertörler
//+ - * / %
//++ -- **
//+= -= *= /= %=
// Mantıksal Operatörler
// < > <= >= == ! != === !== & | && ||
function kontrol(){
    var a = 10;
    var b = "10";
    console.log("a = " + typeof(a));
    console.log("b = " + typeof(b));
    if(a == b && typeof(a) == typeof(b)){   // === çalışma mantığı
        console.log("a=b");
    }
    else{
        console.log("a!=b");
    }
}

function faktoriyel(n){
    var sonuc = 1;
    for(var i = 1; i <= n; i++){
        sonuc *=i;
    }
    return sonuc;
}

var array =[1,2,3,4,5,6,7,8,9,10];
function diziDongu(){
    for(var i = 0 ; i < array.length; i++){
        var item = array[i];
        console.log(item);
    }
    console.log("foreach");
    array.forEach(item =>{
        console.log(item);
    });

    console.log("map");
    array.map(item => {
        console.log(item);
    });
}

//////// arrow function ///////////
var diziDongu2 = () =>{

    array.map((item,index,itself)=>{
        console.log("Index: "+index + " Değer:" + item);
        console.log("itself: "+itself);
        array[index] = item **2;
    });

}

var a = [1, 2, 3, 4, 5, 6, 6, 8, 9, 10, 2, 2]; //return 6
var b = [2, 4, 5, 3, 1, 1, 3, 4, 5, 5]; //return 1

function checkRepeat(array) {
  var distinct = [];
  for (var i = 1; i < array.length; i++) {
      var item1 = array[i-1];
      var item2 = array[i];
      if (item1 == item2 && distinct.indexOf(item1) == -1) {
          distinct.push(item1);
      }
  }
  return distinct.toString();
}

console.log(checkRepeat(a));
console.log(checkRepeat(b));

