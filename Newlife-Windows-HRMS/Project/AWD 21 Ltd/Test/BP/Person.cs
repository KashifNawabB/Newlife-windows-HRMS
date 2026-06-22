using System;
using System.Data;
using System.Configuration;

/// <summary>
/// Summary description for Person
/// </summary>
public class Person
{
    string _empid;
    string _depid;
    string _nic;
    string _firstname;
    string _lastname;
    string _fullname;
    string _sex;
    int _age;
    DateTime _dob;
    string _address;
    string _city;
    string _country;
    string _busnumber;
    string _homenumber;

    string _basic;
    string _mstatus;
    string _confirm;
    string _designation;

    string _visatype;
    DateTime _visaissue;
    DateTime _visaexp;

    string _nextkin;
    string _relation;
    string _allergies;
    string _medicalcondition;
    string _regularmedication;
    string _gpcontact;
    string _gpaddress;
    string _emergencycontact;
    string _passportcountry;
    DateTime _passportissue;
    DateTime _passportexp;
    byte[] _picture;



    public Person()
	{
		//
		// TODO: Add constructor logic here
    	//
	}
    public string EMPID
    {
        get
        {
            return _empid;
        }
        set
        {
            _empid = value;
        }
    }
    public string DEPID
    {
        get
        {
            return _depid;
        }
        set
        {
            _depid = value;
        }
    }
    public string NIC
    {
        get
        {
            return _nic;
        }
        set
        {
            _nic = value;
        }
    }

    public string FIRSTNAME
    {
        get
        {
            return _firstname;
        }
        set
        {
            _firstname = value;
        }
    }
    public string LASTNAME
    {
        get
        {
            return _lastname;
        }
        set
        {
            _lastname = value;
        }
    }

    public string FULLNAME
    {
        get
        {
            return _fullname;
        }
        set
        {
            _fullname = value;
        }

    }
    public string SEX
    {
        get
        {
            return _sex;
        }
        set
        {
            _sex = value;
        }
    }
    public int AGE
    {
        get
        {
            return _age;
        }
        set
        {
            _age = value;
        }
    }
    public DateTime DOB
    {
        get
        {
            return _dob;
        }
        set
        {
            _dob = value;
        }
    }
    public string ADDRESS
    {
        get
        {
            return _address;
        }
        set
        {
            _address = value;
        }
    }
    public string CITY
    {
        get
        {
            return _city;
        }
        set
        {
            _city = value;
        }
    }
    public string COUNTRY
    {
        get
        {
            return _country;
        }
        set
        {
            _country = value;
        }
    }
    public string BUSNUMBER
    {
        get
        {
            return _busnumber;
        }
        set
        {
            _busnumber = value;
        }
    }
    public string HOMENUMBER
    {
        get
        {
            return _homenumber;
        }
        set
        {
            _homenumber = value;
        }
    }

    public string MSTATUS
    {
        get
        {
            return _mstatus;
        }
        set
        {
            _mstatus = value;
        }
    }

    public string BASIC
    {
        get
        {
            return _basic;
        }
        set
        {
            _basic = value;
        }
    }

    public string CONFIRM
    {
        get
        {
            return _confirm;
        }
        set
        {
            _confirm = value;
        }
    }

    public string DESIGNATION
    {
        get
        {
            return _designation;
        }
        set
        {
            _designation = value;
        }
    }

    public string VISATYPE
    {
        get
        {
            return _visatype;
        }
        set
        {
            _visatype = value;
        }
    }

    public DateTime VISAEXP
    {
        get
        {
            return _visaexp;
        }
        set
        {
            _visaexp = value;
        }
    }

    public DateTime VISAISSUE
    {
        get
        {
            return _visaissue;
        }
        set
        {
            _visaissue = value;
        }
    }

    public string Nextkin
    {
        get
        {
            return _nextkin;
        }

        set
        {
            _nextkin = value;
        }
    }

    public string Relation
    {
        get
        {
            return _relation;
        }

        set
        {
            _relation = value;
        }
    }

    public string Allergies
    {
        get
        {
            return _allergies;
        }

        set
        {
            _allergies = value;
        }
    }

    public string Medicalcondition
    {
        get
        {
            return _medicalcondition;
        }

        set
        {
            _medicalcondition = value;
        }
    }

    public string Regularmedication
    {
        get
        {
            return _regularmedication;
        }

        set
        {
            _regularmedication = value;
        }
    }

    public string Gpcontact
    {
        get
        {
            return _gpcontact;
        }

        set
        {
            _gpcontact = value;
        }
    }

    public string Gpaddress
    {
        get
        {
            return _gpaddress;
        }

        set
        {
            _gpaddress = value;
        }
    }

    public string Emergencycontact
    {
        get
        {
            return _emergencycontact;
        }

        set
        {
            _emergencycontact = value;
        }
    }

    public string Passportcountry
    {
        get
        {
            return _passportcountry;
        }

        set
        {
            _passportcountry = value;
        }
    }

    public DateTime Passportissue
    {
        get
        {
            return _passportissue;
        }

        set
        {
            _passportissue = value;
        }
    }

    public DateTime Passportexp
    {
        get
        {
            return _passportexp;
        }

        set
        {
            _passportexp = value;
        }
    }

    public byte[] Picture
    {
        get
        {
            return _picture;
        }

        set
        {
            _picture = value;
        }
    }
}
