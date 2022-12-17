using UnityEngine;

/// <summary>
/// Um den SoundManager zu benutzen, kann man mit AuidoSystem.PlaySound(clipname:string) aufrufen. 
/// Clipname muss dabei dem Namen der Audiodatei entsprechen, die zuvor unter Resources/Sounds" abgespeichert wurde.
/// </summary>
public class AudioSystem : StaticInstance<AudioSystem> {

    [SerializeField] private AudioSource _musicSource;
    [SerializeField] private AudioSource _soundsSource;
    
    //Play Stuff
    public void PlayMusic(string clipName, bool loop = true) {
        AudioClip clip = ResourceSystem.Instance.GetMusic(clipName);
        _musicSource.clip = clip;
        _musicSource.loop = true;
        _musicSource.Play();
    }

    public void PlaySound(string clipName, Vector3 pos, float vol = 1, float pitch = 1)
    {
        _soundsSource.transform.position = pos;
        PlaySound(clipName, vol, pitch);
    }

    public void PlaySound(string clipName, float vol = 1, float pitch = 1)
    {
        AudioClip clip = ResourceSystem.Instance.GetSound(clipName);
        _soundsSource.pitch = pitch;
        _soundsSource.PlayOneShot(clip, vol);
    }


    //Change Volume
    public void ChangeMasterVolume(float value)
    {
        AudioListener.volume = value;
    }

    public void ChangeSoundVolume(float value)
    {
        _soundsSource.volume = value;
    }
    
    public void ChangeMusicVolume(float value)
    {
        _musicSource.volume = value;
    }
}