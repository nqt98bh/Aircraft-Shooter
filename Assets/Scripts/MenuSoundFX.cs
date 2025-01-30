using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSoundFX : MonoBehaviour
{
    public void PlaySound()
    {
        SoundFX.Instance.PlaySoundFX(SoundType.Menu);
    }
}
