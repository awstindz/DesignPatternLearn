using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgePattern
{
    public class ProductManager : Manager
    {
        public ProductManager(Project currentProject) : base(currentProject)
        {
        }

        public override void SchedulePlan()
        {
            base.CurrentProject.ScheduleTask();
        }

        public override void AssignTasks()
        {
            base.CurrentProject.MakPlan();
        }

        public override void ControlProcess()
        {
            base.CurrentProject.ControlProcess();
        }

        public void AnalyseRequirement()
        {
            base.CurrentProject.AnalyzeRequirement();
        }

        public void DesignProduct()
        {
            base.CurrentProject.DesignProduct();
        }

        public override void ManageProject()
        {
            Console.WriteLine("produceManager:{0}", base.CurrentProject.ProjectName);
            AnalyseRequirement();
            DesignProduct();

            base.ManageProject();
        }
    }
}
