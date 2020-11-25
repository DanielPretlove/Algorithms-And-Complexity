using System;
using System.Collections.Generic;
using System.Text;

namespace CAB301_Assignment
{
    class MemberCollection
    {
        
        public Member[] members { get; set; }


        public MemberCollection()
        {
            members = new Member[10];
        }

        // registering a new member
        public void Register_Member(Member newMember)
        {
            int count = 0;

            while(members[count] != null)
            {
                count++;
            }
            
            if (count < members.Length)
            {
                members[count] = newMember;
            }

            else
            {
                Console.WriteLine("Member list is full, so you cannot register");
            }
        }


        // finding if a member exist in the array and checks who is logged in
        public Member Find_Member(string LastNameFirstName)
        {
            for (int i = 0; i < members.Length; i++)
            {
                if (members[i] != null)
                {
                    if(String.Concat(members[i].LastName,members[i].FirstName) == LastNameFirstName)
                    {
                        
                        return members[i];
                    }
                }
            }

            throw new Exception($"member {LastNameFirstName} not found");
        }

    }
}
