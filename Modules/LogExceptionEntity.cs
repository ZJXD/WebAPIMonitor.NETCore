
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
    /// 描 述：应用未处理的异常记录表
    /// </summary>
    public partial class LogExceptionEntity
    {
        /// <summary>
        /// 主键标识
        /// </summary>
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        /// <summary>
        /// 异常详细信息
        /// </summary>
        [Column("exception_message")]
        public string ExceptionMessage { get; set; }

    }
}
