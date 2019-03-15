﻿using System;
namespace DB.LebiShop
{
	[Serializable]
	public class Lebi_Type
	{
		#region Model
		private int _id=0;
		private string _class="";
		private string _color="";
		private string _description="";
		private string _name="";
		private int _sort=0;
		private string _UpdateCols="";
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		public string Class
		{
			set{ _class=value;}
			get{return _class;}
		}
		public string Color
		{
			set{ _color=value;}
			get{return _color;}
		}
		public string Description
		{
			set{ _description=value;}
			get{return _description;}
		}
		public string Name
		{
			set{ _name=value;}
			get{return _name;}
		}
		public int Sort
		{
			set{ _sort=value;}
			get{return _sort;}
		}
		public string UpdateCols
		{
			set{_UpdateCols=value;}
			get{return _UpdateCols;}
		}
		#endregion

	}
}

