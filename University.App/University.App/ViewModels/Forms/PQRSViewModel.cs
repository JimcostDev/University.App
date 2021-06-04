using System;
using System.Collections.Generic;
using System.Text;

namespace University.App.ViewModels.Forms
{
    public class PQRSViewModel : BaseViewModel
    {
        #region Attributes
        public class TypeRequest
        {
            public string Name { get; set; }
        }

        private List<TypeRequest> _typeRequests;
        #endregion

        #region Properties
        public List<TypeRequest> TypeRequests
        {
            get { return this._typeRequests; }
            set { this.SetValue(ref this._typeRequests, value); }
        }
        #endregion

        #region Constructor
        public PQRSViewModel()
        {
            this.LoadTypeRequests();
        }
        #endregion
        #region Methods
        private void LoadTypeRequests()
        {
            this.TypeRequests = new List<TypeRequest>
            {
                new TypeRequest { Name = "Petition" },
                new TypeRequest { Name = "Complain" },
                new TypeRequest { Name = "Claim" },
                new TypeRequest { Name = "Suggestion" }
            };
        }
        #endregion
    }
}
