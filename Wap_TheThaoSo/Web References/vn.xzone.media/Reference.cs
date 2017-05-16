﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.17929.
// 
#pragma warning disable 1591

namespace Wap_TheThaoSo.vn.xzone.media {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="MOReceiverSoap", Namespace="http://tempuri.org/")]
    public partial class MOReceiver : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback ReceverMOOperationCompleted;
        
        private System.Threading.SendOrPostCallback ReturnUrlForAppOperationCompleted;
        
        private System.Threading.SendOrPostCallback VMG_ReturnUrlForGameOperationCompleted;
        
        private System.Threading.SendOrPostCallback VMG_ReturnUrlForApplicationOperationCompleted;
        
        private System.Threading.SendOrPostCallback ReturnWapUrlForGameOperationCompleted;
        
        private System.Threading.SendOrPostCallback ReturnUrlS2_ForGameOperationCompleted;
        
        private System.Threading.SendOrPostCallback ProcessAllOperationCompleted;
        
        private System.Threading.SendOrPostCallback ReturnWapUrlPackageOperationCompleted;
        
        private System.Threading.SendOrPostCallback XzoneReturnUrlOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public MOReceiver() {
            this.Url = global::Wap_TheThaoSo.Properties.Settings.Default.Wap_TheThaoSo_vn_xzone_media_MOReceiver;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event ReceverMOCompletedEventHandler ReceverMOCompleted;
        
        /// <remarks/>
        public event ReturnUrlForAppCompletedEventHandler ReturnUrlForAppCompleted;
        
        /// <remarks/>
        public event VMG_ReturnUrlForGameCompletedEventHandler VMG_ReturnUrlForGameCompleted;
        
        /// <remarks/>
        public event VMG_ReturnUrlForApplicationCompletedEventHandler VMG_ReturnUrlForApplicationCompleted;
        
        /// <remarks/>
        public event ReturnWapUrlForGameCompletedEventHandler ReturnWapUrlForGameCompleted;
        
        /// <remarks/>
        public event ReturnUrlS2_ForGameCompletedEventHandler ReturnUrlS2_ForGameCompleted;
        
        /// <remarks/>
        public event ProcessAllCompletedEventHandler ProcessAllCompleted;
        
        /// <remarks/>
        public event ReturnWapUrlPackageCompletedEventHandler ReturnWapUrlPackageCompleted;
        
        /// <remarks/>
        public event XzoneReturnUrlCompletedEventHandler XzoneReturnUrlCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/ReceverMO", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string ReceverMO(string User_ID, string Service_ID, string Command_Code, string Message, string Request_ID) {
            object[] results = this.Invoke("ReceverMO", new object[] {
                        User_ID,
                        Service_ID,
                        Command_Code,
                        Message,
                        Request_ID});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void ReceverMOAsync(string User_ID, string Service_ID, string Command_Code, string Message, string Request_ID) {
            this.ReceverMOAsync(User_ID, Service_ID, Command_Code, Message, Request_ID, null);
        }
        
        /// <remarks/>
        public void ReceverMOAsync(string User_ID, string Service_ID, string Command_Code, string Message, string Request_ID, object userState) {
            if ((this.ReceverMOOperationCompleted == null)) {
                this.ReceverMOOperationCompleted = new System.Threading.SendOrPostCallback(this.OnReceverMOOperationCompleted);
            }
            this.InvokeAsync("ReceverMO", new object[] {
                        User_ID,
                        Service_ID,
                        Command_Code,
                        Message,
                        Request_ID}, this.ReceverMOOperationCompleted, userState);
        }
        
        private void OnReceverMOOperationCompleted(object arg) {
            if ((this.ReceverMOCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ReceverMOCompleted(this, new ReceverMOCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/ReturnUrlForApp", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string ReturnUrlForApp(int appid) {
            object[] results = this.Invoke("ReturnUrlForApp", new object[] {
                        appid});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void ReturnUrlForAppAsync(int appid) {
            this.ReturnUrlForAppAsync(appid, null);
        }
        
        /// <remarks/>
        public void ReturnUrlForAppAsync(int appid, object userState) {
            if ((this.ReturnUrlForAppOperationCompleted == null)) {
                this.ReturnUrlForAppOperationCompleted = new System.Threading.SendOrPostCallback(this.OnReturnUrlForAppOperationCompleted);
            }
            this.InvokeAsync("ReturnUrlForApp", new object[] {
                        appid}, this.ReturnUrlForAppOperationCompleted, userState);
        }
        
        private void OnReturnUrlForAppOperationCompleted(object arg) {
            if ((this.ReturnUrlForAppCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ReturnUrlForAppCompleted(this, new ReturnUrlForAppCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/VMG_ReturnUrlForGame", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string VMG_ReturnUrlForGame(string gameid, int ispartner, string msisdn, int partnerid, string department, string servicetype, string telco, string description, string serviceid, string requestid) {
            object[] results = this.Invoke("VMG_ReturnUrlForGame", new object[] {
                        gameid,
                        ispartner,
                        msisdn,
                        partnerid,
                        department,
                        servicetype,
                        telco,
                        description,
                        serviceid,
                        requestid});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void VMG_ReturnUrlForGameAsync(string gameid, int ispartner, string msisdn, int partnerid, string department, string servicetype, string telco, string description, string serviceid, string requestid) {
            this.VMG_ReturnUrlForGameAsync(gameid, ispartner, msisdn, partnerid, department, servicetype, telco, description, serviceid, requestid, null);
        }
        
        /// <remarks/>
        public void VMG_ReturnUrlForGameAsync(string gameid, int ispartner, string msisdn, int partnerid, string department, string servicetype, string telco, string description, string serviceid, string requestid, object userState) {
            if ((this.VMG_ReturnUrlForGameOperationCompleted == null)) {
                this.VMG_ReturnUrlForGameOperationCompleted = new System.Threading.SendOrPostCallback(this.OnVMG_ReturnUrlForGameOperationCompleted);
            }
            this.InvokeAsync("VMG_ReturnUrlForGame", new object[] {
                        gameid,
                        ispartner,
                        msisdn,
                        partnerid,
                        department,
                        servicetype,
                        telco,
                        description,
                        serviceid,
                        requestid}, this.VMG_ReturnUrlForGameOperationCompleted, userState);
        }
        
        private void OnVMG_ReturnUrlForGameOperationCompleted(object arg) {
            if ((this.VMG_ReturnUrlForGameCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.VMG_ReturnUrlForGameCompleted(this, new VMG_ReturnUrlForGameCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/VMG_ReturnUrlForApplication", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string VMG_ReturnUrlForApplication(string appid, int ispartner, string msisdn, int partnerid, string department, string servicetype, string telco, string description, string serviceid, string requestid) {
            object[] results = this.Invoke("VMG_ReturnUrlForApplication", new object[] {
                        appid,
                        ispartner,
                        msisdn,
                        partnerid,
                        department,
                        servicetype,
                        telco,
                        description,
                        serviceid,
                        requestid});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void VMG_ReturnUrlForApplicationAsync(string appid, int ispartner, string msisdn, int partnerid, string department, string servicetype, string telco, string description, string serviceid, string requestid) {
            this.VMG_ReturnUrlForApplicationAsync(appid, ispartner, msisdn, partnerid, department, servicetype, telco, description, serviceid, requestid, null);
        }
        
        /// <remarks/>
        public void VMG_ReturnUrlForApplicationAsync(string appid, int ispartner, string msisdn, int partnerid, string department, string servicetype, string telco, string description, string serviceid, string requestid, object userState) {
            if ((this.VMG_ReturnUrlForApplicationOperationCompleted == null)) {
                this.VMG_ReturnUrlForApplicationOperationCompleted = new System.Threading.SendOrPostCallback(this.OnVMG_ReturnUrlForApplicationOperationCompleted);
            }
            this.InvokeAsync("VMG_ReturnUrlForApplication", new object[] {
                        appid,
                        ispartner,
                        msisdn,
                        partnerid,
                        department,
                        servicetype,
                        telco,
                        description,
                        serviceid,
                        requestid}, this.VMG_ReturnUrlForApplicationOperationCompleted, userState);
        }
        
        private void OnVMG_ReturnUrlForApplicationOperationCompleted(object arg) {
            if ((this.VMG_ReturnUrlForApplicationCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.VMG_ReturnUrlForApplicationCompleted(this, new VMG_ReturnUrlForApplicationCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/ReturnWapUrlForGame", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string ReturnWapUrlForGame(int gameid) {
            object[] results = this.Invoke("ReturnWapUrlForGame", new object[] {
                        gameid});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void ReturnWapUrlForGameAsync(int gameid) {
            this.ReturnWapUrlForGameAsync(gameid, null);
        }
        
        /// <remarks/>
        public void ReturnWapUrlForGameAsync(int gameid, object userState) {
            if ((this.ReturnWapUrlForGameOperationCompleted == null)) {
                this.ReturnWapUrlForGameOperationCompleted = new System.Threading.SendOrPostCallback(this.OnReturnWapUrlForGameOperationCompleted);
            }
            this.InvokeAsync("ReturnWapUrlForGame", new object[] {
                        gameid}, this.ReturnWapUrlForGameOperationCompleted, userState);
        }
        
        private void OnReturnWapUrlForGameOperationCompleted(object arg) {
            if ((this.ReturnWapUrlForGameCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ReturnWapUrlForGameCompleted(this, new ReturnWapUrlForGameCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/ReturnUrlS2_ForGame", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string ReturnUrlS2_ForGame(int gameid, string msisdn) {
            object[] results = this.Invoke("ReturnUrlS2_ForGame", new object[] {
                        gameid,
                        msisdn});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void ReturnUrlS2_ForGameAsync(int gameid, string msisdn) {
            this.ReturnUrlS2_ForGameAsync(gameid, msisdn, null);
        }
        
        /// <remarks/>
        public void ReturnUrlS2_ForGameAsync(int gameid, string msisdn, object userState) {
            if ((this.ReturnUrlS2_ForGameOperationCompleted == null)) {
                this.ReturnUrlS2_ForGameOperationCompleted = new System.Threading.SendOrPostCallback(this.OnReturnUrlS2_ForGameOperationCompleted);
            }
            this.InvokeAsync("ReturnUrlS2_ForGame", new object[] {
                        gameid,
                        msisdn}, this.ReturnUrlS2_ForGameOperationCompleted, userState);
        }
        
        private void OnReturnUrlS2_ForGameOperationCompleted(object arg) {
            if ((this.ReturnUrlS2_ForGameCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ReturnUrlS2_ForGameCompleted(this, new ReturnUrlS2_ForGameCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/ProcessAll", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool ProcessAll(string src, string desc, int type) {
            object[] results = this.Invoke("ProcessAll", new object[] {
                        src,
                        desc,
                        type});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void ProcessAllAsync(string src, string desc, int type) {
            this.ProcessAllAsync(src, desc, type, null);
        }
        
        /// <remarks/>
        public void ProcessAllAsync(string src, string desc, int type, object userState) {
            if ((this.ProcessAllOperationCompleted == null)) {
                this.ProcessAllOperationCompleted = new System.Threading.SendOrPostCallback(this.OnProcessAllOperationCompleted);
            }
            this.InvokeAsync("ProcessAll", new object[] {
                        src,
                        desc,
                        type}, this.ProcessAllOperationCompleted, userState);
        }
        
        private void OnProcessAllOperationCompleted(object arg) {
            if ((this.ProcessAllCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ProcessAllCompleted(this, new ProcessAllCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/ReturnWapUrlPackage", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string ReturnWapUrlPackage(string code) {
            object[] results = this.Invoke("ReturnWapUrlPackage", new object[] {
                        code});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void ReturnWapUrlPackageAsync(string code) {
            this.ReturnWapUrlPackageAsync(code, null);
        }
        
        /// <remarks/>
        public void ReturnWapUrlPackageAsync(string code, object userState) {
            if ((this.ReturnWapUrlPackageOperationCompleted == null)) {
                this.ReturnWapUrlPackageOperationCompleted = new System.Threading.SendOrPostCallback(this.OnReturnWapUrlPackageOperationCompleted);
            }
            this.InvokeAsync("ReturnWapUrlPackage", new object[] {
                        code}, this.ReturnWapUrlPackageOperationCompleted, userState);
        }
        
        private void OnReturnWapUrlPackageOperationCompleted(object arg) {
            if ((this.ReturnWapUrlPackageCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ReturnWapUrlPackageCompleted(this, new ReturnWapUrlPackageCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/XzoneReturnUrl", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string XzoneReturnUrl(string shortcode, string type) {
            object[] results = this.Invoke("XzoneReturnUrl", new object[] {
                        shortcode,
                        type});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void XzoneReturnUrlAsync(string shortcode, string type) {
            this.XzoneReturnUrlAsync(shortcode, type, null);
        }
        
        /// <remarks/>
        public void XzoneReturnUrlAsync(string shortcode, string type, object userState) {
            if ((this.XzoneReturnUrlOperationCompleted == null)) {
                this.XzoneReturnUrlOperationCompleted = new System.Threading.SendOrPostCallback(this.OnXzoneReturnUrlOperationCompleted);
            }
            this.InvokeAsync("XzoneReturnUrl", new object[] {
                        shortcode,
                        type}, this.XzoneReturnUrlOperationCompleted, userState);
        }
        
        private void OnXzoneReturnUrlOperationCompleted(object arg) {
            if ((this.XzoneReturnUrlCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.XzoneReturnUrlCompleted(this, new XzoneReturnUrlCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    public delegate void ReceverMOCompletedEventHandler(object sender, ReceverMOCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ReceverMOCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ReceverMOCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    public delegate void ReturnUrlForAppCompletedEventHandler(object sender, ReturnUrlForAppCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ReturnUrlForAppCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ReturnUrlForAppCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    public delegate void VMG_ReturnUrlForGameCompletedEventHandler(object sender, VMG_ReturnUrlForGameCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class VMG_ReturnUrlForGameCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal VMG_ReturnUrlForGameCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    public delegate void VMG_ReturnUrlForApplicationCompletedEventHandler(object sender, VMG_ReturnUrlForApplicationCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class VMG_ReturnUrlForApplicationCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal VMG_ReturnUrlForApplicationCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    public delegate void ReturnWapUrlForGameCompletedEventHandler(object sender, ReturnWapUrlForGameCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ReturnWapUrlForGameCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ReturnWapUrlForGameCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    public delegate void ReturnUrlS2_ForGameCompletedEventHandler(object sender, ReturnUrlS2_ForGameCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ReturnUrlS2_ForGameCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ReturnUrlS2_ForGameCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    public delegate void ProcessAllCompletedEventHandler(object sender, ProcessAllCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ProcessAllCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ProcessAllCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public bool Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    public delegate void ReturnWapUrlPackageCompletedEventHandler(object sender, ReturnWapUrlPackageCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ReturnWapUrlPackageCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ReturnWapUrlPackageCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    public delegate void XzoneReturnUrlCompletedEventHandler(object sender, XzoneReturnUrlCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class XzoneReturnUrlCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal XzoneReturnUrlCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591