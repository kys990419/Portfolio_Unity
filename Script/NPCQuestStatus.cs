using UnityEngine;

public class NPCQuestStatus : MonoBehaviour
{
    public Camera cam;
    public GameObject questAvailableIcon; // ?μ€?Έλ? λ°μ ???λ ?ν ?μ΄μ½?
    public GameObject questInProgressIcon; // ?μ€??μ§ν μ€μΈ ?ν ?μ΄μ½?
    private bool hasQuest; // NPCκ° ?μ€?Έλ? κ°μ§κ³??λμ§ ?¬λ?
    private bool questInProgress; // ?μ¬ μ§ν μ€μΈ ?μ€?Έκ? ?λμ§ ?¬λ?

    private void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        UpdateQuestStatusIcons();
    }
    private void Update()
    {
        Quaternion q_hp = Quaternion.LookRotation(questAvailableIcon.gameObject.transform.position - cam.transform.position);
        Vector3 hp_angle = Quaternion.RotateTowards(questAvailableIcon.gameObject.transform.rotation, q_hp, 200).eulerAngles;
        questAvailableIcon.gameObject.transform.rotation = Quaternion.Euler(0, hp_angle.y, 0);

        Quaternion q_hp2 = Quaternion.LookRotation(questInProgressIcon.gameObject.transform.position - cam.transform.position);
        Vector3 hp_angle2 = Quaternion.RotateTowards(questInProgressIcon.gameObject.transform.rotation, q_hp2, 200).eulerAngles;
        questInProgressIcon.gameObject.transform.rotation = Quaternion.Euler(0, hp_angle2.y, 0);
    }

    // ?μ€?Έλ? λ°μ ???λμ§ ?¬λ?λ₯??€μ ?λ ?¨μ
    public void SetQuestAvailability(bool available)
    {
        hasQuest = available;
        UpdateQuestStatusIcons();
    }

    // ?μ¬ μ§ν μ€μΈ ?μ€?Έκ? ?λμ§ ?¬λ?λ₯??€μ ?λ ?¨μ
    public void SetQuestInProgress(bool inProgress)
    {
        questInProgress = inProgress;
        UpdateQuestStatusIcons();
    }

    // ?μ΄μ½??νλ₯??λ°?΄νΈ?λ ?¨μ
    private void UpdateQuestStatusIcons()
    {
        questAvailableIcon.SetActive(hasQuest && !questInProgress);
        questInProgressIcon.SetActive(questInProgress);
    }
}
