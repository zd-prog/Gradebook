using Gradebook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradebook.ViewModels
{
    class TestTypeViewModel : ViewModelBase
    {
        public TestType TestType;
        public TestTypeViewModel(TestType testType)
        {
            this.TestType = testType;
        }
        public TestType Test_Type
        {
            get { return TestType; }
            set
            {
                TestType = value;
                OnPropertyChanged("Test_Type");
            }
        }
        public ICollection<Test> Tests
        {
            get { return TestType.Tests; }
            set
            {
                TestType.Tests = value;
                OnPropertyChanged("Tests");
            }
        }
    }
}
