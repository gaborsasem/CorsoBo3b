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

public class OpenPopupDaScript : BaseNetLogic
{
    IUAVariable miaVarPLC;
    private RemoteVariableSynchronizer variableSynchronizer;
    public override void Start()
    {
        // Insert code to be executed when the user-defined logic is started
        miaVarPLC = Project.Current.GetVariable("CommDrivers/ModbusDriver1/ModbusStation1/Tags/ModbusTag1");
        variableSynchronizer = new RemoteVariableSynchronizer();
        variableSynchronizer.Add(miaVarPLC);
        miaVarPLC.VariableChange += MiaVarPLC_VariableChange;
    }

    private void MiaVarPLC_VariableChange(object sender, VariableChangeEventArgs e)
    {
        if (e.NewValue)
            UICommands.OpenDialog(Owner, Project.Current.Get<DialogType>("UI/MyWidget/PopUp"));
    }

    public override void Stop()
    {
        // Insert code to be executed when the user-defined logic is stopped
        miaVarPLC.VariableChange -= MiaVarPLC_VariableChange;
    }
}
