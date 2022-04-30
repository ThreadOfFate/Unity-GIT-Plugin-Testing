using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Create GitSettings", fileName = "GitSettings", order = 0)]
public class GitSettings : ScriptableObject
{
    public string mainBranch = "";
    public string[] activeBranches = new string[]{};
    public string activeFolder = "";
}
