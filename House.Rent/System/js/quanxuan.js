// JScript 文件
function btn_xuan(obj)
{
    var arrlist=document.getElementsByTagName("input");
    for(var i=0;i<arrlist.length;i++)
    {
        if(arrlist[i].type=="checkbox")
        {
            if(obj.value==" 全 选 ")
            {
                arrlist[i].checked=true;
            }
            else
            {
                arrlist[i].checked=false;
            }
        }
    }
    if(obj.value==" 全 选 ")
    {
        obj.value="取消全选";
    }
    else
    {
        obj.value=" 全 选 ";
    }
}