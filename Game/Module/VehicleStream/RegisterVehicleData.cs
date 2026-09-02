using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Component;

namespace CSharpScript.Game.Module.VehicleStream
{
	// Token: 0x02004C46 RID: 19526
	[NullableContext(1)]
	[Nullable(0)]
	[RequiredMember]
	public class RegisterVehicleData : IRegisterVehicleData
	{
		// Token: 0x17008759 RID: 34649
		// (get) Token: 0x06032E10 RID: 208400 RVA: 0x00CBE98D File Offset: 0x00CBCB8D
		// (set) Token: 0x06032E11 RID: 208401 RVA: 0x00CBE995 File Offset: 0x00CBCB95
		[RequiredMember]
		public int VehiclePbDataId { get; set; }

		// Token: 0x1700875A RID: 34650
		// (get) Token: 0x06032E12 RID: 208402 RVA: 0x00CBE99E File Offset: 0x00CBCB9E
		// (set) Token: 0x06032E13 RID: 208403 RVA: 0x00CBE9A6 File Offset: 0x00CBCBA6
		[RequiredMember]
		public int StartRoadId { get; set; }

		// Token: 0x1700875B RID: 34651
		// (get) Token: 0x06032E14 RID: 208404 RVA: 0x00CBE9AF File Offset: 0x00CBCBAF
		// (set) Token: 0x06032E15 RID: 208405 RVA: 0x00CBE9B7 File Offset: 0x00CBCBB7
		[RequiredMember]
		public int StartRoadIndex { get; set; }

		// Token: 0x1700875C RID: 34652
		// (get) Token: 0x06032E16 RID: 208406 RVA: 0x00CBE9C0 File Offset: 0x00CBCBC0
		// (set) Token: 0x06032E17 RID: 208407 RVA: 0x00CBE9C8 File Offset: 0x00CBCBC8
		[RequiredMember]
		public int DestRoadId { get; set; }

		// Token: 0x1700875D RID: 34653
		// (get) Token: 0x06032E18 RID: 208408 RVA: 0x00CBE9D1 File Offset: 0x00CBCBD1
		// (set) Token: 0x06032E19 RID: 208409 RVA: 0x00CBE9D9 File Offset: 0x00CBCBD9
		[RequiredMember]
		public int DestIndex { get; set; }

		// Token: 0x1700875E RID: 34654
		// (get) Token: 0x06032E1A RID: 208410 RVA: 0x00CBE9E2 File Offset: 0x00CBCBE2
		// (set) Token: 0x06032E1B RID: 208411 RVA: 0x00CBE9EA File Offset: 0x00CBCBEA
		[RequiredMember]
		public Vector ActorLocation { get; set; }

		// Token: 0x1700875F RID: 34655
		// (get) Token: 0x06032E1C RID: 208412 RVA: 0x00CBE9F3 File Offset: 0x00CBCBF3
		// (set) Token: 0x06032E1D RID: 208413 RVA: 0x00CBE9FB File Offset: 0x00CBCBFB
		[RequiredMember]
		public Rotator ActorRotator { get; set; }

		// Token: 0x17008760 RID: 34656
		// (get) Token: 0x06032E1E RID: 208414 RVA: 0x00CBEA04 File Offset: 0x00CBCC04
		// (set) Token: 0x06032E1F RID: 208415 RVA: 0x00CBEA0C File Offset: 0x00CBCC0C
		[RequiredMember]
		public ITrafficNavigationConfig BaseConfig { get; set; }

		// Token: 0x06032E20 RID: 208416 RVA: 0x00CBEA15 File Offset: 0x00CBCC15
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public RegisterVehicleData()
		{
		}
	}
}
