using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.GamePlay.Cipher
{
	// Token: 0x02003DD9 RID: 15833
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/GamePlay/Cipher/ECipherGameplayType.ECipherGameplayType")]
	public enum ECipherGameplayType : byte
	{
		// Token: 0x040143FD RID: 82941
		数字,
		// Token: 0x040143FE RID: 82942
		文字,
		// Token: 0x040143FF RID: 82943
		图片,
		// Token: 0x04014400 RID: 82944
		ECipherGameplayType_MAX
	}
}
