﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Shop.Bussiness;
using Shop.Model;using DB.LebiShop;
using LB.Tools;

namespace Shop.Admin.agent
{
    public partial class areaagent_user_edit_window : AdminAjaxBase
    {
        protected Lebi_Agent_Area model;
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = RequestTool.RequestInt("id",0);
            //if (id == 0)
            //{
            //    if (!EX_Admin.Power("supplier_group_edit", "添加商家分组"))
            //    {
            //        WindowNoPower();
            //    }
            //}
            //else
            //{
            //    if (!EX_Admin.Power("supplier_group_edit", "编辑商家分组"))
            //    {
            //        WindowNoPower();
            //    }
            //}
            model = B_Lebi_Agent_Area.GetModel(id);
            if (model == null)
                model = new Lebi_Agent_Area();
        }
    }
}