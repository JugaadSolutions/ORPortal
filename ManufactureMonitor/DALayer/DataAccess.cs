using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
namespace ManufactureMonitor.DALayer
{
    public class DataAccess
    {
        String connection = @"Data Source=.\SQLEXPRESS;Initial Catalog=IOR;Persist Security Info=True;User ID=sa;Password=sushma";


        public DataTable GetStopProblems(int MachineGroup_ID)
        {
            SqlConnection cn;
            SqlCommand cmd;

            cn = new SqlConnection(connection);

            String query = @" Select Code as No,[Description]
                            From SpecificProblems INNER JOIN Machines ON(Machines.ID=SpecificProblems.Machine_ID) 
                        AND (Machines.MachineGroupId={0})";
            query = String.Format(query, MachineGroup_ID);

            cn.Open();
            cmd = new SqlCommand(query, cn);
            
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dr.Close();

            cn.Close();

            return dt;
            
        }
        public DataTable GetParameters(int MachineGroup_ID)
        {
            SqlConnection cn;
            SqlCommand cmd;

            cn = new SqlConnection(connection);
            String query = @" Select Name as Machine, TOS as [time to stop(s)], (Pulses+':'+Pieces) as [Pulses:Pieces],Rmin as [OR red MIN(%)],Rmax as [OR red MAX(%)],Omin as [OR orange MIN(%)],Omax as [OR orange MAX(%)],Gmin as [OR green MIN(%)],Gmax as [OR green MAX(%)]
                            from Machines where (Machines.MachineGroupId={0})";
            query = String.Format(query, MachineGroup_ID);

            cn.Open();
            cmd = new SqlCommand(query, cn);

            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dr.Close();
            cn.Close();
            return dt;

        }
        public DataTable GetMachineName(int MachineGroup_ID)
        {
            SqlConnection cn;
            SqlCommand cmd;

            cn = new SqlConnection(connection);
            String query = @" Select Name 
                              from Machines where (Machines.MachineGroupId={0})";
            query = String.Format(query, MachineGroup_ID);

            cn.Open();
            cmd = new SqlCommand(query, cn);

            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dr.Close();
            cn.Close();
            return dt;

        }
        
    }
}