﻿using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Configuration;
using System.Web;
using System.Text.RegularExpressions;
using System.Text;
using Shop.Model;using DB.LebiShop;
using LB.Tools;


namespace Shop.Bussiness
{
    /// <summary>
    /// ImageHelper 的摘要说明
    /// </summary>
    public class FileHelper
    {

        static string ServerPath = System.Web.HttpContext.Current.Server.MapPath("~/");
        /// <summary>
        /// 保存原始图片的方法
        /// 290 成功
        /// 291 文件已经存在，请重命名后上传
        /// 292 没有可上传的文件
        /// 293 格式不支持
        /// 294 修剪尺寸不能是0
        /// 295 文件不存在
        /// 296 异常
        /// 297 长度超限
        /// </summary>
        /// <param name="FileUpload"></param>
        /// <param name="path"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static int UPLoad(HttpPostedFile FileUpload, string Path, string FileName)
        {
            Path = ServerPath + Path + "/";
            if (!File.Exists(Path))   //如果路径不存在，则创建
            {
                System.IO.Directory.CreateDirectory(Path);
            }
            if (FileUpload.ContentLength > 1)   //如果是true，则表示该控件有文件要上传
            {
                string fileContentType = FileUpload.ContentType;
                string name = FileUpload.FileName;                         //返回文件在客户端的完全路径（包括文件名全称）
                FileInfo file = new FileInfo(name);                        //FileInfo对象表示磁盘或网络位置上的文件。提供文件的路径，就可以创建一个FileInfo对象：                                       
                string webFilePath = Path + FileName;                      //完整的存储路径
                if (FileUpload.ContentLength > Convert.ToDecimal(ShopCache.GetBaseConfig().UpLoadLimit) * 1024 * 1024)
                {
                    return 297;
                }
                if (File.Exists(webFilePath))
                {
                    File.Delete(webFilePath);
                }
                try
                {
                    FileUpload.SaveAs(webFilePath);
                    //bool flag = CheckPictureSafe(webFilePath);
                    //if (flag)
                    return 290;
                    //else
                    //    return 296;
                }
                catch (Exception ex)
                {
                    return 296;
                    //Msg = ex.Message;
                }

                //else
                //{
                //    return 291;
                //    //Msg = "文件已经存在，请重命名后上传!";
                //}
            }
            else
            {
                return 292;
                //Msg = "没有可上传的文件";
            }


        }

        #region 删除
        public static void DeleteFile(string imgUrl)
        {


            try
            {
                Regex reg = new Regex("(http://([^/]*))", RegexOptions.IgnoreCase);
                string url = reg.Replace(imgUrl, "");
                string fileUrl = ServerPath + url;
                if (File.Exists(fileUrl))
                {
                    File.Delete(fileUrl);
                }
            }
            catch
            {

            }
        }
        public static bool IsExists(string imgUrl)
        {
            string fileUrl = ServerPath + imgUrl;
            if (File.Exists(fileUrl))
                return true;
            return false;
        }

        #endregion

        /// <summary>
        /// C#检测上传图片是否安全函数
        /// </summary>
        /// <param name="strPictureFilePath"></param>
        public static bool CheckPictureSafe(string strPictureFilePath)
        {
            bool strReturn = true;
            if (File.Exists(strPictureFilePath))
            {
                StringBuilder str_Temp = new StringBuilder();
                try
                {
                    using (StreamReader sr = new StreamReader(strPictureFilePath))    //按文本文件方式读取图片内容
                    {
                        String line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            str_Temp.Append(line);
                        }
                        //检测是否包含危险字符串
                        if (str_Temp == null)
                        {
                            strReturn = false;
                        }
                        else
                        {
                            string DangerString = "<script|iframe|.getfolder|.createfolder|.deletefolder|.createdirectory|.deletedirectory|.saveas|wscript.shell|script.encode|server.|.createobject|execute|activexobject|language=|include|filesystemobject|shell.application";
                            strReturn = RegexTool.Check(str_Temp.ToString(), DangerString);

                        }
                        sr.Close();
                    }
                    if (strReturn)
                    {
                        File.Delete(strPictureFilePath);
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);

                }
            }
            return true;
        }
    }

}
