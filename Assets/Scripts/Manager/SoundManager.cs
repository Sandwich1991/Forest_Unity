using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager
{
    /**********************************************************************/
    // Fields
    // 오디오 소스를 저장할 배열
    private AudioSource[] _audioSources = new AudioSource[(int)Define.Sound.MaxCount];

    // 오디오 클립을 저장할 딕셔너리 (oneshot으로 플레이할 클립을 캐싱)
    private Dictionary<string, AudioClip> _audioClips = new Dictionary<string, AudioClip>();

    /**********************************************************************/
    // Methods
    public void init()
    {
        GameObject root = GameObject.Find("@Sound");
        if (root == null)
        {
            // DontDestroyOnLoad의 @Sound 오브젝트를 만든다
            root = new GameObject { name = "@Sound" };
            Object.DontDestroyOnLoad(root);
            
            // Define.Sound의 enum을 가져옴
            string[] soundNames = System.Enum.GetNames(typeof(Define.Sound));
            
            for (int i = 0; i < soundNames.Length - 1; i++)
            {
                // @Sound안에 sound의 종류별로 AudioSource 컴포넌트를 가진 오브젝트를 만든다
                GameObject go = new GameObject { name = soundNames[i] };
                _audioSources[i] = go.AddComponent<AudioSource>();
                go.transform.parent = root.transform;
            }
        }
    }
    
    // 오디오 클립을 불러오는 메소드
    AudioClip GetOrAddAudioClip(string path, Define.Sound type = Define.Sound.Effect)
    {
        // 오디오파일 경로명에 Sounds가 빠져있으면 포함시킨다.
        if (path.Contains("Sounds") == false)
            path = $"Sounds/{path}";

        AudioClip audioClip = null;
        
        /* 오디오 클립이 Bgm이라면 바로 리소스 매니져를 통해 로드하고
         Effect라면 매번 로드하기에 부하가 크기 때문에
         _audioClips 딕셔너리에 캐싱해두고 로드한다 */
        if (type == Define.Sound.Bgm)
        {
            audioClip = Managers.Resource.Load<AudioClip>(path);
        }
        else
        {
            // 딕셔너리에서 해당 클립을 찾아보고 없으면 리소스매니져로 로드
            if (_audioClips.TryGetValue(path, out audioClip) == false)
            {
                audioClip = Managers.Resource.Load<AudioClip>(path);
                _audioClips.Add(path, audioClip);
            }
        }
        if (audioClip == null)
            Debug.Log($"AudioClip Missing! {path}");

        return audioClip;
    }
    
    // 오디오를 재생하는 메소드
    public void Play(string path, Define.Sound type = Define.Sound.Effect, float pitch = 1f)
    {
        AudioClip audioClip = GetOrAddAudioClip(path, type);

        if (audioClip == null)
            return;
        
        /* 오디오 클립이 Bgm이라면 Play() 메소드로 재생하고
         Effect라면 PlayOneShot() 메소드로 재생한다 */
        if (type == Define.Sound.Bgm)
        {
            AudioSource audioSource = _audioSources[(int)Define.Sound.Bgm];
            
            // Bgm이 재생중이면 정지한다
            if (audioSource.isPlaying) 
                audioSource.Stop();

            audioSource.pitch = pitch;
            audioSource.clip = audioClip;
            audioSource.loop = true;
            audioSource.Play();
        }
        else // 오디오 클립이 Effect라면,
        {
            AudioSource audioSource = _audioSources[(int)Define.Sound.Effect];
            audioSource.pitch = pitch;
            audioSource.PlayOneShot(audioClip);
        }
    }
    
    // 리소스 부하를 방지하기위한 Clear 메소드
    public void Clear()
    {
        foreach (AudioSource audioSource in _audioSources)
        {
            audioSource.clip = null;
            audioSource.Stop();
        }
        _audioClips.Clear();
    }

    // 모든 오디오 소스를 뮤트하는 메소드
    public void Mute()
    {
        foreach (AudioSource audioSource in _audioSources)
        {
            audioSource.mute = true;
        }
    }
    
    // 모든 오디오 소스의 뮤트를 해제
    public void UnMute()
    {
        foreach (AudioSource audioSource in _audioSources)
        {
            if (audioSource.mute == true)
                audioSource.mute = false;
        }
    }
    
    
}
