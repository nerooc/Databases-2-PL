using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;


[Serializable]
[Microsoft.SqlServer.Server.SqlUserDefinedAggregate(Format.Native)]
public struct avg{

    public void Init(){
        this.sum = 0;
        this.count = 0;
    }

    public void Accumulate(double Value){
        this.sum += Value;
        this.count++;
    }

    public void Merge(avg Group){
        this.sum += Group.sum;
    }

    public double Terminate(){
        return this.sum / this.count;
    }

    private double sum;
    private int count;

}