using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.SlidingBlocks
{
	// Token: 0x02004EFC RID: 20220
	[NullableContext(1)]
	[Nullable(0)]
	[RequiredMember]
	public class TargetDescribeAndScore : ITargetDescribeAndScore
	{
		// Token: 0x17008A12 RID: 35346
		// (get) Token: 0x06034437 RID: 214071 RVA: 0x00D12CBE File Offset: 0x00D10EBE
		// (set) Token: 0x06034438 RID: 214072 RVA: 0x00D12CC6 File Offset: 0x00D10EC6
		[RequiredMember]
		public string DescribeTextKey { get; set; }

		// Token: 0x17008A13 RID: 35347
		// (get) Token: 0x06034439 RID: 214073 RVA: 0x00D12CCF File Offset: 0x00D10ECF
		// (set) Token: 0x0603443A RID: 214074 RVA: 0x00D12CD7 File Offset: 0x00D10ED7
		[RequiredMember]
		public int RewardId { get; set; }

		// Token: 0x17008A14 RID: 35348
		// (get) Token: 0x0603443B RID: 214075 RVA: 0x00D12CE0 File Offset: 0x00D10EE0
		// (set) Token: 0x0603443C RID: 214076 RVA: 0x00D12CE8 File Offset: 0x00D10EE8
		[RequiredMember]
		public int Score { get; set; }

		// Token: 0x0603443D RID: 214077 RVA: 0x00D12CF1 File Offset: 0x00D10EF1
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public TargetDescribeAndScore()
		{
		}
	}
}
