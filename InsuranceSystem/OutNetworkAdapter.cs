using System.Xml.Linq;

namespace Unit5_AdapterPatternPatient_Blazor.InsuranceSystem
{
    public class OutNetworkAdapter : InsuranceInterface
    {
        OutNetworkPatient patient;
        public OutNetworkAdapter(string newName, int newPolicyNumber)
        {
            patient = new OutNetworkPatient(newName, newPolicyNumber);
        }

        public decimal CoverageAmount(int ProcedureID, decimal ProcedureCost)
        {
            decimal coveragePercent = patient.CoveragePercent(ProcedureCost);
            return (coveragePercent * ProcedureCost);
        }

        public string getPatientName()
        {
            return patient.getPatientName();
        }

        public string getPolicyNumber()
        {
            return patient.PolicyNumber.ToString();
        }

        public bool IsCovered(string patientName, string policyNumber)
        {
            bool result = true;
            string covered = patient.IsCovered(patientName, System.Int32.Parse(policyNumber));
            if (covered.Equals("yes")) 
            {
                result = true; 
            }
            else if (covered.Equals("no")) 
            { 
                result = false; 
            }
            return result; 
        }
    }
}
