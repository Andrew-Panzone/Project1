using UnityEngine;
using UnityEngine.UI;

public class GreenFilmEffect : MonoBehaviour
{
    public Image greenFilmImage;

    // Enable the green film effect
    public void EnableGreenFilm()
    {
        if (greenFilmImage != null)
        {
            greenFilmImage.enabled = true;
        }
    }

    // Disable the green film effect
    public void DisableGreenFilm()
    {
        if (greenFilmImage != null)
        {
            greenFilmImage.enabled = false;
        }
    }
}
