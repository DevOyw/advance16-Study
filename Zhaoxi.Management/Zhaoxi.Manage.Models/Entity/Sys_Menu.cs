﻿using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zhaoxi.Manage.Models.Entity
{
    /// <summary>
    /// 和数据库对应实体---在数据库中保存功能菜单和按钮
    /// </summary>
    [SugarTable("Sys_Menu")]
    public class Sys_Menu
    {
        [SugarColumn(IsPrimaryKey = true)]
        public Guid Id { get; set; }
        [SugarColumn(ColumnName = "ParentId")]
        public Guid ParentId { get; set; }
        /// <summary>
        /// 菜单名称
        /// </summary>
        public string? MenuText { get; set; }
        /// <summary>
        /// 全名称--多级菜单-- 一级==二级菜单==三级菜单
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public string? FullName { get; set; }
        /// <summary>
        /// 控制器名称
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public string? ControllerName { get; set; }
        /// <summary>
        /// 方法名称
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public string? ActionName { get; set; }
        /// <summary>
        /// 菜单类型
        /// 0：菜单功能
        /// 1：按钮功能
        /// </summary>
        public int MenuType { get; set; }
        /// <summary>
        /// 递归类型
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        public List<Sys_Menu>? MenuChildList { get; set; }
    }
}