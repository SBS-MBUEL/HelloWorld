using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld.eAccounting_API
{
    public class MachineLearningDto
    {
        public MachineLearningDto()
        {
            this.Inputs = new Inputs();
        }

        public Inputs Inputs { get; set; }
        public dynamic GlobalParameters {
            get
            {
                return new { };
            }
        }
    }

    public class Inputs
    {
        public Inputs()
        {
            this.input1 = new input1();
        }

        public input1 input1 { get; set; }
    }

    public class input1
    {
        public List<string> ColumnNames { get; set; }
        public List<List<string>> Values { get; set; }
    }
}
