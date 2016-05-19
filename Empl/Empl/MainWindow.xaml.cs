using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;

namespace Empl
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Empleycontext context = new Empleycontext();

        public MainWindow()
        {
            InitializeComponent();
            work = context.Employee.ToList();
            foreach (var el in context.Employee)
            {
                list.Items.Add(el.EmplOut());
            }
            
            A.IsEnabled = false;
            B.IsEnabled = false;
            C.IsEnabled = false;
            D.IsEnabled = false;    
        }

        public bool test()
        {
            bool a = true;
            if (NAME.Text == "")
            {
                NAME.BorderBrush = Brushes.Red;
                a = false;
            }
            else
                NAME.BorderBrush = Brushes.White;
            if (SURNAME.Text == "")
            {
                SURNAME.BorderBrush = Brushes.Red;
                a = false;
            }
            else
                SURNAME.BorderBrush = Brushes.White;
            if (THIRDNAME.Text == "")
            {
                THIRDNAME.BorderBrush = Brushes.Red;
                a = false;
            }
            else
                THIRDNAME.BorderBrush = Brushes.White;
            if (e_mail.Text == "")
            {
                e_mail.BorderBrush = Brushes.Red;
                a = false;
            }
            else
                e_mail.BorderBrush = Brushes.White;
            if (calend.Text == "")
            {
                calend.BorderBrush = Brushes.Red;
                a = false;
            }
            else
                calend.BorderBrush = Brushes.White;
            if (!RegexUtilities.IsValidEmail(e_mail.Text))
            {
                e_mail.BorderBrush = Brushes.Red;
                a = false;
            }
            else
                e_mail.BorderBrush = Brushes.White;
            if (Male.IsChecked == false && Female.IsChecked == false)
            {
                s_e_x.BorderBrush = Brushes.Red;
                a = false;
            }
            else
                s_e_x.BorderBrush = Brushes.White;

            return a;
        }

       List<Employee> work = new List<Employee>();
        
        public void outsav(int a)
        {
            SURNAME.Text = work[a]._secondName;
            NAME.Text = work[a]._firstName;
            THIRDNAME.Text = work[a]._thirdName;
            e_mail.Text = work[a]._email;
            if (work[a]._sex == true)
                Male.IsChecked = true;
            else
                Female.IsChecked = true;
            calend.Text = work[a]._dateOfBirth;
            place.Text = work[a]._adress;
            mobcomp.SelectedIndex = work[a]._mobilecomp;
            mobt.Text = work[a]._telNumber;
            EXPOUT(work[a]._exp);
            from.SelectedIndex = work[a]._minSalary;
            to.SelectedIndex = work[a]._maxSalary;
            resume.Text = work[a]._resume;
            car.IsChecked = work[a]._avtoExist;
            lic.IsChecked = work[a]._driveLic;
            ABCDOUT(a);
            
            
        }

        public int EXP()
        {
            int f = 0;
            if (notwork.IsChecked == true)
            {
                f = 1;
            }

            if (less1.IsChecked == true)
            {
                f = 2;
            }

            if (from1to5.IsChecked == true)
            {
                f = 3;
            }

            if (from5to9.IsChecked == true)
            {
                f = 4;
            }

            if (more10.IsChecked == true)
            {
                f = 5;
            }
            return f;
        }

        public void EXPOUT(int a)
        {
            if (a == 1)
                notwork.IsChecked = true;
            else if (a == 2)
                less1.IsChecked = true;
            else if (a == 3)
                from1to5.IsChecked = true;
            else if (a == 4)
                from5to9.IsChecked = true;
            else
                more10.IsChecked = true;

        }

        public void ABCD(bool?[] a)
        {
            if (A.IsEnabled == true)
            {
                a[0] = A.IsChecked;
                a[1] = B.IsChecked;
                a[2] = C.IsChecked;
                a[3] = D.IsChecked;
            }
            if (A.IsEnabled == false)
            {
                for (int i = 0; i < 4; i++)
                {
                    a[i] = null;
                }
            }
            
        }

        public void ABCDOUT(int a)
        {
            if (work[a].drive[0] == false)
            {
                A.IsEnabled = false;
                B.IsEnabled = false;
                C.IsEnabled = false;
                D.IsEnabled = false;
            }
            else
            {
                A.IsChecked=work[a].drive[0];
                B.IsChecked=work[a].drive[1];
                C.IsChecked=work[a].drive[2];
                D.IsChecked=work[a].drive[3];
            }
        }

        private void mobcomp_Loaded(object sender, RoutedEventArgs e)
        {
            string[] mas = new string [3];
            mas[0]="MTS";
            mas[1]="Velcom";
            mas[2]="life:)";
            foreach (string s in mas)
                mobcomp.Items.Add(s);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (test())
            {
                bool?[] r = new bool?[4];
                ABCD(r);
                Employee temp = new Employee(NAME.Text, SURNAME.Text, THIRDNAME.Text, Male.IsChecked, calend.Text, e_mail.Text, place.Text, mobt.Text, car.IsChecked
                    , r, resume.Text, from.SelectedIndex, to.SelectedIndex, mobcomp.SelectedIndex, EXP(),lic.IsChecked);
                //work.Add(temp);
                list.Items.Add(temp.EmplOut());
                
                context.Employee.Add(temp);
                context.SaveChanges();
            }

           // resume.Text =art(A.IsChecked).ToString();      
        }


        public class RegexUtilities
        {
            public static bool IsValidEmail(string strIn)
            {
                // Return true if strIn is in valid e-mail format.
                return Regex.IsMatch(strIn,
                       @"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))" +
                       @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$");
            }
        }

        private void lic_Checked(object sender, RoutedEventArgs e)
        {
                A.IsEnabled = true;
                B.IsEnabled = true;
                C.IsEnabled = true;
                D.IsEnabled = true;
        }

        private void lic_Unchecked(object sender, RoutedEventArgs e)
        {
                A.IsEnabled = false;
                B.IsEnabled = false;
                C.IsEnabled = false;
                D.IsEnabled = false;
                A.IsChecked = false;
                B.IsChecked = false;
                C.IsChecked = false;
                D.IsChecked = false;  
        }

        private void from_Loaded_1(object sender, RoutedEventArgs e)
        {
            for (int i = 100; i <= 1000; i += 100)
            {
                from.Items.Add(i);
            }
        }

        private void to_Loaded_1(object sender, RoutedEventArgs e)
        {
            for (int i = 1500; i <= 5000; i += 500)
            {
                to.Items.Add(i);
            }
        }

        private void list_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            int a = list.SelectedIndex;
            outsav(a);
            
           // NAME.BorderBrush = Brushes.Red;
           // resume.Text = RegexUtilities.IsValidEmail(strIn).ToString();
            
        }

        private void del_Click(object sender, RoutedEventArgs e)
        {
            int a = list.SelectedIndex;

            if (a >= 0)
            {
                work.RemoveAt(a);
                list.Items.RemoveAt(a);
                
            }
        }

        private void clear_Click(object sender, RoutedEventArgs e)
        {
            NAME.Text = "";
            SURNAME.Text = "";
            THIRDNAME.Text = "";
            e_mail.Text = "";
            place.Text = "";
            resume.Text = "";
            calend.Text = "";
            Male.IsChecked = false;
            Female.IsChecked = false;
            from.SelectedIndex = 0;
            to.SelectedIndex = 0;
            mobcomp.SelectedIndex = 0;
            mobt.Text = "";
            notwork.IsChecked = true;
            notwork.IsChecked = false;
            car.IsChecked = false;
            A.IsChecked = false;
            B.IsChecked = false;
            C.IsChecked = false;
            D.IsChecked = false;
            lic.IsChecked = false;



        }

        
    }
}
