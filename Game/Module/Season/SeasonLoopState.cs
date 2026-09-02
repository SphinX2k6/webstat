using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.Module.Season
{
	// Token: 0x02004FF9 RID: 20473
	[RequiredMember]
	public class SeasonLoopState : ISeasonLoopState
	{
		// Token: 0x17008AA2 RID: 35490
		// (get) Token: 0x06034C5D RID: 216157 RVA: 0x00D3E75B File Offset: 0x00D3C95B
		// (set) Token: 0x06034C5E RID: 216158 RVA: 0x00D3E763 File Offset: 0x00D3C963
		[RequiredMember]
		public ESeason CurrentSeason { get; set; }

		// Token: 0x17008AA3 RID: 35491
		// (get) Token: 0x06034C5F RID: 216159 RVA: 0x00D3E76C File Offset: 0x00D3C96C
		// (set) Token: 0x06034C60 RID: 216160 RVA: 0x00D3E774 File Offset: 0x00D3C974
		[RequiredMember]
		public ESeasonLoopPhase Phase { get; set; }

		// Token: 0x17008AA4 RID: 35492
		// (get) Token: 0x06034C61 RID: 216161 RVA: 0x00D3E77D File Offset: 0x00D3C97D
		// (set) Token: 0x06034C62 RID: 216162 RVA: 0x00D3E785 File Offset: 0x00D3C985
		[RequiredMember]
		public double PhaseElapsed { get; set; }

		// Token: 0x06034C63 RID: 216163 RVA: 0x00D3E78E File Offset: 0x00D3C98E
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public SeasonLoopState()
		{
		}
	}
}
