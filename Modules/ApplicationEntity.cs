
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
    /// 描 述：接入系统表
    /// </summary>
    public partial class ApplicationEntity
    {
        /// <summary>
        /// 主键标识
        /// </summary>
        [Column("id")]
        public int Id { get; set; }

        /// <summary>
        /// 系统名称
        /// </summary>
        [Column("name")]
        public string Name { get; set; }

        /// <summary>
        /// 系统 token
        /// </summary>
        [Column("token")]
        public string Token { get; set; }

        /// <summary>
        /// 是否已删除
        /// </summary>
        [Column("is_delete")]
        public bool IsDelete { get; set; }
    }
}
