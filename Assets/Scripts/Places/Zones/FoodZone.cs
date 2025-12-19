using UnityEngine;

public class FoodZone : Place
{
    [Header("Parameters :")]
    [SerializeField] int progressAmount = 2;
    public int ProgressAmount
    { get => progressAmount; set => progressAmount = value; }
    [SerializeField] float _delayToGetResource = 5f;

    //[SerializeField] int[] _delayToGetResource = new int[3] { 1, 0, 0 };
    float _lastSpawn;

    public override void Action(Villager villager)
    {
        if (Time.time > _lastSpawn + _delayToGetResource)
        {
            GameManager.Instance.Food += progressAmount;
            _lastSpawn = Time.time;
        }
    }

    public override void PreAction(Villager villager)
    {
        base.PreAction(villager);
        villager.WorkAnimator.SetBool("IsPicking", true);

    }

    public override void PostAction(Villager villager, Coroutine coroutine)
    {
        base.PostAction(villager, coroutine);
        villager.WorkAnimator.SetBool("IsPicking", false);
    }
}


