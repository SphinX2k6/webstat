using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Data.Fight.Enum
{
	// Token: 0x02003EE5 RID: 16101
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Data/Fight/Enum/BPELevelPrefabDestructibleHitInfo.BPELevelPrefabDestructibleHitInfo")]
	public enum BPELevelPrefabDestructibleHitInfo : byte
	{
		// Token: 0x040150DA RID: 86234
		子弹_受击点和地面受击速度_,
		// Token: 0x040150DB RID: 86235
		和实体Range组件Overlap的Actor的位置,
		// Token: 0x040150DC RID: 86236
		和实体Range组件Overlap的Actor的位置和Actor的速度_前提有速度_,
		// Token: 0x040150DD RID: 86237
		和实体Range组件Overlap的Actor的位置和Actor的速度_曲线_,
		// Token: 0x040150DE RID: 86238
		BPELevelPrefabDestructibleHitInfo_MAX
	}
}
