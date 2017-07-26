using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour {


    public GameObject player;
    //private PlayerController playerController;
    private PlayerStatManager playerStatManager;
    private GameObject healthText;

    void Start () {
        //playerController = player.GetComponent<PlayerController>();
        playerStatManager = player.GetComponent<PlayerStatManager>();

    }

    public void updateMenuStats ()
    {
        gameObject.transform.Find("StatMenu/Health/HealthText").gameObject.GetComponent<Text>().text = "Health: " + playerStatManager.health.ToString();
        gameObject.transform.Find("StatMenu/Armor/ArmorText").gameObject.GetComponent<Text>().text = "Armor: " + playerStatManager.stats.armor.ToString();
        gameObject.transform.Find("StatMenu/MagicResist/MagicResistText").gameObject.GetComponent<Text>().text = "Magic Resist: " + ((playerStatManager.stats.magicResist - 1f) * 100f).ToString() + "%";
        gameObject.transform.Find("StatMenu/ChaosResist/ChaosResistText").gameObject.GetComponent<Text>().text = "Chaos Resist: " + ((playerStatManager.stats.chaosResist - 1f) * 100f).ToString() + "%";
        gameObject.transform.Find("StatMenu/HealingReceived/HealingReceivedText").gameObject.GetComponent<Text>().text = "Healing Received: " + ((playerStatManager.stats.healingReceived - 1f) *100f).ToString() + "%";

        gameObject.transform.Find("StatMenu/PhysicalDamage/PhysicalDamageText").gameObject.GetComponent<Text>().text = "Physical Damage: " + ((playerStatManager.stats.physicalDamage - 1f) * 100f).ToString() + "%";
        gameObject.transform.Find("StatMenu/MagicDamage/MagicDamageText").gameObject.GetComponent<Text>().text = "Magic Damage: " + ((playerStatManager.stats.magicDamage - 1f) * 100f).ToString() + "%";
        gameObject.transform.Find("StatMenu/ChaosDamage/ChaosDamageText").gameObject.GetComponent<Text>().text = "Chaos Damage: " + ((playerStatManager.stats.chaosDamage - 1f) * 100f).ToString() + "%";
        gameObject.transform.Find("StatMenu/CritChance/CritChanceText").gameObject.GetComponent<Text>().text = "Crit Chance: " + ((playerStatManager.stats.critChance) * 100f).ToString() + "%";
        gameObject.transform.Find("StatMenu/CritDamage/CritDamageText").gameObject.GetComponent<Text>().text = "Crit Damage: " + ((playerStatManager.stats.critDamage - 1f) * 100f).ToString() + "%";

        gameObject.transform.Find("StatMenu/MoveSpeed/MoveSpeedText").gameObject.GetComponent<Text>().text = "Move Speed: " + playerStatManager.stats.moveSpeed.ToString();
        gameObject.transform.Find("StatMenu/Mana/ManaText").gameObject.GetComponent<Text>().text = "Mana: " + playerStatManager.stats.manaPool.ToString();
        gameObject.transform.Find("StatMenu/CooldownReduction/CooldownReductionText").gameObject.GetComponent<Text>().text = "Cooldown Reduction: " + ((playerStatManager.stats.cooldownReduction - 1f) *100f).ToString() + "%";
        gameObject.transform.Find("StatMenu/HealingAmount/HealingAmountText").gameObject.GetComponent<Text>().text = "Healing Amount: " + ((playerStatManager.stats.healingBonus - 1f) *100f).ToString() + "%";
    }
}
