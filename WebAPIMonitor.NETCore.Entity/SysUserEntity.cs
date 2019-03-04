using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPIMonitor.NETCore.Entity
{
    [SugarTable("sys_user")]
    public class SysUserEntity
    {
        /// <summary>
        /// 主键标识
        /// </summary>
        [SugarColumn(ColumnName = "id", IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }

        /// <summary>
        /// 登录账户
        /// </summary>
        [SugarColumn(ColumnName = "account")]
        public string Account { get; set; }

        /// <summary>
        /// 登录密码
        /// </summary>
        [SugarColumn(ColumnName = "password")]
        public string Password { get; set; }

        /// <summary>
        /// 真实姓名
        /// </summary>
        [SugarColumn(ColumnName = "real_name")]
        public string RealName { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        [SugarColumn(ColumnName = "nick_name")]
        public string NickName { get; set; }

        /// <summary>
        /// 所属部门主键
        /// </summary>
        [SugarColumn(ColumnName = "unit_id")]
        public int? UnitId { get; set; }

        /// <summary>
        /// 所属部门名称
        /// </summary>
        [SugarColumn(ColumnName = "unit_name")]
        public string UnitName { get; set; }

        /// <summary>
        /// 头像
        /// </summary>
        [SugarColumn(ColumnName = "head_icon")]
        public string HeadIcon { get; set; }

        /// <summary>
        /// 手机
        /// </summary>
        [SugarColumn(ColumnName = "mobile")]
        public string Mobile { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        [SugarColumn(ColumnName = "telephone")]
        public string Telephone { get; set; }

        /// <summary>
        /// email
        /// </summary>
        [SugarColumn(ColumnName = "email")]
        public string Email { get; set; }

        /// <summary>
        /// 生日
        /// </summary>
        [SugarColumn(ColumnName = "birthday")]
        public DateTime? Birthday { get; set; }

        /// <summary>
        /// 性别（1：男，2：女）
        /// </summary>
        [SugarColumn(ColumnName = "sex")]
        public byte? Sex { get; set; }

        /// <summary>
        /// 住址
        /// </summary>
        [SugarColumn(ColumnName = "address")]
        public string Address { get; set; }

        /// <summary>
        /// 工作职务
        /// </summary>
        [SugarColumn(ColumnName = "job_post")]
        public string JobPost { get; set; }

        /// <summary>
        /// 排序号
        /// </summary>
        [SugarColumn(ColumnName = "sort_num")]
        public int? SortNum { get; set; }

        /// <summary>
        /// 是否已删除( 1 表示是，0 表示否)
        /// </summary>
        [SugarColumn(ColumnName = "is_deleted")]
        public bool IsDeleted { get; set; }

        /// <summary>
        /// 是否启用(1表示启用，0表示禁用)
        /// </summary>
        [SugarColumn(ColumnName = "is_enable")]
        public bool? IsEnable { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [SugarColumn(ColumnName = "gmt_create")]
        public DateTime? GmtCreate { get; set; }

        /// <summary>
        /// 最新修改时间
        /// </summary>
        [SugarColumn(ColumnName = "gmt_modified")]
        public DateTime? GmtModified { get; set; }
    }
}
