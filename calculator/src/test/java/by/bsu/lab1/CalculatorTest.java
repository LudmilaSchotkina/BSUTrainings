package by.bsu.lab1;
import org.junit.*;

public class CalculatorTest{

    private Calculator calculator= new Calculator();
    private double eps = 1e-15;

    @Test
    public void testAddSuccess() {
        Assert.assertEquals(7, calculator.add(3, 4), eps);
    }

    @Test
    public void testSubstractSuccess() {
        Assert.assertEquals(2, calculator.subtract(5, 3), eps);
    }

    @Test
    public void testMultiplySuccess() {
        Assert.assertEquals(56, calculator.multiply(7, 8), eps);
    }

    @Test
    public void testDivideSuccess() {
        Assert.assertEquals(3, calculator.divide(27, 9), eps);
    }

    @Test
    public void testDivideByZero() {
        Assert.assertEquals(Double.POSITIVE_INFINITY, calculator.divide(27, 0), eps);
    }

    @Test
    public void testCalculate() {
        double expectedResult = 0.0;
        char wrongOperation = '&';
        Assert.assertEquals(expectedResult, calculator.compute(27, 7, wrongOperation), eps);
    }
}
