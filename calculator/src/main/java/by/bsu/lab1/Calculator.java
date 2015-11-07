package by.bsu.lab1;
import java.util.Scanner;

public class Calculator {

    public double add(double a, double b){
        double result = a+b;
        if (result > Double.MAX_VALUE) {
            throw new RuntimeException("Overflow occured");
        } else if (result < Double.MIN_VALUE) {
            throw new RuntimeException("Underflow occured");
        }
        return result;
    }

    public double subtract(double a, double b){
        double result = a-b;
        if (result > Double.MAX_VALUE) {
            throw new RuntimeException("Overflow occured");
        } else if (result < Double.MIN_VALUE) {
            throw new RuntimeException("Underflow occured");
        }
        return result;
    }

    public double multiply(double a, double b){
        double result = a*b;
        if (result > Double.MAX_VALUE) {
            throw new RuntimeException("Overflow occured");
        } else if (result < Double.MIN_VALUE) {
            throw new RuntimeException("Underflow occured");
        }
        return result;
    }

    public double divide(double a, double b){
        if(b == 0.0)
            return Double.POSITIVE_INFINITY;

        double result = a/b;
        if (result > Double.MAX_VALUE) {
            throw new RuntimeException("Overflow occured");
        } else if (result < Double.MIN_VALUE) {
            throw new RuntimeException("Underflow occured");
        }

        return result;
    }

    public double compute(double firstNumber, double secondNumber, char operation){
        double result = 0.0;
        switch (operation){
            case '+':
                result = add(firstNumber, secondNumber);
                break;
            case '-':
                result = subtract(firstNumber, secondNumber);
                break;
            case '*':
                result = multiply(firstNumber, secondNumber);
                break;
            case '/':
                result = divide(firstNumber, secondNumber);
                break;
            default:
                System.out.print("Wrong key! (use '+', '-', '*', '/') ");
        }
        return result;
    }

    public static void main(String []args){

        Calculator calculator = new Calculator();
        double firstNumber = 0.0, secondNumber = 0.0;
        String operationString;
        boolean flag = true;
        char operation='-';

        Scanner in = new Scanner(System.in);
        while(flag){
            System.out.print("Enter first number:\t");
            firstNumber = in.nextDouble();

            System.out.print("Enter operation:\t");
            operationString = in.next();

            operation = operationString.charAt(0);

            System.out.print("Enter second number:\t");
            secondNumber = in.nextDouble();

            System.out.print(firstNumber + " " + operation + " " +secondNumber + " = " + calculator.compute(firstNumber, secondNumber, operation));

            System.out.print("\n-----Do you want to continue? ('y' or 'n')-----");
            char quit = in.next().charAt(0);
            if(quit == 'n')
                flag = false;
        }
        in.close();
    }
}


