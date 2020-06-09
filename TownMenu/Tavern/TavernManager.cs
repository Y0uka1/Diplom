using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TavernManager : ScriptableObject, IManager
{
    public TavernList charList;

    int maxBar;
    int maxCasino;
    int maxBordel;
    int maxRoom;
    int curBar;
    int curCasino;
    int curBordel;
    int curRoom;

    int tavernLevel;

    public List<ICharacterStats> bar;
    public List<ICharacterStats> casino;
    public List<ICharacterStats> bordel;
    public List<ICharacterStats> room;

   

   public RelaxType curType = RelaxType.NULL;

    SwitchToBar toBar;
    SwitchToCasino toCasino;
    SwitchToBordel toBordel;
    SwitchToRoom toRoom;

    public ManagerStatus status { get; set; } = ManagerStatus.Offline;

   // public List<ICharacterStats> charList;

    public void Initialize()
    {
        if (status == ManagerStatus.Offline)
        {
            tavernLevel = 0;
            maxBar = 1;
            maxCasino = 1;
            maxBordel = 1;
            maxRoom = 1;
            curBar = 0;
            curBordel = 0;
            curCasino = 0;
            curRoom = 0;

            bar = new List<ICharacterStats>(maxBar);
            casino = new List<ICharacterStats>(maxCasino);
            bordel = new List<ICharacterStats>(maxBordel);
            room = new List<ICharacterStats>(maxRoom);
            MainManager.busyChars = new List<ICharacterStats>();

            charList = GameObject.FindObjectOfType<TavernList>();
            charList.GetList();

            toBar = GameObject.FindObjectOfType<SwitchToBar>();
            toCasino = GameObject.FindObjectOfType<SwitchToCasino>();
            toBordel = GameObject.FindObjectOfType<SwitchToBordel>();
            toRoom = GameObject.FindObjectOfType<SwitchToRoom>();
            toBar.Initialize();
            toCasino.Initialize();
            toBordel.Initialize();
            toRoom.Initialize();
            status = ManagerStatus.Online;
        }
    }

    public bool BarAdd(ICharacterStats chara)
    {
        if (curBar < maxBar)
        {
            bar.Add(chara);
            curBar++;
            return true;
        }
        return false;
    }

    public bool CasinoAdd(ICharacterStats chara)
    {
        if (curCasino < maxCasino)
        {
            casino.Add(chara);
            curCasino++;
            return true;
        }
        return false;
    }

    public bool BordelAdd(ICharacterStats chara)
    {
        if (curBordel < maxBordel)
        {
            bordel.Add(chara);
            curBordel++;
            return true;
        }
        return false;
    }

    public bool RoomAdd(ICharacterStats chara)
    {
        if (curRoom < maxRoom)
        {
            room.Add(chara);
            curRoom++;
            return true;
        }
        return false;
    }

    public void Relax()
    {
        foreach(var i in bar)
        {
            i.LooseMorale(-(25 + (tavernLevel * 10)));
        }

        foreach (var i in casino)
        {
            i.LooseMorale(-(50 + (tavernLevel * 10)));
        }

        foreach (var i in bordel)
        {
            i.LooseMorale(-(75 + (tavernLevel * 10)));
        }

        foreach (var i in room)
        {
            i.LooseMorale(-(100 + (tavernLevel * 10)));
        }
    }

    public bool AddToList(ICharacterStats chara)
    {
        bool result;
        switch (curType)
        {
            case RelaxType.Bar:
                {
                    result=BarAdd(chara);
                    
                    break;
                }
            case RelaxType.Casino:
                {
                    result = CasinoAdd(chara);
                    
                    break;
                }
            case RelaxType.Bordel:
                {
                    result = BordelAdd(chara);
                   
                    break;
                }
            case RelaxType.Room:
                {
                    result = RoomAdd(chara);

                    break;
                }
            default:
                result = false;
                break;
        }

        if(result==true)
            MainManager.busyChars.Add(chara);

        return result;
    }

    public void RemoveFromList(ICharacterStats chara)
    {
        switch (curType)
        {
            case RelaxType.Bar:
                {
                    bar.Remove(chara);
                   curBar--;
                    break;
                }
            case RelaxType.Casino:
                {
                    casino.Remove(chara);
                    curCasino--;
                    break;
                }
            case RelaxType.Bordel:
                {
                    bordel.Remove(chara);
                    curBordel--;
                    break;
                }
            case RelaxType.Room:
                {
                    room.Remove(chara);
                    curRoom--;
                    break;
                }
        }


       
      
        MainManager.busyChars.Remove(chara);
    }




}
