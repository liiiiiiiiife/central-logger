﻿using System;
using System.Collections.Concurrent;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace CentralLogProvider {

    public class CentralLogOptions {
        public string serviceUrl;
        public CentralLogOptions(string serviceUrl) {
            this.serviceUrl = serviceUrl;
        }
    }

    public class CentralLogProvider : ILoggerProvider {
        private readonly ConcurrentDictionary<string, CentralLogger> loggers = new ConcurrentDictionary<string, CentralLogger>();

        private readonly CentralLogOptions options;

        public CentralLogProvider(CentralLogOptions options) {
            this.options = options;
        }

        public ILogger CreateLogger(string categoryName) {
            return new CentralLogger(this, categoryName, options);
        }
        public void Dispose() {
            loggers.Clear();
        }
    }
}
