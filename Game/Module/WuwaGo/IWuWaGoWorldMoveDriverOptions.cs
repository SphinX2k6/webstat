using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.WuwaGo
{
	// Token: 0x02004AAC RID: 19116
	[NullableContext(1)]
	public interface IWuWaGoWorldMoveDriverOptions
	{
		// Token: 0x170084EF RID: 34031
		// (get) Token: 0x06031D69 RID: 204137
		IReadOnlyList<IWuWaGoWorldMoveTarget> Targets { get; }

		// Token: 0x170084F0 RID: 34032
		// (get) Token: 0x06031D6A RID: 204138
		Vector FromWorldPosition { get; }

		// Token: 0x170084F1 RID: 34033
		// (get) Token: 0x06031D6B RID: 204139
		Vector ToWorldPosition { get; }

		// Token: 0x170084F2 RID: 34034
		// (get) Token: 0x06031D6C RID: 204140
		int? DurationMs { get; }

		// Token: 0x170084F3 RID: 34035
		// (get) Token: 0x06031D6D RID: 204141
		float? Speed { get; }

		// Token: 0x170084F4 RID: 34036
		// (get) Token: 0x06031D6E RID: 204142
		int? TimeoutMs { get; }

		// Token: 0x170084F5 RID: 34037
		// (get) Token: 0x06031D6F RID: 204143
		int? TickIntervalMs { get; }

		// Token: 0x170084F6 RID: 34038
		// (get) Token: 0x06031D70 RID: 204144
		int? SettleDurationMs { get; }

		// Token: 0x170084F7 RID: 34039
		// (get) Token: 0x06031D71 RID: 204145
		float? EarlyStopStepRatio { get; }

		// Token: 0x170084F8 RID: 34040
		// (get) Token: 0x06031D72 RID: 204146
		float? ArriveTolerance { get; }

		// Token: 0x170084F9 RID: 34041
		// (get) Token: 0x06031D73 RID: 204147
		[Nullable(2)]
		Func<bool> ShouldAbort { [NullableContext(2)] get; }

		// Token: 0x170084FA RID: 34042
		// (get) Token: 0x06031D74 RID: 204148
		EWuWaGoTimeStopPolicy? TimeStopPolicy { get; }

		// Token: 0x170084FB RID: 34043
		// (get) Token: 0x06031D75 RID: 204149
		[Nullable(2)]
		IWuWaGoWorldMoveHooks Hooks { [NullableContext(2)] get; }
	}
}
