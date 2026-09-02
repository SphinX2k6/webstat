using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.VehicleStream
{
	// Token: 0x02004C48 RID: 19528
	[NullableContext(2)]
	[Nullable(0)]
	[RequiredMember]
	public class DistanceAndRoadway : IDistanceAndRoadway
	{
		// Token: 0x17008763 RID: 34659
		// (get) Token: 0x06032E25 RID: 208421 RVA: 0x00CBEA1D File Offset: 0x00CBCC1D
		// (set) Token: 0x06032E26 RID: 208422 RVA: 0x00CBEA25 File Offset: 0x00CBCC25
		[RequiredMember]
		public float Distance { get; set; }

		// Token: 0x17008764 RID: 34660
		// (get) Token: 0x06032E27 RID: 208423 RVA: 0x00CBEA2E File Offset: 0x00CBCC2E
		// (set) Token: 0x06032E28 RID: 208424 RVA: 0x00CBEA36 File Offset: 0x00CBCC36
		[RequiredMember]
		public UKuroRoadway Roadway { get; set; }

		// Token: 0x06032E29 RID: 208425 RVA: 0x00CBEA3F File Offset: 0x00CBCC3F
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public DistanceAndRoadway()
		{
		}
	}
}
