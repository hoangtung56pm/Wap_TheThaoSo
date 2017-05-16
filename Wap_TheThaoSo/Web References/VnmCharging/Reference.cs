﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18408
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.18408.
// 
#pragma warning disable 1591

namespace Wap_TheThaoSo.VnmCharging {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="WebServiceCharging3gSoap", Namespace="http://tempuri.org/")]
    public partial class WebServiceCharging3g : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback PaymentVnmOperationCompleted;
        
        private System.Threading.SendOrPostCallback PaymentVnmWithAccountOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public WebServiceCharging3g() {
            this.Url = global::Wap_TheThaoSo.Properties.Settings.Default.Wap_TheThaoSo_VnmCharging_WebServiceCharging3g;
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
        public event PaymentVnmCompletedEventHandler PaymentVnmCompleted;
        
        /// <remarks/>
        public event PaymentVnmWithAccountCompletedEventHandler PaymentVnmWithAccountCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/PaymentVnm", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string PaymentVnm(string msisdn, string price, string content, string servicename) {
            object[] results = this.Invoke("PaymentVnm", new object[] {
                        msisdn,
                        price,
                        content,
                        servicename});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void PaymentVnmAsync(string msisdn, string price, string content, string servicename) {
            this.PaymentVnmAsync(msisdn, price, content, servicename, null);
        }
        
        /// <remarks/>
        public void PaymentVnmAsync(string msisdn, string price, string content, string servicename, object userState) {
            if ((this.PaymentVnmOperationCompleted == null)) {
                this.PaymentVnmOperationCompleted = new System.Threading.SendOrPostCallback(this.OnPaymentVnmOperationCompleted);
            }
            this.InvokeAsync("PaymentVnm", new object[] {
                        msisdn,
                        price,
                        content,
                        servicename}, this.PaymentVnmOperationCompleted, userState);
        }
        
        private void OnPaymentVnmOperationCompleted(object arg) {
            if ((this.PaymentVnmCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.PaymentVnmCompleted(this, new PaymentVnmCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/PaymentVnmWithAccount", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string PaymentVnmWithAccount(string msisdn, string price, string content, string servicename, string userName, string userPass, string cpId) {
            object[] results = this.Invoke("PaymentVnmWithAccount", new object[] {
                        msisdn,
                        price,
                        content,
                        servicename,
                        userName,
                        userPass,
                        cpId});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void PaymentVnmWithAccountAsync(string msisdn, string price, string content, string servicename, string userName, string userPass, string cpId) {
            this.PaymentVnmWithAccountAsync(msisdn, price, content, servicename, userName, userPass, cpId, null);
        }
        
        /// <remarks/>
        public void PaymentVnmWithAccountAsync(string msisdn, string price, string content, string servicename, string userName, string userPass, string cpId, object userState) {
            if ((this.PaymentVnmWithAccountOperationCompleted == null)) {
                this.PaymentVnmWithAccountOperationCompleted = new System.Threading.SendOrPostCallback(this.OnPaymentVnmWithAccountOperationCompleted);
            }
            this.InvokeAsync("PaymentVnmWithAccount", new object[] {
                        msisdn,
                        price,
                        content,
                        servicename,
                        userName,
                        userPass,
                        cpId}, this.PaymentVnmWithAccountOperationCompleted, userState);
        }
        
        private void OnPaymentVnmWithAccountOperationCompleted(object arg) {
            if ((this.PaymentVnmWithAccountCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.PaymentVnmWithAccountCompleted(this, new PaymentVnmWithAccountCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    public delegate void PaymentVnmCompletedEventHandler(object sender, PaymentVnmCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class PaymentVnmCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal PaymentVnmCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    public delegate void PaymentVnmWithAccountCompletedEventHandler(object sender, PaymentVnmWithAccountCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class PaymentVnmWithAccountCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal PaymentVnmWithAccountCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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