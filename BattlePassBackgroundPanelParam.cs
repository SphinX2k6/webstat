using System;
using System.Runtime.CompilerServices;

// Token: 0x0200237F RID: 9087
[NullableContext(2)]
[Nullable(0)]
public class BattlePassBackgroundPanelParam
{
	// Token: 0x060116AC RID: 71340 RVA: 0x004CCCCE File Offset: 0x004CAECE
	public BattlePassBackgroundPanelParam(bool isRewardPanel = false, WeaponSkeletalObserverHandles weaponObservers = null)
	{
		this.IsRewardPanel = isRewardPanel;
		this.WeaponObservers = weaponObservers;
	}

	// Token: 0x040088B7 RID: 34999
	public bool IsRewardPanel;

	// Token: 0x040088B8 RID: 35000
	public WeaponSkeletalObserverHandles WeaponObservers;
}
