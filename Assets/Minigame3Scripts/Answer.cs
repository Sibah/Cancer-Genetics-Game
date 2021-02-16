using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Answer : MonoBehaviour
{
    public Text answerText;
    public static int answernumb;
    public Text sentence;
    public static int sentencenumb;
    public Text pressedText;
    public Text wrongText;

    
    

    public static string[] sentenceList = {"Transkriptiossa <color=yellow>?</color> :n sisältämä geneettinen informaatio kopioidaan <color=yellow>?</color>:ksi",
    "Transkriptiossa <color=green>DNA</color> :n sisältämä geneettinen informaatio kopioidaan <color=yellow>?</color>:ksi",

    "Transkriptiossa DNA:n sisältämä geneettinen informaatio kopioidaan <color=yellow>?</color>:ksi ", "Transkriptiossa DNA:n sisältämä geneettinen informaatio kopioidaan <color=green>lähetti-RNA:ksi</color>",

    "Erona Dna:han RNA:ssa on tymiini paikalla <color=yellow>?</color> sekä sokeriosana deoksiriboosin paikalla <color=yellow>?</color>", "Erona Dna:han RNA:ssa on tymiini sijasta <color=green>urasiili</color> sekä sokeriosana deoksiriboosin sijasta <color=yellow>?</color>", 

    "Erona Dna:han RNA:ssa on tymiini paikalla urasiili sekä sokeriosana deoksiriboosin paikalla <color=yellow>?</color>", "Erona Dna:han RNA:ssa on tymiini sijasta urasiili sekä sokeriosana deoksiriboosin sijasta <color=green>riboosi</color>",

    "<color=yellow>?</color> on geenin paikka kromosomissa", "<color=green>Lokus</color> on geenin paikka kromosomissa",

    "<color=yellow>?</color> on osa DNA:ta ja yksilöillä on siitä eri muotoja, <color=yellow>?</color> ","<color=green>Geeni</color> on osa DNA:ta ja yksilöillä on siitä eri muotoja, <color=yellow>?</color>",

    "Geeni on osa DNA:ta ja yksilöillä on siitä eri muotoja, <color=yellow>?</color>", "Geeni on osa DNA:ta ja yksilöillä on siitä eri muotoja, <color=green>alleeleita</color>",

    "Alleeli voi olla joko <color=yellow>?</color> tai <color=yellow>?</color> ja se voi ilmentyä joko <color=yellow>?</color> tai <color=yellow>?</color>", "Alleeli voi olla joko <color=green>dominoiva</color> tai <color=yellow>?</color> ja se voi ilmentyä joko <color=yellow>?</color> tai <color=yellow>?</color>",
    
    "Alleeli voi olla joko dominoiva tai <color=yellow>?</color> ja se voi ilmentyä joko <color=yellow>?</color> tai <color=yellow>?</color>", "Alleeli voi olla joko dominoiva tai <color=green>resessiivinen</color> ja se voi ilmentyä joko <color=yellow>?</color> tai <color=yellow>?</color>",

    "Alleeli voi olla joko dominoiva tai resessiivinen ja se voi ilmentyä joko <color=yellow>?</color> tai <color=yellow>?</color>", "Alleeli voi olla joko dominoiva tai resessiivinen ja se voi ilmentyä joko <color=green>heterotsygoottina</color> tai <color=yellow>?</color>",

    "Alleeli voi olla joko dominoiva tai resessiivinen ja se voi ilmentyä joko heterotsygoottina tai <color=yellow>?</color>", "Alleeli voi olla joko dominoiva tai resessiivinen ja se voi ilmentyä joko heterotsygoottina tai <color=green>homotsygoottina</color>",

    "Yleensä lapsen, joka sairastaa <color=yellow>?</color> <color=yellow>?</color> periytyvää sairautta vanhemmat ovat terveitä kantajia", "Yleensä lapsen, joka sairastaa <color=green>autosomissa</color> <color=yellow>?</color> periytyvää sairautta vanhemmat ovat terveitä kantajia",
    
    "Yleensä lapsen, joka sairastaa autosomissa <color=yellow>?</color> periytyvää sairautta vanhemmat ovat terveitä kantajia", "Yleensä lapsen, joka sairastaa autosomissa <color=green>resessiivisesti</color> periytyvää sairautta vanhemmat ovat terveitä kantajia",

    "Riittää, että toisessa alleelissa on sairauden aiheuttava mutaatio, jos sairaus periytyy <color=yellow>?</color>", "Riittää, että toisessa alleelissa on sairauden aiheuttava mutaatio, jos sairaus periytyy <color=green>dominoivasti</color>",

    "<color=yellow>?</color> geenille on tyypillistä sukupolven yli hyppääminen ja sairaan henkilön lapset sairastuvat <color=yellow>?</color> todennäköisyydellä", "<color=green>Autosomissa resessiiviselle</color> geenille on tyypillistä sukupolven yli hyppääminen ja sairaan henkilön lapset sairastuvat <color=yellow>?</color> todennäköisyydellä",

    "Autosomissa resessiiviselle geenille on tyypillistä sukupolven yli hyppääminen ja sairaan henkilön lapset sairastuvat <color=yellow>?</color> todennäköisyydellä", "Autosomissa resessiiviselle geenille on tyypillistä sukupolven yli hyppääminen ja sairaan henkilön lapset sairastuvat <color=green>25%</color> todennäköisyydellä",

    "<color=yellow>?</color> dominoivan geenin aiheuttaman sairauden oireet eivät tule esille fenotyypissä", "<color=green>Epätydellisessä penetranssissa</color> dominoivan geenin aiheuttaman sairauden oireet eivät tule esille fenotyypissä",

    "X-kromosomissa <color=yellow>?</color> periytyvä tauti voi olla naisilla lievempi oireinen johtuen <color=yellow>?</color>", "X-kromosomissa <color=green>dominoivasti</color> periytyvä tauti voi olla naisilla lievempi oireinen johtuen <color=yellow>?</color>",

    "X-kromosomissa dominoivasti periytyvä tauti voi olla naisilla lievempi oireinen johtuen <color=yellow>?</color>", "X-kromosomissa dominoivasti periytyvä tauti voi olla naisilla lievempi oireinen johtuen <color=green>lyonisaatiosta</color>",

    "Sairaan miehen <color=yellow>?</color> ovat terveitä, mutta kaikki <color=yellow>?</color> sairastuvat, jos kyseessä on X-kromosomissa dominoivasti periytyvä sairaus" , "Sairaan miehen <color=green>pojat</color> ovat terveitä, mutta kaikki <color=yellow>?</color> sairastuvat, jos kyseessä on X-kromosomissa dominoivasti periytyvä sairaus",

    "Sairaan miehen pojat ovat terveitä, mutta kaikki <color=yellow>?</color> sairastuvat, jos kyseessä on X-kromosomissa dominoivasti periytyvä sairaus", "Sairaan miehen pojat ovat terveitä, mutta kaikki <color=green>tyttäret</color> sairastuvat, jos kyseessä on X-kromosomissa dominoivasti periytyvä sairaus",

    "Resessiivisesti X-kromosomissa periytyvä sairaus esiintyy lähes pelkästään <color=yellow>?</color>", "Resessiivisesti X-kromosomissa periytyvä sairaus esiintyy lähes pelkästään <color=green>miehillä</color>",

    "Sairaan pojan äiti on kantaja <color=yellow>?</color> periytyvässä sairaudessa", "Sairaan pojan äiti on kantaja <color=green>resessiivisesti X-kromosomissa</color> periytyvässä sairaudessa",

    "Transkriptiossa <color=yellow>?</color>-polymeraasi kopioi DNA:n <color=yellow>?</color> RNA:ksi", "Transkriptiossa <color=green>RNA</color>-polymeraasi kopioi DNA:n <color=yellow>?</color> RNA:ksi",

    "Transkriptiossa RNA-polymeraasi kopioi DNA:n <color=yellow>?</color> RNA:ksi", "Transkriptiossa RNA-polymeraasi kopioi DNA:n <color=green>mallijuostetta</color> RNA:ksi",

    "RNA-polymeraasi tarvitsee <color=yellow>?</color> sitoutuakseen <color=yellow>?</color> alueelle ja aloittaakseen transkription", "RNA-polymeraasi tarvitsee <color=green>transkriptiotekijöitä</color> sitoutuakseen <color=yellow>?</color> alueelle ja aloittaakseen transkription",

    "RNA-polymeraasi tarvitsee transkriptiotekijöitä sitoutuakseen <color=yellow>?</color> alueelle ja aloittaakseen transkription", "RNA-polymeraasi tarvitsee transkriptiotekijöitä sitoutuakseen <color=green>promoottori</color> alueelle ja aloittaakseen transkription",

    "RNA-polymeraasi lisää emäksiä <color=yellow>?</color> suuntaan", "RNA-polymeraasi lisää emäksiä <color=green>5’ -> 3’</color> suuntaan",

    "RNA:n siirtymiselle tumaan on välttämätöntä, että siihen lisätään <color=yellow>?</color> ja <color=yellow>?</color> -häntä", "RNA:n siirtymiselle tumaan on välttämätöntä, että siihen lisätään <color=green>5’CAP</color> ja <color=yellow>?</color> -häntä",

    "RNA:n siirtymiselle tumaan on välttämätöntä, että siihen lisätään 5’CAP ja <color=yellow>?</color> -häntä", "RNA:n siirtymiselle tumaan on välttämätöntä, että siihen lisätään 5’CAP ja <color=green>poly-A</color> -häntä",

    "RNA:ta muokataan silmukoinnissa, jossa siitä poistetaan <color=yellow>?</color> <color=yellow>?</color> toimesta", "RNA:ta muokataan silmukoinnissa, jossa siitä poistetaan <color=green>intronit</color> <color=yellow>?</color> toimesta",

    "RNA:ta muokataan silmukoinnissa, jossa siitä poistetaan intronit <color=yellow>?</color> toimesta", "RNA:ta muokataan silmukoinnissa, jossa siitä poistetaan intronit <color=green>spliseosomin</color> toimesta",

    "Silmukoinnissa voidaan lisätä geneettistä vaihtelua poistamalla osa <color=yellow>?</color>, tätä kutsutaan <color=yellow>?</color> silmukoinniksi", "Silmukoinnissa voidaan lisätä geneettistä vaihtelua poistamalla osa <color=green>eksoneista</color>, tätä kutsutaan <color=yellow>?</color> silmukoinniksi",

    "Silmukoinnissa voidaan lisätä geneettistä vaihtelua poistamalla osa eksoneista, tätä kutsutaan <color=yellow>?</color> silmukoinniksi", "Silmukoinnissa voidaan lisätä geneettistä vaihtelua poistamalla osa eksoneista, tätä kutsutaan <color=green>vaihtoehtoiseksi</color> silmukoinniksi",

    "<color=yellow>?</color>-RNA:sta tehdään valmis aminohappoketju <color=yellow>?</color>", "<color=green>Lähetti</color>-RNA:sta tehdään valmis aminohappoketju <color=yellow>?</color>",

    "Lähetti-RNA:sta tehdään valmis aminohappoketju <color=yellow>?</color>", "Lähetti-RNA:sta tehdään valmis aminohappoketju <color=green>translaatiossa</color>",

    "Siirtäjä-RNA tunnistaa <color=yellow>?</color> lähetti-RNA:n kodonin <color=yellow>?</color> ja samalla tuo spesifisen aminohapon ribosomille", "Siirtäjä-RNA tunnistaa <color=green>ribosomilla</color> lähetti-RNA:n kodonin <color=yellow>?</color> ja samalla tuo spesifisen aminohapon ribosomille",

    "Siirtäjä-RNA tunnistaa ribosomilla lähetti-RNA:n kodonin <color=yellow>?</color> ja samalla tuo spesifisen aminohapon ribosomille", "Siirtäjä-RNA tunnistaa ribosomilla lähetti-RNA:n kodonin <color=green>antikodonillaan</color> ja samalla tuo spesifisen aminohapon ribosomille",

    "Ribosomissa kohdassa A siirtäjä-RNA sitoutuu <color=yellow>?</color>, P:ssä <color=yellow>?</color> irtoaa ja <color=yellow>?</color>:ssä siirtäjä-RNA vapautuu", "Ribosomissa kohdassa A siirtäjä-RNA sitoutuu <color=green>kodoniin</color>, P:ssä <color=yellow>?</color> irtoaa ja <color=yellow>?</color>:ssä siirtäjä-RNA vapautuu",

    "Ribosomissa kohdassa A siirtäjä-RNA sitoutuu kodoniin, P:ssä <color=yellow>?</color> irtoaa ja <color=yellow>?</color>:ssä siirtäjä-RNA vapautuu", "Ribosomissa kohdassa A siirtäjä-RNA sitoutuu kodoniin, P:ssä <color=green>aminohappo</color> irtoaa ja <color=yellow>?</color>:ssä siirtäjä-RNA vapautuu",

    "Ribosomissa kohdassa A siirtäjä-RNA sitoutuu kodoniin, P:ssä aminohappo irtoaa ja <color=yellow>?</color>:ssä siirtäjä-RNA vapautuu", "Ribosomissa kohdassa A siirtäjä-RNA sitoutuu kodoniin, P:ssä aminohappo irtoaa ja <color=green>E</color>:ssä siirtäjä-RNA vapautuu",

    "<color=yellow>?</color> saa ribosomilla aikaan veden liittämisen peptidi ketjuun ja translaation loppumisen", "<color=green>Lopetuskodoni</color> saa ribosomilla aikaan veden liittämisen peptidi ketjuun ja translaation loppumisen"

     }; 



    private static string[] answers = {"DNA", "1",
    "lähetti-RNA", "2",
    "urasiili", "3",
    "riboosi", "4",
    "lokus", "5",
    "geeni", "6",
    "alleeleita", "7",
    "dominoiva", "8",
    "resessiivinen", "9",
    "heterotsygoottina", "10",
    "homotsygoottina", "11",
    "autosomissa", "12",
    "resessiivisesti", "13",
    "dominoivasti", "14",
    "Autosomissa resessiiviselle", "15",
    "25%", "16",
    "Epätydellisessä penetranssissa", "17",
    "dominoivasti", "18",
    "lyonisaatiosta", "19",
    "pojat", "20",
    "tyttäret", "21",
    "miehillä", "22",
    "resessiivisesti X-kromosomissa", "23",
    "RNA", "24",
    "mallijuostetta", "25",
    "transkriptiotekijöitä", "26",
    "promoottori", "27",
    "5’ -> 3’", "28",
    "5’CAP", "29",
    "poly-A", "30",
    "intronit", "31",
    "spliseosomin", "32",
    "eksoneista", "33",
    "vaihtoehtoiseksi", "34",
    "Lähetti", "35",
    "translaatiossa", "36",
    "ribosomilla", "37",
    "antikodonillaan", "38",
    "kodoniin", "39",
    "aminohappo", "40",
    "E", "41",
    "Lopetuskodoni" };



    // Start is called before the first frame update
    void Start()
    {
        sentencenumb = 0;
        answernumb = 1;
        answerText.text = answers[0];
        answerText.color = Color.black;
        wrongText.color = Color.black;

        sentence.text = sentenceList[0];
    }

    // Update is called once per frame
    void Update()
    {
        //if the clicked answer gives points the this will be done
        if (Score.scoreAmount == answernumb)
        {
            if (pressedText.text == answerText.text)
            {
                //answerText.color = Color.green;
                answernumb += 1;
                sentencenumb += 1;
                sentence.text = sentenceList[sentencenumb];
                sentencenumb +=1;
                
            }
            else
            {
                Score.scoreAmount -= 2;
                //answerText.color = Color.red;
                wrongText.color = Color.red;
                answernumb -= 1;
                sentencenumb +=2;
            }

            //update sentence and change answer back to black
            StartCoroutine(CoroutineChangeVariables());
        }
    }



    IEnumerator CoroutineChangeVariables()
{
    
    yield return new WaitForSeconds(1); // wait for 1 seconds

    //cheks if it was the last sentence of the array, if was returns to main screen
    //otherwise gives next sentence
    if (sentencenumb == sentenceList.Length)
    {
        
        SceneManager.LoadScene(0);
    }
    else
    {
        
        sentence.text = sentenceList[sentencenumb];
        //answerText.color = Color.black;
        wrongText.color = Color.black;
        answerText.text = answers[sentencenumb];
    
    }
}





}
