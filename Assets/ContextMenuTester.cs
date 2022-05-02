using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ContextMenuTester : MonoBehaviour
{
    [ContextMenu("CompareToBranch")]
    public void CompareToBranch()
    {
        var branches = GITMethods.GetAllActiveBranches();
        foreach (var branch in branches)
        {
            Debug.Log(branch);
        }
        var files = GITMethods.GetAllFilesChanges();
        foreach (var file in files)
        {
            Debug.Log(file);
        }
    }
}
