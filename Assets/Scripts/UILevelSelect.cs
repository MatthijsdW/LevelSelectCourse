using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class UILevelSelect : MonoBehaviour
{
    private LevelController levelController;
    [SerializeField]
    private UILevel levelUI;
    [SerializeField]
    private LevelPopup levelPopup;
    [SerializeField]
    private int pageSize;

    private Transform levelSelectPanel;
    private int currentPage;
    private List<UILevel> levelList = new List<UILevel>();

    private void Start()
    {
        levelController = GameObject.Find("LevelController").GetComponent<LevelController>();
        levelSelectPanel = transform;

        foreach (Level level in levelController.levels)
        {
            levelList.Add(levelUI);
        }

        BuildLevelPage(0);
    }

    private void BuildLevelPage(int page)
    {
        RemoveItemsFromPage();

        currentPage = page;

        List<UILevel> pageList = levelList.Skip(currentPage * pageSize).Take(pageSize).ToList();

        for (int i = 0; i <pageList.Count; i++)
        {
            Level level = levelController.levels[page * pageSize + i];
            UILevel instance = Instantiate(pageList[i]);
            instance.SetStars(level.Stars);
            instance.transform.SetParent(levelSelectPanel);
            instance.GetComponent<Button>().onClick.AddListener(() => SelectLevel(level));

            if (!level.Locked)
            {
                instance.lockImage.SetActive(false);
                instance.levelIDText.text = level.ID.ToString();
            }
            else
            {
                instance.lockImage.SetActive(true);
                instance.levelIDText.text = "";
            }
        }
    }

    private void RemoveItemsFromPage()
    {
        for (int i = 0; i < levelSelectPanel.childCount; i++)
        {
            Destroy(levelSelectPanel.GetChild(i).gameObject);
        }
    }

    public void NextPage()
    {
        BuildLevelPage(currentPage + 1);
    }

    public void PreviousPage()
    {
        BuildLevelPage(currentPage - 1);
    }

    private void SelectLevel(Level level)
    {
        if (level.Locked)
        {
            levelPopup.gameObject.SetActive(true);
            levelPopup.SetText($"<b>Level {level.ID} is currently locked.</b>\nComplete level {level.ID - 1} to unlock!");
        }
        else
        {
            levelController.StartLevel(level.LevelName);
        }
    }
}
