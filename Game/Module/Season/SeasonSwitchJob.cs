using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.Module.Season
{
	// Token: 0x02004FFC RID: 20476
	[NullableContext(2)]
	[Nullable(0)]
	[RequiredMember]
	public class SeasonSwitchJob : ISeasonSwitchJob
	{
		// Token: 0x17008AAA RID: 35498
		// (get) Token: 0x06034C72 RID: 216178 RVA: 0x00D3E796 File Offset: 0x00D3C996
		// (set) Token: 0x06034C73 RID: 216179 RVA: 0x00D3E79E File Offset: 0x00D3C99E
		[RequiredMember]
		public ESeason TargetSeason { get; set; }

		// Token: 0x17008AAB RID: 35499
		// (get) Token: 0x06034C74 RID: 216180 RVA: 0x00D3E7A7 File Offset: 0x00D3C9A7
		// (set) Token: 0x06034C75 RID: 216181 RVA: 0x00D3E7AF File Offset: 0x00D3C9AF
		[RequiredMember]
		public double TargetValue { get; set; }

		// Token: 0x17008AAC RID: 35500
		// (get) Token: 0x06034C76 RID: 216182 RVA: 0x00D3E7B8 File Offset: 0x00D3C9B8
		// (set) Token: 0x06034C77 RID: 216183 RVA: 0x00D3E7C0 File Offset: 0x00D3C9C0
		[RequiredMember]
		public double Speed { get; set; }

		// Token: 0x17008AAD RID: 35501
		// (get) Token: 0x06034C78 RID: 216184 RVA: 0x00D3E7C9 File Offset: 0x00D3C9C9
		// (set) Token: 0x06034C79 RID: 216185 RVA: 0x00D3E7D1 File Offset: 0x00D3C9D1
		[RequiredMember]
		public double RemainDistance { get; set; }

		// Token: 0x17008AAE RID: 35502
		// (get) Token: 0x06034C7A RID: 216186 RVA: 0x00D3E7DA File Offset: 0x00D3C9DA
		// (set) Token: 0x06034C7B RID: 216187 RVA: 0x00D3E7E2 File Offset: 0x00D3C9E2
		public TSeasonSwitchCallback OnComplete { get; set; }

		// Token: 0x06034C7C RID: 216188 RVA: 0x00D3E7EB File Offset: 0x00D3C9EB
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public SeasonSwitchJob()
		{
		}
	}
}
