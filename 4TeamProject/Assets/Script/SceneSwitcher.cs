using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // 씬 전환을 위해 필요한 네임스페이스

public class SceneSwitcher : MonoBehaviour
{
    // 씬 이름으로 씬을 로드하는 메서드
    public void LoadSceneByName(string GameScene)
    {
        // 주어진 씬 이름으로 씬을 로드합니다.
        SceneManager.LoadScene(GameScene);
    }

    
}
