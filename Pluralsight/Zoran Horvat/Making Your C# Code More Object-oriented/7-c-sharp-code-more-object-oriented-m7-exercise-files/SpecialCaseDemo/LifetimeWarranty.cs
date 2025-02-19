﻿using System;

namespace SpecialCaseDemo
{
    class LifetimeWarranty : IWarranty
    {

        private DateTime IssuingDate { get; }

        public LifetimeWarranty(DateTime issuingDate)
        {
            this.IssuingDate = issuingDate.Date;
        }

        public void Claim(DateTime onDate, Action onValidClaim)
        {
            if (!this.IsValidOn(onDate))
                return;
            onValidClaim();
        }

        private bool IsValidOn(DateTime date) =>
            date.Date >= this.IssuingDate;
    }
}
