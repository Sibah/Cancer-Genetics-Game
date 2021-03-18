using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Answer2 : MonoBehaviour
{
    public Text answerText;
    public static int answernumb;
    public Text sentence;
    public static int sentencenumb;
    public Text pressedText;
    public Text wrongText;
    

    public static string[] sentenceList = { "Tupakka, ionisoiva säteily ja happiradikaalit ovat esimerkkejä <color=yellow>?</color>", "Tupakka, ionisoiva säteily ja happiradikaalit ovat esimerkkejä <color=green>karsinogeeneistä</color>",

    "Emäksenkorjauksen mutaatiot altistavat <color=yellow>?</color> periytyvälle MUYTH-geeniin assosioituvalle <color=yellow>?</color>", "Emäksenkorjauksen mutaatiot altistavat <color=green>resessiivisesti</color> periytyvälle MUYTH-geeniin assosioituvalle <color=yellow>?</color>",
    "Emäksenkorjauksen mutaatiot altistavat resessiivisesti periytyvälle MUYTH-geeniin assosioituvalle <color=yellow>?</color>", "Emäksenkorjauksen mutaatiot altistavat resessiivisesti periytyvälle MUYTH-geeniin assosioituvalle <color=green>polypoosille</color>",

    "Periytyvää syöpäalttiutta aiheuttava kasvunrajoitegeeni CDKN2A ja <color=yellow>?</color> CDK4 ilmentyvät solusyklin <color=yellow>?</color> vaiheessa", "Periytyvää syöpäalttiutta aiheuttava kasvunrajoitegeeni CDKN2A ja <color=green>onkogeeni</color> CDK4 ilmentyvät solusyklin <color=yellow>?</color> vaiheessa",
    "Periytyvää syöpäalttiutta aiheuttava kasvunrajoitegeeni CDKN2A ja onkogeeni CDK4 ilmentyvät solusyklin <color=yellow>?</color> vaiheessa", "Periytyvää syöpäalttiutta aiheuttava kasvunrajoitegeeni CDKN2A ja onkogeeni CDK4 ilmentyvät solusyklin <color=green>G1</color> vaiheessa",

    "<color=yellow>?</color> P53 toimii solusyklissä sekä on myös <color=yellow>?</color> käynnistäjä", "<color=green>Portinvartijageeni</color> P53 toimii solusyklissä sekä on myös <color=yellow>?</color> käynnistäjä",
    "Portinvartijageeni P53 toimii solusyklissä sekä on myös <color=yellow>?</color> käynnistäjä", "Portinvartijageeni P53 toimii solusyklissä sekä on myös <color=green>apoptoosin</color> käynnistäjä",

    "Syöpä on <color=yellow>?</color> sairaus, joka yleensä kehittyy hankinnaisen perimän <color=yellow>?</color> kautta", "Syöpä on <color=green>geneettinen</color> sairaus, joka yleensä kehittyy hankinnaisen perimän <color=yellow>?</color> kautta",
    "Syöpä on geneettinen sairaus, joka yleensä kehittyy hankinnaisen perimän <color=yellow>?</color> kautta", "Syöpä on geneettinen sairaus, joka yleensä kehittyy hankinnaisen perimän <color=green>mutaation</color> kautta",

    "Knudsonin teorian mukaan solu tarvitsee ainakin <color=yellow>?</color> osumaa eli <color=yellow>?</color> kasvunrajoitegeenissä muuttuakseen syöpäsoluksi", "Knudsonin teorian mukaan solu tarvitsee ainakin <color=green>kaksi</color> osumaa eli <color=yellow>?</color> kasvunrajoitegeenissä muuttuakseen syöpäsoluksi",
    "Knudsonin teorian mukaan solu tarvitsee ainakin kaksi osumaa eli <color=yellow>?</color> kasvunrajoitegeenissä muuttuakseen syöpäsoluksi", "Knudsonin teorian mukaan solu tarvitsee ainakin kaksi osumaa eli <color=green>mutaatiota</color> kasvunrajoitegeenissä muuttuakseen syöpäsoluksi",

    "<color=yellow>?</color> syövässä Knudsonin teorian ensimmäinen mutaatio on <color=yellow>?</color>, kun hankinnaisessa molemmat mutaatiot syntyvät elämän aikana", "<color=green>Perinnöllisessä</color> syövässä Knudsonin teorian ensimmäinen mutaatio on <color=yellow>?</color>, kun hankinnaisessa molemmat mutaatiot syntyvät elämän aikana",
    "Perinnöllisessä syövässä Knudsonin teorian ensimmäinen mutaatio on <color=yellow>?</color>, kun hankinnaisessa molemmat mutaatiot syntyvät elämän aikana", "Perinnöllisessä syövässä Knudsonin teorian ensimmäinen mutaatio on <color=green>ituradassa</color>, kun hankinnaisessa molemmat mutaatiot syntyvät elämän aikana",

    "Proto-onkogeenin <color=yellow>?</color> mutaatio <color=yellow>?</color>, johtaa yliaktiivisten solun kasvua <color=yellow>?</color> proteiinien tuottoon", "Proto-onkogeenin <color=green>aktivoiva</color> mutaatio <color=yellow>?</color>, johtaa yliaktiivisten solun kasvua <color=yellow>?</color> proteiinien tuottoon",
    "Proto-onkogeenin aktivoiva mutaatio <color=yellow>?</color>, johtaa yliaktiivisten solun kasvua <color=yellow>?</color> proteiinien tuottoon", "Proto-onkogeenin aktivoiva mutaatio <color=green>onkogeeniksi</color>, johtaa yliaktiivisten solun kasvua <color=yellow>?</color> proteiinien tuottoon",
    "Proto-onkogeenin aktivoiva mutaatio onkogeeniksi, johtaa yliaktiivisten solun kasvua <color=yellow>?</color> proteiinien tuottoon", "Proto-onkogeenin aktivoiva mutaatio onkogeeniksi, johtaa yliaktiivisten solun kasvua <color=green>edistävien</color> proteiinien tuottoon",

    "Onkogeenit periytyvät <color=yellow>?</color> ja myös solutasolla vain toisen <color=yellow>?</color> mutaatio tarvitaan tuottamaan muuntunutta proteiinia", "Onkogeenit periytyvät <color=green>dominoivasti</color> ja myös solutasolla vain toisen <color=yellow>?</color> mutaatio tarvitaan tuottamaan muuntunutta proteiinia",
    "Onkogeenit periytyvät dominoivasti ja myös solutasolla vain toisen <color=yellow>?</color> mutaatio tarvitaan tuottamaan muuntunutta proteiinia", "Onkogeenit periytyvät dominoivasti ja myös solutasolla vain toisen <color=green>alleelin</color> mutaatio tarvitaan tuottamaan muuntunutta proteiinia",

    "Esimerkki perinnöllisestä onkogeenistä on <color=yellow>?</color>, joka altistaa papillaariselle munuaissyövälle, HER2 taas on hankinnainen <color=yellow>?</color> onkogeeni", "Esimerkki perinnöllisestä onkogeenistä on <color=green>MET</color>, joka altistaa papillaariselle munuaissyövälle, HER2 taas on hankinnainen <color=yellow>?</color> onkogeeni",
    "Esimerkki perinnöllisestä onkogeenistä on MET, joka altistaa papillaariselle munuaissyövälle, HER2 taas on hankinnainen <color=yellow>?</color> onkogeeni", "Esimerkki perinnöllisestä onkogeenistä on MET, joka altistaa papillaariselle munuaissyövälle, HER2 taas on hankinnainen <color=green>rintasyövän</color> onkogeeni",

    "<color=yellow>?</color> ovat useammin perinnöllisten syöpäalttiuksien takana kuin <color=yellow>?</color>", "<color=green>Kasvunrajoitegeenit</color> ovat useammin perinnöllisten syöpäalttiuksien takana kuin <color=yellow>?</color>",
    "Kasvunrajoitegeenit ovat useammin perinnöllisten syöpäalttiuksien takana kuin <color=yellow>?</color>", "Kasvunrajoitegeenit ovat useammin perinnöllisten syöpäalttiuksien takana kuin <color=green>onkogeenit</color>",

    "Kasvunrajoitegeenissä tapahtuva <color=yellow>?</color> mutaatio poistaa solun kasvun jarrun", "Kasvunrajoitegeenissä tapahtuva <color=green>inaktivoiva</color> mutaatio poistaa solun kasvun jarrun",

    "Solutasolla kasvunrajoitegeenien molempien <color=yellow>?</color> on inaktivoiduttava geenin toiminnan muuttumiseen eli ne toimivat <color=yellow>?</color>", "Solutasolla kasvunrajoitegeenien molempien <color=green>alleelien</color> on inaktivoiduttava geenin toiminnan muuttumiseen eli ne toimivat <color=yellow>?</color>",
    "Solutasolla kasvunrajoitegeenien molempien alleelien on inaktivoiduttava geenin toiminnan muuttumiseen eli ne toimivat <color=yellow>?</color>", "Solutasolla kasvunrajoitegeenien molempien alleelien on inaktivoiduttava geenin toiminnan muuttumiseen eli ne toimivat <color=green>resessiivisesti</color>",

    "Ituradassa kasvunrajoitegeenien syöpäalttius periytyy <color=yellow>?</color> eli elinaikana geenin toiminnan muuttumiseen tarvitaan enää <color=yellow>?</color> mutaatio", "Ituradassa kasvunrajoitegeenien syöpäalttius periytyy <color=green>vallitsevasti</color> eli elinaikana geenin toiminnan muuttumiseen tarvitaan enää <color=yellow>?</color> mutaatio",
    "Ituradassa kasvunrajoitegeenien syöpäalttius periytyy vallitsevasti eli elinaikana geenin toiminnan muuttumiseen tarvitaan enää <color=yellow>?</color> mutaatio", "Ituradassa kasvunrajoitegeenien syöpäalttius periytyy vallitsevasti eli elinaikana geenin toiminnan muuttumiseen tarvitaan enää <color=green>yksi</color> mutaatio",

    "Kasvunrajoitegeeneistä esimerkiksi <color=yellow>?</color> ja P53 ovat <color=yellow>?</color>, jotka kontrolloivat solujen kasvua", "Kasvunrajoitegeeneistä esimerkiksi <color=green>APC</color> ja P53 ovat <color=yellow>?</color>, jotka kontrolloivat solujen kasvua",
    "Kasvunrajoitegeeneistä esimerkiksi APC ja P53 ovat <color=yellow>?</color>, jotka kontrolloivat solujen kasvua", "Kasvunrajoitegeeneistä esimerkiksi APC ja P53 ovat <color=green>portinvartijoita</color>, jotka kontrolloivat solujen kasvua",

    "<color=yellow>?</color> vaikuttavien geenien inaktivoituminen edistää solun kasvua muuttamalla ympäröivän kudoksen rakennetta", "<color=green>Kasvuympäristöön</color> vaikuttavien geenien inaktivoituminen edistää solun kasvua muuttamalla ympäröivän kudoksen rakennetta",

    "Kasvuympäristöön vaikuttavan <color=yellow>?</color> mutaatio edistää paksusuolen epiteelisolujen ylikasvua muuttamalla strooman solujen kasvua", "Kasvuympäristöön vaikuttavan <color=green>SMAD4</color> mutaatio edistää paksusuolen epiteelisolujen ylikasvua muuttamalla strooman solujen kasvua",

    "<color=yellow>?</color> voivat muokata myös esimerkiksi tulehdukselliset sairaudet kuten colitis ulcerosa, joka nostaa <color=yellow>?</color> riskiä", "<color=green>Kasvuympäristöä</color> voivat muokata myös esimerkiksi tulehdukselliset sairaudet kuten colitis ulcerosa, joka nostaa <color=yellow>?</color> riskiä", 
    "Kasvuympäristöä voivat muokata myös esimerkiksi tulehdukselliset sairaudet kuten colitis ulcerosa, joka nostaa <color=yellow>?</color> riskiä", "Kasvuympäristöä voivat muokata myös esimerkiksi tulehdukselliset sairaudet kuten colitis ulcerosa, joka nostaa <color=green>paksusuolisyövän</color> riskiä",

    "DNA:n katkoksia ja replikaatiovirheitä korjaavat <color=yellow>?</color> ylläpitävät genomin <color=yellow>?</color>", "DNA:n katkoksia ja replikaatiovirheitä korjaavat <color=green>huoltogeenit</color> ylläpitävät genomin <color=yellow>?</color>",
    "DNA:n katkoksia ja replikaatiovirheitä korjaavat huoltogeenit ylläpitävät genomin <color=yellow>?</color>", "DNA:n katkoksia ja replikaatiovirheitä korjaavat huoltogeenit ylläpitävät genomin <color=green>stabiliteettia</color>",

    "<color=yellow>?</color> inaktivoituminen johtaa mutaatioiden määrän kasvuun myös muissa <color=yellow>?</color>", "<color=green>Huoltojoukkogeenien </color> inaktivoituminen johtaa mutaatioiden määrän kasvuun myös muissa <color=yellow>?</color>",
    "Huoltojoukkogeenien inaktivoituminen johtaa mutaatioiden määrän kasvuun myös muissa <color=yellow>?</color>", "Huoltojoukkogeenien inaktivoituminen johtaa mutaatioiden määrän kasvuun myös muissa <color=green>kasvunrajoitegeeneissä</color>",

    "<color=yellow>?</color> sekä <color=yellow>?</color> mahdollistavat mutaatioiden suuren lukumäärän syöpäsolussa", "<color=green>Genominen instabiliteetti</color> sekä <color=yellow>?</color> mahdollistavat mutaatioiden suuren lukumäärän syöpäsolussa",
    "Genominen instabiliteetti sekä <color=yellow>?</color> mahdollistavat mutaatioiden suuren lukumäärän syöpäsolussa", "Genominen instabiliteetti sekä <color=green>valintaetu</color> mahdollistavat mutaatioiden suuren lukumäärän syöpäsolussa",

    "Syövän genominen instabiiliteetti eli replikaatiovirheiden ja <color=yellow>?</color> kertyminen johtuu <color=yellow>?</color> virheistä", "Syövän genominen instabiiliteetti eli replikaatiovirheiden ja <color=green>mutaatioiden</color> kertyminen johtuu <color=yellow>?</color> virheistä",
    "Syövän genominen instabiiliteetti eli replikaatiovirheiden ja mutaatioiden kertyminen johtuu <color=yellow>?</color> virheistä", "Syövän genominen instabiiliteetti eli replikaatiovirheiden ja mutaatioiden kertyminen johtuu <color=green>kasvunrajoitegeenien</color> virheistä",

    "Syöpäsolujen kehittymiselle oleellisia ovat <color=yellow>?</color>-mutaatiot, jotka tarjoavat syöpäsolulle <color=yellow>?</color>", "Syöpäsolujen kehittymiselle oleellisia ovat <color=green>driver</color>-mutaatiot, jotka tarjoavat syöpäsolulle <color=yellow>?</color>",
    "Syöpäsolujen kehittymiselle oleellisia ovat driver-mutaatiot, jotka tarjoavat syöpäsolulle <color=yellow>?</color>", "Syöpäsolujen kehittymiselle oleellisia ovat driver-mutaatiot, jotka tarjoavat syöpäsolulle <color=green>valintaedun</color>",

    "<color=yellow>?</color> eivät edistä solun muuttumista syöpäsoluksi, mutta niiden määrä kasvaa driver-geenien mutatoituessa", "<color=green>Passenger</color> eivät edistä solun muuttumista syöpäsoluksi, mutta niiden määrä kasvaa driver-geenien mutatoituessa",

    "<color=yellow>?</color>-geenien mutaatiot ovat yleisiä, mutta harvinaisemmat <color=yellow>?</color>-geenien mutaatiot ajavat solun syöpäsoluksi", "<color=green> Passenger</color>-geenien mutaatiot ovat yleisiä, mutta harvinaisemmat <color=yellow>?</color>-geenien mutaatiot ajavat solun syöpäsoluksi",
    "Passenger-geenien mutaatiot ovat yleisiä, mutta harvinaisemmat <color=yellow>?</color>-geenien mutaatiot ajavat solun syöpäsoluksi", "Passenger-geenien mutaatiot ovat yleisiä, mutta harvinaisemmat <color=green>driver</color>-geenien mutaatiot ajavat solun syöpäsoluksi",

    "Syöpäsolussa kromosomeja voi olla <color=yellow>?</color> kuin normaalisti ja niissä voi olla rakennevikoja, tämä johtuu <color=yellow>?</color> instabiliteetista", "Syöpäsolussa kromosomeja voi olla <color=green>enemmän</color> kuin normaalisti ja niissä voi olla rakennevikoja, tämä johtuu <color=yellow>?</color> instabiliteetista",
    "Syöpäsolussa kromosomeja voi olla enemmän kuin normaalisti ja niissä voi olla rakennevikoja, tämä johtuu <color=yellow>?</color> instabiliteetista", "Syöpäsolussa kromosomeja voi olla enemmän kuin normaalisti ja niissä voi olla rakennevikoja, tämä johtuu <color=green>kromosomitason</color> instabiliteetista",

    "Genomin instabiliteetin toinen tyyppi <color=yellow>?</color> ilmenee toistojaksojen <color=yellow>?</color> ja pistemutaatioina", "Genomin instabiliteetin toinen tyyppi <color=green>mikrosatelliitti-instabiliteetti</color> ilmenee toistojaksojen <color=yellow>?</color> ja pistemutaatioina",
    "Genomin instabiliteetin toinen tyyppi mikrosatelliitti-instabiliteetti ilmenee toistojaksojen <color=yellow>?</color> ja pistemutaatioina", "Genomin instabiliteetin toinen tyyppi mikrosatelliitti instabiliteetti ilmenee toistojaksojen <color=green>pituusvaihteluna</color> ja pistemutaatioina",

    "<color=yellow>?</color> järjestelmän vika on yleinen syy mikrosatellittii-instabiliteetille", "<color=green>Mismatch-repair</color> järjestelmän vika on yleinen syy mikrosatellittii-instabiliteetille",

    "Mikrosatelliitti-instabiliteettia esiintyy noin <color=yellow>?</color> syövistä ja se voi olla osana <color=yellow>?</color> monisyöpäoireyhtymää", "Mikrosatelliitti-instabiliteettia esiintyy noin <color=green>15 %</color> syövistä ja se voi olla osana <color=yellow>?</color> monisyöpäoireyhtymää",
    "Mikrosatelliitti-instabiliteettia esiintyy noin 15 % syövistä ja se voi olla osana <color=yellow>?</color> monisyöpäoireyhtymää", "Mikrosatelliitti-instabiliteettia esiintyy noin 15 % syövistä ja se voi olla osana <color=green>periytyvää</color> monisyöpäoireyhtymää",

    "Harva syöpäalttiusoireyhtymä altistaa vain <color=yellow>?</color> syövälle, mutta jokaisella oireyhtymällä on kuitenkin sille tyypillisiä syöpiä", "Harva syöpäalttiusoireyhtymä altistaa vain <color=green>yhdelle</color> syövälle, mutta jokaisella oireyhtymällä on kuitenkin sille tyypillisiä syöpiä",

    "Li-Fraumenin oireyhtymässä on mutaatio <color=yellow>?</color> geenissä, ja se altistaa esimerkiksi <color=yellow>?</color>- ja luustosyövälle", "Li-Fraumenin oireyhtymässä on mutaatio <color=green>P53</color> geenissä, ja se altistaa esimerkiksi <color=yellow>?</color>- ja luustosyövälle",
    "Li-Fraumenin oireyhtymässä on mutaatio P53 geenissä, ja se altistaa esimerkiksi <color=yellow>?</color>- ja luustosyövälle", "Li-Fraumenin oireyhtymässä on mutaatio P53 geenissä, ja se altistaa esimerkiksi <color=green>rinta</color>- ja luustosyövälle",

    "Syöpäalttiusoireyhtymä voidaan tunnistaa <color=yellow>?</color> tarkastelemalla ja <color=yellow>?</color>", "Syöpäalttiusoireyhtymä voidaan tunnistaa <color=green>sukupuuta</color> tarkastelemalla ja <color=yellow>?</color>",
    "Syöpäalttiusoireyhtymä voidaan tunnistaa sukupuuta tarkastelemalla ja <color=yellow>?</color>", "Syöpäalttiusoireyhtymä voidaan tunnistaa sukupuuta tarkastelemalla ja <color=green>geenitestillä</color>",

    "Tunnistetuista syöpäalttiusoireyhtymistä suurin osa on <color=yellow>?</color> ja niille on tyypillistä epätäydellinen <color=yellow>?</color>", "Tunnistetuista syöpäalttiusoireyhtymistä suurin osa on <color=green>dominoivia</color> ja niille on tyypillistä epätäydellinen <color=yellow>?</color>",
    "Tunnistetuista syöpäalttiusoireyhtymistä suurin osa on dominoivia, ja niille on tyypillistä epätäydellinen <color=yellow>?</color>", "Tunnistetuista syöpäalttiusoireyhtymistä suurin osa on dominoivia ja niille on tyypillistä epätäydellinen <color=green>penetranssi</color>",

    "<color=yellow>?</color> värjäystulos kudoksen immunohistokemiallisessa värjäyksessä osoittaa geenin inaktivoitumisen", "<color=green>Negatiivinen</color> värjäystulos kudoksen immunohistokemiallisessa värjäyksessä osoittaa geenin inaktivoitumisen",

    "Naisten yleisin syöpä on <color=yellow>?</color> ja jokaisella naisella on noin <color=yellow>?</color> riski sairastua siihen", "Naisten yleisin syöpä on <color=green>rintasyöpä</color> ja jokaisella naisella on noin <color=yellow>?</color> riski sairastua siihen",
    "Naisten yleisin syöpä on rintasyöpä ja jokaisella naisella on noin <color=yellow>?</color> riski sairastua siihen", "Naisten yleisin syöpä on rintasyöpä ja jokaisella naisella on noin <color=green>10-15%</color> riski sairastua siihen",

    "Korkean riskin <color=yellow>?</color> alttiudesta johtuvan rintasyövän osuus Suomessa todetuista rintasyövistä on noin <color=yellow>?</color>", "Korkean riskin <color=green>perinnöllisestä</color> alttiudesta johtuvan rintasyövän osuus Suomessa todetuista rintasyövistä on noin <color=yellow>?</color>",
    "Korkean riskin perinnöllisestä alttiudesta johtuvan rintasyövän osuus Suomessa todetuista rintasyövistä on noin <color=yellow>?</color>", "Korkean riskin perinnöllisestä alttiudesta johtuvan rintasyövän osuus Suomessa todetuista rintasyövistä on noin <color=green>5–10 %</color>",

    "Suuren riskin geenivirheen, kuten <color=green>BRCA 1</color> kantajilla katsotaan olevan <color=yellow>?</color> riski sairastua rintasyöpään", "Suuren riskin geenivirheen, kuten <color=green>BRCA 1</color> kantajilla katsotaan olevan <color=yellow>?</color> riski sairastua rintasyöpään",
    "Suuren riskin geenivirheen, kuten BRCA 1 kantajilla katsotaan olevan <color=yellow>?</color> riski sairastua rintasyöpään", "Suuren riskin geenivirheen, kuten BRCA 1 kantajilla katsotaan olevan <color=green>yli 50 %</color> riski sairastua rintasyöpään",

    "<color=yellow>?</color> riskin perinnöllisen syöpäalttiuden geenimutaatiot ovat harvinaisia väestössä", "<color=green>Suuren</color> riskin perinnöllisen syöpäalttiuden geenimutaatiot ovat harvinaisia väestössä",

    "<color=yellow>?</color> ja <color=yellow>?</color> geeneihin liittyy lähes yhtä suuri rintasyövän riski, mutta BRCA 1:ssä on huomattavasti korkeampi <color=yellow>?</color> riski", "<color=green>BRCA 1</color> ja <color=yellow>?</color> geeneihin liittyy lähes yhtä suuri rintasyövän riski, mutta BRCA 1:ssä on huomattavasti korkeampi <color=yellow>?</color> riski",
    "BRCA 1 ja <color=yellow>?</color> geeneihin liittyy lähes yhtä suuri rintasyövän riski, mutta BRCA 1:ssä on huomattavasti korkeampi <color=yellow>?</color> riski", "BRCA 1 ja <color=green>BRCA 2</color> geeneihin liittyy lähes yhtä suuri rintasyövän riski, mutta BRCA 1:ssä on huomattavasti korkeampi <color=yellow>?</color> riski",
    "BRCA 1 ja BRCA 2 geeneihin liittyy lähes yhtä suuri rintasyövän riski, mutta BRCA 1:ssä on huomattavasti korkeampi <color=yellow>?</color> riski", "BRCA 1 ja BRCA 2 geeneihin liittyy lähes yhtä suuri rintasyövän riski, mutta BRCA 1:ssä on huomattavasti korkeampi <color=green>munasarjasyövän</color> riski",

    "BRCA 1 ja BRCA 2 rintasyöpäalttiusgeenien kantajien sairastumisriskiä voidaan pienentää <color=yellow>?</color> ja <color=yellow>?</color> poistolla", "BRCA 1 ja BRCA 2 rintasyöpäalttiusgeenien kantajien sairastumisriskiä voidaan pienentää <color=green>rintojen</color> ja <color=yellow>?</color> poistolla",
    "BRCA 1 ja BRCA 2 rintasyöpäalttiusgeenien kantajien sairastumisriskiä voidaan pienentää rintojen ja <color=green>munasarjojen</color> poistolla",

    "Paksu- ja peräsuolisyöpien ilmaantuvuus on suurta, mutta vain noin <color=yellow>?</color> on selkeästi perinnölliseen alttiuteen liittyvää", "Paksu- ja peräsuolisyöpien ilmaantuvuus on suurta, mutta vain noin <color=green> 5 %</color> on selkeästi perinnölliseen alttiuteen liittyvää",

    "Sporadinen paksusuolisyöpä kehittyy usein, kun <color=yellow>?</color> geenin virhe johtaa polyypin syntyyn, sitten mutaatiot muissa onkogeeneissa ja kasvunrajoitegeeneissä johtavat <color=yellow>?</color> malignisoitumiseen", "Sporadinen paksusuolisyöpä kehittyy usein, kun <color=green>APC</color> geenin virhe johtaa polyypin syntyyn, sitten mutaatiot muissa onkogeeneissa ja kasvunrajoitegeeneissä johtavat <color=yellow>?</color> malignisoitumiseen",
    "Sporadinen paksusuolisyöpä kehittyy usein, kun APC geenin virhe johtaa polyypin syntyyn, sitten mutaatiot muissa onkogeeneissa ja kasvunrajoitegeeneissä johtavat <color=yellow>?</color> malignisoitumiseen", "Sporadinen paksusuolisyöpä kehittyy usein, kun APC geenin virhe johtaa polyypin syntyyn, sitten mutaatiot muissa onkogeeneissa ja kasvunrajoitegeeneissä johtavat <color=green>polyypin</color> malignisoitumiseen",

    "Perinnöllistä kohonnutta <color=yellow>?</color> aiheuttavat oireyhtymät voidaan karkeasti jakaa <color=yellow>?</color> ja ei-polypoottisiin", "Perinnöllistä kohonnutta <color=green>perä- ja paksusuolisyöpäalttiutta</color> aiheuttavat oireyhtymät voidaan karkeasti jakaa <color=yellow>?</color> ja ei-polypoottisiin",
    "Perinnöllistä kohonnutta perä- ja paksusuolisyöpäalttiutta aiheuttavat oireyhtymät voidaan karkeasti jakaa <color=yellow>?</color> ja ei-polypoottisiin", "Perinnöllistä kohonnutta perä- ja paksusuolisyöpäalttiutta aiheuttavat oireyhtymät voidaan karkeasti jakaa <color=green>polypoottisiin</color> ja ei-polypoottisiin",

    "Portinvartijageeni APC:n perinnöllinen geenivirhe johtaa <color=yellow>?</color> (FAP), jossa elinikäinen sairastumisriski paksusuolisyöpään voi olla jopa <color=yellow>?</color>", "Portinvartijageeni APC:n perinnöllinen geenivirhe johtaa <color=green>familiaaliseen adenomatoottiseen polypoosiin</color> (FAP), jossa elinikäinen sairastumisriski paksusuolisyöpään voi olla jopa <color=yellow>?</color>",
    "Portinvartijageeni APC:n perinnöllinen geenivirhe johtaa familiaaliseen adenomatoottiseen polypoosiin (FAP), jossa elinikäinen sairastumisriski paksusuolisyöpään voi olla jopa <color=yellow>?</color>", "Portinvartijageeni APC:n perinnöllinen geenivirhe johtaa familiaaliseen adenomatoottiseen polypoosiin (FAP), jossa elinikäinen sairastumisriski paksusuolisyöpään voi olla jopa <color=green>100 %</color>",

    "Ei-polypoottisen paksusuolisyövän eli HNPCC eli <color=yellow>?</color> oireyhtymän alttiusgeenejä ovat <color=yellow>?</color> geenit, esimerkiksi <color=yellow>?</color>, MSH2, MSH6 ja <color=yellow>?</color>", "Ei-polypoottisen paksusuolisyövän eli HNPCC eli <color=green>Lynchin</color> oireyhtymän alttiusgeenejä ovat <color=yellow>?</color> geenit, esimerkiksi <color=yellow>?</color>, MSH2, MSH6 ja <color=yellow>?</color>",
    "Ei-polypoottisen paksusuolisyövän eli HNPCC eli Lynchin oireyhtymän alttiusgeenejä ovat <color=yellow>?</color> geenit, esimerkiksi <color=yellow>?</color>, MSH2, MSH6 ja <color=yellow>?</color>", "Ei-polypoottisen paksusuolisyövän eli HNPCC eli Lynchin oireyhtymän alttiusgeenejä ovat <color=green>mismatch-repair</color> geenit, esimerkiksi <color=yellow>?</color>, MSH2, MSH6 ja <color=yellow>?</color>",
    "Ei-polypoottisen paksusuolisyövän eli HNPCC eli Lynchin oireyhtymän alttiusgeenejä ovat mismatch-repair geenit, esimerkiksi <color=yellow>?</color>, MSH2, MSH6 ja <color=yellow>?</color>", "Ei-polypoottisen paksusuolisyövän eli HNPCC eli Lynchin oireyhtymän alttiusgeenejä ovat mismatch-repair geenit, esimerkiksi <color=green>MLH1</color>, MSH2, MSH6 ja <color=yellow>?</color>",
    "Ei-polypoottisen paksusuolisyövän eli HNPCC eli Lynchin oireyhtymän alttiusgeenejä ovat mismatch-repair geenit, esimerkiksi MLH1, MSH2, MSH6 ja <color=yellow>?</color>", "Ei-polypoottisen paksusuolisyövän eli HNPCC eli Lynchin oireyhtymän alttiusgeenejä ovat mismatch-repair geenit, esimerkiksi MLH1, MSH2, MSH6 ja <color=green>PMS2</color>",

    "Lynchin oireyhtymässä <color=yellow>?</color> kehittyminen pahanlaatuisiksi on <color=yellow>?</color>, vaikka polyyppien määrä ei ole suurempi kuin yleisväestössä", "Lynchin oireyhtymässä <color=green>polyyppien</color> kehittyminen pahanlaatuisiksi on <color=yellow>?</color>, vaikka polyyppien määrä ei ole suurempi kuin yleisväestössä",
    "Lynchin oireyhtymässä polyyppien kehittyminen pahanlaatuisiksi on <color=yellow>?</color>, vaikka polyyppien määrä ei ole suurempi kuin yleisväestössä", "Lynchin oireyhtymässä polyyppien kehittyminen pahanlaatuisiksi on <color=green>nopeutunut</color>, vaikka polyyppien määrä ei ole suurempi kuin yleisväestössä",

    "Lynchin oireyhtymän geenivirheen kantajalle <color=yellow>?</color> ilmaantuu keskimäärin <color=yellow>?</color> aikaisemmin kuin sporadisena eli noin 40–60-vuotiaana", "Lynchin oireyhtymän geenivirheen kantajalle <color=green>paksusuolisyöpä</color> ilmaantuu keskimäärin <color=yellow>?</color> aikaisemmin kuin sporadisena eli noin 40–60-vuotiaana",
    "Lynchin oireyhtymän geenivirheen kantajalle paksusuolisyöpä ilmaantuu keskimäärin <color=yellow>?</color> aikaisemmin kuin sporadisena eli noin 40–60-vuotiaana", "Lynchin oireyhtymän geenivirheen kantajalle paksusuolisyöpä ilmaantuu keskimäärin <color=green>noin 20 vuotta</color> aikaisemmin kuin sporadisena eli noin 40–60-vuotiaana",

    "Lynchin oireyhtymän potilaille tehdään <color=yellow>?</color> 2–3 vuoden välein, näin perä- ja paksusuolisyövästä aiheutuva kuolleisuus laskee yleisen väestön tasolle", "Lynchin oireyhtymän potilaille tehdään <color=green>kolonoskopia</color> 2–3 vuoden välein, näin perä- ja paksusuolisyövästä aiheutuva kuolleisuus laskee yleisen väestön tasolle"
    };




//Lauseet muodossa kysymyslause+lause vastauksella, joten tässä vastauksia tulee olla aina 2kpl per lause
//jotta oikeiden vastausten tarkistus menee oikein.
//uusi vastaus tulee lisätä myös WordGenerator scriptin wordlistiin
    private static string[] answers = {
        "karsinogeeneistä", "1",
        "resessiivisesti", "2",
        "polypoosille", "3",
        "onkogeeni", "4",
        "G1", "5",
        "Portinvartijageeni", "6",
        "apoptoosin", "7",
        "geneettinen", "8",
        "mutaation", "9",
        "kaksi", "10",
        "mutaatiota", "11",
        "Perinnöllisessä", "12",
        "ituradassa", "13", 
        "aktivoiva", "14",
        "onkogeeniksi", "15",
        "edistävien", "16",
        "dominoivasti", "17",
        "alleelin", "18",
        "MET", "19", 
        "rintasyövän", "20",
        "Kasvunrajoitegeenit", "21", 
        "onkogeenit", "22",
        "inaktivoiva", "23",
        "alleelien", "24",
        "resessiivisesti", "25",
        "vallitsevasti", "26",
        "yksi", "27", 
        "APC", "28", 
        "portinvartijoita", "29",
        "Kasvuympäristöön", "30",
        "SMAD4", "31", 
        "Kasvuympäristöä", "32",
        "paksusuolisyövän", "33",
        "huoltogeenit", "34",
        "stabiliteettia", "35",
        "Huoltojoukkogeenien", "36",
        "kasvunrajoitegeeneissä", "37",
        "Genominen instabiliteetti", "38",
        "valintaetu", "39", 
        "mutaatioiden", "40",
        "kasvunrajoitegeenien", "41",
        "driver", "42", 
        "valintaedun", "43", 
        "Passenger", "44",
        "Passenger", "45",
        "driver", "46",
        "enemmän", "47",
        "kromosomitason", "48",
        "mikrosatelliitti", "49",
        "pituusvaihteluna", "50",
        "Mismatch-repair", "51",
        "15 %", "52",
        "periytyvää", "53",
        "yhdelle", "54",
        "P53", "55", 
        "rinta", "56", 
        "sukupuuta", "57",
        "geenitestillä", "58",
        "dominoivia", "59", 
        "penetranssi", "60",
        "Negatiivinen", "61", 
        "rintasyöpä", "62", 
        "10-15%", "63",
        "perinnöllisestä", "64",
        "5–10 %", "65", 
        "BRCA 1", "66", 
        "yli 50 %", "67",
        "Suuren", "68",
        "BRCA 1", "69", 
        "BRCA 2", "70", 
        "munasarjasyövän", "71", 
        "rintojen", "72", 
        "munasarjojen", "73", 
        " 5 %", "74", 
        "APC", "75", 
        "polyypin", "76",
        "perä- ja paksusuolisyöpäalttiutta", "77",
        "polypoottisiin", "78",
        "familiaaliseen adenomatoottiseen polypoosiin", "79",
        "100 %", "80", 
        "Lynchin", "81",
        "mismatch-repair", "82",
        "MLH1", "83", 
        "PMS2", "84",
        "polyyppien", "85",
        "nopeutunut", "86",
        "paksusuolisyöpä", "87",
        "noin 20 vuotta", "88",
        "kolonoskopia"
    };



   // Start is called before the first frame update
    void Start()
    {
        sentencenumb = 0;
        answernumb = 1;
        answerText.text = answers[0];
        answerText.color = Color.black;
        
        
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
                wrongText.gameObject.SetActive(true);
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

    //cheks if it was the last sentence of the array, if was returns to mini game 3 main screen
    //otherwise gives next sentence
    if (sentencenumb == sentenceList.Length)
    {
        
        SceneManager.LoadScene(10);
    }
    else
    {
        
        sentence.text = sentenceList[sentencenumb];
        wrongText.gameObject.SetActive(false);
        answerText.text = answers[sentencenumb];
    
    }
}





}