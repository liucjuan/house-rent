using BirdSof;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web;

/// <summary>
/// ErrorType 的摘要说明
/// </summary>
public enum ErrorType
{
    [EnumDescription("成功")]
    Success = 0000,

    [EnumDescription("失败")]
    Failed = 0001,

    [EnumDescription("当前用户不存在")]
    BadUser = 0002,

    [EnumDescription("密码有误")]
    BadPassWord = 0003,
}


// string txt = EnumDescription.GetFieldText(ErrorType.BadPassWord);
