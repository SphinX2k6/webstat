using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02006111 RID: 24849
	[NullableContext(2)]
	[Nullable(0)]
	public class VisibleAnimMachine
	{
		// Token: 0x0603EC4F RID: 257103 RVA: 0x01012F29 File Offset: 0x01011129
		public void InitCallback(Action<bool> visibleCallback, Action<bool> playAnimCallback, Action<bool> stopAnimCallback)
		{
			this.VisibleCallback = visibleCallback;
			this.PlayAnimCallback = playAnimCallback;
			this.StopAnimCallback = stopAnimCallback;
		}

		// Token: 0x0603EC50 RID: 257104 RVA: 0x01012F40 File Offset: 0x01011140
		public void InitVisible(bool value)
		{
			this.Visible = value;
			if (value)
			{
				this.State = 1;
				return;
			}
			this.State = 0;
		}

		// Token: 0x0603EC51 RID: 257105 RVA: 0x01012F5C File Offset: 0x0101115C
		public void SetVisible(bool value, float animTime)
		{
			if (this.Visible == value)
			{
				return;
			}
			this.Visible = value;
			Action<bool> stopAnimCallback = this.StopAnimCallback;
			if (stopAnimCallback != null)
			{
				stopAnimCallback(!value);
			}
			if (animTime > 0f)
			{
				if (value)
				{
					Action<bool> visibleCallback = this.VisibleCallback;
					if (visibleCallback != null)
					{
						visibleCallback(true);
					}
					this.State = 2;
				}
				else
				{
					this.State = 3;
				}
				Action<bool> playAnimCallback = this.PlayAnimCallback;
				if (playAnimCallback != null)
				{
					playAnimCallback(value);
				}
				this.DestroyTimer();
				this.AnimTimer = TimerSystem.Instance.Delay(new TTimerAction(this.OnAnimFinish), animTime, null, null, true, 1f);
				return;
			}
			if (value)
			{
				this.State = 1;
			}
			else
			{
				this.State = 0;
			}
			Action<bool> visibleCallback2 = this.VisibleCallback;
			if (visibleCallback2 == null)
			{
				return;
			}
			visibleCallback2(value);
		}

		// Token: 0x0603EC52 RID: 257106 RVA: 0x01013020 File Offset: 0x01011220
		public void ForcePlayShowAnim(int animTime)
		{
			if (this.State == 2)
			{
				return;
			}
			if (this.State == 3)
			{
				Action<bool> stopAnimCallback = this.StopAnimCallback;
				if (stopAnimCallback != null)
				{
					stopAnimCallback(false);
				}
			}
			this.State = 2;
			Action<bool> playAnimCallback = this.PlayAnimCallback;
			if (playAnimCallback != null)
			{
				playAnimCallback(true);
			}
			this.DestroyTimer();
			this.AnimTimer = TimerSystem.Instance.Delay(new TTimerAction(this.OnAnimFinish), (float)animTime, null, null, true, 1f);
		}

		// Token: 0x0603EC53 RID: 257107 RVA: 0x01013097 File Offset: 0x01011297
		public void Reset()
		{
			this.DestroyTimer();
		}

		// Token: 0x0603EC54 RID: 257108 RVA: 0x0101309F File Offset: 0x0101129F
		public void Deactivate()
		{
			this.DestroyTimer();
			if (this.State != 3)
			{
				if (this.State == 2)
				{
					Action<bool> stopAnimCallback = this.StopAnimCallback;
					if (stopAnimCallback == null)
					{
						return;
					}
					stopAnimCallback(true);
				}
				return;
			}
			Action<bool> stopAnimCallback2 = this.StopAnimCallback;
			if (stopAnimCallback2 == null)
			{
				return;
			}
			stopAnimCallback2(false);
		}

		// Token: 0x0603EC55 RID: 257109 RVA: 0x010130DC File Offset: 0x010112DC
		private void OnAnimFinish(float _)
		{
			this.AnimTimer = null;
			if (this.State != 3)
			{
				if (this.State == 2)
				{
					this.State = 1;
				}
				return;
			}
			this.State = 0;
			Action<bool> visibleCallback = this.VisibleCallback;
			if (visibleCallback == null)
			{
				return;
			}
			visibleCallback(false);
		}

		// Token: 0x0603EC56 RID: 257110 RVA: 0x01013117 File Offset: 0x01011317
		private void DestroyTimer()
		{
			if (this.AnimTimer != null)
			{
				TimerSystem.Instance.Remove(this.AnimTimer);
				this.AnimTimer = null;
			}
		}

		// Token: 0x04023352 RID: 144210
		public int State;

		// Token: 0x04023353 RID: 144211
		public bool Visible;

		// Token: 0x04023354 RID: 144212
		public Action<bool> VisibleCallback;

		// Token: 0x04023355 RID: 144213
		public Action<bool> PlayAnimCallback;

		// Token: 0x04023356 RID: 144214
		public Action<bool> StopAnimCallback;

		// Token: 0x04023357 RID: 144215
		private TimerHandle AnimTimer;

		// Token: 0x0200C298 RID: 49816
		[NullableContext(0)]
		private enum EVisibleAnimState
		{
			// Token: 0x0403BFE3 RID: 245731
			Hide,
			// Token: 0x0403BFE4 RID: 245732
			Show,
			// Token: 0x0403BFE5 RID: 245733
			ShowAnim,
			// Token: 0x0403BFE6 RID: 245734
			HideAnim
		}
	}
}
