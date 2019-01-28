using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(VoiceController))]
public class VoiceTest : MonoBehaviour {

    public Image progressBar;
    public SimplePixelizer imgCamera;
    //private SimplePixelizer simplePixelizer;
    int error, acertos;

    public Text uiText;
    VoiceController voiceController;
    public GameObject mic;

    //public float pixelizer;
    // Start is called before the first frame update

    /*void Awake()
    {
        simplePixelizer = ImgCamera.GetComponent<SimplePixelizer>();

    }*/
    public string[] img1;
    //public List<string> img2;
    //public string[] img2 = {""}; = {""};
    // public string[] img2 = new string[] {""};
    bool VerifyArray(string[] list, string toCompare)
    {
        //int i = 0;
        foreach (string compare in list)
        {
            //i++;
            if (compare.Equals(toCompare))
            {
                //img1.SetValue("", i);
                return true;
            }
        }
        return false;
    }

   /* bool VerifyList(List<string> list, string toCompare)
    {
        //int i = 0;
        foreach (string compare in list)
        {
            //i++;
            if (compare.Equals(toCompare))
            {
                //img1.SetValue("", i);
                return true;
            }
        }
        return false;
    }*/

    public void GetSpeech() {
        mic.SetActive(true);
        voiceController.GetSpeech();
    }

    void Start() {
        img1 = new string[] {"campo", "paisagem", "paisagens", "rural", "campinho", "várzea", "fazenda", "sítio", "chácara",
            "nuvem", "nuvens", "roça", "plantação", "casa", "casebre", "casinha", "chaminé", "férias", "balanço", "balança",
            "árvore", "árvores", "arbusto", "arbustos", "cadeira de balanço", "noite", "anoitecer", "grama",
            "agricultura", "luzes", "banco", "banquinho", "lua", "vila", "vilarejo", "camponês", "campesino",
            "campensina", "chalé", "brincadeira", "gleba", "terreno", "lavoura", "colheita", "vaca", "gramado",
            "grama" };
        //img2 = new List<string>();
        progressBar.fillAmount = 0.0f;
        voiceController = GetComponent<VoiceController>();
    }

    void OnEnable()
    {
        // VoiceController.resultRecieved += OnVoiceResult;
    }

    void OnDisable()
    {
        VoiceController.resultRecieved -= OnVoiceResult;
    }

    void OnVoiceResult(string text) {
        mic.SetActive(false);
        text = text.Split(' ')[0];
        if (!uiText.text.Equals(text))
        {
            uiText.text = text;
            verifyGameLogic(text);
        }
        uiText.text = text;
        //verifyGameLogic(text);
        //img2.Add(text);
    }

    void verifyGameLogic(string text)
    {
        if (!VerifyArray(img1, text.ToLower()) && !text.Equals(""))
        {
            error++;
            if (error == 4)
            {
                SceneManager.LoadScene("wasted");
            }

            progressBar.fillAmount += 0.25f;
        }
        else
        {
                acertos++;
                //progressBar.fillAmount += 0.25f;
                //ImgCamera.pixelize -= 5;
                //pixelizer = GetComponent<SimplePixelizer>();
                if (acertos == 4)
                {
                    SceneManager.LoadScene("to_wast" +
                        "");
                }
                imgCamera.pixelize -= 5;
                //Debug.Log(imgCamera.pixelize);         
        }
    }
}
