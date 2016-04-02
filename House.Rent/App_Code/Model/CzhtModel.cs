using System;
using System.Collections.Generic;
using System.Web;

namespace Model
{
    /// <summary>
    /// CzhtModel 的摘要说明
    /// </summary>
    public class CzhtModel
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string path;

        public string Path
        {
            get { return path; }
            set { path = value; }
        }

        private string js;

        public string Js
        {
            get { return js; }
            set { js = value; }
        }

        private string title;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }
    }

}
