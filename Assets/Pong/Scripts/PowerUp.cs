using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public PowerUp powerUp;
    public Ball ball;
    public WaitForSeconds wait;
    public int counter = 0;
    //-----------------------------------------------------------------------------
    private void OnTriggerEnter(Collider other)
    {
        if(counter == 0)
        {
            int randomDecider = Random.Range(1, 4);
            //do something interesting to the ball, paddle, or some other game element
            Debug.Log($"{other.name} passed through my collider - {this.name}");
            powerUp.GetComponent<MeshRenderer>().enabled = false;

            if(randomDecider == 1)
            {
               Debug.Log($"Invisible was chosen");
               ball.GetComponent<MeshRenderer>().enabled = false;
            }

            if(randomDecider == 2)
            {
               Debug.Log($"OmegaSpeed Speed was Chosen");
               ball.OMEGASpeed();
            }

            if(randomDecider == 3){
                Debug.Log($"Shrink was chosen");
                ball.shrink();
            }

            counter++;

        } else
        {
            Debug.Log($"Nothing");
        }
        


    }

    public void ResetPowerUp()
    {
        counter = 0;
        powerUp.GetComponent<MeshRenderer>().enabled = true;
        ball.GetComponent<MeshRenderer>().enabled = true;
    }

}
