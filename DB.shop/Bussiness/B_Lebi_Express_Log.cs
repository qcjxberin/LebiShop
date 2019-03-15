﻿using System;
using System.Data;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using LB.DataAccess;
namespace DB.LebiShop
{
	/// <summary>
	/// 业务逻辑类B_Lebi_Express_Log 的摘要说明。
	/// </summary>
	public partial class B_Lebi_Express_Log
	{
		public B_Lebi_Express_Log()
		{}
		#region  成员方法

		/// <summary>
		/// 返回单个字符串
		/// </summary>
		public static string GetValue(string col,string where, int seconds=0)
		{
			return D_Lebi_Express_Log.Instance.GetValue(col,where,seconds);
		}


		/// <summary>
		/// 返回记录条数
		/// </summary>
		public static int Counts(string where, int seconds=0)
		{
			return D_Lebi_Express_Log.Instance.Counts(where,seconds);
		}
		public static int Counts(SQLPara para, int seconds=0)
		{
			return D_Lebi_Express_Log.Instance.Counts(para,seconds);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public static int Add(Lebi_Express_Log model)
		{
			return D_Lebi_Express_Log.Instance.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public static void Update(Lebi_Express_Log model)
		{
			D_Lebi_Express_Log.Instance.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public static void Delete(int id)
		{
			
			D_Lebi_Express_Log.Instance.Delete(id);
		}
		/// <summary>
		/// 删除多条数据  by where条件
		/// </summary>
		public static void Delete(string where)
		{
			
			D_Lebi_Express_Log.Instance.Delete(where);
		}
		/// <summary>
		/// 删除多条数据
		/// </summary>
		public static void Delete(SQLPara para)
		{
			
			D_Lebi_Express_Log.Instance.Delete(para);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public static Lebi_Express_Log GetModel(int id, int seconds=0)
		{
			
			return D_Lebi_Express_Log.Instance.GetModel(id,seconds);
		}
		/// <summary>
		/// 得到一个对象实体 by where条件
		/// </summary>
		public static Lebi_Express_Log GetModel(string where, int seconds=0)
		{
			
			return D_Lebi_Express_Log.Instance.GetModel(where,seconds);
		}
		public static Lebi_Express_Log GetModel(SQLPara para, int seconds=0)
		{
			
			return D_Lebi_Express_Log.Instance.GetModel(para,seconds);
		}


		/// <summary>
		/// 得到最大ID
		/// </summary>
		public static int GetMaxId()
		{
			return D_Lebi_Express_Log.Instance.GetMaxID("");
		}
		public static int GetMaxId(SQLPara para)
		{
			return D_Lebi_Express_Log.Instance.GetMaxID(para);
		}
		public static int GetMaxId(string strWhere)
		{
			return D_Lebi_Express_Log.Instance.GetMaxID(strWhere);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public static List<Lebi_Express_Log> GetList(string strWhere,string strFieldOrder, int seconds=0)
		{
			return D_Lebi_Express_Log.Instance.GetList(strWhere,strFieldOrder,seconds);
		}
		public static List<Lebi_Express_Log> GetList(SQLPara para, int seconds=0)
		{
			return D_Lebi_Express_Log.Instance.GetList(para,seconds);
		}
		public static List<Lebi_Express_Log> GetList(string strWhere, string strFieldOrder, int PageSize, int page, int seconds=0)
		{
			return D_Lebi_Express_Log.Instance.GetList(strWhere,strFieldOrder,PageSize,page,seconds);
		}
		public static List<Lebi_Express_Log> GetList(SQLPara para, int PageSize, int page, int seconds=0)
		{
			return D_Lebi_Express_Log.Instance.GetList(para,PageSize,page,seconds);
		}

		/// <summary>
		/// 绑定表单数据
		/// </summary>
		public static Lebi_Express_Log BindForm(Lebi_Express_Log model)
		{
			
			return D_Lebi_Express_Log.Instance.BindForm(model);
		}
		/// <summary>
		/// 安全方式绑定表单数据
		/// </summary>
		public static Lebi_Express_Log SafeBindForm(Lebi_Express_Log model)
		{
			
			return D_Lebi_Express_Log.Instance.SafeBindForm(model);
		}

		#endregion  成员方法
	}
}

