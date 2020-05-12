using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgePattern
{
    public class ProjectManager : Manager
    {
        public ProjectManager(Project currentProject) : base(currentProject)
        {
        }

        public override void AssignTasks()
        {
            base.CurrentProject.MakPlan();
        }

        public override void ControlProcess()
        {
            base.CurrentProject.ControlProcess();
        }

        public override void SchedulePlan()
        {
            base.CurrentProject.ScheduleTask();
        }

        public override void ManageProject()
        {
            Console.WriteLine("Project Manager:{0}", base.CurrentProject.ProjectName);
            base.ManageProject();
        }
    }
}
