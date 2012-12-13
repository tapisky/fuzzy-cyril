using UnityEngine;
using System.Collections;

public class BackgroundMusic : MonoBehaviour {
	
	private Rect labelRect;
	private Rect labelsample1;
	private Rect labelsample2;
	private Rect labelsample3;
	private AudioSource snare;
	private AudioSource kick;
	private AudioSource hat;
	private AudioSource pizzi1;
	private bool bpizzi1;
	private AudioSource pizzi2;
	private AudioSource pizzi3;
	private AudioSource sample;
	
	public CollisionBouncing nb;
	public WWW stream;
	
	// Use this for initialization
	void Start () 
	{
		
		labelRect = new Rect(0, 0, 200, 20);
		labelsample1 = new Rect(0, 20, 200, 20);
		labelsample2 = new Rect(0, 40, 200, 20);
		labelsample3 = new Rect(0, 60, 200, 20);
		
		snare = GameObject.Find("snare").audio;
		snare.volume = 0.2F;
		
		kick = GameObject.Find("kick").audio;
		kick.volume = 0.0F;
		
		hat = GameObject.Find("hat").audio;
		hat.volume = 0.0F;

		pizzi1 = GameObject.Find("pizzi1").audio;
		pizzi1.volume = 0.0F;
		bpizzi1 = false;
		pizzi2 = GameObject.Find("pizzi2").audio;
		pizzi2.volume = 0.0F;
		pizzi3 = GameObject.Find("pizzi3").audio;
		pizzi3.volume = 0.0F;
				
		nb = GetComponent<CollisionBouncing>();
		
		//nb.numbounces = 8;
		
		//stream = new WWW ("http://www.igolgol.com/music/Ringtone_Omen_Loop2.wav");  // start a download of the given URL

		//audio.clip = stream.GetAudioClip(false, true); // 2D
		
		//StartCoroutine(startstream(audio.clip));
		
	}
	
	/*IEnumerator startstream(AudioClip clip)
	{
		
		while (!clip.isReadyToPlay)
		{
			yield return new WaitForSeconds(3F);
		}
		
		if (clip.isReadyToPlay)
		{
			audio.Play();
			
		}
		
	}*/
	
	// Update is called once per frame
	void LateUpdate ()
	{
		
		if ( ((nb.numbounces % 4) == 0) && (nb.numbounces > 0)  || ( ( ((nb.numbounces % 4) >= 0) && ((nb.numbounces % 4) <= 1) ) && (nb.numbounces < 12)) )
		{
			StartCoroutine(fadein(kick,0.2F));
			
		}
		else
		{
			StartCoroutine(fadeout(kick,1));
		}
		
		if ( (nb.numbounces > 8) && ( ((nb.numbounces % 4) == 0) || ((nb.numbounces % 4) == 1) ) && (nb.numbounces < 14) )
		{
			StartCoroutine(fadein(hat,0.1F));
		}
		else
		{
			StartCoroutine(fadeout(hat,1));
		}
				
		if ( (nb.numbounces > 10) && (!bpizzi1) )
		{
			bpizzi1 = true;
			StartCoroutine(playscheduled(pizzi1));
		}
		
		if (nb.numbounces >= 14)
		{
			
			StartCoroutine(fadein(kick,0.2F));
			StartCoroutine(fadein(hat,0.1F));
		}
		
		if ( (nb.numbounces < 10) && (bpizzi1) )
		{
			bpizzi1 = false;
			StartCoroutine(fadeout2(pizzi1));
		}
		
		if (nb.numbounces == 20)
		{
			nb.numbounces = 0;	
		}
	}
	
	IEnumerator playscheduled(AudioSource audioobj)
	{
		
		yield return new WaitForSeconds(audioobj.clip.length - audioobj.time);
		audioobj.volume = 0.08F;
		yield return null;
	}
	
	IEnumerator stopscheduled(AudioSource audioobj)
	{
		
		yield return new WaitForSeconds(audioobj.clip.length - audioobj.time - 0.1F);
		audioobj.volume = 0.0F;
		yield return null;
	}
	
	
	IEnumerator fadeout(AudioSource audioobj, int bar)
	{
		/*while (audioobj.volume > 0.05F)
		{
			audioobj.volume = audioobj.volume - 0.00005F;	
		}
		*/
		while ( (audioobj.timeSamples % (bar*22050)) < ((bar*22050)-2000) )
		{
			yield return new WaitForSeconds(0.3F);
		}
		audioobj.volume = 0.0F;
		yield return null;
	}
	
	IEnumerator fadeout2(AudioSource audioobj)
	{
		/*while (audioobj.volume > 0.05F)
		{
			audioobj.volume = audioobj.volume - 0.00005F;	
		}
		*/
		
		while  (audioobj.volume > 0.001F)
		{
			audioobj.volume = audioobj.volume * 0.75F;
			yield return new WaitForSeconds(0.3F);
		}
		audioobj.volume = 0.0F;
		yield return null;
	}
	
	IEnumerator fadein(AudioSource audioobj, float vol)
	{
		/*
		while (audioobj.volume < 0.2F)
		{
			audioobj.volume = audioobj.volume + 0.00005F;
		}
		*/
		while ( (audioobj.timeSamples % 22050) < 20000)
		{
			yield return new WaitForSeconds(0.3F);
		}
		audioobj.volume = vol;
		yield return null;
	}
	//
	
	void OnGUI()

	{

   		//GUI.Label(labelRect, "Bar: " + bar + "    Beat: " + beat + "    Meas: " + meas);
		GUI.Label(labelRect, "Num. bounces: " + nb.numbounces);
		if (kick.volume > 0.0F)
		{
			GUI.Label(labelsample1, "Kick sample: ON");
		}
		else
		{
			GUI.Label(labelsample1, "Kick sample: OFF");
		}
		
		if (hat.volume > 0.0F)
		{
			GUI.Label(labelsample2, "Hihat sample: ON");
		}
		else
		{
			GUI.Label(labelsample2, "Hihat sample: OFF");
		}
		
		if (pizzi1.volume > 0.0F)
		{
			GUI.Label(labelsample3, "Melody sample: ON");
		}
		else
		{
			GUI.Label(labelsample3, "Melody sample: OFF");
		}
		
		//GUI.Label(labelsample1, "Kick sample: " + nb.numbounces);
		
		//labelsample1
	}
	
}
