using System;
using System.Runtime.CompilerServices;

// Token: 0x02000BEB RID: 3051
public class TimerHandle : IStaticVariableResetter
{
	// Token: 0x0600325C RID: 12892 RVA: 0x000225B5 File Offset: 0x000207B5
	static TimerHandle()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(TimerHandle.CreateStaticDefaultValue), new Action(TimerHandle.ResetStaticDefaultValue));
	}

	// Token: 0x0600325D RID: 12893 RVA: 0x000225D4 File Offset: 0x000207D4
	public static void CreateStaticDefaultValue()
	{
		TimerHandle.Increment = 0;
	}

	// Token: 0x0600325E RID: 12894 RVA: 0x000225DC File Offset: 0x000207DC
	public static void ResetStaticDefaultValue()
	{
		TimerHandle.Increment = 0;
	}

	// Token: 0x0600325F RID: 12895 RVA: 0x000225E4 File Offset: 0x000207E4
	[NullableContext(1)]
	public TimerHandle(TimerSystemInstance instance)
	{
		this.Instance = instance;
		this.Id = ++TimerHandle.Increment;
	}

	// Token: 0x06003260 RID: 12896 RVA: 0x00022606 File Offset: 0x00020806
	public bool Valid()
	{
		TimerSystemInstance instance = this.Instance;
		return instance != null && instance.Has(this);
	}

	// Token: 0x06003261 RID: 12897 RVA: 0x0002261A File Offset: 0x0002081A
	public bool Remove()
	{
		TimerSystemInstance instance = this.Instance;
		return instance != null && instance.Remove(this);
	}

	// Token: 0x06003262 RID: 12898 RVA: 0x0002262E File Offset: 0x0002082E
	[NullableContext(2)]
	public void PendingRemove_FinalizerThread(string reason)
	{
		TimerSystemInstance instance = this.Instance;
		if (instance == null)
		{
			return;
		}
		instance.PendingRemove_FinalizerThread(this, reason);
	}

	// Token: 0x06003263 RID: 12899 RVA: 0x00022642 File Offset: 0x00020842
	public bool IsPause()
	{
		TimerSystemInstance instance = this.Instance;
		return instance != null && instance.IsPause(this);
	}

	// Token: 0x06003264 RID: 12900 RVA: 0x00022656 File Offset: 0x00020856
	public bool Pause()
	{
		TimerSystemInstance instance = this.Instance;
		return instance != null && instance.Pause(this, null);
	}

	// Token: 0x06003265 RID: 12901 RVA: 0x0002266B File Offset: 0x0002086B
	public bool Resume()
	{
		TimerSystemInstance instance = this.Instance;
		return instance != null && instance.Resume(this);
	}

	// Token: 0x06003266 RID: 12902 RVA: 0x0002267F File Offset: 0x0002087F
	public bool ChangeDilation(float dilation)
	{
		TimerSystemInstance instance = this.Instance;
		return instance != null && instance.ChangeDilation(this, dilation, null);
	}

	// Token: 0x04000536 RID: 1334
	public readonly int Id;

	// Token: 0x04000537 RID: 1335
	private static int Increment;

	// Token: 0x04000538 RID: 1336
	[Nullable(2)]
	private readonly TimerSystemInstance Instance;
}
