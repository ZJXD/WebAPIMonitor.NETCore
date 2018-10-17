
//------------------------------------------------------------------------------
// <auto-codeCreate>
//     此代码由工具生成。
//     对此文件的更改可能会导致不正确的行为，
//     如果重新生成代码，这些更改将会丢失。
// </auto-codeCreate>
//------------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations.Schema;

namespace Modules
{
    /// <summary>
    /// Copyright (c) 2017-2018 杭州深度信息科技有限公司
    /// 日 期：
    /// 描 述：
    /// </summary>
    public partial class LogRequestEntity
    {
        /// <summary>
        /// 主键标识
        /// </summary>
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        /// <summary>
        /// 请求 head
        /// </summary>
        [Column("request_headers")]
        public string RequestHeaders { get; set; }

        /// <summary>
        /// 请求 body
        /// </summary>
        [Column("request_body")]
        public string RequestBody { get; set; }

    }
}
