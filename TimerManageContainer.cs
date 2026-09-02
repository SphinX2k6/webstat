using System;
using System.Runtime.CompilerServices;

// Token: 0x0200310B RID: 12555
[NullableContext(2)]
[Nullable(0)]
public class TimerManageContainer
{
	// Token: 0x06019F5B RID: 106331 RVA: 0x007981F0 File Offset: 0x007963F0
	[NullableContext(1)]
	public TimerManageContainer(Action stopCallback)
	{
		this.StopCallback = stopCallback;
	}

	// Token: 0x06019F5C RID: 106332 RVA: 0x00798200 File Offset: 0x00796400
	public void Delay(float delay, bool forceRestart = false)
	{
		if (this.TimerHandle != null && !forceRestart)
		{
			return;
		}
		this.Remove();
		int num = (delay < 20f) ? 20 : ((int)delay);
		this.TimerHandle = TimerSystem.Instance.Delay(new TTimerAction(this.OnStop), (float)num, null, null, true, 1f);
	}

	// Token: 0x06019F5D RID: 106333 RVA: 0x00798255 File Offset: 0x00796455
	public bool Remove()
	{
		if (this.TimerHandle != null && TimerSystem.Instance.Has(this.TimerHandle))
		{
			TimerSystem.Instance.Remove(this.TimerHandle);
			this.TimerHandle = null;
			return true;
		}
		return false;
	}

	// Token: 0x06019F5E RID: 106334 RVA: 0x0079828C File Offset: 0x0079648C
	public void Stop()
	{
		if (this.Remove())
		{
			this.OnStop(0f);
		}
	}

	// Token: 0x06019F5F RID: 106335 RVA: 0x007982A1 File Offset: 0x007964A1
	private void OnStop(float delta)
	{
		this.TimerHandle = null;
		this.StopCallback();
	}

	// Token: 0x0400D027 RID: 53287
	private Action StopCallback;

	// Token: 0x0400D028 RID: 53288
	private TimerHandle TimerHandle;
}
