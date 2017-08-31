using Microsoft.AspNetCore.Html;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocFXRazor.Models
{
    public class ConceptualTopic
    {
        [JsonProperty("uid")]
        public string UID { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("rawTitle")]
        public string TitleContent { get; set; }

        public HtmlString TitleHtml => new HtmlString(TitleContent);

        [JsonProperty("conceptual")]
        public string Content { get; set; }

        public HtmlString ContentHtml => new HtmlString(Content);

        [JsonProperty("_toc", ObjectCreationHandling = ObjectCreationHandling.Reuse)]
        public TableOfContents TableOfContents { get; } = new TableOfContents();

        [JsonExtensionData(ReadData = true, WriteData = true)]
        public Dictionary<string, JToken> AdditionalProperties { get; set; } = new Dictionary<string, JToken>();
    }

    public class TableOfContents
    {
        [JsonProperty("items", ObjectCreationHandling = ObjectCreationHandling.Reuse)]
        public List<TableOfContentsItem> Items { get; }
    }

    public class TableOfContentsItem
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("href")]
        public string HRef { get; set; }

        [JsonProperty("topicHref")]
        public string TopicHRef { get; set; }

        [JsonProperty("topicUid")]
        public string TopicUID { get; set; }

        [JsonProperty("active")]
        public bool IsActive { get; set; }

        [JsonProperty("leaf")]
        public bool IsLeaf { get; set; }

        [JsonProperty("level")]
        public int Level { get; set; }

        [JsonProperty("items", ObjectCreationHandling = ObjectCreationHandling.Reuse)]
        public List<TableOfContentsItem> ChildItems { get; }
    }
}
