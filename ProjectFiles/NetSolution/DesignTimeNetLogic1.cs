#region Using directives
using System;
using UAManagedCore;
using OpcUa = UAManagedCore.OpcUa;
using FTOptix.HMIProject;
using FTOptix.NetLogic;
using FTOptix.UI;
using FTOptix.DataLogger;
using FTOptix.NativeUI;
using FTOptix.Recipe;
using FTOptix.SQLiteStore;
using FTOptix.Store;
using FTOptix.OPCUAServer;
using FTOptix.Modbus;
using FTOptix.Retentivity;
using FTOptix.CoreBase;
using FTOptix.CommunicationDriver;
using FTOptix.Core;
using FTOptix.Alarm;
using FTOptix.WebUI;
using FTOptix.SerialPort;
using FTOptix.System;
#endregion

public class DesignTimeNetLogic1 : BaseNetLogic
{
    [ExportMethod]
    public void MioMetodoTest()
    {
        // Insert code to be executed by the method
        Log.Info("mio test");
        var numeroAllarmi = LogicObject.GetVariable("NumeroAllarmi");
        for (int i = 0; i < numeroAllarmi.Value; i++)
        {
            var mioAllarme = InformationModel.Make<DigitalAlarm>("Allarme_" + i);
            Project.Current.Get("Alarms").Add(mioAllarme);  
        }
        
    }

    [ExportMethod]
    public void EliminaAllarmi()
    {
        foreach (var item in Project.Current.Get("Alarms").Children)
        {
            item.Delete();
        }
    }
}
