﻿using System;
using System.Collections.Generic;
using System.Web;

using Shop.Model;using DB.LebiShop;
using Shop.Bussiness;
using LB.Tools;

namespace weixinpayh5
{
    public class WxPayException : Exception 
    {
        public WxPayException(string msg) : base(msg) 
        {

        }
     }
}