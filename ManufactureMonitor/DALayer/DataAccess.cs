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
            String connection = System.Configuration.ConfigurationManager.
        ConnectionStrings["DefaultConnection"].ConnectionString;
       


            #region STOPPROBLEMS
            public DataTable GetStopProblems(int MachineGroup_ID)
        {
            SqlConnection cn;
            SqlCommand cmd;

            cn = new SqlConnection(connection);

            String query = @"  select
            [Description] as [Problem description] ,
            [Code] as [No], 
            (Case when CommonProblems.[Type]=1 then 'yes' else '-' end) as [Non-Operation Time1],
            (Case when CommonProblems.[Type]=2 then 'yes' else '-' end) as [Non-Operation Time2],
            (Case when CommonProblems.[Type]=3 then 'yes' else '-' end) as [Non-Operation Time3]
            From 
            CommonProblems";

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
            #endregion
         public DataTable GetParameters(int MachineGroup_ID)
        {
            SqlConnection cn;
            SqlCommand cmd;

            cn = new SqlConnection(connection);
            String query = @" Select Name as Machine, TOS as [time to stop(s)], Convert(nvarchar,Pulses,0)+':'+
            Convert(nvarchar,Pieces,0) as [Pulses:Pieces],Rmin as [OR red MIN(%)],Rmax as [OR red MAX(%)],Omin as [OR orange MIN(%)],
            Omax as [OR orange MAX(%)],Gmin as [OR green MIN(%)],Gmax as [OR green MAX(%)]
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
            public DataTable GetParameters(int MachineGroup_ID, int Machine_Id)
            {
                SqlConnection cn;
                SqlCommand cmd;

                cn = new SqlConnection(connection);
                String query = @" Select Name as Machine,Rmin as [OR red MIN(%)],Rmax as [OR red MAX(%)],Omin as [OR orange MIN(%)],
            Omax as [OR orange MAX(%)],Gmin as [OR green MIN(%)],Gmax as [OR green MAX(%)]
                            from Machines where (Machines.MachineGroupId={0} AND Machines.Id={1})";
                query = String.Format(query, MachineGroup_ID, Machine_Id);

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
         public DataTable GetMachine(int proj)
        {
            SqlConnection cn;
            SqlCommand cmd;

            cn = new SqlConnection(connection);
            String query = @" Select Machine_Id
                              from ProjectMachines where Project_Id={0}";
            query = String.Format(query, proj);

            cn.Open();
            cmd = new SqlCommand(query, cn);

            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dr.Close();
            cn.Close();
            return dt;

        }
        public DataTable GetMachines(int MachineGroup_ID,int Machine_Id)
        {
            SqlConnection cn;
            SqlCommand cmd;

            cn = new SqlConnection(connection);
            String query = @" Select Name  
                              from Machines where (Machines.MachineGroupId={0} )AND Machines.Id={1}";
            query = String.Format(query, MachineGroup_ID,Machine_Id);

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
            String Pulses, String Pieces, double Rmin, double Rmax, double Omin, double Omax, double Gmin, double Gmax,
            double MPDuration, double StopClose)
        {
            SqlConnection cn;
            SqlCommand cmd;

            cn = new SqlConnection(connection);
            String query = @" Update Machines SET TOS={0},Pulses='{1}',Pieces='{2}',Rmin={3},Rmax={4},Omin={5},
                                    Omax={6},Gmin={7},Gmax={8} ,MPDuration={9},StopCloseDuration={10}
                            where (Machines.Id={11})";
            query = String.Format(query,TOS,Pulses,Pieces,Rmin,Rmax,Omin,Omax,Gmin,Gmax,MPDuration,StopClose,Id );
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
            String query = @" Select *
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
                            (select Breaks.Shift_Id, [start] , [end]  from Breaks where Name='FIRST' and Machine_Id={0}) 
                                as FirstBreak on FirstBreak.Shift_Id = Shifts.Id

                            LEFT Outer join 
                            (select Breaks.Shift_Id, [start] , [end]  from Breaks where Name='SECOND'and Machine_Id={0}) 
                            as SecondBreak on SecondBreak.Shift_Id = Shifts.Id

                            LEFT Outer join 
                            (select Breaks.Shift_Id, [start], [end]  from Breaks where Name='THIRD'and Machine_Id={0}) 
                            as ThirdBreak on ThirdBreak.Shift_Id = Shifts.Id

                            LEFT Outer join 
                            (select Breaks.Shift_Id, [start] , [end] from Breaks where Name='FOURTH'and Machine_Id={0}) 
                            as FourthBreak on FourthBreak.Shift_Id = Shifts.Id

                            LEFT Outer join 
                            (select Breaks.Shift_Id, [start] , [end]  from Breaks where Name='FIFTH'and Machine_Id={0}) 
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
        public DataTable GetShiftDays(int MachineId)
        {
             SqlConnection cn;
            SqlCommand cmd;

            cn = new SqlConnection(connection);
            String query = @" select ( (Case when ShiftMachines.Monday=0 Then ' ' else 'Mon' End)+' ,'+
                            (Case When ShiftMachines.Tuesday=0 Then ' ' else 'Tue' End)+' ,'+
                            (Case When ShiftMachines.Wednesday=0 Then ' ' else 'Wed' End)+' ,'+
                            (Case When ShiftMachines.Thursday =0 Then ' ' else 'Thu' End)+' ,'+
                            (Case When ShiftMachines.Friday =0 Then ' ' else 'Fri' End) +' ,'+
                            (Case When ShiftMachines.Saturday =0 Then ' ' else 'Sat' End)+' ,'+ 
                            (Case When ShiftMachines.Sunday=0 Then ' ' else 'Sun' End) )as Days 
                            From ShiftMachines where Machine_Id={0}";
            query = String.Format(query, MachineId);

            cn.Open();
            cmd = new SqlCommand(query, cn);

            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dr.Close();
            cn.Close();
            return dt;
        }
        public bool SetPassword(String name,String password,String password1)
        {
            SqlConnection cn,cn1;
            SqlCommand cmd,cmd1;

            cn = new SqlConnection(connection);
            String query = @" select Password from Users 
                            where Name='{0}'";
            query = String.Format(query,name, password);
            cn.Open();
            cmd = new SqlCommand(query, cn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                
                if (password == dr["Password"].ToString())
                {
                    //cn.Open();
                    dr.Close();
                    cn1 = new SqlConnection(connection);
                    cn1.Open();
                    cmd1 = new SqlCommand("update Users set Password= '" + password1 + "' where Name='" + name + "'", cn1);
                    
                    cmd1.ExecuteNonQuery();
                    cn.Close();
                    cn1.Close();
                    return true;
                }
                else
                {
                    cn.Close();
                    return false;
                }

            }
            
            cn.Close();
            return false;
            

        }
        public DataTable GetCommonProblems()
        {
            SqlConnection cn;
            SqlCommand cmd;

            cn = new SqlConnection(connection);
            String query = @" Select Convert(nvarchar,code,0)+':'+ Description as [Description],code,type 
                              from CommonProblems ";
            query = String.Format(query, cn);

            cn.Open();
            cmd = new SqlCommand(query, cn);

            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dr.Close();
            cn.Close();
            return dt;

        }
        public bool AddProblems(String description, int code, int type,int subType)
        {
            SqlConnection cn;
            SqlCommand cmd;
            try
            {

                cn = new SqlConnection(connection);
                String query;


                if (subType <= 0)
                {
                    query = @"insert into CommonProblems(Description,Code,Type)
                    values('{0}',{1},{2})";

                    query = String.Format(query, description, code, type);
                }
                else
                {
                    query = @"insert into CommonProblems(Description,Code,Type,SubType)
                    values('{0}',{1},{2},{3})";

                    query = String.Format(query, description, code, type, subType);
                }
                cn.Open();
                cmd = new SqlCommand(query, cn);
                cmd.ExecuteNonQuery();
                cn.Close();
                return true;

            }

            catch (Exception)
            {
                return false;


            }
              
               
       }

        public DataTable SelectCommonProblems(String code)
        {
            SqlConnection cn;
            SqlCommand cmd;

            cn = new SqlConnection(connection);
            String query = @" Select  Description,code,type,subType
                              from CommonProblems where Code='{0}'";
            query = String.Format(query, code);

            cn.Open();
            cmd = new SqlCommand(query, cn);

            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dr.Close();
            cn.Close();
            return dt;

        }
        public void UpdateProblems(int code,String description,int type,int subtype)
        {
            SqlConnection cn;
            SqlCommand cmd;

            cn = new SqlConnection(connection);
            String query;
            if (subtype <= 0)
            {
                query = @" Update CommonProblems SET Description='{1}',Type={2}
                            where (Code={0})";
                query = String.Format(query, code, description, type);
            }
            else
            {
                query = @" Update CommonProblems SET Description='{1}',Type={2}, SubType={3}
                            where (Code={0})";
                query = String.Format(query, code, description, type, subtype);
            }

            cn.Open();
            cmd = new SqlCommand(query, cn);

            cmd.ExecuteNonQuery();

            cn.Close();

        }
        public DataTable DisplayProblems()
        {
            SqlConnection cn;
            SqlCommand cmd;

            cn = new SqlConnection(connection);

            String query = @"  select
            [Description] as [Problem description] ,
            [Code] as [No], 
            (Case when CommonProblems.[Type]=1 then 'yes' else '-' end) as [Non-Operation Time1],
            (Case when CommonProblems.[Type]=2 then 'yes' else '-' end) as [Non-Operation Time2],
            (Case when CommonProblems.[Type]=3 then 'yes' else '-' end) as [Non-Operation Time3]
            From 
            CommonProblems";

            query = String.Format(query,cn);

            cn.Open();
            cmd = new SqlCommand(query, cn);

            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dr.Close();

            cn.Close();

            return dt;

        }
        public void DeleteProblem(int code)
        {
            SqlConnection cn;
            SqlCommand cmd;

            cn = new SqlConnection(connection);
            String query = @" Delete From CommonProblems 
                            where (Code={0})";
            query = String.Format(query, code);
            cn.Open();
            cmd = new SqlCommand(query, cn);

            cmd.ExecuteNonQuery();

            cn.Close();
        }
        public DataTable GetShifts(int Id)
        {
            SqlConnection cn;
            SqlCommand cmd;

            cn = new SqlConnection(connection);
            String query = @"select Convert(varchar(5),CONVERT(TIME(0),Shifts.Start,0),20)   
                            +'-'+Convert(varchar(5),CONVERT(TIME(0),Shifts.[End],0),20)
                            +'   '
                            +(case when ShiftMachines.Monday=1 Then 'Mon' else ' '  End)+
                            +(case when ShiftMachines.Tuesday=1 Then ',Tue' else ' ' End)+
                            +(case when ShiftMachines.Wednesday=1 Then ',Wed'else ' '  End)+
                            +(case when ShiftMachines.Thursday=1 Then ',Thu' else ' ' End)+
                            +(case when ShiftMachines.Friday=1 Then ',Fri' else ' ' End)+
                            +(case when ShiftMachines.Saturday=1 Then ',Sat' else ' ' End)+
                            +(case when ShiftMachines.Sunday=1 Then ',Sun' else ' ' End) as shifts,Id,Name
                             from 
                             Shifts inner Join ShiftMachines on Shifts.Id=ShiftMachines.Shift_Id
                             where
                             ShiftMachines.Machine_Id={0} order by Shifts asc";
            query = String.Format(query, Id);
            cn.Open();
            cmd = new SqlCommand(query, cn);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dr.Close();
            cn.Close();
            return dt;

        }
        public void DeleteShift(int Shift_Id,int Machine_Id)
        {
            SqlConnection cn;
            SqlCommand cmd;

            cn = new SqlConnection(connection);
            String query = @" Delete From ShiftMachines 
                            where (Shift_Id={0} AND Machine_Id={1})";
            query = String.Format(query, Shift_Id,Machine_Id);
            cn.Open();
            cmd = new SqlCommand(query, cn);

            cmd.ExecuteNonQuery();

            cn.Close();
        }
        public DataTable SelectShift(int Shift_Id)
        {
            SqlConnection cn;
            SqlCommand cmd;

            cn = new SqlConnection(connection);
            String query = @" Select DatePart(Hour,Start) as [SHours],DatePart(Hour,[End]) as [EHours],
                              DatePart(Minute,Start) as [SMinutes],DatePart(Minute,[End]) as [EMinutes],Id
                            from 
                            Shifts 
                            where 
                            Id={0}";
            query = String.Format(query, Shift_Id);

            cn.Open();
            cmd = new SqlCommand(query, cn);

            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dr.Close();
            cn.Close();
            return dt;

        }
        public DataTable SelectSession(int SessionId)
        {
            SqlConnection cn;
            SqlCommand cmd;

            cn = new SqlConnection(connection);
            String query = @" Select DatePart(Hour,Start) as [SHours],DatePart(Hour,[End]) as [EHours],
                              DatePart(Minute,Start) as [SMinutes],DatePart(Minute,[End]) as [EMinutes],Id
                            from 
                            Sessions 
                            where 
                            Id={0}";
            query = String.Format(query, SessionId);

            cn.Open();
            cmd = new SqlCommand(query, cn);

            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dr.Close();
            cn.Close();
            return dt;
        }

        public SessionCollection getSessions(int shift, int machine)
        {

            SqlConnection con = new SqlConnection(connection);
            con.Open();

            SessionCollection sessions = new SessionCollection();

            String qry = String.Empty;
            qry = @"SELECT * FROM [Sessions] where Shift_Id={0} and Machine_Id={1}";

            qry = String.Format(qry, shift, machine);
            SqlCommand cmd = new SqlCommand(qry, con);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dr.Close();
            con.Close();
            con.Dispose();
            cmd.Dispose();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                sessions.Add(new Session(shift, (int)dt.Rows[i]["id"],
                    ((DateTime)dt.Rows[i]["Start"]).ToString(), ((DateTime)dt.Rows[i]["End"]).ToString()));
            }

            
            return sessions;
        }

        public SessionCollection getBreaks(int shift, int machine)
        {

            SqlConnection con = new SqlConnection(connection);
            con.Open();

            SessionCollection breaks = new SessionCollection();

            String qry = String.Empty;
            qry = @"SELECT Breaks.Id,Start,[End] FROM Breaks where Shift_Id={0} and Machine_Id = {1}";

            qry = String.Format(qry, shift, machine);
            SqlCommand cmd = new SqlCommand(qry, con);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dr.Close();
            con.Close();
            con.Dispose();
            cmd.Dispose();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Session s = new Session(shift, (int)dt.Rows[i]["Id"],
                    ((DateTime)dt.Rows[i]["Start"]).ToString(), ((DateTime)dt.Rows[i]["End"]).ToString());
                s.Isbreak = true;
                breaks.Add(s);
            }

            
            return breaks;
        }



        public void UpdateSession(int machine,int shift,int Id, String from, String to)
        {
            SqlConnection cn;
            SqlCommand cmd;

            cn = new SqlConnection(connection);
            String query = @" Update Sessions SET Start='{1}',[End]='{2}'
                            where Id={0} and Machine_Id={3} and Shift_Id = {4}";
            query = String.Format(query, Id, from, to,machine,shift);
            cn.Open();
            cmd = new SqlCommand(query, cn);

            cmd.ExecuteNonQuery();

            cn.Close();
        }


        public void UpdateShift(int Id, String from, String to)
        {
            SqlConnection cn;
            SqlCommand cmd;

            cn = new SqlConnection(connection);
            String query = @" Update Shifts SET Start='{1}',[End]='{2}'
                            where (Id='{0}')";
            query = String.Format(query, Id, from, to);
            cn.Open();
            cmd = new SqlCommand(query, cn);

            cmd.ExecuteNonQuery();

            cn.Close();

        }
         public DataTable ConvertData(int shour, int smin,int ehour,int emin,int Id)
        {
            SqlConnection cn;
            SqlCommand cmd;

            cn = new SqlConnection(connection);
            String query = @" Select DatePart(HOUR,{0})+''+DatePart(Minute,{1}) as[From],DatePart(HOUR,{2})+''+DatePart(Minute,{3}) as[To]
                            from Shifts
                            where Id=1
                            where (Code='{4}')";
            query = String.Format(query, shour, smin, ehour, emin, Id);
            cn.Open();
            cmd = new SqlCommand(query, cn);

            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dr.Close();
            cn.Close();
            return dt;


        }
         public void UpdateShiftday(int MId,int Id,bool mon,bool tue,bool wed,bool thu,bool fri,bool sat,bool sun)
         {
             SqlConnection cn;
             SqlCommand cmd;

             cn = new SqlConnection(connection);
             String query = @" Update ShiftMachines SET Monday='{2}',Tuesday='{3}',
                               Wednesday='{4}',Thursday='{5}',Friday='{6}',Saturday='{7}',Sunday='{8}'
                               where 
                              (Machine_Id={0} AND Shift_Id={1} )";
             query = String.Format(query,MId,Id,mon,tue,wed,thu,fri,sat,sun);
             cn.Open();
             cmd = new SqlCommand(query, cn);

             cmd.ExecuteNonQuery();

             cn.Close();

         }
         public DataTable Selectday(int Id,int MId)
         {
             SqlConnection cn;
             SqlCommand cmd;

             cn = new SqlConnection(connection);
             String query = @"Select Monday,Tuesday,Wednesday,Thursday,Friday,Saturday,Sunday 
                              From ShiftMachines
                            where 
                            Shift_Id={0} AND Machine_Id={1}";
             query = String.Format(query, Id, MId);

             cn.Open();
             cmd = new SqlCommand(query, cn);

             SqlDataReader dr = cmd.ExecuteReader();
             DataTable dt = new DataTable();
             dt.Load(dr);
             dr.Close();
             cn.Close();
             return dt;

         }
         public int AddShift( DateTime start, DateTime end)
         {
             SqlConnection cn;
             SqlCommand cmd,cmd1;
             SqlDataReader dr;
             try
             {

                 cn = new SqlConnection(connection);
                 String query = @"insert into Shifts(Start,[End]) values('{0}','{1}') ";
                 query = String.Format(query, start, end);
                 cn.Open();
                 cmd = new SqlCommand(query, cn);
                 cmd.ExecuteNonQuery();
                 cmd1 = new SqlCommand("select max(Id) from Shifts", cn);
                 dr = cmd1.ExecuteReader();
                 DataTable dt = new DataTable();
                 dt.Load(dr);
                 dr.Close();
                 cn.Close();

                 if (dt.Rows.Count > 0)
                 {
                     int ShiftId = (int)dt.Rows[0][0];
                     return ShiftId;

                 }

              
                 return -1;

             }

             catch (Exception)
             {
                 return -1;


             }

         }
         public void AddShiftday(int MId, int SId ,bool mon, bool tue, bool wed, bool thu, bool fri, bool sat, bool sun)
         {
             SqlConnection cn;
             SqlCommand cmd;

             cn = new SqlConnection(connection);
             String query = @" Insert Into ShiftMachines(Machine_Id,Monday,Tuesday,Wednesday,Thursday,Friday,Saturday,Sunday,Shift_Id)
                                Values({0},'{1}','{2}','{3}','{4}','{5}','{6}','{7}',{8})";
             query = String.Format(query, MId, mon, tue, wed, thu, fri, sat, sun, SId);
             cn.Open();
             cmd = new SqlCommand(query, cn);

             cmd.ExecuteNonQuery();

             cn.Close();

         }

         public ShiftCollection getShifts(int machine)
         {
             SqlConnection con = new SqlConnection(connection);
             con.Open();

             ShiftCollection shifts = new ShiftCollection();

             String qry = String.Empty;
             qry = @"SELECT Shifts.ID,Shifts.Name,Shifts.[Start],Shifts.[End],
                    Sunday, Monday, Tuesday, Wednesday,Thursday, Friday, Saturday FROM shifts
                    inner join ShiftMachines on Shifts.Id = ShiftMachines.Shift_Id
                    where ShiftMachines.Machine_Id = {0} 
                    ORDER BY id";

             qry = String.Format(qry, machine);

             SqlCommand cmd = new SqlCommand(qry, con);
             SqlDataReader dr = cmd.ExecuteReader();
             DataTable dt = new DataTable();
             dt.Load(dr);
             dr.Close();
             con.Close();
             con.Dispose();
             cmd.Dispose();

             for (int i = 0; i < dt.Rows.Count; i++)
             {
                 
                 shifts.Add(new Shift((int)dt.Rows[i]["id"], (string)dt.Rows[i]["name"],
                    ((DateTime)dt.Rows[i]["Start"]), ((DateTime)dt.Rows[i]["End"]),
                    (Boolean)dt.Rows[i]["Sunday"], (Boolean)dt.Rows[i]["Monday"], 
                    (Boolean)dt.Rows[i]["Tuesday"],
                    (Boolean)dt.Rows[i]["Wednesday"], 
                    (Boolean)dt.Rows[i]["Thursday"], 
                    (Boolean)dt.Rows[i]["Friday"], 
                    (Boolean)dt.Rows[i]["Saturday"]));
             }

            
             return shifts;
         }
         public void AddBreaks(int MId, int SId, DateTime start, DateTime end,String name)
         {
             SqlConnection cn;
             SqlCommand cmd;

             cn = new SqlConnection(connection);
             String query = @" Insert Into Breaks(Machine_Id,Shift_Id,Start,[End],Name)
                                Values({0},'{1}','{2}','{3}','{4}')";
             query = String.Format(query, MId, SId, start,end,name);
             cn.Open();
             cmd = new SqlCommand(query, cn);

             cmd.ExecuteNonQuery();

             cn.Close();

         }

         public  void UpdateBreaks(int p, int Shift_Id, DateTime BreakS, DateTime BreakE,String name)
         {
             SqlConnection cn;
             SqlCommand cmd;

             cn = new SqlConnection(connection);
             String query = @" Update Breaks SET Start='{2}',[End]='{3}'
                               where 
                              (Machine_Id={0} AND Shift_Id={1},Name='{4}' )";
             query = String.Format(query, p,Shift_Id,BreakS,BreakE,name);
             cn.Open();
             cmd = new SqlCommand(query, cn);

             cmd.ExecuteNonQuery();

             cn.Close();

         }

         public void DeleteBreaks(int p, int Shift_Id)
         {
             SqlConnection cn;
             SqlCommand cmd;

             cn = new SqlConnection(connection);
             String query = @" Delete from Breaks 
                               where 
                              (Machine_Id={0} AND Shift_Id={1} )";
             query = String.Format(query, p, Shift_Id);
             cn.Open();
             cmd = new SqlCommand(query, cn);

             cmd.ExecuteNonQuery();

             cn.Close();
         }
         public DataTable SelectBreak(int Shift_Id,int Machine_Id)
         {
             SqlConnection cn;
             SqlCommand cmd;

             cn = new SqlConnection(connection);
             String query = @" Select DatePart(Hour,Start) as [SHours],DatePart(Hour,[End]) as [EHours],
                              DatePart(Minute,Start) as [SMinutes],DatePart(Minute,[End]) as [EMinutes]
                            from 
                            Breaks 
                            where 
                            Shift_Id={0} AND Machine_Id={1}";
             query = String.Format(query, Shift_Id, Machine_Id);

             cn.Open();
             cmd = new SqlCommand(query, cn);

             SqlDataReader dr = cmd.ExecuteReader();
             DataTable dt = new DataTable();
             dt.Load(dr);
             dr.Close();
             cn.Close();
             return dt;

         }

        public SessionCollection GetBreaks(int Shift_Id,int Machine_Id)
         {
             SqlConnection cn;
             SqlCommand cmd;

             cn = new SqlConnection(connection);
             String query = @" Select *
                            from 
                            Breaks 
                            where 
                            Shift_Id={0} AND Machine_Id={1}";
             query = String.Format(query, Shift_Id, Machine_Id);

             cn.Open();
             cmd = new SqlCommand(query, cn);

             SqlDataReader dr = cmd.ExecuteReader();
             DataTable dt = new DataTable();
             dt.Load(dr);
             dr.Close();
             cn.Close();

           
              SessionCollection breaks = new SessionCollection();
             for( int i = 0 ; i< dt.Rows.Count ;i++)
             {
                 breaks.Add(new Session(Shift_Id,(int)dt.Rows[i]["Id"],((DateTime)dt.Rows[i]["Start"]).ToString("yyyy-MM-dd HH:mm:ss"),
                     ((DateTime)dt.Rows[i]["End"]).ToString("yyyy-MM-dd HH:mm:ss")));
             }
             

             return breaks;

         }


         
         public DataTable GetSessions(int Shift_Id, int Machine_Id)
         {
             SqlConnection cn;
             SqlCommand cmd;

             cn = new SqlConnection(connection);
             String query = @" Select Convert(varchar(5),CONVERT(TIME(0),[Start],0),20)+'-'+
                                Convert(varchar(5),CONVERT(TIME(0),[End],0),20) as [End],Id
                            from 
                            Sessions 
                            where 
                            Shift_Id={0} AND Machine_Id={1}";
             query = String.Format(query, Shift_Id, Machine_Id);

             cn.Open();
             cmd = new SqlCommand(query, cn);

             SqlDataReader dr = cmd.ExecuteReader();
             DataTable dt = new DataTable();
             dt.Load(dr);
             dr.Close();
             cn.Close();
             return dt;
         }
         public DataTable GetShiftTimings(int Machine_ID, int Shift_Id)
         {
             SqlConnection cn;
             SqlCommand cmd;

             cn = new SqlConnection(connection);
             String query = @" Select Machines.Name+'-'+' '+Convert(varchar(5),CONVERT(TIME(0),Shifts.Start,0),20)   
                               +'-'+Convert(varchar(5),CONVERT(TIME(0),Shifts.[End],0),20)
                               as shifts, CONVERT(TIME(0),Shifts.Start,20) as [Start],CONVERT(TIME(0),Shifts.[End],20) as [End],Shifts.Name as [Name]
                                 from Machines
                                 Join ShiftMachines on Machines.Id=ShiftMachines.Machine_Id 
                                 Join Shifts on Shifts.Id=ShiftMachines.Shift_Id
                                 where
                                 ShiftMachines.Machine_Id={0}";
             String query1 = @"AND ShiftMachines.Shift_Id={0} ";
             if (Shift_Id > 0)
             {
                 query1 = string.Format(query1, Shift_Id);
                 query += query1;
             }
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
         public DataTable GetShiftTimings(int Machine_ID)
         {
             SqlConnection cn;
             SqlCommand cmd;

             cn = new SqlConnection(connection);
             String query = @" Select Convert(varchar(5),CONVERT(TIME(0),Shifts.Start,0),20)   
                               +'-'+Convert(varchar(5),CONVERT(TIME(0),Shifts.[End],0),20)
                               as shifts,Shifts.Id as Id,Shifts.Name as [Name]
                                 from Machines
                                 Join ShiftMachines on Machines.Id=ShiftMachines.Machine_Id 
                                 Join Shifts on Shifts.Id=ShiftMachines.Shift_Id
                                 where
                                 ShiftMachines.Machine_Id={0}  ";
             query = String.Format(query, Machine_ID );
             cn.Open();
             cmd = new SqlCommand(query, cn);
             SqlDataReader dr = cmd.ExecuteReader();
             DataTable dt = new DataTable();
             dt.Load(dr);
             dr.Close();
             cn.Close();
             return dt;

         }
         public void DeleteSession(int Machine_Id, int Shift_Id)
         {
             SqlConnection cn;
             SqlCommand cmd;

             cn = new SqlConnection(connection);
             String query = @" Delete from Sessions 
                               where 
                              (Machine_Id={0} AND Shift_Id={1} )";
             query = String.Format(query, Machine_Id, Shift_Id);
             cn.Open();
             cmd = new SqlCommand(query, cn);

             cmd.ExecuteNonQuery();

             cn.Close();
         }
         public DataTable GetSpecificProblems(int Machine_Id)
         {
             SqlConnection cn;
             SqlCommand cmd;

             cn = new SqlConnection(connection);
             String query = @" Select Convert(nvarchar,code,0)+':'+Description as [Description],code,type 
                              from SpecificProblems where Machine_Id='{0}'";
             query = String.Format(query, Machine_Id);

             cn.Open();
             cmd = new SqlCommand(query, cn);

             SqlDataReader dr = cmd.ExecuteReader();
             DataTable dt = new DataTable();
             dt.Load(dr);
             dr.Close();
             cn.Close();
             return dt;

         }

         public DataTable SelectSpecificProblems(int code,int Machine_Id)
         {
             SqlConnection cn;
             SqlCommand cmd;

             cn = new SqlConnection(connection);
             String query = @" Select Description,code,type,subType
                              from SpecificProblems where Code={0} AND Machine_Id={1}";
             query = String.Format(query, code, Machine_Id);

             cn.Open();
             cmd = new SqlCommand(query, cn);

             SqlDataReader dr = cmd.ExecuteReader();
             DataTable dt = new DataTable();
             dt.Load(dr);
             dr.Close();
             cn.Close();
             return dt;
         }
         public void UpdateSpecificProblems(String code, String description, int type, int subtype)
         {
             SqlConnection cn;
             SqlCommand cmd;

             cn = new SqlConnection(connection);
             String query;
             if (subtype <= 0)
             {
                 query = @" Update SpecificProblems SET Description='{1}',Type={2}
                            where (Code={0})";
                 query = String.Format(query, code, description, type);
             }
             else
             {
                  query = @" Update SpecificProblems SET Description='{1}',Type={2}, SubType={3}
                            where (Code={0})";
                 query = String.Format(query, code, description, type,subtype);
             }

             cn.Open();
             cmd = new SqlCommand(query, cn);

             cmd.ExecuteNonQuery();

             cn.Close();

         }

         public bool AddSpecificProblem(string description, string code, string type,int Machine_Id,int subType)
         {
             SqlConnection cn;
             SqlCommand cmd;
             try
             {

                 cn = new SqlConnection(connection);
                 String query;


                 if (subType <= 0)
                 {
                     query = @"insert into SpecificProblems(Description,Code,Type,Machine_Id)
                    values('{0}',{1},{2},{3})";

                     query = String.Format(query, description, code, type, Machine_Id);
                 }
                 else
                 {
                     query = @"insert into SpecificProblems(Description,Code,Type,Machine_Id,SubType)
                    values('{0}',{1},{2},{3},{4})";

                     query = String.Format(query, description, code, type, Machine_Id, subType);
                 }
                 cn.Open();
                 cmd = new SqlCommand(query, cn);
                 cmd.ExecuteNonQuery();
                 cn.Close();
                 int Code=Convert.ToInt32(code);
                 if (Code >= 1 && Code <= 999)
                 {
                     return true;
                 }
                 else
                 {
                     return false;
                 }

             }

             catch (Exception)
             {
                 return false;


             }
               
         }
         public DataTable DisplaySpecificProblems(int Machine_Id)
         {
             SqlConnection cn;
             SqlCommand cmd;

             cn = new SqlConnection(connection);

             String query = @"  select
            [Description] as [Problem Description] ,
            [Code] as [No], 
            (Case when SpecificProblems.[Type]=1 then 'yes' else '-' end) as [Non-Operation Time1],
            (Case when SpecificProblems.[Type]=2 then 'yes' else '-' end) as [Non-Operation Time2],
            (Case when SpecificProblems.[Type]=3 then 'yes' else '-' end) as [Non-Operation Time3]
            From 
            SpecificProblems 
            where Machine_Id={0}";

             query = String.Format(query, Machine_Id);

             cn.Open();
             cmd = new SqlCommand(query, cn);

             SqlDataReader dr = cmd.ExecuteReader();
             DataTable dt = new DataTable();
             dt.Load(dr);
             dr.Close();

             cn.Close();

             return dt;

         }
         public DataTable GetProjects(int Machine_Id)
         {
             SqlConnection cn;
             SqlCommand cmd;

             cn = new SqlConnection(connection);
             String query = @"Select Projects.Name+' - ' + Convert(nvarchar,Projects.CycleTime,0) as Projects,Projects.Id
             from ProjectMachines join Projects on ProjectMachines.Project_Id=Projects.Id
             where Machine_Id='{0}'";
             query = String.Format(query, Machine_Id);

             cn.Open();
             cmd = new SqlCommand(query, cn);

             SqlDataReader dr = cmd.ExecuteReader();
             DataTable dt = new DataTable();
             dt.Load(dr);
             dr.Close();
             cn.Close();
             return dt;

         }
         public void AddProjects(int MId, int SId, DateTime start, DateTime end, String name)
         {
             SqlConnection cn;
             SqlCommand cmd;

             cn = new SqlConnection(connection);
             String query = @" Insert Into Breaks(Machine_Id,Shift_Id,Start,[End],Name)
                                Values({0},'{1}','{2}','{3}','{4}')";
             query = String.Format(query, MId, SId, start, end, name);
             cn.Open();
             cmd = new SqlCommand(query, cn);

             cmd.ExecuteNonQuery();

             cn.Close();

         }
         public int AddProjects(String name,float time)
         {
             SqlConnection cn;
             SqlCommand cmd, cmd1;
             SqlDataReader dr;
             try
             {

                 cn = new SqlConnection(connection);
                 String query = @"insert into Projects(Name,CycleTime) values('{0}',{1}) ";
                 query = String.Format(query, name, time);
                 cn.Open();
                 cmd = new SqlCommand(query, cn);
                 cmd.ExecuteNonQuery();
                 cmd1 = new SqlCommand("select max(Id) from Projects", cn);
                 dr = cmd1.ExecuteReader();
                 DataTable dt = new DataTable();
                 dt.Load(dr);
                 dr.Close();
                 cn.Close();

                 if (dt.Rows.Count > 0)
                 {
                     int ProjectId = (int)dt.Rows[0][0];
                     return ProjectId;

                 }


                 return -1;

             }

             catch (Exception)
             {
                 return -1;


             }

         }
         public bool AddProjectId(int Project_Id, int Machine_Id)
         {
             SqlConnection cn;
             SqlCommand cmd;
             try
             {
                 cn = new SqlConnection(connection);
                 String query = @" Insert Into ProjectMachines(Project_Id,Machine_Id)
                                    Values({0},{1})";
                 query = String.Format(query, Project_Id, Machine_Id);
                 cn.Open();
                 cmd = new SqlCommand(query, cn);

                 cmd.ExecuteNonQuery();

                 cn.Close();
                 return true;
             }
             catch (Exception)
             {
                 return false;

             }


         }
         public void UpdateProjects(int ProjectId, String name,float time)
         {
             SqlConnection cn;
             SqlCommand cmd;

             cn = new SqlConnection(connection);
             String query = @" Update Projects SET Name='{1}',CycleTime={2}
                               where 
                              (Id={0} )";
             query = String.Format(query, ProjectId, name, time);
             cn.Open();
             cmd = new SqlCommand(query, cn);

             cmd.ExecuteNonQuery();

             cn.Close();

         }
         public DataTable SelectProject(int Project_Id, int Machine_Id)
         {
             SqlConnection cn;
             SqlCommand cmd;

             cn = new SqlConnection(connection);
             String query = @"Select Projects.Name as Projects,Projects.CycleTime as Time
                            from ProjectMachines 
                            join Projects on ProjectMachines.Project_Id=Projects.Id
                            where ProjectMachines.Machine_Id={1} AND ProjectMachines.Project_Id={0}";
             query = String.Format(query, Project_Id, Machine_Id);

             cn.Open();
             cmd = new SqlCommand(query, cn);

             SqlDataReader dr = cmd.ExecuteReader();
             DataTable dt = new DataTable();
             dt.Load(dr);
             dr.Close();
             cn.Close();
             return dt;
         }

         public void DeleteProject(int Project_Id)
         {
             SqlConnection cn;
             SqlCommand cmd;

             cn = new SqlConnection(connection);
             String query = @" Delete from Projects 
                               where 
                              (Id={0} )";
             query = String.Format(query, Project_Id);
             cn.Open();
             cmd = new SqlCommand(query, cn);

             cmd.ExecuteNonQuery();

             cn.Close();
         }
         public void DeleteProjectId(int Project_Id, int Machine_Id)
         {
             SqlConnection cn;
             SqlCommand cmd;

             cn = new SqlConnection(connection);
             String query = @" Delete from ProjectMachines 
                               where 
                              (Project_Id={0} AND Machine_Id={1} )";
             query = String.Format(query, Project_Id,Machine_Id);
             cn.Open();
             cmd = new SqlCommand(query, cn);

             cmd.ExecuteNonQuery();

             cn.Close();
         }
         public DataTable GetProject(int Machine_ID)
         {
             SqlConnection cn;
             SqlCommand cmd;

             cn = new SqlConnection(connection);
             String query = @" Select Projects.Name as Projects,Projects.CycleTime as Time
                            from ProjectMachines 
                            join Projects on ProjectMachines.Project_Id=Projects.Id
                            where ProjectMachines.Machine_Id={0}";
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
         public DataTable GetMachineInputs(int Machine_Id, int Shift_Id, String date)
         {
             SqlConnection cn;
             SqlCommand cmd;

             cn = new SqlConnection(connection);
             String query = @"Select Convert(varchar(5),CONVERT(TIME(0),Shifts.Start,0),20) as [From],
                                Convert(varchar(5),CONVERT(TIME(0),Shifts.[End],0),20) as [To]
                                from Shifts
                                where Id={0} 
                                " ;

            
             query = String.Format(query,Shift_Id);

             cn.Open();
             cmd = new SqlCommand(query, cn);

             SqlDataReader dr = cmd.ExecuteReader();
             DataTable dt = new DataTable();
             dt.Load(dr);
             dr.Close();

             DateTime fromTs = DateTime.Parse(date + " "+dt.Rows[0]["From"]);
             DateTime toTs = DateTime.Parse(date + " "+dt.Rows[0]["To"]);

             query = @"Select Timestamp from MachineInputs where Machine_Id = {0}  and Timestamp >= '{1}' and Timestamp < '{2}'
                                 
                                ";
             query = String.Format(query, Machine_Id, fromTs.ToString("yyyy-MM-dd HH:mm:ss"), toTs.ToString("yyyy-MM-dd HH:mm:ss"));

             cmd = new SqlCommand(query, cn);

             dr = cmd.ExecuteReader();
             dt = new DataTable();
             dt.Load(dr);

             if (dt.Rows.Count > 0)
                 dt.Columns.Add("Time Between Pulses[s]", typeof(string));

             DateTime temp = fromTs;
             for( int i = 0 ; i < dt.Rows.Count ; i++)
             {

                  
                 TimeSpan ts = (DateTime)dt.Rows[i]["Timestamp"] - temp;
                 dt.Rows[i]["Time Between Pulses[s]"] = ts.TotalSeconds;

                 temp = (DateTime)dt.Rows[i]["Timestamp"];
                 }


             dr.Close();
             cn.Close();
             return dt;
         }

         public List<TimeSequence> GetStopDetails(int machine, int Shift_Id, String from, String to, bool Speedloss)
         {

             SqlConnection cn;
             SqlCommand cmd;

             String query ;
             String query1 = String.Empty;

             cn = new SqlConnection(connection);

             query = @"  select Stops.SlNo, Stops.Code, CONVERT(TIME(0), [Start],20)  as [From], CONVERT(TIME(0),[End],20) as [To],
                        datediff(second,0,[End]-[Start]) as 'Duration[s]',
                        (Case when CommonProblems.[Type]=3 then 'OFF' else 'STOP' end) as 'StopType',
                        Convert(nvarchar,CommonProblems.Code,0)+':'+[Description] as Problem,
                        Comment,
                        'Common' as Source,
                        Stops.Machine_Id       
                        from Stops                           
                        inner join CommonProblems on CommonProblems.Code = Stops.Code
                        where [Start] >= '{1}' and [End] < '{2}' 
                        union
                        select Stops.SlNo, Stops.Code, CONVERT(TIME(0), [Start],20)  as [From], CONVERT(TIME(0),[End],20) as [To],
                        datediff(second,0,[End]-[Start]) as 'Duration[s]', 
                        (Case when SpecificProblems.[Type]=3 then 'OFF' else 'STOP' end) as 'StopType', 
                        Convert(nvarchar,SpecificProblems.Code,0)+':'+[Description] as Problem,
                        Comment ,
                        'Specific' as Source,
                        Stops.Machine_Id    
                        from Stops                               
                        inner join SpecificProblems on SpecificProblems.Code = Stops.Code

                            where [Start] >= '{1}' and [End] < '{2}' and SpecificProblems.Machine_Id={0} 

                            union
 
                            select OFFs.SlNo, OFFs.Code, CONVERT(TIME(0), [Start],20)  as [From], CONVERT(TIME(0),[End],20) as [To],
                        datediff(second,0,[End]-[Start]) as 'Duration[s]', 
                        (Case when SpecificProblems.[Type]=3 then 'OFF' else 'STOP' end) as 'StopType', 
                        Convert(nvarchar,SpecificProblems.Code,0)+':'+[Description] as Problem,
                        Comment ,
                        'Specific' as Source,
                        OFFs.Machine_Id    
                        from OFFs                               
                        inner join SpecificProblems on SpecificProblems.Code = OFFs.Code

                            where [Start] >= '{1}' and [End] < '{2}' and SpecificProblems.Machine_Id={0}
                            union
                            select OFFs.SlNo, OFFs.Code, CONVERT(TIME(0), [Start],20)  as [From], CONVERT(TIME(0),[End],20) as [To],
                            datediff(second,0,[End]-[Start]) as 'Duration[s]', 
                        (Case when CommonProblems.[Type]=3 then 'OFF' else 'STOP' end) as 'StopType', 
                        Convert(nvarchar,CommonProblems.Code,0)+':'+[Description] as Problem,
                        Comment ,
                        'Common' as Source,
                        OFFs.Machine_Id    
                        from OFFs                               
                        inner join CommonProblems on CommonProblems.Code = OFFs.Code

                            where [Start] >= '{1}' and [End] < '{2}' ";

                 if( Speedloss )
                 {
                     query1 = @"
                            union
 
                            select Stops.SlNo, Stops.Code, CONVERT(TIME(0), [Start],20)  as [From], CONVERT(TIME(0),[End],20) as [To],
                        datediff(second,0,[End]-[Start]) as 'Duration[s]',
                        
                        [Status] as 'StopType',
                        '' as Problem,
                        Comment,
                        'Specific' as Source,
                        Stops.Machine_Id    
                        from Stops 
                        
                        where [Start] >= '{1}' and [End] < '{2}' 
                        and  [Status] ='SpeedLoss'";
                     query1 = String.Format(query1, machine, from,
                         to);

                     
                 }
                 query += query1 +"  order by [From]";
                 query = String.Format(query, machine, 
                 from, to);

             cn.Open();
             cmd = new SqlCommand(query, cn);

            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
             dt.Load(dr);
             dr.Close();
             cn.Close();
             List<TimeSequence> TimeSequence = new List<TimeSequence>();

             for (int i = 0; i < dt.Rows.Count; i++)
             {
                 TimeSequence.Add(new TimeSequence
                 {
                     ProblemCode = (int)dt.Rows[i]["Code"],
                     From = dt.Rows[i]["From"].ToString(),
                     To = dt.Rows[i]["To"].ToString(),

                     Duration = (int)dt.Rows[i]["Duration[s]"],
                     StopType = (String)dt.Rows[i]["StopType"],
                     Problem = (String)dt.Rows[i]["Problem"],
                     Comment = (dt.Rows[i]["Comment"] == DBNull.Value) ? "" : (String)dt.Rows[i]["Comment"]
                     
                 });
             }

             return TimeSequence;
         }

         internal DataTable GetStopInfo(int p, String type, String source, int machine)
         {
             SqlConnection cn;
             SqlCommand cmd;
             String query =String.Empty;
             cn = new SqlConnection(connection);
             if( type == "STOP" ) type = "Stops";
             else if( type == "OFF") type = "Offs";
             if (source == "Common")
             {

                 query  = @" Select CommonProblems.Code, Description
                                from CommonProblems 
                                inner join {0} on {0}.Code = CommonProblems.Code
                                where {0}.Code = {1}";
                 query = String.Format(query, type, p);
             }
             else if (source == "Specific")
             {
                 query = @" Select SpecificProblems.Code, Description
                                from SpecificProblems 
                                inner join {0} on {0}.Code = CommonProblems.Code
                                where {0}.Code = {1} and {0}.Machine_Id = {2}";
                 query = String.Format(query, type, p, machine);
             }
             query = String.Format(query, p);
                 

             cn.Open();
             cmd = new SqlCommand(query, cn);

             SqlDataReader dr = cmd.ExecuteReader();
             DataTable dt = new DataTable();
             dt.Load(dr);
             dr.Close();
             cn.Close();
             return dt;
         }

         public DataTable GetStopsInfo(int machine)
         {
             SqlConnection cn;
             SqlCommand cmd;

             cn = new SqlConnection(connection);
             String query = @" Select Convert(nvarchar,code,0)+':'+ Description as [Description],code ,1 as Filter
                              from CommonProblems 

                                union

                            Select Convert(nvarchar,code,0)+':'+ Description as [Description],code ,2 as Filter
                              from SpecificProblems where Machine_Id = {0} 
                                order by Filter";
             query = String.Format(query, machine);
             query = String.Format(query, cn);

             cn.Open();
             cmd = new SqlCommand(query, cn);

             SqlDataReader dr = cmd.ExecuteReader();
             DataTable dt = new DataTable();
             dt.Load(dr);
             dr.Close();
             cn.Close();
             return dt;
         }

         public DataTable GetOffInfo(int machine)
         {
             SqlConnection cn;
             SqlCommand cmd;

             cn = new SqlConnection(connection);
             String query = @" Select Convert(nvarchar,code,0)+':'+ Description as [Description],code ,1 as Filter
                              from CommonProblems where Type='3'

                                union

                            Select Convert(nvarchar,code,0)+':'+ Description as [Description],code ,2 as Filter
                              from SpecificProblems where Machine_Id = {0} and Type='3'
                                order by Filter";
             query = String.Format(query, machine);
             query = String.Format(query, cn);

             cn.Open();
             cmd = new SqlCommand(query, cn);

             SqlDataReader dr = cmd.ExecuteReader();
             DataTable dt = new DataTable();
             dt.Load(dr);
             dr.Close();
             cn.Close();
             return dt;
         }

         public DataTable GetStops(int machine, DateTime start, DateTime end)
         {

             SqlConnection cn;
             SqlCommand cmd;

             cn = new SqlConnection(connection);
             String query = @" Select Convert(nvarchar,code,0)+':'+ Description as [Description],code ,1 as Filter
                              from CommonProblems 

                                union

                            Select Convert(nvarchar,code,0)+':'+ Description as [Description],code ,2 as Filter
                              from SpecificProblems where Machine_Id = {0} 
                                order by Filter";
             query = String.Format(query, machine);
             query = String.Format(query, cn);

             cn.Open();
             cmd = new SqlCommand(query, cn);

             SqlDataReader dr = cmd.ExecuteReader();
             DataTable dt = new DataTable();
             dt.Load(dr);
             dr.Close();
             cn.Close();
             return dt;
         }


         internal DataTable GetModels(int p)
         {
             SqlConnection cn;
             SqlCommand cmd;

             cn = new SqlConnection(connection);
             String query = @" Select Projects.ID,Projects.Name, Name+'-'+Convert(nvarchar,CycleTime,0) as [Models]
                              from ProjectMachines 
                                inner join Projects on Projects.id=ProjectMachines.Project_Id
                                where Machine_Id={0}";
             query = String.Format(query, p);

             cn.Open();
             cmd = new SqlCommand(query, cn);

             SqlDataReader dr = cmd.ExecuteReader();
             DataTable dt = new DataTable();
             dt.Load(dr);
             dr.Close();
             cn.Close();
             return dt;
         }

//         public List<OR> GetOR(int MachineId, DateTime from, DateTime to)
//         {

//             List<OR> ORList = new List<OR>();

//             List<Session> ORSessions = new List<Session>();

//             SqlConnection cn;
//             SqlCommand cmd;

//             cn = new SqlConnection(connection);
//             String query = @" Select * from ProjectTracker where Machine_Id = {0} 
//                and Timestamp > '{1}' and Timestamp < '{2}' ";
//             query = String.Format(query, MachineId,from.ToString("yyyy-MM-dd HH:mm:ss"), to.ToString("yyyy-MM-dd HH:mm:ss"));

//             cn.Open();
//             cmd = new SqlCommand(query, cn);

//             SqlDataReader dr = cmd.ExecuteReader();
//             DataTable dt = new DataTable();
//             dt.Load(dr);
//             dr.Close();

//             DateTime startPoint = from;
//             for (int i = 0; i < dt.Rows.Count; i++)
//             {
//                 OR or = new OR();
//                 or.From = startPoint;
//                 or.To = DateTime.Parse((string)dt.Rows[i]["Timestamp"]);
//                 ORList.Add(or);

//                 startPoint = or.To;
//             }



         //         }

         #region SHIFT_HISTORY
         public List<ShiftHistory> GetShiftHistory(int machine,String from,String to)
         {
             SqlConnection cn;
             SqlCommand cmd;

             cn = new SqlConnection(connection);
             
                 String query = @"select distinct Convert(Time(0),[From],20) as [From], Convert(Time(0),[To],20) as [To],
                                Name as Project,CycleTime, ProjectTracker.[From] as 'Start',ProjectTracker.[To] as 'End',
                                SessionActual - Scraps as [Actual],Scraps, Scraps.[timestamp] from ProjectTracker 
                                inner join Projects on ProjectTracker.Project_Id = Projects.Id 
                                inner join Scraps on ProjectTracker.SlNo = Scraps.ProjectTracker_Id 
                                 where [From]>='{1}' and ([From]<'{2}' or [To] is null) and
                                  ProjectTracker.Machine_Id={0} and Scraps.Machine_Id={0} 
                                   and Timestamp >='{1}' 
                                   and Timestamp<='{2}'
                                order by Timestamp asc";



                 query = String.Format(query, machine, from, to);

                 cn.Open();
                 cmd = new SqlCommand(query, cn);

                 SqlDataReader dr = cmd.ExecuteReader();
                 DataTable dt = new DataTable();
                 dt.Load(dr);
                 dr.Close();
                 cn.Close();
             
             dt.Columns.Add("LoadTime", typeof(double));
             dt.Columns.Add("Nop1", typeof(double));
             dt.Columns.Add("Nop2", typeof(double));
             dt.Columns.Add("Undefined", typeof(double));
             dt.Columns.Add("idle", typeof(double));
             dt.Columns.Add("KR", typeof(double));
             dt.Columns.Add("BKR", typeof(double));
             dt.Columns.Add("OK", typeof(double));

          

             for (int i = 0; i < dt.Rows.Count; i++)
             {
                 ShiftCollection shifts = getShifts(machine);
                 Shift s = shifts.getShift((DateTime)dt.Rows[i]["Start"], dt.Rows[i]["End"] ==
                         DBNull.Value ? DateTime.Now : (DateTime)dt.Rows[i]["End"]);
                 s.Sessions = getSessions(s.ID, machine);
                 s.Breaks = getBreaks(s.ID, machine);

                 double OK = (int)dt.Rows[i]["Actual"] - (int)dt.Rows[i]["Scraps"];
                 dt.Rows[i]["OK"]=OK;

                

                 double Nop2 = GetNop2Duration(machine, (DateTime)dt.Rows[i]["Start"],
                     dt.Rows[i]["End"] ==
                     DBNull.Value ? DateTime.Now : (DateTime)dt.Rows[i]["End"], s);

                 dt.Rows[i]["Nop2"] = Nop2;

                 double Undefined = GetUndefinedDuration(machine, (DateTime)dt.Rows[i]["Start"],
                     dt.Rows[i]["End"] ==
                     DBNull.Value ? DateTime.Now : (DateTime)dt.Rows[i]["End"], s);
                 dt.Rows[i]["Undefined"] = Undefined;

                 double OffDuration = GetOffDuration(machine, (DateTime)dt.Rows[i]["Start"],
                     dt.Rows[i]["End"] ==
                     DBNull.Value ? DateTime.Now : (DateTime)dt.Rows[i]["End"], s);
                 dt.Rows[i]["Idle"] = OffDuration;

                 double Nop1 = GetNop1Duration(machine, (DateTime)dt.Rows[i]["Start"],
                    dt.Rows[i]["End"] ==
                    DBNull.Value ? DateTime.Now : (DateTime)dt.Rows[i]["End"], s);
                 dt.Rows[i]["Nop1"] = Nop1;


                 double LoadTime = GetLoadTime(machine, (DateTime)dt.Rows[i]["Start"],
                     dt.Rows[i]["End"] ==
                     DBNull.Value ? DateTime.Now : (DateTime)dt.Rows[i]["End"], s);

                 dt.Rows[i]["LoadTime"] = LoadTime-OffDuration;

                 double Kadouritsu = (((int)dt.Rows[i]["Actual"]  * (double)dt.Rows[i]["CycleTime"])
                     / LoadTime)*100;
                 dt.Rows[i]["KR"] = Math.Round(Kadouritsu,2);

                 double Bekadouritsu = ((LoadTime - Nop1) / LoadTime) * 100;
                 dt.Rows[i]["BKR"] = Math.Round(Bekadouritsu, 2);

                 
                

             }

           
             List<ShiftHistory> ShiftHistory = new List<ShiftHistory>();

             for (int i = 0; i < dt.Rows.Count; i++)
             {
                 ShiftHistory.Add(new ShiftHistory
                 {
                     Project = (String)dt.Rows[i]["Project"],
                     CycleTime = (double)dt.Rows[i]["CycleTime"],
                     From = dt.Rows[i]["From"].ToString(),
                     To = dt.Rows[i]["To"].ToString(),
                     Actual = (int)dt.Rows[i]["Actual"],
                     Scraps = (int)dt.Rows[i]["Scraps"],
                     LoadTime = (double)dt.Rows[i]["LoadTime"],
                     Nop1 = (double)dt.Rows[i]["Nop1"],
                     Nop2 = (double)dt.Rows[i]["Nop2"],
                     Undefined = (double)dt.Rows[i]["Undefined"],
                     Idle = (double)dt.Rows[i]["Idle"],
                     KR = (double)dt.Rows[i]["KR"],
                     BKR = (double)dt.Rows[i]["BKR"],
                     OK=(double)dt.Rows[i]["OK"]
                     
                 });
             }

             return ShiftHistory;
         }

         public List<ShiftHistory_Summary> GetShiftHistory_Summary(int machine, String from, String to)
         {
             
             List<ShiftHistory> ShiftHistory =GetShiftHistory(machine, from, to);
             Dictionary<String, List<ShiftHistory>> ShiftHistoryCollection = new Dictionary<string,List<ShiftHistory>>();

            
             foreach (ShiftHistory sh in ShiftHistory)
             {
                 if (ShiftHistoryCollection.ContainsKey(sh.Project))
                     ShiftHistoryCollection[sh.Project].Add(sh);
                 else
                 {
                     List<ShiftHistory> sl = new List<Entity.ShiftHistory>();
                     sl.Add(sh);
                     ShiftHistoryCollection.Add(sh.Project, sl);
                 }
             }

             List<ShiftHistory_Summary> ShSummary = new List<ShiftHistory_Summary>();

             foreach (KeyValuePair<string, List<ShiftHistory>> K in ShiftHistoryCollection)
             {
                 ShSummary.Add(new ShiftHistory_Summary(K.Value));
             }

             return ShSummary;
         }



         public double GetLoadTime(int machine, DateTime start, DateTime end, Shift s)
         {
            
             

            

             double loadtime = s.getActiveDuration(start,end);

             return loadtime;
         
         }


         public double GetNop2Duration(int machine, DateTime start, DateTime end,Shift s)
         {
              

            

             double duration = 0;
             SqlConnection cn;
             SqlCommand cmd;

             cn = new SqlConnection(connection);

             cn.Open();
             cmd = new SqlCommand("getDefinedStopDuration", cn) ;
             cmd.CommandType = CommandType.StoredProcedure;

             cmd.Parameters.Add("@StartTs", SqlDbType.DateTime).Value = start;
             cmd.Parameters.Add("@StopTs", SqlDbType.DateTime).Value = end;
             cmd.Parameters.Add("@StopType", SqlDbType.Int).Value = 2;
             cmd.Parameters.Add("@Machine_Id", SqlDbType.Int).Value = machine;


             SqlDataReader dr = cmd.ExecuteReader();
             DataTable dt = new DataTable();
             dt.Load(dr);
             if (dt.Rows.Count <= 0) return 0;
             if (dt.Rows[0][0] == DBNull.Value) return 0;
             for (int i = 0; i < dt.Rows.Count; i++)
             {
                 duration += s.getActiveDuration((DateTime)dt.Rows[i]["Start"], (DateTime)dt.Rows[i]["END"]);
             }

             cn.Close();
             return duration;
         }

         public double GetNop2_TypeDuration(int machine, DateTime start, DateTime end, int type, ShiftCollection shifts)
         {
             

             Shift s = shifts.getShift(start, end);
             s.Sessions = getSessions(s.ID, machine);
             s.Breaks = getBreaks(s.ID, machine);

             double duration = 0;
             SqlConnection cn;
             SqlCommand cmd;

             String query = @"select  {0} as Start,[END], Stops.Code, 1 as C1

                            from Stops 
                            inner join CommonProblems on Stops.Code = CommonProblems.code

                            where 
                            [Start] <={0} and [Start] <={1} and
                            [End] >={0}  and [End] <={1}
                            and Stops.Code<> 0 and CommonProblems.Type=2  
                            and CommonProblems.SubType = {2} and Stops.Machine_Id = {3}
                            union
                            select  {0} as Start,[END],Stops.Code, 1 as C1
                                                                from Stops 
                                                                inner join SpecificProblems on Stops.Code = SpecificProblems.Code

                                                                where  
                            [Start] <={0} and [Start] <={1} and
                            [End] >={0}  and [End] <={1}
                            and Stops.Code <> 0  and SpecificProblems.Type=2 
                            and SpecificProblems.SubType = {2} and Stops.Machine_Id = {3}

                            union

                            select  [START] as Start,[END], Stops.Code,2 as C1

                            from Stops 
                            inner join CommonProblems on Stops.Code = CommonProblems.code

                            where  
                             [Start] >={0} and [Start] <={1} and
                            [End] >={0}  and [End] <={1}
                            and Stops.Code <> 0 and CommonProblems.Type=2 
                            and CommonProblems.SubType = {2} and Stops.Machine_Id = {3}
                            union
                            select  [START] as Start,[END],Stops.Code, 2 as C1
                                                                from Stops 
                                                                inner join SpecificProblems on Stops.Code = SpecificProblems.Code

                                                                where  
                             [Start] >={0} and [Start] <={1} and
                            [End] >={0}  and [End] <={1}
                            and Stops.Code <> 0 and SpecificProblems.Type=2 
                            and SpecificProblems.SubType = {2} and Stops.Machine_Id = {3}

                            union
                            select  [START] as Start,{1}, Stops.Code, 3 as C1

                            from Stops 
                            inner join CommonProblems on Stops.Code = CommonProblems.code

                            where  
                             [Start] >={0} and [Start] <={1} and
                            [End] >={0}  and [End] >={1}
                            and Stops.Code <> 0 and CommonProblems.Type=2  
                            and CommonProblems.SubType = {2} and Stops.Machine_Id = {3}
                            union
                            select  [START] as Start,{1},Stops.Code, 3 as C1
                             from Stops 
                            inner join SpecificProblems on Stops.Code = SpecificProblems.Code
                            where  
                             [Start] >={0} and [Start] <={1} and
                            [End] >={0}  and [End] >={1} 
                            and Stops.Code <> 0 and SpecificProblems.Type=2  
                            and SpecificProblems.SubType = {2} and Stops.Machine_Id = {3}

                            order by C1";



             query = String.Format(query, machine, start, end);

             cn = new SqlConnection(connection);
             cn.Open();
             cmd = new SqlCommand(query, cn);

             SqlDataReader dr = cmd.ExecuteReader();


             DataTable dt = new DataTable();
             dt.Load(dr);
             if (dt.Rows.Count <= 0) return 0;
             if (dt.Rows[0][0] == DBNull.Value) return 0;
             for (int i = 0; i < dt.Rows.Count; i++)
             {
                 duration += s.getActiveDuration((DateTime)dt.Rows[i]["Start"], (DateTime)dt.Rows[i]["END"]);
             }

             cn.Close();
             return duration;
         }

         public double GetNop1Duration(int machine, DateTime start, DateTime end, Shift s)
         {
             

            

             double duration = 0;
             SqlConnection cn;
             SqlCommand cmd;

             cn = new SqlConnection(connection);

             cn.Open();
             cmd = new SqlCommand("getDefinedStopDuration", cn);
             cmd.CommandType = CommandType.StoredProcedure;

             cmd.Parameters.Add("@StartTs", SqlDbType.DateTime).Value = start;
             cmd.Parameters.Add("@StopTs", SqlDbType.DateTime).Value = end;
             cmd.Parameters.Add("@StopType", SqlDbType.Int).Value = 1;
             cmd.Parameters.Add("@Machine_Id", SqlDbType.Int).Value = machine;


             SqlDataReader dr = cmd.ExecuteReader();
             DataTable dt = new DataTable();
             dt.Load(dr);
             if (dt.Rows.Count <= 0) return 0;
             if (dt.Rows[0][0] == DBNull.Value) return 0;
             for (int i = 0; i < dt.Rows.Count; i++)
             {
                 duration += s.getActiveDuration((DateTime)dt.Rows[i]["Start"], (DateTime)dt.Rows[i]["END"]);
             }
             cmd.Dispose();
             cn.Close();
             return duration;
         }

         public double GetUndefinedDuration(int machine, DateTime start, DateTime end, Shift s)
         {
            

          

             double duration = 0;
             SqlConnection cn;
             SqlCommand cmd;

             cn = new SqlConnection(connection);

             cn.Open();
             cmd = new SqlCommand("getUnDefinedStopDuration", cn);
             cmd.CommandType = CommandType.StoredProcedure;

             cmd.Parameters.Add("@StartTs", SqlDbType.DateTime).Value = start;
             cmd.Parameters.Add("@StopTs", SqlDbType.DateTime).Value = end;
             cmd.Parameters.Add("@StopType", SqlDbType.Int).Value = 0;
             cmd.Parameters.Add("@Machine_Id", SqlDbType.Int).Value = machine;


             SqlDataReader dr = cmd.ExecuteReader();
             DataTable dt = new DataTable();
             dt.Load(dr);
             if (dt.Rows.Count <= 0) return 0;
             if (dt.Rows[0][0] == DBNull.Value) return 0;
             for (int i = 0; i < dt.Rows.Count; i++)
             {
                 duration += s.getActiveDuration((DateTime)dt.Rows[i]["Start"], (DateTime)dt.Rows[i]["END"]);
             }
             dr.Close();
             cmd.Dispose();
             cn.Close();
             return duration;
         }

         public double GetOffDuration(int machine, DateTime start, DateTime end, Shift s)
         {
             
             

             double duration = 0;
             SqlConnection cn;
             SqlCommand cmd;

             cn = new SqlConnection(connection);

             cn.Open();
             cmd = new SqlCommand("getOffDuration", cn);
             cmd.CommandType = CommandType.StoredProcedure;

             cmd.Parameters.Add("@StartTs", SqlDbType.DateTime).Value = start;
             cmd.Parameters.Add("@StopTs", SqlDbType.DateTime).Value = end;
             cmd.Parameters.Add("@Machine_Id", SqlDbType.Int).Value = machine;


             SqlDataReader dr = cmd.ExecuteReader();
             DataTable dt = new DataTable();
             dt.Load(dr);
             if (dt.Rows.Count <= 0) return 0;
             if (dt.Rows[0][0] == DBNull.Value) return 0;
             for (int i = 0; i < dt.Rows.Count; i++)
             {
                 duration += s.getActiveDuration((DateTime)dt.Rows[i]["Start"], (DateTime)dt.Rows[i]["END"]);
             }
             cmd.Dispose();
             cn.Close();
             return duration;
         }
#endregion

         #region CODE_COMMENT

         public DataTable GetStopTimes(int Machine_Id, int Shift_Id, String date)
         {
             SqlConnection cn;
             SqlCommand cmd;

             cn = new SqlConnection(connection);
             String query = @"Select Convert(varchar(5),CONVERT(TIME(0),Shifts.Start,0),20) as [From],
                                Convert(varchar(5),CONVERT(TIME(0),Shifts.[End],0),20) as [To]
                                from Shifts
                                where Id={0} 
                                ";


             query = String.Format(query, Shift_Id);

             cn.Open();
             cmd = new SqlCommand(query, cn);

             SqlDataReader dr = cmd.ExecuteReader();
             DataTable dt = new DataTable();
             dt.Load(dr);
             dr.Close();

             DateTime fromTs = DateTime.Parse(date + " " + dt.Rows[0]["From"]);
             DateTime toTs = DateTime.Parse(date + " " + dt.Rows[0]["To"]);

             query = @"Select Timestamp from MachineInputs where Machine_Id = {0}  and Timestamp >= '{1}' and Timestamp < '{2}'
                                 
                                ";
             query = String.Format(query, Machine_Id, fromTs.ToString("yyyy-MM-dd HH:mm:ss"), toTs.ToString("yyyy-MM-dd HH:mm:ss"));

             cmd = new SqlCommand(query, cn);

             dr = cmd.ExecuteReader();
             dt = new DataTable();
             dt.Load(dr);

             if (dt.Rows.Count > 0)
                 dt.Columns.Add("Time Between Pulses[s]", typeof(string));

             DateTime temp = fromTs;
             for (int i = 0; i < dt.Rows.Count; i++)
             {


                 TimeSpan ts = (DateTime)dt.Rows[i]["Timestamp"] - temp;
                 dt.Rows[i]["Time Between Pulses[s]"] = ts.TotalSeconds;

                 temp = (DateTime)dt.Rows[i]["Timestamp"];
             }


             dr.Close();
             cn.Close();
             return dt;
         }

#endregion

         #region SCRAPS

         internal DataTable GetScrapsEntry(int machine, int shift,DateTime from, DateTime to)
         {
             SqlConnection cn;
             SqlCommand cmd;

             cn = new SqlConnection(connection);

             String query = @"select Scraps.SlNo, Convert(nvarchar(10),Scraps.Timestamp,105) as 'Date', Name as 'Project/Model', Scraps
                            from Scraps inner join ProjectTracker on Scraps.ProjectTracker_Id = ProjectTracker.SlNo
                            inner join Projects on Projects.Id = ProjectTracker.Project_Id and SessionActual > 0
                            where Scraps.Machine_Id = {0} and Scraps.Timestamp >= '{1}' and Scraps.Timestamp < '{2}'";

             query = String.Format(query, machine, from.ToString("yyyy-MM-dd HH:mm:ss"), to.ToString("yyyy-MM-dd HH:mm:ss"));

             String filterShift = @"and Scraps.Shift_Id = '{0}'";
             if (shift > 0)
             {
                 query += filterShift;
                 query = String.Format(query, shift);
             }
             
            

             cn.Open();
             cmd = new SqlCommand(query, cn);

             SqlDataReader dr = cmd.ExecuteReader();
             DataTable dt = new DataTable();
             dt.Load(dr);
             dr.Close();
             cn.Close();
             return dt;
         }

         public DataTable GetScrapsReport(int machine, int shift, DateTime from, DateTime to)
         {
             SqlConnection cn;
             SqlCommand cmd;

             cn = new SqlConnection(connection);

             String query = @"select Scraps.SlNo, Convert(nvarchar(10),Scraps.Timestamp,105) as 'Date', SessionActual as Actual, Scraps,
                            round(Convert(float(1),Scraps,0)/Convert(float(1),SessionActual,0)*100,2,1) as Rejection
                            from Scraps inner join ProjectTracker on Scraps.ProjectTracker_Id = ProjectTracker.SlNo
                            inner join Projects on Projects.Id = ProjectTracker.Project_Id and SessionActual > 0
                            where Scraps.Machine_Id = {0} and Scraps.Timestamp >= '{1}' and Scraps.Timestamp < '{2}'";

             query = String.Format(query, machine, from.ToString("yyyy-MM-dd HH:mm:ss"), to.ToString("yyyy-MM-dd HH:mm:ss"));

             String filterShift = @"and Scraps.Shift_Id = '{0}'";
             if (shift > 0)
             {
                 query += filterShift;
                 query = String.Format(query, shift);
             }



             cn.Open();
             cmd = new SqlCommand(query, cn);

             SqlDataReader dr = cmd.ExecuteReader();
             DataTable dt = new DataTable();
             dt.Load(dr);
             //
            
             
             //for (int i = 0; i < dt.Rows.Count;i++ )
             //{

             //}
             dr.Close();
             cn.Close();
             return dt;
         }

         internal void updateScraps(int p1, int p2)
         {
             SqlConnection cn;
             SqlCommand cmd;

             cn = new SqlConnection(connection);
             String query = @" Update Scraps SET Scraps={0} where SlNo={1}";
             query = String.Format(query,p2,p1);
             cn.Open();
             cmd = new SqlCommand(query, cn);

             cmd.ExecuteNonQuery();

             cn.Close();
         }
        #endregion


         #region ACTUAL_STATE
         public int getSessionPlan(Session s, int machine)
         {
             SqlConnection cn;
             SqlCommand cmd;

             DateTime breakStart = DateTime.Parse(s.StartTime);
             DateTime breakEnd = DateTime.Parse(s.EndTime);

             breakStart =
                 new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, breakStart.Hour, breakStart.Minute, breakStart.Second);
             breakEnd =
               new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, breakEnd.Hour, breakEnd.Minute, breakEnd.Second);
             cn = new SqlConnection(connection);
             String query = @" Select Max([Plan]) from [Plan] where timestamp >= '{0}' and timestamp <= '{1}' 
                                and Machine_Id={2}";
             query = String.Format(query, breakStart.ToString("yyyy-MM-dd HH:mm:ss"), breakEnd.ToString("yyyy-MM-dd HH:mm:ss"), machine);

             cn.Open();
             cmd = new SqlCommand(query, cn);

             SqlDataReader dr = cmd.ExecuteReader();
             DataTable dt = new DataTable();
             dt.Load(dr);
             dr.Close();
             cn.Close();

             if (dt.Rows.Count <= 0) return 0;
             if (dt.Rows[0][0] == DBNull.Value) return 0;


             return (int)dt.Rows[0][0];
         }


         public int getSessionActual(Session s, int machine)
         {
             SqlConnection cn;
             SqlCommand cmd;

             DateTime breakStart = DateTime.Parse(s.StartTime);
             DateTime breakEnd = DateTime.Parse(s.EndTime);

             breakStart =
                 new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, breakStart.Hour, breakStart.Minute, breakStart.Second);
             breakEnd =
               new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, breakEnd.Hour, breakEnd.Minute, breakEnd.Second);
             cn = new SqlConnection(connection);
             String query = @" Select Max(Actual) from [Actual] where timestamp >= '{0}' and timestamp <= '{1}' 
                                and Machine_Id={2}";
             query = String.Format(query, breakStart.ToString("yyyy-MM-dd HH:mm:ss"), breakEnd.ToString("yyyy-MM-dd HH:mm:ss"), machine);

             cn.Open();
             cmd = new SqlCommand(query, cn);

             SqlDataReader dr = cmd.ExecuteReader();
             DataTable dt = new DataTable();
             dt.Load(dr);
             dr.Close();
             cn.Close();

             if (dt.Rows.Count <= 0) return 0;
             if (dt.Rows[0][0] == DBNull.Value) return 0;


             return (int)dt.Rows[0][0];
         }


         public Stop getStop(int machine,Shift sh)
         {
             Stop s;

             DateTime shStart = DateTime.Parse(sh.StartTime);
             DateTime shEnd = DateTime.Parse(sh.EndTime);
             shStart =
                new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, shStart.Hour, shStart.Minute, shStart.Second);
             shEnd =
               new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, shEnd.Hour, shEnd.Minute, shEnd.Second);

             SqlConnection con = new SqlConnection(connection);
             con.Open();

             String qry = String.Empty;
             qry = @"select Top(1) * from [Stops] where Machine_Id={0} and[Start] > '{1}' and [End] is null  and Status<>'Speed Loss' order by [Start] asc";
             qry = String.Format(qry, machine,shStart.ToString("yyyy-MM-dd HH:mm:ss"));


             SqlCommand cmd = new SqlCommand(qry, con);
             SqlDataReader dr = cmd.ExecuteReader();
             DataTable dt = new DataTable();
             dt.Load(dr);
             dr.Close();
             cmd.Dispose();
             con.Close();
             if (dt.Rows.Count == 0)
             {
                 s = null;
             }
             else
             {

                 s = new Stop();
                 s.ID = (int)dt.Rows[0]["SlNo"];
                 s.Status = "Open";
                 s.From = (DateTime?)dt.Rows[0]["Start"];
                 s.To = (dt.Rows[0]["End"] == DBNull.Value) ? null : (DateTime?)dt.Rows[0]["End"];
             }



             return s;
         }


         public Stop getOff(int machine)
         {
             Stop s;
             SqlConnection con = new SqlConnection(connection);
             con.Open();

             String qry = String.Empty;
             qry = @"select Top(1) * from [OFFs] where Machine_Id={0} and [Status] = 'OPEN' order by [Start] asc";
             qry = String.Format(qry, machine);


             SqlCommand cmd = new SqlCommand(qry, con);
             SqlDataReader dr = cmd.ExecuteReader();
             DataTable dt = new DataTable();
             dt.Load(dr);
             dr.Close();
             cmd.Dispose();
             con.Close();
             if (dt.Rows.Count == 0)
             {
                 s = null;
             }
             else
             {

                 s = new Stop();
                 s.ID = (int)dt.Rows[0]["SlNo"];
                 s.Status = "Open";
                 s.From = (DateTime?)dt.Rows[0]["Start"];
                 s.To = (dt.Rows[0]["End"] == DBNull.Value) ? null : (DateTime?)dt.Rows[0]["End"];
             }



             return s;
         }
         public bool getOffMachine(int machine)
         {
             
             SqlConnection con = new SqlConnection(connection);
             try
             {
                 
                 String qry = String.Empty;
                 qry = @"select  * from [OFFs] where Machine_Id={0} and [End] is null and status='OPEN' ";
                 qry = String.Format(qry, machine);


                 SqlCommand cmd = new SqlCommand(qry, con);
                 con.Open();
                 //cmd.Connection = con;
                 SqlDataReader dr = cmd.ExecuteReader();
                 DataTable dt = new DataTable();
                 dt.Load(dr);
                 dr.Close();
                 con.Close();
                 if (dt.Rows.Count > 0)
                 {

                     return true;


                 }

                 return false;
             }


             catch (Exception)
             {
                 return false;

             }
         }
#endregion


         internal void UpdateStopInfo(int SlNo,int code, string source, string type, string comment, int machine)
         {
             SqlConnection cn;
             SqlCommand cmd;

             cn = new SqlConnection(connection);
             String query = string.Empty;
             if (type == "STOP")
             {

                 query = @" Update Stops SET code={0} , comment='{2}' where SlNo={1}";
             }
             else if (type == "OFF")
             {
                 query = @" Update OFFs SET code={0} , comment='{2}' where SlNo={1}";
             }

             query = String.Format(query, code, SlNo,comment);
             cn.Open();
             cmd = new SqlCommand(query, cn);

             cmd.ExecuteNonQuery();

             cn.Close();
         }
         #region PROJECT_ASSIGNMENT
         public DataTable CurrentProject(int Machine_Id)
         {
             SqlConnection cn;
             SqlCommand cmd;

             cn = new SqlConnection(connection);
             String query = @"Select Projects.Name+' - ' + Convert(nvarchar,Projects.CycleTime,0) as Project,Projects.Id as Id
             from ProjectMachines join Projects on ProjectMachines.Project_Id=Projects.Id
             where Machine_Id='{0}' AND ProjectMachines.Active='Yes'";
             query = String.Format(query, Machine_Id);

             cn.Open();
             cmd = new SqlCommand(query, cn);

             SqlDataReader dr = cmd.ExecuteReader();
             DataTable dt = new DataTable();
             dt.Load(dr);
             dr.Close();
             cn.Close();
             return dt;
         }
         public DataTable GetNewProjects(int Machine_Id)
         {
             SqlConnection cn;
             SqlCommand cmd;

             cn = new SqlConnection(connection);
             String query = @"Select Projects.Name+' - ' + Convert(nvarchar,Projects.CycleTime,0) as Projects,Projects.Id as Id
             from ProjectMachines join Projects on ProjectMachines.Project_Id=Projects.Id
             where Machine_Id='{0}' AND ProjectMachines.Active='No'";
             query = String.Format(query, Machine_Id);

             cn.Open();
             cmd = new SqlCommand(query, cn);

             SqlDataReader dr = cmd.ExecuteReader();
             DataTable dt = new DataTable();
             dt.Load(dr);
             dr.Close();
             cn.Close();
             return dt;
         }
         public bool SetProject(int Machine_Id, int cur_p_id, int new_p_id)
         {
             SqlConnection cn;
             SqlCommand cmd;
             try
             {
                 cn = new SqlConnection(connection);
                 String query = @" Begin tran
                    update ProjectMachines set Active='No' where Machine_Id = {0} and Project_Id = {1}
                    update ProjectMachines set Active='Yes' where Machine_Id = {0} and Project_Id = {2}
                    commit";
                 query = String.Format(query, Machine_Id, cur_p_id, new_p_id);
                 cn.Open();
                 cmd = new SqlCommand(query, cn);

                 cmd.ExecuteNonQuery();

                 cn.Close();
                 return true;
             }
             catch (Exception)
             {
                 return false;

             }
         }
#endregion
      
        //by ganesh
          ~DataAccess()
         {
             SqlConnection.ClearAllPools();
         }



          internal DataTable GetSession(int machine, int shift)
          {
              SqlConnection cn;
              SqlCommand cmd;

              cn = new SqlConnection(connection);
              String query = @" Select Convert(varchar(5),CONVERT(TIME(0),[Start],0),20)+'-'+Convert(varchar(5),CONVERT(TIME(0),[End],0),20)
                            from 
                            Sessions 
                            where 
                            Shift_Id={1} AND Machine_Id={0}";
              query = String.Format(query, machine, shift);

              cn.Open();
              cmd = new SqlCommand(query, cn);

              SqlDataReader dr = cmd.ExecuteReader();
              DataTable dt = new DataTable();
              dt.Load(dr);
              dr.Close();
              cn.Close();
              return dt;

          }

          public DataTable GetAccumulation(int machine, String from, String to)
          {
              SqlConnection cn;
              SqlCommand cmd;

              cn = new SqlConnection(connection);
              String query = @"
              Select DISTINCT Res.Code As [Code],Res.descp as [Problems],Time_mi.Time_in_Seconds As [Time],Time_mi.[Count] As [Count]
                From
                (Select Code_Desc.[Description] as descp,Stops.Start,Stops.[End],Stops.Code As Code,Stops.Machine_Id
	                From
                        (Select [code],[Description] 
		                From
		                [CommonProblems] 
		                UNION ALL
		                Select [Code],[Description]
		                From
		                [SpecificProblems]) AS Code_Desc
	                INNER JOIN Stops
	                ON
	                Stops.Code=Code_Desc.Code
	                Where Stops.Machine_Id={0}
	                AND 
	                [start] Between '{1}' AND '{2}' 
	                AND 
	                [end] Between '{1}' AND '{2}' ) As Res
	                INNER JOIN 
	                (Select Stops.Code, SUM(DATEDIFF(SECOND,Start,[end])) As [Time_in_Seconds],COUNT(Stops.Code) As [Count] 
	                From
	                Stops
	                Where
	                [start] Between '{1}' AND '{2}' 
	                AND 
	                [end] Between '{1}' AND '{2}'
	                AND 
	                Machine_Id={0}
	                Group BY
	                Stops.Code) As Time_mi
	                ON
	                Time_mi.Code=Res.Code
	                Where
	                Machine_Id={0}";

              query = String.Format(query, machine, from , to);

              cn.Open();
              cmd = new SqlCommand(query, cn);

              SqlDataReader dr = cmd.ExecuteReader();
              DataTable dt = new DataTable();
              dt.Load(dr);
              dt.Columns.Add("Time[%]",typeof(Int32));

              Int32 sum = 0;
              for (int i = 0; i < dt.Rows.Count; i++)
              {
                  sum += Convert.ToInt32(dt.Rows[i]["Time"].ToString());
              }

              for (int i = 0; i < dt.Rows.Count; i++)
              {
                  dt.Rows[i]["Time[%]"] = (Convert.ToInt32(dt.Rows[i]["Time"].ToString()) / sum)*100;
              }


              dr.Close();
              cn.Close();
              return dt;

          }

          public void SetM_Off_Imm(int MId, int parameter, string exeTime, string timestamp,int command)
          {
              SqlConnection cn;
              SqlCommand cmd;

              cn = new SqlConnection(connection);
              String query = @" Insert Into Command(Machine_ID,ID,Parameters,ExecutionTimeStamp,Status,TimeStamp)
                                Values({0},'{4}','{1}','{2}','1','{3}')";
              query = String.Format(query, MId, parameter, exeTime, timestamp, command);
              cn.Open();
              cmd = new SqlCommand(query, cn);

              cmd.ExecuteNonQuery();

              cn.Close();
          }
          public void SetM_Off_Retro(int machine, DateTime from, DateTime to)
          {
              SqlConnection cn;
              SqlCommand cmd;

              cn = new SqlConnection(connection);
              String query = @" Update MachineInputs SET Valid='0'
                            where (Machine_Id={0} and (timestamp>='{1}' and timestamp<='{2}'))";
              query = String.Format(query,machine,from,to );
              cn.Open();
              cmd = new SqlCommand(query, cn);

              cmd.ExecuteNonQuery();

              cn.Close();
          }

          public void SetCM_Off_Retro(int MId, DateTime from, DateTime to)
          {
              SqlConnection cn;
              SqlCommand cmd;

              cn = new SqlConnection(connection);
              String query = @" Update MachineInputs SET Valid='1'
                            where (Machine_Id={0} and (timestamp>='{1}' and timestamp<='{2}'))";
              query = String.Format(query, MId, from, to);
              cn.Open();
              cmd = new SqlCommand(query, cn);

              cmd.ExecuteNonQuery();

              cn.Close();
          }

          public int GetOK(int machine, int shift, int pid, DateTime from, DateTime to)
          {
              SqlConnection cn;
              SqlCommand cmd;

              cn = new SqlConnection(connection);
              String query = @"Select (SUM(ProjectTracker.SessionActual)-SUM(Scraps.Scraps)) as [OK]
                            from ProjectTracker join Scraps on ProjectTracker.SlNo=Scraps.ProjectTracker_Id    
                            where 
                            ProjectTracker.Shift_Id={1} AND ProjectTracker.Machine_Id={0} AND ProjectTracker.Project_Id={2} and 
                            ProjectTracker.[From] >='{3}' AND 
                            ProjectTracker.[From] <=' {4}'";
              query = String.Format(query, machine, shift, pid, from.ToString("yyyy-MM-dd HH:mm:ss"), to.ToString("yyyy-MM-dd HH:mm:ss"));

              cn.Open();
              cmd = new SqlCommand(query, cn);

              SqlDataReader dr = cmd.ExecuteReader();
              DataTable dt = new DataTable();
              dt.Load(dr);
              dr.Close();
              cn.Close();
              for (int i = 0; i < dt.Rows.Count;i++)
              {
                  if (dt.Rows[i]["OK"] ==
                          DBNull.Value)

                      return 0;
                  else
                      break;
              }
              int OK=(int)dt.Rows[0][0];
              return OK;
          }
    }
     
}