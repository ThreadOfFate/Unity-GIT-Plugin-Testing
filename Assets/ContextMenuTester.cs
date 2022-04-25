using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContextMenuTester : MonoBehaviour
{
    [ContextMenu("CompareToBranch")]
    public void CompareToBranch()
    {
        CompareBranches branches = new CompareBranches();
        branches.CompareToBranch();
    }
}
