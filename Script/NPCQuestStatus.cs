using UnityEngine;

public class NPCQuestStatus : MonoBehaviour
{
    public Camera cam;
    public GameObject questAvailableIcon; // ?˜ìŠ¤?¸ë? ë°›ì„ ???ˆëŠ” ?íƒœ ?„ì´ì½?
    public GameObject questInProgressIcon; // ?˜ìŠ¤??ì§„í–‰ ì¤‘ì¸ ?íƒœ ?„ì´ì½?
    private bool hasQuest; // NPCê°€ ?˜ìŠ¤?¸ë? ê°€ì§€ê³??ˆëŠ”ì§€ ?¬ë?
    private bool questInProgress; // ?„ì¬ ì§„í–‰ ì¤‘ì¸ ?˜ìŠ¤?¸ê? ?ˆëŠ”ì§€ ?¬ë?

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

    // ?˜ìŠ¤?¸ë? ë°›ì„ ???ˆëŠ”ì§€ ?¬ë?ë¥??¤ì •?˜ëŠ” ?¨ìˆ˜
    public void SetQuestAvailability(bool available)
    {
        hasQuest = available;
        UpdateQuestStatusIcons();
    }

    // ?„ì¬ ì§„í–‰ ì¤‘ì¸ ?˜ìŠ¤?¸ê? ?ˆëŠ”ì§€ ?¬ë?ë¥??¤ì •?˜ëŠ” ?¨ìˆ˜
    public void SetQuestInProgress(bool inProgress)
    {
        questInProgress = inProgress;
        UpdateQuestStatusIcons();
    }

    // ?„ì´ì½??íƒœë¥??…ë°?´íŠ¸?˜ëŠ” ?¨ìˆ˜
    private void UpdateQuestStatusIcons()
    {
        questAvailableIcon.SetActive(hasQuest && !questInProgress);
        questInProgressIcon.SetActive(questInProgress);
    }
}
