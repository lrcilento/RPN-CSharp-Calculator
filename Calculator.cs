using System;
using System.Collections.Generic;

class Calculator
{
    public static string rpn(string equation)
    {
        int aux = 0;
        char token;
        string rpn = "";
        Stack<char> stack = new Stack<char>();
        while (aux < equation.Length)
        {
            token = equation[aux];
            if (token == '0' || token == '1' || token == '2' || token == '3' || token == '4' || token == '5' || token == '6' || token == '7' || token == '8' || token == '9' || token == '.' || token == '.')
            {
                while (aux + 1 < equation.Length && (equation[aux + 1] == '0' || equation[aux + 1] == '1' || equation[aux + 1] == '2' || equation[aux + 1] == '3' || equation[aux + 1] == '4' || equation[aux + 1] == '5' || equation[aux + 1] == '6' || equation[aux + 1] == '7' || equation[aux + 1] == '8' || equation[aux + 1] == '9' || equation[aux + 1] == '.' || equation[aux + 1] == ','))
                {
                    rpn += token;
                    aux++;
                    token = equation[aux];
                }
                rpn += token;
                rpn += ' ';
            }
            else if (token == '(')
            {
                stack.Push(token);
            }
            else if (token == '+' || token == '-')
            {
                while (stack.Count > 0 && (stack.Peek() == '*' || stack.Peek() == '/' || stack.Peek() == '^' || stack.Peek() == '+' || stack.Peek() == '-'))
                {
                    rpn += stack.Pop();
                    rpn += ' ';
                }
                stack.Push(token);
            }
            else if (token == '*' || token == '/')
            {
                while (stack.Count > 0 && (stack.Peek() == '*' || stack.Peek() == '/' || stack.Peek() == '^'))
                {
                    rpn += stack.Pop();
                    rpn += ' ';
                }
                stack.Push(token);
            }
            else if (token == '^')
            {
                while (stack.Count > 0 && stack.Peek() == '^')
                {
                    rpn += stack.Pop();
                    rpn += ' ';
                }
                stack.Push(token);
            }
            else if (token == ')')
            {
                while (stack.Count > 0 && stack.Peek() != '(')
                {
                    rpn += stack.Pop();
                    rpn += ' ';
                }
                if (stack.Peek() == '(')
                {
                    stack.Pop();
                }
            }
            else if (token == '!')
            {
                rpn += token;
                rpn += ' ';

            }
            aux++;
        }
        while (stack.Count > 0)
        {
            rpn += stack.Pop();
            rpn += ' ';
        }
        return rpn;

    }
    public static double calculate(string rpn)
    {
        int aux = 0;
        double w, x, y, z = 0, pow = 0;
        char token;
        bool longnumber = false, dec = false;
        Stack<char> stack = new Stack<char>();
        Stack<char> decimals = new Stack<char>();
        Stack<double> operands = new Stack<double>();
        while (aux < rpn.Length)
        {
            token = rpn[aux];
            if (token == '0' || token == '1' || token == '2' || token == '3' || token == '4' || token == '5' || token == '6' || token == '7' || token == '8' || token == '9' || token == '.' || token == ',')
            {
                while (aux + 1 < rpn.Length && (rpn[aux + 1] == '0' || rpn[aux + 1] == '1' || rpn[aux + 1] == '2' || rpn[aux + 1] == '3' || rpn[aux + 1] == '4' || rpn[aux + 1] == '5' || rpn[aux + 1] == '6' || rpn[aux + 1] == '7' || rpn[aux + 1] == '8' || rpn[aux + 1] == '9' || rpn[aux + 1] == '.' || rpn[aux + 1] == ','))
                {
                    stack.Push(token);
                    aux++;
                    token = rpn[aux];
                    longnumber = true;
                    if (token == '.' || token == ',')
                    {
                        aux++;
                        token = rpn[aux];
                        dec = true;
                        while (aux + 1 < rpn.Length && (rpn[aux + 1] == '0' || rpn[aux + 1] == '1' || rpn[aux + 1] == '2' || rpn[aux + 1] == '3' || rpn[aux + 1] == '4' || rpn[aux + 1] == '5' || rpn[aux + 1] == '6' || rpn[aux + 1] == '7' || rpn[aux + 1] == '8' || rpn[aux + 1] == '9'))
                        {
                            decimals.Push(token);
                            aux++;
                            token = rpn[aux];
                        }
                    }
                }
                if (longnumber)
                {
                    if (dec == true) { decimals.Push(token); };
                    if (dec == false) { stack.Push(token); };
                    while (stack.Count > 0)
                    {

                        w = (double)(stack.Pop() - '0');
                        z += w * Math.Pow(10, pow);
                        pow++;
                    }
                    pow = 1;
                    while (decimals.Count > 0) { stack.Push(decimals.Pop());}
                    while (stack.Count > 0)
                    {
                        w = (double)(stack.Pop() - '0');
                        z += w / Math.Pow(10, pow);
                        pow++; ;
                    }
                    operands.Push(z);
                    pow = 0;
                    z = 0;
                    dec = false;
                    longnumber = false;
                }
                else
                {
                    w = (double)(token - '0');
                    operands.Push(w);
                }
            }
            else if (token == '+' || token == '-' || token == '/' || token == '*' || token == '^')
            {
                y = operands.Pop();
                x = operands.Pop();
                if (token == '+') { x = x + y; }
                else if (token == '-') { x = x - y; }
                else if (token == '/') { x = x / y; }
                else if (token == '*') { x = x * y; }
                else if (token == '^') { x = Math.Pow(x, y); }
                operands.Push(x);
            }
            else if (token == '!')
            {
                operands.Push(factorial((int)operands.Pop()));
            }
            aux++;
        }
        return operands.Pop();
    }
    public static int factorial(int x)
    {
        int r = 1;
        if (x != 0)
        {
            while (x > 0)
            {
                r = r * x;
                x--;
            }
        }
        return r;
    }
}
