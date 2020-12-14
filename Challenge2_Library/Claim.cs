using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge2_Library


{
    public enum Type
    {
        Car =1,
        Home, 
        Theft
    }
    public class Claim
    {
        public int ClaimId { get; set; } // Unique ID 
        public Type ClaimType { get; set; }
        public string ClaimDescription { get; set; }
        public double ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public string DateOfIncidentString { get; set; }
        public DateTime DateOfClaim { get; set; }
        public string DateOfClaimString { get; set; }
        public bool ClaimIsValid { get; set; }

        public Claim() { }
        public Claim(int claimId, Type claimType, string claimDescription, double claimAmount, DateTime dateOfIncident, DateTime dateOfClaim, bool claimIsValid)
        {
            ClaimId = claimId;
            ClaimType = claimType;
            ClaimDescription = claimDescription;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
            ClaimIsValid = claimIsValid;
        }
    }
}
