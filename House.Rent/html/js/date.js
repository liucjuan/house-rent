// JavaScript Document
today = new Date(); 
var isDay = new
Array("星期日","星期一","星期二","星期三","星期四","星期五","星期六","星期日"); 
date1 =today.getYear() + "年" + (today.getMonth() + 1 ) + "月" + today.getDate() + "日 "+isDay[today.getDay()]; 

document.write(date1.fontsize(2)); 
