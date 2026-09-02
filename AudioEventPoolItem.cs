using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02000023 RID: 35
[NullableContext(2)]
[Nullable(0)]
public class AudioEventPoolItem
{
	// Token: 0x0600009B RID: 155 RVA: 0x00005870 File Offset: 0x00003A70
	[NullableContext(1)]
	public AudioEventPoolItem(UAkAudioEvent @event, long? time = null)
	{
		this.AudioEvent = @event;
		long? num = time;
		this.LastActiveTime = ((num != null) ? ((double)num.GetValueOrDefault()) : Singleton<Time>.Instance.Now);
	}

	// Token: 0x0600009C RID: 156 RVA: 0x000058AF File Offset: 0x00003AAF
	public void UpdateEvent(UAkAudioEvent @event)
	{
		if (@event != null)
		{
			this.AudioEvent = @event;
		}
		this.LastActiveTime = Singleton<Time>.Instance.Now;
	}

	// Token: 0x0600009D RID: 157 RVA: 0x000058CB File Offset: 0x00003ACB
	public void Destroy()
	{
		if (this.AudioEvent != null)
		{
			this.AudioEvent = null;
		}
	}

	// Token: 0x04000071 RID: 113
	public UAkAudioEvent AudioEvent;

	// Token: 0x04000072 RID: 114
	public double LastActiveTime;
}
