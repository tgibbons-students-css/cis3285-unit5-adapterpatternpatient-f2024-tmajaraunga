using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Unit5_AdapterPatternPatient_Blazor.InsuranceSystem
{
    public enum PolicyLevels { Silver, Gold, Platinum };

    class InNetworkPatient : InsuranceInterface
    {
        public InNetworkPatient(string newName, string newPolicyNumber, PolicyLevels newLevel)
        {
            Name = newName;
            PolicyNumber = newPolicyNumber;
            PolicyLevel = newLevel;
        }
        public string Name { get; set; }                // patient's full name
        public string PolicyNumber { get; set; }        // policy number for this patient
        private PolicyLevels PolicyLevel { get; set; }         // level of coverage for this patient
        public DateTime Dob { get; set; }               // date of birth
                                                        // required for Insurance Interface
        public decimal CoverageAmount(int ProcedureID, decimal ProcedureCost)
        {
            decimal amt = ProcedureCost * 0.5M;
            if (PolicyLevel == PolicyLevels.Silver)
            {
                switch (ProcedureID)
                {
                    case 0:
                    case 1:
                    case 2:
                        amt = (ProcedureCost * 0.6M);
                        break;
                    case 3:
                    case 4:
                    case 5:
                        amt = (ProcedureCost * 0.75M);
                        break;
                }
            }
            else
            {
                switch (ProcedureID)
                {
                    case 0:
                    case 1:
                    case 2:
                        amt = (ProcedureCost * 0.8M);
                        break;
                    case 3:
                    case 4:
                    case 5:
                        amt = (ProcedureCost * 0.9M);
                        break;
                }
            }
            return amt;
        }

        // required for Insurance Interface
        public bool IsCovered(string patientName, string policyNumber)
        {
            if ((patientName == Name) && (policyNumber == PolicyNumber))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string getPatientName()
        {
            return Name;
        }

        public string getPolicyNumber()
        {
            return PolicyNumber;
        }
    }

}
