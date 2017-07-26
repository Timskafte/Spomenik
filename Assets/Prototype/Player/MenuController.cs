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
        gameObject.transform.FindChild("StatMenu/Health/HealthText").gameObject.GetComponent<Text>().text = "Health: " + playerStatManager.health.ToString();
        gameObject.transform.FindChild("StatMenu/Armor/ArmorText").gameObject.GetComponent<Text>().text = "Armor: " + playerStatManager.stats.armor.ToString();
        gameObject.transform.FindChild("StatMenu/MagicResist/MagicResistText").gameObject.GetComponent<Text>().text = "Magic Resist: " + playerStatManager.stats.magicResist.ToString();
        gameObject.transform.FindChild("StatMenu/ChaosResist/ChaosResistText").gameObject.GetComponent<Text>().text = "Chaos Resist: " + playerStatManager.stats.chaosResist.ToString();
        gameObject.transform.FindChild("StatMenu/HealingReceived/HealingReceivedText").gameObject.GetComponent<Text>().text = "Healing Received: " + playerStatManager.stats.healingReceived.ToString();

        gameObject.transform.FindChild("StatMenu/PhysicalDamage/PhysicalDamageText").gameObject.GetComponent<Text>().text = "Physical Damage: " + playerStatManager.stats.physicalDamage.ToString();
        gameObject.transform.FindChild("StatMenu/MagicDamage/MagicDamageText").gameObject.GetComponent<Text>().text = "Magic Damage: " + playerStatManager.stats.magicDamage.ToString();
        gameObject.transform.FindChild("StatMenu/ChaosDamage/ChaosDamageText").gameObject.GetComponent<Text>().text = "Chaos Damage: " + playerStatManager.stats.chaosDamage.ToString();
        gameObject.transform.FindChild("StatMenu/CritChance/CritChanceText").gameObject.GetComponent<Text>().text = "Crit Chance: " + playerStatManager.stats.critChance.ToString();
        gameObject.transform.FindChild("StatMenu/CritDamage/CritDamageText").gameObject.GetComponent<Text>().text = "Crit Damage: " + playerStatManager.stats.critDamage.ToString();

        gameObject.transform.FindChild("StatMenu/MoveSpeed/MoveSpeedText").gameObject.GetComponent<Text>().text = "Move Speed: " + playerStatManager.stats.moveSpeed.ToString();
        gameObject.transform.FindChild("StatMenu/Mana/ManaText").gameObject.GetComponent<Text>().text = "Mana: " + playerStatManager.stats.manaPool.ToString();
        gameObject.transform.FindChild("StatMenu/CooldownReduction/CooldownReductionText").gameObject.GetComponent<Text>().text = "Cooldown Reduction: " + playerStatManager.stats.cooldownReduction.ToString();
        gameObject.transform.FindChild("StatMenu/HealingAmount/HealingAmountText").gameObject.GetComponent<Text>().text = "Healing Amount: " + playerStatManager.stats.healingBonus.ToString();
    }
}
