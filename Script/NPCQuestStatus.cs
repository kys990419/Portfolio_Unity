using UnityEngine;

public class NPCQuestStatus : MonoBehaviour
{
    public Camera cam;
    public GameObject questAvailableIcon; // ?�스?��? 받을 ???�는 ?�태 ?�이�?
    public GameObject questInProgressIcon; // ?�스??진행 중인 ?�태 ?�이�?
    private bool hasQuest; // NPC가 ?�스?��? 가지�??�는지 ?��?
    private bool questInProgress; // ?�재 진행 중인 ?�스?��? ?�는지 ?��?

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

    // ?�스?��? 받을 ???�는지 ?��?�??�정?�는 ?�수
    public void SetQuestAvailability(bool available)
    {
        hasQuest = available;
        UpdateQuestStatusIcons();
    }

    // ?�재 진행 중인 ?�스?��? ?�는지 ?��?�??�정?�는 ?�수
    public void SetQuestInProgress(bool inProgress)
    {
        questInProgress = inProgress;
        UpdateQuestStatusIcons();
    }

    // ?�이�??�태�??�데?�트?�는 ?�수
    private void UpdateQuestStatusIcons()
    {
        questAvailableIcon.SetActive(hasQuest && !questInProgress);
        questInProgressIcon.SetActive(questInProgress);
    }
}
