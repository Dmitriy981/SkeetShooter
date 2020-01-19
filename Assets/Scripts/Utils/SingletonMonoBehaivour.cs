using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonMonoBehaivour<T> : MonoBehaviour where T : Component, new()
{
	protected static Lazy<T> instance = new Lazy<T>(() => CreateGameObject());

	public static T Instance { get { return instance.Value; } }

	public static T CreateGameObject()
	{
		GameObject existed = GameObject.Find(typeof(T).Name);
		T result = null;

		if (existed == null)
		{
			GameObject go = new GameObject(typeof(T).Name);

			DontDestroyOnLoad(go);
			result = go.AddComponent<T>();
		}
		else
		{
			result = existed.GetComponent<T>();
		}

		return result;
	}
}
