using UnityEngine;
using UnityEngine.UI;

public class ButtonsRotation : MonoBehaviour
{
    public Button[] buttons; 
    public float rotationSpeed = 1f; 
    [SerializeField] private float rotationAngle = 1f; 
    private float[] currentAngles; 
    private bool[] rotatingPositive;

    void Start()
    {
        currentAngles = new float[buttons.Length];
        rotatingPositive = new bool[buttons.Length];

        for (int i = 0; i < rotatingPositive.Length; i++)
        {
            rotatingPositive[i] = (i % 2 == 0);
        }
    }

    void Update()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            if (rotatingPositive[i])
            {
                currentAngles[i] += rotationSpeed * Time.deltaTime;
                if (currentAngles[i] >= rotationAngle)
                {
                    currentAngles[i] = rotationAngle;
                    rotatingPositive[i] = false;
                }
            }
            else
            {
                currentAngles[i] -= rotationSpeed * Time.deltaTime;
                if (currentAngles[i] <= -rotationAngle)
                {
                    currentAngles[i] = -rotationAngle;
                    rotatingPositive[i] = true;
                }
            }

            buttons[i].transform.localRotation = Quaternion.Euler(0f, 0f, currentAngles[i]);
        }
    }
}// tiempo asintotico 0(n)