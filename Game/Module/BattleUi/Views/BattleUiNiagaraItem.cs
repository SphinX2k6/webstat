using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02005FDC RID: 24540
	[NullableContext(1)]
	[Nullable(0)]
	public class BattleUiNiagaraItem
	{
		// Token: 0x0603DC00 RID: 252928 RVA: 0x00FBB1C6 File Offset: 0x00FB93C6
		public BattleUiNiagaraItem(UUINiagara item)
		{
			this.Item = item;
			this.Duration = 1000f;
			this.Item.bIsAlphaZeroClip = false;
		}

		// Token: 0x0603DC01 RID: 252929 RVA: 0x00FBB1EC File Offset: 0x00FB93EC
		public void Play()
		{
			this.Item.SetUIActive(true);
			this.Item.ActivateSystem(true);
			this.RemoveTimer();
			this.AddTimer();
		}

		// Token: 0x0603DC02 RID: 252930 RVA: 0x00FBB212 File Offset: 0x00FB9412
		private void OnTimer(float _)
		{
			this.TimerId = null;
			this.StopInternal();
		}

		// Token: 0x0603DC03 RID: 252931 RVA: 0x00FBB221 File Offset: 0x00FB9421
		public void Stop()
		{
			if (this.TimerId == null)
			{
				return;
			}
			this.RemoveTimer();
			this.StopInternal();
		}

		// Token: 0x0603DC04 RID: 252932 RVA: 0x00FBB238 File Offset: 0x00FB9438
		private void StopInternal()
		{
			this.Item.SetUIActive(false);
		}

		// Token: 0x0603DC05 RID: 252933 RVA: 0x00FBB246 File Offset: 0x00FB9446
		private void AddTimer()
		{
			this.TimerId = TimerSystem.Instance.Delay(new TTimerAction(this.OnTimer), this.Duration, null, null, true, 1f);
		}

		// Token: 0x0603DC06 RID: 252934 RVA: 0x00FBB272 File Offset: 0x00FB9472
		private void RemoveTimer()
		{
			if (this.TimerId != null)
			{
				TimerSystem.Instance.Remove(this.TimerId);
				this.TimerId = null;
			}
		}

		// Token: 0x04022A47 RID: 141895
		private const int DEFAULT_DURATION = 1000;

		// Token: 0x04022A48 RID: 141896
		public UUINiagara Item;

		// Token: 0x04022A49 RID: 141897
		public float Duration;

		// Token: 0x04022A4A RID: 141898
		[Nullable(2)]
		private TimerHandle TimerId;
	}
}
