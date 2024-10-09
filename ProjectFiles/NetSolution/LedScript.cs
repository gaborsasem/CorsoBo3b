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

public class LedScript : BaseNetLogic
{
    Led mioLed;
    public override void Start()
    {
        // Insert code to be executed when the user-defined logic is started
        Log.Info("sono entrato nella pagina");
        mioLed = (Led)Owner;
        mioLed.Color = Colors.Lime;
        var mioSwitch = Owner.Owner.Get<Switch>("Switch1");
        mioSwitch.CheckedVariable.VariableChange += CheckedVariable_VariableChange;
    }

    private void CheckedVariable_VariableChange(object sender, VariableChangeEventArgs e)
    {
        if (e.NewValue == true)
        {
            mioLed.Color = Colors.Blue;
        }
        else
        {
            mioLed.Color = Colors.Red;
        }
    }

    public override void Stop()
    {
        // Insert code to be executed when the user-defined logic is stopped
        Log.Info("sono uscito dalla pagina");
    }
}
