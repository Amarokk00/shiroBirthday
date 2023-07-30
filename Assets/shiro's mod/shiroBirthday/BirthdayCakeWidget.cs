﻿
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;

public class BirthdayCakeWidget : MonoBehaviour
{
    public string WIDGET_QUERY_KEY = "birthdaycake";
    public GameObject sprite;

    void Awake()
    {
        float randomScale = Random.Range(0.003f,0.01f);
		float randomRotation = Random.Range(-180f,180f);
        sprite.transform.localScale = new Vector3(randomScale,randomScale,1f);
		
		sprite.transform.rotation = Quaternion.Euler(90f,randomRotation,-randomRotation);
        GetComponent<KMWidget>().OnQueryRequest += GetQueryResponse;
    }

    public string GetQueryResponse(string queryKey, string queryInfo)
    {
        if(queryKey == WIDGET_QUERY_KEY)
        {
            Dictionary<string, int> response = new Dictionary<string, int>();
            string responseStr = JsonConvert.SerializeObject(response);
            return responseStr;
        }

        return "";
    }
}
