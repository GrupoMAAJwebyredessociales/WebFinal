using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
public class VideoPlay : MonoBehaviour {
	public string nextScene;
    private void Start()
    {
        if(Application.platform == RuntimePlatform.WebGLPlayer)
        {
            SceneManager.LoadScene(nextScene);
        }
    }
    void Update(){
		if (this.GetComponent<VideoPlayer> ().isPrepared && !this.GetComponent<VideoPlayer> ().isPlaying) {
			SceneManager.LoadScene(nextScene);
		}
	}
}
