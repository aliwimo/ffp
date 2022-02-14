using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;

namespace ffp
{
    class Program
    {

        static void Main(string[] args)
        {
			string[] operators = { "+", "-", "*", "/" };
			string[] functions = { "sin", "cos", "exp", "rlog" };
			string[] terminals_1V = { "x", "1" };
			string[] terminals_2V = { "x", "y" };

			string target_function 	= "f8";
			Par.pop_size          	= 50;
			Par.max_eval          	= 25000;
			Par.max_gen           	= 1000;
			Par.init_min_depth    	= 0;
			Par.init_max_depth    	= 6;
			Par.max_depth         	= 15;
			Par.max_depth_value		= "1000000";		
			Par.alpha				= 0.1;
			Par.beta				= 0.5;
			Par.gamma				= 1.0;
			Tree.operator_rate 		= 0.5;
			Tree.terminal_rate 		= 0.5;
			Tree.sharing_rate		= 0.9;

			
			Par set_parameters = new Par(target_function);

			if (Par.var_num == 1)
				Tree.terminals = (string[])terminals_1V.Clone();
			else
				Tree.terminals = (string[])terminals_2V.Clone();


			if (!(Par.alpha < Par.beta && Par.beta < Par.gamma))
			{
				Console.WriteLine("Make sure that 'Alpha < Beta < Gamma'");
				Console.WriteLine("Please modify parameters values ...");
                Environment.Exit(0);
			}

			// FP model = new FP();
			DFP model = new DFP();
			model.Run();

        }

    }
}
