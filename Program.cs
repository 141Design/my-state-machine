using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//ステートマシンってこんな感じ？

namespace SimpleStateMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            StateMachine machine = new StateMachine();
            State s1 = new State();
            State s2 = new State();
            State s3 = new State();
            State st = new State();
            States states = new States();

            s1.Process = states.state1;
            s2.Process = states.state2;
            s3.Process = states.state3;
            machine.AddState(s1, "s1");
            machine.AddState(s2, "s2");
            machine.AddState(s3, "s3");
            machine.AddState(st, "end");
            machine.Jump("s1");
            while (machine.PresentState != "end")
            {
                machine.Execute();
            }   
        }
    }

    //ダミー用のクラス
    public class States
    {

        int count;

        public States()
        {
            count = 0;
        }

        public string state1(string presentState, string eventStr)
        {
            Console.WriteLine("state1 Called");
            if(count >= 5)
            {
                count = 0;
                return "s2";
            }
            count++;
            return presentState;
        }

        public string state2(string presentState, string eventStr)
        {

            Console.WriteLine("state2 Called");
            if (count >= 5)
            {
                count = 0;
                return "s3";
            }
            count++;
            return presentState;
        }

        public string state3(string presentState, string eventStr)
        {
            Console.WriteLine("state3 Called");
            if (count >= 5)
            {
                count = 0;
                return "end";
            }
            count++;
            return presentState;
        }
        public string terminalState(string presentState, string eventStr)
        {
            Console.WriteLine("end");
            return presentState;
        }
    }

}
