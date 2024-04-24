using UnityEngine;
using UnityEngine.UI;

public class StatusController : MonoBehaviour
{
    [SerializeField]
    private int hp;
    private int currentHp;
    [SerializeField]
    private int sp;
    private int currentSp;

    [SerializeField]
    private int spIncreaseSpeed;

    [SerializeField]
    private int spRechargeTime;
    private int currentSpRechargeTime;

    private bool spUsed;

    [SerializeField]
    private Image[] images_Gauge;

    private const int HP = 0, SP = 1;

    // Start is called before the first frame update
    void Start()
    {
        currentHp = hp;
        currentSp = sp;
    }

    // Update is called once per frame
    void Update()
    {
        GaugeUpdate();
        SPRechargeTime();
        SPRecover();
        
    }

    private void SPRechargeTime(){
        if(spUsed){
            if(currentSpRechargeTime < spRechargeTime){
                currentSpRechargeTime++;
            }
            else
            spUsed = false;
        }
    }
    private void SPRecover(){
        if(!spUsed && currentSp < sp){
            currentSp += spIncreaseSpeed;
        }
    }

    private void GaugeUpdate(){
        images_Gauge[HP].fillAmount = (float) currentHp / hp;
        images_Gauge[SP].fillAmount = (float) currentSp / sp;
    }
    public void DecreaseStamina(int _count){
        spUsed = true;
        currentSpRechargeTime = 0;

        if(currentSp - _count >0){
            currentSp -= _count;
        }
        else
            currentSp = 0;
    }
    public int getCurrentSP(){
        return currentSp;
    }


    public void ReduceHPByPercentage(float percentage)
    {
        int damage = (int)(hp * percentage);
        currentHp -= damage;
        if (currentHp < 0) currentHp = 0;

        
    }


    public bool IsPlayerDead()
    {
        return currentHp <= 0;
    }
}