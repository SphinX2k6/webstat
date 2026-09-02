using System;
using CSharpScript.Game.Module.Activity.ActivityContent.WheelTower;

// Token: 0x0200173F RID: 5951
public class CheckWheelTowerCanShowHandler : CheckDungeonTypeCanShowHandlerBase
{
	// Token: 0x0600A740 RID: 42816 RVA: 0x002C6FCC File Offset: 0x002C51CC
	public override bool CheckCanShow()
	{
		WheelTowerData activityData = ModelBase<WheelTowerModel>.Instance.ActivityData;
		return activityData != null && activityData.IsUnLock() && activityData.IsInCycle();
	}
}
