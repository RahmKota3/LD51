using UnityEngine;

public class SoundManager : MonoBehaviour
{
	public static SoundManager Instance;

	[SerializeField] AudioClip Attack;
	[SerializeField] AudioClip Death;
	[SerializeField] AudioClip MenuButton;
	[SerializeField] AudioClip Slash;
	[SerializeField] AudioClip Block;
	[SerializeField] AudioClip Time;

	[SerializeField] AudioSource audioSource;

	bool soundDisabled = false;

	public void PlaySound(SoundType sound)
    {
		if (soundDisabled)
			return;

        switch (sound)
        {
			case SoundType.Attack:
				audioSource.PlayOneShot(Attack);
				break;

			case SoundType.Death:
				audioSource.PlayOneShot(Death);
				break;

			case SoundType.MenuButton:
				audioSource.PlayOneShot(MenuButton);
				break;

			case SoundType.Slash:
				audioSource.PlayOneShot(Slash);
				break;

			case SoundType.Block:
				audioSource.PlayOneShot(Block);
				break;

			case SoundType.Time:
				audioSource.PlayOneShot(Time);
				break;
		}
    }
	
	void Awake()
	{
		Instance = this;
	}
}
