using System;

namespace Wap_TheThaoSo.Library.Component
{
    public class UserInfo
    {
        private int _memberID;
        public int MemberID
        {
            get { return _memberID; }
            set { _memberID = value; }
        }

        private string _member_MSISDN;
        public string Member_MSISDN
        {
            get { return _member_MSISDN; }
            set { _member_MSISDN = value; }
        }

        private string _member_Nickname;
        public string Member_Nickname
        {
            get { return _member_Nickname; }
            set { _member_Nickname = value; }
        }

        private string _member_Password;
        public string Member_Password
        {
            get { return _member_Password; }
            set { _member_Password = value; }
        }

        private bool _member_IsActive;
        public bool Member_IsActive
        {
            get { return _member_IsActive; }
            set { _member_IsActive = value; }
        }

        private DateTime _member_RegisterOn;
        public DateTime Member_RegisterOn
        {
            get { return _member_RegisterOn; }
            set { _member_RegisterOn = value; }
        }

        private DateTime _member_DeactiveOn;
        public DateTime Member_DeactiveOn
        {
            get { return _member_DeactiveOn; }
            set { _member_DeactiveOn = value; }
        }

        private int _member_DeactiveBy;
        public int Member_DeactiveBy
        {
            get { return _member_DeactiveBy; }
            set { _member_DeactiveBy = value; }
        }

        private DateTime _member_ExpiredOn;
        public DateTime Member_ExpiredOn
        {
            get { return _member_ExpiredOn; }
            set { _member_ExpiredOn = value; }
        }

        private bool _member_IsLock;
        public bool Member_IsLock
        {
            get { return _member_IsLock; }
            set { _member_IsLock = value; }
        }

        private DateTime _member_ActiveOn;
        public DateTime Member_ActiveOn
        {
            get { return _member_ActiveOn; }
            set { _member_ActiveOn = value; }
        }

        private int _member_IsLockCount;
        public int Member_IsLockCount
        {
            get { return _member_IsLockCount; }
            set { _member_IsLockCount = value; }
        }

    }
}