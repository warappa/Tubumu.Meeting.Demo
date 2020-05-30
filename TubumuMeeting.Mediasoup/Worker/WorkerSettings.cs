﻿using System.Collections.Generic;

namespace TubumuMeeting.Mediasoup
{
    public class WorkerSettings
    {
        /// <summary>
        ///  Logging level for logs generated by the media worker subprocesses (check
        ///  the Debugging documentation). Valid values are 'debug', 'warn', 'error' and
        ///  'none'. Default 'error'.
        /// </summary>
        public WorkerLogLevel? LogLevel { get; set; } = WorkerLogLevel.Error;

        /// <summary>
        ///  Log tags for debugging. Check the meaning of each available tag in the
        ///  Debugging documentation.
        /// </summary>
        public WorkerLogTag[]? LogTags { get; set; }

        /// <summary>
        ///  Minimun RTC port for ICE, DTLS, RTP, etc. Default 10000.
        /// </summary>
        public int? RtcMinPort { get; set; } = 10000;

        /// <summary>
        ///  Maximum RTC port for ICE, DTLS, RTP, etc. Default 59999.
        /// </summary>
        public int? RtcMaxPort { get; set; } = 59999;

        /// <summary>
        ///  Path to the DTLS public certificate file in PEM format. If unset, a
        ///  certificate is dynamically created.
        /// </summary>
        public string? DtlsCertificateFile { get; set; }

        /// <summary>
        ///  Path to the DTLS certificate private key file in PEM format. If unset, a
        ///  certificate is dynamically created.
        /// </summary>
        public string? DtlsPrivateKeyFile { get; set; }

        /// <summary>
        ///  Custom application data.
        /// </summary>
        public Dictionary<string, object>? AppData { get; set; }
    }
}
