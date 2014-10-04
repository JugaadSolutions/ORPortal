using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using ManufactureMonitor.Entity;
namespace ManufactureMonitor.DALayer
{
    public class DataAccess
    {
        String connection = @"Data Source=.\SQLEXPRESS;Initial Catalog=IOR;Persist Security Info=True;User ID=sa;Password=ide123$%^";


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
        public DataTable GetMachines(int MachineGroup_ID)
        {
            SqlConnection cn;
            SqlCommand cmd;

            cn = new SqlConnection(connection);
            String query = @" Select Name  as Machines,Id
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
        public void  UpdateParameters(int Id,double TOS,
            String Pulses, String Pieces, double Rmin, double Rmax, double Omin, double Omax, double Gmin, double Gmax)
        {
            SqlConnection cn;
            SqlCommand cmd;

            cn = new SqlConnection(connection);
            String query = @" Update Machines SET TOS={0},Pulses='{1}',Pieces='{2}',Rmin={3},Rmax={4},Omin={5},
                                    Omax={6},Gmin={7},Gmax={8} 
                            where (Machines.Id={9})";
            query = String.Format(query,TOS,Pulses,Pieces,Rmin,Rmax,Omin,Omax,Gmin,Gmax,Id );
            cn.Open();
            cmd = new SqlCommand(query, cn);

            cmd.ExecuteNonQuery();
           
            cn.Close();

        }
        public DataTable GetMachineParameters(int ID)
        {
            SqlConnection cn;
            SqlCommand cmd;

            cn = new SqlConnection(connection);
            String query = @" Select Name as Machine,TOS,Pulses,Pieces,Rmin,Rmax,Omin,Omax,Gmin,Gmax
                            from Machines where Id={0}";
            query = String.Format(query, ID);

            cn.Open();
            cmd = new SqlCommand(query, cn);

            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dr.Close();
            cn.Close();
            return dt;


        }
        public bool Login(String UserName, String Password)
        {
            SqlConnection cn;
            SqlCommand cmd;

            cn = new SqlConnection(connection);
            String query = @"SELECT [Password] FROM [Users] WHERE  Name='{0}'";
            query=String.Format(query,UserName);
            
            cmd = new SqlCommand(query, cn);
            cn.Open();
            cmd.Connection = cn;
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dr.Close();
            cn.Close();
            if (dt.Rows.Count > 0)
            {
                if (((string)dt.Rows[0]["Password"] )== Password)
                return true;
              

            }
           
                return false;
         
        }
        public DataTable GetSchedule(int Machine_ID)
        {
            SqlConnection cn;
            SqlCommand cmd;

            cn = new SqlConnection(connection);
            String query = @" select Convert(varchar(5),CONVERT(TIME(0),Shifts.Start,0),20),Convert(varchar(5),CONVERT(TIME(0),Shifts.[End],0),20) ,
                            Convert(varchar(5),CONVERT(TIME(0),FirstBreak.[Start],0),20)  ,Convert(varchar(5),CONVERT(TIME(0),FirstBreak.[End],0),20) , 
                            Convert(varchar(5),CONVERT(TIME(0),SecondBreak.[Start], 0),20),Convert(varchar(5),CONVERT(TIME(0),SecondBreak.[End], 0),20) ,
                            Convert(varchar(5),CONVERT(TIME(0),ThirdBreak.[Start], 0),20) ,Convert(varchar(5),CONVERT(TIME(0),ThirdBreak.[End], 0),20),
                            Convert(varchar(5),CONVERT(TIME(0),FourthBreak.[Start], 0),20) ,Convert(varchar(5),CONVERT(TIME(0),FourthBreak.[End], 0),20) ,
                            Convert(varchar(5),CONVERT(TIME(0),FifthBreak.[Start], 0),20) ,Convert(varchar(5),CONVERT(TIME(0),FifthBreak.[End], 0),20) , 
                              
                            (Case when ShiftMachines.Monday=0 Then 'No' else 'Yes' End) ,
                            (Case When ShiftMachines.Tuesday=0 Then 'No' else 'Yes' End),
                            (Case When ShiftMachines.Wednesday=0 Then 'No' else 'Yes' End) ,
                            (Case When ShiftMachines.Thursday =0 Then 'No' else 'Yes' End),
                            (Case When ShiftMachines.Friday =0 Then 'No' else 'Yes' End) ,
                            (Case When ShiftMachines.Saturday =0 Then 'No' else 'Yes' End), 
                            (Case When ShiftMachines.Sunday=0 Then 'No' else 'Yes' End) 
                            from Shifts LEFT Outer Join ShiftMachines on (Shifts.Id=ShiftMachines.Shift_Id)
                            LEFT Outer join 
                            (select Breaks.Shift_Id, [start] , [end]  from Breaks where Name='FIRST REST' and Machine_Id=1) 
                                as FirstBreak on FirstBreak.Shift_Id = Shifts.Id

                            LEFT Outer join 
                            (select Breaks.Shift_Id, [start] , [end]  from Breaks where Name='SECOND REST'and Machine_Id=1) 
                            as SecondBreak on SecondBreak.Shift_Id = Shifts.Id

                            LEFT Outer join 
                            (select Breaks.Shift_Id, [start], [end]  from Breaks where Name='THIRD REST'and Machine_Id=1) 
                            as ThirdBreak on ThirdBreak.Shift_Id = Shifts.Id

                            LEFT Outer join 
                            (select Breaks.Shift_Id, [start] , [end] from Breaks where Name='FOURTH REST'and Machine_Id=1) 
                            as FourthBreak on FourthBreak.Shift_Id = Shifts.Id

                            LEFT Outer join 
                            (select Breaks.Shift_Id, [start] , [end]  from Breaks where Name='FIFTH REST'and Machine_Id=1) 
                            as FifthBreak on FifthBreak.Shift_Id = Shifts.Id
                            where ShiftMachines.Machine_Id = {0}";
            query = String.Format(query, Machine_ID);

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