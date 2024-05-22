using UnityEngine;
using UnityEngine.SceneManagement; // 씬 관리를 위해 필요합니다.
using System.Collections;
using UnityEngine.UI;
using System.Data.Common; // UI를 사용하기 위해 필요합니다.
using System.Diagnostics; // Stopwatch를 사용하기 위해 필요합니다.
using TMPro;
using Debug = UnityEngine.Debug;

namespace Wan_Splash
{
    // 비동기 씬 로더 클래스
    public class AsyncSceneLoader : MonoBehaviour
    {
        [Header("Load")]

        public string sceneToLoad = ""; // 로드하려는 씬의 이름
        public TMP_Text loadingText; // 로딩 상태를 표시할 UI 텍스트
        public float minimumExposureTime = 1; // 최소로 스플래쉬가 노출될 시간

        [Header("Initial Data")]
        public InitialData initialData;

        private AsyncOperation asyncLoadSceneOperation;


        // 씬 로딩을 시작하는 메소드
        public void Start()
        {
            // 씬 이름이 유효한지 확인
            if (string.IsNullOrEmpty(sceneToLoad))
            {
                Debug.LogError("Scene name is empty or null!");
                return;
            }

            StartCoroutine(LoadSceneCoroutine());
        }

        // 비동기 씬 로딩
        IEnumerator LoadSceneCoroutine()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            // 씬 로드 시작
            asyncLoadSceneOperation = SceneManager.LoadSceneAsync(sceneToLoad);
            asyncLoadSceneOperation.allowSceneActivation = false;

            // 로딩이 완료될 때까지 대기, 로딩 상태 출력
            while (!asyncLoadSceneOperation.isDone)
            {
                float progress = Mathf.Clamp01(asyncLoadSceneOperation.progress / 0.9f);
                Debug.Log(progress);
                if (loadingText != null)
                {
                    loadingText.text = "Loading... " + (progress * 100) + "%";
                }
                if (asyncLoadSceneOperation.progress >= 0.9f)
                {
                    break;
                }
                yield return new WaitForEndOfFrame();
            }

            // 데이터에 등록된 매니저 생성 및 초기화
            foreach(var data in initialData.PersistentManager)
            {
                GameObject AddManger = Instantiate(data);
                data.GetComponent<WanManager>().Init();
            }

            // 로딩이 완료된 시점에서 스톱워치를 멈춤
            stopwatch.Stop();

            // 최소 노출 시간을 보장하기 위해 추가로 대기
            float remainingTime = minimumExposureTime - (float)stopwatch.Elapsed.TotalSeconds;
            if (remainingTime > 0)
            {
                yield return new WaitForSeconds(remainingTime);
            }

            ActivateScene();
        }

        public void ActivateScene()
        {
            asyncLoadSceneOperation.allowSceneActivation = true;
        }
    }
}
