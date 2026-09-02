using System;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.LevelGamePlay.TuningStand.Bubble
{
	// Token: 0x02006A8D RID: 27277
	public class TuningStandBubbleTypeStartLink : TuningStandBubbleTypeBase
	{
		// Token: 0x06043766 RID: 276326 RVA: 0x01161846 File Offset: 0x0115FA46
		public override bool TryStartBubble(bool canPlay)
		{
			if (!canPlay)
			{
				this.HasPlayedOnce = true;
				return false;
			}
			if (this.PlayFlow == null || this.HasPlayedOnce)
			{
				return false;
			}
			this.CurIndex = 0;
			base.UpdateBubble();
			this.HasPlayedOnce = true;
			return true;
		}

		// Token: 0x04025AD9 RID: 154329
		protected new ETuningStandBubbleTriggerType BubbleType = ETuningStandBubbleTriggerType.StartLink;

		// Token: 0x04025ADA RID: 154330
		private bool HasPlayedOnce;
	}
}
