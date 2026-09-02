using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.Module.Plot.Sequence
{
	// Token: 0x02005387 RID: 21383
	public class PlotSubtitleConfig
	{
		// Token: 0x060368A3 RID: 223395 RVA: 0x00DC915E File Offset: 0x00DC735E
		[NullableContext(1)]
		public void CopyFrom(PlotSubtitleConfig other)
		{
			this.Subtitles = other.Subtitles;
			this.GuardTime = other.GuardTime;
			this.AudioDelay = other.AudioDelay;
			this.AudioTransitionDuration = other.AudioTransitionDuration;
			this.AutoPlayDelay = other.AutoPlayDelay;
		}

		// Token: 0x060368A4 RID: 223396 RVA: 0x00DC919C File Offset: 0x00DC739C
		public void Clear()
		{
			this.Subtitles = null;
			this.GuardTime = 0f;
			this.AudioDelay = 0f;
			this.AudioTransitionDuration = 0f;
			this.AutoPlayDelay = 0f;
		}

		// Token: 0x0401F672 RID: 128626
		[Nullable(2)]
		public ITalkItem Subtitles;

		// Token: 0x0401F673 RID: 128627
		public float GuardTime;

		// Token: 0x0401F674 RID: 128628
		public float AudioDelay;

		// Token: 0x0401F675 RID: 128629
		public float AudioTransitionDuration;

		// Token: 0x0401F676 RID: 128630
		public float AutoPlayDelay;
	}
}
