using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility
{
    public abstract class BillHandler
    {
        public string UserName { get; set; }

        public List<string> Permissions { get; set; }

        public bool CheckPermission(string permission)
        {
            return Permissions.Contains(permission);
        }

        protected BillHandler Successor { get; set; }

        public void HandleBill(Bill bill)
        {
            if (CheckPermission("SAVE") && bill.Status == BillStatus.Open)
            {
                this.DoBillOperation(bill);
            }
            else
            {
                this.Successor.DoBillOperation(bill);
            }
        }

        public abstract void DoBillOperation(Bill bill);
    }

    public class Purchaser : BillHandler
    {
        private List<string> permissions = new List<string>() { "SAVE" };

        public Purchaser(string username)
        {
            base.UserName = UserName;
            base.Permissions = permissions;
            base.Successor = new Manager("经理--任经理");
        }
       

        public override void DoBillOperation(Bill bill)
        {
            if (CheckPermission("SAVE") && bill.Status == BillStatus.Open)
            {
                bill.Status = BillStatus.Saved;
                Console.WriteLine(string.Format("{0}:{1}已经保存!",this.UserName,bill.BilNo));
            }

            if (CheckPermission("SUBMIT") && bill.Status == BillStatus.Saved)
            {
                bill.Status = BillStatus.Submitted;
                Console.WriteLine(string.Format("{0}:{1}已经提交!", this.UserName, bill.BilNo));
            }

            if (CheckPermission("AUDIT") && bill.Status == BillStatus.Submitted)
            {
                if (bill.Amount <= 5000)
                {
                    bill.Status = BillStatus.Submitted;
                    Console.WriteLine(string.Format("{0}:{1}已经审核！", this.UserName, bill.BilNo));
                }
                else
                {
                    this.Successor.DoBillOperation(bill);
                }
            }
            else
            {
                this.Successor.DoBillOperation(bill);
            }
        }
    }

    public class Manager : BillHandler
    {
        private List<string> permissions = new List<string> { "SAVE", "SUBMIT", "AUDIT" };
        public  Manager(string userName)
        {
            base.UserName = userName;
            base.Permissions = permissions;
            base.Successor = new CEO("CEO");
        }
        public override void DoBillOperation(Bill bill)
        {
            if (CheckPermission("SAVE") && bill.Status == BillStatus.Open)
            {
                bill.Status = BillStatus.Saved;
                Console.WriteLine(string.Format("{0}:{1}已经保存!", this.UserName, bill.BilNo));
            }

            if (CheckPermission("SUBMIT") && bill.Status == BillStatus.Saved)
            {
                bill.Status = BillStatus.Submitted;
                Console.WriteLine(string.Format("{0}:{1}已经提交!", this.UserName, bill.BilNo));
            }

            if (CheckPermission("AUDIT") && bill.Status == BillStatus.Submitted)
            {
                if (bill.Amount <= 20000)
                {
                    bill.Status = BillStatus.Submitted;
                    Console.WriteLine(string.Format("{0}:{1}已经审核！", this.UserName, bill.BilNo));
                }
                else
                {
                    this.Successor.DoBillOperation(bill);
                }
            }
            else
            {
                this.Successor.DoBillOperation(bill);
            }
        }
    }

    public class CEO : BillHandler
    {
        private List<string> permissions = new List<string>() { "SAVE", "SUBMIT", "AUDIT" };
        public CEO(string userName)
        {
            base.UserName = userName;
            base.Permissions = permissions;
        }
        public override void DoBillOperation(Bill bill)
        {
            if (CheckPermission("SAVE") && bill.Status == BillStatus.Open)
            {
                bill.Status = BillStatus.Saved;
                Console.WriteLine(string.Format("{0}:{1}已经保存!", this.UserName, bill.BilNo));
            }

            if (CheckPermission("SUBMIT") && bill.Status == BillStatus.Saved)
            {
                bill.Status = BillStatus.Submitted;
                Console.WriteLine(string.Format("{0}:{1}已经提交!", this.UserName, bill.BilNo));
            }

            if (CheckPermission("AUDIT") && bill.Status == BillStatus.Submitted)
            {
                
                 bill.Status = BillStatus.Submitted;
                 Console.WriteLine(string.Format("{0}:{1}已经审核！", this.UserName, bill.BilNo));
               
            }
        }
    }
}
