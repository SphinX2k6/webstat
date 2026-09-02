using System;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.QuickHack
{
	// Token: 0x020052FA RID: 21242
	public class QuickHackAbsoluteTimeStopManager : IQuickHackTimeScaleManager
	{
		// Token: 0x0603639F RID: 222111 RVA: 0x00DAA180 File Offset: 0x00DA8380
		public void BeginTimeScale(QuickHackDevice config, int ownerEntityId)
		{
			int timeScaleDuration = config.TimeScaleDuration;
			if (timeScaleDuration <= 0)
			{
				return;
			}
			float timeDilation = config.TimeDilation;
			if (timeDilation >= 1f)
			{
				return;
			}
			this.OwnerEntityId = ownerEntityId;
			float duration = (float)timeScaleDuration * 0.001f;
			SkillUtils.BeginAbsoluteTimeStop(ownerEntityId, duration, true, timeDilation);
			SkillUtils.BeginTimeStopRequest(ownerEntityId, duration, 0f);
			this.TimerHandle = TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
			{
				this.TimerHandle = null;
				this.EndTimeScaleInternal();
			}, (float)timeScaleDuration, null, null, true, 1f);
		}

		// Token: 0x060363A0 RID: 222112 RVA: 0x00DAA1F6 File Offset: 0x00DA83F6
		public void EndTimeScale()
		{
			TimerHandle timerHandle = this.TimerHandle;
			if (timerHandle != null)
			{
				timerHandle.Remove();
			}
			this.TimerHandle = null;
			this.EndTimeScaleInternal();
		}

		// Token: 0x060363A1 RID: 222113 RVA: 0x00DAA217 File Offset: 0x00DA8417
		private void EndTimeScaleInternal()
		{
			if (this.OwnerEntityId != 0)
			{
				SkillUtils.EndAbsoluteTimeStop(this.OwnerEntityId);
				SkillUtils.EndTimeStopRequest(this.OwnerEntityId);
			}
		}

		// Token: 0x0401F2E0 RID: 127712
		private int OwnerEntityId;

		// Token: 0x0401F2E1 RID: 127713
		[Nullable(2)]
		private TimerHandle TimerHandle;
	}
}
