using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Web;

namespace Model
{
    /// <summary>
    /// ProClsModel 的摘要说明
    /// </summary>
    public class ProClsModel
    {
        private int pro_cls_id;

        public int Pro_cls_id
        {
            get { return pro_cls_id; }
            set { pro_cls_id = value; }
        }

        private string pro_cls_name;

        public string Pro_cls_name
        {
            get { return pro_cls_name; }
            set { pro_cls_name = value; }
        }

        private int pro_cls_pid;

        public int Pro_cls_pid
        {
            get { return pro_cls_pid; }
            set { pro_cls_pid = value; }
        }
    }

}
