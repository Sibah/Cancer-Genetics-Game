using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordGenerator : MonoBehaviour
{
    private static string[] wordList = {"DNA", "lähetti-RNA", "urasiili", "riboosi", "lokus", "geeni", "alleeleita", "dominoiva",
    "resessiivinen","heterotsygoottina", "homotsygoottina", "autosomissa", "resessiivisesti", "dominoivasti", "Autosomissa resessiiviselle", 
    "25%", "Epätydellisessä penetranssissa", "dominoivasti","lyonisaatiosta", "pojat", "tyttäret", "miehillä", "resessiivisesti X-kromosomissa", "RNA",
    "mallijuostetta", "transkriptiotekijöitä", "promoottori", "25’ -> 3’", "5’CAP", "poly-A", "intronit", "spliseosomin","eksoneista",
    "vaihtoehtoiseksi", "Lähetti", "translaatiossa", "ribosomilla", "antikodonillaan", "kodoniin", "aminohappo","E","Lopetuskodoni",
    "2answer1", "2answer2", "2answer3"};




    public static string GetRandomWord ()
    {
        //kasvattamalla viimeistä numeroa lisäät ruudulle tulevien sanojen vaihtoehtojen määrää
        int randomIndex = Random.Range(Answer.sentencenumb/2, Answer.sentencenumb/2+4);
        string randomWord = wordList[randomIndex];

        return randomWord;

    }

    void Update()
    {
    }
}
