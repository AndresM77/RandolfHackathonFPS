using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour {

	public enum spawnState {SPAWNING, WAITING, COUNTING};

	[System.Serializable]
	public class Wave 
	{
		public string name;
		public int count;
		public Transform enemy;
		public float rate;
	}

	public Wave[] waves;
	private int nextWave = 0;

	public float timeBetweenWaves = 5;
	public float waveCountdown = 0;

	private spawnState state = spawnState.COUNTING;

	void Start() 
	{
		waveCountdown = timeBetweenWaves;

	}

	void Update() 
	{
		if (waveCountdown <= 0) 
		{
			if (state != spawnState.SPAWNING) 
			{
				//start spawning wave
				StartCoroutine(SpawnWave(waves[nextWave]));
			}
		} else 
		{
			waveCountdown -= Time.deltaTime;
		}
	}

	IEnumerator SpawnWave(Wave _wave) 
	{
		//spawning
		state = spawnState.SPAWNING;

		for (int i = 0; i < _wave.count; i++) 
		{
			SpawnEnemy (_wave.enemy);
		}
		//waiting
		state = spawnState.WAITING;
		yield break;
	}

	void SpawnEnemy (Transform _enemy) 
	{
		//spawning enemy
		Debug.Log("Spawning enemy: " + _enemy.name);
	}

}
