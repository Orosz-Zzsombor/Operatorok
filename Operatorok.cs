using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    internal class Operatorok
    {
        int operandusA;
        string muvelet;
        int operndusB;

        public Operatorok(string CSVsor)
        {
            var mezo = CSVsor.Split(' ');
            this.operandusA = int.Parse(mezo[0]);
            this.muvelet = mezo[1];
            this.operndusB = int.Parse(mezo[2]);
        }
        public Operatorok(int operandusA, string muvelet, int operndusB)
        {
            this.operandusA = operandusA;
            this.muvelet = muvelet;
            this.operndusB = operndusB;
        }
    
        
        
            
        
        public int OperandusA { get => operandusA; set => operandusA = value; }
        public string Muvelet { get => muvelet; set => muvelet = value; }
        public int OperndusB { get => operndusB; set => operndusB = value; }


        
    }

}
