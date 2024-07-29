using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public TextAsset dialogData;
    private Sprite charactor;
    public Text nameText;
    public Text dialogText;

    string[] dialogRows;
    private int dialogIndex = 0;
    public List<Sprite> images = new List<Sprite>();
    //charactor image list
    private Dictionary<string, Sprite> imageDic = new Dictionary<string, Sprite>();
    //charactor name -> charactor image

    // Start is called before the first frame update
    void Start()
    {
        Awake();
        ReadText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void UpdateText(string _name, string _text)
    {
        nameText.text = _name;
        dialogText.text = _text;
    }

    private void UpdateImage(string _name)
    {
        charactor = imageDic[_name];
    }

    private void ReadText()
    {
        dialogRows = dialogData.text.Split('\n');
        ShowDialogRow();
        Awake();
    }

    private void Awake()
    {
        //´ò±í
        imageDic["first"] = images[0];
        imageDic["second"] = images[1];
    }

    private void ShowDialogRow()
    {
        foreach (var cell in dialogRows)
        {
            string[] rowArray = cell.Split(',');
            if (rowArray[0] == "#")
            {
                continue;
            }
            else if (rowArray[0] == dialogIndex.ToString())
            {
                dialogIndex = int.Parse(rowArray[3]);
                UpdateText(rowArray[1], rowArray[2]);
                Debug.Log(rowArray[1] + " " + rowArray[2]);
                UpdateImage(rowArray[1]);
                break;
            }
        }
    }

    public void Onclick()
    {
        ShowDialogRow();
    }
}
