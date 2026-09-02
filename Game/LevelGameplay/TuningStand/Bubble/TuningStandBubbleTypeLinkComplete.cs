using System;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.LevelGamePlay.TuningStand.Bubble
{
	// Token: 0x02006A91 RID: 27281
	public class TuningStandBubbleTypeLinkComplete : TuningStandBubbleTypeBase
	{
		// Token: 0x0604376E RID: 276334 RVA: 0x0116195B File Offset: 0x0115FB5B
		public override bool TryStartBubble(bool canPlay)
		{
			if (this.PlayFlow == null)
			{
				return false;
			}
			this.CurIndex = 0;
			base.UpdateBubble();
			return true;
		}

		// Token: 0x04025AE0 RID: 154336
		protected new ETuningStandBubbleTriggerType BubbleType = ETuningStandBubbleTriggerType.LinkComplete;
	}
}
