using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wap_TheThaoSo.Library.Component.Transaction
{
    public class ViSport_SubscriptionInfo
    {
        private int _iD;
        public int ID
        {
            get { return _iD; }
            set { _iD = value; }
        }

        private string _mSISDN;
        public string MSISDN
        {
            get { return _mSISDN; }
            set { _mSISDN = value; }
        }

        private int _updateType;
        public int UpdateType
        {
            get { return _updateType; }
            set { _updateType = value; }
        }

        private string _updateDesc;
        public string UpdateDesc
        {
            get { return _updateDesc; }
            set { _updateDesc = value; }
        }

        private DateTime _regisTime;
        public DateTime RegisTime
        {
            get { return _regisTime; }
            set { _regisTime = value; }
        }

        private DateTime _expiryTime;
        public DateTime ExpiryTime
        {
            get { return _expiryTime; }
            set { _expiryTime = value; }
        }

        private string _serviceID;
        public string ServiceID
        {
            get { return _serviceID; }
            set { _serviceID = value; }
        }
    }
}