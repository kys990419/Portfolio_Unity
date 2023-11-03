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
        "<color=yellow>" + "[퀘스트]: "+ "</color>" + "일어나 아들!" + "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 내용]: " + "</color>" +  "마을 토마토 밭에 가서 토마토를 5개 수확하자"+ "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 보상]: " + "</color>" + "100 골드" + "\n",

        "<color=yellow>" + "[퀘스트]: "+ "</color>" + "장로님의 호출" + "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 내용]: " + "</color>" +  "마을의 장로님을 찾아가 대화하기"+ "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 보상]: " + "</color>" + "100 골드" + "\n",

        "<color=yellow>" + "[퀘스트]: "+ "</color>" + "용병사무소가 어디있지?" + "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 내용]: " + "</color>" +  "용병사무소의 용병단장을 찾아가 대화하기"+ "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 보상]: " + "</color>" + "100 골드" + "\n",

        "<color=yellow>" + "[퀘스트]: "+ "</color>" + "실력 테스트" + "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 내용]: " + "</color>" +  "마을 밖의 고블린 전사 5마리를 처치하자"+ "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 보상]: " + "</color>" + "100 골드" + "\n" + "\n" +
                          "<color=red>" + "1차 전직 퀘스트" + "</color>" + "\n",

        "<color=yellow>" + "[퀘스트]: "+ "</color>" + "니가 그 이번에 들어온 신참이냐?" + "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 내용]: " + "</color>" +  "용병부단장을 만나 대화 진행"+ "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 보상]: " + "</color>" + "체력 포션 10개, 마나 포션 10개" + "\n",

        "<color=yellow>" + "[퀘스트]: "+ "</color>" + "인정받고 싶으면 증명해 보여라" + "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 내용]: " + "</color>" +  "마을 밖의 고블린 궁수의 전리품 10개를 수집해오자"+ "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 보상]: " + "</color>" + "100 골드" + "\n",

        "<color=yellow>" + "[퀘스트]: "+ "</color>" + "초록색 지붕을 가진 집에 누가 살까?" + "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 내용]: " + "</color>" +  "마을 밖 초록지붕집을 조사하고 오기"+ "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 보상]: " + "</color>" + "100 골드" + "\n",

        "<color=yellow>" + "[퀘스트]: "+ "</color>" + "숲속의 보물상자?" + "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 내용]: " + "</color>" +  "초록지붕집 근처 보물상자들을 찾아보자"+ "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 보상]: " + "</color>" + "100 골드" + "\n",

        "<color=yellow>" + "[퀘스트]: "+ "</color>" + "고블린 행동대장 토벌 작전" + "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 내용]: " + "</color>" +  "마을 북동쪽에 있는 고블린 주둔지로 가서 고블린 행동대장을 처치하고 전리품을 가져오자"+ "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 보상]: " + "</color>" + "500 골드" + "\n",

        "<color=yellow>" + "[퀘스트]: "+ "</color>" + "루테란 마을의 평화 1" + "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 내용]: " + "</color>" +  "용병단장님을 만나 안부를 묻자"+ "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 보상]: " + "</color>" + "체력포션 10개, 마나포션 10개" + "\n",

        "<color=yellow>" + "[퀘스트]: "+ "</color>" + "루테란 마을의 평화 2" + "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 내용]: " + "</color>" +  "마을 남서쪽의 고블린 왕 주둔지로 가 보스인 고블린 왕을 처치하고 전리품을 가져오자"+ "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 보상]: " + "</color>" + "1000 골드" + "\n" +
                          "<color=red>" + "2차 전직 퀘스트" + "\n",

        "<color=yellow>" + "[퀘스트]: "+ "</color>" + "작별인사" + "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 내용]: " + "</color>" +  "엄마를 만나 작별인사를 나누자"+ "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 보상]: " + "</color>" + "100 골드" + "\n",

        "<color=yellow>" + "[퀘스트]: "+ "</color>" + "기회의 땅 아르테미스로!" + "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 내용]: " + "</color>" +  "용병단장님을 만나러 가자 그리고 아르테미스로 가자"+ "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 보상]: " + "</color>" + "300골드" + "\n",

        "<color=yellow>" + "[퀘스트]: "+ "</color>" + "아르테미스의 용병단장을 찾아가자" + "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 내용]: " + "</color>" +  "아르테미스의 용병사무소를 찾아가 용병단장을 만나자"+ "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 보상]: " + "</color>" + "200 골드" + "\n",

        "<color=yellow>" + "[퀘스트]: "+ "</color>" + "버나이어 장로님" + "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 내용]: " + "</color>" +  "아르테미스 마을의 장로를 만나 인사를 드리고 오자"+ "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 보상]: " + "</color>" + "200 골드" + "\n",

        "<color=yellow>" + "[퀘스트]: "+ "</color>" + "보트 위의 약 찾기" + "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 내용]: " + "</color>" +  "장로의 보트에 놓고내린 약을 찾아주자"+ "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 보상]: " + "</color>" + "200 골드" + "\n",

        "<color=yellow>" + "[퀘스트]: "+ "</color>" + "해골전사 사냥" + "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 내용]: " + "</color>" +  "아르테미스 용병사무소에 와서 처음 임무다운 임무를 받았다. 마을 밖 몬스터를 10마리 처치하자"+ "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 보상]: " + "</color>" + "200 골드" + "\n",

        "<color=yellow>" + "[퀘스트]: "+ "</color>" + "해골궁수 사냥" + "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 내용]: " + "</color>" +  "해골궁수를 처치하고 전리품을 가져오자"+ "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 보상]: " + "</color>" + "200 골드" + "\n",

        "<color=yellow>" + "[퀘스트]: "+ "</color>" + "더 넓은 아르테미스를 위하여" + "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 내용]: " + "</color>" +  "아르테미스 대륙의 협곡에 해골기사가 주둔해 사람들은 협곡 그 너머로 갈 수 없다. 용병단장의 부탁을 수락하여 해골기사를 처치하자"+ "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 보상]: " + "</color>" + "400 골드" + "\n",

        "<color=yellow>" + "[퀘스트]: "+ "</color>" + "뜨거워진 우물 물" + "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 내용]: " + "</color>" +  "우물 안의 물이 뜨거워 지고 있다. 발원지를 조사해보자"+ "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 보상]: " + "</color>" + "400 골드" + "\n",

        "<color=yellow>" + "[퀘스트]: "+ "</color>" + "협곡 깊은 곳에 숨겨진 약초" + "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 내용]: " + "</color>" +  "깊은 협곡에 숨겨진 빨간 약초가 있다고한다. 그것을 찾아오자"+ "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 보상]: " + "</color>" + "400 골드" + "\n",

        "<color=yellow>" + "[퀘스트]: "+ "</color>" + "아르테미스의 평화를 위해" + "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 내용]: " + "</color>" +  "용병단장님은 암석거인을 처치하여 이 마을의 평화를 지켜달라고 부탁한다."+ "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 보상]: " + "</color>" + "2000 골드" + "\n" +
                          "<color=red>" + "3차 전직 퀘스트" + "\n",

        "<color=yellow>" + "[퀘스트]: "+ "</color>" + "세상의 끝을 향해서" + "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 내용]: " + "</color>" +  "용병단장과 대화하고 아르데타인으로 갈 준비를 하자"+ "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 보상]: " + "</color>" + "600 골드" + "\n",

        "<color=yellow>" + "[퀘스트]: "+ "</color>" + "어두운 대륙 아르데타인" + "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 내용]: " + "</color>" +  "아르데타인에 도착했다. 곧바로 용병단장을 찾아가자"+ "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 보상]: " + "</color>" + "600 골드" + "\n",

        "<color=yellow>" + "[퀘스트]: "+ "</color>" + "다른 용병단원들은 어디 있나요?" + "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 내용]: " + "</color>" +  "루테란, 아르테미스 용병사무소에 비해 초라해 보이는 아르데타인 용병사무소. 무슨 일이 있었던걸까? 용병단장에게 물어보자"+ "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 보상]: " + "</color>" + "600 골드" + "\n",

        "<color=yellow>" + "[퀘스트]: "+ "</color>" + "설득 - 용병부단장" + "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 내용]: " + "</color>" +  "흩어진 용병단원들을 다시 모으기 위해 데릭이 발로 뛰기 시작했다. 먼저 용병부단장을 찾아가자"+ "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 보상]: " + "</color>" + "600 골드" + "\n",

        "<color=yellow>" + "[퀘스트]: "+ "</color>" + "설득 - 용병단원 1" + "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 내용]: " + "</color>" +  "다음은 용병단원 1을 찾아가자"+ "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 보상]: " + "</color>" + "600 골드" + "\n",

        "<color=yellow>" + "[퀘스트]: "+ "</color>" + "설득 - 용병단원 2" + "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 내용]: " + "</color>" +  "마지막으로 용병단원 2를 찾아가자"+ "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 보상]: " + "</color>" + "600 골드" + "\n",

        "<color=yellow>" + "[퀘스트]: "+ "</color>" + "광산으로 가봐" + "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 내용]: " + "</color>" +  "아르데타인 마을은 광산업을 통해 주로 생계 유지를 한다. 광산으로 가 둘러보자"+ "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 보상]: " + "</color>" + "800 골드" + "\n",

        "<color=yellow>" + "[퀘스트]: "+ "</color>" + "광산을 위협하는 괴물들" + "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 내용]: " + "</color>" +  "용병단장님이 광산을 위협하는 괴물들을 처치하라는 명령을 주셨다. 검은전사를 10마리 처치하자"+ "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 보상]: " + "</color>" + "800 골드" + "\n",

        "<color=yellow>" + "[퀘스트]: "+ "</color>" + "광산을 위협하는 괴물들 2" + "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 내용]: " + "</color>" +  "검은망령의 전리품을 10개 수집해가자"+ "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 보상]: " + "</color>" + "800 골드" + "\n",

        "<color=yellow>" + "[퀘스트]: "+ "</color>" + "전초기지 탐색" + "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 내용]: " + "</color>" +  "마을 밖 북동쪽에 용병단 전초기지가 있다. 전초기지의 상태를 둘러보고 오자"+ "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 보상]: " + "</color>" + "600 골드" + "\n",

        "<color=yellow>" + "[퀘스트]: "+ "</color>" + "홀로 사는 노인" + "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 내용]: " + "</color>" +  "장로님에겐 나이 든 아버지가 있는데 아버지는 마을 밖 먼 곳에서 홀로 살고계신다. 아버지가 잘 계신지 확인하고 오자"+ "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 보상]: " + "</color>" + "600 골드" + "\n",

        "<color=yellow>" + "[퀘스트]: "+ "</color>" + "아르데타인의 두 괴물 - 1" + "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 내용]: " + "</color>" +  "아르데타인의 머나먼 구석에 있는 뒤틀린주술사를 처치하고 전리품을 가져오자"+ "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 보상]: " + "</color>" + "골드 2000" + "\n",

        "<color=yellow>" + "[퀘스트]: "+ "</color>" + "아르데타인의 두 괴물 - 2" + "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 내용]: " + "</color>" +  "아르데타인의 머나먼 구석에 있는 뒤틀린사신를 처치하고 전리품을 가져오자"+ "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 보상]: " + "</color>" + "골드 2000" + "\n",

        "<color=yellow>" + "[퀘스트]: "+ "</color>" + "각성" + "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 내용]: " + "</color>" +  "두 괴물을 처치하고 돌아오자 용병단장님이 따로 나를 불렀다. 새로운 스킬을 전수해주기 위해서"+ "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 보상]: " + "</color>" + "골드 800" + "\n" +
                          "<color=red>" + "각성 스킬 획득" + "\n",

        "<color=yellow>" + "[퀘스트]: "+ "</color>" + "기나긴 여정의 마침표" + "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 내용]: " + "</color>" +  "아르데타인 중심부에 있는 최종보스인 지옥수문장을 처치하자"+ "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 보상]: " + "</color>" + "골드 10000, 데마이어 왕국의 영웅 칭호" + "\n" +
                          "<color=blue>" + "게임 클리어" + "\n"
    };
    */

    public void Start()
    {
        info[0] = "<color=yellow>" + "[퀘스트]: " + "</color>" + "일어나 아들!" + "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 내용]: " + "</color>" + "마을 토마토 밭에 가서 토마토를 5개 수확하자" + "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 보상]: " + "</color>" + "100 골드" + "\n";

        info[1] = "<color=yellow>" + "[퀘스트]: " + "</color>" + "장로님의 호출" + "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 내용]: " + "</color>" + "마을의 장로님을 찾아가 대화하기" + "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 보상]: " + "</color>" + "100 골드" + "\n";
;
        info[2] = "<color=yellow>" + "[퀘스트]: " + "</color>" + "용병사무소가 어디있지?" + "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 내용]: " + "</color>" + "용병사무소의 용병단장을 찾아가 대화하기" + "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 보상]: " + "</color>" + "100 골드" + "\n";

        info[3] = "<color=yellow>" + "[퀘스트]: " + "</color>" + "실력 테스트" + "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 내용]: " + "</color>" + "마을 밖의 고블린 전사 5마리를 처치하자" + "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 보상]: " + "</color>" + "100 골드" + "\n" + "\n" +
                          "<color=red>" + "1차 전직 퀘스트" + "</color>" + "\n";

        info[4] = "<color=yellow>" + "[퀘스트]: " + "</color>" + "니가 그 이번에 들어온 신참이냐?" + "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 내용]: " + "</color>" + "용병부단장을 만나 대화 진행" + "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 보상]: " + "</color>" + "체력 포션 10개, 마나 포션 10개" + "\n";

        info[5] = "<color=yellow>" + "[퀘스트]: " + "</color>" + "인정받고 싶으면 증명해 보여라" + "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 내용]: " + "</color>" + "마을 밖의 고블린 궁수의 전리품 10개를 수집해오자" + "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 보상]: " + "</color>" + "100 골드" + "\n";

        info[6] = "<color=yellow>" + "[퀘스트]: " + "</color>" + "초록색 지붕을 가진 집에 누가 살까?" + "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 내용]: " + "</color>" + "마을 밖 초록지붕집을 조사하고 오기" + "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 보상]: " + "</color>" + "100 골드" + "\n";

        info[7] = "<color=yellow>" + "[퀘스트]: " + "</color>" + "숲속의 보물상자?" + "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 내용]: " + "</color>" + "초록지붕집 근처 보물상자들을 찾아보자" + "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 보상]: " + "</color>" + "100 골드" + "\n";

        info[8] = "<color=yellow>" + "[퀘스트]: " + "</color>" + "고블린 행동대장 토벌 작전" + "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 내용]: " + "</color>" + "마을 북동쪽에 있는 고블린 주둔지로 가서 고블린 행동대장을 처치하고 전리품을 가져오자" + "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 보상]: " + "</color>" + "500 골드" + "\n";

        info[9] = "<color=yellow>" + "[퀘스트]: " + "</color>" + "루테란 마을의 평화 1" + "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 내용]: " + "</color>" + "용병단장님을 만나 안부를 묻자" + "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 보상]: " + "</color>" + "체력포션 10개, 마나포션 10개" + "\n";

        info[10] = "<color=yellow>" + "[퀘스트]: " + "</color>" + "루테란 마을의 평화 2" + "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 내용]: " + "</color>" + "마을 남서쪽의 고블린 왕 주둔지로 가 보스인 고블린 왕을 처치하고 전리품을 가져오자" + "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 보상]: " + "</color>" + "1000 골드" + "\n" +
                          "<color=red>" + "2차 전직 퀘스트" + "\n";

        info[11] = "<color=yellow>" + "[퀘스트]: " + "</color>" + "작별인사" + "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 내용]: " + "</color>" + "엄마를 만나 작별인사를 나누자" + "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 보상]: " + "</color>" + "100 골드" + "\n";

        info[12] = "<color=yellow>" + "[퀘스트]: " + "</color>" + "기회의 땅 아르테미스로!" + "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 내용]: " + "</color>" + "용병단장님을 만나러 가자 그리고 아르테미스로 가자" + "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 보상]: " + "</color>" + "300골드" + "\n" +
                          "<color=green>" + "루테란 마지막 퀘스트" + "</color>" + "\n";

        info[13] = "<color=yellow>" + "[퀘스트]: " + "</color>" + "아르테미스의 용병단장을 찾아가자" + "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 내용]: " + "</color>" + "아르테미스의 용병사무소를 찾아가 용병단장을 만나자" + "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 보상]: " + "</color>" + "200 골드" + "\n";

        info[14] = "<color=yellow>" + "[퀘스트]: " + "</color>" + "버나이어 장로님" + "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 내용]: " + "</color>" + "아르테미스 마을의 장로를 만나 인사를 드리고 오자" + "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 보상]: " + "</color>" + "200 골드" + "\n";

        info[15] = "<color=yellow>" + "[퀘스트]: " + "</color>" + "보트 위의 약 찾기" + "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 내용]: " + "</color>" + "장로의 보트에 놓고내린 약을 찾아주자" + "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 보상]: " + "</color>" + "200 골드" + "\n";

        info[16] = "<color=yellow>" + "[퀘스트]: " + "</color>" + "해골전사 사냥" + "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 내용]: " + "</color>" + "아르테미스 용병사무소에 와서 처음 임무다운 임무를 받았다. 마을 밖 몬스터를 10마리 처치하자" + "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 보상]: " + "</color>" + "200 골드" + "\n";

        info[17] = "<color=yellow>" + "[퀘스트]: " + "</color>" + "해골궁수 사냥" + "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 내용]: " + "</color>" + "해골궁수를 처치하고 전리품을 가져오자" + "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 보상]: " + "</color>" + "200 골드" + "\n";

        info[18] = "<color=yellow>" + "[퀘스트]: " + "</color>" + "더 넓은 아르테미스를 위하여" + "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 내용]: " + "</color>" + "아르테미스 대륙의 협곡에 해골기사가 주둔해 사람들은 협곡 그 너머로 갈 수 없다. 용병단장의 부탁을 수락하여 해골기사를 처치하자" + "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 보상]: " + "</color>" + "400 골드" + "\n";

        info[19] = "<color=yellow>" + "[퀘스트]: " + "</color>" + "뜨거워진 우물 물" + "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 내용]: " + "</color>" + "우물 안의 물이 뜨거워 지고 있다. 발원지를 조사해보자" + "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 보상]: " + "</color>" + "400 골드" + "\n";

        info[20] = "<color=yellow>" + "[퀘스트]: " + "</color>" + "협곡 깊은 곳에 숨겨진 약초" + "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 내용]: " + "</color>" + "깊은 협곡에 숨겨진 빨간 약초가 있다고한다. 그것을 찾아오자" + "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 보상]: " + "</color>" + "400 골드" + "\n";

        info[21] = "<color=yellow>" + "[퀘스트]: " + "</color>" + "아르테미스의 평화를 위해" + "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 내용]: " + "</color>" + "용병단장님은 암석거인을 처치하여 이 마을의 평화를 지켜달라고 부탁한다." + "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 보상]: " + "</color>" + "2000 골드" + "\n" +
                          "<color=red>" + "3차 전직 퀘스트" + "\n";

        info[22] = "<color=yellow>" + "[퀘스트]: " + "</color>" + "세상의 끝을 향해서" + "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 내용]: " + "</color>" + "용병단장과 대화하고 아르데타인으로 갈 준비를 하자" + "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 보상]: " + "</color>" + "600 골드" + "\n" +
                          "<color=green>" + "아르테미스 마지막 퀘스트" + "\n";

        info[23] = "<color=yellow>" + "[퀘스트]: " + "</color>" + "어두운 대륙 아르데타인" + "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 내용]: " + "</color>" + "아르데타인에 도착했다. 곧바로 용병단장을 찾아가자" + "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 보상]: " + "</color>" + "600 골드" + "\n";

        info[24] = "<color=yellow>" + "[퀘스트]: " + "</color>" + "다른 용병단원들은 어디 있나요?" + "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 내용]: " + "</color>" + "루테란, 아르테미스 용병사무소에 비해 초라해 보이는 아르데타인 용병사무소. 무슨 일이 있었던걸까? 용병단장에게 물어보자" + "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 보상]: " + "</color>" + "600 골드" + "\n";

        info[25] = "<color=yellow>" + "[퀘스트]: " + "</color>" + "설득 - 용병부단장" + "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 내용]: " + "</color>" + "흩어진 용병단원들을 다시 모으기 위해 데릭이 발로 뛰기 시작했다. 먼저 용병부단장을 찾아가자" + "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 보상]: " + "</color>" + "600 골드" + "\n";

        info[26] = "<color=yellow>" + "[퀘스트]: " + "</color>" + "설득 - 용병단원 1" + "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 내용]: " + "</color>" + "다음은 용병단원 1을 찾아가자" + "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 보상]: " + "</color>" + "600 골드" + "\n";

        info[27] = "<color=yellow>" + "[퀘스트]: " + "</color>" + "설득 - 용병단원 2" + "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 내용]: " + "</color>" + "마지막으로 용병단원 2를 찾아가자" + "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 보상]: " + "</color>" + "600 골드" + "\n";

        info[28] = "<color=yellow>" + "[퀘스트]: " + "</color>" + "광산으로 가봐" + "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 내용]: " + "</color>" + "아르데타인 마을은 광산업을 통해 주로 생계 유지를 한다. 광산으로 가 둘러보자" + "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 보상]: " + "</color>" + "800 골드" + "\n";

        info[29] = "<color=yellow>" + "[퀘스트]: " + "</color>" + "광산을 위협하는 괴물들" + "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 내용]: " + "</color>" + "용병단장님이 광산을 위협하는 괴물들을 처치하라는 명령을 주셨다. 검은전사를 10마리 처치하자" + "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 보상]: " + "</color>" + "800 골드" + "\n";

        info[30] = "<color=yellow>" + "[퀘스트]: " + "</color>" + "광산을 위협하는 괴물들 2" + "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 내용]: " + "</color>" + "검은망령의 전리품을 10개 수집해가자" + "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 보상]: " + "</color>" + "800 골드" + "\n";

        info[31] = "<color=yellow>" + "[퀘스트]: " + "</color>" + "전초기지 탐색" + "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 내용]: " + "</color>" + "마을 밖 북동쪽에 용병단 전초기지가 있다. 전초기지의 상태를 둘러보고 오자" + "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 보상]: " + "</color>" + "600 골드" + "\n";

        info[32] = "<color=yellow>" + "[퀘스트]: " + "</color>" + "홀로 사는 노인" + "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 내용]: " + "</color>" + "장로님에겐 나이 든 아버지가 있는데 아버지는 마을 밖 먼 곳에서 홀로 살고계신다. 아버지가 잘 계신지 확인하고 오자" + "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 보상]: " + "</color>" + "600 골드" + "\n";

        info[33] = "<color=yellow>" + "[퀘스트]: " + "</color>" + "아르데타인의 두 괴물 - 1" + "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 내용]: " + "</color>" + "아르데타인의 머나먼 구석에 있는 뒤틀린주술사를 처치하고 전리품을 가져오자" + "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 보상]: " + "</color>" + "골드 2000" + "\n";

        info[34] = "<color=yellow>" + "[퀘스트]: " + "</color>" + "아르데타인의 두 괴물 - 2" + "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 내용]: " + "</color>" + "아르데타인의 머나먼 구석에 있는 뒤틀린사신를 처치하고 전리품을 가져오자" + "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 보상]: " + "</color>" + "골드 2000" + "\n";

        info[35] = "<color=yellow>" + "[퀘스트]: " + "</color>" + "각성" + "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 내용]: " + "</color>" + "두 괴물을 처치하고 돌아오자 용병단장님이 따로 나를 불렀다. 새로운 스킬을 전수해주기 위해서" + "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 보상]: " + "</color>" + "골드 800" + "\n" +
                          "<color=red>" + "각성 스킬 획득" + "\n";

        info[36] = "<color=yellow>" + "[퀘스트]: " + "</color>" + "기나긴 여정의 마침표" + "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 내용]: " + "</color>" + "아르데타인 중심부에 있는 최종보스인 지옥수문장을 처치하자" + "\n" + "\n" +
                          "<color=yellow>" + "[퀘스트 보상]: " + "</color>" + "골드 10000, 데마이어 왕국의 영웅 칭호" + "\n" +
                          "<color=blue>" + "게임 클리어" + "\n";

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

                        if (quest.QuestID == questAcceptNumber && quest.QuestGiver == npcIdGiver.Id) // 퀘스트 받을 수 잇는 npc 인지 체크
                        {
                            
                            Debug.Log("questID : " + quest.QuestID + " AN : " + questAcceptNumber); // 두번째 엄마한테 말걸면 2, 2

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
