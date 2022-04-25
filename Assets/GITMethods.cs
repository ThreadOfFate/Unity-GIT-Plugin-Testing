using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class GITMethods
{
    public GITMethods()
    {
        SetPath();
    }

    private string _path;
    private void SetPath()
    {
        var path = Application.dataPath;
        while (!path.EndsWith("/"))
        {
            path = path.Remove(path.Length - 1);
        }
        _path = path.Remove(path.Length - 1);
    }
    
    public string[] GetAllRemoteBranches()
    {
        var startInfo = new ProcessStartInfo
        {
            WorkingDirectory = _path,
            WindowStyle = ProcessWindowStyle.Normal,
            FileName = "git.exe",
            Arguments = "branch -r",
            UseShellExecute = false,
            RedirectStandardOutput = true
        };
        
        Process process = new Process();
        process.StartInfo = startInfo;
        process.Start();
        
        string output = process.StandardOutput.ReadToEnd();
        output = output.Replace(" ", "");
        output = output.Substring(0, output.Length - 2);
        output = output.Replace("\n", Environment.NewLine);
        
        string[] branches = output.Split(
            new string[] { Environment.NewLine },
            StringSplitOptions.None
        );
        return branches;
    }
    
    public string[] GetAllFilesChanges(string baseBranch,string[] otherBranches)
    {
        List<string> allFiles = new List<string>();
        foreach (var currentBranch in otherBranches)
        {
            var startInfo = new System.Diagnostics.ProcessStartInfo
            {
                WorkingDirectory = _path,
                WindowStyle = ProcessWindowStyle.Normal,
                FileName = "git.exe",
                Arguments = "diff --name-only " + baseBranch + " " + currentBranch,
                UseShellExecute = false,
                RedirectStandardOutput = true
            };

            Process process = new Process();
            process.StartInfo = startInfo;
            process.Start();

            string output = process.StandardOutput.ReadToEnd();
            if (output.Length == 0)
            {
                continue;
            }
            output = output.Replace(" ", "");
            output = output.Substring(0, output.Length - 2);
            output = output.Replace("\n", Environment.NewLine);

            string[] files = output.Split(
                new string[] {Environment.NewLine},
                StringSplitOptions.None
            );
            allFiles.AddRange(files);
        }
        return allFiles.Distinct().ToArray();
    }
}
