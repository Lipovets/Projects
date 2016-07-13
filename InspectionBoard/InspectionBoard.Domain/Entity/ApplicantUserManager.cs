using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using InspectionBoard.Domain.Context;

namespace InspectionBoard.Domain.Entity
{
    public class ApplicantUserManager:UserManager<Applicant>
    {
        public ApplicantUserManager(IUserStore<Applicant> store): base(store)
        {
        }

        public static ApplicantUserManager Create(IdentityFactoryOptions<ApplicantUserManager> options,
                                            IOwinContext context)
        {
            InspectionBoardContext db = context.Get<InspectionBoardContext>();
            ApplicantUserManager manager = new ApplicantUserManager(new UserStore<Applicant>(db));
            return manager;
        }

    }
}
