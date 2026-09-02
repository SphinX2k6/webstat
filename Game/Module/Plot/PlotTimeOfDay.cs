using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

namespace CSharpScript.Game.Module.Plot
{
	// Token: 0x0200537A RID: 21370
	public class PlotTimeOfDay
	{
		// Token: 0x06036810 RID: 223248 RVA: 0x00DC6024 File Offset: 0x00DC4224
		public void OnPlotStart(bool pauseTime)
		{
			if (this.IsPauseConfig)
			{
				return;
			}
			this.IsPauseConfig = pauseTime;
			if (!pauseTime)
			{
				return;
			}
			this.IsPauseInPlot = true;
			this.NeedResetTime = ModelBase<TimeOfDayModel>.Instance.TimeRunLockState;
			ModelBase<TimeOfDayModel>.Instance.SetUseClientLockState(true);
			ModelBase<TimeOfDayModel>.Instance.SetTimeRunLockStateClient(true, true);
			ModelBase<TimeOfDayModel>.Instance.SetTimeSyncLockStateClient(true, true);
			this.CachePrePlotTime = (int)ModelBase<TimeOfDayModel>.Instance.GameTime.Second;
		}

		// Token: 0x06036811 RID: 223249 RVA: 0x00DC6095 File Offset: 0x00DC4295
		public void OnSeqStart()
		{
			this.StopTween();
			this.CachePreSeqTime = (int)ModelBase<TimeOfDayModel>.Instance.GameTime.Second;
			this.IsInherit = false;
		}

		// Token: 0x06036812 RID: 223250 RVA: 0x00DC60BC File Offset: 0x00DC42BC
		public void OnSeqEnd()
		{
			this.StopTween();
			ModelBase<TimeOfDayModel>.Instance.SetTimeRunLockStateClient(this.IsPauseInPlot, true);
			if (this.IsInherit && this.CachePreSeqTime != 0 && Math.Abs((double)this.CachePreSeqTime - ModelBase<TimeOfDayModel>.Instance.GameTime.Second) > 9.99999993922529E-09)
			{
				ControllerBase<TimeOfDayController>.Instance.AdjustTime((double)this.CachePreSeqTime, SceneDateUpdateReason.LevelPlayAuto, 0U, true);
			}
			this.IsInherit = false;
			this.CachePreSeqTime = 0;
		}

		// Token: 0x06036813 RID: 223251 RVA: 0x00DC613C File Offset: 0x00DC433C
		public void OnPlotEnd()
		{
			if (!this.IsPauseConfig)
			{
				return;
			}
			ModelBase<TimeOfDayModel>.Instance.SetUseClientLockState(false);
			ModelBase<TimeOfDayModel>.Instance.SetTimeRunLockStateClient(false, true);
			ModelBase<TimeOfDayModel>.Instance.SetTimeSyncLockStateClient(false, true);
			if (this.NeedResetTime && Math.Abs((double)this.CachePrePlotTime - ModelBase<TimeOfDayModel>.Instance.GameTime.Second) > 9.99999993922529E-09)
			{
				ControllerBase<TimeOfDayController>.Instance.AdjustTime((double)this.CachePrePlotTime, SceneDateUpdateReason.LevelPlayAuto, 0U, true);
			}
			this.CachePrePlotTime = 0;
			this.IsPauseConfig = false;
			this.IsPauseInPlot = false;
		}

		// Token: 0x06036814 RID: 223252 RVA: 0x00DC61D0 File Offset: 0x00DC43D0
		public void PauseTime()
		{
			if (this.IsPauseInPlot)
			{
				return;
			}
			ModelBase<TimeOfDayModel>.Instance.SetTimeRunLockStateClient(true, true);
			this.IsPauseInPlot = true;
			Singleton<Log>.Instance.Info(ELogModule.TimeOfDay, ELogAuthor.FZX, "[TimeRunLockState] 剧情行为锁定时间", default(ReadOnlySpan<ValueTuple<string, object>>));
		}

		// Token: 0x06036815 RID: 223253 RVA: 0x00DC6218 File Offset: 0x00DC4418
		public void ResumeTime()
		{
			if (!this.IsPauseInPlot)
			{
				return;
			}
			ModelBase<TimeOfDayModel>.Instance.SetTimeRunLockStateClient(false, true);
			Singleton<Log>.Instance.Info(ELogModule.TimeOfDay, ELogAuthor.FZX, "[TimeRunLockState] 剧情行为解锁时间", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.IsPauseInPlot = false;
		}

		// Token: 0x06036816 RID: 223254 RVA: 0x00DC625D File Offset: 0x00DC445D
		public void SetTime(int second)
		{
			ControllerBase<TimeOfDayController>.Instance.AdjustTime((double)second, SceneDateUpdateReason.LevelPlayAuto, 0U, true);
		}

		// Token: 0x06036817 RID: 223255 RVA: 0x00DC6270 File Offset: 0x00DC4470
		public void SetTimeDuration(bool isInherit, int startSecond, int endSecond, int tweenSecond)
		{
			this.StopTween();
			this.IsInherit = isInherit;
			int num = startSecond;
			if (num > 86400)
			{
				num = 0;
			}
			if (tweenSecond <= 0)
			{
				ControllerBase<TimeOfDayController>.Instance.AdjustTime((double)num, SceneDateUpdateReason.LevelPlayAuto, 0U, true);
				return;
			}
			int num2 = endSecond;
			if (num2 > 86400)
			{
				num2 = 0;
			}
			if (num2 < num)
			{
				num2 += 86400;
			}
			double num3 = TodDayTime.ConvertFromRealTimeSecond((double)tweenSecond);
			double num4 = 1.0;
			if (num3 > 0.0)
			{
				num4 = (double)(num2 - num) / num3;
			}
			ModelBase<TimeOfDayModel>.Instance.SetTimeRunLockStateClient(false, true);
			Singleton<Log>.Instance.Info(ELogModule.TimeOfDay, ELogAuthor.FZX, "[TimeRunLockState] Seq解锁时间", default(ReadOnlySpan<ValueTuple<string, object>>));
			ControllerBase<TimeOfDayController>.Instance.AdjustTime((double)num, SceneDateUpdateReason.LevelPlayAuto, 0U, true);
			ControllerBase<TimeOfDayController>.Instance.ChangeTimeScale((float)num4);
			this.TimerId = TimerSystem.Instance.Delay(delegate(float _)
			{
				ControllerBase<TimeOfDayController>.Instance.AdjustTime((double)endSecond, SceneDateUpdateReason.LevelPlayAuto, 0U, true);
				this.TimerId = null;
				ControllerBase<TimeOfDayController>.Instance.ResumeTimeScale(true);
				ModelBase<TimeOfDayModel>.Instance.SetTimeRunLockStateClient(this.IsPauseInPlot, true);
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.TimeOfDay;
				ELogAuthor author = ELogAuthor.FZX;
				string message = "[TimeRunLockState] Seq恢复时间锁定";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("IsPauseInPlot", this.IsPauseInPlot);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}, (float)(tweenSecond * Singleton<TimeUtil>.Instance.InverseMillisecond), null, null, true, 1f);
		}

		// Token: 0x06036818 RID: 223256 RVA: 0x00DC637B File Offset: 0x00DC457B
		private void StopTween()
		{
			if (this.TimerId != null)
			{
				if (TimerSystem.Instance.Has(this.TimerId))
				{
					TimerSystem.Instance.Remove(this.TimerId);
				}
				ControllerBase<TimeOfDayController>.Instance.ResumeTimeScale(true);
				this.TimerId = null;
			}
		}

		// Token: 0x0401F623 RID: 128547
		private bool IsPauseInPlot;

		// Token: 0x0401F624 RID: 128548
		private bool IsPauseConfig;

		// Token: 0x0401F625 RID: 128549
		private bool IsInherit;

		// Token: 0x0401F626 RID: 128550
		private int CachePrePlotTime;

		// Token: 0x0401F627 RID: 128551
		private int CachePreSeqTime;

		// Token: 0x0401F628 RID: 128552
		private bool NeedResetTime;

		// Token: 0x0401F629 RID: 128553
		[Nullable(2)]
		private TimerHandle TimerId;
	}
}
