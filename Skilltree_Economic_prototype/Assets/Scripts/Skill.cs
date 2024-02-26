using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static SkillTree;
using Unity.VisualScripting;
using UnityEngine.UI;

public class Skill : MonoBehaviour
{
    public int id;
    public TMP_Text TitleText;
    public TMP_Text DescriptionText;

    public int[] ConnectedSkills;

    public void UpdateUI()
    {
        TitleText.text = $"{skillTree.SkillLevels[id]}/{skillTree.SkillCaps[id]}\n{skillTree.SkillNames[id]}";   //the title of the skill
        DescriptionText.text = $"{skillTree.SkillDescriptions[id]}\nCost: {skillTree.SkillPoint}/1 SP";    //display the cost and how many skillpoints is currently available

        GetComponent<Image>().color = skillTree.SkillLevels[id] >= skillTree.SkillCaps[id] ? Color.red                //change the colour based on the level cap   yellow = its maxed, Green = can afford, White = cant afford/NA  
            : skillTree.SkillPoint > 0 ? Color.black : Color.grey;          
        
        foreach (var connectedSkill in ConnectedSkills)
        {
            skillTree.skillList[connectedSkill].gameObject.SetActive(skillTree.SkillLevels[id] > 0);    //make the skills visible or not
            skillTree.ConnectorList[connectedSkill].SetActive(skillTree.SkillLevels[id] > 0);           //make the lines visible or not

        }
    } 

    public void Buy()
    {
        if (skillTree.SkillPoint < 1 || skillTree.SkillLevels[id] >= skillTree.SkillCaps[id]) return;  
        skillTree.SkillPoint -= 1;
        skillTree.SkillLevels[id]++;
        skillTree.UpdateAllSkillUI();

    }
}

