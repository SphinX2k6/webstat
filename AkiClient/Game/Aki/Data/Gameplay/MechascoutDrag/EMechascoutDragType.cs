using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Data.Gameplay.MechascoutDrag
{
	// Token: 0x02003EB1 RID: 16049
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Data/Gameplay/MechascoutDrag/EMechascoutDragType.EMechascoutDragType")]
	public enum EMechascoutDragType : byte
	{
		// Token: 0x04014E99 RID: 85657
		LongPress,
		// Token: 0x04014E9A RID: 85658
		Instant,
		// Token: 0x04014E9B RID: 85659
		EMechascoutDragType_MAX
	}
}
