using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.Input.Enum
{
	// Token: 0x020041AC RID: 16812
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/Input/Enum/EInputAction.EInputAction")]
	public enum EInputAction : byte
	{
		// Token: 0x04018D6F RID: 101743
		None,
		// Token: 0x04018D70 RID: 101744
		跳跃,
		// Token: 0x04018D71 RID: 101745
		攀爬,
		// Token: 0x04018D72 RID: 101746
		走跑切换,
		// Token: 0x04018D73 RID: 101747
		攻击,
		// Token: 0x04018D74 RID: 101748
		闪避,
		// Token: 0x04018D75 RID: 101749
		技能1,
		// Token: 0x04018D76 RID: 101750
		幻象1,
		// Token: 0x04018D77 RID: 101751
		大招,
		// Token: 0x04018D78 RID: 101752
		幻象2,
		// Token: 0x04018D79 RID: 101753
		切换角色1,
		// Token: 0x04018D7A RID: 101754
		切换角色2,
		// Token: 0x04018D7B RID: 101755
		切换角色3,
		// Token: 0x04018D7C RID: 101756
		锁定目标,
		// Token: 0x04018D7D RID: 101757
		瞄准,
		// Token: 0x04018D7E RID: 101758
		通用交互,
		// Token: 0x04018D7F RID: 101759
		下降,
		// Token: 0x04018D80 RID: 101760
		移动输入按键事件,
		// Token: 0x04018D81 RID: 101761
		EInputAction_MAX
	}
}
