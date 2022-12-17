using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// One repository for all scriptable objects. Create your query methods here to keep your business logic clean.
/// I make this a MonoBehaviour as sometimes I add some debug/development references in the editor.
/// If you don't feel free to make this a standard class
/// </summary>
public class ResourceSystem : StaticInstance<ResourceSystem> {

    //This was my Way of Managing scriptable objects in an old game
    //public List<LauncherScriptable> launchers { get; private set; }
    //private Dictionary<LauncherType, LauncherScriptable> _LauncherDict;
    //public List<RocketScriptable> rockets { get; private set; }
    //private Dictionary<RocketType, RocketScriptable> _RocketDict;

    //Audio
    private Dictionary<string, AudioClip> sounds_Dict;
    private Dictionary<string, AudioClip> music_Dict;

    protected override void Awake()
    {
        base.Awake();
        AssembleResources();
    }

    private void AssembleResources()
    {
        //Audio
        sounds_Dict = Resources.LoadAll<AudioClip>("Audio/Sounds").ToDictionary(x => x.name, y => y);
        music_Dict = Resources.LoadAll<AudioClip>("Audio/Music").ToDictionary(x => x.name, y => y);

        //This was my Way of Managing scriptable objects in an old game
        //launchers = Resources.LoadAll<LauncherScriptable>("Launcher").ToList();
        //_LauncherDict = launchers.ToDictionary(r => r.launcherType, r => r);
        //rockets = Resources.LoadAll<RocketScriptable>("Rockets").ToList();
        //_RocketDict = rockets.ToDictionary(r => r.rocketType, r => r);
    }
    
    //Audio
    public AudioClip GetSound(string clipName) => sounds_Dict[clipName];
    public AudioClip GetMusic(string clipName) => music_Dict[clipName];

    //This was my Way of Managing scriptable objects in an old game
    //public LauncherScriptable GetLauncher(LauncherType t) => _LauncherDict[t];
    //public LauncherScriptable GetRandomLauncher() => launchers[Random.Range(0, launchers.Count)];    
    //public RocketScriptable GetRocket(RocketType t) => _RocketDict[t];
    //public RocketScriptable GetRandomRocket() => rockets[Random.Range(0, rockets.Count)];
}   