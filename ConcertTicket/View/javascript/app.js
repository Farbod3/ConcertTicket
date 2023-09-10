
// window.addEventListener("scroll",function(){

//   let navbar = document.querySelectorAll(".container .navbar");
//   if( window.scroll> 20 ){
//   navbar.classList.add("activen");}
// });

// let m1Btns = document.querySelectorAll(".a-menu");
// for(let i = 0;i < m1Btns.length;i++){
//     m1Btns[i].addEventListener("click", function () {
//         for(let j = 0;j < m1Btns.length;j++){
//             m1Btns[j].classList.remove("activem1");
//         }
//      m1Btns[i].classList.add("activem1");
 
//     })
// for (i = 0; i < m1Btns.length; i++) {
//  m1Btns[i].className =m1Btns[i].className.replace(" activem1", "");
// };
// };
let m2Btns = document.querySelectorAll(".a2-menu");
for(let i = 0;i < m2Btns.length;i++){
    m2Btns[i].addEventListener("click", function () {
        for(let j = 0;j < m2Btns.length;j++){
            m2Btns[j].classList.remove("activem2");
        }
     m2Btns[i].classList.add("activem2");
 
    });
};
// let menuicon = document.querySelectorAll(".menuicon");
// menuicon.addEventListener("click", function() {
//   let menuphone = document.querySelectorAll(".menu-phone");
//   menuphone.classList.add("active-menu-mobile");
// });
function openmenu(sidemenu ,navbar){
document.getElementById(sidemenu).style.display= "block";
document.getElementById(sidemenu).style.position= "fixed";
document.getElementById(navbar).style.position="relative";
};
let xmenu =document.querySelector(".xmenu");
xmenu.addEventListener("click",function(){ 
let menuphone=document.querySelector(".menu-phone");
menuphone.style.display="none";
document.getElementById("navbar").style.position="fixed";
});



function opentab(tabname) {
    var i;
    var x = document.getElementsByClassName("tab");
    for (i = 0; i < x.length; i++) {
      x[i].style.display = "none";
    }
    document.getElementById(tabname).style.display = "block";
  }
  function opentab1(tabname) {
    var x = document.getElementsByClassName("tab");
    document.getElementById(tabname).style.display = "block";
  };
  let xbutton=document.querySelector(".xbutton");
  xbutton.addEventListener("click",function(){
    document.getElementById("logintab").style.display = "none";
  });

  // let hame = document.querySelector(".hame");
  // hame.addEventListener("click",function(){
  //   let archive = document.querySelector(".archive-a");
  //   let hb = document.querySelector(".hb");
  //   hb.classList.remove("activem1")
  //   archive.classList.add("activem1");
  // }); 

  let arrowbtn =document.querySelector(".select-c");
  arrowbtn.addEventListener("click",function(){
  let dropdown =  document.querySelector(".drop-down-city");
  dropdown.classList.toggle("activedropdown");
  });
  
  function opentab2(tabname) {
    var i;
    var x = document.getElementsByClassName("tab");
    // for (i = 0; i < x.length; i++) {
    //   x[i].style.display = "none";
    // }
    document.getElementById(tabname).style.display = "block";
  }
  // function opentab3(tabname) {
  //   var i;
  //   var x = document.getElementsByClassName("tab");
  //   // for (i = 0; i < x.length; i++) {
  //   //   x[i].style.display = "none";
  //   // }
  //   document.getElementById(tabname).style.display = "block";
  // }
// ***********************************)***********************************************
// let SearchBtn = document.querySelector(".s-btn");
// SearchBtn.addEventListener("click",function(){
// let input=document.querySelector("s-input");
// **********************************************************************************
// })

// let changebackground =document.querySelector(".a-menu");
// changebackground.addEventListener("click",function(){
//     document.querySelector(".a-menu").computedStyleMap.background="red";
// })
// window.addEventListener("scroll", () => {
// const navbar = document.querySelector(".navbar");
// navbar.classList.toggle("sticky", window.scroll > 10)
// });
// const date = document.querySelector(".dateconcert".innerHTMl);
// alert(date);
// let menubg = document.querySelector(".a-menu");
// menubg.addEventListener("click",function (){

//     var current = document.getElementsByClassName("active");
//     current.className = current.className.replace(" active");
//     // this.className += " active";

// });
// var menubar = document.getElementById("menubar1");


// for (var i = 0; i < btns.length; i++) {
//   btns[i].addEventListener("click", function() {
//     var current = document.getElementsByClassName("active");
//     current[0].className = current[0].className.replace(" active");
//     this.className += " active";
//   });
// }
