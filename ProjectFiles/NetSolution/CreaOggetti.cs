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

public class CreaOggetti : BaseNetLogic
{
    public override void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            var mioOggetto = InformationModel.Make<DisplayUnitaMisura>("mioOggetto" + i);
            Owner.Add(mioOggetto);
        }
        // Insert code to be executed when the user-defined logic is started
        
    }

    public override void Stop()
    {
        // Insert code to be executed when the user-defined logic is stopped
    }
}
