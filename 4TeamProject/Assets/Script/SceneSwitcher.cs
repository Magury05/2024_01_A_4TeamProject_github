using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // �� ��ȯ�� ���� �ʿ��� ���ӽ����̽�

public class SceneSwitcher : MonoBehaviour
{
    // �� �̸����� ���� �ε��ϴ� �޼���
    public void LoadSceneByName(string GameScene)
    {
        // �־��� �� �̸����� ���� �ε��մϴ�.
        SceneManager.LoadScene(GameScene);
    }

    
}
