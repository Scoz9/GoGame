
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour {

	public static AudioManager instance;

	[SerializeField] private AudioMixerGroup musicMixerGroup;
	[SerializeField] private AudioMixerGroup soundEffectsMixerGroup;
	[SerializeField] private Sound[] sounds;
	public Slider musicSlider;
	public Slider effectsSlider;

	void Awake ()
	{
		instance = this;
	
		foreach (Sound s in sounds) {
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.audioClip;
			s.source.loop = s.isLoop;
			s.source.volume = s.volume;
			
			switch(s.audioType)
			{
				case Sound.AudioTypes.soundEffect:
					s.source.outputAudioMixerGroup = soundEffectsMixerGroup;
					break;
				
				case Sound.AudioTypes.music:
					s.source.outputAudioMixerGroup = musicMixerGroup;
					break;

			}

			if(s.playOnAwake){
				s.source.Play();
			}
			
		}
	}

	public void Play (string sound) {
		Sound s = Array.Find(sounds, item => item.name == sound);
		s.source.Play();
	}

	public void Stop(string sound) {
		Sound s = Array.Find(sounds, item => item.name == sound);
		s.source.Stop();
	}

	public void UpdateMixerVolume(){
		musicMixerGroup.audioMixer.SetFloat("Music Volume", Mathf.Log10(AudioOptionsManager.musicVolume)*20);
		soundEffectsMixerGroup.audioMixer.SetFloat("Sound Effects Volume", Mathf.Log10(AudioOptionsManager.soundEffectsVolume)*20);
	}
}
