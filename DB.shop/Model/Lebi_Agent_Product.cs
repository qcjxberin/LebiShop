﻿using System;
namespace DB.LebiShop
{
	[Serializable]
	public class Lebi_Agent_Product
	{
		#region Model
		private int _id=0;
		private int _product_id=0;
		private int _user_id=0;
		private string _user_username="";
		private string _UpdateCols="";
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		public int Product_id
		{
			set{ _product_id=value;}
			get{return _product_id;}
		}
		public int User_id
		{
			set{ _user_id=value;}
			get{return _user_id;}
		}
		public string User_UserName
		{
			set{ _user_username=value;}
			get{return _user_username;}
		}
		public string UpdateCols
		{
			set{_UpdateCols=value;}
			get{return _UpdateCols;}
		}
		#endregion

	}
}

