﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AtlantisDeviceSimulator
{
    class MetricSender
    {
        private Metric metric;

        public MetricSender( Metric metric)
        {
            this.metric = metric;
        }

        public void Send()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(ConfigurationManager.AppSettings["BaseDeviceEndpoint"]);
            var data = JsonConvert.SerializeObject(metric);
            var result = client.PostAsync("/device/"+metric.Id+"/telemetry/", new StringContent(data, Encoding.UTF8, "application/json")).Result;
        }

        
    }
}
