using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Effect.Scene
{
	// Token: 0x02003D35 RID: 15669
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Effect/Scene/ESceneEffectStateType.ESceneEffectStateType")]
	public enum ESceneEffectStateType : byte
	{
		// Token: 0x04013A6D RID: 80493
		AirWall,
		// Token: 0x04013A6E RID: 80494
		ToxicFog,
		// Token: 0x04013A6F RID: 80495
		ESceneEffectStateType_MAX
	}
}
