using System;
using System.Linq;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private GameObject currentGroup;

    System.Random random = new System.Random();

    private string[] MACRO_GROUPS = { "Skull", "Body", "LeftArm", "RightArm", "LeftLeg", "RightLeg" };    // Five macro groups of bones: Skull, Body, LeftArm, RightArm, LeftLeg, RightLeg
    private string[] SUB_GROUPS = { "Vertebra", "Rib", "LeftHand", "RightHand", "LeftFoot", "RightFoot" };    // Five macro groups of bones: Skull, Body, LeftArm, RightArm, LeftLeg, RightLeg
    [SerializeField] private GameObject[] prefabGroups;
    [SerializeField] private RectTransform displayPoint;
    [SerializeField] private Camera camera;

    public TextMeshProUGUI[] answers;

    public event EventHandler OnStateChanged;
    public event EventHandler OnBoneChanged;
    public event EventHandler OnGameOver;

    private enum State
    {
        WaitingToStart,
        CountdownToStart,
        GamePlaying,
        GameOver
    }

    private State state;
    private float waitingToStartTimer = 1f;
    private float countdownToStartTimer = 3f;
    private float gameTime = 0f;

    private int MAX_ANSWERS = 15;
    private int answered = 0;

    private int correctAnswers = 0;

    private String currentBoneStr = "";

    public bool OnAnswerClick(String answer)
    {
        if (answer == currentBoneStr)
        {
            correctAnswers += 1;
        }
        answered += 1;
        Debug.Log(answer);
        Invoke("NextBone", 0.5f);
        return answer == currentBoneStr;
    }

    void Awake()
    {
        Instance = this;
        state = State.WaitingToStart;
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case State.WaitingToStart:
                waitingToStartTimer -= Time.deltaTime;
                if (waitingToStartTimer < 0f)
                {
                    state = State.CountdownToStart;
                    OnStateChanged?.Invoke(this, EventArgs.Empty);
                }
                break;
            case State.CountdownToStart:
                countdownToStartTimer -= Time.deltaTime;
                if (countdownToStartTimer < 0f)
                {
                    state = State.GamePlaying;
                    NextBone();
                    OnStateChanged?.Invoke(this, EventArgs.Empty);
                }
                break;
            case State.GamePlaying:
                gameTime += Time.deltaTime;
                break;
            case State.GameOver:
                currentGroup.SetActive(false);
                gameObject.SetActive(false);
                OnGameOver?.Invoke(this, EventArgs.Empty);
                break;
        }
    }

    private (int, GameObject) getRandomBoneIndexGroup()
    {
        // pick one of the five macrogroups
        int groupIndex = random.Next(0, prefabGroups.Length);

        if (prefabGroups[groupIndex] != null)
        {
            GameObject group = prefabGroups[groupIndex];
            Debug.Log(group.name);

            // pick a bone or a subgroup of bones inside the macrogroup 
            int boneIndex = random.Next(0, group.transform.childCount);
            GameObject bone = group.transform.GetChild(boneIndex).gameObject;
            Debug.Log(bone.name);

            // if is a subgroup, we must pick again another bone inside the subgroup
            if (SUB_GROUPS.Contains(bone.name))
            {
                group = bone;
                boneIndex = random.Next(0, group.transform.childCount);
                bone = group.transform.GetChild(boneIndex).gameObject;
                Debug.Log(bone.name);
            }

            return (boneIndex, group);
        }

        return (0, null);
    }

    private Boolean AnswerAlreadyExists(String name)
    {
        for (int i = 0; i < answers.Length; i++)
        {
            if(answers[i].text == name)
            {
                return true;
            }
        }
        return false;
    }

    public bool NextBone()
    {
        if (answered == MAX_ANSWERS)
        {
            state = State.GameOver;
            OnStateChanged?.Invoke(this, EventArgs.Empty);
            return false;
        }
        camera.fieldOfView = 90;
        displayPoint.localRotation = UnityEngine.Quaternion.Euler(0, 0, 0);

        if (currentGroup != null)
        {
            Destroy(currentGroup);
        }

        int layerUI = LayerMask.NameToLayer("UI");

        // generate random bone
        var res = getRandomBoneIndexGroup();
        GameObject group = res.Item2;
        int boneIndex = res.Item1;

        // instantiate the group
        currentGroup = Instantiate(group, displayPoint.position, UnityEngine.Quaternion.identity);

        //Rotate on display point should work
        currentGroup.transform.SetParent(displayPoint);

        //check which group it is to fix x,y,z relative to parent
        string groupName = group.name;
        switch (groupName)
        {
            case "RightArm":
                currentGroup.transform.localPosition = new UnityEngine.Vector3(96, -34, -4);
                break;
            case "RightLeg":
                currentGroup.transform.localPosition = new UnityEngine.Vector3(78, 78, -12);
                break;
            case "LeftLeg":
                currentGroup.transform.localPosition = new UnityEngine.Vector3(45, 77, -14);
                break;
            case "Body":
                currentGroup.transform.localPosition = new UnityEngine.Vector3(11, 4, 61);
                break;
            case "Vertebra":
                currentGroup.transform.localPosition = new UnityEngine.Vector3(13, 3, -10);
                break;
            case "Skull":
                currentGroup.transform.localPosition = new UnityEngine.Vector3(9, -80, 143);
                currentGroup.transform.Rotate(new UnityEngine.Vector3(0, 180, 0));
                break;
            case "RightHand":
                currentGroup.transform.localPosition = new UnityEngine.Vector3(98, 3, 3);
                currentGroup.transform.Rotate(new UnityEngine.Vector3(-180, -1, 3));
                break;
            case "LeftArm":
                currentGroup.transform.localPosition = new UnityEngine.Vector3(-20, 103, 5);
                break;
            case "LeftFoot":
                currentGroup.transform.localPosition = new UnityEngine.Vector3(1, 57, -134);
                currentGroup.transform.Rotate(new UnityEngine.Vector3(64, -113, 70));
                break;
            case "LeftHand":
                currentGroup.transform.localPosition = new UnityEngine.Vector3(-6, -110, 36);
                currentGroup.transform.Rotate(new UnityEngine.Vector3(156, -2, -10));
                break;
            case "RightFoot":
                currentGroup.transform.localPosition = new UnityEngine.Vector3(-42, -38, -135);
                currentGroup.transform.Rotate(new UnityEngine.Vector3(59, 65, -116));
                break;
            case "Rib":
                currentGroup.transform.localPosition = new UnityEngine.Vector3(10, -15, 71);
                break;
        }

        // outline bone
        GameObject currentBone = currentGroup.transform.GetChild(boneIndex).gameObject;
        var outline = currentBone.AddComponent<Outline>();
        outline.OutlineMode = Outline.Mode.OutlineAll;
        outline.OutlineColor = Color.yellow;
        outline.OutlineWidth = 5f;

        // Set UI layer
        currentGroup.layer = layerUI;
        foreach (Transform child in currentGroup.GetComponentsInChildren<Transform>(true))
        {
            child.gameObject.layer = layerUI;
        }

        //sort randomically answers array
        answers = answers.OrderBy(x => UnityEngine.Random.value).ToArray();
        string[] currentBoneNameSplitted = currentBone.name.Split('_');
        answers[0].text = currentBoneStr = currentBoneNameSplitted[currentBoneNameSplitted.Length - 1];

        // generate 3 answers
        int i = 1;
        while(i < 4)
        {
            var randomBone = getRandomBoneIndexGroup();
            int randomBoneIndex = randomBone.Item1;
            GameObject randomBoneObj = randomBone.Item2;
            String[] splitted = randomBoneObj.transform.GetChild(randomBoneIndex).gameObject.name.Split('_');
            String name = splitted[splitted.Length - 1];
            
            // Check if already present
            if(!AnswerAlreadyExists(name))
            {
                answers[i].text = name;
                i++;
            }
        }

        OnBoneChanged?.Invoke(this, EventArgs.Empty);

        return true;
    }

    public bool IsGameRunning()
    {
        return state == State.GamePlaying;
    }

    public bool IsCountDownRunning()
    {
        return state == State.CountdownToStart;
    }

    public float GetCountdownTimer()
    {
        return countdownToStartTimer;
    }

    public float GetGameTime()
    {
        return gameTime;
    }

    public int GetCurrentQuestionIndex()
    {
        return answered + 1;
    }

    public int GetTotalQuestions()
    {
        return MAX_ANSWERS;
    }

    public int GetCorrectAnswersCount()
    {
        return correctAnswers;
    }

    public bool isGameOver()
    {
        return state == State.GameOver;
    }
}

