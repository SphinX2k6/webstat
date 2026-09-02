using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.WuwaGo
{
	// Token: 0x02004AAD RID: 19117
	[NullableContext(1)]
	[Nullable(0)]
	[RequiredMember]
	public class WuWaGoWorldMoveDriverOptions : IWuWaGoWorldMoveDriverOptions
	{
		// Token: 0x170084FC RID: 34044
		// (get) Token: 0x06031D76 RID: 204150 RVA: 0x00C79A73 File Offset: 0x00C77C73
		// (set) Token: 0x06031D77 RID: 204151 RVA: 0x00C79A7B File Offset: 0x00C77C7B
		[RequiredMember]
		public IReadOnlyList<IWuWaGoWorldMoveTarget> Targets { get; set; }

		// Token: 0x170084FD RID: 34045
		// (get) Token: 0x06031D78 RID: 204152 RVA: 0x00C79A84 File Offset: 0x00C77C84
		// (set) Token: 0x06031D79 RID: 204153 RVA: 0x00C79A8C File Offset: 0x00C77C8C
		[RequiredMember]
		public Vector FromWorldPosition { get; set; }

		// Token: 0x170084FE RID: 34046
		// (get) Token: 0x06031D7A RID: 204154 RVA: 0x00C79A95 File Offset: 0x00C77C95
		// (set) Token: 0x06031D7B RID: 204155 RVA: 0x00C79A9D File Offset: 0x00C77C9D
		[RequiredMember]
		public Vector ToWorldPosition { get; set; }

		// Token: 0x170084FF RID: 34047
		// (get) Token: 0x06031D7C RID: 204156 RVA: 0x00C79AA6 File Offset: 0x00C77CA6
		// (set) Token: 0x06031D7D RID: 204157 RVA: 0x00C79AAE File Offset: 0x00C77CAE
		public int? DurationMs { get; set; }

		// Token: 0x17008500 RID: 34048
		// (get) Token: 0x06031D7E RID: 204158 RVA: 0x00C79AB7 File Offset: 0x00C77CB7
		// (set) Token: 0x06031D7F RID: 204159 RVA: 0x00C79ABF File Offset: 0x00C77CBF
		public float? Speed { get; set; }

		// Token: 0x17008501 RID: 34049
		// (get) Token: 0x06031D80 RID: 204160 RVA: 0x00C79AC8 File Offset: 0x00C77CC8
		// (set) Token: 0x06031D81 RID: 204161 RVA: 0x00C79AD0 File Offset: 0x00C77CD0
		public int? TimeoutMs { get; set; }

		// Token: 0x17008502 RID: 34050
		// (get) Token: 0x06031D82 RID: 204162 RVA: 0x00C79AD9 File Offset: 0x00C77CD9
		// (set) Token: 0x06031D83 RID: 204163 RVA: 0x00C79AE1 File Offset: 0x00C77CE1
		public int? TickIntervalMs { get; set; }

		// Token: 0x17008503 RID: 34051
		// (get) Token: 0x06031D84 RID: 204164 RVA: 0x00C79AEA File Offset: 0x00C77CEA
		// (set) Token: 0x06031D85 RID: 204165 RVA: 0x00C79AF2 File Offset: 0x00C77CF2
		public int? SettleDurationMs { get; set; }

		// Token: 0x17008504 RID: 34052
		// (get) Token: 0x06031D86 RID: 204166 RVA: 0x00C79AFB File Offset: 0x00C77CFB
		// (set) Token: 0x06031D87 RID: 204167 RVA: 0x00C79B03 File Offset: 0x00C77D03
		public float? EarlyStopStepRatio { get; set; }

		// Token: 0x17008505 RID: 34053
		// (get) Token: 0x06031D88 RID: 204168 RVA: 0x00C79B0C File Offset: 0x00C77D0C
		// (set) Token: 0x06031D89 RID: 204169 RVA: 0x00C79B14 File Offset: 0x00C77D14
		public float? ArriveTolerance { get; set; }

		// Token: 0x17008506 RID: 34054
		// (get) Token: 0x06031D8A RID: 204170 RVA: 0x00C79B1D File Offset: 0x00C77D1D
		// (set) Token: 0x06031D8B RID: 204171 RVA: 0x00C79B25 File Offset: 0x00C77D25
		[Nullable(2)]
		public Func<bool> ShouldAbort { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x17008507 RID: 34055
		// (get) Token: 0x06031D8C RID: 204172 RVA: 0x00C79B2E File Offset: 0x00C77D2E
		// (set) Token: 0x06031D8D RID: 204173 RVA: 0x00C79B36 File Offset: 0x00C77D36
		public EWuWaGoTimeStopPolicy? TimeStopPolicy { get; set; }

		// Token: 0x17008508 RID: 34056
		// (get) Token: 0x06031D8E RID: 204174 RVA: 0x00C79B3F File Offset: 0x00C77D3F
		// (set) Token: 0x06031D8F RID: 204175 RVA: 0x00C79B47 File Offset: 0x00C77D47
		[Nullable(2)]
		public IWuWaGoWorldMoveHooks Hooks { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x06031D90 RID: 204176 RVA: 0x00C79B50 File Offset: 0x00C77D50
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public WuWaGoWorldMoveDriverOptions()
		{
		}
	}
}
