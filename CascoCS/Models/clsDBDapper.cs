using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

/// <summary>
/// 需安裝套件:Dapper,若不想安裝可用 clsDB
/// </summary>
public class clsDBDapper : IDisposable
{

    private SqlConnection objConn;
    public enum ConnStrNameEnum { DBConnection, DBConnTest }

    public clsDBDapper()
    {
        objConn = new SqlConnection(ConfigurationManager.ConnectionStrings[ConnStrNameEnum.DBConnection.ToString()].ToString());

    }


    public clsDBDapper(ConnStrNameEnum ConnStrName)
    {
        objConn = new SqlConnection(ConfigurationManager.ConnectionStrings[ConnStrName.ToString()].ToString());
    }


    public void Dispose()
    {
        this.ToConnClose();
    }

    /// <summary>
    /// 開啟連線
    /// </summary>
    public bool ToConnOpen()
    {
        bool result = true;

        try
        {
            if (objConn.State != ConnectionState.Open)
            {
                objConn.Open();
            }
        }
        catch
        {
            result = false;
        }

        return result;
    }

    /// <summary>
    /// 關閉連線
    /// </summary>
    public bool ToConnClose()
    {
        bool result = true;

        try
        {
            if (objConn.State != ConnectionState.Closed)
            {
                objConn.Close();
            }
        }
        catch
        {
            result = false;
        }

        return result;
    }


    //-------------------------------------
    /// <summary>
    /// 回傳指定類別 -- 需傳入SQL參數
    /// </summary>
    public IList<T> ToClass<T>(string sql, DynamicParameters Params) where T : new()
    {
        if (string.IsNullOrEmpty(sql) == true)
        {
            return null;
        }
        if (Params != null)
        {
            var _result = this.objConn.Query<T>(sql, Params).ToList();
            return _result;
        }
        else
        {
            var _result = this.objConn.Query<T>(sql).ToList();
            return _result;
        }

    }

    public IList<T> ToClassByObj<T>(string sql, object Params) where T : new()
    {
        if (string.IsNullOrEmpty(sql) == true)
        {
            return null;
        }
        if (Params != null)
        {
            var _result = this.objConn.Query<T>(sql, Params).ToList();
            return _result;
        }
        else
        {
            var _result = this.objConn.Query<T>(sql).ToList();
            return _result;
        }

    }

    /// <summary>
    /// 回傳指定類別
    /// </summary>
    public IList<T> ToClass<T>(string sql) where T : new()
    {
        return this.ToClass<T>(sql, null);
    }

    /// <summary>
    /// 執行指定的SQL語法
    /// </summary>
    /// <param name="sql"></param>
    /// <param name="Params"></param>
    /// <returns></returns>
    public bool ToExecute(string sql, DynamicParameters Params)
    {
        bool _flag = false;
        int _result = 0;
        if (string.IsNullOrEmpty(sql) == true)
        {

        }
        if (Params != null)
        {
            _result = this.objConn.Execute(sql, Params);
        }
        else
        {
            _result = this.objConn.Execute(sql, Params);
        }
        _flag = (_result == 0) ? false : true;
        return _flag;
    }

    public bool ToExecute(string sql, object Params)
    {
        bool _flag = false;
        int _result = 0;
        if (string.IsNullOrEmpty(sql) == true)
        {

        }
        if (Params != null)
        {
            _result = this.objConn.Execute(sql, Params);
        }
        else
        {
            _result = this.objConn.Execute(sql, Params);
        }
        _flag = (_result == 0) ? false : true;
        return _flag;
    }


    public dynamic ToObj(string sql, DynamicParameters Params)
    {
        var _result = this.objConn.Query(sql, Params);
        return _result;
    }
}

