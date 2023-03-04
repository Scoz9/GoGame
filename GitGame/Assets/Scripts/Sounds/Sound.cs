using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound {

	public enum AudioTypes{soundEffect,music}
	public AudioTypes audioType;

	[HideInInspector] public AudioSource source;
	public string name;
	public AudioClip audioClip;
	public bool isLoop;
	public bool playOnAwake;

	[Range(0f, 1f)]
	public float volume = 0.5f;	
}
