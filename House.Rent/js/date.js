// JavaScript Document
today = new Date(); 
var isDay = new
Array("星期日","星期一","星期二","星期三","星期四","星期五","星期六","星期日"); 
date1 =today.getFullYear() + "年" + (today.getMonth() + 1 ) + "月" + today.getDate() + "日 "+isDay[today.getDay()]; 

document.write(date1.fontsize(2)); 


function loadcls(obj,pid,type)
{
    obj=document.getElementById(obj);
    obj.options.length=0;
    obj.options.add(new Option("请选择"+type, "0"));
    for(var i=0;i<provincearray.length;i++)
    {
        if(provincearray[i][1]==pid)
	        obj.options.add(new Option(provincearray[i][0], provincearray[i][2]));
    }
}
function selected(obj,hid,txt)
{
    if(hid.value!="")
    {
        for(var i=0;i<obj.options.length;i++)
        {
            if(obj.options[i].text==txt)
            {
                obj.options[i].selected=true;
                break;
            }
        }
    }
}  

function show()
{
    var ddl_yi=document.getElementById("ddl_yi");
    var hid=document.getElementById("hidclsid");
    var ddl_er=document.getElementById("ddl_er");
    
    if(hid.value!="")
    {
        var clspid="";
        for(var i=0;i<provincearray.length;i++)
        {
            if(hid.value==provincearray[i][2])
            {
                clspid=provincearray[i][1];
                loadcls("ddl_er",clspid,"二级分类");
                ddl_er.value=hid.value;
                ddl_yi.value=clspid;
                break;
            }
        }
    }
}
function kong()
{
    var title=document.getElementById("title");
    var name=document.getElementById("name");
    var ddl_yi=document.getElementById("ddl_yi");
    var ddl_er=document.getElementById("ddl_er");
    var hidclsid=document.getElementById("hidclsid");
    /*var pri=document.getElementById("pri");
    var num=document.getElementById("num");*/
    var tel=document.getElementById("tel");
    var add=document.getElementById("add");
    var intro=document.getElementById("intro");
    
    if(title.value=="")
    {
        alert("请输入标题");
        title.focus();
        return false;
    }
  
    if(ddl_yi.value=="0")
    {
        alert("请选择一级分类");
        ddl_yi.focus();
        return false;
    }
    
    else
    {
        hidclsid.value=ddl_er.value;   
    }
    /*if(pri.value=="")
    {
        alert("请输入价格");
        pri.focus();
        return false;
    }
    if(num.value=="")
    {
        alert("请输入库存");
        num.focus();
        return false;
    }*/
    if(tel.value=="")
    {
        alert("请输入电话");
        tel.focus();
        return false;
    }
    if(add.value=="")
    {
        alert("请输入地址");
        add.focus();
        return false;
    }
    if(intro.value=="")
    {
        alert("请输入简介");
        intro.focus();
        return false;
    }
}