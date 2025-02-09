﻿using System;
using UnityEngine;
using System.Collections;

//Jsonに関する処理を行うクラス
[Serializable]
public class JsonFunc<T>
{
    public string query;
    public T topScoringIntent;

    public JsonFunc(string query, T topScoringIntent)
    {
        this.query = query;
        this.topScoringIntent = topScoringIntent;
        //Debug.Log("FromJson:" + this.data);
    }
}

/*[Serializable]
public class Meta
{
    public string typeName;
    public Meta(string typeName) { this.typeName = typeName; }
}*/

[Serializable]
public class Queries
{
    public string intent;
    public double score;
    //public int score;

    public Queries(string intent, double score) //ここのintentとかはluisの要素と一緒
    {
        this.intent = intent;
        this.score = score;
    }
}
