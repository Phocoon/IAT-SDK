using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Phocoon.IAT;
using UnityEngine;
using UnityEngine.UI;

public class DemoGame : MonoBehaviour
{

    public Slider wizard;
    public Slider worm;

    public Animator WizardAnimator;
    public Animator WormAnimator;

    public Animator HealAnimator;
    public Animator FireAnimator;
    public GameObject Rank;

    private float countDown = 1f;
    private float timer = 0f;

    private bool left = true;

    private bool isDone = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= countDown)
        {
            if (left)
            {
                WormAttack(true);
            }
            else
            {
                WizardAttack(true);
            }
            timer = 0;
        }
    }

    public void WizardAttack(bool auto = false)
    {
        if (isDone)
        {
            return;
        }
        WizardAnimator.SetTrigger("Attack");
        FireAnimator.gameObject.SetActive(true);
        FireAnimator.SetTrigger("Trigger");
        worm.value -= 0.1f;
        if (worm.value <= 0)
        {
            PhocoonIAT.Instance.SetUserScore(!auto, 100);
            Rank.gameObject.SetActive(true);
            Rank.GetComponentInChildren<DemoRank>().ShowRank();
            PhocoonIAT.Instance.EndSession();
        }
    }

    public void WormAttack(bool auto = false)
    {
        if (isDone)
        {
            return;
        }
        WormAnimator.SetTrigger("Attack");
        FireAnimator.gameObject.SetActive(true);
        FireAnimator.SetTrigger("Trigger");
        wizard.value -= 0.1f;
        if (wizard.value <= 0)
        {
            PhocoonIAT.Instance.SetUserScore(!auto, 100);
            Rank.gameObject.SetActive(true);
            Rank.GetComponentInChildren<DemoRank>().ShowRank();
            PhocoonIAT.Instance.EndSession();
        }
    }

    public void WizardHeal()
    {
        WizardAnimator.SetTrigger("Heal");
        HealAnimator.gameObject.SetActive(true);
        HealAnimator.SetTrigger("Trigger");
        wizard.value += 0.1f;
    }

    public void WormHeal()
    {
        WormAnimator.SetTrigger("Heal");
        HealAnimator.gameObject.SetActive(true);
        HealAnimator.SetTrigger("Trigger");
        worm.value += 0.1f;
    }
}
