using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using UnrealEngine;

namespace CSharpScript.Game.Module.Teleport
{
	// Token: 0x02004EEC RID: 20204
	[NullableContext(2)]
	public interface ITeleportContext
	{
		// Token: 0x170089BB RID: 35259
		// (get) Token: 0x060342FC RID: 213756
		[Nullable(1)]
		string ClientReason { [NullableContext(1)] get; }

		// Token: 0x170089BC RID: 35260
		// (get) Token: 0x060342FD RID: 213757
		FVectorDouble TargetPosition { get; }

		// Token: 0x170089BD RID: 35261
		// (get) Token: 0x060342FE RID: 213758
		ETeleportMode? TeleportMode { get; }

		// Token: 0x170089BE RID: 35262
		// (get) Token: 0x060342FF RID: 213759
		IRotator TargetRotation { get; }

		// Token: 0x170089BF RID: 35263
		// (get) Token: 0x06034300 RID: 213760
		IVector TargetGravityDirect { get; }

		// Token: 0x170089C0 RID: 35264
		// (get) Token: 0x06034301 RID: 213761
		IVector TargetSpeed { get; }

		// Token: 0x170089C1 RID: 35265
		// (get) Token: 0x06034302 RID: 213762
		TeleportReason? ServerReason { get; }

		// Token: 0x170089C2 RID: 35266
		// (get) Token: 0x06034303 RID: 213763
		TransitionOptionPb Option { get; }

		// Token: 0x170089C3 RID: 35267
		// (get) Token: 0x06034304 RID: 213764
		int? TransitionConfigId { get; }

		// Token: 0x170089C4 RID: 35268
		// (get) Token: 0x06034305 RID: 213765
		bool? NeedRestoreCamera { get; }

		// Token: 0x170089C5 RID: 35269
		// (get) Token: 0x06034306 RID: 213766
		GameCtxPb GameCtx { get; }

		// Token: 0x170089C6 RID: 35270
		// (get) Token: 0x06034307 RID: 213767
		Entity ElevatorEntity { get; }

		// Token: 0x170089C7 RID: 35271
		// (get) Token: 0x06034308 RID: 213768
		bool? DisableAutoFade { get; }

		// Token: 0x170089C8 RID: 35272
		// (get) Token: 0x06034309 RID: 213769
		int? TeleportCfgId { get; }

		// Token: 0x170089C9 RID: 35273
		// (get) Token: 0x0603430A RID: 213770
		bool? NeedRequestToServer { get; }

		// Token: 0x170089CA RID: 35274
		// (get) Token: 0x0603430B RID: 213771
		bool? NeedWaitStreaming { get; }

		// Token: 0x170089CB RID: 35275
		// (get) Token: 0x0603430C RID: 213772
		bool? KeepCameraRelativeRotation { get; }

		// Token: 0x170089CC RID: 35276
		// (get) Token: 0x0603430D RID: 213773
		bool? KeepSpeedRelativeRotation { get; }
	}
}
