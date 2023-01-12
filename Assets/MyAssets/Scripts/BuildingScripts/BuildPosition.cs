using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildPosition : MonoBehaviour
{
    private GameManager gameManagerScript;
    public GameObject gameManager;
    public Building currentBuildingScript;
    private Vector3 recruitOffset = new Vector3(0, 0, 5);
    public bool position1Recruit;
    public bool position2Recruit;
    public bool position3Recruit;
    public bool position4Recruit;
    public bool position5Recruit;
    public bool position6Recruit;
    public bool position7Recruit;
    public bool position8Recruit;
    public bool position9Recruit;
    public bool position10Recruit;
    public bool position11Recruit;
    public bool position12Recruit;
    public bool position13Recruit;
    public bool position14Recruit;
    public bool position15Recruit;
    public bool position16Recruit;
    public bool position17Recruit;
    public bool position18Recruit;
    public bool position19Recruit;
    public bool position20Recruit;
    public bool position21Recruit;
    public bool position22Recruit;
    public bool position23Recruit;
    public bool position24Recruit;
    public bool position25Recruit;
    public bool position26Recruit;
    public bool position27Recruit;
    public bool position28Recruit;
    public bool position29Recruit;
    public bool position30Recruit;
    public bool position31Recruit;
    public bool position32Recruit;
    public bool position33Recruit;
    public bool position34Recruit;
    public bool position35Recruit;
    public bool position36Recruit;
    public bool position37Recruit;
    public bool position38Recruit;
    public bool position39Recruit;
    public bool position40Recruit;
    public bool position41Recruit;
    public bool position42Recruit;
    public bool position43Recruit;
    public bool position44Recruit;
    public bool position45Recruit;
    public bool position46Recruit;
    public bool position47Recruit;
    public bool position48Recruit;
    public bool position49Recruit;
    public bool position50Recruit;
    public bool position51Recruit;
    public bool position52Recruit;
    public bool position53Recruit;
    public bool position54Recruit;
    public bool position55Recruit;
    public bool position56Recruit;
    public bool position57Recruit;
    public bool position58Recruit;
    public bool position59Recruit;
    public bool position60Recruit;
    public bool position61Recruit;
    public bool position62Recruit;
    public bool position63Recruit;
    public bool position64Recruit;
    public bool position65Recruit;
    public bool position66Recruit;
    public bool position67Recruit;
    public bool position68Recruit;
    public bool position69Recruit;
    public bool position70Recruit;
    public bool position71Recruit;
    public bool position72Recruit;
    public bool position73Recruit;
    public bool position74Recruit;
    public bool position75Recruit;
    public bool position76Recruit;
    public bool position77Recruit;
    public bool position78Recruit;
    public bool position79Recruit;
    public bool position80Recruit;
    public bool position81Recruit;
    public bool position82Recruit;
    public bool position83Recruit;
    public bool position84Recruit;
    public bool position85Recruit;
    public bool position86Recruit;
    public bool position87Recruit;
    public bool position88Recruit;
    public bool position89Recruit;
    public bool position90Recruit;
    public bool position91Recruit;
    public bool position92Recruit;
    public bool position93Recruit;
    public bool position94Recruit;
    public bool position95Recruit;
    public bool position96Recruit;
    public bool position97Recruit;
    public bool position98Recruit;
    public bool position99Recruit;
    public bool position100Recruit;
    public bool position101Recruit;
    public bool position102Recruit;
    public bool position103Recruit;
    public bool position104Recruit;
    public bool position105Recruit;
    public bool position106Recruit;
    public bool position107Recruit;
    public bool position108Recruit;
    public bool position109Recruit;
    public bool position110Recruit;
    public bool position111Recruit;
    public bool position112Recruit;
    public bool position113Recruit;
    public bool position114Recruit;
    public bool position115Recruit;
    public bool position116Recruit;
    public bool position117Recruit;
    public bool position118Recruit;
    public bool position119Recruit;
    public bool position120Recruit;
    public bool position121Recruit;
    public bool position122Recruit;
    public bool position123Recruit;
    public bool position124Recruit;
    public bool position125Recruit;
    public bool position126Recruit;
    public bool position1Building;
    public bool position2Building;
    public bool position3Building;
    public bool position4Building;
    public bool position5Building;
    public bool position6Building;
    public bool position7Building;
    public bool position8Building;
    public bool position9Building;
    public bool position10Building;
    public bool position11Building;
    public bool position12Building;
    public bool position13Building;
    public bool position14Building;
    public bool position15Building;
    public bool position16Building;
    public bool position17Building;
    public bool position18Building;
    public bool position19Building;
    public bool position20Building;
    public bool position21Building;
    public bool position22Building;
    public bool position23Building;
    public bool position24Building;
    public bool position25Building;
    public bool position26Building;
    public bool position27Building;
    public bool position28Building;
    public bool position29Building;
    public bool position30Building;
    public bool position31Building;
    public bool position32Building;
    public bool position33Building;
    public bool position34Building;
    public bool position35Building;
    public bool position36Building;
    public bool position37Building;
    public bool position38Building;
    public bool position39Building;
    public bool position40Building;
    public bool position41Building;
    public bool position42Building;
    public bool position43Building;
    public bool position44Building;
    public bool position45Building;
    public bool position46Building;
    public bool position47Building;
    public bool position48Building;
    public bool position49Building;
    public bool position50Building;
    public bool position51Building;
    public bool position52Building;
    public bool position53Building;
    public bool position54Building;
    public bool position55Building;
    public bool position56Building;
    public bool position57Building;
    public bool position58Building;
    public bool position59Building;
    public bool position60Building;
    public bool position61Building;
    public bool position62Building;
    public bool position63Building;
    public bool position64Building;
    public bool position65Building;
    public bool position66Building;
    public bool position67Building;
    public bool position68Building;
    public bool position69Building;
    public bool position70Building;
    public bool position71Building;
    public bool position72Building;
    public bool position73Building;
    public bool position74Building;
    public bool position75Building;
    public bool position76Building;
    public bool position77Building;
    public bool position78Building;
    public bool position79Building;
    public bool position80Building;
    public bool position81Building;
    public bool position82Building;
    public bool position83Building;
    public bool position84Building;
    public bool position85Building;
    public bool position86Building;
    public bool position87Building;
    public bool position88Building;
    public bool position89Building;
    public bool position90Building;
    public bool position91Building;
    public bool position92Building;
    public bool position93Building;
    public bool position94Building;
    public bool position95Building;
    public bool position96Building;
    public bool position97Building;
    public bool position98Building;
    public bool position99Building;
    public bool position100Building;
    public bool position101Building;
    public bool position102Building;
    public bool position103Building;
    public bool position104Building;
    public bool position105Building;
    public bool position106Building;
    public bool position107Building;
    public bool position108Building;
    public bool position109Building;
    public bool position110Building;
    public bool position111Building;
    public bool position112Building;
    public bool position113Building;
    public bool position114Building;
    public bool position115Building;
    public bool position116Building;
    public bool position117Building;
    public bool position118Building;
    public bool position119Building;
    public bool position120Building;
    public bool position121Building;
    public bool position122Building;
    public bool position123Building;
    public bool position124Building;
    public bool position125Building;
    public bool position126Building;
    public GameObject position1ButtonObject;
    public GameObject position2ButtonObject;
    public GameObject position3ButtonObject;
    public GameObject position4ButtonObject;
    public GameObject position5ButtonObject;
    public GameObject position6ButtonObject;
    public GameObject position7ButtonObject;
    public GameObject position8ButtonObject;
    public GameObject position9ButtonObject;
    public GameObject position10ButtonObject;
    public GameObject position11ButtonObject;
    public GameObject position12ButtonObject;
    public GameObject position13ButtonObject;
    public GameObject position14ButtonObject;
    public GameObject position15ButtonObject;
    public GameObject position16ButtonObject;
    public GameObject position17ButtonObject;
    public GameObject position18ButtonObject;
    public GameObject position19ButtonObject;
    public GameObject position20ButtonObject;
    public GameObject position21ButtonObject;
    public GameObject position22ButtonObject;
    public GameObject position23ButtonObject;
    public GameObject position24ButtonObject;
    public GameObject position25ButtonObject;
    public GameObject position26ButtonObject;
    public GameObject position27ButtonObject;
    public GameObject position28ButtonObject;
    public GameObject position29ButtonObject;
    public GameObject position30ButtonObject;
    public GameObject position31ButtonObject;
    public GameObject position32ButtonObject;
    public GameObject position33ButtonObject;
    public GameObject position34ButtonObject;
    public GameObject position35ButtonObject;
    public GameObject position36ButtonObject;
    public GameObject position37ButtonObject;
    public GameObject position38ButtonObject;
    public GameObject position39ButtonObject;
    public GameObject position40ButtonObject;
    public GameObject position41ButtonObject;
    public GameObject position42ButtonObject;
    public GameObject position43ButtonObject;
    public GameObject position44ButtonObject;
    public GameObject position45ButtonObject;
    public GameObject position46ButtonObject;
    public GameObject position47ButtonObject;
    public GameObject position48ButtonObject;
    public GameObject position49ButtonObject;
    public GameObject position50ButtonObject;
    public GameObject position51ButtonObject;
    public GameObject position52ButtonObject;
    public GameObject position53ButtonObject;
    public GameObject position54ButtonObject;
    public GameObject position55ButtonObject;
    public GameObject position56ButtonObject;
    public GameObject position57ButtonObject;
    public GameObject position58ButtonObject;
    public GameObject position59ButtonObject;
    public GameObject position60ButtonObject;
    public GameObject position61ButtonObject;
    public GameObject position62ButtonObject;
    public GameObject position63ButtonObject;
    public GameObject position64ButtonObject;
    public GameObject position65ButtonObject;
    public GameObject position66ButtonObject;
    public GameObject position67ButtonObject;
    public GameObject position68ButtonObject;
    public GameObject position69ButtonObject;
    public GameObject position70ButtonObject;
    public GameObject position71ButtonObject;
    public GameObject position72ButtonObject;
    public GameObject position73ButtonObject;
    public GameObject position74ButtonObject;
    public GameObject position75ButtonObject;
    public GameObject position76ButtonObject;
    public GameObject position77ButtonObject;
    public GameObject position78ButtonObject;
    public GameObject position79ButtonObject;
    public GameObject position80ButtonObject;
    public GameObject position81ButtonObject;
    public GameObject position82ButtonObject;
    public GameObject position83ButtonObject;
    public GameObject position84ButtonObject;
    public GameObject position85ButtonObject;
    public GameObject position86ButtonObject;
    public GameObject position87ButtonObject;
    public GameObject position88ButtonObject;
    public GameObject position89ButtonObject;
    public GameObject position90ButtonObject;
    public GameObject position91ButtonObject;
    public GameObject position92ButtonObject;
    public GameObject position93ButtonObject;
    public GameObject position94ButtonObject;
    public GameObject position95ButtonObject;
    public GameObject position96ButtonObject;
    public GameObject position97ButtonObject;
    public GameObject position98ButtonObject;
    public GameObject position99ButtonObject;
    public GameObject position100ButtonObject;
    public GameObject position101ButtonObject;
    public GameObject position102ButtonObject;
    public GameObject position103ButtonObject;
    public GameObject position104ButtonObject;
    public GameObject position105ButtonObject;
    public GameObject position106ButtonObject;
    public GameObject position107ButtonObject;
    public GameObject position108ButtonObject;
    public GameObject position109ButtonObject;
    public GameObject position110ButtonObject;
    public GameObject position111ButtonObject;
    public GameObject position112ButtonObject;
    public GameObject position113ButtonObject;
    public GameObject position114ButtonObject;
    public GameObject position115ButtonObject;
    public GameObject position116ButtonObject;
    public GameObject position117ButtonObject;
    public GameObject position118ButtonObject;
    public GameObject position119ButtonObject;
    public GameObject position120ButtonObject;
    public GameObject position121ButtonObject;
    public GameObject position122ButtonObject;
    public GameObject position123ButtonObject;
    public GameObject position124ButtonObject;
    public GameObject position125ButtonObject;
    public GameObject position126ButtonObject;
    public GameObject building1;
    public GameObject building2;
    public GameObject building3;
    public GameObject building4;
    public GameObject building5;
    public GameObject building6;
    public GameObject building7;
    public GameObject building8;
    public GameObject building9;
    public GameObject building10;
    public GameObject building11;
    public GameObject building12;
    public GameObject building13;
    public GameObject building14;
    public GameObject building15;
    public GameObject building16;
    public GameObject building17;
    public GameObject building18;
    public GameObject building19;
    public GameObject building20;
    public GameObject building21;
    public GameObject building22;
    public GameObject building23;
    public GameObject building24;
    public GameObject building25;
    public GameObject building26;
    public GameObject building27;
    public GameObject building28;
    public GameObject building29;
    public GameObject building30;
    public GameObject building31;
    public GameObject building32;
    public GameObject building33;
    public GameObject building34;
    public GameObject building35;
    public GameObject building36;
    public GameObject building37;
    public GameObject building38;
    public GameObject building39;
    public GameObject building40;
    public GameObject building41;
    public GameObject building42;
    public GameObject building43;
    public GameObject building44;
    public GameObject building45;
    public GameObject building46;
    public GameObject building47;
    public GameObject building48;
    public GameObject building49;
    public GameObject building50;
    public GameObject building51;
    public GameObject building52;
    public GameObject building53;
    public GameObject building54;
    public GameObject building55;
    public GameObject building56;
    public GameObject building57;
    public GameObject building58;
    public GameObject building59;
    public GameObject building60;
    public GameObject building61;
    public GameObject building62;
    public GameObject building63;
    public GameObject building64;
    public GameObject building65;
    public GameObject building66;
    public GameObject building67;
    public GameObject building68;
    public GameObject building69;
    public GameObject building70;
    public GameObject building71;
    public GameObject building72;
    public GameObject building73;
    public GameObject building74;
    public GameObject building75;
    public GameObject building76;
    public GameObject building77;
    public GameObject building78;
    public GameObject building79;
    public GameObject building80;
    public GameObject building81;
    public GameObject building82;
    public GameObject building83;
    public GameObject building84;
    public GameObject building85;
    public GameObject building86;
    public GameObject building87;
    public GameObject building88;
    public GameObject building89;
    public GameObject building90;
    public GameObject building91;
    public GameObject building92;
    public GameObject building93;
    public GameObject building94;
    public GameObject building95;
    public GameObject building96;
    public GameObject building97;
    public GameObject building98;
    public GameObject building99;
    public GameObject building100;
    public GameObject building101;
    public GameObject building102;
    public GameObject building103;
    public GameObject building104;
    public GameObject building105;
    public GameObject building106;
    public GameObject building107;
    public GameObject building108;
    public GameObject building109;
    public GameObject building110;
    public GameObject building111;
    public GameObject building112;
    public GameObject building113;
    public GameObject building114;
    public GameObject building115;
    public GameObject building116;
    public GameObject building117;
    public GameObject building118;
    public GameObject building119;
    public GameObject building120;
    public GameObject building121;
    public GameObject building122;
    public GameObject building123;
    public GameObject building124;
    public GameObject building125;
    public GameObject building126;
    private Button position1Button;
    private Button position2Button;
    private Button position3Button;
    private Button position4Button;
    private Button position5Button;
    private Button position6Button;
    private Button position7Button;
    private Button position8Button;
    private Button position9Button;
    private Button position10Button;
    private Button position11Button;
    private Button position12Button;
    private Button position13Button;
    private Button position14Button;
    private Button position15Button;
    private Button position16Button;
    private Button position17Button;
    private Button position18Button;
    private Button position19Button;
    private Button position20Button;
    private Button position21Button;
    private Button position22Button;
    private Button position23Button;
    private Button position24Button;
    private Button position25Button;
    private Button position26Button;
    private Button position27Button;
    private Button position28Button;
    private Button position29Button;
    private Button position30Button;
    private Button position31Button;
    private Button position32Button;
    private Button position33Button;
    private Button position34Button;
    private Button position35Button;
    private Button position36Button;
    private Button position37Button;
    private Button position38Button;
    private Button position39Button;
    private Button position40Button;
    private Button position41Button;
    private Button position42Button;
    private Button position43Button;
    private Button position44Button;
    private Button position45Button;
    private Button position46Button;
    private Button position47Button;
    private Button position48Button;
    private Button position49Button;
    private Button position50Button;
    private Button position51Button;
    private Button position52Button;
    private Button position53Button;
    private Button position54Button;
    private Button position55Button;
    private Button position56Button;
    private Button position57Button;
    private Button position58Button;
    private Button position59Button;
    private Button position60Button;
    private Button position61Button;
    private Button position62Button;
    private Button position63Button;
    private Button position64Button;
    private Button position65Button;
    private Button position66Button;
    private Button position67Button;
    private Button position68Button;
    private Button position69Button;
    private Button position70Button;
    private Button position71Button;
    private Button position72Button;
    private Button position73Button;
    private Button position74Button;
    private Button position75Button;
    private Button position76Button;
    private Button position77Button;
    private Button position78Button;
    private Button position79Button;
    private Button position80Button;
    private Button position81Button;
    private Button position82Button;
    private Button position83Button;
    private Button position84Button;
    private Button position85Button;
    private Button position86Button;
    private Button position87Button;
    private Button position88Button;
    private Button position89Button;
    private Button position90Button;
    private Button position91Button;
    private Button position92Button;
    private Button position93Button;
    private Button position94Button;
    private Button position95Button;
    private Button position96Button;
    private Button position97Button;
    private Button position98Button;
    private Button position99Button;
    private Button position100Button;
    private Button position101Button;
    private Button position102Button;
    private Button position103Button;
    private Button position104Button;
    private Button position105Button;
    private Button position106Button;
    private Button position107Button;
    private Button position108Button;
    private Button position109Button;
    private Button position110Button;
    private Button position111Button;
    private Button position112Button;
    private Button position113Button;
    private Button position114Button;
    private Button position115Button;
    private Button position116Button;
    private Button position117Button;
    private Button position118Button;
    private Button position119Button;
    private Button position120Button;
    private Button position121Button;
    private Button position122Button;
    private Button position123Button;
    private Button position124Button;
    private Button position125Button;
    private Button position126Button;


    void Start()
    {
        gameManagerScript = gameManager.GetComponent<GameManager>();
        position1Button = position1ButtonObject.GetComponent<Button>();
        position2Button = position2ButtonObject.GetComponent<Button>();
        position3Button = position3ButtonObject.GetComponent<Button>();
        position4Button = position4ButtonObject.GetComponent<Button>();
        position5Button = position5ButtonObject.GetComponent<Button>();
        position6Button = position6ButtonObject.GetComponent<Button>();
        position7Button = position7ButtonObject.GetComponent<Button>();
        position8Button = position8ButtonObject.GetComponent<Button>();
        position9Button = position9ButtonObject.GetComponent<Button>();
        position10Button = position10ButtonObject.GetComponent<Button>();
        position11Button = position11ButtonObject.GetComponent<Button>();
        position12Button = position12ButtonObject.GetComponent<Button>();
        position13Button = position13ButtonObject.GetComponent<Button>();
        position14Button = position14ButtonObject.GetComponent<Button>();
        position15Button = position15ButtonObject.GetComponent<Button>();
        position16Button = position16ButtonObject.GetComponent<Button>();
        position17Button = position17ButtonObject.GetComponent<Button>();
        position18Button = position18ButtonObject.GetComponent<Button>();
        position19Button = position19ButtonObject.GetComponent<Button>();
        position20Button = position20ButtonObject.GetComponent<Button>();
        position21Button = position21ButtonObject.GetComponent<Button>();
        position22Button = position22ButtonObject.GetComponent<Button>();
        position23Button = position23ButtonObject.GetComponent<Button>();
        position24Button = position24ButtonObject.GetComponent<Button>();
        position25Button = position25ButtonObject.GetComponent<Button>();
        position26Button = position26ButtonObject.GetComponent<Button>();
        position27Button = position27ButtonObject.GetComponent<Button>();
        position28Button = position28ButtonObject.GetComponent<Button>();
        position29Button = position29ButtonObject.GetComponent<Button>();
        position30Button = position30ButtonObject.GetComponent<Button>();
        position31Button = position31ButtonObject.GetComponent<Button>();
        position32Button = position32ButtonObject.GetComponent<Button>();
        position33Button = position33ButtonObject.GetComponent<Button>();
        position34Button = position34ButtonObject.GetComponent<Button>();
        position35Button = position35ButtonObject.GetComponent<Button>();
        position36Button = position36ButtonObject.GetComponent<Button>();
        position37Button = position37ButtonObject.GetComponent<Button>();
        position38Button = position38ButtonObject.GetComponent<Button>();
        position39Button = position39ButtonObject.GetComponent<Button>();
        position40Button = position40ButtonObject.GetComponent<Button>();
        position41Button = position41ButtonObject.GetComponent<Button>();
        position42Button = position42ButtonObject.GetComponent<Button>();
        position43Button = position43ButtonObject.GetComponent<Button>();
        position44Button = position44ButtonObject.GetComponent<Button>();
        position45Button = position45ButtonObject.GetComponent<Button>();
        position46Button = position46ButtonObject.GetComponent<Button>();
        position47Button = position47ButtonObject.GetComponent<Button>();
        position48Button = position48ButtonObject.GetComponent<Button>();
        position49Button = position49ButtonObject.GetComponent<Button>();
        position50Button = position50ButtonObject.GetComponent<Button>();
        position51Button = position51ButtonObject.GetComponent<Button>();
        position52Button = position52ButtonObject.GetComponent<Button>();
        position53Button = position53ButtonObject.GetComponent<Button>();
        position54Button = position54ButtonObject.GetComponent<Button>();
        position55Button = position55ButtonObject.GetComponent<Button>();
        position56Button = position56ButtonObject.GetComponent<Button>();
        position57Button = position57ButtonObject.GetComponent<Button>();
        position58Button = position58ButtonObject.GetComponent<Button>();
        position59Button = position59ButtonObject.GetComponent<Button>();
        position60Button = position60ButtonObject.GetComponent<Button>();
        position61Button = position61ButtonObject.GetComponent<Button>();
        position62Button = position62ButtonObject.GetComponent<Button>();
        position63Button = position63ButtonObject.GetComponent<Button>();
        position64Button = position64ButtonObject.GetComponent<Button>();
        position65Button = position65ButtonObject.GetComponent<Button>();
        position66Button = position66ButtonObject.GetComponent<Button>();
        position67Button = position67ButtonObject.GetComponent<Button>();
        position68Button = position68ButtonObject.GetComponent<Button>();
        position69Button = position69ButtonObject.GetComponent<Button>();
        position70Button = position70ButtonObject.GetComponent<Button>();
        position71Button = position71ButtonObject.GetComponent<Button>();
        position72Button = position72ButtonObject.GetComponent<Button>();
        position73Button = position73ButtonObject.GetComponent<Button>();
        position74Button = position74ButtonObject.GetComponent<Button>();
        position75Button = position75ButtonObject.GetComponent<Button>();
        position76Button = position76ButtonObject.GetComponent<Button>();
        position77Button = position77ButtonObject.GetComponent<Button>();
        position78Button = position78ButtonObject.GetComponent<Button>();
        position79Button = position79ButtonObject.GetComponent<Button>();
        position80Button = position80ButtonObject.GetComponent<Button>();
        position81Button = position81ButtonObject.GetComponent<Button>();
        position82Button = position82ButtonObject.GetComponent<Button>();
        position83Button = position83ButtonObject.GetComponent<Button>();
        position84Button = position84ButtonObject.GetComponent<Button>();
        position85Button = position85ButtonObject.GetComponent<Button>();
        position86Button = position86ButtonObject.GetComponent<Button>();
        position87Button = position87ButtonObject.GetComponent<Button>();
        position88Button = position88ButtonObject.GetComponent<Button>();
        position89Button = position89ButtonObject.GetComponent<Button>();
        position90Button = position90ButtonObject.GetComponent<Button>();
        position91Button = position91ButtonObject.GetComponent<Button>();
        position92Button = position92ButtonObject.GetComponent<Button>();
        position93Button = position93ButtonObject.GetComponent<Button>();
        position94Button = position94ButtonObject.GetComponent<Button>();
        position95Button = position95ButtonObject.GetComponent<Button>();
        position96Button = position96ButtonObject.GetComponent<Button>();
        position97Button = position97ButtonObject.GetComponent<Button>();
        position98Button = position98ButtonObject.GetComponent<Button>();
        position99Button = position99ButtonObject.GetComponent<Button>();
        position100Button = position100ButtonObject.GetComponent<Button>();
        position101Button = position101ButtonObject.GetComponent<Button>();
        position102Button = position102ButtonObject.GetComponent<Button>();
        position103Button = position103ButtonObject.GetComponent<Button>();
        position104Button = position104ButtonObject.GetComponent<Button>();
        position105Button = position105ButtonObject.GetComponent<Button>();
        position106Button = position106ButtonObject.GetComponent<Button>();
        position107Button = position107ButtonObject.GetComponent<Button>();
        position108Button = position108ButtonObject.GetComponent<Button>();
        position109Button = position109ButtonObject.GetComponent<Button>();
        position110Button = position110ButtonObject.GetComponent<Button>();
        position111Button = position111ButtonObject.GetComponent<Button>();
        position112Button = position112ButtonObject.GetComponent<Button>();
        position113Button = position113ButtonObject.GetComponent<Button>();
        position114Button = position114ButtonObject.GetComponent<Button>();
        position115Button = position115ButtonObject.GetComponent<Button>();
        position116Button = position116ButtonObject.GetComponent<Button>();
        position117Button = position117ButtonObject.GetComponent<Button>();
        position118Button = position118ButtonObject.GetComponent<Button>();
        position119Button = position119ButtonObject.GetComponent<Button>();
        position120Button = position120ButtonObject.GetComponent<Button>();
        position121Button = position121ButtonObject.GetComponent<Button>();
        position122Button = position122ButtonObject.GetComponent<Button>();
        position123Button = position123ButtonObject.GetComponent<Button>();
        position124Button = position124ButtonObject.GetComponent<Button>();
        position125Button = position125ButtonObject.GetComponent<Button>();
        position126Button = position126ButtonObject.GetComponent<Button>();
        position1Button.onClick.AddListener(BuildPosition1);
        position2Button.onClick.AddListener(BuildPosition2);
        position3Button.onClick.AddListener(BuildPosition3);
        position4Button.onClick.AddListener(BuildPosition4);
        position5Button.onClick.AddListener(BuildPosition5);
        position6Button.onClick.AddListener(BuildPosition6);
        position7Button.onClick.AddListener(BuildPosition7);
        position8Button.onClick.AddListener(BuildPosition8);
        position9Button.onClick.AddListener(BuildPosition9);
        position10Button.onClick.AddListener(BuildPosition10);
        position11Button.onClick.AddListener(BuildPosition11);
        position12Button.onClick.AddListener(BuildPosition12);
        position13Button.onClick.AddListener(BuildPosition13);
        position14Button.onClick.AddListener(BuildPosition14);
        position15Button.onClick.AddListener(BuildPosition15);
        position16Button.onClick.AddListener(BuildPosition16);
        position17Button.onClick.AddListener(BuildPosition17);
        position18Button.onClick.AddListener(BuildPosition18);
        position19Button.onClick.AddListener(BuildPosition19);
        position20Button.onClick.AddListener(BuildPosition20);
        position21Button.onClick.AddListener(BuildPosition21);
        position22Button.onClick.AddListener(BuildPosition22);
        position23Button.onClick.AddListener(BuildPosition23);
        position24Button.onClick.AddListener(BuildPosition24);
        position25Button.onClick.AddListener(BuildPosition25);
        position26Button.onClick.AddListener(BuildPosition26);
        position27Button.onClick.AddListener(BuildPosition27);
        position28Button.onClick.AddListener(BuildPosition28);
        position29Button.onClick.AddListener(BuildPosition29);
        position30Button.onClick.AddListener(BuildPosition30);
        position31Button.onClick.AddListener(BuildPosition31);
        position32Button.onClick.AddListener(BuildPosition32);
        position33Button.onClick.AddListener(BuildPosition33);
        position34Button.onClick.AddListener(BuildPosition34);
        position35Button.onClick.AddListener(BuildPosition35);
        position36Button.onClick.AddListener(BuildPosition36);
        position37Button.onClick.AddListener(BuildPosition37);
        position38Button.onClick.AddListener(BuildPosition38);
        position39Button.onClick.AddListener(BuildPosition39);
        position40Button.onClick.AddListener(BuildPosition40);
        position41Button.onClick.AddListener(BuildPosition41);
        position42Button.onClick.AddListener(BuildPosition42);
        position43Button.onClick.AddListener(BuildPosition43);
        position44Button.onClick.AddListener(BuildPosition44);
        position45Button.onClick.AddListener(BuildPosition45);
        position46Button.onClick.AddListener(BuildPosition46);
        position47Button.onClick.AddListener(BuildPosition47);
        position48Button.onClick.AddListener(BuildPosition48);
        position49Button.onClick.AddListener(BuildPosition49);
        position50Button.onClick.AddListener(BuildPosition50);
        position51Button.onClick.AddListener(BuildPosition51);
        position52Button.onClick.AddListener(BuildPosition52);
        position53Button.onClick.AddListener(BuildPosition53);
        position54Button.onClick.AddListener(BuildPosition54);
        position55Button.onClick.AddListener(BuildPosition55);
        position56Button.onClick.AddListener(BuildPosition56);
        position57Button.onClick.AddListener(BuildPosition57);
        position58Button.onClick.AddListener(BuildPosition58);
        position59Button.onClick.AddListener(BuildPosition59);
        position60Button.onClick.AddListener(BuildPosition60);
        position61Button.onClick.AddListener(BuildPosition61);
        position62Button.onClick.AddListener(BuildPosition62);
        position63Button.onClick.AddListener(BuildPosition63);
        position64Button.onClick.AddListener(BuildPosition64);
        position65Button.onClick.AddListener(BuildPosition65);
        position66Button.onClick.AddListener(BuildPosition66);
        position67Button.onClick.AddListener(BuildPosition67);
        position68Button.onClick.AddListener(BuildPosition68);
        position69Button.onClick.AddListener(BuildPosition69);
        position70Button.onClick.AddListener(BuildPosition70);
        position71Button.onClick.AddListener(BuildPosition71);
        position72Button.onClick.AddListener(BuildPosition72);
        position73Button.onClick.AddListener(BuildPosition73);
        position74Button.onClick.AddListener(BuildPosition74);
        position75Button.onClick.AddListener(BuildPosition75);
        position76Button.onClick.AddListener(BuildPosition76);
        position77Button.onClick.AddListener(BuildPosition77);
        position78Button.onClick.AddListener(BuildPosition78);
        position79Button.onClick.AddListener(BuildPosition79);
        position80Button.onClick.AddListener(BuildPosition80);
        position81Button.onClick.AddListener(BuildPosition81);
        position82Button.onClick.AddListener(BuildPosition82);
        position83Button.onClick.AddListener(BuildPosition83);
        position84Button.onClick.AddListener(BuildPosition84);
        position85Button.onClick.AddListener(BuildPosition85);
        position86Button.onClick.AddListener(BuildPosition86);
        position87Button.onClick.AddListener(BuildPosition87);
        position88Button.onClick.AddListener(BuildPosition88);
        position89Button.onClick.AddListener(BuildPosition89);
        position90Button.onClick.AddListener(BuildPosition90);
        position91Button.onClick.AddListener(BuildPosition91);
        position92Button.onClick.AddListener(BuildPosition92);
        position93Button.onClick.AddListener(BuildPosition93);
        position94Button.onClick.AddListener(BuildPosition94);
        position95Button.onClick.AddListener(BuildPosition95);
        position96Button.onClick.AddListener(BuildPosition96);
        position97Button.onClick.AddListener(BuildPosition97);
        position98Button.onClick.AddListener(BuildPosition98);
        position99Button.onClick.AddListener(BuildPosition99);
        position100Button.onClick.AddListener(BuildPosition100);
        position101Button.onClick.AddListener(BuildPosition101);
        position102Button.onClick.AddListener(BuildPosition102);
        position103Button.onClick.AddListener(BuildPosition103);
        position104Button.onClick.AddListener(BuildPosition104);
        position105Button.onClick.AddListener(BuildPosition105);
        position106Button.onClick.AddListener(BuildPosition106);
        position107Button.onClick.AddListener(BuildPosition107);
        position108Button.onClick.AddListener(BuildPosition108);
        position109Button.onClick.AddListener(BuildPosition109);
        position110Button.onClick.AddListener(BuildPosition110);
        position111Button.onClick.AddListener(BuildPosition111);
        position112Button.onClick.AddListener(BuildPosition112);
        position113Button.onClick.AddListener(BuildPosition113);
        position114Button.onClick.AddListener(BuildPosition114);
        position115Button.onClick.AddListener(BuildPosition115);
        position116Button.onClick.AddListener(BuildPosition116);
        position117Button.onClick.AddListener(BuildPosition117);
        position118Button.onClick.AddListener(BuildPosition118);
        position119Button.onClick.AddListener(BuildPosition119);
        position120Button.onClick.AddListener(BuildPosition120);
        position121Button.onClick.AddListener(BuildPosition121);
        position122Button.onClick.AddListener(BuildPosition122);
        position123Button.onClick.AddListener(BuildPosition123);
        position124Button.onClick.AddListener(BuildPosition124);
        position125Button.onClick.AddListener(BuildPosition125);
        position126Button.onClick.AddListener(BuildPosition126);
    }
    void BuildPosition1()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position1Recruit)
            {
                currentBuildingScript.position1R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position1ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position1ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position1Recruit = true;
                FinishBuild();
            }
            else if(!gameManagerScript.recruiting && !position1Building)
            {
                currentBuildingScript.position1 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position1ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position1ButtonObject.transform.position.z);
                position1Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition2()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position2Recruit)
            {
                currentBuildingScript.position2R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position2ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position2ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position2Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position2Building)
            {
                currentBuildingScript.position2 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position2ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position2ButtonObject.transform.position.z);
                position2Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition3()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position3Recruit)
            {
                currentBuildingScript.position3R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position3ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position3ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position3Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position3Building)
            {
                currentBuildingScript.position3 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position3ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position3ButtonObject.transform.position.z);
                position3Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition4()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position4Recruit)
            {
                currentBuildingScript.position4R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position4ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position4ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position4Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position4Building)
            {
                currentBuildingScript.position4 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position4ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position4ButtonObject.transform.position.z);
                position4Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition5()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position5Recruit)
            {
                currentBuildingScript.position5R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position5ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position5ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position5Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position5Building)
            {
                currentBuildingScript.position5 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position5ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position5ButtonObject.transform.position.z);
                position5Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition6()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position6Recruit)
            {
                currentBuildingScript.position6R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position6ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position6ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position6Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position6Building)
            {
                currentBuildingScript.position6 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position6ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position6ButtonObject.transform.position.z) + recruitOffset;
                position6Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition7()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position7Recruit)
            {
                currentBuildingScript.position7R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position7ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position7ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position7Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position7Building)
            {
                currentBuildingScript.position7 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position7ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position7ButtonObject.transform.position.z) + recruitOffset;
                position7Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition8()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position8Recruit)
            {
                currentBuildingScript.position8R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position8ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position8ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position8Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position8Building)
            {
                currentBuildingScript.position8 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position8ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position8ButtonObject.transform.position.z);
                position8Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition9()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position9Recruit)
            {
                currentBuildingScript.position9R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position9ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position9ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position9Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position9Building)
            {
                currentBuildingScript.position9 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position9ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position9ButtonObject.transform.position.z);
                position9Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition10()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position10Recruit)
            {
                currentBuildingScript.position10R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position10ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position10ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position10Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position10Building)
            {
                currentBuildingScript.position10 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position10ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position10ButtonObject.transform.position.z);
                position10Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition11()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position11Recruit)
            {
                currentBuildingScript.position11R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position11ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position11ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position11Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position11Building)
            {
                currentBuildingScript.position11 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position11ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position11ButtonObject.transform.position.z);
                position11Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition12()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position12Recruit)
            {
                currentBuildingScript.position12R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position12ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position12ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position12Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position12Building)
            {
                currentBuildingScript.position12 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position12ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position12ButtonObject.transform.position.z);
                position12Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition13()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position13Recruit)
            {
                currentBuildingScript.position13R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position13ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position13ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position13Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position13Building)
            {
                currentBuildingScript.position13 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position13ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position13ButtonObject.transform.position.z);
                position13Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition14()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position14Recruit)
            {
                currentBuildingScript.position14R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position14ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position14ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position14Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position14Building)
            {
                currentBuildingScript.position14 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position14ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position14ButtonObject.transform.position.z);
                position14Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition15()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position15Recruit)
            {
                currentBuildingScript.position15R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position15ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position15ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position15Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position15Building)
            {
                currentBuildingScript.position15 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position15ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position15ButtonObject.transform.position.z);
                position15Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition16()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position16Recruit)
            {
                currentBuildingScript.position16R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position16ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position16ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position16Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position16Building)
            {
                currentBuildingScript.position16 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position16ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position16ButtonObject.transform.position.z);
                position16Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition17()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position17Recruit)
            {
                currentBuildingScript.position17R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position17ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position17ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position17Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position17Building)
            {
                currentBuildingScript.position17 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position17ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position17ButtonObject.transform.position.z);
                position17Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition18()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position18Recruit)
            {
                currentBuildingScript.position18R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position18ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position18ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position18Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position1Building)
            {
                currentBuildingScript.position18 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position18ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position18ButtonObject.transform.position.z) + recruitOffset;
                position18Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition19()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position19Recruit)
            {
                currentBuildingScript.position19R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position19ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position19ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position19Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position19Building)
            {
                currentBuildingScript.position19 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position19ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position19ButtonObject.transform.position.z);
                position19Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition20()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position20Recruit)
            {
                currentBuildingScript.position20R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position20ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position20ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position20Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position20Building)
            {
                currentBuildingScript.position20 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position20ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position20ButtonObject.transform.position.z);
                position20Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition21()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position21Recruit)
            {
                currentBuildingScript.position21R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position21ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position21ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position21Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position21Building)
            {
                currentBuildingScript.position21 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position21ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position21ButtonObject.transform.position.z);
                position21Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition22()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position22Recruit)
            {
                currentBuildingScript.position22R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position22ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position22ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position22Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position22Building)
            {
                currentBuildingScript.position22 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position22ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position22ButtonObject.transform.position.z);
                position22Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition23()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position23Recruit)
            {
                currentBuildingScript.position23R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position23ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position23ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position23Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position23Building)
            {
                currentBuildingScript.position23 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position23ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position23ButtonObject.transform.position.z);
                position23Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition24()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position24Recruit)
            {
                currentBuildingScript.position24R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position24ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position24ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position24Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position24Building)
            {
                currentBuildingScript.position24 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position24ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position24ButtonObject.transform.position.z);
                position24Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition25()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position25Recruit)
            {
                currentBuildingScript.position25R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position25ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position25ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position25Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position25Building)
            {
                currentBuildingScript.position25 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position25ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position25ButtonObject.transform.position.z);
                position25Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition26()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position26Recruit)
            {
                currentBuildingScript.position26R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position26ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position26ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position26Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position26Building)
            {
                currentBuildingScript.position26 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position26ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position26ButtonObject.transform.position.z);
                position26Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition27()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position27Recruit)
            {
                currentBuildingScript.position27R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position27ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position27ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position27Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position27Building)
            {
                currentBuildingScript.position27 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position27ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position27ButtonObject.transform.position.z);
                position27Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition28()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position28Recruit)
            {
                currentBuildingScript.position28R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position28ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position28ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position28Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position28Building)
            {
                currentBuildingScript.position28 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position28ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position28ButtonObject.transform.position.z);
                position28Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition29()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position29Recruit)
            {
                currentBuildingScript.position29R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position29ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position29ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position29Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position29Building)
            {
                currentBuildingScript.position29 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position29ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position29ButtonObject.transform.position.z);
                position29Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition30()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position30Recruit)
            {
                currentBuildingScript.position30R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position30ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position30ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position30Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position30Building)
            {
                currentBuildingScript.position30 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position30ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position30ButtonObject.transform.position.z);
                position30Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition31()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position31Recruit)
            {
                currentBuildingScript.position31R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position31ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position31ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position31Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position31Building)
            {
                currentBuildingScript.position31 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position31ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position31ButtonObject.transform.position.z);
                position31Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition32()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position32Recruit)
            {
                currentBuildingScript.position32R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position32ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position32ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position32Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position32Building)
            {
                currentBuildingScript.position32 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position32ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position32ButtonObject.transform.position.z);
                position32Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition33()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position33Recruit)
            {
                currentBuildingScript.position33R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position33ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position33ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position33Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position33Building)
            {
                currentBuildingScript.position33 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position33ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position33ButtonObject.transform.position.z);
                position33Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition34()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position34Recruit)
            {
                currentBuildingScript.position34R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position34ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position34ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position34Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position34Building)
            {
                currentBuildingScript.position34 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position34ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position34ButtonObject.transform.position.z);
                position34Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition35()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position35Recruit)
            {
                currentBuildingScript.position35R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position35ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position35ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position35Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position35Building)
            {
                currentBuildingScript.position35 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position35ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position35ButtonObject.transform.position.z);
                position35Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition36()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position36Recruit)
            {
                currentBuildingScript.position36R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position36ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position36ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position36Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position36Building)
            {
                currentBuildingScript.position36 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position36ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position36ButtonObject.transform.position.z);
                position36Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition37()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position37Recruit)
            {
                currentBuildingScript.position37R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position37ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position37ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position37Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position37Building)
            {
                currentBuildingScript.position37 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position37ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position37ButtonObject.transform.position.z);
                position37Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition38()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position38Recruit)
            {
                currentBuildingScript.position38R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position38ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position38ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position38Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position38Building)
            {
                currentBuildingScript.position38 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position38ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position38ButtonObject.transform.position.z);
                position38Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition39()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position39Recruit)
            {
                currentBuildingScript.position39R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position39ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position39ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position39Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position39Building)
            {
                currentBuildingScript.position39 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position39ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position39ButtonObject.transform.position.z);
                position39Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition40()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position40Recruit)
            {
                Debug.Log("R");
                currentBuildingScript.position40R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position40ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position40ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position40Recruit = true;
                FinishBuild();
            }
            if (!gameManagerScript.recruiting && !position40Building)
            {
                Debug.Log("built");
                currentBuildingScript.position40 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position40ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position40ButtonObject.transform.position.z);
                position40Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition41()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position41Recruit)
            {
                currentBuildingScript.position41R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position41ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position41ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position41Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position41Building)
            {
                currentBuildingScript.position41 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position41ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position41ButtonObject.transform.position.z);
                position41Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition42()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position42Recruit)
            {
                currentBuildingScript.position42R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position42ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position42ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position42Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position42Building)
            {
                currentBuildingScript.position42 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position42ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position42ButtonObject.transform.position.z);
                position42Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition43()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position43Recruit)
            {
                currentBuildingScript.position43R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position43ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position43ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position43Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position43Building)
            {
                currentBuildingScript.position43 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position43ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position43ButtonObject.transform.position.z);
                position43Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition44()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position44Recruit)
            {
                currentBuildingScript.position44R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position44ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position44ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position44Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position44Building)
            {
                currentBuildingScript.position44 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position44ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position44ButtonObject.transform.position.z);
                position44Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition45()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position45Recruit)
            {
                currentBuildingScript.position45R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position45ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position45ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position45Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position45Building)
            {
                currentBuildingScript.position45 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position45ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position45ButtonObject.transform.position.z);
                position45Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition46()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position46Recruit)
            {
                currentBuildingScript.position46R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position46ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position46ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position46Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position46Building)
            {
                currentBuildingScript.position46 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position46ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position46ButtonObject.transform.position.z);
                position46Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition47()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position47Recruit)
            {
                currentBuildingScript.position47R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position47ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position47ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position47Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position47Building)
            {
                currentBuildingScript.position47 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position47ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position47ButtonObject.transform.position.z);
                position47Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition48()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position48Recruit)
            {
                currentBuildingScript.position48R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position48ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position48ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position48Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position48Building)
            {
                currentBuildingScript.position48 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position48ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position48ButtonObject.transform.position.z);
                position48Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition49()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position49Recruit)
            {
                currentBuildingScript.position49R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position49ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position49ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position49Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position49Building)
            {
                currentBuildingScript.position49 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position49ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position49ButtonObject.transform.position.z);
                position49Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition50()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position50Recruit)
            {
                currentBuildingScript.position50R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position50ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position50ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position50Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position50Building)
            {
                currentBuildingScript.position50 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position50ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position50ButtonObject.transform.position.z);
                position50Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition51()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position51Recruit)
            {
                currentBuildingScript.position51R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position51ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position51ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position51Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position51Building)
            {
                currentBuildingScript.position51 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position51ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position51ButtonObject.transform.position.z);
                position51Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition52()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position52Recruit)
            {
                currentBuildingScript.position52R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position52ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position52ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position52Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position52Building)
            {
                currentBuildingScript.position52 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position52ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position52ButtonObject.transform.position.z);
                position52Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition53()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position53Recruit)
            {
                currentBuildingScript.position53R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position53ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position53ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position53Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position53Building)
            {
                currentBuildingScript.position53 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position53ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position53ButtonObject.transform.position.z);
                position53Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition54()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position54Recruit)
            {
                currentBuildingScript.position54R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position54ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position54ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position54Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position54Building)
            {
                currentBuildingScript.position54 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position54ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position54ButtonObject.transform.position.z);
                position54Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition55()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position55Recruit)
            {
                currentBuildingScript.position55R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position55ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position55ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position55Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position55Building)
            {
                currentBuildingScript.position55 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position55ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position55ButtonObject.transform.position.z);
                position55Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition56()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position56Recruit)
            {
                currentBuildingScript.position56R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position56ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position56ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position56Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position56Building)
            {
                currentBuildingScript.position56 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position56ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position56ButtonObject.transform.position.z);
                position56Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition57()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position57Recruit)
            {
                currentBuildingScript.position57R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position57ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position57ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position57Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position57Building)
            {
                currentBuildingScript.position57 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position57ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position57ButtonObject.transform.position.z);
                position57Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition58()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position58Recruit)
            {
                currentBuildingScript.position58R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position58ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position58ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position58Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position58Building)
            {
                currentBuildingScript.position58 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position58ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position58ButtonObject.transform.position.z);
                position58Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition59()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position59Recruit)
            {
                currentBuildingScript.position59R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position59ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position59ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position59Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position59Building)
            {
                currentBuildingScript.position59 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position59ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position59ButtonObject.transform.position.z);
                position59Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition60()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position60Recruit)
            {
                currentBuildingScript.position60R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position60ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position60ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position60Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position60Building)
            {
                currentBuildingScript.position60 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position60ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position60ButtonObject.transform.position.z);
                position60Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition61()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position61Recruit)
            {
                currentBuildingScript.position61R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position61ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position61ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position61Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position61Building)
            {
                currentBuildingScript.position61 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position61ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position61ButtonObject.transform.position.z);
                position61Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition62()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position62Recruit)
            {
                currentBuildingScript.position62R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position62ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position62ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position62Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position62Building)
            {
                currentBuildingScript.position62 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position62ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position62ButtonObject.transform.position.z);
                position62Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition63()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position63Recruit)
            {
                currentBuildingScript.position63R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position63ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position63ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position63Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position63Building)
            {
                currentBuildingScript.position63 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position63ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position63ButtonObject.transform.position.z);
                position63Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition64()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position64Recruit)
            {
                currentBuildingScript.position64R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position64ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position64ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position64Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position64Building)
            {
                currentBuildingScript.position64 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position64ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position64ButtonObject.transform.position.z);
                position64Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition65()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position65Recruit)
            {
                currentBuildingScript.position65R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position65ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position65ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position65Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position65Building)
            {
                currentBuildingScript.position65 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position65ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position65ButtonObject.transform.position.z);
                position65Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition66()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position66Recruit)
            {
                currentBuildingScript.position66R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position66ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position66ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position66Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position66Building)
            {
                currentBuildingScript.position66 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position66ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position66ButtonObject.transform.position.z);
                position66Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition67()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position67Recruit)
            {
                currentBuildingScript.position67R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position67ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position67ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position67Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position67Building)
            {
                currentBuildingScript.position67 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position67ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position67ButtonObject.transform.position.z);
                position67Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition68()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position68Recruit)
            {
                currentBuildingScript.position68R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position68ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position68ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position68Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position68Building)
            {
                currentBuildingScript.position68 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position68ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position68ButtonObject.transform.position.z);
                position68Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition69()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position69Recruit)
            {
                currentBuildingScript.position69R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position69ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position69ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position69Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position69Building)
            {
                currentBuildingScript.position69 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position69ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position69ButtonObject.transform.position.z);
                position69Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition70()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position70Recruit)
            {
                currentBuildingScript.position70R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position70ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position70ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position70Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position70Building)
            {
                currentBuildingScript.position70 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position70ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position70ButtonObject.transform.position.z);
                position70Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition71()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position71Recruit)
            {
                currentBuildingScript.position71R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position71ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position71ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position71Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position71Building)
            {
                currentBuildingScript.position71 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position71ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position71ButtonObject.transform.position.z);
                position71Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition72()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position72Recruit)
            {
                currentBuildingScript.position72R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position72ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position72ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position72Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position72Building)
            {
                currentBuildingScript.position72 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position72ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position72ButtonObject.transform.position.z);
                position72Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition73()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position73Recruit)
            {
                currentBuildingScript.position73R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position73ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position73ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position73Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position73Building)
            {
                currentBuildingScript.position73 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position73ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position73ButtonObject.transform.position.z);
                position73Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition74()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position74Recruit)
            {
                currentBuildingScript.position74R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position74ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position74ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position74Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position74Building)
            {
                currentBuildingScript.position74 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position74ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position74ButtonObject.transform.position.z);
                position74Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition75()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position75Recruit)
            {
                currentBuildingScript.position7R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position75ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position75ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position75Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position75Building)
            {
                currentBuildingScript.position75 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position75ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position75ButtonObject.transform.position.z);
                position75Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition76()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position76Recruit)
            {
                currentBuildingScript.position76R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position76ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position76ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position76Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position76Building)
            {
                currentBuildingScript.position76 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position76ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position76ButtonObject.transform.position.z);
                position76Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition77()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position77Recruit)
            {
                currentBuildingScript.position77R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position77ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position77ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position77Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position77Building)
            {
                currentBuildingScript.position77 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position77ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position77ButtonObject.transform.position.z);
                position77Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition78()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position78Recruit)
            {
                currentBuildingScript.position78R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position78ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position78ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position78Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position78Building)
            {
                currentBuildingScript.position78 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position78ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position78ButtonObject.transform.position.z);
                position78Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition79()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position79Recruit)
            {
                currentBuildingScript.position79R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position79ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position79ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position79Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position79Building)
            {
                currentBuildingScript.position79 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position79ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position79ButtonObject.transform.position.z);
                position79Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition80()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position80Recruit)
            {
                currentBuildingScript.position80R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position80ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position80ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position80Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position80Building)
            {
                currentBuildingScript.position80 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position80ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position80ButtonObject.transform.position.z);
                position80Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition81()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position81Recruit)
            {
                currentBuildingScript.position81R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position81ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position81ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position81Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position81Building)
            {
                currentBuildingScript.position81 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position81ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position81ButtonObject.transform.position.z);
                position81Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition82()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position82Recruit)
            {
                currentBuildingScript.position82R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position82ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position82ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position82Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position82Building)
            {
                currentBuildingScript.position82 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position82ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position82ButtonObject.transform.position.z);
                position82Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition83()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position83Recruit)
            {
                currentBuildingScript.position83R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position83ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position83ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position83Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position83Building)
            {
                currentBuildingScript.position83 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position83ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position83ButtonObject.transform.position.z);
                position83Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition84()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position84Recruit)
            {
                currentBuildingScript.position84R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position84ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position84ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position84Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position84Building)
            {
                currentBuildingScript.position84 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position84ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position84ButtonObject.transform.position.z);
                position84Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition85()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position85Recruit)
            {
                currentBuildingScript.position85R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position85ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position85ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position85Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position85Building)
            {
                currentBuildingScript.position85 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position85ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position85ButtonObject.transform.position.z);
                position85Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition86()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position86Recruit)
            {
                currentBuildingScript.position86R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position86ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position86ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position86Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position86Building)
            {
                currentBuildingScript.position86 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position86ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position86ButtonObject.transform.position.z);
                position86Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition87()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position87Recruit)
            {
                currentBuildingScript.position87R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position87ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position87ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position87Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position87Building)
            {
                currentBuildingScript.position87 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position87ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position87ButtonObject.transform.position.z);
                position87Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition88()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position88Recruit)
            {
                currentBuildingScript.position88R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position88ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position88ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position88Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position88Building)
            {
                currentBuildingScript.position88 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position88ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position88ButtonObject.transform.position.z);
                position88Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition89()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position89Recruit)
            {
                currentBuildingScript.position89R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position89ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position89ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position89Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position89Building)
            {
                currentBuildingScript.position89 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position89ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position89ButtonObject.transform.position.z);
                position89Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition90()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position90Recruit)
            {
                currentBuildingScript.position90R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position90ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position90ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position90Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position90Building)
            {
                currentBuildingScript.position90 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position90ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position90ButtonObject.transform.position.z);
                position90Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition91()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position91Recruit)
            {
                currentBuildingScript.position91R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position91ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position91ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position91Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position91Building)
            {
                currentBuildingScript.position91 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position91ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position91ButtonObject.transform.position.z);
                position91Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition92()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position92Recruit)
            {
                currentBuildingScript.position92R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position92ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position92ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position92Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position92Building)
            {
                currentBuildingScript.position92 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position92ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position92ButtonObject.transform.position.z);
                position92Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition93()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position93Recruit)
            {
                currentBuildingScript.position93R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position93ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position93ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position93Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position93Building)
            {
                currentBuildingScript.position93 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position93ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position93ButtonObject.transform.position.z);
                position93Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition94()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position94Recruit)
            {
                currentBuildingScript.position94R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position94ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position94ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position94Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position94Building)
            {
                currentBuildingScript.position94 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position94ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position94ButtonObject.transform.position.z);
                position94Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition95()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position95Recruit)
            {
                currentBuildingScript.position95R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position95ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position95ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position95Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position95Building)
            {
                currentBuildingScript.position95 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position95ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position95ButtonObject.transform.position.z);
                position95Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition96()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position96Recruit)
            {
                currentBuildingScript.position96R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position96ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position96ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position96Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position96Building)
            {
                currentBuildingScript.position96 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position96ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position96ButtonObject.transform.position.z);
                position96Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition97()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position97Recruit)
            {
                currentBuildingScript.position97R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position97ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position97ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position97Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position97Building)
            {
                currentBuildingScript.position97 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position97ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position97ButtonObject.transform.position.z);
                position97Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition98()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position98Recruit)
            {
                currentBuildingScript.position98R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position98ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position98ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position98Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position98Building)
            {
                currentBuildingScript.position98 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position98ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position98ButtonObject.transform.position.z);
                position98Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition99()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position99Recruit)
            {
                currentBuildingScript.position99R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position99ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position99ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position99Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position99Building)
            {
                currentBuildingScript.position99 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position99ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position99ButtonObject.transform.position.z);
                position99Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition100()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position100Recruit)
            {
                currentBuildingScript.position100R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position100ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position100ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position100Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position100Building)
            {
                currentBuildingScript.position100 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position100ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position100ButtonObject.transform.position.z);
                position100Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition101()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position101Recruit)
            {
                currentBuildingScript.position101R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position101ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position101ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position101Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position101Building)
            {
                currentBuildingScript.position101 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position101ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position101ButtonObject.transform.position.z);
                position101Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition102()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position102Recruit)
            {
                currentBuildingScript.position102R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position102ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position102ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position102Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position102Building)
            {
                currentBuildingScript.position102 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position102ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position102ButtonObject.transform.position.z);
                position102Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition103()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position103Recruit)
            {
                currentBuildingScript.position103R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position103ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position103ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position103Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position103Building)
            {
                currentBuildingScript.position103 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position103ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position103ButtonObject.transform.position.z);
                position103Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition104()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position104Recruit)
            {
                currentBuildingScript.position104R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position104ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position104ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position104Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position104Building)
            {
                currentBuildingScript.position104 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position104ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position104ButtonObject.transform.position.z);
                position104Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition105()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position105Recruit)
            {
                currentBuildingScript.position105R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position105ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position105ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position105Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position105Building)
            {
                currentBuildingScript.position105 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position105ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position105ButtonObject.transform.position.z);
                position105Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition106()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position106Recruit)
            {
                currentBuildingScript.position106R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position106ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position106ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position106Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position106Building)
            {
                currentBuildingScript.position106 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position106ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position106ButtonObject.transform.position.z);
                position106Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition107()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position107Recruit)
            {
                currentBuildingScript.position107R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position107ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position107ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position107Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position107Building)
            {
                currentBuildingScript.position107 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position107ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position107ButtonObject.transform.position.z);
                position107Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition108()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position108Recruit)
            {
                currentBuildingScript.position108R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position108ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position108ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position108Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position108Building)
            {
                currentBuildingScript.position108 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position108ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position108ButtonObject.transform.position.z);
                position108Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition109()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position109Recruit)
            {
                currentBuildingScript.position109R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position109ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position109ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position109Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position109Building)
            {
                currentBuildingScript.position109 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position109ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position109ButtonObject.transform.position.z);
                position109Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition110()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position110Recruit)
            {
                currentBuildingScript.position110R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position110ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position110ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position110Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position110Building)
            {
                currentBuildingScript.position110 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position110ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position110ButtonObject.transform.position.z);
                position110Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition111()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position111Recruit)
            {
                currentBuildingScript.position111R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position111ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position111ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position111Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position111Building)
            {
                currentBuildingScript.position111 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position111ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position111ButtonObject.transform.position.z);
                position111Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition112()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position112Recruit)
            {
                currentBuildingScript.position112R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position112ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position112ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position112Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position112Building)
            {
                currentBuildingScript.position112 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position112ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position112ButtonObject.transform.position.z);
                position112Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition113()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position113Recruit)
            {
                currentBuildingScript.position113R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position113ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position113ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position113Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position113Building)
            {
                currentBuildingScript.position113 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position113ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position113ButtonObject.transform.position.z);
                position113Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition114()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position114Recruit)
            {
                currentBuildingScript.position114R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position114ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position114ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position114Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position114Building)
            {
                currentBuildingScript.position114 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position114ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position114ButtonObject.transform.position.z);
                position114Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition115()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position115Recruit)
            {
                currentBuildingScript.position115R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position115ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position115ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position115Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position115Building)
            {
                currentBuildingScript.position115 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position115ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position115ButtonObject.transform.position.z);
                position115Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition116()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position116Recruit)
            {
                currentBuildingScript.position116R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position116ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position116ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position116Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position116Building)
            {
                currentBuildingScript.position116 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position116ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position116ButtonObject.transform.position.z);
                position116Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition117()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position117Recruit)
            {
                currentBuildingScript.position117R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position117ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position117ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position117Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position117Building)
            {
                currentBuildingScript.position117 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position117ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position117ButtonObject.transform.position.z);
                position117Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition118()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position118Recruit)
            {
                currentBuildingScript.position118R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position118ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position118ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position118Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position118Building)
            {
                currentBuildingScript.position118 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position118ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position118ButtonObject.transform.position.z);
                position118Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition119()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position119Recruit)
            {
                currentBuildingScript.position119R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position119ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position119ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position119Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position119Building)
            {
                currentBuildingScript.position119 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position119ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position119ButtonObject.transform.position.z);
                position119Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition120()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position120Recruit)
            {
                currentBuildingScript.position120R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position120ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position120ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position120Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position120Building)
            {
                currentBuildingScript.position120 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position120ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position120ButtonObject.transform.position.z);
                position120Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition121()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position121Recruit)
            {
                currentBuildingScript.position121R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position121ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position121ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position121Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position121Building)
            {
                currentBuildingScript.position121 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position121ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position121ButtonObject.transform.position.z);
                position121Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition122()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position122Recruit)
            {
                currentBuildingScript.position122R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position122ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position122ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position122Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position122Building)
            {
                currentBuildingScript.position122 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position122ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position122ButtonObject.transform.position.z);
                position122Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition123()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position123Recruit)
            {
                currentBuildingScript.position123R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position123ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position123ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position123Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position123Building)
            {
                currentBuildingScript.position123 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position123ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position123ButtonObject.transform.position.z);
                position123Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition124()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position124Recruit)
            {
                currentBuildingScript.position124R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position124ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position124ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position124Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position124Building)
            {
                currentBuildingScript.position124 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position124ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position124ButtonObject.transform.position.z);
                position124Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition125()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position125Recruit)
            {
                currentBuildingScript.position125R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position125ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position125ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position125Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position125Building)
            {
                currentBuildingScript.position125 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position125ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position125ButtonObject.transform.position.z);
                position125Building = true;
                FinishBuild();
            }
        }
    }
    void BuildPosition126()
    {
        if (gameManagerScript.constructing)
        {
            currentBuildingScript = gameManagerScript.currentBuildingScript;
            if (gameManagerScript.recruiting && !position126Recruit)
            {
                currentBuildingScript.position126R = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position126ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position126ButtonObject.transform.position.z) + recruitOffset;
                currentBuildingScript.startPosition = gameManagerScript.currentBuilding.transform.position;
                position126Recruit = true;
                FinishBuild();
            }
            else if (!gameManagerScript.recruiting && !position126Building)
            {
                currentBuildingScript.position126 = true;
                gameManagerScript.currentBuilding.transform.position = new Vector3(position126ButtonObject.transform.position.x, gameManagerScript.currentBuilding.transform.position.y, position126ButtonObject.transform.position.z);
                position126Building = true;
                FinishBuild();
            }
        }
    }
    void FinishBuild()
    {
        if (gameManagerScript.currentBuildingRangeFinder)
        {
            gameManagerScript.currentBuildingScript.rangeFinder.GetComponent<MeshRenderer>().enabled = false;
        }
        currentBuildingScript.startingPosition = gameManagerScript.currentBuilding.transform.position;
        gameManagerScript.GainGold(-gameManagerScript.currentBuildingCost);
        gameManagerScript.creationCamera.enabled = false;
        gameManagerScript.constructing = false;
        gameManagerScript.currentBuilding = null;
    }
}
