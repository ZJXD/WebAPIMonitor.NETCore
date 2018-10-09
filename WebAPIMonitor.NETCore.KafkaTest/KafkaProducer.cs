using Confluent.Kafka;
using Confluent.Kafka.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPIMonitor.NETCore.KafkaTest
{
    public sealed class KafkaProducer
    {
        private readonly static Lazy<KafkaProducer> _instance = new Lazy<KafkaProducer>(
            () => new KafkaProducer());

        public static KafkaProducer Instance
        {
            get
            {
                return _instance.Value;
            }
        }

        private Producer<Null, string> producer;

        private string TopicName;

        /// <summary>
        /// 私有构造函数
        /// </summary>
        private KafkaProducer()
        {
            TopicName = ConfigHelper.GetSectionValue("topicName");
            string servers = ConfigHelper.GetSectionValue("servers");
            var config = new Dictionary<string, object>
            {
                { "bootstrap.servers",  servers}
                // 异步模式下，设置缓存消息的时间，并一次性发送
                //{ "queue.buffering.max.ms", ConfigurationManager.AppSettings["bufferMs"].ToString() },
                // 异步的模式下 最长等待的消息数
                //{ "queue.buffering.max.messages", ConfigurationManager.AppSettings["bufferMessages"].ToString() }
            };

            // .NET Core 下报错关于“GB2312”，添加 System.Text.Encoding.CodePages 的引用，并添加上这一句
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            producer = new Producer<Null, string>(config, null, new StringSerializer(Encoding.GetEncoding("gb2312")));
        }

        /// <summary>
        /// 发送数据
        /// </summary>
        /// <returns></returns>
        public void ProducerAsync(string message)
        {
            var result = producer.ProduceAsync(TopicName, null, message);

            result.ContinueWith(task =>
            {
                if (result.Result.Error.Code != ErrorCode.NoError)
                {
                    Console.WriteLine("接口请求日志生成消息出现错误：", new Exception(result.Result.Error.Reason));
                }
            });

            // 等待请求时间
            //producer.Flush(TimeSpan.FromSeconds(10));
        }
    }
}
