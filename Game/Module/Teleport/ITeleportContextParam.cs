using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using UnrealEngine;

namespace CSharpScript.Game.Module.Teleport
{
	// Token: 0x02004EED RID: 20205
	[NullableContext(2)]
	[Nullable(0)]
	[RequiredMember]
	public class ITeleportContextParam : ITeleportContext
	{
		// Token: 0x170089CD RID: 35277
		// (get) Token: 0x0603430E RID: 213774 RVA: 0x00D0DEC8 File Offset: 0x00D0C0C8
		// (set) Token: 0x0603430F RID: 213775 RVA: 0x00D0DED0 File Offset: 0x00D0C0D0
		[Nullable(1)]
		[RequiredMember]
		public string ClientReason { [NullableContext(1)] get; [NullableContext(1)] set; }

		// Token: 0x170089CE RID: 35278
		// (get) Token: 0x06034310 RID: 213776 RVA: 0x00D0DED9 File Offset: 0x00D0C0D9
		// (set) Token: 0x06034311 RID: 213777 RVA: 0x00D0DEE1 File Offset: 0x00D0C0E1
		public FVectorDouble TargetPosition { get; set; }

		// Token: 0x170089CF RID: 35279
		// (get) Token: 0x06034312 RID: 213778 RVA: 0x00D0DEEA File Offset: 0x00D0C0EA
		// (set) Token: 0x06034313 RID: 213779 RVA: 0x00D0DEF2 File Offset: 0x00D0C0F2
		public ETeleportMode? TeleportMode { get; set; }

		// Token: 0x170089D0 RID: 35280
		// (get) Token: 0x06034314 RID: 213780 RVA: 0x00D0DEFB File Offset: 0x00D0C0FB
		// (set) Token: 0x06034315 RID: 213781 RVA: 0x00D0DF03 File Offset: 0x00D0C103
		public IRotator TargetRotation { get; set; }

		// Token: 0x170089D1 RID: 35281
		// (get) Token: 0x06034316 RID: 213782 RVA: 0x00D0DF0C File Offset: 0x00D0C10C
		// (set) Token: 0x06034317 RID: 213783 RVA: 0x00D0DF14 File Offset: 0x00D0C114
		public IVector TargetGravityDirect { get; set; }

		// Token: 0x170089D2 RID: 35282
		// (get) Token: 0x06034318 RID: 213784 RVA: 0x00D0DF1D File Offset: 0x00D0C11D
		// (set) Token: 0x06034319 RID: 213785 RVA: 0x00D0DF25 File Offset: 0x00D0C125
		public IVector TargetSpeed { get; set; }

		// Token: 0x170089D3 RID: 35283
		// (get) Token: 0x0603431A RID: 213786 RVA: 0x00D0DF2E File Offset: 0x00D0C12E
		// (set) Token: 0x0603431B RID: 213787 RVA: 0x00D0DF36 File Offset: 0x00D0C136
		public TeleportReason? ServerReason { get; set; }

		// Token: 0x170089D4 RID: 35284
		// (get) Token: 0x0603431C RID: 213788 RVA: 0x00D0DF3F File Offset: 0x00D0C13F
		// (set) Token: 0x0603431D RID: 213789 RVA: 0x00D0DF47 File Offset: 0x00D0C147
		public TransitionOptionPb Option { get; set; }

		// Token: 0x170089D5 RID: 35285
		// (get) Token: 0x0603431E RID: 213790 RVA: 0x00D0DF50 File Offset: 0x00D0C150
		// (set) Token: 0x0603431F RID: 213791 RVA: 0x00D0DF58 File Offset: 0x00D0C158
		public int? TransitionConfigId { get; set; }

		// Token: 0x170089D6 RID: 35286
		// (get) Token: 0x06034320 RID: 213792 RVA: 0x00D0DF61 File Offset: 0x00D0C161
		// (set) Token: 0x06034321 RID: 213793 RVA: 0x00D0DF69 File Offset: 0x00D0C169
		public bool? NeedRestoreCamera { get; set; }

		// Token: 0x170089D7 RID: 35287
		// (get) Token: 0x06034322 RID: 213794 RVA: 0x00D0DF72 File Offset: 0x00D0C172
		// (set) Token: 0x06034323 RID: 213795 RVA: 0x00D0DF7A File Offset: 0x00D0C17A
		public GameCtxPb GameCtx { get; set; }

		// Token: 0x170089D8 RID: 35288
		// (get) Token: 0x06034324 RID: 213796 RVA: 0x00D0DF83 File Offset: 0x00D0C183
		// (set) Token: 0x06034325 RID: 213797 RVA: 0x00D0DF8B File Offset: 0x00D0C18B
		public Entity ElevatorEntity { get; set; }

		// Token: 0x170089D9 RID: 35289
		// (get) Token: 0x06034326 RID: 213798 RVA: 0x00D0DF94 File Offset: 0x00D0C194
		// (set) Token: 0x06034327 RID: 213799 RVA: 0x00D0DF9C File Offset: 0x00D0C19C
		public bool? DisableAutoFade { get; set; }

		// Token: 0x170089DA RID: 35290
		// (get) Token: 0x06034328 RID: 213800 RVA: 0x00D0DFA5 File Offset: 0x00D0C1A5
		// (set) Token: 0x06034329 RID: 213801 RVA: 0x00D0DFAD File Offset: 0x00D0C1AD
		public int? TeleportCfgId { get; set; }

		// Token: 0x170089DB RID: 35291
		// (get) Token: 0x0603432A RID: 213802 RVA: 0x00D0DFB6 File Offset: 0x00D0C1B6
		// (set) Token: 0x0603432B RID: 213803 RVA: 0x00D0DFBE File Offset: 0x00D0C1BE
		public bool? NeedRequestToServer { get; set; }

		// Token: 0x170089DC RID: 35292
		// (get) Token: 0x0603432C RID: 213804 RVA: 0x00D0DFC7 File Offset: 0x00D0C1C7
		// (set) Token: 0x0603432D RID: 213805 RVA: 0x00D0DFCF File Offset: 0x00D0C1CF
		public bool? NeedWaitStreaming { get; set; }

		// Token: 0x170089DD RID: 35293
		// (get) Token: 0x0603432E RID: 213806 RVA: 0x00D0DFD8 File Offset: 0x00D0C1D8
		// (set) Token: 0x0603432F RID: 213807 RVA: 0x00D0DFE0 File Offset: 0x00D0C1E0
		public bool? KeepCameraRelativeRotation { get; set; }

		// Token: 0x170089DE RID: 35294
		// (get) Token: 0x06034330 RID: 213808 RVA: 0x00D0DFE9 File Offset: 0x00D0C1E9
		// (set) Token: 0x06034331 RID: 213809 RVA: 0x00D0DFF1 File Offset: 0x00D0C1F1
		public bool? KeepSpeedRelativeRotation { get; set; }

		// Token: 0x06034332 RID: 213810 RVA: 0x00D0DFFA File Offset: 0x00D0C1FA
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public ITeleportContextParam()
		{
		}
	}
}
