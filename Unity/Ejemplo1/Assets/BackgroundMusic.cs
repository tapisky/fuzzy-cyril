using UnityEngine;
using System.Collections;

public class BackgroundMusic : MonoBehaviour {
	
	private Rect labelRect;
	private AudioSource snare;
	private AudioSource kick;
	private AudioSource hat;
	private AudioSource pizzi1;
	private AudioSource pizzi2;
	private AudioSource pizzi3;
	private AudioSource sample;
	
	public CollisionBouncing nb;
	
	// Use this for initialization
	void Start () {
		
		labelRect = new Rect(0, 0, 200, 20);
		
		snare = GameObject.Find("snare").audio;
		snare.volume = 0.2F;
		
		kick = GameObject.Find("kick").audio;
		kick.volume = 0.0F;
		
		hat = GameObject.Find("hat").audio;
		hat.volume = 0.0F;

		pizzi1 = GameObject.Find("pizzi1").audio;
		pizzi1.volume = 0.0F;
		pizzi2 = GameObject.Find("pizzi2").audio;
		pizzi2.volume = 0.0F;
		pizzi3 = GameObject.Find("pizzi3").audio;
		pizzi3.volume = 0.0F;
				
		nb = GetComponent<CollisionBouncing>();

		
	}
	
	// Update is called once per frame
	void LateUpdate ()
	{
		
		if ( ((nb.numbounces % 4) == 0) && (nb.numbounces > 0)  || ( ( ((nb.numbounces % 4) >= 0) && ((nb.numbounces % 4) <= 1) ) && (nb.numbounces > 16)) )
		{
			StartCoroutine(fadein(kick,0.2F));
		}
		else
		{
			StartCoroutine(fadeout(kick));
		}
		
		if ( (nb.numbounces > 8) && ( ((nb.numbounces % 4) == 0) || ((nb.numbounces % 4) == 1) ) )
		{
			StartCoroutine(fadein(hat,0.1F));
		}
		else
		{
			StartCoroutine(fadeout(hat));
		}
		//print ("Samples mod 22050: " + (hat.timeSamples % 22050));
		
		if (nb.numbounces > 20)
		{
			
			StartCoroutine(playscheduled(pizzi1));
		}
		
		
		if (nb.numbounces > 40)
		{
			StartCoroutine(stopscheduled(pizzi1));
			StartCoroutine(playscheduled(pizzi2));
		}
		
		if (nb.numbounces == 60)
		{
			nb.numbounces = 15;
			
		}
	}
	
	IEnumerator playscheduled(AudioSource audioobj)
	{
		
		yield return new WaitForSeconds(audioobj.clip.length - audioobj.time - 0.1F);
		audioobj.volume = 0.08F;
		yield return null;
	}
	
	IEnumerator stopscheduled(AudioSource audioobj)
	{
		
		yield return new WaitForSeconds(audioobj.clip.length - audioobj.time - 0.1F);
		audioobj.volume = 0.0F;
		yield return null;
	}
	
	
	IEnumerator fadeout(AudioSource audioobj)
	{
		/*while (audioobj.volume > 0.05F)
		{
			audioobj.volume = audioobj.volume - 0.00005F;	
		}
		*/
		while ( (audioobj.timeSamples % 22050) < 20000)
		{
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
	
	void OnGUI()

	{

   		//GUI.Label(labelRect, "Bar: " + bar + "    Beat: " + beat + "    Meas: " + meas);
		GUI.Label(labelRect, "Num. bounces: " + nb.numbounces);
		

	}
	
}
