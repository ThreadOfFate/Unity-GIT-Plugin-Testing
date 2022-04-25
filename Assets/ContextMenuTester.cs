using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ContextMenuTester : MonoBehaviour
{
    [ContextMenu("CompareToBranch")]
    public void CompareToBranch()
    {
        GITMethods GITMethods = new GITMethods();
        var branches = GITMethods.GetAllRemoteBranches();
        foreach (var branch in branches)
        {
            Debug.Log(branch);
        }

        var files = GITMethods.GetAllFilesChanges(branches.First(), branches);
        foreach (var file in files)
        {
            Debug.Log(file);
        }
    }
}
