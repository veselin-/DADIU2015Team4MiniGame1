using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour {

	public AudioSource music;
	public AudioSource flapping;
	public AudioSource success;
	public AudioSource wind;
	public AudioSource fail;
	public AudioSource combo;
	public AudioSource pose;

	public AudioMixer MasterMixer;
	public AudioMixer MusicMixer;
	public AudioMixer SoundFXMixer;

	public void MusicPlay()
	{
		music.Play ();
	}

	public void MusicStop()
	{
		music.Stop ();
	}
	public void WindPlay()
	{
		wind.Play ();
	}
	public void WindStop()
	{
		wind.Stop ();
	}
	public void FlappingPlay()
	{
		flapping.Play ();
	}
	public void FlappingStop()
	{
		flapping.Stop ();
	}

	public void SuccessPlay()
	{
		success.Play ();
	}

	public void SuccessStop()
	{
		success.Stop ();
	}

	public void ChangeSuccessPitch(float pitch)
	{
		SoundFXMixer.SetFloat ("SuccessPitch", pitch);
	}


	public void FailPlay()
	{
		fail.Play ();
	}

	public void FailStop()
	{
		fail.Stop ();
	}

	public void ComboPlay()
	{
		combo.Play ();
	}

	public void ComboStop()
	{
		combo.Stop ();
	}

	public void PosePlay()
	{
		pose.Play ();
	}
	
	public void PoseStop()
	{
		pose.Stop ();
	}
}
