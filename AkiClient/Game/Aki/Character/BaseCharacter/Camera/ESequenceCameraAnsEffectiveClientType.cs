using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Camera
{
	// Token: 0x0200430B RID: 17163
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Camera/ESequenceCameraAnsEffectiveClientType.ESequenceCameraAnsEffectiveClientType")]
	public enum ESequenceCameraAnsEffectiveClientType : byte
	{
		// Token: 0x040199DC RID: 104924
		单客户端,
		// Token: 0x040199DD RID: 104925
		全客户端,
		// Token: 0x040199DE RID: 104926
		锁定目标客户端,
		// Token: 0x040199DF RID: 104927
		仇恨目标客户端,
		// Token: 0x040199E0 RID: 104928
		技能目标客户端,
		// Token: 0x040199E1 RID: 104929
		ESequenceCameraAnsEffectiveClientType_MAX
	}
}
