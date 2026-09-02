using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Data.QuickTimeAction.Customization
{
	// Token: 0x02003E27 RID: 15911
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Data/QuickTimeAction/Customization/EQtaCustomizationViewType.EQtaCustomizationViewType")]
	public enum EQtaCustomizationViewType : byte
	{
		// Token: 0x04014809 RID: 83977
		无界面,
		// Token: 0x0401480A RID: 83978
		限次长按洛瑟菈技能交互指示器界面,
		// Token: 0x0401480B RID: 83979
		拍照并收集物品,
		// Token: 0x0401480C RID: 83980
		打开指定界面,
		// Token: 0x0401480D RID: 83981
		EQtaCustomizationViewType_MAX
	}
}
