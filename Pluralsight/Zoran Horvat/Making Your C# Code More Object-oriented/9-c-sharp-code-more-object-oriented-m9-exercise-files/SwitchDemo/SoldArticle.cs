﻿using System;
using System.Collections.Generic;
using SwitchDemo.Common;
using SwitchDemo.Common.Interfaces;

namespace SwitchDemo
{
    class SoldArticle
    {

        private IWarranty MoneyBackGuarantee { get; }
        private IWarranty NotOperationalWarranty { get; }
        private IWarranty CircuitryWarranty { get; set; }

        private IOption<Part> Circuitry { get; set; } = Option<Part>.None();

        private DeviceStatus OperationalStatus { get; set; }

        private IReadOnlyDictionary<DeviceStatus, Action<Action>> WarrantyMap { get; }

        public SoldArticle(IWarranty moneyBack, IWarranty express, IWarrantyMapFactory rulesFactory)
        {
            if (moneyBack == null)
                throw new ArgumentNullException(nameof(moneyBack));
            if (express == null)
                throw new ArgumentNullException(nameof(express));

            this.MoneyBackGuarantee = moneyBack;
            this.NotOperationalWarranty = express;
            this.CircuitryWarranty = VoidWarranty.Instance;

            this.OperationalStatus = DeviceStatus.AllFine();

            this.WarrantyMap = rulesFactory.Create(
                this.ClaimMoneyBack, this.ClaimNotOperationalWarranty, this.ClaimCircuitryWarranty);
        }

        private void ClaimMoneyBack(Action action)
        {
            this.MoneyBackGuarantee.Claim(DateTime.Now, action);
        }

        private void ClaimNotOperationalWarranty(Action action)
        {
            this.NotOperationalWarranty.Claim(DateTime.Now, action);
        }

        private void ClaimCircuitryWarranty(Action action)
        {
            this.Circuitry
                .WhenSome()
                .Do(c => this.CircuitryWarranty.Claim(c.DefectDetectedOn, action))
                .Execute();
        }

        public void InstallCircuitry(Part circuitry, IWarranty extendedWarranty)
        {
            this.Circuitry = Option<Part>.Some(circuitry);
            this.CircuitryWarranty = extendedWarranty;
            this.OperationalStatus = this.OperationalStatus.CircuitryReplaced();
        }

        public void CircuitryNotOperational(DateTime detectedOn)
        {
            this.Circuitry
                .WhenSome()
                .Do(c =>
                    {
                        c.MarkDefective(detectedOn);
                        this.OperationalStatus = this.OperationalStatus.CircuitryFailed();
                    })
                .Execute();
        }

        public void VisibleDamage()
        {
            this.OperationalStatus = this.OperationalStatus.WithVisibleDamage();
        }

        public void NotOperational()
        {
            this.OperationalStatus = this.OperationalStatus.NotOperational();
        }

        public void Repaired()
        {
            this.OperationalStatus = this.OperationalStatus.Repaired();
        }

        public void ClaimWarranty(Action onValidClaim)
        {
            this.WarrantyMap[this.OperationalStatus].Invoke(onValidClaim);
        }
    }
}
