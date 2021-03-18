using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WordGenerator : MonoBehaviour
{
    public static int test;



    private static string[] wordList = {"DNA", "lähetti-RNA", "urasiili", "riboosi", "lokus", "geeni", "alleeleita", "dominoiva",
    "resessiivinen","heterotsygoottina", "homotsygoottina", "autosomissa", "resessiivisesti", "dominoivasti", "Autosomissa resessiiviselle", 
     "Epätydellisessä penetranssissa", "dominoivasti","lyonisaatiosta", "pojat", "tyttäret", "miehillä", "resessiivisesti X-kromosomissa", "RNA",
    "mallijuostetta", "transkriptiotekijöitä", "promoottori", "25’ -> 3’", "5’CAP", "poly-A", "intronit", "spliseosomin","eksoneista",
    "vaihtoehtoiseksi", "Lähetti", "translaatiossa", "ribosomilla", "antikodonillaan", "kodoniin", "aminohappo","E","Lopetuskodoni",
    "Säätelyalueen", "patogeenisia", "ituradassa", "aktivoiva", "inaktivoiva", "insertio", "deleetio", "substituutio", "Translokaatio",
    "insertiot","deleetiot", "toistojaksoiksi", "mikrosatelliitit", "sisarkromatidia", "Glykosylaasiproteiinit", "emäksenkorjauksessa",
    "nukleotidinpoistokorjaus", "geeni-informaatiota", "Mismatch-repair", "MLH1", "PMS2", "synteesivaiheessa", "sykliinit", "CDK",
    "pysähtyy", "apoptoosin", "G1-S-tarkistuspisteellä", "Replikaation", "sykliinin","pRb", "E2F", "P53", "inaktivoivaa", "G2-M-tarkastuspisteellä",
    //ylimääräiset sanat:
    "G1-S-tarkistuspisteellä", "E2F", "P53"
    };

    private static string[] wordList2 = { "karsinogeeneistä", "resessiivisesti"," polypoosille", "onkogeeni", "G1", "Portinvartijageeni",
    "apoptoosin", "geneettinen", "mutaation", "kaksi", "mutaatiota", "Perinnöllisessä", "ituradassa", "aktivoiva",
    "onkogeeniksi", "edistävien", "dominoivasti", "alleelin", "MET", "rintasyövän", "Kasvunrajoitegeenit", "onkogeenit",
    "inaktivoiva", "alleelien", "resessiivisesti", "vallitsevasti", "yksi", "APC", "portinvartijoita",
    "Kasvuympäristöön", "SMAD4", "Kasvuympäristöä", "paksusuolisyövän", "huoltogeenit", "stabiliteettia", "Huoltojoukkogeenien",
    "kasvunrajoitegeeneissä","Genominen instabiliteetti", "valintaetu", "mutaatioiden", "kasvunrajoitegeenien", "driver",
    "valintaedun", "Passenger", "Passenger", "driver", "enemmän", "kromosomitason", "mikrosatelliitti-instabiliteetti", "pituusvaihteluna",
    "Mismatch-repair", "15 %", "periytyvää", "yhdelle", "P53", "rinta","sukupuuta",
    "geenitestillä", "dominoivia", "penetranssi", "Negatiivinen", "rintasyöpä", "10-15%", "perinnöllisestä", "5–10 %", "BRCA 1",
    "yli 50 %", "Suuren", "BRCA 1", "BRCA 2", "munasarjasyövän", "rintojen", "munasarjojen"," 5 %",
    "APC", "polyypin", "perä- ja paksusuolisyöpäalttiutta", "polypoottisiin", "familiaaliseen adenomatoottiseen polypoosiin", "100 %",
    "Lynchin", "mismatch-repair", "MLH1", "PMS2", "polyyppien", "nopeutunut", "paksusuolisyöpä", "noin 20 vuotta","kolonoskopia",
    //ylimääräiset:
    "geenitestillä", "mikrosatelliitti", "insertiot"
    };




    public static string GetRandomWord ()
    {
        if (SceneManager.GetActiveScene().name == "FirstRound")
        {
            //kasvattamalla viimeistä numeroa lisäät ruudulle tulevien sanojen vaihtoehtojen määrää, HUOM wordList lopusta pitää
        //löytyä ylimääräisä sanoja yhtä monta kuin tässä kasvatetaan
        int randomIndex = Random.Range(Answer.sentencenumb/2, Answer.sentencenumb/2+3);
        string randomWord = wordList[randomIndex];

        Debug.Log(Answer.randomizer);

        return randomWord;
        }

        else
        {
               //kasvattamalla viimeistä numeroa lisäät ruudulle tulevien sanojen vaihtoehtojen määrää, HUOM wordList lopusta pitää
        //löytyä ylimääräisä sanoja yhtä monta kuin tässä kasvatetaan
        int randomIndex = Random.Range(Answer2.sentencenumb/2, Answer2.sentencenumb/2+3);
        string randomWord = wordList2[randomIndex];

        return randomWord;

        }

    }

    void Update()
    {
        test = Answer.randomizer;
    }

    void Start() 
    {

    }
}
