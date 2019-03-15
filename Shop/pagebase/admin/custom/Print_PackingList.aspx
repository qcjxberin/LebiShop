﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Shop.Bussiness.PageBase.AdminCustomPageBase.cs" Inherits="Shop.Bussiness.AdminCustomPageBase" %>
<%@ Import Namespace="DB.LebiShop" %>
<%@ Import Namespace="Shop.Bussiness" %>
<%@ Import Namespace="Shop.Model" %>
<%@ Import Namespace="System.Collections.Generic" %>
<%
string id = LB.Tools.RequestTool.RequestSafeString("id");
int loop = LB.Tools.RequestTool.RequestInt("loop",0);
string where = "";
int Count = 1;
if (!id.Contains(",")){
    where = "id = lbsql{"+id+"}";
}else{
    string[] ids = id.Split(',');
    Count = ids.Count();
    if (ids[loop] != "")
    {
        where = "id = lbsql{"+ ids[loop] +"}";
    }
}
Lebi_Order model = B_Lebi_Order.GetModel(where);
if (model == null)
{
    model = new Lebi_Order();
}
List<Lebi_Order_Product> pros = B_Lebi_Order_Product.GetList("Order_id=" + model.id + "", "");
List<Lebi_Comment> comms = B_Lebi_Comment.GetList("TableName='Order' and Keyid=" + model.id + " and User_id = "+ model.User_id +" and Admin_id = 0", "id desc");
Lebi_Bill bill = B_Lebi_Bill.GetModel("Order_id = "+ model.id);
if (bill == null)
{
    bill = new Lebi_Bill();
}
%>
<html>
<head>
<title><%=Tag("装箱单")%>-<%=Tag("单据打印")%>-<%=site.title%></title>
<META name="author" content="LebiShop">
<link href="<%=site.AdminAssetsPath %>/plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet">
<link href="<%=site.AdminCssPath %>/style.css" rel="stylesheet">
<style>
body{background:#fff;margin:0;padding:0;font-size:12px;text-align:left;overflow:auto}h1,h2,h3{text-align:center;font-weight:bold;}h1{font-size:22px},h2{font-size:18px}h3{font-size:14px}input{font-size:12px}.order-print{width:754px;margin:0 auto}.order-print table{width:100%; margin-bottom:10px;border-collapse:collapse;}.order-print table td{border-bottom:1px solid #000}.order-print table th{text-align:left}
.order-print h2{margin:0 0 10px 0; padding:10px 0; border-bottom:1px dotted #000; font-weight:bold; font-size:15px; text-align:Center}
.order-print .headmenu{padding-left:5px; height:27px;color:#666;font-size:13px;font-weight:bold}
.order-print .list{border-top:1px solid #000}
.order-print .list th{padding-left:5px; line-height:25px; font-weight:normal; text-align:left; border-bottom:1px solid #000}
.order-print .list td{padding-left:5px; line-height:25px; text-align:left; background:#fff; border-bottom:1px solid #fff}
.order-print .list TR.list {background-color:expression((this.rowIndex%2==0)?"#FFFFFF":"#FFFFFF")}
.order-print .list TH.list .pro-pic {width: 45px; height: 45px}
.order-print .list TH.list .pro-pic IMG {width: expression(this.width > 45 ? 45 : true); height: expression(this.height > 45 ? 45 : true); max-width: 45px; max-height: 45px; vertical-align: middle; text-align: center}</style>
<style media=print>.print-btn{display:none;}</style>
<script type="text/javascript">
    javascript: window.print();
</script>
<%if ((loop+1) < Count){ %>
<script type="text/javascript">
    function NextPrint() {
        window.location.href = "?id=<%=id%>&loop=<%=loop+1 %>";
    }
    setTimeout("NextPrint()", 3000);
</script>
<%} %>
</head>
<body class="fix-sidebar fix-header card-no-border">
<div id="main-wrapper">
<div class="container-fluid">
<div class="row page-titles print-btn">
    <div class="col-md-12 col-12 align-self-center">
        <%if ((loop+1) < Count){ %>
            <a class="btn btn-default" href="?id=<%=id%>&loop=<%=loop+1 %>"><i class="ti-info-alt"></i> <%=Tag("下一个")%>(<%=Tag("剩余")%>：<%=Count-loop-1 %>)</a>
        <%} %>
        <button class="btn btn-info" onclick="window.print();"><i class="ti-printer"></i> <%=Tag("打印")%></button>
        <button class="btn btn-default" onclick="window.close();"><i class="ti-close"></i> <%=Tag("关闭")%></button>
    </div>
</div>
<div class="order-print">
<h1>中领国际实业有限公司</h1>
<h1>SINOLINK International Industrial Co.,Limited</h1>
<h3>ADD: Room H,15/F,Siu King Building.6 On Wah Street,Ngau Tau Kok.Kowloon,HongKong.</h3>
<h1>装箱单</h1>
<h1>Packing List</h1>
<table cellspacing="0" cellpadding="0" align="center">
<tr>
<th style="width:55%">
<table cellspacing="0" cellpadding="0" align="center">
<tr>
<th style="width:15%">致TO：</th><td><%=model.T_Address %> <%=Shop.Bussiness.EX_Area.GetAreaName(model.T_Area_id)%></td>
</tr>
<tr>
<th style="width:15%">由FROM：</th><td>Qindao,China</td>
</tr>
</table>
</th>
<th style="width:2%"></th>
<th style="width:43%">
<table cellspacing="0" cellpadding="0" border="1" align="center">
<tr>
<th style="width:50%;text-align:center">发票号Invoice No：</th><th><%=bill.BillNo %></th>
</tr>
</table>
<table cellspacing="0" cellpadding="0" align="center">
<tr>
<th style="width:22%">日期Date：</th><td><%=model.Time_Add %></td>
</tr>
<tr>
<th style="width:22%">致TO：</th><td><%=Shop.Bussiness.EX_Area.GetAreaName(model.T_Area_id,0)%></td>
</tr>
</table>
</th>
</tr>
</table>
<table cellspacing="0" cellpadding="0" border="1" align="center" class="list">
<tr>
<th style="width:14%;line-height:130%">商品编号Art No.</th>
<th>商品名称Goods Description</th>
<th style="width:10%;line-height:130%">件数Nos.of<br />Packages</th>
<th style="width:10%;line-height:130%">数量QTY</th>
<th style="width:10%;line-height:130%">单位Unit</th>
<th style="width:10%;line-height:130%">净重N.W<br />TONS</th>
<th style="width:10%;line-height:130%">毛重G.W<br />TONS</th>
<th style="width:10%;line-height:130%">体积<br />Volume<br />CBM</th>
</tr>
<%int totalqty = 0;decimal totalnetweight = 0;decimal totalweight = 0;decimal totalvolume = 0; foreach (DB.LebiShop.Lebi_Order_Product pro in pros)
  { %>
<tr class="list">
<th class="list"><%=pro.Product_Number%>&nbsp;</th>
<th class="list"><%=Shop.Bussiness.Language.Content(pro.Product_Name, "EN")%></th>
<th class="list"><%=pro.Count%></th>
<th class="list"><%if(pro.PackageRate>0){%><%=pro.Count*pro.PackageRate%><%}else{%><%=pro.Count%><%}%></th>
<th class="list"><%=Shop.Bussiness.Language.Content(Shop.Bussiness.EX_Product.ProductUnit(pro.Units_id), "EN")%></th>
<th class="list"><%=pro.Count*pro.NetWeight/1000%></th>
<th class="list"><%=pro.Count*pro.Weight/1000%></th>
<th class="list"><%=pro.Count*pro.Volume%></th>
</tr>
<%totalqty += pro.Count;totalnetweight += pro.Count*pro.NetWeight;totalweight += pro.Count*pro.Weight;totalvolume += pro.Count*pro.Volume;;
  } %>
<tr>
<td class="list" colspan="2" style="text-align:right">TOTAL:</td>
<th class="list"><%=totalqty%></th>
<th class="list">&nbsp;</th>
<th class="list">&nbsp;</th>
<th class="list"><%=totalnetweight%></th>
<th class="list"><%=totalweight%></th>
<th class="list"><%=totalvolume%></th>
</tr>
</table>
<table cellspacing="0" cellpadding="0" align="center">
<tr>
<th style="width:14%;text-align:right">B/L No.：</th><th><%=model.BLNo %></th>
</tr>
<tr>
<th style="width:14%;text-align:right">Container No.：</th><th><%=model.ContainerNo %></th>
</tr>
<tr>
<th style="width:14%;text-align:right">Seal No.：</th><th><%=model.SealNo %></th>
</tr>
</table>
</div>
</div>
</div>
</body>
</html>