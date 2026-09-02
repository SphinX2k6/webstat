using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Data.Entity.Enum
{
	// Token: 0x02003EF8 RID: 16120
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Data/Entity/Enum/EBodyType.EBodyType")]
	public enum EBodyType : byte
	{
		// Token: 0x040151A2 RID: 86434
		None,
		// Token: 0x040151A3 RID: 86435
		MaleS,
		// Token: 0x040151A4 RID: 86436
		MaleM,
		// Token: 0x040151A5 RID: 86437
		MaleXL,
		// Token: 0x040151A6 RID: 86438
		FemaleS,
		// Token: 0x040151A7 RID: 86439
		FemaleMS,
		// Token: 0x040151A8 RID: 86440
		FemaleM,
		// Token: 0x040151A9 RID: 86441
		FemaleXL,
		// Token: 0x040151AA RID: 86442
		ShopHand,
		// Token: 0x040151AB RID: 86443
		ShopStore,
		// Token: 0x040151AC RID: 86444
		ShopDoll,
		// Token: 0x040151AD RID: 86445
		ShopPhonograph,
		// Token: 0x040151AE RID: 86446
		ShopPicture,
		// Token: 0x040151AF RID: 86447
		EBodyType_MAX
	}
}
