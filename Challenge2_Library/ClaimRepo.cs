using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge2_Library


{
    public class ClaimRepo
    {
        // FIELD to use in CRUD methods 
        private Queue<Claim> _queuOfClaims = new Queue<Claim>();

        //Functions needed - 1- Create/Add, 2- Read/Show list of claims, 3- Update/Pull Claim from top of Queu

        //CRUD
        //Create(ADD) new Claim
        public void AddClaimToQueue(Claim newClaim)
        {
            _queuOfClaims.Enqueue(newClaim);
        }

        //Read
        //Display the LIST of CLAIMs
        public Queue<Claim> ShowQueueofClaims()
        {
            return _queuOfClaims;
        }

        //Update
        //Update Claim from List - functionality not required

        //Delete
        //Remove Claim from List - functionality not required

        //Helper Methods

        //Get next CLAIM from Queue -- > in console (dequeue or peek)
        
        // Below can be used to give a total of entries in queue since there is not indexing ability for queues:
        // int claimCount= queueOfClaims.ToArray().ToList().IndexOf(claim);





    }
}
