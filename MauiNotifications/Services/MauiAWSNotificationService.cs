using Amazon;
using Amazon.SimpleNotificationService;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiNotifications.Services
{
    public class MauiAWSNotificationService
    {
        private IAmazonSimpleNotificationService _sns;

        public IAmazonSimpleNotificationService awsSNS
        {
            get { return _sns; }
            set
            {
                _sns = value;
            }
        }

        public MauiAWSNotificationService()
        {
            IConfiguration config = MauiProgram.Services.GetService<IConfiguration>();
            var settings = config.GetRequiredSection("Settings").Get<Settings.AWSSettings>();
            _sns = new AmazonSimpleNotificationServiceClient(settings.aws_access_key, settings.aws_secret_key, RegionEndpoint.USEast1);
        }
    }
}
