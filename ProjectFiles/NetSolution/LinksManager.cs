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
using FTOptix.Retentivity;
using FTOptix.CoreBase;
using FTOptix.Core;
using FTOptix.Modbus;
using FTOptix.CommunicationDriver;
using System.Collections.Generic;
using FTOptix.OPCUAServer;
#endregion

public class LinksManager : BaseNetLogic
{
    [ExportMethod]
    public void GetBrokenDynamicLinks()
    {
        var nodesWithBrokenDynamicLink = new List<string>();
        var projectNodes = Project.Current.Parent.FindNodesByType<IUANode>();

        foreach (var n in projectNodes)
        {
            // Check if the current node has a dynamic link
            var dynamicLink = n.Refs.GetVariable(FTOptix.CoreBase.ReferenceTypes.HasDynamicLink);
            if (dynamicLink == null) continue;
            // Retrieve the path of the dynamic link
            var dynamicLinkPath = (string)dynamicLink.Value;
            // Resolve the dynamic link and get to the target node
            var targetVariable = LogicObject.Context.ResolvePath(n, dynamicLinkPath).ResolvedNode;
            if (targetVariable == null)
            {
                nodesWithBrokenDynamicLink.Add("Node BrowsePath: " + Log.Node(n));
            }
        }

        foreach (var info in nodesWithBrokenDynamicLink)
        {
            Log.Info(info);
        }
    }
}
