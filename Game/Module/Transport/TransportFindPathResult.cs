using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Transport
{
	// Token: 0x02004E72 RID: 20082
	[NullableContext(1)]
	[Nullable(0)]
	[RequiredMember]
	public class TransportFindPathResult : ITransportFindPathResult
	{
		// Token: 0x170088D4 RID: 35028
		// (get) Token: 0x06033E57 RID: 212567 RVA: 0x00CFC42E File Offset: 0x00CFA62E
		// (set) Token: 0x06033E58 RID: 212568 RVA: 0x00CFC436 File Offset: 0x00CFA636
		[RequiredMember]
		public FVectorDouble RoadStartPoint { get; set; }

		// Token: 0x170088D5 RID: 35029
		// (get) Token: 0x06033E59 RID: 212569 RVA: 0x00CFC43F File Offset: 0x00CFA63F
		// (set) Token: 0x06033E5A RID: 212570 RVA: 0x00CFC447 File Offset: 0x00CFA647
		[RequiredMember]
		public FVectorDouble RoadEndPoint { get; set; }

		// Token: 0x170088D6 RID: 35030
		// (get) Token: 0x06033E5B RID: 212571 RVA: 0x00CFC450 File Offset: 0x00CFA650
		// (set) Token: 0x06033E5C RID: 212572 RVA: 0x00CFC458 File Offset: 0x00CFA658
		[RequiredMember]
		public TArray<UKuroRoadway> Roadways { get; set; }

		// Token: 0x170088D7 RID: 35031
		// (get) Token: 0x06033E5D RID: 212573 RVA: 0x00CFC461 File Offset: 0x00CFA661
		// (set) Token: 0x06033E5E RID: 212574 RVA: 0x00CFC469 File Offset: 0x00CFA669
		[Nullable(2)]
		public UAutopilotRoute AutopilotRoute { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x170088D8 RID: 35032
		// (get) Token: 0x06033E5F RID: 212575 RVA: 0x00CFC472 File Offset: 0x00CFA672
		// (set) Token: 0x06033E60 RID: 212576 RVA: 0x00CFC47A File Offset: 0x00CFA67A
		public double? RouteLength { get; set; }

		// Token: 0x06033E61 RID: 212577 RVA: 0x00CFC483 File Offset: 0x00CFA683
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public TransportFindPathResult()
		{
		}
	}
}
