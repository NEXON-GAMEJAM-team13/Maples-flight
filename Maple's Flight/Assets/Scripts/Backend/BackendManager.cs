using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using BackEnd;

public class BackendManager : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI googlehashText;

    private void Awake()
    {
        // Update �޼ҵ��� Backend.AsyncPoll(); ȣ�� ���� �ı� ����
        DontDestroyOnLoad(gameObject);
        BackendSetUp();
    }

    private void Update()
    {
        // ������ �񵿱� �޼ҵ� ȣ���� ���� �ۼ�
        if (Backend.IsInitialized)
            Backend.AsyncPoll();
    }

    void BackendSetUp()
    {
        var bro = Backend.Initialize(true); // �ڳ� �ʱ�ȭ

        // �ڳ� �ʱ�ȭ�� ���� ���䰪
        if (bro.IsSuccess())
        {
            Debug.Log("�ʱ�ȭ ���� : " + bro); // ������ ��� statusCode 204 Success
        }
        else
        {
            Debug.LogError("�ʱ�ȭ ���� : " + bro); // ������ ��� statusCode 400�� ���� �߻� 
        }

        //example
        string googlehash = Backend.Utils.GetGoogleHash();
        googlehashText.text = googlehash;
    }
}
