using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class CompareBranches
{
    public void CompareToBranch()
    {
        var path = Application.dataPath;
        while (!path.EndsWith("/"))
        {
            path = path.Remove(path.Length - 1);
        }
        path = path.Remove(path.Length - 1);
        
        var startInfo = new System.Diagnostics.ProcessStartInfo
        {
            WorkingDirectory = path,
            WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal,
            FileName = "cmd.exe",
            Arguments = "",
            RedirectStandardInput = true,
            UseShellExecute = false
        };
    }
}
