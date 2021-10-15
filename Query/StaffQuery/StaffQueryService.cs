﻿using Dapper;
using NetCoreReactJS.Common;
using NetCoreReactJS.DTO;
using NetCoreReactJS.Services;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace NetCoreReactJS.Query.StaffQuery
{
    public class StaffQueryService : IStaffQueryService
    {
        private readonly IConnectionService _connection;
        public StaffQueryService(IConnectionService connection)
        {
            _connection = connection;
        }


        public List<StaffDTO> GetList(string Name)
        {
            try
            {
                using (IDbConnection conn = _connection.GetConnection())
                {
                    string SqlQuery = @"
                        select s.*, s1.StfName as ManName, d.DeptName, p.PosName
                        from 
	                        staff s left join staff s1 on s.ManId = s1.Id
	                        left join Dept d on s.DeptId = d.id
	                        left join Pos p on s.PosId = p.id
                        where s.IsDel <> 1
                    ";// 
                    var param = new DynamicParameters();
                    if (Name != null)
                    {
                        SqlQuery += @" and s.StfName like CONCAT('%', @Name, '%')";
                        param.Add("@Name", Name, DbType.String);
                    }
                    List<StaffDTO> kq = conn.Query<StaffDTO>(SqlQuery, param, commandType: CommandType.Text).ToList();
                    return kq;
                }
            }
            finally
            {
                _connection.CloseConnection();
            }
        }

        public List<StaffDTO> GetListMan(int Id)
        {
            try
            {
                using (IDbConnection conn = _connection.GetConnection())
                {
                    string SqlQuery = @"
                        select s.*, s1.StfName as ManName, d.DeptName, p.PosName
                        from 
	                        staff s left join staff s1 on s.ManId = s.Id
	                        left join Dept d on s.DeptId = d.id
	                        left join Pos p on s.PosId = p.id
                        where 
                           s.IsDel <> 1 and
	                       s.StfId <> @Id
                    ";// 
                    var param = new DynamicParameters();
                    param.Add("@Id", Id, DbType.Int32);
                    List<StaffDTO> kq = conn.Query<StaffDTO>(SqlQuery, param, commandType: CommandType.Text).ToList();
                    return kq;
                }
            }
            finally
            {
                _connection.CloseConnection();
            }
        }

        public StaffDTO GetOneById(int Id)
        {
            try
            {
                using (IDbConnection conn = _connection.GetConnection())
                {
                    string SqlQuery = @"
                        select s.*, s1.StfName as ManName, d.DeptName, p.PosName
                        from 
	                        staff s left join staff s1 on s.ManId = s.Id
	                        left join Dept d on s.DeptId = d.id
	                        left join Pos p on s.PosId = p.id
                        where 
	                       s.Id = @Id
                    ";
                    var param = new DynamicParameters();
                    param.Add("@Id", Id, DbType.Int32);
                    StaffDTO kq = conn.Query<StaffDTO>(SqlQuery, param, commandType: CommandType.Text).FirstOrDefault();
                    return kq;
                }
            }
            finally
            {
                _connection.CloseConnection();
            }
        }

        
    }
}
