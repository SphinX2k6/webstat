using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x0200602A RID: 24618
	[NullableContext(1)]
	[Nullable(0)]
	public class FallDownBarStateMachine
	{
		// Token: 0x0603E112 RID: 254226 RVA: 0x00FD7667 File Offset: 0x00FD5867
		public FallDownBarStateMachine(Action<float> fallDownChangeFunction)
		{
		}

		// Token: 0x0603E113 RID: 254227 RVA: 0x00FD7684 File Offset: 0x00FD5884
		public void Update(float delta)
		{
			if (!this.IsEnable)
			{
				return;
			}
			this.CurrentDuration += delta * this.TimeDilation;
			float obj = this.CurrentDuration / this.Duration;
			this.<fallDownChangeFunction>P(obj);
		}

		// Token: 0x0603E114 RID: 254228 RVA: 0x00FD76C9 File Offset: 0x00FD58C9
		public void OnFallDownStart(float duration)
		{
			this.Duration = duration * (float)Singleton<TimeUtil>.Instance.InverseMillisecond;
			this.CurrentDuration = 0f;
			this.IsEnable = true;
		}

		// Token: 0x0603E115 RID: 254229 RVA: 0x00FD76F0 File Offset: 0x00FD58F0
		public void OnChangeTimeDilation(float timeDilation)
		{
			this.TimeDilation = timeDilation;
		}

		// Token: 0x0603E116 RID: 254230 RVA: 0x00FD76F9 File Offset: 0x00FD58F9
		public void OnFallDownEnd()
		{
			this.IsEnable = false;
		}

		// Token: 0x0603E117 RID: 254231 RVA: 0x00FD7702 File Offset: 0x00FD5902
		public void OnDestroy()
		{
			this.IsEnable = false;
			this.TimeDilation = 1f;
		}

		// Token: 0x04022CA7 RID: 142503
		[CompilerGenerated]
		private Action<float> <fallDownChangeFunction>P = fallDownChangeFunction;

		// Token: 0x04022CA8 RID: 142504
		private float Duration;

		// Token: 0x04022CA9 RID: 142505
		private float CurrentDuration;

		// Token: 0x04022CAA RID: 142506
		private float TimeDilation = 1f;

		// Token: 0x04022CAB RID: 142507
		private bool IsEnable;
	}
}
