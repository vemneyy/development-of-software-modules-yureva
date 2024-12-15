using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_3_individual_mvp
{
    public interface IView
    {
        string NumeratorA { get; set; }
        string DenominatorA { get; set; }
        string NumeratorB { get; set; }
        string DenominatorB { get; set; }
        string Result { get; set; }

        event EventHandler AddFractions;
        event EventHandler SubtractFractions;
        event EventHandler MultiplyFractions;
        event EventHandler DivideFractions;
    }

}
