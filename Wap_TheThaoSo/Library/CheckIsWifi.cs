using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wap_TheThaoSo.Library;
namespace Wap_TheThaoSo.Library
{
    class CheckIsWifi
    {
        public static bool CheckWifi(string clientIp)
        {
            log4net.ILog _log = log4net.LogManager.GetLogger("File");

            _log.Debug("-------ClientIP-------------");
            _log.Debug(clientIp);

            IPList iplist = new IPList();
            //viettel
            iplist.Add("27.64.0.0", 16);
            iplist.Add("27.64.0.0", 11);
            iplist.Add("27.65.0.0", 16);
            iplist.Add("27.66.0.0", 16);
            iplist.Add("27.67.0.0", 16);
            iplist.Add("27.76.0.0", 16);
            iplist.Add("27.77.0.0", 16);
            iplist.Add("171.224.0.0", 16);
            iplist.Add("171.225.0.0", 16);
            iplist.Add("171.228.0.0", 16);
            iplist.Add("171.230.0.0", 16);
            iplist.Add("171.231.0.0", 16);
            iplist.Add("171.232.0.0", 16);
            iplist.Add("171.233.0.0", 16);
            iplist.Add("171.234.0.0", 16);
            iplist.Add("171.236.0.0", 16);
            iplist.Add("171.238.0.0", 16);
            iplist.Add("171.240.0.0", 16);
            iplist.Add("171.241.0.0", 16);
            iplist.Add("171.241.128.0", 17);
            iplist.Add("171.243.0.0", 16);
            iplist.Add("171.244.0.0", 16);
            iplist.Add("171.247.0.0", 16);
            iplist.Add("171.248.0.0", 16);
            iplist.Add("171.249.0.0", 16);
            iplist.Add("171.250.0.0", 16);
            iplist.Add("171.251.64.0", 18);
            iplist.Add("171.251.128.0", 17);
            iplist.Add("171.255.0.0", 16);

            //mobilefone
            iplist.Add("113.187.0.0", 24);
            iplist.Add("113.187.1.0", 24);
            iplist.Add("113.187.2.0", 24);
            iplist.Add("113.187.3.0", 24);
            iplist.Add("113.187.4.0", 24);
            iplist.Add("113.187.5.0", 24);
            iplist.Add("113.187.6.0", 24);
            iplist.Add("113.187.7.0", 24);
            iplist.Add("113.187.8.0", 24);
            iplist.Add("113.187.9.0", 24);
            iplist.Add("113.187.10.0", 24);
            iplist.Add("113.187.11.0", 24);
            iplist.Add("113.187.12.0", 24);
            iplist.Add("113.187.13.0", 24);
            iplist.Add("113.187.14.0", 24);
            iplist.Add("113.187.15.0", 24);
            iplist.Add("113.187.16.0", 24);
            iplist.Add("113.187.18.0", 24);
            iplist.Add("113.187.19.0", 24);
            iplist.Add("113.187.20.0", 24);
            iplist.Add("113.187.21.0", 24);
            iplist.Add("113.187.22.0", 24);
            iplist.Add("113.187.23.0", 24);
            iplist.Add("113.187.24.0", 24);
            iplist.Add("113.187.25.0", 24);
            iplist.Add("113.187.26.0", 24);
            iplist.Add("113.187.27.0", 24);
            iplist.Add("113.187.28.0", 24);
            iplist.Add("113.187.29.0", 24);
            iplist.Add("113.187.30.0", 24);
            iplist.Add("113.187.31.0", 24);

            //vinaphone
            iplist.Add("113.185.1.0", 24);
            iplist.Add("113.185.2.0", 24);
            iplist.Add("113.185.3.0", 24);
            iplist.Add("113.185.4.0", 24);
            iplist.Add("113.185.5.0", 24);
            iplist.Add("113.185.6.0", 24);
            iplist.Add("113.185.7.0", 24);
            iplist.Add("113.185.8.0", 24);
            iplist.Add("113.185.9.0", 24);
            iplist.Add("113.185.10.0", 24);
            iplist.Add("113.185.11.0", 24);
            iplist.Add("113.185.12.0", 24);
            iplist.Add("113.185.13.0", 24);
            iplist.Add("113.185.14.0", 24);
            iplist.Add("113.185.15.0", 24);
            iplist.Add("113.185.16.0", 24);
            iplist.Add("113.185.18.0", 24);
            iplist.Add("113.185.19.0", 24);
            iplist.Add("113.185.20.0", 24);
            iplist.Add("113.185.21.0", 24);
            iplist.Add("113.185.22.0", 24);
            iplist.Add("113.185.23.0", 24);
            iplist.Add("113.185.24.0", 24);
            iplist.Add("113.185.25.0", 24);
            iplist.Add("113.185.26.0", 24);
            iplist.Add("113.185.27.0", 24);
            iplist.Add("113.185.28.0", 24);
            iplist.Add("113.185.29.0", 24);
            iplist.Add("113.185.30.0", 24);
            iplist.Add("113.185.31.0", 24);
            iplist.Add("172.16.30.11");
            iplist.Add("172.16.30.12");
            iplist.Add("113.185.0.16");


            //vnm
            iplist.Add("202.172.4.192", 26);
            iplist.Add("203.170.26.0", 24);
            iplist.Add("203.170.27.0", 24);
            iplist.Add("203.128.247.24", 30);
            iplist.Add("203.162.40.20", 30);

            if (iplist.CheckNumber(clientIp) || clientIp.Substring(0, 3) == "10." || clientIp.Substring(0, 6) == "103.7." || clientIp.StartsWith("113.187") || clientIp.StartsWith("171.") || clientIp.StartsWith("27."))
            {
                return false;
            }

            return true;
        }

        public static bool IsVinaphone(string clientIp)
        {
            log4net.ILog _log = log4net.LogManager.GetLogger("File");

            _log.Debug("--------- ClientIP VINAPHONE -------------");
            _log.Debug(clientIp);

            IPList iplist = new IPList();

            iplist.Add("113.185.0.0", 19);
            //vinaphone F5
            iplist.Add("113.185.1.0", 24);
            iplist.Add("113.185.2.0", 24);
            iplist.Add("113.185.3.0", 24);
            iplist.Add("113.185.4.0", 24);
            iplist.Add("113.185.5.0", 24);
            iplist.Add("113.185.6.0", 24);
            iplist.Add("113.185.7.0", 24);
            iplist.Add("113.185.8.0", 24);
            iplist.Add("113.185.9.0", 24);
            iplist.Add("113.185.10.0", 24);
            iplist.Add("113.185.11.0", 24);
            iplist.Add("113.185.12.0", 24);
            iplist.Add("113.185.13.0", 24);
            iplist.Add("113.185.14.0", 24);
            iplist.Add("113.185.15.0", 24);
            iplist.Add("113.185.16.0", 24);
            iplist.Add("113.185.18.0", 24);
            iplist.Add("113.185.19.0", 24);
            iplist.Add("113.185.20.0", 24);
            iplist.Add("113.185.21.0", 24);
            iplist.Add("113.185.22.0", 24);
            iplist.Add("113.185.23.0", 24);
            iplist.Add("113.185.24.0", 24);
            iplist.Add("113.185.25.0", 24);
            iplist.Add("113.185.26.0", 24);
            iplist.Add("113.185.27.0", 24);
            iplist.Add("113.185.28.0", 24);
            iplist.Add("113.185.29.0", 24);
            iplist.Add("113.185.30.0", 24);
            iplist.Add("113.185.31.0", 24);
            //Operamini

            iplist.Add("37.228.104.0", 21);
            iplist.Add("58.67.157.0", 24);
            iplist.Add("59.151.95.128", 25);
            iplist.Add("59.151.98.128", 27);
            iplist.Add("59.151.106.224", 27);
            iplist.Add("59.151.120.32", 27);
            iplist.Add("80.84.1.0", 24);
            iplist.Add("80.239.242.0", 23);
            iplist.Add("82.145.208.0", 20);

            iplist.Add("91.203.96.0", 22);
            iplist.Add("116.58.209.36", 27);
            iplist.Add("116.58.209.128", 27);

            iplist.Add("116.58.209.128", 27);

            iplist.Add("141.0.8.0", 21);

            iplist.Add("195.189.142.0", 23);
            iplist.Add("203.81.19.0", 24);
            iplist.Add("209.170.68.0", 24);
            iplist.Add("217.212.230.0", 23);

            iplist.Add("217.212.226.0", 24);
            iplist.Add("185.26.180.0", 22);

            //Wap GW
            iplist.Add("172.16.30.11", 24);
            iplist.Add("172.16.30.12", 24);
            iplist.Add("113.185.0.16", 24);

            if (iplist.CheckNumber(clientIp))
            {
                return true;
            }

            return false;

        }

        public static bool IsViettel(string clientIp)
        {
            log4net.ILog _log = log4net.LogManager.GetLogger("File");

            _log.Debug("--------- ClientIP VIETTEL -------------");
            _log.Debug(clientIp);

            IPList iplist = new IPList();

            //viettel
            iplist.Add("27.64.0.0", 16);
            iplist.Add("27.64.0.0", 16);
            iplist.Add("27.64.128.0", 17);

            iplist.Add("27.65.0.0", 16);
            iplist.Add("27.66.0.0", 16);

            iplist.Add("27.66.0.0", 16);
            iplist.Add("27.66.0.0", 17);
            iplist.Add("27.66.128.0", 17);


            iplist.Add("27.67.0.0", 16);
            iplist.Add("27.68.0.0", 16);
            iplist.Add("27.68.0.0", 17);
            iplist.Add("27.68.128.0", 17);
            iplist.Add("27.69.0.0", 16);
            iplist.Add("27.70.0.0", 16);
            iplist.Add("27.71.0.0", 16);

            iplist.Add("27.71.0.0", 20);
            iplist.Add("27.71.16.0", 20);
            iplist.Add("27.71.32.0", 20);
            iplist.Add("27.71.48.0", 20);
            iplist.Add("27.71.64.0", 20);
            iplist.Add("27.71.80.0", 20);
            iplist.Add("27.71.96.0", 20);
            iplist.Add("27.71.112.0", 20);
            iplist.Add("27.71.128.0", 17);

            iplist.Add("27.72.0.0", 16);
            iplist.Add("27.73.0.0", 16);
            iplist.Add("27.74.0.0", 16);
            iplist.Add("27.75.0.0", 16);
            iplist.Add("27.76.0.0", 16);
            iplist.Add("27.77.0.0", 16);
            iplist.Add("27.78.0.0", 16);
            iplist.Add("27.79.0.0", 16);

            iplist.Add("171.224.0.0", 16);
            iplist.Add("171.225.0.0", 16);
            iplist.Add("171.226.0.0", 16);
            iplist.Add("171.227.0.0", 16);
            iplist.Add("171.227.0.0", 17);
            iplist.Add("171.227.128.0", 18);
            iplist.Add("171.227.192.0", 19);
            iplist.Add("171.227.224.0", 19);
            iplist.Add("171.228.0.0", 16);
            iplist.Add("171.229.0.0", 16);
            iplist.Add("171.230.0.0", 16);
            iplist.Add("171.231.0.0", 16);
            iplist.Add("171.232.0.0", 16);
            iplist.Add("171.233.0.0", 16);
            iplist.Add("171.234.0.0", 16);
            iplist.Add("171.235.0.0", 16);
            iplist.Add("171.235.0.0", 18);
            iplist.Add("171.235.64.0", 19);
            iplist.Add("171.235.96.0", 19);
            iplist.Add("171.235.128.0", 17);
            iplist.Add("171.236.0.0", 16);
            iplist.Add("171.237.0.0", 16);
            iplist.Add("171.237.0.0", 17);
            iplist.Add("171.237.128.0", 17);
            iplist.Add("171.238.0.0", 16);
            iplist.Add("171.239.0.0", 16);
            iplist.Add("171.239.0.0", 17);
            iplist.Add("171.239.128.0", 17);
            iplist.Add("171.240.0.0", 16);
            iplist.Add("171.241.0.0", 16);
            iplist.Add("171.241.0.0", 17);
            iplist.Add("171.241.128.0", 17);
            iplist.Add("171.242.0.0", 16);
            iplist.Add("171.243.0.0", 16);
            iplist.Add("171.243.0.0", 18);
            iplist.Add("171.243.64.0", 19);
            iplist.Add("171.243.96.0", 20);
            iplist.Add("171.243.112.0", 20);
            iplist.Add("171.243.128.0", 17);

            iplist.Add("171.244.0.0", 16);
            iplist.Add("171.245.0.0", 16);

            iplist.Add("171.245.0.0", 17);
            iplist.Add("171.245.128.0", 19);
            iplist.Add("171.245.160.0", 20);
            iplist.Add("171.245.176.0", 20);
            iplist.Add("171.245.192.0", 18);

            iplist.Add("171.246.0.0", 16);
            iplist.Add("171.246.0.0", 17);
            iplist.Add("171.246.128.0", 17);

            iplist.Add("171.247.0.0", 16);
            iplist.Add("171.248.0.0", 16);
            iplist.Add("171.249.0.0", 16);
            iplist.Add("171.250.0.0", 16);
            iplist.Add("171.251.0.0", 16);

            iplist.Add("171.251.0.0", 18);
            iplist.Add("171.251.64.0", 18);
            iplist.Add("171.251.128.0", 18);
            iplist.Add("171.251.192.0", 18);

            iplist.Add("171.252.0.0", 16);
            iplist.Add("171.253.0.0", 16);
            iplist.Add("171.254.0.0", 16);

            iplist.Add("171.254.0.0", 17);
            iplist.Add("171.254.128.0", 17);

            iplist.Add("171.255.0.0", 16);

            iplist.Add("171.255.0.0", 20);
            iplist.Add("171.255.16.0", 20);
            iplist.Add("171.255.32.0", 20);
            iplist.Add("171.255.48.0", 20);
            iplist.Add("171.255.64.0", 18);
            iplist.Add("171.255.128.0", 17);

            iplist.Add("125.235.49.0", 22);
            iplist.Add("125.235.49.0", 23);
            iplist.Add("125.235.50.0", 24);
            iplist.Add("125.235.51.0", 24);

            iplist.Add("125.235.153.0", 22);

            iplist.Add("125.235.153.0", 23);
            iplist.Add("125.235.154.0", 24);
            iplist.Add("125.235.155.0", 24);

            iplist.Add("125.234.49.0", 22);
            iplist.Add("125.234.49.0", 23);
            iplist.Add("125.234.50.0", 24);
            iplist.Add("125.234.51.0", 24);

            iplist.Add("125.235.64.0", 20);

            if (iplist.CheckNumber(clientIp))
            {
                _log.Info("is viettel");
                return true;
            }

            return false;

        }

        public static bool IsVnm(string clientIp)
        {
            log4net.ILog log = log4net.LogManager.GetLogger("File");

            log.Debug("--------- ClientIP VNM -------------");
            log.Debug(clientIp);

            IPList iplist = new IPList();

            //vnm
            //iplist.Add("202.172.4.192", 26);
            //iplist.Add("203.170.26.0", 24);
            //iplist.Add("203.170.27.0", 24);
            //iplist.Add("203.170.26.20",24);
            //iplist.Add("203.128.247.24", 30);
            //iplist.Add("203.162.40.20", 30);

            //if (iplist.CheckNumber(clientIp))
            //{
            //    return true;
            //}

            if (clientIp.StartsWith("203.") || clientIp.StartsWith("10.200") || clientIp.StartsWith("10.208"))
            {
                log.Info("is vnm");
                return true;
            }

            return false;
        }

        public static bool IsMobi(string clientIp)
        {
            var iplist = new IPList();

            //Ip public 3g

            iplist.Add("113.187.0.0", 24);
            iplist.Add("113.191.8.0", 24);
            iplist.Add("113.187.4.0", 24);
            iplist.Add("222.255.208.0", 24);
            iplist.Add("222.255.209.0", 24);
            iplist.Add("103.234.88.0", 24);
            iplist.Add("103.234.89.0", 24);
            iplist.Add("111.91.234.0", 24);
            iplist.Add("113.187.22.0", 24);
            iplist.Add("113.187.23.0", 24);
            iplist.Add("113.187.24.0", 24);
            iplist.Add("113.187.25.0", 24);
            iplist.Add("113.191.8.128", 25);
            iplist.Add("103.237.66.0", 24);
            iplist.Add("103.237.66.0", 25);

            //extend
            iplist.Add("183.91.6.0", 24);
            iplist.Add("203.162.240.0", 24);
            iplist.Add("123.30.87.0", 28);
            iplist.Add("123.30.83.16", 29);
            iplist.Add("222.255.208.0", 24);
            iplist.Add("222.255.209.0", 24);
            iplist.Add("123.30.165.0", 25);
            iplist.Add("113.187.16.0", 23);
            iplist.Add("101.99.46.240", 29);
            iplist.Add("101.99.46.248", 29);
            iplist.Add("206.53.147.241", 24);
            iplist.Add("206.53.148.241", 24);
            iplist.Add("206.53.149.241", 24);
            iplist.Add("103.234.88.0", 24);
            iplist.Add("91.203.96.103");
            iplist.Add("217.212.226.170");
            iplist.Add("82.145.210.210");
            iplist.Add("58.67.157.0", 24);
            iplist.Add("116.58.209.128", 27);
            iplist.Add("59.151.95.128", 25);
            iplist.Add("141.0.8.0", 21);
            iplist.Add("59.151.98.128", 27);
            iplist.Add("59.151.95.128", 25);
            iplist.Add("141.0.8.0", 21);
            iplist.Add("195.189.142.0", 23);
            iplist.Add("59.151.106.224", 27);
            iplist.Add("203.81.19.0", 24);
            iplist.Add("59.151.120.32", 27);
            iplist.Add("209.170.68.0", 24);
            iplist.Add("80.84.1.0", 24);
            iplist.Add("217.212.230.0", 23);
            iplist.Add("80.239.242.0", 23);
            iplist.Add("217.212.226.0", 24);
            iplist.Add("82.145.208.0", 20);
            iplist.Add("185.26.180.0", 22);
            iplist.Add("91.203.96.0", 22);
            iplist.Add("113.191.8.0", 24);
            iplist.Add("111.91.234.128", 25);
            iplist.Add("113.191.8.128", 25);
            iplist.Add("37.228.104.0", 21);
            iplist.Add("116.58.209.36", 27);

            if (iplist.CheckNumber(clientIp))
            {
                return true;
            }

            return false;
        }
    }
}
