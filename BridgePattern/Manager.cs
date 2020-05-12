using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgePattern
{
    public abstract class Manager
    {
        protected Project CurrentProject { get; }

        protected Manager(Project currentProject)
        {
            CurrentProject = currentProject;
        }

        public abstract void SchedulePlan();

        public abstract void AssignTasks();

        public abstract void ControlProcess();

        public virtual void ManageProject()
        {
            SchedulePlan();
            AssignTasks();
            ControlProcess();
        }
    }
}
