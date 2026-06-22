using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



class Payment
{
    int _id;
    DateTime _salary_date;
    float _hours_worked;
    float _total_pay;
    float _income_tax;
    float _ni_tax;
    float _deductions;
    float _net_pay;
    byte[] _payslip_data;
    string _emp_id;


    public int ID
    {
        get { return _id; }
        set { _id = value; }
    }

    public DateTime SALARY_DATE
    {
        get { return _salary_date; }
        set { _salary_date = value; }
    }

    public float HOURS_WORKED
    {
        get { return _hours_worked; }
        set { _hours_worked = value; }
    }

    public float TOTAL_PAY
    {
        get { return _total_pay; }
        set { _total_pay = value; }
    }

    public float INCOME_TAX
    {
        get { return _income_tax; }
        set { _income_tax = value; }
    }

    public float NI_TAX
    {
        get { return _ni_tax; }
        set { _ni_tax = value; }
    }

    public float DEDUCTIONS
    {
        get { return _deductions; }
        set { _deductions = value; }
    }

    public float NET_PAY
    {
        get { return _net_pay; }
        set { _net_pay = value; }
    }

    public byte[] PAYSLIP_DATA
    {
        get { return _payslip_data; }
        set { _payslip_data = value; }
    }

    public string EMP_ID
    {
        get { return _emp_id; }
        set { _emp_id = value; }
    }
}

