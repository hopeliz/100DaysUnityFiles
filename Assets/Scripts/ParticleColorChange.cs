using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleColorChange : MonoBehaviour
{
    public ParticleSystem particles;
    public Gradient grad;
    public GradientColorKey[] redColor;
    public GradientColorKey[] yellowColor;
    public GradientColorKey[] greenColor;
    public GradientColorKey[] blueColor;
    public GradientAlphaKey[] alpha;

    public Color firstColor;
    public Color secondColor;

    // Start is called before the first frame update
    void Start()
    {
        grad = new Gradient();

        redColor = new GradientColorKey[3];
        redColor[0].color = new Color(0.745283F, 0, 0.08627847F);
        redColor[1].color = new Color(1, 0.4232884F, 0.02745098F);
        redColor[2].color = Color.white;

        yellowColor = new GradientColorKey[3];
        yellowColor[0].color = new Color(1, 0.9451673F, 0);
        yellowColor[1].color = new Color(0.7830189F, 0.6852621F, 0.3508811F);
        yellowColor[2].color = Color.white;

        greenColor = new GradientColorKey[3];
        greenColor[0].color = new Color(0.09140146F, 0.3962264F, 0.07289071F);
        greenColor[1].color = new Color(0, 1, 0.2272727F);
        greenColor[2].color = Color.white;

        blueColor = new GradientColorKey[3];
        blueColor[0].color = new Color(0.06643878F, 0, 0.6226415F);
        blueColor[1].color = new Color(0.3895959F, 0.5435687F, 0.9716981F);
        blueColor[2].color = Color.white;

        alpha = new GradientAlphaKey[3];
        alpha[0].alpha = 1.0F;
        alpha[1].alpha = 1.0F;
        alpha[2].alpha = 1.0F;

        firstColor = redColor[0].color;
        secondColor = redColor[1].color;
    }

    // Update is called once per frame
    void Update()
    {
        particles.startColor = Color.Lerp(firstColor, secondColor, particles.time / particles.duration);

        if (Input.GetKeyDown(KeyCode.R))
        {
            //grad.SetKeys(redColor, alpha);

            //grad.SetKeys(new GradientColorKey[] { new GradientColorKey(new Color(0.745283F, 0, 0.08627847F), 0.0F), new GradientColorKey(new Color(1, 0.4232884F, 0.02745098F), 0.5F), new GradientColorKey(Color.white, 1.0F) }, new GradientAlphaKey[] { new GradientAlphaKey(1.0F, 0.0F), new GradientAlphaKey(1.0F, 1.0F) } );
            firstColor = redColor[0].color;
            secondColor = redColor[1].color;
            print("blah");
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            firstColor = yellowColor[0].color;
            secondColor = yellowColor[1].color;
            print("blah");
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            firstColor = greenColor[0].color;
            secondColor = greenColor[1].color;
            print("blah");
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            firstColor = blueColor[0].color;
            secondColor = blueColor[1].color;
            print("blah");
        }

    }
}
