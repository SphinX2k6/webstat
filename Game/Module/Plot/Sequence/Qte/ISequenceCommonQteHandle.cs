using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Plot.Sequence.Qte
{
	// Token: 0x02005394 RID: 21396
	[NullableContext(2)]
	public interface ISequenceCommonQteHandle
	{
		// Token: 0x17008D99 RID: 36249
		// (get) Token: 0x060368EB RID: 223467
		// (set) Token: 0x060368EC RID: 223468
		int SubtitleId { get; set; }

		// Token: 0x17008D9A RID: 36250
		// (get) Token: 0x060368ED RID: 223469
		// (set) Token: 0x060368EE RID: 223470
		int OptionIndex { get; set; }

		// Token: 0x17008D9B RID: 36251
		// (get) Token: 0x060368EF RID: 223471
		// (set) Token: 0x060368F0 RID: 223472
		bool IsProgressQte { get; set; }

		// Token: 0x17008D9C RID: 36252
		// (get) Token: 0x060368F1 RID: 223473
		// (set) Token: 0x060368F2 RID: 223474
		bool IsUpdateWithProgress { get; set; }

		// Token: 0x17008D9D RID: 36253
		// (get) Token: 0x060368F3 RID: 223475
		// (set) Token: 0x060368F4 RID: 223476
		FFrameTime SequenceQteStartRange { get; set; }

		// Token: 0x17008D9E RID: 36254
		// (get) Token: 0x060368F5 RID: 223477
		// (set) Token: 0x060368F6 RID: 223478
		FFrameTime SequenceQteEndRange { get; set; }

		// Token: 0x17008D9F RID: 36255
		// (get) Token: 0x060368F7 RID: 223479
		// (set) Token: 0x060368F8 RID: 223480
		QteSpineInfoProxy SpineInfo { get; set; }

		// Token: 0x060368F9 RID: 223481
		void OnBegin();

		// Token: 0x060368FA RID: 223482
		void OnFinish();

		// Token: 0x060368FB RID: 223483
		void OnSequenceAnimFinished();

		// Token: 0x060368FC RID: 223484
		void OnTick(float delta);

		// Token: 0x060368FD RID: 223485
		void ForceStopSequenceQte();
	}
}
