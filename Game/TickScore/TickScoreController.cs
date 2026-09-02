using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.TickScore
{
	// Token: 0x02004727 RID: 18215
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class TickScoreController : Singleton<TickScoreController>, ITickable
	{
		// Token: 0x0602F4D9 RID: 193753 RVA: 0x00B371C6 File Offset: 0x00B353C6
		public void Init()
		{
			this.SwimTickScore = new ScoreUpdateManager(1f, 3);
		}

		// Token: 0x0602F4DA RID: 193754 RVA: 0x00B371D9 File Offset: 0x00B353D9
		public void Tick(float delta)
		{
			this.SwimTickScore.Update();
		}

		// Token: 0x0401AF13 RID: 110355
		private const int SWIM_MAX_COUNT = 3;

		// Token: 0x0401AF14 RID: 110356
		[Nullable(1)]
		public ScoreUpdateManager SwimTickScore;
	}
}
