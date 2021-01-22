﻿using System;
using System.Collections.Generic;
using System.Text;

using DIPatterns.CommerceRepoDI_Interface.Interfaces;
using DIPatterns.DAO;

namespace DIPatterns.CommerceRepoDI_Interface
{
    class Commerce
    {
        IBillingProcessor billingProcessor;
        ICustomerProcessor customerProcessor;
        INotifier notifier;

        public Commerce()
        {

        }
        public Commerce(IBillingProcessor billingProcessor, ICustomerProcessor customerProcessor, INotifier notifier)
        {
            this.billingProcessor = billingProcessor;
            this.customerProcessor = customerProcessor;
            this.notifier = notifier;
        }

        public void ProcessOrder(Order order)
        {
            billingProcessor.ProcessPayment(order.CreditCard, order.CustomerName);
            customerProcessor.UpdateCustomerOrder(order.CustomerName, order.Product);
            notifier.SendReceipt(order.Product);
        }
    }
}
