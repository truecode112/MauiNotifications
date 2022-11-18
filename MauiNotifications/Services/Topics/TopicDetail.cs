using System.Collections.Generic;

namespace MauiNotifications.Services.Topics
{
    public sealed class TopicDetail
    {
        public string Name { get; set; } = string.Empty;
        public string Region { get; set; } = string.Empty;
        public IReadOnlyDictionary<string, string> Attributes { get; set; } = new Dictionary<string, string>();
    }
}