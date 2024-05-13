using Newtonsoft.Json;
using System.Collections.Generic;

public class SQSEvent
{
    [JsonProperty("Records")]
    public List<SQSRecord> Records { get; set; }
}

public class SQSRecord
{
    [JsonProperty("messageId")]
    public string MessageId { get; set; }

    [JsonProperty("receiptHandle")]
    public string ReceiptHandle { get; set; }

    [JsonProperty("body")]
    public string Body { get; set; } // You can parse this later or create another DTO for it

    [JsonProperty("attributes")]
    public Dictionary<string, string> Attributes { get; set; }

    [JsonProperty("messageAttributes")]
    public Dictionary<string, string> MessageAttributes { get; set; } // Assuming they are all string pairs, adjust if not

    [JsonProperty("md5OfBody")]
    public string MD5OfBody { get; set; }

    [JsonProperty("eventSource")]
    public string EventSource { get; set; }

    [JsonProperty("eventSourceARN")]
    public string EventSourceARN { get; set; }

    [JsonProperty("awsRegion")]
    public string AwsRegion { get; set; }
}

public class SQSMessageBody
{
    [JsonProperty("batchNumber")]
    public int BatchNumber { get; set; }

    [JsonProperty("offset")]
    public int Offset { get; set; }

    [JsonProperty("limit")]
    public int Limit { get; set; }
}