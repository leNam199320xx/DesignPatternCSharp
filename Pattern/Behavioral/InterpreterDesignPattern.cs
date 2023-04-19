﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Pattern.Behavioral
{
    internal class InterpreterDesignPattern
    {
        public class Context
        {
            public string expression { get; set; }
            public DateTime date { get; set; }
            public Context(DateTime date)
            {
                this.date = date;
            }
        }

        public interface AbstractExpression
        {
            void Evaluate(Context context);
        }

        public class DayExpression : AbstractExpression
        {
            public void Evaluate(Context context)
            {
                string expression = context.expression;
                context.expression = expression.Replace("DD", context.date.Day.ToString());
            }
        }

        public class MonthExpression : AbstractExpression
        {
            public void Evaluate(Context context)
            {
                string expression = context.expression;
                context.expression = expression.Replace("MM", context.date.Month.ToString());
            }
        }

        public class YearExpression : AbstractExpression
        {
            public void Evaluate(Context context)
            {
                string expression = context.expression;
                context.expression = expression.Replace("YYYY", context.date.Year.ToString());
            }
        }

        public class SeparatorExpression : AbstractExpression
        {
            public void Evaluate(Context context)
            {
                string expression = context.expression;
                context.expression = expression.Replace(" ", "-");
            }
        }
    }
}
