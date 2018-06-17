using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
public class VideoPlay : MonoBehaviour {
	public string nextScene;
	void Start(){
	}
	void Update(){
		if (this.GetComponent<VideoPlayer> ().isPrepared && !this.GetComponent<VideoPlayer> ().isPlaying) {
			SceneManager.LoadScene(nextScene);
		}
	}
}
