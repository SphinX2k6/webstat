using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x020041DC RID: 16860
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/EAttributeOperation.EAttributeOperation")]
	public enum EAttributeOperation : byte
	{
		// Token: 0x04018FEF RID: 102383
		加,
		// Token: 0x04018FF0 RID: 102384
		减,
		// Token: 0x04018FF1 RID: 102385
		乘,
		// Token: 0x04018FF2 RID: 102386
		除,
		// Token: 0x04018FF3 RID: 102387
		赋值,
		// Token: 0x04018FF4 RID: 102388
		EAttributeOperation_MAX
	}
}
