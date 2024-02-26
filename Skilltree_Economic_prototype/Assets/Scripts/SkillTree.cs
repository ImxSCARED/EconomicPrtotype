using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkillTree : MonoBehaviour
{
    public static SkillTree skillTree;
    private void Awake() => skillTree = this;

    public int[] SkillLevels;
    public int[] SkillCaps;
    public string[] SkillNames;
    public string[] SkillDescriptions;
 

    public List<Skill> skillList;
    public GameObject SkillHolder;

    public List<GameObject> ConnectorList;
    public GameObject ConnectorHolder;

    public int SkillPoint;
    public int spRemaining;

    private void Start()
    {
        SkillPoint = spRemaining;

        SkillLevels = new int[6];
        SkillCaps = new[] { 1, 1, 1, 2, 3, 3 };

        SkillNames = new[] { "RUN!", "Hops", "Faster!", "Sprint", "Speedy", "No limits", };
        SkillDescriptions = new[]
        {
            "Increase speed.",
            "Increase jump height",
            "Increases speed more.",
            "Press [LeftShift] to sprint",
            "Sprint faster",
            "dash has no cooldown",
        };
        foreach (var skill in SkillHolder.GetComponentsInChildren<Skill>()) skillList.Add(skill);
        
        foreach (var connector in ConnectorHolder.GetComponentsInChildren<RectTransform>()) ConnectorList.Add(connector.gameObject);

        for (var i = 0; i < skillList.Count; i++) skillList[i].id = i;
 
        skillList[0].ConnectedSkills = new[] { 1, 2, 3};   //what skills are connected  skill 0 is connected to 1,2 and 3
        skillList[2].ConnectedSkills = new[] { 4, 5};   //skill 2 is connected to 4 and 5

        UpdateAllSkillUI();
    }

    public void UpdateAllSkillUI()
    {
        foreach (var skill in skillList) skill.UpdateUI();   //updates UI and skill script
        
    }

    private void Update()
    {
        if (SkillPoint == 0)
        {
            SceneManager.LoadScene((int)SceneIndex.Level2);
        }
    }
}
