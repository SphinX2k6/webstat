using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.Hourglass
{
	// Token: 0x02006E5C RID: 28252
	[NullableContext(2)]
	[Nullable(0)]
	[RequiredMember]
	public class QteHourglassCompletedQteInfo : IQteHourglassCompletedQteInfo
	{
		// Token: 0x1700A388 RID: 41864
		// (get) Token: 0x0604490E RID: 280846 RVA: 0x011D3388 File Offset: 0x011D1588
		// (set) Token: 0x0604490F RID: 280847 RVA: 0x011D3390 File Offset: 0x011D1590
		[RequiredMember]
		public int HandleId { get; set; }

		// Token: 0x1700A389 RID: 41865
		// (get) Token: 0x06044910 RID: 280848 RVA: 0x011D3399 File Offset: 0x011D1599
		// (set) Token: 0x06044911 RID: 280849 RVA: 0x011D33A1 File Offset: 0x011D15A1
		[RequiredMember]
		public int QteId { get; set; }

		// Token: 0x1700A38A RID: 41866
		// (get) Token: 0x06044912 RID: 280850 RVA: 0x011D33AA File Offset: 0x011D15AA
		// (set) Token: 0x06044913 RID: 280851 RVA: 0x011D33B2 File Offset: 0x011D15B2
		[RequiredMember]
		public bool IsSuccess { get; set; }

		// Token: 0x1700A38B RID: 41867
		// (get) Token: 0x06044914 RID: 280852 RVA: 0x011D33BB File Offset: 0x011D15BB
		// (set) Token: 0x06044915 RID: 280853 RVA: 0x011D33C3 File Offset: 0x011D15C3
		[RequiredMember]
		public bool IsFail { get; set; }

		// Token: 0x1700A38C RID: 41868
		// (get) Token: 0x06044916 RID: 280854 RVA: 0x011D33CC File Offset: 0x011D15CC
		// (set) Token: 0x06044917 RID: 280855 RVA: 0x011D33D4 File Offset: 0x011D15D4
		public Vector StartPos { get; set; }

		// Token: 0x06044918 RID: 280856 RVA: 0x011D33DD File Offset: 0x011D15DD
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public QteHourglassCompletedQteInfo()
		{
		}
	}
}
