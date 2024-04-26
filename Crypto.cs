using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Crypto
{
    public string id;
    public string rank;
    public string symbol;
    public string name;
    public string supply;
    public string maxSupply;
    public string marketCapUsd;
    public string volumeUsd24Hr;
    public string priceUsd;
    public string changePercent24Hr;
    public string vwap24Hr;
    public string explorer;

    public Crypto(string id, string rank, string symbol, string name, string supply, string maxSupply, string marketCapUsd, string volumeUsd24Hr, string priceUsd, string changePercent24Hr, string vwap24Hr, string explorer)
    {
        this.id = id;
        this.rank = rank;
        this.symbol = symbol;
        this.name = name;
        this.supply = supply;
        this.maxSupply = maxSupply;
        this.marketCapUsd = marketCapUsd;
        this.volumeUsd24Hr = volumeUsd24Hr;
        this.priceUsd = priceUsd;
        this.changePercent24Hr = changePercent24Hr;
        this.vwap24Hr = vwap24Hr;
        this.explorer = explorer;
    }
}



public class CryptoReader : MonoBehaviour
{
    void Start()
    {
       
        string filePath = "CryptoPath.json"; 
        string jsonText = File.ReadAllText(filePath);

       
        List<Crypto> cryptoList = JsonUtility.FromJson<List<Crypto>>(jsonText);

       
        foreach (Crypto crypto in cryptoList)
        {
            Debug.Log("Crypto ID: " + crypto.id);
            Debug.Log("Rank: " + crypto.rank);
            Debug.Log("Symbol: " + crypto.symbol);
            Debug.Log("Name: " + crypto.name);
            Debug.Log("Supply: " + crypto.supply);
            Debug.Log("Max Supply: " + crypto.maxSupply);
            Debug.Log("Market Cap (USD): " + crypto.marketCapUsd);
            Debug.Log("Volume (USD, 24Hr): " + crypto.volumeUsd24Hr);
            Debug.Log("Price (USD): " + crypto.priceUsd);
            Debug.Log("Change Percent (24Hr): " + crypto.changePercent24Hr);
            Debug.Log("VWAP (24Hr): " + crypto.vwap24Hr);
            Debug.Log("Explorer: " + crypto.explorer);
        }
    }
}

