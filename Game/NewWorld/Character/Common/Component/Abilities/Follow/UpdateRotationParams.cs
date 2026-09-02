using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.Character.Common.Component.Abilities.Follow
{
	// Token: 0x0200497C RID: 18812
	[NullableContext(1)]
	[Nullable(0)]
	[RequiredMember]
	public class UpdateRotationParams : IUpdateRotationParams
	{
		// Token: 0x170083DD RID: 33757
		// (get) Token: 0x060312A7 RID: 201383 RVA: 0x00C3DEF6 File Offset: 0x00C3C0F6
		// (set) Token: 0x060312A8 RID: 201384 RVA: 0x00C3DEFE File Offset: 0x00C3C0FE
		public float DeltaTimeMs { get; set; }

		// Token: 0x170083DE RID: 33758
		// (get) Token: 0x060312A9 RID: 201385 RVA: 0x00C3DF07 File Offset: 0x00C3C107
		// (set) Token: 0x060312AA RID: 201386 RVA: 0x00C3DF0F File Offset: 0x00C3C10F
		public float RotationInterpSpeed { get; set; }

		// Token: 0x170083DF RID: 33759
		// (get) Token: 0x060312AB RID: 201387 RVA: 0x00C3DF18 File Offset: 0x00C3C118
		// (set) Token: 0x060312AC RID: 201388 RVA: 0x00C3DF20 File Offset: 0x00C3C120
		[RequiredMember]
		public FRotator RotateOffset { get; set; }

		// Token: 0x170083E0 RID: 33760
		// (get) Token: 0x060312AD RID: 201389 RVA: 0x00C3DF29 File Offset: 0x00C3C129
		// (set) Token: 0x060312AE RID: 201390 RVA: 0x00C3DF31 File Offset: 0x00C3C131
		[RequiredMember]
		public FollowShooterAimTarget AimTarget { get; set; }

		// Token: 0x060312AF RID: 201391 RVA: 0x00C3DF3A File Offset: 0x00C3C13A
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public UpdateRotationParams()
		{
		}
	}
}
