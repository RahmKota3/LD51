using UnityEngine;

public class SoundManager : MonoBehaviour
{
	public static SoundManager Instance;

	[SerializeField] AudioClip Attack;
	[SerializeField] AudioClip Death;
	[SerializeField] AudioClip MenuButton;

	[SerializeField] AudioSource audioSource;

	bool soundDisabled = false;

	public void PlaySound(SoundType sound)
    {
		if (soundDisabled)
			return;

        switch (sound)
        {
			case SoundType.Slash:
				audioSource.PlayOneShot(Attack);
				break;

			case SoundType.Death:
				audioSource.PlayOneShot(Death);
				break;

			case SoundType.MenuButton:
				audioSource.PlayOneShot(MenuButton);
				break;
		}
    }
	
	void Awake()
	{
		Instance = this;
	}
}
