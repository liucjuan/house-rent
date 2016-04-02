using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Management;

namespace Model
{
    /// <summary>
    /// HfModel 的摘要说明
    /// </summary>
    public class HfModel
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

      //  public int Lid { get; set; }

        private int lid;

        public int Lid
        {
            get { return lid; }
            set { lid = value; }
        }

        private string hfnr;

        public string Hfnr
        {
            get { return hfnr; }
            set { hfnr = value; }
        }
    }

}
