using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace T_Shirt_Store.WebUI.AppCode.Extensions
{
    public static partial class Extension
    {
       // ^([\w -\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{ 1,3}\.)| (([\w -] +\.)+))([a - zA - Z]{ 2,4}|[0 - 9]{ 1,3})(\]?)$
       static public bool IsEmail( this string value) 
        {
            return Regex.IsMatch(value,  @"^([\w -\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{ 1,3}\.)| (([\w -] +\.)+))([a - zA - Z]{ 2,4}|[0 - 9]{ 1,3})(\]?)$");
        }
    }
}
