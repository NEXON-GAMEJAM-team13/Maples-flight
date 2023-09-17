using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndingController : MonoBehaviour
{
    [SerializeField]
    Sprite[] thumbnails = new Sprite[11];
    string[] titles = new string[11];
    string[] desc = new string[11];
    string[] desc2 = new string[11];

    void Awake()
    {
        titles[0] = "엄마, 하늘에도 바다가 있어요!";
        titles[1] = "이동 중엔 한 눈을 팔면 안돼요!";
        titles[2] = "나무가 원래 이렇게 컸던가요..?";
        titles[3] = "씨앗으로 바위를 쳐봤어요!";
        titles[4] = "날개가 달린 괴물한테\n잡아먹히고 말았어요!";
        titles[5] = "도토리 괴물의 귀여운 모습에\n속지 마세요!";
        titles[6] = "호기심 대마왕 토끼는\n궁금한걸 참지 못해요!";
        titles[7] = "아기 단풍나무가 되었어요!";
        titles[8] = "어린이 단풍나무가 되었어요!";
        titles[9] = "사춘기 단풍나무가 되었어요!";
        titles[10] = "단풍나무가 만개했어요!";

        desc[0] = "강하게 부는 바람을 타고 올라간 곳엔\n끝없는 바다가 펼쳐져 있었어요!";
        desc[1] = "정신없이 떠다니다보니\n어느새 나뭇가지에 걸려버렸어요..\n이동 중엔 한 눈 팔지 말기! 명심할게요..";
        desc[2] = "엄마한테 붙어있을 땐 몰랐는데,\n나무는 아주 아주 커요. 엄마의 편지처럼\n저도 꼭 크고 아름다운 나무가 될 거예요!";
        desc[3] = "결과는 처참했어요..\n다시는 바위를 우습게 보지 않을 거예요.";
        desc[4] = "무시무시한 크기의 날개 달린 괴물을\n피하는데 실패하자,\n괴물이 날 망설임 없이 집어삼켰어요.";
        desc[5] = "나무 근처를 지나갈 땐 도토리 괴물을 조심해야 해요.\n생김새는 귀엽지만 하는 짓은 그렇지 못하거든요.";
        desc[6] = "호기심을 참지 못하고 나무 위로 튀어나온 토끼와\n부딪혀 멀리 튕겨나갔어요.\n제가 보이지 않을 정도라니..뭐가 그리 궁금한걸까요?";
        desc[7] = "아무래도 비행 시간이 너무 짧았나봐요..\n그래도 이것 보세요! 제가 드디어 뿌리를 틔웠어요!";
        desc[8] = "이렇게 조금씩 멀리 나아가는거죠!\n어때요? 전보다 더 성장한거 같지 않나요?";
        desc[9] = "나름 어엿한 단풍나무 같죠?\n이 정도면 저도 이제 다 컸다고요!";
        desc[10] = "엄마처럼 크고 아름다운 단풍나무가 됐어요!\n이제 이 곳에서 평화롭던\n예전 우리 마을의 모습을 되찾을 거예요.\n지켜봐주세요 엄마!";

        
        desc2[0] = "강하게 부는 바람을 타고\n올라간 곳엔 끝없는 바다가\n펼쳐져 있었어요!";
        desc2[1] = "정신없이 떠다니다보니\n어느새 나뭇가지에 \n걸려버렸어요..\n이동 중엔 한 눈 팔지 말기!\n명심할게요..";
        desc2[2] = "엄마한테 붙어있을 땐 몰랐는데,\n나무는 아주 아주 커요.\n엄마의 편지처럼\n저도 꼭 크고 아름다운\n나무가 될 거예요!";
        desc2[3] = "결과는 처참했어요..\n다시는 바위를 우습게 보지\n않을 거예요.";
        desc2[4] = "무시무시한 크기의\n날개 달린 괴물을\n피하는데 실패하자,\n괴물이 날 망설임 없이\n집어삼켰어요.";
        desc2[5] = "나무 근처를 지나갈 땐\n도토리 괴물을 조심해야 해요.\n생김새는 귀엽지만\n하는 짓은 그렇지 못하거든요.";
        desc2[6] = "호기심을 참지 못하고\n나무 위로 튀어나온 토끼와\n부딪혀 멀리 튕겨나갔어요.\n제가 보이지 않을 정도라니..\n뭐가 그리 궁금한걸까요?"; 
        desc2[7] = "아무래도 비행 시간이\n너무 짧았나봐요..\n그래도 이것 보세요!\n제가 드디어 뿌리를 틔웠어요!";
        desc2[8] = "이렇게 조금씩\n멀리 나아가는거죠!\n어때요? 전보다 더\n 성장한거 같지 않나요?";
        desc2[9] = "나름 어엿한 단풍나무 같죠?\n이 정도면 저도 이제 다 컸다고요!";
        desc2[10] = "엄마처럼 크고 아름다운\n단풍나무가 됐어요!\n이제 이 곳에서 평화롭던\n예전 우리 마을의 모습을\n되찾을 거예요.\n지켜봐주세요 엄마!";
    }

    public string GetEndingTitleText(int idx)
    {
        return titles[idx];
    }

    public string GetEndingDescText(int idx)
    {
        if (GameManager.instance.isDiary)
            return desc2[idx];

        return desc[idx];
    }

    public Sprite GetEndingImage(int idx)
    {
        return thumbnails[idx];
    }
}
