using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Plot.PlotView.PlotComponent
{
	// Token: 0x020053DD RID: 21469
	[NullableContext(2)]
	[Nullable(0)]
	public sealed class PlotAutoPlayComponent
	{
		// Token: 0x06036CD3 RID: 224467 RVA: 0x00DE6AC8 File Offset: 0x00DE4CC8
		[NullableContext(1)]
		public void Init(IPlotAutoPlayComponentContext context)
		{
			this.Toggle = context.Toggle;
			this.WaitTime = context.WaitTime;
			this.CheckTalkFinishedDelegate = context.CheckTalkFinishedDelegate;
			this.ContinueToNextTalkDelegate = context.ContinueToNextTalkDelegate;
			this.Toggle.OnStateChange.Add(new Action<EToggleState>(this.OnToggleStateChange));
			this.UpdateAutoPlayToggle();
		}

		// Token: 0x06036CD4 RID: 224468 RVA: 0x00DE6B27 File Offset: 0x00DE4D27
		private void OnToggleStateChange(EToggleState state)
		{
			this.ChangeAutoPlay(state == EToggleState.ETT_Checked);
		}

		// Token: 0x06036CD5 RID: 224469 RVA: 0x00DE6B34 File Offset: 0x00DE4D34
		public void ChangeAutoPlay(bool isAutoPlay)
		{
			PlotConfig plotConfig = ModelBase<PlotModel>.Instance.PlotConfig;
			if (plotConfig.AutoPlayState > EAutoPlayState.Manual == isAutoPlay)
			{
				return;
			}
			plotConfig.AutoPlayState = (isAutoPlay ? EAutoPlayState.SemiAuto : EAutoPlayState.Manual);
			plotConfig.AutoPlayStateCache = plotConfig.AutoPlayState;
			this.UpdateAutoPlayToggle();
			bool flag = this.IsTalkFinished();
			if (isAutoPlay)
			{
				if (flag)
				{
					Action continueToNextTalkDelegate = this.ContinueToNextTalkDelegate;
					if (continueToNextTalkDelegate == null)
					{
						return;
					}
					continueToNextTalkDelegate();
					return;
				}
			}
			else
			{
				this.RemoveDelayTimer();
			}
		}

		// Token: 0x06036CD6 RID: 224470 RVA: 0x00DE6B9C File Offset: 0x00DE4D9C
		public void UpdateAutoPlayToggle()
		{
			EToggleState state = (ModelBase<PlotModel>.Instance.PlotConfig.AutoPlayState > EAutoPlayState.Manual) ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
			this.Toggle.SetToggleState(state, false, false, false);
		}

		// Token: 0x06036CD7 RID: 224471 RVA: 0x00DE6BD4 File Offset: 0x00DE4DD4
		public void MuteAutoPlay(bool isMute)
		{
			if (isMute)
			{
				ModelBase<PlotModel>.Instance.PlotConfig.AutoPlayState = EAutoPlayState.Manual;
				this.RemoveDelayTimer();
				this.UpdateAutoPlayToggle();
				return;
			}
			PlotConfig plotConfig = ModelBase<PlotModel>.Instance.PlotConfig;
			plotConfig.AutoPlayState = plotConfig.AutoPlayStateCache;
			this.UpdateAutoPlayToggle();
			if (plotConfig.AutoPlayState != EAutoPlayState.Manual && this.IsTalkFinished())
			{
				Action continueToNextTalkDelegate = this.ContinueToNextTalkDelegate;
				if (continueToNextTalkDelegate == null)
				{
					return;
				}
				continueToNextTalkDelegate();
			}
		}

		// Token: 0x06036CD8 RID: 224472 RVA: 0x00DE6C3C File Offset: 0x00DE4E3C
		public bool TryDelayPlayNextTalk()
		{
			if (!this.GetIsAutoPlay())
			{
				return false;
			}
			if (!this.IsTalkFinished())
			{
				return false;
			}
			this.DelayPlayNextTalk();
			return true;
		}

		// Token: 0x06036CD9 RID: 224473 RVA: 0x00DE6C59 File Offset: 0x00DE4E59
		private void DelayPlayNextTalk()
		{
			this.RemoveDelayTimer();
			this.DelayTimer = TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
			{
				this.RemoveDelayTimer();
				Action continueToNextTalkDelegate = this.ContinueToNextTalkDelegate;
				if (continueToNextTalkDelegate == null)
				{
					return;
				}
				continueToNextTalkDelegate();
			}, this.WaitTime, null, null, true, 1f);
		}

		// Token: 0x06036CDA RID: 224474 RVA: 0x00DE6C8B File Offset: 0x00DE4E8B
		private void RemoveDelayTimer()
		{
			if (this.DelayTimer != null)
			{
				TimerSystem.GameplayTimeInstance.Remove(this.DelayTimer);
				this.DelayTimer = null;
			}
		}

		// Token: 0x06036CDB RID: 224475 RVA: 0x00DE6CAD File Offset: 0x00DE4EAD
		public void Clear()
		{
			this.RemoveDelayTimer();
			this.CheckTalkFinishedDelegate = null;
			this.ContinueToNextTalkDelegate = null;
		}

		// Token: 0x06036CDC RID: 224476 RVA: 0x00DE6CC4 File Offset: 0x00DE4EC4
		public void SetToggleActive(bool active)
		{
			UUIExtendToggle toggle = this.Toggle;
			if (toggle == null)
			{
				return;
			}
			UUIItem uuiitem = toggle.RootUIComp.Get();
			if (uuiitem == null)
			{
				return;
			}
			uuiitem.SetUIActive(active);
		}

		// Token: 0x06036CDD RID: 224477 RVA: 0x00DE6CF4 File Offset: 0x00DE4EF4
		public bool IsTalkFinished()
		{
			return this.CheckTalkFinishedDelegate != null && this.CheckTalkFinishedDelegate();
		}

		// Token: 0x06036CDE RID: 224478 RVA: 0x00DE6D0B File Offset: 0x00DE4F0B
		public bool GetIsAutoPlay()
		{
			return ModelBase<PlotModel>.Instance.PlotConfig.AutoPlayState > EAutoPlayState.Manual;
		}

		// Token: 0x0401F8EC RID: 129260
		private UUIExtendToggle Toggle;

		// Token: 0x0401F8ED RID: 129261
		private TimerHandle DelayTimer;

		// Token: 0x0401F8EE RID: 129262
		private float WaitTime;

		// Token: 0x0401F8EF RID: 129263
		private Func<bool> CheckTalkFinishedDelegate;

		// Token: 0x0401F8F0 RID: 129264
		private Action ContinueToNextTalkDelegate;
	}
}
