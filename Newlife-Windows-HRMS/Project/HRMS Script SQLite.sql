-- Tables for HRMS
 
-- Table: Att_Details
CREATE TABLE Att_Details (
    Att_Id TEXT null,
    Emp_Id TEXT null,
    Date_Time datetime null,
    Status TEXT null,
    Time time null
);
 
-- Table: Dep_Details
CREATE TABLE Dep_Details (
    Dep_Id TEXT null,
    Dep_Name TEXT null,
    Dep_Head TEXT null,
    Dep_Description TEXT null,
    Dep_Status TEXT null
);
 
-- Table: Documents
CREATE TABLE Documents (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    Title TEXT null,
    Description TEXT null,
    Data BLOB null,
    Emp_Id TEXT,
    Exp_Date datetime null,
	FOREIGN KEY (Emp_Id) REFERENCES Emp_Details(Emp_Id)
);
 
-- Table: Emp_Details
CREATE TABLE Emp_Details (
    Emp_Id TEXT PRIMARY KEY,
    Dep_Id TEXT null,
    NIC TEXT null,
    Confirmation TEXT null,
    First_Name TEXT null,
    Last_Name TEXT null,
    Full_Name TEXT null,
    Sex TEXT null,
    M_Sta TEXT null,
    Age TEXT null,
    D_O_Birth datetime null,
    Address TEXT null,
    City TEXT null,
    Country TEXT null,
    Contact TEXT null,
    Basic_sal TEXT null,
    Designation TEXT null,
    Visa_Type TEXT null,
    Visa_Exp datetime null,
    NextOfKin TEXT null,
    Relation TEXT null,
    Allergies TEXT null,
    MedicalCondition TEXT null,
    RegularMedication TEXT null,
    GPContact TEXT null,
    GPAddress TEXT null,
    EmergencyContact TEXT null,
    PassportCountry TEXT null,
    PassportIssue date null,
    PassportExpiry date null,
    Image BLOB null,
    Visa_Issue datetime null
);
 
-- Table: Job_History
CREATE TABLE Job_History (
    JH_id TEXT PRIMARY KEY,
    EID TEXT null,
    Job_title TEXT null,
    Join_Date TEXT null,
    Resign_Date TEXT null
);
 
-- Table: Job_HSDetails
CREATE TABLE Job_HSDetails (
    Jh_ID TEXT null,
    Jh_EmpID TEXT null,
    Jh_Joingdate datetime null,
    jh_Resigndate datetime null,
    jh_Jobtitle TEXT null,
    jh_comment TEXT null
);
 
-- Table: Leave_Details
CREATE TABLE Leave_Details (
    Leave_Id TEXT null,
    Emp_Id TEXT null,
    App_Date datetime null,
    Res_Date datetime null,
    Type TEXT null
);
 
-- Table: Login
CREATE TABLE Login (
    Login_id TEXT PRIMARY KEY,
    Emp_Id TEXT null,
    Username TEXT not null,
    Password TEXT not null
);
 
-- Table: Pay_Details
CREATE TABLE Pay_Details (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Salary_Date date null,
    Hours_Worked REAL null,
    Total_Pay REAL null,
    Income_Tax REAL null,
    NITax REAL null,
    Deductions REAL null,
    Net_Pay REAL null,
    Payslip_Data BLOB null,
    Emp_Id TEXT not null,
	FOREIGN KEY (Emp_Id) REFERENCES Emp_Details(Emp_Id)
);
 
-- Table: Roster
CREATE TABLE Roster (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    _From date null,
    _To date null,
    Description TEXT null,
    Data BLOB null,
    _Month TEXT null,
    Extension TEXT null
);