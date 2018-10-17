
//------------------------------------------------------------------------------
// <auto-codeCreate>
//     此代码由工具生成。
//     对此文件的更改可能会导致不正确的行为，
//     如果重新生成代码，这些更改将会丢失。
// </auto-codeCreate>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modules
{
    /// <summary>
    /// Copyright (c) 2017-2018 杭州深度信息科技有限公司
    /// 日 期：
    /// 描 述：接口请求日志表
    /// </summary>
    public partial class LogEntity
    {
        /// <summary>
        /// 主键标识
        /// </summary>
        [Column("id")]
        public int Id { get; set; }

        /// <summary>
        /// 应用标识
        /// </summary>
        [Column("application_id")]
        public int? ApplicationId { get; set; }

        /// <summary>
        /// 应用名称
        /// </summary>
        [Column("application_name")]
        public string ApplicationName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("http_method")]
        public string HttpMethod { get; set; }

        /// <summary>
        /// 请求 url
        /// </summary>
        [Column("url")]
        public string Url { get; set; }

        /// <summary>
        /// 接收到请求的时间
        /// </summary>
        [Column("request_time")]
        public DateTime? RequestTime { get; set; }

        /// <summary>
        /// 发起响应的时间
        /// </summary>
        [Column("response_time")]
        public DateTime? ResponseTime { get; set; }

        /// <summary>
        /// 执行时间（单位为ms）
        /// </summary>
        [Column("execute_milliseconds")]
        public double? ExecuteMilliseconds { get; set; }

        /// <summary>
        /// 访客 ip 地址
        /// </summary>
        [Column("ip")]
        public string Ip { get; set; }

        /// <summary>
        /// 主机
        /// </summary>
        [Column("host")]
        public string Host { get; set; }

        /// <summary>
        /// 浏览器
        /// </summary>
        [Column("browser")]
        public string Browser { get; set; }

        /// <summary>
        /// 是否出现未处理的异常
        /// </summary>
        [Column("is_untreated_exception")]
        public bool IsUntreatedException { get; set; }

        /// <summary>
        /// 记录创建时间
        /// </summary>
        [Column("gmt_create")]
        public DateTime? GmtCreate { get; set; }

    }
}
