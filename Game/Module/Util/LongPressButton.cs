using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Util
{
	// Token: 0x02004C66 RID: 19558
	[NullableContext(2)]
	[Nullable(0)]
	public class LongPressButton
	{
		// Token: 0x06032F78 RID: 208760 RVA: 0x00CC3E58 File Offset: 0x00CC2058
		[NullableContext(1)]
		public LongPressButton(UUIButtonComponent button, Action<float> tickFn, int interval = 100)
		{
			button.OnPointDownCallBack.Bind(new Action(this.StartClick));
			button.OnPointUpCallBack.Bind(new Action(this.EndClick));
			button.OnPointExitCallBack.Bind(new Action(this.EndClick));
			this.Button = button;
			this.TimerId = TimerSystem.GameplayTimeInstance.Forever(new TTimerAction(tickFn.Invoke), (float)interval, 1f, null, null, true);
			TimerSystem.GameplayTimeInstance.Pause(this.TimerId, null);
		}

		// Token: 0x06032F79 RID: 208761 RVA: 0x00CC3EEF File Offset: 0x00CC20EF
		private void StartClick()
		{
			TimerSystem.GameplayTimeInstance.Resume(this.TimerId);
		}

		// Token: 0x06032F7A RID: 208762 RVA: 0x00CC3F02 File Offset: 0x00CC2102
		private void EndClick()
		{
			if (TimerSystem.GameplayTimeInstance.IsPause(this.TimerId))
			{
				return;
			}
			TimerSystem.GameplayTimeInstance.Pause(this.TimerId, null);
		}

		// Token: 0x06032F7B RID: 208763 RVA: 0x00CC3F29 File Offset: 0x00CC2129
		public void OnDestroy()
		{
			this.Button.OnPointDownCallBack.Unbind();
			this.Button.OnPointUpCallBack.Unbind();
			TimerSystem.GameplayTimeInstance.Remove(this.TimerId);
		}

		// Token: 0x0401DA7C RID: 121468
		private const int SECOND_0_1 = 100;

		// Token: 0x0401DA7D RID: 121469
		private readonly TimerHandle TimerId;

		// Token: 0x0401DA7E RID: 121470
		private readonly UUIButtonComponent Button;
	}
}
