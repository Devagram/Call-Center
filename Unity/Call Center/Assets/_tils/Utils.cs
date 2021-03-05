using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public static class Utils 
{
	public static bool IsPlayerOrPickup(this Collision2D collision2D)=>
		 (collision2D.collider.CompareTag("Player") 
		|| collision2D.collider.CompareTag("Jar") 
		|| collision2D.collider.CompareTag("Soul") 
		|| collision2D.collider.CompareTag("Pickup"));


	public static bool IsPickup(this Collider2D collision2D) =>
		(collision2D.CompareTag("Jar")
		|| collision2D.CompareTag("Soul")
		|| collision2D.CompareTag("Pickup"));

	public static void ChangeLayersRecursively(this Transform trans, string name,Transform ignore)
	{
		trans.gameObject.layer = LayerMask.NameToLayer(name);
		foreach (Transform child in trans)
		{
			if (child == ignore) continue;
			child.ChangeLayersRecursively(name, ignore);
		}
	}

	public static void SetAudioGropVolume(UnityEngine.Audio.AudioMixer target, float value, string volumeParameter)
	{
		float volume = Mathf.Clamp01(value);
		if (volume > 0f)
			volume = 45 * Mathf.Log10(volume);
		else
			volume = -144f;
		target.SetFloat(volumeParameter, volume);
	}


	public static bool IsNullOrEmpty<T>(this T[] array)=> array == null || array.Length< 1;

	public static bool IsNullOrEmpty<T>(this List<T> list) => list == null || list.Count < 1;

	public static bool IsNullOrEmpty<T>(this Queue<T> queue)=> queue == null || queue.Count < 1;

	public static bool IsNullOrEmpty<T1, T2>(this Dictionary<T1, T2> dictionary)=> dictionary == null || dictionary.Count < 1;

	public static AudioSource CreateAudioSource(Transform parent)
	{
		GameObject tempAudioSource = new GameObject("UniqueAudioSource");
		tempAudioSource.transform.parent = parent.transform;
		tempAudioSource.transform.position = Vector3.zero;
		return tempAudioSource.AddComponent<AudioSource>();
	}
	public static void Resize<T>(this List<T> list, int size, T element = default(T))
	{
		int count = list.Count;

		if (size < count)
		{
			list.RemoveRange(size, count - size);
		}
		else if (size > count)
		{
			if (size > list.Capacity)
				list.Capacity = size;

			list.AddRange(System.Linq.Enumerable.Repeat(element, size - count));
		}
	}

}
