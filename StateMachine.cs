using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//状態の初期化メソッド、実行メソッド、アクションと遷移先テーブルを登録する
//動詞stringを入力すると別の状態に遷移する

namespace SimpleStateMachine
{
    public class StateMachine
    {
        public string PresentState{ set; get; }
        public Dictionary<string, State> StateTable;

        public StateMachine()
        {
            StateTable = new Dictionary<string, State>();
        }

        //状態を追加する 状態を追加できない場合は-1を返す。
        public int AddState(State newState,string stateName)
        {
            //キーが存在しない場合に登録する
            if (!StateTable.ContainsKey(stateName))
            {
                StateTable[stateName] = newState;
                return 0;
            }
            return -1;
        }

        //状態を実行する。
        public int Execute()
        {
            if(StateTable[PresentState]!= null)
            {
                if(StateTable[PresentState].Process != null)
                {
                    PresentState = StateTable[PresentState].Process(PresentState,null);
                    return 0;
                }
                return -1;//メソッドが登録されていない
            }
            return -2;//状態が登録されていない
        }

        //指定の状態にジャンプする
        public int Jump(string stateName)
        {
            if (StateTable.ContainsKey(stateName))
            {
                PresentState = stateName;
            }
            return 0;
        }
        
        public List<string> GetStateNames()
        {
            List<string> retStateNames = new List<string>(StateTable.Keys);
            return retStateNames;
        }
    }

    public class State
    {
        public Func<string, string, string> Process { get; set; }// Process 現在の状態,イベント文字列, 戻り値：次の状態
    }
}
