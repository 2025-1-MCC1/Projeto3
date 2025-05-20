using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bola : MonoBehaviour
{
    public float velocidade = 10;       //tem que ser no public pois consegue alterar dps no proprio unity
    int pontosJog1 = 0;
    int pontosJog2 = 0;
    public TMP_Text TextoPontosJog2;
    public TMP_Text TextoPontosJog1;
    void Start()
    {
        //Debug.Log("Jogador 1:" + pontosJog1 + " x " + pontosJog2 + " : Jogador 2");
        TextoPontosJog2.SetText(pontosJog2.ToString());
        TextoPontosJog1.SetText(pontosJog1.ToString());
        if ((pontosJog2 >= 3))
        {
            SceneManager.LoadScene("GameOver");
        }
        else if ((pontosJog1 >= 3))
        {
            SceneManager.LoadScene("GameOver2");
        }
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(0, 2) == 0 ? -1 : 1;
        GetComponent<Rigidbody>().linearVelocity = new Vector2(velocidade * x, velocidade * y);
    }

    void Update()
    {

    }
    private void OnCollisionEnter(Collision batida)
    {
        if (batida.gameObject.name == "bdireita")
        {
            transform.position = new Vector3(-0.5f, 9.1f, 15.93f);
            pontosJog2++;
            Start();
        }
        else if (batida.gameObject.name == "besquerda")
        {
            transform.position = new Vector3(-0.5f, 9.1f, 15.93f);
            pontosJog1++;
            Start();
        }
    }
}
