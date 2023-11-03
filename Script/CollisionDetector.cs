using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking.Types;

public class CollisionDetector : MonoBehaviour
{
    public GameObject infoBack;
    public Text infoTxt;

    public QuestAcceptButton questAccept;
    public QuestCompleteButton questComplete;
    public GameObject OnBtn;
    public GameObject OffBtn;

    bool first;
    bool first2;
    public GameObject number1;
    public Text questUITxt;
    public GameObject questUIBack;
    private int CanInteration = 0;
    public GameObject DialogUI;
    public int isNPCQ;
    public PlayerMove playerMove;
    private NpcIdGiver npcIdGiver;
    private bool isCollisionHandled;
    public bool onlyOneTime;
    private int spaceBarCount;
    public GameObject questUI;
    public GameObject dialogUI;
    public GameObject questAcceptButton;
    public GameObject questCompleteButton;
    public QuestClearList questClearList;
    //public GameObject questAcceptUI;
    //public GameObject questProgressUI;

    public int[] Array = {0,2,4,5,5,6,6,6,8,5,5,5,2,5,22,21,21,22,23,22,22,21,22,22,36,36,37,39,40,36,36,37,36,47,36,37,36,36};

    private JsonQuestLoader jsonQuestLoader;
    string[] info = new string[40];
    private KeyCode interactKey = KeyCode.G;

    /*
    public string[] info = new string[]
    {
        "<color=yellow>" + "[����Ʈ]: "+ "</color>" + "�Ͼ �Ƶ�!" + "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" +  "���� �丶�� �翡 ���� �丶�並 5�� ��Ȯ����"+ "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" + "100 ���" + "\n",

        "<color=yellow>" + "[����Ʈ]: "+ "</color>" + "��δ��� ȣ��" + "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" +  "������ ��δ��� ã�ư� ��ȭ�ϱ�"+ "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" + "100 ���" + "\n",

        "<color=yellow>" + "[����Ʈ]: "+ "</color>" + "�뺴�繫�Ұ� �������?" + "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" +  "�뺴�繫���� �뺴������ ã�ư� ��ȭ�ϱ�"+ "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" + "100 ���" + "\n",

        "<color=yellow>" + "[����Ʈ]: "+ "</color>" + "�Ƿ� �׽�Ʈ" + "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" +  "���� ���� ��� ���� 5������ óġ����"+ "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" + "100 ���" + "\n" + "\n" +
                          "<color=red>" + "1�� ���� ����Ʈ" + "</color>" + "\n",

        "<color=yellow>" + "[����Ʈ]: "+ "</color>" + "�ϰ� �� �̹��� ���� �����̳�?" + "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" +  "�뺴�δ����� ���� ��ȭ ����"+ "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" + "ü�� ���� 10��, ���� ���� 10��" + "\n",

        "<color=yellow>" + "[����Ʈ]: "+ "</color>" + "�����ް� ������ ������ ������" + "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" +  "���� ���� ��� �ü��� ����ǰ 10���� �����ؿ���"+ "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" + "100 ���" + "\n",

        "<color=yellow>" + "[����Ʈ]: "+ "</color>" + "�ʷϻ� ������ ���� ���� ���� ���?" + "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" +  "���� �� �ʷ��������� �����ϰ� ����"+ "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" + "100 ���" + "\n",

        "<color=yellow>" + "[����Ʈ]: "+ "</color>" + "������ ��������?" + "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" +  "�ʷ������� ��ó �������ڵ��� ã�ƺ���"+ "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" + "100 ���" + "\n",

        "<color=yellow>" + "[����Ʈ]: "+ "</color>" + "��� �ൿ���� ��� ����" + "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" +  "���� �ϵ��ʿ� �ִ� ��� �ֵ����� ���� ��� �ൿ������ óġ�ϰ� ����ǰ�� ��������"+ "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" + "500 ���" + "\n",

        "<color=yellow>" + "[����Ʈ]: "+ "</color>" + "���׶� ������ ��ȭ 1" + "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" +  "�뺴������� ���� �Ⱥθ� ����"+ "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" + "ü������ 10��, �������� 10��" + "\n",

        "<color=yellow>" + "[����Ʈ]: "+ "</color>" + "���׶� ������ ��ȭ 2" + "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" +  "���� �������� ��� �� �ֵ����� �� ������ ��� ���� óġ�ϰ� ����ǰ�� ��������"+ "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" + "1000 ���" + "\n" +
                          "<color=red>" + "2�� ���� ����Ʈ" + "\n",

        "<color=yellow>" + "[����Ʈ]: "+ "</color>" + "�ۺ��λ�" + "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" +  "������ ���� �ۺ��λ縦 ������"+ "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" + "100 ���" + "\n",

        "<color=yellow>" + "[����Ʈ]: "+ "</color>" + "��ȸ�� �� �Ƹ��׹̽���!" + "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" +  "�뺴������� ������ ���� �׸��� �Ƹ��׹̽��� ����"+ "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" + "300���" + "\n",

        "<color=yellow>" + "[����Ʈ]: "+ "</color>" + "�Ƹ��׹̽��� �뺴������ ã�ư���" + "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" +  "�Ƹ��׹̽��� �뺴�繫�Ҹ� ã�ư� �뺴������ ������"+ "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" + "200 ���" + "\n",

        "<color=yellow>" + "[����Ʈ]: "+ "</color>" + "�����̾� ��δ�" + "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" +  "�Ƹ��׹̽� ������ ��θ� ���� �λ縦 �帮�� ����"+ "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" + "200 ���" + "\n",

        "<color=yellow>" + "[����Ʈ]: "+ "</color>" + "��Ʈ ���� �� ã��" + "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" +  "����� ��Ʈ�� ������ ���� ã������"+ "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" + "200 ���" + "\n",

        "<color=yellow>" + "[����Ʈ]: "+ "</color>" + "�ذ����� ���" + "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" +  "�Ƹ��׹̽� �뺴�繫�ҿ� �ͼ� ó�� �ӹ��ٿ� �ӹ��� �޾Ҵ�. ���� �� ���͸� 10���� óġ����"+ "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" + "200 ���" + "\n",

        "<color=yellow>" + "[����Ʈ]: "+ "</color>" + "�ذ�ü� ���" + "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" +  "�ذ�ü��� óġ�ϰ� ����ǰ�� ��������"+ "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" + "200 ���" + "\n",

        "<color=yellow>" + "[����Ʈ]: "+ "</color>" + "�� ���� �Ƹ��׹̽��� ���Ͽ�" + "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" +  "�Ƹ��׹̽� ����� ��� �ذ��簡 �ֵ��� ������� ���� �� �ʸӷ� �� �� ����. �뺴������ ��Ź�� �����Ͽ� �ذ��縦 óġ����"+ "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" + "400 ���" + "\n",

        "<color=yellow>" + "[����Ʈ]: "+ "</color>" + "�߰ſ��� �칰 ��" + "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" +  "�칰 ���� ���� �߰ſ� ���� �ִ�. �߿����� �����غ���"+ "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" + "400 ���" + "\n",

        "<color=yellow>" + "[����Ʈ]: "+ "</color>" + "���� ���� ���� ������ ����" + "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" +  "���� ��� ������ ���� ���ʰ� �ִٰ��Ѵ�. �װ��� ã�ƿ���"+ "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" + "400 ���" + "\n",

        "<color=yellow>" + "[����Ʈ]: "+ "</color>" + "�Ƹ��׹̽��� ��ȭ�� ����" + "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" +  "�뺴������� �ϼ������� óġ�Ͽ� �� ������ ��ȭ�� ���Ѵ޶�� ��Ź�Ѵ�."+ "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" + "2000 ���" + "\n" +
                          "<color=red>" + "3�� ���� ����Ʈ" + "\n",

        "<color=yellow>" + "[����Ʈ]: "+ "</color>" + "������ ���� ���ؼ�" + "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" +  "�뺴����� ��ȭ�ϰ� �Ƹ���Ÿ������ �� �غ� ����"+ "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" + "600 ���" + "\n",

        "<color=yellow>" + "[����Ʈ]: "+ "</color>" + "��ο� ��� �Ƹ���Ÿ��" + "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" +  "�Ƹ���Ÿ�ο� �����ߴ�. ��ٷ� �뺴������ ã�ư���"+ "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" + "600 ���" + "\n",

        "<color=yellow>" + "[����Ʈ]: "+ "</color>" + "�ٸ� �뺴�ܿ����� ��� �ֳ���?" + "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" +  "���׶�, �Ƹ��׹̽� �뺴�繫�ҿ� ���� �ʶ��� ���̴� �Ƹ���Ÿ�� �뺴�繫��. ���� ���� �־����ɱ�? �뺴���忡�� �����"+ "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" + "600 ���" + "\n",

        "<color=yellow>" + "[����Ʈ]: "+ "</color>" + "���� - �뺴�δ���" + "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" +  "����� �뺴�ܿ����� �ٽ� ������ ���� ������ �߷� �ٱ� �����ߴ�. ���� �뺴�δ����� ã�ư���"+ "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" + "600 ���" + "\n",

        "<color=yellow>" + "[����Ʈ]: "+ "</color>" + "���� - �뺴�ܿ� 1" + "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" +  "������ �뺴�ܿ� 1�� ã�ư���"+ "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" + "600 ���" + "\n",

        "<color=yellow>" + "[����Ʈ]: "+ "</color>" + "���� - �뺴�ܿ� 2" + "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" +  "���������� �뺴�ܿ� 2�� ã�ư���"+ "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" + "600 ���" + "\n",

        "<color=yellow>" + "[����Ʈ]: "+ "</color>" + "�������� ����" + "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" +  "�Ƹ���Ÿ�� ������ ������� ���� �ַ� ���� ������ �Ѵ�. �������� �� �ѷ�����"+ "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" + "800 ���" + "\n",

        "<color=yellow>" + "[����Ʈ]: "+ "</color>" + "������ �����ϴ� ������" + "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" +  "�뺴������� ������ �����ϴ� �������� óġ�϶�� ����� �̴ּ�. �������縦 10���� óġ����"+ "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" + "800 ���" + "\n",

        "<color=yellow>" + "[����Ʈ]: "+ "</color>" + "������ �����ϴ� ������ 2" + "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" +  "���������� ����ǰ�� 10�� �����ذ���"+ "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" + "800 ���" + "\n",

        "<color=yellow>" + "[����Ʈ]: "+ "</color>" + "���ʱ��� Ž��" + "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" +  "���� �� �ϵ��ʿ� �뺴�� ���ʱ����� �ִ�. ���ʱ����� ���¸� �ѷ����� ����"+ "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" + "600 ���" + "\n",

        "<color=yellow>" + "[����Ʈ]: "+ "</color>" + "Ȧ�� ��� ����" + "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" +  "��δԿ��� ���� �� �ƹ����� �ִµ� �ƹ����� ���� �� �� ������ Ȧ�� ����Ŵ�. �ƹ����� �� ����� Ȯ���ϰ� ����"+ "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" + "600 ���" + "\n",

        "<color=yellow>" + "[����Ʈ]: "+ "</color>" + "�Ƹ���Ÿ���� �� ���� - 1" + "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" +  "�Ƹ���Ÿ���� �ӳ��� ������ �ִ� ��Ʋ���ּ��縦 óġ�ϰ� ����ǰ�� ��������"+ "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" + "��� 2000" + "\n",

        "<color=yellow>" + "[����Ʈ]: "+ "</color>" + "�Ƹ���Ÿ���� �� ���� - 2" + "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" +  "�Ƹ���Ÿ���� �ӳ��� ������ �ִ� ��Ʋ����Ÿ� óġ�ϰ� ����ǰ�� ��������"+ "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" + "��� 2000" + "\n",

        "<color=yellow>" + "[����Ʈ]: "+ "</color>" + "����" + "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" +  "�� ������ óġ�ϰ� ���ƿ��� �뺴������� ���� ���� �ҷ���. ���ο� ��ų�� �������ֱ� ���ؼ�"+ "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" + "��� 800" + "\n" +
                          "<color=red>" + "���� ��ų ȹ��" + "\n",

        "<color=yellow>" + "[����Ʈ]: "+ "</color>" + "�⳪�� ������ ��ħǥ" + "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" +  "�Ƹ���Ÿ�� �߽ɺο� �ִ� ���������� ������������ óġ����"+ "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" + "��� 10000, �����̾� �ձ��� ���� Īȣ" + "\n" +
                          "<color=blue>" + "���� Ŭ����" + "\n"
    };
    */

    public void Start()
    {
        info[0] = "<color=yellow>" + "[����Ʈ]: " + "</color>" + "�Ͼ �Ƶ�!" + "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" + "���� �丶�� �翡 ���� �丶�並 5�� ��Ȯ����" + "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" + "100 ���" + "\n";

        info[1] = "<color=yellow>" + "[����Ʈ]: " + "</color>" + "��δ��� ȣ��" + "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" + "������ ��δ��� ã�ư� ��ȭ�ϱ�" + "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" + "100 ���" + "\n";
;
        info[2] = "<color=yellow>" + "[����Ʈ]: " + "</color>" + "�뺴�繫�Ұ� �������?" + "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" + "�뺴�繫���� �뺴������ ã�ư� ��ȭ�ϱ�" + "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" + "100 ���" + "\n";

        info[3] = "<color=yellow>" + "[����Ʈ]: " + "</color>" + "�Ƿ� �׽�Ʈ" + "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" + "���� ���� ��� ���� 5������ óġ����" + "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" + "100 ���" + "\n" + "\n" +
                          "<color=red>" + "1�� ���� ����Ʈ" + "</color>" + "\n";

        info[4] = "<color=yellow>" + "[����Ʈ]: " + "</color>" + "�ϰ� �� �̹��� ���� �����̳�?" + "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" + "�뺴�δ����� ���� ��ȭ ����" + "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" + "ü�� ���� 10��, ���� ���� 10��" + "\n";

        info[5] = "<color=yellow>" + "[����Ʈ]: " + "</color>" + "�����ް� ������ ������ ������" + "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" + "���� ���� ��� �ü��� ����ǰ 10���� �����ؿ���" + "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" + "100 ���" + "\n";

        info[6] = "<color=yellow>" + "[����Ʈ]: " + "</color>" + "�ʷϻ� ������ ���� ���� ���� ���?" + "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" + "���� �� �ʷ��������� �����ϰ� ����" + "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" + "100 ���" + "\n";

        info[7] = "<color=yellow>" + "[����Ʈ]: " + "</color>" + "������ ��������?" + "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" + "�ʷ������� ��ó �������ڵ��� ã�ƺ���" + "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" + "100 ���" + "\n";

        info[8] = "<color=yellow>" + "[����Ʈ]: " + "</color>" + "��� �ൿ���� ��� ����" + "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" + "���� �ϵ��ʿ� �ִ� ��� �ֵ����� ���� ��� �ൿ������ óġ�ϰ� ����ǰ�� ��������" + "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" + "500 ���" + "\n";

        info[9] = "<color=yellow>" + "[����Ʈ]: " + "</color>" + "���׶� ������ ��ȭ 1" + "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" + "�뺴������� ���� �Ⱥθ� ����" + "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" + "ü������ 10��, �������� 10��" + "\n";

        info[10] = "<color=yellow>" + "[����Ʈ]: " + "</color>" + "���׶� ������ ��ȭ 2" + "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" + "���� �������� ��� �� �ֵ����� �� ������ ��� ���� óġ�ϰ� ����ǰ�� ��������" + "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" + "1000 ���" + "\n" +
                          "<color=red>" + "2�� ���� ����Ʈ" + "\n";

        info[11] = "<color=yellow>" + "[����Ʈ]: " + "</color>" + "�ۺ��λ�" + "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" + "������ ���� �ۺ��λ縦 ������" + "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" + "100 ���" + "\n";

        info[12] = "<color=yellow>" + "[����Ʈ]: " + "</color>" + "��ȸ�� �� �Ƹ��׹̽���!" + "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" + "�뺴������� ������ ���� �׸��� �Ƹ��׹̽��� ����" + "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" + "300���" + "\n" +
                          "<color=green>" + "���׶� ������ ����Ʈ" + "</color>" + "\n";

        info[13] = "<color=yellow>" + "[����Ʈ]: " + "</color>" + "�Ƹ��׹̽��� �뺴������ ã�ư���" + "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" + "�Ƹ��׹̽��� �뺴�繫�Ҹ� ã�ư� �뺴������ ������" + "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" + "200 ���" + "\n";

        info[14] = "<color=yellow>" + "[����Ʈ]: " + "</color>" + "�����̾� ��δ�" + "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" + "�Ƹ��׹̽� ������ ��θ� ���� �λ縦 �帮�� ����" + "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" + "200 ���" + "\n";

        info[15] = "<color=yellow>" + "[����Ʈ]: " + "</color>" + "��Ʈ ���� �� ã��" + "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" + "����� ��Ʈ�� ������ ���� ã������" + "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" + "200 ���" + "\n";

        info[16] = "<color=yellow>" + "[����Ʈ]: " + "</color>" + "�ذ����� ���" + "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" + "�Ƹ��׹̽� �뺴�繫�ҿ� �ͼ� ó�� �ӹ��ٿ� �ӹ��� �޾Ҵ�. ���� �� ���͸� 10���� óġ����" + "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" + "200 ���" + "\n";

        info[17] = "<color=yellow>" + "[����Ʈ]: " + "</color>" + "�ذ�ü� ���" + "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" + "�ذ�ü��� óġ�ϰ� ����ǰ�� ��������" + "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" + "200 ���" + "\n";

        info[18] = "<color=yellow>" + "[����Ʈ]: " + "</color>" + "�� ���� �Ƹ��׹̽��� ���Ͽ�" + "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" + "�Ƹ��׹̽� ����� ��� �ذ��簡 �ֵ��� ������� ���� �� �ʸӷ� �� �� ����. �뺴������ ��Ź�� �����Ͽ� �ذ��縦 óġ����" + "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" + "400 ���" + "\n";

        info[19] = "<color=yellow>" + "[����Ʈ]: " + "</color>" + "�߰ſ��� �칰 ��" + "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" + "�칰 ���� ���� �߰ſ� ���� �ִ�. �߿����� �����غ���" + "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" + "400 ���" + "\n";

        info[20] = "<color=yellow>" + "[����Ʈ]: " + "</color>" + "���� ���� ���� ������ ����" + "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" + "���� ��� ������ ���� ���ʰ� �ִٰ��Ѵ�. �װ��� ã�ƿ���" + "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" + "400 ���" + "\n";

        info[21] = "<color=yellow>" + "[����Ʈ]: " + "</color>" + "�Ƹ��׹̽��� ��ȭ�� ����" + "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" + "�뺴������� �ϼ������� óġ�Ͽ� �� ������ ��ȭ�� ���Ѵ޶�� ��Ź�Ѵ�." + "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" + "2000 ���" + "\n" +
                          "<color=red>" + "3�� ���� ����Ʈ" + "\n";

        info[22] = "<color=yellow>" + "[����Ʈ]: " + "</color>" + "������ ���� ���ؼ�" + "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" + "�뺴����� ��ȭ�ϰ� �Ƹ���Ÿ������ �� �غ� ����" + "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" + "600 ���" + "\n" +
                          "<color=green>" + "�Ƹ��׹̽� ������ ����Ʈ" + "\n";

        info[23] = "<color=yellow>" + "[����Ʈ]: " + "</color>" + "��ο� ��� �Ƹ���Ÿ��" + "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" + "�Ƹ���Ÿ�ο� �����ߴ�. ��ٷ� �뺴������ ã�ư���" + "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" + "600 ���" + "\n";

        info[24] = "<color=yellow>" + "[����Ʈ]: " + "</color>" + "�ٸ� �뺴�ܿ����� ��� �ֳ���?" + "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" + "���׶�, �Ƹ��׹̽� �뺴�繫�ҿ� ���� �ʶ��� ���̴� �Ƹ���Ÿ�� �뺴�繫��. ���� ���� �־����ɱ�? �뺴���忡�� �����" + "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" + "600 ���" + "\n";

        info[25] = "<color=yellow>" + "[����Ʈ]: " + "</color>" + "���� - �뺴�δ���" + "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" + "����� �뺴�ܿ����� �ٽ� ������ ���� ������ �߷� �ٱ� �����ߴ�. ���� �뺴�δ����� ã�ư���" + "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" + "600 ���" + "\n";

        info[26] = "<color=yellow>" + "[����Ʈ]: " + "</color>" + "���� - �뺴�ܿ� 1" + "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" + "������ �뺴�ܿ� 1�� ã�ư���" + "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" + "600 ���" + "\n";

        info[27] = "<color=yellow>" + "[����Ʈ]: " + "</color>" + "���� - �뺴�ܿ� 2" + "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" + "���������� �뺴�ܿ� 2�� ã�ư���" + "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" + "600 ���" + "\n";

        info[28] = "<color=yellow>" + "[����Ʈ]: " + "</color>" + "�������� ����" + "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" + "�Ƹ���Ÿ�� ������ ������� ���� �ַ� ���� ������ �Ѵ�. �������� �� �ѷ�����" + "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" + "800 ���" + "\n";

        info[29] = "<color=yellow>" + "[����Ʈ]: " + "</color>" + "������ �����ϴ� ������" + "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" + "�뺴������� ������ �����ϴ� �������� óġ�϶�� ����� �̴ּ�. �������縦 10���� óġ����" + "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" + "800 ���" + "\n";

        info[30] = "<color=yellow>" + "[����Ʈ]: " + "</color>" + "������ �����ϴ� ������ 2" + "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" + "���������� ����ǰ�� 10�� �����ذ���" + "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" + "800 ���" + "\n";

        info[31] = "<color=yellow>" + "[����Ʈ]: " + "</color>" + "���ʱ��� Ž��" + "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" + "���� �� �ϵ��ʿ� �뺴�� ���ʱ����� �ִ�. ���ʱ����� ���¸� �ѷ����� ����" + "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" + "600 ���" + "\n";

        info[32] = "<color=yellow>" + "[����Ʈ]: " + "</color>" + "Ȧ�� ��� ����" + "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" + "��δԿ��� ���� �� �ƹ����� �ִµ� �ƹ����� ���� �� �� ������ Ȧ�� ����Ŵ�. �ƹ����� �� ����� Ȯ���ϰ� ����" + "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" + "600 ���" + "\n";

        info[33] = "<color=yellow>" + "[����Ʈ]: " + "</color>" + "�Ƹ���Ÿ���� �� ���� - 1" + "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" + "�Ƹ���Ÿ���� �ӳ��� ������ �ִ� ��Ʋ���ּ��縦 óġ�ϰ� ����ǰ�� ��������" + "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" + "��� 2000" + "\n";

        info[34] = "<color=yellow>" + "[����Ʈ]: " + "</color>" + "�Ƹ���Ÿ���� �� ���� - 2" + "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" + "�Ƹ���Ÿ���� �ӳ��� ������ �ִ� ��Ʋ����Ÿ� óġ�ϰ� ����ǰ�� ��������" + "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" + "��� 2000" + "\n";

        info[35] = "<color=yellow>" + "[����Ʈ]: " + "</color>" + "����" + "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" + "�� ������ óġ�ϰ� ���ƿ��� �뺴������� ���� ���� �ҷ���. ���ο� ��ų�� �������ֱ� ���ؼ�" + "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" + "��� 800" + "\n" +
                          "<color=red>" + "���� ��ų ȹ��" + "\n";

        info[36] = "<color=yellow>" + "[����Ʈ]: " + "</color>" + "�⳪�� ������ ��ħǥ" + "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" + "�Ƹ���Ÿ�� �߽ɺο� �ִ� ���������� ������������ óġ����" + "\n" + "\n" +
                          "<color=yellow>" + "[����Ʈ ����]: " + "</color>" + "��� 10000, �����̾� �ձ��� ���� Īȣ" + "\n" +
                          "<color=blue>" + "���� Ŭ����" + "\n";

        jsonQuestLoader = FindObjectOfType<JsonQuestLoader>();
        if (jsonQuestLoader == null)
        {
            Debug.LogError("JsonQuestLoader instance not found!");
            return;
        }


        npcIdGiver = GetComponent<NpcIdGiver>();

        if (dialogUI == null)
        {
            Debug.LogError("DialogUI object is not assigned!");
            return;
        }

        if (questUI == null)
        {
            Debug.LogError("QuestUI object is not assigned!");
            return;
        }
        dialogUI.SetActive(false); 
        //questUI.SetActive(false); 
        //questAcceptButton.SetActive(false);
        //questCompleteButton.SetActive(false);

        //questAcceptUI.SetActive(false);
        //questProgressUI.SetActive(false);
    }
    public void CheckNPCID()
    {
        int questAcceptNumber = QuestManager.Instance.QuestAcceptNumber;

        List<QuestData> allQuestsData = jsonQuestLoader.allQuestsData;

        /*
        foreach (QuestData quest in allQuestsData)
        {
            if (quest.QuestID == questAcceptNumber && quest.QuestGiver == npcIdGiver.Id)
            {
                isNPCQ = 1; 
            }
        }
        */
    }

    private void Update()
    {
        
        int questAcceptNumber = QuestManager.Instance.QuestAcceptNumber;
        int myQuestAcceptNumber = QuestManager.Instance.MyQuestAcceptNumber;
        int myQuestCompleteNumber = QuestManager.Instance.MyQuestCompleteNumber;

        List<QuestData> allQuestsData = jsonQuestLoader.allQuestsData;

        
        if (isCollisionHandled && Input.GetKeyDown(interactKey))
        {
            if(true)
            {
                spaceBarCount++;

                if (spaceBarCount == 1)
                {                   
                    foreach (QuestData quest in allQuestsData)
                    {    

                        if (quest.QuestID == questAcceptNumber && quest.QuestGiver == npcIdGiver.Id) // ����Ʈ ���� �� �մ� npc ���� üũ
                        {
                            
                            Debug.Log("questID : " + quest.QuestID + " AN : " + questAcceptNumber); // �ι�° �������� ���ɸ� 2, 2

                            if(quest.QuestGiver == Array[questAcceptNumber-1])
                            {
                                onlyOneTime = false;
                            }
                            if (questClearList.clearQ == false && onlyOneTime == false)
                            {
                               // Debug.Log(info[questAcceptNumber - 1]);
                                infoBack.gameObject.SetActive(true);
                                infoTxt.text = info[questAcceptNumber - 1] + "";
                                //Debug.Log("dsfasfdfafasfafafasdf" + questAcceptNumber);
                                //Debug.Log(info[questAcceptNumber-1]);
                                
                              

                                /*
                                OnBtn.gameObject.SetActive(true);
                                Debug.Log("1");
                                questAccept.On.gameObject.SetActive(true);
                                */
                         
                                onlyOneTime = true;
                                playerMove.anim.speed = 0;
                                playerMove.isQuest = true;
                            }


                            if (questClearList.clearQ == true)
                            {
                                Debug.Log("2");
                                OffBtn.gameObject.SetActive(true);
                                questComplete.Off.gameObject.SetActive(true);

                                playerMove.anim.speed = 0;
                                playerMove.isQuest = true;
                            }

                            
                                
                            FindObjectOfType<JsonQuestLoader>()?.HandleNpcCollision(npcIdGiver.Id, questAcceptNumber);
                            FindObjectOfType<QuestAcceptButton>()?.SetNpcId_Accept(npcIdGiver.Id, myQuestAcceptNumber);
                            FindObjectOfType<QuestCompleteButton>()?.SetNpcId_Complete(npcIdGiver.Id, myQuestCompleteNumber);

                            break;
                        }
                        else
                        {
                            Debug.Log("6");
                            DialogUI.gameObject.SetActive(false);
                            dialogUI.SetActive(false);

                            if (!onlyOneTime)
                            {
                                Debug.Log("7");
                                playerMove.anim.speed = 1;
                                playerMove.isQuest = false;
                            }
                        }

                    }
                }
            }
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isCollisionHandled)
        {
            isCollisionHandled = true;
            npcIdGiver = GetComponent<NpcIdGiver>();

            if (npcIdGiver != null)
            {
                int npcId = npcIdGiver.Id;
                // FindObjectOfType<JsonDialogLoader>()?.HandleNpcCollision(npcId);
                spaceBarCount = 0; 
            }
            else
            {
                Debug.LogError("NpcIdGiver component is not found on the collider object!");
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && isCollisionHandled)
        {
            isCollisionHandled = false;
            spaceBarCount = 0; 
        }
    }

    private int QuestCheck(int num)
    {
        int questAcceptNumber = QuestManager.Instance.QuestAcceptNumber;
        List<QuestData> allQuestsData = jsonQuestLoader.allQuestsData;

        foreach (QuestData quest in allQuestsData)
        {
            if (quest.QuestID == questAcceptNumber && quest.QuestGiver == npcIdGiver.Id)
            {
                Debug.Log("hi:" + quest.QuestID);
                num = 1;
                return num;
            }
        }
        return 0;
    }
}
