using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.NewWorld.Character.Common.Controller
{
	// Token: 0x020048F2 RID: 18674
	[RequiredMember]
	public class ProjectileJumpConfig : IProjectileJumpConfig
	{
		// Token: 0x1700830C RID: 33548
		// (get) Token: 0x06030C0F RID: 199695 RVA: 0x00C0B83E File Offset: 0x00C09A3E
		// (set) Token: 0x06030C10 RID: 199696 RVA: 0x00C0B846 File Offset: 0x00C09A46
		[RequiredMember]
		public float BaseJumpHeight { get; set; }

		// Token: 0x1700830D RID: 33549
		// (get) Token: 0x06030C11 RID: 199697 RVA: 0x00C0B84F File Offset: 0x00C09A4F
		// (set) Token: 0x06030C12 RID: 199698 RVA: 0x00C0B857 File Offset: 0x00C09A57
		[RequiredMember]
		public float BaseJumpDistanceRate { get; set; }

		// Token: 0x1700830E RID: 33550
		// (get) Token: 0x06030C13 RID: 199699 RVA: 0x00C0B860 File Offset: 0x00C09A60
		// (set) Token: 0x06030C14 RID: 199700 RVA: 0x00C0B868 File Offset: 0x00C09A68
		[RequiredMember]
		public float MaxJumpDistance { get; set; }

		// Token: 0x1700830F RID: 33551
		// (get) Token: 0x06030C15 RID: 199701 RVA: 0x00C0B871 File Offset: 0x00C09A71
		// (set) Token: 0x06030C16 RID: 199702 RVA: 0x00C0B879 File Offset: 0x00C09A79
		[RequiredMember]
		public float MaxJumpHeight { get; set; }

		// Token: 0x17008310 RID: 33552
		// (get) Token: 0x06030C17 RID: 199703 RVA: 0x00C0B882 File Offset: 0x00C09A82
		// (set) Token: 0x06030C18 RID: 199704 RVA: 0x00C0B88A File Offset: 0x00C09A8A
		[RequiredMember]
		public float JumpAcceleration { get; set; }

		// Token: 0x17008311 RID: 33553
		// (get) Token: 0x06030C19 RID: 199705 RVA: 0x00C0B893 File Offset: 0x00C09A93
		// (set) Token: 0x06030C1A RID: 199706 RVA: 0x00C0B89B File Offset: 0x00C09A9B
		[RequiredMember]
		public float TargetSpeedForJump { get; set; }

		// Token: 0x17008312 RID: 33554
		// (get) Token: 0x06030C1B RID: 199707 RVA: 0x00C0B8A4 File Offset: 0x00C09AA4
		// (set) Token: 0x06030C1C RID: 199708 RVA: 0x00C0B8AC File Offset: 0x00C09AAC
		[RequiredMember]
		public float AllTimeForJump { get; set; }

		// Token: 0x17008313 RID: 33555
		// (get) Token: 0x06030C1D RID: 199709 RVA: 0x00C0B8B5 File Offset: 0x00C09AB5
		// (set) Token: 0x06030C1E RID: 199710 RVA: 0x00C0B8BD File Offset: 0x00C09ABD
		[RequiredMember]
		public float JumpBlendTime { get; set; }

		// Token: 0x06030C1F RID: 199711 RVA: 0x00C0B8C6 File Offset: 0x00C09AC6
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public ProjectileJumpConfig()
		{
		}
	}
}
