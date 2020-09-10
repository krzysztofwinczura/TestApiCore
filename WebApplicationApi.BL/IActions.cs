namespace WebApplicationApi.BL
{
    public interface IActions
    {
        string Addition(string arg1, string arg2);
        string Addition(string arg1, string[] arg2);
        string Multiplication(string arg1, string arg2);
        string Multiplication(string arg1, string[] arg2);
        string Division(string arg1, string arg2);
        string Division(string arg1, string[] arg2);
        string Subtraction(string arg1, string arg2);
        string Subtraction(string arg1, string[] arg2);
        string CurveInterpolation(string arg1, string arg2);
        string CurveApproximation(string arg1, string arg2);
        object CurveInterpolation(PointXy[] pointXy);
    }
}
