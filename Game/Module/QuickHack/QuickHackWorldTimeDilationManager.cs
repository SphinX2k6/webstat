using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Camera;

namespace CSharpScript.Game.Module.QuickHack
{
	// Token: 0x020052FC RID: 21244
	public class QuickHackWorldTimeDilationManager : IQuickHackTimeScaleManager
	{
		// Token: 0x060363A6 RID: 222118 RVA: 0x00DAA250 File Offset: 0x00DA8450
		public void BeginTimeScale(QuickHackDevice config, int ownerEntityId)
		{
			int timeScaleDuration = config.TimeScaleDuration;
			if (timeScaleDuration == 0)
			{
				return;
			}
			float num = Singleton<MathUtils>.Instance.Clamp(config.TimeDilation, 0f, 1f);
			if (num >= 1f)
			{
				return;
			}
			this.IsChangeTimeScale = true;
			ControllerBase<GameModeController>.Instance.SetTimeDilation(num, ETimeDilationType.QuickHack);
			ControllerBase<CameraController>.Instance.SetTimeDilation(1f, "MainCamera");
			if (timeScaleDuration > 0)
			{
				this.TimerHandle = TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
				{
					this.TimerHandle = null;
					this.EndInternal();
				}, (float)timeScaleDuration, null, null, true, 1f);
			}
		}

		// Token: 0x060363A7 RID: 222119 RVA: 0x00DAA2DF File Offset: 0x00DA84DF
		public void EndTimeScale()
		{
			TimerHandle timerHandle = this.TimerHandle;
			if (timerHandle != null)
			{
				timerHandle.Remove();
			}
			this.TimerHandle = null;
			this.EndInternal();
		}

		// Token: 0x060363A8 RID: 222120 RVA: 0x00DAA300 File Offset: 0x00DA8500
		private void EndInternal()
		{
			if (this.IsChangeTimeScale)
			{
				ControllerBase<GameModeController>.Instance.SetTimeDilation(1f, ETimeDilationType.QuickHack);
				this.IsChangeTimeScale = false;
			}
		}

		// Token: 0x0401F2E2 RID: 127714
		private bool IsChangeTimeScale;

		// Token: 0x0401F2E3 RID: 127715
		[Nullable(2)]
		private TimerHandle TimerHandle;
	}
}
