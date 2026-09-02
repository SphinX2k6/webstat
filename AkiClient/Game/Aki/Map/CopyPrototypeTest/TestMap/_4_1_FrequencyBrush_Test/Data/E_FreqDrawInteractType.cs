using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Map.CopyPrototypeTest.TestMap._4_1_FrequencyBrush_Test.Data
{
	// Token: 0x02003DB4 RID: 15796
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Map/CopyPrototypeTest/TestMap/4_1_FrequencyBrush_Test/Data/E_FreqDrawInteractType.E_FreqDrawInteractType")]
	public enum E_FreqDrawInteractType : byte
	{
		// Token: 0x04014297 RID: 82583
		破坏,
		// Token: 0x04014298 RID: 82584
		激活,
		// Token: 0x04014299 RID: 82585
		创造物体,
		// Token: 0x0401429A RID: 82586
		跟随轨迹移动,
		// Token: 0x0401429B RID: 82587
		创造空间,
		// Token: 0x0401429C RID: 82588
		根据轨迹链接,
		// Token: 0x0401429D RID: 82589
		无,
		// Token: 0x0401429E RID: 82590
		E_MAX
	}
}
