using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Unit5_AdapterPatternPatient_Blazor.InsuranceSystem
{
    public interface InsuranceInterface
    {
        // verifies that the patient is currently covered by this policy
        bool IsCovered(string patientName, string policyNumber);

        decimal CoverageAmount(int ProcedureID, decimal ProcedureCost);

        string getPatientName();

        string getPolicyNumber();
    }
}
