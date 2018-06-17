using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
public class VideoPlay : MonoBehaviour {
	public string nextScene;
	void Start(){
		this.GetComponent<VideoPlayer>().url = System.IO.Path.Combine (Application.streamingAssetsPath,"myFile.mp4");
	}
	void Update(){
		if (this.GetComponent<VideoPlayer> ().isPrepared && !this.GetComponent<VideoPlayer> ().isPlaying) {
			SceneManager.LoadScene(nextScene);
		}
	}
}
