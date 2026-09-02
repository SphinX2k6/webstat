using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.VehicleStream
{
	// Token: 0x02004C4A RID: 19530
	[RequiredMember]
	public class MoveCheckResultAndDistance : IMoveCheckResultAndDistance
	{
		// Token: 0x17008767 RID: 34663
		// (get) Token: 0x06032E2E RID: 208430 RVA: 0x00CBEA47 File Offset: 0x00CBCC47
		// (set) Token: 0x06032E2F RID: 208431 RVA: 0x00CBEA4F File Offset: 0x00CBCC4F
		[RequiredMember]
		public EMoveCheckResult Result { get; set; }

		// Token: 0x17008768 RID: 34664
		// (get) Token: 0x06032E30 RID: 208432 RVA: 0x00CBEA58 File Offset: 0x00CBCC58
		// (set) Token: 0x06032E31 RID: 208433 RVA: 0x00CBEA60 File Offset: 0x00CBCC60
		[RequiredMember]
		public float AfterAdjustDistance { get; set; }

		// Token: 0x06032E32 RID: 208434 RVA: 0x00CBEA69 File Offset: 0x00CBCC69
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public MoveCheckResultAndDistance()
		{
		}
	}
}
