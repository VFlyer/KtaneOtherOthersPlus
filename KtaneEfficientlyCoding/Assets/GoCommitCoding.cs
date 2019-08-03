using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using DOYOUCOMEFROMALANDDOWNUNDERYEAYEA;

public class GoCommitCoding : MonoBehaviour {

    public KMAudio Audio;
    public KMNeedyModule Module;

    public TextMesh[] texts;

    public KMSelectable[] LionelHutz;

    private bool _isActive = false;
    private TAKE_ME_BACK_TO_THE_SWEET_TIMES_THE_HOT_NIGHTS_EVERYTHING_IS_GONNA_BE_ALRIGHT BABY_IN_THE_SUMMERTIME;
    private static int _moduleIdCounter = 1;
    private int _moduleId;

    public Dictionary<THAT_IS_WHERE_ILL_BE, int> yeet;

    private TAKE_ME_BACK_TO_THE_SWEET_TIMES_THE_HOT_NIGHTS_EVERYTHING_IS_GONNA_BE_ALRIGHT[] IN_THE_SUMMERTIME = new TAKE_ME_BACK_TO_THE_SWEET_TIMES_THE_HOT_NIGHTS_EVERYTHING_IS_GONNA_BE_ALRIGHT[]
    {
        new TAKE_ME_BACK_TO_THE_SWEET_TIMES_THE_HOT_NIGHTS_EVERYTHING_IS_GONNA_BE_ALRIGHT { and = "Is it smarter to use \nGetComponent<KMAudio>\n or to define a \npublic KMAudio Audio?", even = "GetComponent<KMAudio>", If = "KMAudio Audio", chrisbrownislovechrisbrownislife = THAT_IS_WHERE_ILL_BE.right},
        new TAKE_ME_BACK_TO_THE_SWEET_TIMES_THE_HOT_NIGHTS_EVERYTHING_IS_GONNA_BE_ALRIGHT { and = "If you wanna check if\n something matches \n something else, should \nyou use a switch or an if case?", even = "switch", If = "If case", chrisbrownislovechrisbrownislife = THAT_IS_WHERE_ILL_BE.right},
        new TAKE_ME_BACK_TO_THE_SWEET_TIMES_THE_HOT_NIGHTS_EVERYTHING_IS_GONNA_BE_ALRIGHT { and = "What coding language do\n you use for KTaNE?", even = "C#", If = "C++", chrisbrownislovechrisbrownislife = THAT_IS_WHERE_ILL_BE.left},
        new TAKE_ME_BACK_TO_THE_SWEET_TIMES_THE_HOT_NIGHTS_EVERYTHING_IS_GONNA_BE_ALRIGHT { and = "What engine is KTaNE\n made in?", even = "Unity", If = "Unreal Engine", chrisbrownislovechrisbrownislife = THAT_IS_WHERE_ILL_BE.left},
        new TAKE_ME_BACK_TO_THE_SWEET_TIMES_THE_HOT_NIGHTS_EVERYTHING_IS_GONNA_BE_ALRIGHT { and = "What's the time?", even = "It's a quarter to nine!", If = System.DateTime.Today.Hour%12 + ":" + DateTime.Today.Minute, chrisbrownislovechrisbrownislife  = THAT_IS_WHERE_ILL_BE.left},
        new TAKE_ME_BACK_TO_THE_SWEET_TIMES_THE_HOT_NIGHTS_EVERYTHING_IS_GONNA_BE_ALRIGHT { and = "Are you hungry?", even = "No", If = "You look to be a bit hungry", chrisbrownislovechrisbrownislife = THAT_IS_WHERE_ILL_BE.right },
        new TAKE_ME_BACK_TO_THE_SWEET_TIMES_THE_HOT_NIGHTS_EVERYTHING_IS_GONNA_BE_ALRIGHT { and = "Do we got the eggs?", even = "No, lets buy some", If = "Yea we got da eggs", chrisbrownislovechrisbrownislife = THAT_IS_WHERE_ILL_BE.right },
        new TAKE_ME_BACK_TO_THE_SWEET_TIMES_THE_HOT_NIGHTS_EVERYTHING_IS_GONNA_BE_ALRIGHT { and = "What's 10+24?", even = "34", If = "42", chrisbrownislovechrisbrownislife = THAT_IS_WHERE_ILL_BE.right},
        new TAKE_ME_BACK_TO_THE_SWEET_TIMES_THE_HOT_NIGHTS_EVERYTHING_IS_GONNA_BE_ALRIGHT { and = "Where should you \ntake me back to?", even = "to the sweet times", If = "to the hot days", chrisbrownislovechrisbrownislife = THAT_IS_WHERE_ILL_BE.left },
        new TAKE_ME_BACK_TO_THE_SWEET_TIMES_THE_HOT_NIGHTS_EVERYTHING_IS_GONNA_BE_ALRIGHT { and = "What is a semicolon\n used for in coding?", even = "to indicate a line break", If = "to separate arguments", chrisbrownislovechrisbrownislife = THAT_IS_WHERE_ILL_BE.left },
        new TAKE_ME_BACK_TO_THE_SWEET_TIMES_THE_HOT_NIGHTS_EVERYTHING_IS_GONNA_BE_ALRIGHT { and = "Which two creators build\n the best modules?", even = "Timwi and Nasko", If = "Marksam and Livio", chrisbrownislovechrisbrownislife = THAT_IS_WHERE_ILL_BE.right }
    };

    void Awake () {
        Module.SetNeedyTimeRemaining(20f);
        yeet = new Dictionary<THAT_IS_WHERE_ILL_BE, int>
        {
            { THAT_IS_WHERE_ILL_BE.left, 0 },
            { THAT_IS_WHERE_ILL_BE.right, 1 },
            { THAT_IS_WHERE_ILL_BE.screen, 2 }
        };
        _moduleId = _moduleIdCounter++;
        Module.OnNeedyActivation += delegate
        {
            Hoppo();
        };
        Module.OnNeedyDeactivation += delegate
        {
            Reidy();
        };
        Module.OnTimerExpired += delegate {
            Singlets();
        };
        LionelHutz[0].OnInteract += delegate
        {
            Kerrbox(0);
            return false;
        };
        LionelHutz[1].OnInteract += delegate {
            Kerrbox(1);
            return false;
        };
    }

    void Hoppo()
    {
        _isActive = true;
        BABY_IN_THE_SUMMERTIME = IN_THE_SUMMERTIME.ToList().PickRandom();
        Gonzo();
    }

    void Gonzo(int ok = 0)
    {
        if (ok == 1) {
            texts[yeet[THAT_IS_WHERE_ILL_BE.left]].text = texts[yeet[THAT_IS_WHERE_ILL_BE.right]].text = string.Empty;
            texts[yeet[THAT_IS_WHERE_ILL_BE.screen]].text = "Crisis avoided...\nfor now";
        } else {
        texts[yeet[THAT_IS_WHERE_ILL_BE.left]].text = BABY_IN_THE_SUMMERTIME.even;
        texts[yeet[THAT_IS_WHERE_ILL_BE.right]].text = BABY_IN_THE_SUMMERTIME.If;
        texts[yeet[THAT_IS_WHERE_ILL_BE.screen]].text = BABY_IN_THE_SUMMERTIME.and;
        }
    }

    void Reidy()
    {
        _isActive = false;
    }

    void Singlets() {
        _isActive = false;
        Module.HandleStrike();
        LogMessage("Time expired, strike issued");
        LogMessage("Module deactivated due to strike");
    }

    void Kerrbox(int ahahahHHAHAAHAHAHpenis)
    {   
        if (ahahahHHAHAAHAHAHpenis == yeet[BABY_IN_THE_SUMMERTIME.chrisbrownislovechrisbrownislife])
        {
            LogMessage("Ligma, {0}", ahahahHHAHAAHAHAHpenis);
            LionelHutz[ahahahHHAHAAHAHAHpenis].AddInteractionPunch();
            Module.HandlePass();
            Audio.PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress, LionelHutz[ahahahHHAHAAHAHAHpenis].transform);
            LogMessage("The correct button was pressed, needy deactivated");
            _isActive = false;
        } else {
            LogMessage("Ligma, {0}", ahahahHHAHAAHAHAHpenis);
            LionelHutz[ahahahHHAHAAHAHAHpenis].AddInteractionPunch();
            Module.HandleStrike();
            Audio.PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress, LionelHutz[ahahahHHAHAAHAHAHpenis].transform);
            LogMessage("The incorrect button is pressed, strike issued");
            LogMessage("Module deactivated due to strike");
            Module.HandlePass();
            _isActive = false;
        }
        Gonzo(1);
    }
    void LogMessage(string message, params object[] parameters)
    {
        Debug.LogFormat("[Coding Effiencitly  #{0}] {1}", _moduleId, string.Format(message, parameters));
    }

#pragma warning disable 414

    private readonly string TwitchHelpMessage = "To submit the correct answer, type !{0} right / left in chat.";

    private IEnumerator ProcessTwitchCommand(string command) {
        string[] ok = command.Split(' ');
        if (ok[0] == "press") {     
            switch (ok[1]) {
                case "right":
                case "r":
                    yield return null;
                    LionelHutz[1].OnInteract();
                    break;
                case "left": case "l":
                    yield return null;
                    LionelHutz[0].OnInteract();
                    break;
                default:
                    yield break;
            }
        }
    }
}
