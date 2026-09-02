using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.NewWorld.Character.Common.Controller
{
	// Token: 0x020048F0 RID: 18672
	[RequiredMember]
	public class JumpProjectileParams : IJumpProjectileParams
	{
		// Token: 0x170082FF RID: 33535
		// (get) Token: 0x06030BF4 RID: 199668 RVA: 0x00C0B7E1 File Offset: 0x00C099E1
		// (set) Token: 0x06030BF5 RID: 199669 RVA: 0x00C0B7E9 File Offset: 0x00C099E9
		[RequiredMember]
		public float Length { get; set; }

		// Token: 0x17008300 RID: 33536
		// (get) Token: 0x06030BF6 RID: 199670 RVA: 0x00C0B7F2 File Offset: 0x00C099F2
		// (set) Token: 0x06030BF7 RID: 199671 RVA: 0x00C0B7FA File Offset: 0x00C099FA
		[RequiredMember]
		public float AllTime { get; set; }

		// Token: 0x17008301 RID: 33537
		// (get) Token: 0x06030BF8 RID: 199672 RVA: 0x00C0B803 File Offset: 0x00C09A03
		// (set) Token: 0x06030BF9 RID: 199673 RVA: 0x00C0B80B File Offset: 0x00C09A0B
		[RequiredMember]
		public float Height0 { get; set; }

		// Token: 0x17008302 RID: 33538
		// (get) Token: 0x06030BFA RID: 199674 RVA: 0x00C0B814 File Offset: 0x00C09A14
		// (set) Token: 0x06030BFB RID: 199675 RVA: 0x00C0B81C File Offset: 0x00C09A1C
		[RequiredMember]
		public float ProjectileA { get; set; }

		// Token: 0x17008303 RID: 33539
		// (get) Token: 0x06030BFC RID: 199676 RVA: 0x00C0B825 File Offset: 0x00C09A25
		// (set) Token: 0x06030BFD RID: 199677 RVA: 0x00C0B82D File Offset: 0x00C09A2D
		[RequiredMember]
		public float ProjectileB { get; set; }

		// Token: 0x06030BFE RID: 199678 RVA: 0x00C0B836 File Offset: 0x00C09A36
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public JumpProjectileParams()
		{
		}
	}
}
