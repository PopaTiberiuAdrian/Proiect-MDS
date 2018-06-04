using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

[TestFixture]
public class PlayerStatsTests {

    [Test]
    public void PlayerBeginsWithMinMoneyTest()
    {
        const int minAmountOfMoney = 0;
        PlayerStats playerStats = new PlayerStats();
        Assert.That(playerStats.getAmountOfMoney(), Is.EqualTo(minAmountOfMoney));
    }

    [TestCase(20, 9999,9999)]
    [TestCase(0, 9999,9999)]
    public void PlayerAmountOfMoneyNeverPassLimitTest(int moneyThatIncrease, int amountOfMoney, int moneyExpected)
    {
        PlayerStats playerStats = new PlayerStats(amountOfMoney);
        playerStats.increaseAmountOfMoney(moneyThatIncrease);
        Assert.That(playerStats.getAmountOfMoney(), Is.EqualTo(moneyExpected));
    }

    [TestCase(20, 0)]
    [TestCase(0, 0)]
    public void PlayerAmountOfMoneyNeverNegativeTest(int moneyThatDecrease, int moneyExpected)
    {
        PlayerStats playerStats = new PlayerStats();
        playerStats.decreaseAmountOfMoney(moneyThatDecrease);
        Assert.That(playerStats.getAmountOfMoney(), Is.EqualTo(moneyExpected));
    }

    [TestCase(20, 5, 0, 0, 0)]
    [TestCase(20, 5, 20, 5, 15)]
    [TestCase(20, 5, 20, 10, 10)]
    public void RoundsRemainingInClipTest(int maxAmmo, float reloadTime, int clipSize, int shotsFiredInClip, int roundsRemainingInClip)
    {
        WeaponReloader weaponReloader = new WeaponReloader(maxAmmo,reloadTime,clipSize);
        weaponReloader.shotsFiredInClip = 0;
        weaponReloader.TakeFromClip(shotsFiredInClip);
        Assert.That(clipSize - weaponReloader.shotsFiredInClip, Is.EqualTo(roundsRemainingInClip));
    }

    [Test]
    public void PlayerAmountOfMoneyOppositeValuesTest(int oppositeNumber)
    {
        
    }
}
