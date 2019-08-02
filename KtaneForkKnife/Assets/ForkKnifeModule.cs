using System;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using UnityEngine;
using Rnd = UnityEngine.Random;
using KModkit;
using Despacito;

public class ForkKnifeModule : MonoBehaviour {

    // The Fortnight
    // KTaNE modded module
    // manual and implementation by Livio
    // ©2019 Livio

    public KMBombInfo Bomb;
    public KMBombModule Module;
    public KMAudio Audio;

    public WebClient wc = new WebClient();

    public SpriteRenderer mapSprite;
    public SpriteRenderer Fortnightlogo;
    public SpriteRenderer Weapon;
    public SpriteRenderer Opponent;
    public SpriteRenderer Emote;
    public SpriteRenderer VictoryRoyale;
    public TextMesh Stage1AlightPosition;
    public TextMesh Stage2AttacStrategy;
    public KMSelectable presstopaybutton;
    public KMSelectable[] mapbuttons;
    public KMSelectable[] fitebuttons;
    public KMSelectable[] emotebuttons;
    public Sprite[] WeaponSprites;
    public Sprite[] EnemySprites;
    public Sprite[] EmoteSprites;

    private Locus correctLocus;
    private Weapon theWeapon;
    private Opponent theEnemy;

    public DateTime today = DateTime.Now.Date;
    public DateTime Area52;

    private List<Locus> locusses;
    private List<Emote> Emoti;

    private Locus[] _loci;
    private Weapon[] _weapons;
    private Opponent[] _opponents;
    private Okay[] _AttackStrategies;
    private Emote[] _emotes;

    private int StageOneDisplayInt;
    private int StageTwoDisplayInt;
    private int StageThreeDisplayInt;
    private static int _moduleIdCounter = 1;
    private int _moduleId;

    internal class BombStatus : MonoBehaviour
    {
        private Dictionary<string, string> WidgetResponses = new Dictionary<string, string>();
        public static BombStatus Instance;
        public GameObject HUD;
        public GameObject Edgework;
        public UnityEngine.UI.Text TimerPrefab;
        public UnityEngine.UI.Text TimerShadowPrefab;
        public UnityEngine.UI.Text StrikesPrefab;
        public UnityEngine.UI.Text SolvesPrefab;
        public UnityEngine.UI.Text NeediesPrefab;
        public UnityEngine.UI.Text ConfidencePrefab;
        public UnityEngine.UI.Text EdgeworkPrefab;
    }

        // Use this for initialization
        void Start()
    {
        _moduleId = _moduleIdCounter++;
        Starter();
        foreach (KMSelectable oke in mapbuttons)
            oke.gameObject.SetActive(false);
        foreach (KMSelectable oke in fitebuttons)
            oke.gameObject.SetActive(false);
        foreach (KMSelectable yes in emotebuttons)
            yes.gameObject.SetActive(false);
        Emote.gameObject.SetActive(false);
        VictoryRoyale.gameObject.SetActive(false);
        presstopaybutton.OnInteract += delegate
        {
            Audio.PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress, presstopaybutton.transform);
            HandleStageOne();
            return false;
        };
    }
    void generateNewOk()
    {
        theEnemy = _opponents.PickRandom();
        theWeapon = _weapons.PickRandom();
    }

    void Starter() {
        foreach (KMSelectable oke in mapbuttons)
            oke.gameObject.SetActive(false);
        foreach (KMSelectable oke in fitebuttons)
            oke.gameObject.SetActive(false);
        foreach (KMSelectable yes in emotebuttons)
            yes.gameObject.SetActive(false);
        Emote.gameObject.SetActive(false);
        VictoryRoyale.gameObject.SetActive(false);
        DateTime.TryParse("2019-09-20", out Area52);
        Ok ok;
        try
        {
            ok = JsonConvert.DeserializeObject<Ok>(wc.DownloadString(new Uri("https://api.exchangeratesapi.io/latest?base=AUD&symbols=USD")));
        } catch{
            ok = null; 
        };
        _loci = new Locus[]
        {
            new Locus {index = 1, visibleName = "Rubbish Intersection", condition = Bomb.GetSolvableModuleNames().Contains("Waste Management")},
            new Locus {index = 2, visibleName = "Expensive Establishment", condition = true},
            new Locus {index = 3, visibleName = "Area 52", condition = System.DateTime.Compare(today, Area52) > 0 },
            new Locus {index = 4, visibleName = "HTML is a programming language", condition = Bomb.GetOnIndicators().Contains("BOB")},
            new Locus {index = 5, visibleName = "“Mountain“", condition = Bomb.GetSerialNumberLetters().Any(x => new[] { 'I' }.Contains(x)) },
            new Locus {index = 6, visibleName = "Retirement Hell", condition = Bomb.GetSolvableModuleNames().Contains("Retirement")},
            new Locus {index = 7, visibleName = "Scary Place (dont go ther)", condition = false},
            new Locus {index = 8, visibleName = "“Lemon Snow“", condition = true},
            new Locus {index = 9, visibleName = "Wall'z Mart", condition = Bomb.GetSolvableModuleNames().Contains("Cheap Checkout")},
            new Locus {index = 10, visibleName = "Pillage Pond", condition = Bomb.GetSolvableModuleNames().Contains("Splitting the Loot")},
            new Locus {index = 11, visibleName = "Ktane headeights", condition = true},
            new Locus {index = 12, visibleName = "Ok", condition = Bomb.GetIndicators().Any(x => new[] { "K" }.Contains(x)) },
            new Locus {index = 13, visibleName = "Despacito Dancefloor", condition = Bomb.GetBatteryHolderCount() - Bomb.GetBatteryCount() < 0},
            new Locus {index = 14, visibleName = "Ligma Landing", condition = Bomb.GetSolvableModuleNames().Contains("Air Traffic Controller")},
            new Locus {index = 15, visibleName = "No", condition = false},
            new Locus {index = 16, visibleName = "Yes", condition = true },
            new Locus {index = 17, visibleName = "Australia", condition = false},
            //TODO: Add straya fix
            new Locus {index = 18, visibleName = "No Friends Notch", condition = Bomb.GetSolvableModuleNames().Contains("Bomb Diffusal")},
            new Locus {index = 19, visibleName = "Atomic Explosion", condition = Bomb.GetSolvableModuleNames().Contains("3D Maze")},
            new Locus {index = 20, visibleName = "Rainy Racecar", condition = true},
            new Locus {index = 21, visibleName = "Ligma Lake", condition = Bomb.GetSolvableModuleNames().Contains("Battleship")}
        };
        _weapons = new Weapon[]
        {
            new Weapon {name = "Ballpoint Pen", sprite = WeaponSprites[0], rarity = "com", attackDMG = 42, reloadTime = 6.3, spawnNumbers = new int[]{1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50 } },
            new Weapon {name = "Hugging Machine", sprite = WeaponSprites[1], rarity = "r", attackDMG = 69, reloadTime = 4.2, spawnNumbers = new int[]{11,12,13} },
            new Weapon {name = "Cut", sprite = WeaponSprites[2], rarity = "l", attackDMG = 75, reloadTime = 2.1, spawnNumbers = new int[]{14}},
            new Weapon {name = "Sharknado", sprite = WeaponSprites[3], rarity = "uncom", attackDMG = 52, reloadTime = 3.5, spawnNumbers = new int[]{ 15, 16, 17, 18, 19 } },
            new Weapon {name = "Green Apple Yeeter", sprite = WeaponSprites[4], rarity = "l", attackDMG = 302, reloadTime = 10.32, spawnNumbers = new int[]{20}},
            new Weapon {name = "Hunting", sprite = WeaponSprites[5], rarity = "r", attackDMG = 99, reloadTime = 2.4, spawnNumbers = new int[]{21, 22, 23}},
            new Weapon {name = "Shoot Thing", sprite = WeaponSprites[6], rarity = "uncom", attackDMG = 22, reloadTime = 1.2, spawnNumbers = new int[]{24, 25, 26, 27, 28}},
            new Weapon {name = "AR-15", sprite = WeaponSprites[7], rarity = "r", attackDMG = 20, reloadTime = 3.5, spawnNumbers = new int[]{29, 30, 31} }
        };
        _opponents = new Opponent[]
        {
            new Opponent {name = "Balloon", sprite = EnemySprites[0], attackDMG = (Convert.ToInt32(Bomb.GetSolvedModuleNames().Count / (Bomb.GetSolvableModuleNames().Count - Bomb.GetSolvedModuleNames().Count)*100))%100, health = Bomb.GetBatteryCount()*10, spawnNumbers = new int[]{ 1 } },
            new Opponent {name = "Noskin", sprite = EnemySprites[1], attackDMG = 10, health = 65, spawnNumbers = new int[]{ 2, 3, 4 } },
            new Opponent {name = "Ucinorn", sprite = EnemySprites[2], attackDMG = 1, health = 1, spawnNumbers = new int[]{ 1337 } },
            new Opponent {name = "Macca's", sprite = EnemySprites[3], attackDMG = Bomb.GetSerialNumberNumbers().Sum()*100%15, health = Bomb.GetSerialNumberLetters().Sum(ltr => ltr - 'A' + 1), spawnNumbers = new int[] { 5 } },
            new Opponent {name = "Zombye", sprite = EnemySprites[4], attackDMG = 100, health = 90, spawnNumbers = new int[] { 6, 7 } },
            new Opponent {name = "yes", sprite = EnemySprites[5], attackDMG = 10, health = 30, spawnNumbers = new int[] { 9 } },
            new Opponent {name = "default", sprite = EnemySprites[6], attackDMG = 20, health = 80, spawnNumbers = new int[] { 10, 11 }}
        };

        generateNewOk();

        _emotes = new Emote[]
        {
            new Emote {sprite = EmoteSprites[0], ok = "armwiggle", weaponCondition = theWeapon.reloadTime < 2.2, opponentCondition = true },
            new Emote {sprite = EmoteSprites[1], ok = "Brakedanze", weaponCondition = theWeapon.attackDMG > 60, opponentCondition = theEnemy.health > 80},
            new Emote {sprite = EmoteSprites[2], ok = "Math", weaponCondition = theEnemy.name == "Ucinorn", opponentCondition = true},
            new Emote {sprite = EmoteSprites[3], ok = "Dab", weaponCondition = theWeapon.rarity.Equals("l"), opponentCondition = theEnemy.health < theWeapon.attackDMG},
            new Emote {sprite = EmoteSprites[4], ok = "Jaxfilms", weaponCondition = theWeapon.name == "AR-15", opponentCondition = true},
            new Emote {sprite = EmoteSprites[5], ok = "Avikeyy", weaponCondition = theWeapon.rarity.Equals("r"), opponentCondition = theEnemy.attackDMG > 40},
            new Emote {sprite = EmoteSprites[6], ok = "serbia stronk", weaponCondition = theWeapon.rarity.Equals("com"), opponentCondition = theEnemy.attackDMG > 80}
        };

        _AttackStrategies = new Okay[]
        {
            new Okay {publicName = "Shoot and Heal", condition = theEnemy.health < theWeapon.attackDMG},
            new Okay {publicName = "Kamikaze", condition = (theEnemy.health*0.75 < theWeapon.attackDMG) && !(theEnemy.health < theWeapon.attackDMG)},
            new Okay {publicName = "Jump and Shoot", condition = (theEnemy.health*0.5 < theWeapon.attackDMG) && !(theEnemy.health*0.75 < theWeapon.attackDMG)},
            new Okay {publicName = "Dab on'em", condition = (theEnemy.health*0.25 < theWeapon.attackDMG) && !(theEnemy.health*0.5 < theWeapon.attackDMG)},
            new Okay {publicName = "Hide", condition = (theEnemy.health*0.25 > theWeapon.attackDMG) && !(theEnemy.health*0.25 < theWeapon.attackDMG)}
        };
        Emoti = _emotes.ToList();
        locusses = _loci.ToList();

        StageTwoDisplayInt = Rnd.Range(0, 3);

        mapSprite.gameObject.SetActive(false);
        presstopaybutton.gameObject.SetActive(true);
        Fortnightlogo.gameObject.SetActive(true);
        Weapon.gameObject.SetActive(false);
        Opponent.gameObject.SetActive(false);

        int startingNumber = Convert.ToInt32(Bomb.GetIndicators().Count() + Bomb.GetModuleNames().Count * 3.14159 + Bomb.GetIndicators().Sum(ind => ind.Sum(l => l - 'A' + 1)));
        if (Bomb.GetSerialNumberLetters().Any(x => new[] { 'A', 'E', 'I', 'O', 'U' }.Contains(x)))
            startingNumber = (startingNumber * 3)%20+1;
        else
            startingNumber = (startingNumber * 2)%20+1;
        int currentNumber = startingNumber;
        LogMessage("Location calculation: Starting off at {0}", _loci[startingNumber].visibleName);
        foreach (Locus locus in _loci)
        {
            if (startingNumber % 2 == 1 && currentNumber % 2 == 0)
            {
            } else if (startingNumber % 2 != 1 && new int[] { 1, 5, 9}.EqualsAny(currentNumber))
            {
            } else if (_loci[currentNumber].condition) {
                correctLocus = _loci[currentNumber];
                Debug.Log(_loci[currentNumber].visibleName);
                break;
            }
            currentNumber++;
        }
        LogMessage("Location caltulation: The correct location is {0}", correctLocus.visibleName);
	}

    void LogMessage(string message, params object[] parameters)
    {
        Debug.LogFormat("[The Fortnight #{0}] {1}", _moduleId, string.Format(message, parameters));
    }

    void HandleStageOne()
    {
        LogMessage("Press to Pay button pressed, advancing to stage one.");
        StageOneDisplayInt = Rnd.Range(0, 20);
        Stage1AlightPosition.text = _loci[StageOneDisplayInt].visibleName;
        presstopaybutton.gameObject.SetActive(false);
        Fortnightlogo.gameObject.SetActive(false);
        mapSprite.gameObject.SetActive(true);
        foreach (KMSelectable ok in mapbuttons)
            ok.gameObject.SetActive(true);
        if (mapbuttons[0].OnInteract == null)
            for (int i = 0; i < mapbuttons.Length; i++)
                mapbuttons[i].OnInteract += GetMapButtonPressHandler(i);
    }

    void HandleStageTwo()
    {
        LogMessage("Watch out! There's {0} about to attack you!", theEnemy.name);
        LogMessage("Your weapon is {0}", theWeapon.name);
        if (fitebuttons[0].OnInteract == null)
            for (int i = 0; i < fitebuttons.Length; i++)
                fitebuttons[i].OnInteract += GetFiteButtonPressHandler(i);
        mapSprite.gameObject.SetActive(false);
        foreach (KMSelectable ok in mapbuttons)
            ok.gameObject.SetActive(false);
        foreach (KMSelectable ok in fitebuttons)
            ok.gameObject.SetActive(true);
        Weapon.gameObject.SetActive(true);
        Opponent.gameObject.SetActive(true);
        Weapon.sprite = theWeapon.sprite;
        Opponent.sprite = theEnemy.sprite;
        Stage2AttacStrategy.text = _AttackStrategies[StageTwoDisplayInt].publicName;
    }

    void HandleStageThree()
    {
        var TheEmote = new Emote();
        foreach (Emote ok in _emotes)
        {
            if (ok.opponentCondition && ok.weaponCondition)
            {
                TheEmote = ok;
                break;
            }
        }
        LogMessage("The first emote with both conditions applying is {0}", TheEmote.ok);
        foreach (KMSelectable ok in fitebuttons)
            ok.gameObject.SetActive(false);
        Weapon.gameObject.SetActive(false);
        Opponent.gameObject.SetActive(false);
        foreach (KMSelectable yes in emotebuttons)
            yes.gameObject.SetActive(true);
        Emote.gameObject.SetActive(true);
        if (emotebuttons[0].OnInteract == null)
            for(int i = 0; i < 3; i++)
            {
                emotebuttons[i].OnInteract = StopItGetSomeHelp(i);
            }
        StageThreeDisplayInt = Rnd.Range(0, 6);
        Emote.sprite = _emotes[StageThreeDisplayInt].sprite;
    }

    void HandleEpiccestVictoryRoyale()
    {
        foreach (KMSelectable yes in emotebuttons)
            yes.gameObject.SetActive(false);
        Emote.gameObject.SetActive(false);
        VictoryRoyale.gameObject.SetActive(true);
        Audio.PlaySoundAtTransform("VictoryEffect", transform);
        Module.HandlePass();
    }

    private KMSelectable.OnInteractHandler GetFiteButtonPressHandler(int btn)
    {
        return delegate
        {
            Audio.PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress, fitebuttons[btn].transform);
            switch (btn) {
                case 0:
                    StageTwoDisplayInt = StageTwoDisplayInt - 1;
                    if (StageTwoDisplayInt < 0)
                        StageTwoDisplayInt = StageTwoDisplayInt + 5;
                break;
                case 1:
                    StageTwoDisplayInt = (StageTwoDisplayInt + 1) % 5;
                    break;
                case 2:
                    if (_AttackStrategies[StageTwoDisplayInt].publicName != "Hide")
                    {
                        if (_AttackStrategies[StageTwoDisplayInt].condition)
                        {
                            LogMessage("Correct strategy selected, advancing to stage three");
                            HandleStageThree();
                        }
                        else
                        {
                            Module.HandleStrike();
                            Audio.PlaySoundAtTransform("StrikeEffect", transform);
                            Starter();
                        }
                    }
                    else
                    {

                        if (_AttackStrategies[StageTwoDisplayInt].condition) {
                            LogMessage("You hid from the enemy, assigning new enemy.");
                            generateNewOk();
                            HandleStageTwo();
                            }
                            else
                            {
                            LogMessage("Wrong strategy selected, you were ko'd, Strike given, returning to stage 0");
                                Module.HandleStrike();
                            Audio.PlaySoundAtTransform("StrikeEffect", transform);
                                Starter();
                            }
                        }
                    break;
                default:
                    break;
            };
                    Stage2AttacStrategy.text = _AttackStrategies[StageTwoDisplayInt].publicName;
                return false;
        };
    }

    private KMSelectable.OnInteractHandler GetMapButtonPressHandler(int btn)
    {
        return delegate
        {
            Audio.PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress, mapbuttons[btn].transform);
            switch (btn) {
                case 0:
                StageOneDisplayInt = (StageOneDisplayInt - 1) % 20;
                break;
                case 1:
                StageOneDisplayInt = (StageOneDisplayInt + 1) % 20;
                break;
                case 2:
                if (correctLocus == _loci[StageOneDisplayInt])
                    {
                    LogMessage("Correct alighting position selected, advancing to stage two");
                    HandleStageTwo();
                    }
                    else
                {
                    LogMessage("Wrong alighting position selected, Strike given, returning to stage 0");
                    Module.HandleStrike();
                        Audio.PlaySoundAtTransform("StrikeEffect", transform);
                    Starter();
                }
                break;
        }
            Stage1AlightPosition.text = _loci[StageOneDisplayInt].visibleName;
            return false;
        };
    }

    private KMSelectable.OnInteractHandler StopItGetSomeHelp (int btn)
    {
        return delegate
        {
            Audio.PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress, emotebuttons[btn].transform);
            switch (btn)
            {
                case 0:
                    StageThreeDisplayInt = StageThreeDisplayInt - 1;
                    if (StageThreeDisplayInt < 0)
                        StageThreeDisplayInt = StageThreeDisplayInt + 7;
                    break;
                case 1:
                    StageThreeDisplayInt = (StageThreeDisplayInt + 1) % 7;
                    break;
                case 2:
                    if (_emotes[StageThreeDisplayInt].opponentCondition && _emotes[StageThreeDisplayInt].weaponCondition)
                    {
                        LogMessage("Correct emote selected, you got the EPIC VICTORY ROYALE!!!!!!");
                        HandleEpiccestVictoryRoyale();
                    }
                    else
                    {
                        LogMessage("Wrong emote selected, your friends laughed at you, Strike given, returning to stage 0");
                        Module.HandleStrike();
                        Audio.PlaySoundAtTransform("StrikeEffect", transform);
                        Starter();
                    }
                    break;
            }
            Emote.sprite = _emotes[StageThreeDisplayInt].sprite;
            return false;
        };
    }

    // Update is called once per frame
    void Update () {
		
	}
}
