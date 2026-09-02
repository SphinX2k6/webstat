using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Sequence.Manager.Enum
{
	// Token: 0x020043B4 RID: 17332
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Sequence/Manager/Enum/SeqCameraMode.SeqCameraMode")]
	public enum SeqCameraMode : byte
	{
		// Token: 0x0401A0FE RID: 106750
		剧情相机,
		// Token: 0x0401A0FF RID: 106751
		跟随相机,
		// Token: 0x0401A100 RID: 106752
		跟随相机剧情模式,
		// Token: 0x0401A101 RID: 106753
		SeqCameraMode_MAX
	}
}
