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
    public static int randomizer;
    public static int stopNumber;

    
    

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

    "<color=yellow>?</color> geenille on tyypillistä sukupolven yli hyppääminen", "<color=green>Autosomissa resessiiviselle</color> geenille on tyypillistä sukupolven yli hyppääminen",

    "<color=yellow>?</color> dominoivan geenin aiheuttaman sairauden oireet eivät tule esille fenotyypissä", "<color=green>Epätydellisessä penetranssissa</color> dominoivan geenin aiheuttaman sairauden oireet eivät tule esille fenotyypissä",

    "X-kromosomissa <color=yellow>?</color> periytyvä tauti voi olla naisilla lievempi oireinen johtuen <color=yellow>?</color>", "X-kromosomissa <color=green>dominoivasti</color> periytyvä tauti voi olla naisilla lievempi oireinen johtuen <color=yellow>?</color>",

    "X-kromosomissa dominoivasti periytyvä tauti voi olla naisilla lievempi oireinen johtuen <color=yellow>?</color>", "X-kromosomissa dominoivasti periytyvä tauti voi olla naisilla lievempi oireinen johtuen <color=green>lyonisaatiosta</color>",

    "Sairaan miehen <color=yellow>?</color> ovat terveitä, mutta yleensä kaikki <color=yellow>?</color> sairastuvat, jos kyseessä on X-kromosomissa dominoivasti periytyvä sairaus" , "Sairaan miehen <color=green>pojat</color> ovat terveitä, mutta yleensä kaikki <color=yellow>?</color> sairastuvat, jos kyseessä on X-kromosomissa dominoivasti periytyvä sairaus",

    "Sairaan miehen pojat ovat terveitä, mutta yleensä kaikki <color=yellow>?</color> sairastuvat, jos kyseessä on X-kromosomissa dominoivasti periytyvä sairaus", "Sairaan miehen pojat ovat terveitä, mutta yleensä kaikki <color=green>tyttäret</color> sairastuvat, jos kyseessä on X-kromosomissa dominoivasti periytyvä sairaus",

    "Resessiivisesti X-kromosomissa periytyvä sairaus esiintyy lähes pelkästään <color=yellow>?</color>", "Resessiivisesti X-kromosomissa periytyvä sairaus esiintyy lähes pelkästään <color=green>miehillä</color>",

    "Sairaan pojan äiti on yleensä terve kantaja <color=yellow>?</color> periytyvässä sairaudessa", "Sairaan pojan äiti on yleensä terve kantaja <color=green>resessiivisesti X-kromosomissa</color> periytyvässä sairaudessa",

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

    "<color=yellow>?</color> saa ribosomilla aikaan veden liittämisen peptidi ketjuun ja translaation loppumisen", "<color=green>Lopetuskodoni</color> saa ribosomilla aikaan veden liittämisen peptidi ketjuun ja translaation loppumisen",

    "<color=yellow>?</color> sekä proteiinia koodaavan osan mutaatiot ovat useimmiten <color=yellow>?</color>", "<color=green>Säätelyalueen</color> sekä proteiinia koodaavan osan mutaatiot ovat useimmiten <color=yellow>?</color>",

    "Säätelyalueen sekä proteiinia koodaavan osan mutaatiot ovat useimmiten <color=yellow>?</color>", "<color=green>Säätelyalueen</color> sekä proteiinia koodaavan osan mutaatiot ovat useimmiten <color=green>patogeenisia</color>",

    "Suvussa eteenpäin periytyvät mutaatiot tapahtuvat <color=yellow>?</color>", "Suvussa eteenpäin periytyvät mutaatiot tapahtuvat <color=green>ituradassa</color>",

    "Geenin toimintaa lisää <color=yellow>?</color> mutaatio ja toimintaa hiljentää <color=yellow>?</color> mutaatio", "Geenin toimintaa lisää <color=green>aktivoiva</color> mutaatio ja toimintaa hiljentää <color=yellow>?</color> mutaatio",

    "Geenin toimintaa lisää aktivoiva mutaatio ja toimintaa hiljentää <color=yellow>?</color> mutaatio", "Geenin toimintaa lisää aktivoiva mutaatio ja toimintaa hiljentää <color=green>inaktivoiva</color> mutaatio",

    "Emäksen lisäys eli <color=yellow>?</color>, emäksen häviämä eli <color=yellow>?</color> ja emäksen vaihdos eli <color=yellow>?</color> ovat esimerkkejä mutaatioista", "Emäksen lisäys eli <color=green>insertio</color>, emäksen häviämä eli <color=yellow>?</color> ja emäksen vaihdos eli <color=yellow>?</color> ovat esimerkkejä mutaatioista",

    "Emäksen lisäys eli insertio, emäksen häviämä eli <color=yellow>?</color> ja emäksen vaihdos eli <color=yellow>?</color> ovat esimerkkejä mutaatioista", "Emäksen lisäys eli insertio, emäksen häviämä eli <color=green>deleetio</color> ja emäksen vaihdos eli <color=yellow>?</color> ovat esimerkkejä mutaatioista",

    "Emäksen lisäys eli insertio, emäksen häviämä eli deleetio ja emäksen vaihdos eli <color=yellow>?</color> ovat esimerkkejä mutaatioista", "Emäksen lisäys eli insertio, emäksen häviämä eli deleetio ja emäksen vaihdos eli <color=green>substituutio</color> ovat esimerkkejä mutaatioista",

    "<color=yellow>?</color> vaihtaa kahden DNA-jakson paikan keskenään tai siirtää DNA-jakson muualle", "<color=green>Translokaatio</color> vaihtaa kahden DNA-jakson paikan keskenään tai siirtää DNA-jakson muualle",

    "Geenin lukukehystä muuttavia mutaatioita ovat varsinkin <color=yellow>?</color> ja <color=yellow>?</color>", "Geenin lukukehystä muuttavia mutaatioita ovat varsinkin <color=green>insertiot</color> ja <color=yellow>?</color>",

    "Geenin lukukehystä muuttavia mutaatioita ovat varsinkin insertiot ja <color=yellow>?</color>", "Geenin lukukehystä muuttavia mutaatioita ovat varsinkin insertiot ja <color=green>deleetiot</color>",

    "DNA-pätkiä, jotka toistuvat useasti peräkkäin kutsutaan <color=yellow>?</color>", "DNA-pätkiä, jotka toistuvat useasti peräkkäin kutsutaan <color=green>toistojaksoiksi</color>",

    "Yleisimpiä toistojaksoja ovat <color=yellow>?</color>", "Yleisimpiä toistojaksoja ovat <color=green>mikrosatelliitit</color>",

    "Homologisessa rekombinaatiossa DNA juosteiden korjauksen mallina käytetään <color=yellow>?</color>", "Homologisessa rekombinaatiossa DNA juosteiden korjauksen mallina käytetään <color=green>sisarkromatidia</color>",

    "<color=yellow>?</color> ovat emäsvauriotyypille spesifisiä proteiineja, joita käytetään <color=yellow>?</color>", "<color=green>Glykosylaasiproteiinit</color> ovat emäsvauriotyypille spesifisiä proteiineja, joita käytetään <color=yellow>?</color>", 

    "Glykosylaasiproteiinit ovat emäsvauriotyypille spesifisiä proteiineja, joita käytetään <color=yellow>?</color>", "Glykosylaasiproteiinit ovat emäsvauriotyypille spesifisiä proteiineja, joita käytetään <color=green>emäksenkorjauksessa</color>",

    "Useamman emäksen puutoksia ja DNA:n kaksoiskierrerakennetta vääristäviä rakennemuutoksia korjaa <color=yellow>?</color>", "Useamman emäksen puutoksia ja DNA:n kaksoiskierrerakennetta vääristäviä rakennemuutoksia korjaa <color=green>nukleotidinpoistokorjaus</color>",

    "DNA:n korjausmekanismeista ei-homologisten päiden yhdistämisellä saatetaan menettää <color=yellow>?</color>", "DNA:n korjausmekanismeista ei-homologisten päiden yhdistämisellä saatetaan menettää <color=green>geeni-informaatiota</color>",

    "<color=yellow>?</color> tunnistaa replikaation virheet sekä muutaman emäksen insertiot ja deleetiot ja korjaa ne", "<color=green>Mismatch-repair</color> tunnistaa replikaation virheet sekä muutaman emäksen insertiot ja deleetiot ja korjaa ne",

    "Replikaatiovirheen sisältävän juosteen purkamisen aloittaa MutLa proteiinikompleksi, joka sisältää geenien <color=yellow>?</color> tai <color=yellow>?</color> proteiinituotteet", "Replikaatiovirheen sisältävän juosteen purkamisen aloittaa MutLa proteiinikompleksi, joka sisältää geenit <color=green>MLH1</color> tai <color=yellow>?</color> proteiinituotteet",

    "Replikaatiovirheen sisältävän juosteen purkamisen aloittaa MutLa proteiinikompleksi, joka sisältää geenien MLH1 tai <color=yellow>?</color> proteiinituotteet", "Replikaatiovirheen sisältävän juosteen purkamisen aloittaa MutLa proteiinikompleksi, joka sisältää geenit MLH1 tai <color=green>PMS2</color> proteiinituotteet",

    "Solusyklin <color=yellow>?</color> mismatch-repair systeemin aktivaatio on suurinta", "Solusyklin <color=green>synteesivaiheessa</color> mismatch-repair systeemin aktivaatio on suurinta",

    "Solusyklin säätelyn kannalta tärkeimmät proteiinit ovat <color=yellow>?</color> ja <color=yellow>?</color>:t", "Solusyklin säätelyn kannalta tärkeimmät proteiinit ovat <color=green>sykliinit</color> ja <color=yellow>?</color>:t",

    "Solusyklin säätelyn kannalta tärkeimmät proteiinit ovat sykliinit ja <color=yellow>?</color>:t", "Solusyklin säätelyn kannalta tärkeimmät proteiinit ovat sykliinit ja <color=green>CDK</color>:t",

    "Solu <color=yellow>?</color> solusyklin vaiheeseen korjaamaan virheitään, jos se ei ole mahdollista aktivoi solu <color=yellow>?</color>", "Solu <color=green>pysähtyy</color> solusyklin vaiheeseen korjaamaan virheitään, jos se ei ole mahdollista aktivoi solu <color=yellow>?</color>",

    "Solu pysähtyy solusyklin vaiheeseen korjaamaan virheitään, jos se ei ole mahdollista aktivoi solu <color=yellow>?</color>", "Solu pysähtyy solusyklin vaiheeseen korjaamaan virheitään, jos se ei ole mahdollista aktivoi solu <color=green>apoptoosin</color>",

    "<color=yellow>?</color> tarkastetaan, että solu on kasvanut tarpeeksi, sillä on ravinteita ja DNA:ssa ei ole vaurioita", "<color=green>G1-S-tarkistuspisteellä</color> tarkastetaan, että solu on kasvanut tarpeeksi, sillä on ravinteita ja DNA:ssa ei ole vaurioita",

    "<color=yellow>?</color> onnistuminen sekä DNA vauriot tarkastetaan G2-M-tarkistuspisteellä", "<color=green>Replikaation</color> onnistuminen sekä DNA vauriot tarkastetaan G2-M-tarkistuspisteellä",

    "Tarkastuspisteellä <color=yellow>?</color> sitoutuminen CDK:hon aiheuttaa <color=yellow>?</color>:n irtoamisen <color=yellow>?</color> transkriptiotekijästä, joka mahdollistaa tarkastuspisteen ohittamisen", "Tarkastuspisteellä <color=green>sykliinin</color> sitoutuminen CDK:hon aiheuttaa <color=yellow>?</color>:n irtoamisen <color=yellow>?</color> transkriptiotekijästä, joka mahdollistaa tarkastuspisteen ohittamisen",

    "Tarkastuspisteellä sykliinin sitoutuminen CDK:hon aiheuttaa <color=yellow>?</color>:n irtoamisen <color=yellow>?</color> transkriptiotekijästä, joka mahdollistaa tarkastuspisteen ohittamisen", "Tarkastuspisteellä sykliinin sitoutuminen CDK:hon aiheuttaa <color=green>pRb</color>:n irtoamisen <color=yellow>?</color> transkriptiotekijästä, joka mahdollistaa tarkastuspisteen ohittamisen",

    "Tarkastuspisteellä sykliinin sitoutuminen CDK:hon aiheuttaa pRb:n irtoamisen <color=yellow>?</color> transkriptiotekijästä, joka mahdollistaa tarkastuspisteen ohittamisen", "Tarkastuspisteellä sykliinin sitoutuminen CDK:hon aiheuttaa pRb:n irtoamisen <color=green>E2F</color> transkriptiotekijästä, joka mahdollistaa tarkastuspisteen ohittamisen",

    "Kasvunrajoitegeeni <color=yellow>?</color> reagoi DNA virheisiin tuottamalla CDK-sykliini-kompleksit <color=yellow>?</color> p21 proteiinia", "Kasvunrajoitegeeni <color=green>P53</color> reagoi DNA virheisiin tuottamalla CDK-sykliini-kompleksit <color=yellow>?</color> p21 proteiinia",

    "Kasvunrajoitegeeni P53 reagoi DNA virheisiin tuottamalla CDK-sykliini-kompleksit <color=yellow>?</color> p21 proteiinia", "Kasvunrajoitegeeni P53 reagoi DNA virheisiin tuottamalla CDK-sykliini-kompleksit <color=green>inaktivoivaa</color> p21 proteiinia",

    "<color=yellow>?</color> CDK fosforylaatio tai P53 pysäyttävät solun virheen sattuessa", "<color=green>G2-M-tarkastuspisteellä</color> CDK fosforylaatio tai P53 pysäyttävät solun virheen sattuessa"

     }; 



//Lauseet muodossa kysymyslause+lause vastauksella, joten tässä vastauksia tulee olla aina 2kpl per lause
//jotta oikeiden vastausten tarkistus menee oikein.
//uusi vastaus tulee lisätä myös WordGenerator scriptin wordlistiin
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
    "Epätydellisessä penetranssissa", "16",
    "dominoivasti", "17",
    "lyonisaatiosta", "18",
    "pojat", "19",
    "tyttäret", "20",
    "miehillä", "21",
    "resessiivisesti X-kromosomissa", "22",
    "RNA", "23",
    "mallijuostetta", "24",
    "transkriptiotekijöitä", "25",
    "promoottori", "26",
    "5’ -> 3’", "27",
    "5’CAP", "28",
    "poly-A", "29",
    "intronit", "30",
    "spliseosomin", "31",
    "eksoneista", "32",
    "vaihtoehtoiseksi", "33",
    "Lähetti", "34",
    "translaatiossa", "35",
    "ribosomilla", "36",
    "antikodonillaan", "37",
    "kodoniin", "38",
    "aminohappo", "39",
    "E", "40",
    "Lopetuskodoni", "41",
    "Säätelyalueen", "42",
    "patogeenisia", "43",
    "ituradassa", "44",
    "aktivoiva", "45",
    "inaktivoiva", "46",
    "insertio", "47",
    "deleetio", "48",
    "substituutio", "49",
    "Translokaatio", "50",
    "insertiot", "51",
    "deleetiot", "52",
    "toistojaksoiksi", "53",
    "mikrosatelliitit", "54",
    "sisarkromatidia", "55",
    "Glykosylaasiproteiinit", "56",
    "emäksenkorjauksessa", "57",
    "nukleotidinpoistokorjaus", "58",
    "geeni-informaatiota", "59",
    "Mismatch-repair", "60",
    "MLH1", "61",
    "PMS2", "62",
    "synteesivaiheessa", "63",
    "sykliinit", "64",
    "CDK", "65",
    "pysähtyy", "66",
    "apoptoosin", "67",
    "G1-S-tarkistuspisteellä", "68",
    "Replikaation", "69",
    "sykliinin", "70",
    "pRb", "71",
    "E2F", "72",
    "P53", "73", 
    "inaktivoivaa", "74", 
    "G2-M-tarkastuspisteellä"
     };



    // Start is called before the first frame update
    void Start()
    {
        sentencenumb = 0;
        answernumb = 1;
        answerText.color = Color.black;
        stopNumber = 20;


        randomizer = Random.Range(0, sentenceList.Length-1);
        if (randomizer % 2 != 0)
        {
            randomizer += 1;
        }

        sentence.text = sentenceList[randomizer];
        answerText.text = answers[randomizer];

        Debug.Log(randomizer);


    }

    // Update is called once per frame
    void Update()
    {
        //if the clicked answer gives points the this will be done
        if (Score.scoreAmount == answernumb)
        {
            if (pressedText.text == answerText.text)
            {
            
                answernumb += 1;
                sentencenumb += 1;
                randomizer += 1;
                
                sentence.text = sentenceList[randomizer];
                //sentencenumb +=1;
                
            }
            else
            {
                randomizer +=1;
                Score.scoreAmount -= 2;
                wrongText.gameObject.SetActive(true);

                answernumb -= 1;

                // If randomized set this to +1
                sentencenumb +=1;
            }

            //update sentence and change answer back to black
            StartCoroutine(CoroutineChangeVariables());
        }


        


    }



    IEnumerator CoroutineChangeVariables()
{
    
    yield return new WaitForSeconds(1); // wait for 1 seconds

    //cheks if it was the last sentence of the array, if was returns to mini game 3 main screen
    //otherwise gives next sentence
    //change ==stopnumber it sentences are randomized

    string checkString = sentenceList[randomizer];
    

    if (sentencenumb == stopNumber)
    {
        
        SceneManager.LoadScene(10);
    }

    else if(checkString.Contains("?"))
    {
        sentence.text = sentenceList[randomizer+1];
        wrongText.gameObject.SetActive(false);
        answerText.text = answers[randomizer+1];
        randomizer +=1;

    }

    else
    {
        randomizer = Random.Range(0, sentenceList.Length-1);
        if (randomizer % 2 != 0)
        {
            randomizer += 1;
        }
        Debug.Log(randomizer);
        

        //could change to randomizer
        sentence.text = sentenceList[randomizer];
       wrongText.gameObject.SetActive(false);
       //could change to randomizer
        answerText.text = answers[randomizer];
    
    }
}


}
