using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;

[Serializable]
[Microsoft.SqlServer.Server.SqlUserDefinedType(Format.Native)]
public struct ComplexNumber : INullable{
    private double _x; //real part
    private double _y; //imaginary part
    
    public bool IsNull{
        get { return m_Null; }
    }
    
    public static ComplexNumber Null{
        get{
            ComplexNumber h = new ComplexNumber();
            h.m_Null = true; return h;
        }
    }
    
    public ComplexNumber(double x, double y){
        _x = x;
        _y = y;
        m_Null = false;
    }
    
    public ComplexNumber(bool nothing){
        this._x = this._y = 0;
        this.m_Null = true;
    }
    
    public double RealPart{
        get { return _x; }
        set { _x = value; }
    }
    
    public double ImaginaryPart{
        get { return _y; }
        set { _y = value; }
    }

    // NOWE METODY /////////////////////////////////////

    // Liczba zespolona sprzężona    
    public ComplexNumber ComplexConjugate(){
        // Tworzymy nową liczbę zespoloną
        ComplexNumber cn = new ComplexNumber();

        // Zapisujemy te same wartości co w orginalnej
        // lecz podmieniamy część zespoloną na ujemną
        cn.m_Null = m_Null;
        cn._x = _x;
        cn._y = -_y;

        // Zwracamy otrzymaną liczbę zespoloną
        return cn;
    }
    
    // Moduł z liczby zespolonej
    public double ComplexAbsolute(){
        // Zwracamy moduł wg. wzoru
        return Math.Sqrt(_x*_x+_y*_y);
    }

    ////////////////////////////////////////////////////

    public override string ToString(){
        string sign = _y > 0 ? "+" : "";
        return _x.ToString() + sign + _y.ToString() + "i";
    }

    public static ComplexNumber Parse(SqlString s){
        string value = s.Value;
        if (s.IsNull || value.Trim() == "")
        return Null;
        string xstr = value.Substring(0, value.IndexOf('+'));
        string ystr = value.Substring(value.IndexOf('+') + 1,
        value.Length - xstr.Length - 2);
        double xx = double.Parse(xstr);
        double yy = double.Parse(ystr);
        return new ComplexNumber(xx, yy);
    }
    
    // Dodawanie liczb zespolonych
    public static ComplexNumber Add(ComplexNumber c1, ComplexNumber c2){
        return new ComplexNumber(c1._x + c2._x, c1._y + c2._y);
    }
    
    // Private member
    private bool m_Null;
}


















// Original \/
/*
[Serializable]
[Microsoft.SqlServer.Server.SqlUserDefinedType(Format.Native)]
public struct Type1 : INullable
{
    public override string ToString()
    {
        // Replace the following code with your code
        return "";
    }
    public bool IsNull
    {
        get
        {
            // Put your code here
            return m_Null;
        }
    }
    
    public static Type1 Null
    {
        get
        {
            Type1 h = new Type1();
            h.m_Null = true;
            return h;
        }
    }
    public static Type1 Parse(SqlString s)
    {
        if (s.IsNull)
            return Null;
        Type1 u = new Type1();
        // Put your code here
        return u;
    }
    // This is a place-holder method
    public string Method1()
    {
        //Insert method code here
        return "Hello";
    }
    // This is a place-holder static method
    public static SqlString Method2()
    {
        //Insert method code here
        return new SqlString("Hello");
    }
    // This is a place-holder field member
    public int var1;
    // Private member
    private bool m_Null;
}
*/
© 2021 GitHub, Inc.