using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.LevelGamePlay.Common.GameplayAction;

namespace CSharpScript.Game.LevelGamePlay.FindSunSprite.Performance.SunSpiritMove
{
	// Token: 0x02006EBA RID: 28346
	public class SunSpiritActionTicker : GameplayActionTicker
	{
		// Token: 0x06044B82 RID: 281474 RVA: 0x011DD624 File Offset: 0x011DB824
		[NullableContext(1)]
		public override void PushAction(GameplayAction action)
		{
			base.PushAction(action);
			if (this.ActionList.Count > 0 && this.MoveTimer == null)
			{
				this.MoveTimer = TimerSystem.Instance.Forever(new TTimerAction(this.TickAction), 20f, 1f, null, null, true);
			}
		}

		// Token: 0x06044B83 RID: 281475 RVA: 0x011DD678 File Offset: 0x011DB878
		public override void TickAction(float delta)
		{
			base.TickAction(delta);
			if (this.ActionList.Count <= 0)
			{
				TimerHandle moveTimer = this.MoveTimer;
				if (moveTimer != null)
				{
					moveTimer.Remove();
				}
				this.MoveTimer = null;
			}
		}

		// Token: 0x06044B84 RID: 281476 RVA: 0x011DD6A8 File Offset: 0x011DB8A8
		public override void Clear()
		{
			base.Clear();
			TimerHandle moveTimer = this.MoveTimer;
			if (moveTimer != null)
			{
				moveTimer.Remove();
			}
			this.MoveTimer = null;
		}

		// Token: 0x0402642E RID: 156718
		[Nullable(2)]
		private TimerHandle MoveTimer;
	}
}
