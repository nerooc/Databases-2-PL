using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;


[Serializable]
[Microsoft.SqlServer.Server.SqlUserDefinedAggregate(Format.Native)]
public struct countOfThreesDivisibleByThree{
    private SqlInt32 countOfThrees;
    
    public void Init(){
        this.countOfThrees = 0;
    }

    public void Accumulate(SqlInt32 Value){
        if ((Value) > 0 && (Value) % 3 == 0){
            this.countOfThrees += 1;
        }
    }

    public void Merge(countOfThreesDivisibleByThree Group){
        this.countOfThrees += Group.countOfThrees;
    }

    public SqlInt32 Terminate(){
        return ((SqlInt32)this.countOfThrees);
    }
};