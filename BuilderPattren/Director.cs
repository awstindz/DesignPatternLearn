using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattren
{
    public class Director
    {
        public Computer Construct(Builder builder)
        {
            return builder.BuildComputer();
        }
    }

    public abstract class Builder
    {
        protected abstract void BuildMainFramePart();

        protected abstract void BuildScreenPart();

        protected abstract void BuildInputPart();

        public abstract Computer BuildComputer();
    }

    public class HpBuilder : Builder
    {
        Computer hp = new Computer() { Band = "惠普" };
        public override Computer BuildComputer()
        {
            BuildMainFramePart();
            BuildScreenPart();
            BuildInputPart();
            return hp;
        }

        protected override void BuildInputPart()
        {
            hp.AssemblePart("键鼠");
        }

        protected override void BuildMainFramePart()
        {
            hp.AssemblePart("主机");
        }

        protected override void BuildScreenPart()
        {
            hp.AssemblePart("显示器");
        }
    }

    public class DellBuilder : Builder
    {
        Computer dell = new Computer() { Band = "戴尔" };

        public override Computer BuildComputer()
        {
            BuildInputPart();
            BuildMainFramePart();
            BuildScreenPart();
            return dell;
        }

        protected override void BuildInputPart()
        {
            dell.AssemblePart("键鼠");
        }

        protected override void BuildMainFramePart()
        {
            dell.AssemblePart("主机");
        }

        protected override void BuildScreenPart()
        {
            dell.AssemblePart("显示器");
        }
    }

    public class Computer
    {
        public string Band { get; set; }

        private List<string> assemblyParts = new List<string>();

        public void AssemblePart(string partName)
        {
            this.assemblyParts.Add(partName);
        }

        public void ShowSteps()
        {
            Console.WriteLine("开始组装「{0}」电脑:",Band);

            foreach (var part in assemblyParts)
            {
                Console.WriteLine(string.Format("组装「{0}」:", part));
            }

            Console.WriteLine("组装「{0}」电脑完毕!", Band);
        }
    }
}
