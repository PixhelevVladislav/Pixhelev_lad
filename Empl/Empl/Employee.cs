using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empl
{
    class Employee 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        private string firstName;
        private string secondName;
        private string thirdName;
        private bool? sex; 
        //0-woman false
        //1-man true
        private string dateOfBirth;
        private string adress;
        private string email;
        private int mobilecomp;
        private string telNumber;
        private bool? avtoExist;
        public bool?[] drive;// = new bool?[4];
        private bool? driveLic;
        private int exp;
        private string resume;
        private int minSalary;
        private int maxSalary;
       // private int g;


        public bool? this[int i]
        {
            get { return drive[i]; }
            set { drive[i] = value; }
        }
        public string _firstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        public string _secondName
        {
            get { return secondName; }
            set { secondName = value; }
        }
        public string _thirdName
        {
            get { return thirdName; }
            set { thirdName = value; }
        }
        
        public bool? _sex
        {
            get { return sex; }
            set { sex = value; }
        }

        public bool? _driveLic
        {
            get { return driveLic; }
            set { driveLic = value; }
        }

        public string _dateOfBirth
        {
            get { return dateOfBirth; }
            set { dateOfBirth = value; }
        }

        public string _adress
        {
            get { return adress; }
            set { adress = value; }

        }

        public string _email
        {
            get { return email; }
            set { email = value; }
        }



        public int _mobilecomp
        {
            get { return mobilecomp; }
            set { mobilecomp = value; }
        }

        public string _telNumber
        {
            get { return telNumber; }
            set { telNumber = value; }
        }
        public bool? _avtoExist
        {
            get { return avtoExist; }
            set { avtoExist = value; }
        }

        public int _exp
        {
            get { return exp ; }
            set { exp = value; }
        }

        public string _resume
        {
            get { return resume; }
            set { resume = value; }
        }

        public int _minSalary
        {
            get { return minSalary; }
            set { minSalary = value; }
        }

        public int _maxSalary
        {
            get { return maxSalary; }
            set { maxSalary = value; }
        }
        public Employee() { }

        public Employee(string firstName, string secondName, string thirdName, bool? sex, string dateOfBirth, string email)
        {
            this.firstName = firstName;
            this.secondName = secondName;
            this.thirdName = thirdName;
            this.sex = sex; 
            this.dateOfBirth = dateOfBirth;
            this.email = email;
           
        }

        public Employee(string firstName, string secondName, string thirdName, bool? sex, string dateOfBirth, string email, string adress, string telNumber,
                bool? avtoExist, bool?[] drive, string resume,int minSalary, int maxSalary, int mobilecomp,int exp,bool? driveLic):this(firstName,secondName,thirdName,sex,dateOfBirth,email)
        {
            this.adress = adress;
            this.telNumber = telNumber;
            this.avtoExist = avtoExist;
            this.drive = drive;
            this.resume = resume;
            this.minSalary = minSalary;
            this.maxSalary = maxSalary;
            this.mobilecomp = mobilecomp;
            this.exp = exp;
            this.driveLic = driveLic;
            
        }

        public string EmplOut ()
        {
            string s = "";
            s += secondName +" "+firstName;
            return s;
        }
    }
}
