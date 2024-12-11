using UnityEngine;

public class SoundManager : MonoBehaviour
{
   public static SoundManager Instance;

   [SerializeField] private AudioSource _musicSource;
   [SerializeField] private AudioSource _sfxSource;
   [SerializeField] private AudioSource _powerUpSfxSource;
   
   [SerializeField] private AudioClip _backgroundMusic;
   
   [SerializeField] private AudioClip _eatSfx;
   [SerializeField] private AudioClip _dashSfx;
   [SerializeField] private AudioClip _dieSfx;
   [SerializeField] private AudioClip _powerUpSfx;
   
   private void Awake()
   {
      if (Instance == null)
         Instance = this;
      else
         Destroy(this.gameObject);
   }

   private void Start()
   {
      PlayBackgroundMusic();
   }

   private void PlayBackgroundMusic()
   {
      _musicSource.loop = true;
      _musicSource.clip = _backgroundMusic;
      _musicSource.Play();
   }

   public void PlayPowerUpSound()
   {
      _powerUpSfxSource.Stop();
      _powerUpSfxSource.clip = _powerUpSfx;
      _powerUpSfxSource.loop = true;
      _powerUpSfxSource.Play();
   }
   
   public void StopPowerUpSound()
   {
      _powerUpSfxSource.Stop();
      _powerUpSfxSource.loop = false;
      _powerUpSfxSource.clip = null;
   }
   
   public void PlayEatSfx()
   {
      _sfxSource.Stop();
      _sfxSource.clip = _eatSfx;
      _sfxSource.Play();
   } 
   
   public void PlayDashSfx()
   {
      _sfxSource.Stop();
      _sfxSource.clip = _dashSfx;
      _sfxSource.Play();
   }  
   
   public void PlayDieSfx()
   {
      _sfxSource.Stop();
      _sfxSource.clip = _dieSfx;
      _sfxSource.Play();
   }
}