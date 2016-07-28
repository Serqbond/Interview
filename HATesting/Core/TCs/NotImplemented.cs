using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.TCs
{
    [TestFixture]
    public class NotImplemented : BaseTestCase
    {
        #region CredsEnter
        public void EmptyPasswordHandlesCorrectly() { }
        public void FacebookLoginWorksCorrectly() { }
        public void GoogleLoginWorksCorrectly() { }
        #endregion

        #region Elements exist and work
        #region HeaderElements
        public void HomeButtonWorksCorrectly() { }
        public void LanguageButtonWorksCorrectly() { }
        public void CurrencyButtonWorksCorrectly() { }
        public void RegistrationLinkWorksCorrectly() { }
        public void EnterLinkWorksCorrectly() { }
        public void SetYourPlaceLinkWorksCorrectly() { }
        #endregion

        #region FooterElements
        public void ExploreHomeAwayLinksWorksCorrectly() { }
        public void SocialNetworksWorksCorrectly() { }
        public void AboutUsLinksWorksCorrectly() { }
        //otherGroups
        #endregion
        #endregion

    }
}
