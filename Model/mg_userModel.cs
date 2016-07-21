using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class mg_userModel
    {
        public mg_userModel()
		{}
		#region Model
		private int _id;
		private string _uno;
		private string _pwd;
		private string _name;
		private string _machineno;
		private string _photo;
		private int? _gongwei;
        private string _email;
        private int _depid;
        private int _posiid;
        private string _menuids;

      
		/// <summary>
		/// 
		/// </summary>
		public int user_id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string user_no
		{
			set{ _uno=value;}
			get{return _uno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string user_pwd
		{
			set{ _pwd=value;}
			get{return _pwd;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string user_name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 
		/// </summary>
        public string user_email
		{
            set { _email = value; }
            get { return _email; }
		}
		/// <summary>
		/// 
		/// </summary>
		public string machineNO
		{
			set{ _machineno=value;}
			get{return _machineno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string user_pic
		{
			set{ _photo=value;}
			get{return _photo;}
		}

        /// <summary>
        /// 
        /// </summary>
        public int user_depid
        {
            set { _depid = value; }
            get { return _depid; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int user_posiid
        {
            set { _posiid = value; }
            get { return _posiid; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string user_menuids
        {
            set { _menuids = value; }
            get { return _menuids; }
        }
		/// <summary>
		/// 工位位置：   1：左工位   2:又工位
		/// </summary>
		public int? gongwei
		{
			set{ _gongwei=value;}
			get{return _gongwei;}
		}
		#endregion Model
    }
}
