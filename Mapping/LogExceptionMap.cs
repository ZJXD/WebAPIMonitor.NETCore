
//------------------------------------------------------------------------------
// <auto-codeCreate>
//     此代码由工具生成。
//     对此文件的更改可能会导致不正确的行为，
//     如果重新生成代码，这些更改将会丢失。
// </auto-codeCreate>
//------------------------------------------------------------------------------

using DataBase.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modules;

namespace Mapping
{
    /// <summary>
    /// Copyright (c) 2017-2018 杭州深度信息科技有限公司
    /// 日 期：
    /// 描 述：应用未处理的异常记录表 实体映射
    /// </summary>
    public class LogExceptionMap : EntityMappingConfiguration<LogExceptionEntity>
    {
        public override void Map(EntityTypeBuilder<LogExceptionEntity> b)
        {
            b.ToTable("log_exception")
                .HasKey(p => p.Id);
        }
    }
}
