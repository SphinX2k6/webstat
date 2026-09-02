using System;

// Token: 0x02001F8D RID: 8077
public class FlyRaceStrengthHandle : RaceStrengthHandle
{
	// Token: 0x0600F212 RID: 61970 RVA: 0x0042209B File Offset: 0x0042029B
	protected override void InitTagAndAttributeId()
	{
		this.FormationAttributeId = EFormationAttributeId.FlameRaceStrength;
		this.VisibleTagId = GameplayTagDefine.EGameplayTagId["关卡.圣火追逐.专用ui"];
		this.SpeedUpTagId = GameplayTagDefine.EGameplayTagId["关卡.圣火追逐.能量不衰减"];
	}
}
