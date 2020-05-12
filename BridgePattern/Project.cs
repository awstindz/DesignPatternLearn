using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgePattern
{
    public abstract class Project
    {
        public string ProjectName { get; set; }

        protected Project(string projectName)
        {
            ProjectName = projectName;
        }

        public abstract void AnalyzeRequirement();

        public abstract void DesignProduct();

        public abstract void MakPlan();

        public abstract void ScheduleTask();

        public abstract void ControlProcess();

        public abstract void ReleaseProduct();

        public abstract void MaintainProduct();
    }
}
