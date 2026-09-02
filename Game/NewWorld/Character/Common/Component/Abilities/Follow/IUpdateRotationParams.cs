using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.Character.Common.Component.Abilities.Follow
{
	// Token: 0x0200497B RID: 18811
	[NullableContext(1)]
	public interface IUpdateRotationParams
	{
		// Token: 0x170083D9 RID: 33753
		// (get) Token: 0x0603129F RID: 201375
		// (set) Token: 0x060312A0 RID: 201376
		float DeltaTimeMs { get; set; }

		// Token: 0x170083DA RID: 33754
		// (get) Token: 0x060312A1 RID: 201377
		// (set) Token: 0x060312A2 RID: 201378
		float RotationInterpSpeed { get; set; }

		// Token: 0x170083DB RID: 33755
		// (get) Token: 0x060312A3 RID: 201379
		// (set) Token: 0x060312A4 RID: 201380
		FRotator RotateOffset { get; set; }

		// Token: 0x170083DC RID: 33756
		// (get) Token: 0x060312A5 RID: 201381
		// (set) Token: 0x060312A6 RID: 201382
		FollowShooterAimTarget AimTarget { get; set; }
	}
}
