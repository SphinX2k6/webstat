using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.Module.Season
{
	// Token: 0x02004FF2 RID: 20466
	[RequiredMember]
	internal class LocatedLoopPosition : ILocatedLoopPosition
	{
		// Token: 0x17008A9D RID: 35485
		// (get) Token: 0x06034C2B RID: 216107 RVA: 0x00D3DCCA File Offset: 0x00D3BECA
		// (set) Token: 0x06034C2C RID: 216108 RVA: 0x00D3DCD2 File Offset: 0x00D3BED2
		[RequiredMember]
		public ESeason Season { get; set; }

		// Token: 0x17008A9E RID: 35486
		// (get) Token: 0x06034C2D RID: 216109 RVA: 0x00D3DCDB File Offset: 0x00D3BEDB
		// (set) Token: 0x06034C2E RID: 216110 RVA: 0x00D3DCE3 File Offset: 0x00D3BEE3
		[RequiredMember]
		public ESeasonLoopPhase Phase { get; set; }

		// Token: 0x06034C2F RID: 216111 RVA: 0x00D3DCEC File Offset: 0x00D3BEEC
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public LocatedLoopPosition()
		{
		}
	}
}
