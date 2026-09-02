using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02000E73 RID: 3699
[NullableContext(2)]
[Nullable(0)]
public class EffectModelInfo : IAudioInfo
{
	// Token: 0x1700065A RID: 1626
	// (get) Token: 0x060059FC RID: 23036 RVA: 0x00160ECB File Offset: 0x0015F0CB
	// (set) Token: 0x060059FD RID: 23037 RVA: 0x00160ED3 File Offset: 0x0015F0D3
	public bool Start { get; set; }

	// Token: 0x060059FE RID: 23038 RVA: 0x00160EDC File Offset: 0x0015F0DC
	[NullableContext(1)]
	public EffectModelInfo(EffectModelAudio model)
	{
		this.Model = model;
		this.Start = false;
	}

	// Token: 0x060059FF RID: 23039 RVA: 0x00160EF2 File Offset: 0x0015F0F2
	public string GetName()
	{
		EffectModelAudio model = this.Model;
		if (model == null)
		{
			return null;
		}
		return model.GetName();
	}

	// Token: 0x06005A00 RID: 23040 RVA: 0x00160F05 File Offset: 0x0015F105
	public string GetAudioEvent()
	{
		EffectModelAudio model = this.Model;
		if (model == null)
		{
			return null;
		}
		UAkAudioEvent audioEvent = model.AudioEvent;
		if (audioEvent == null)
		{
			return null;
		}
		return audioEvent.GetName();
	}

	// Token: 0x06005A01 RID: 23041 RVA: 0x00160F23 File Offset: 0x0015F123
	public bool IsValid()
	{
		EffectModelAudio model = this.Model;
		return model != null && model.IsValid();
	}

	// Token: 0x06005A02 RID: 23042 RVA: 0x00160F38 File Offset: 0x0015F138
	public bool IsAudioEventValid()
	{
		EffectModelAudio model = this.Model;
		bool? flag;
		if (model == null)
		{
			flag = null;
		}
		else
		{
			UAkAudioEvent audioEvent = model.AudioEvent;
			flag = ((audioEvent != null) ? new bool?(audioEvent.IsValid()) : null);
		}
		bool? flag2 = flag;
		return flag2.GetValueOrDefault();
	}

	// Token: 0x06005A03 RID: 23043 RVA: 0x00160F80 File Offset: 0x0015F180
	[NullableContext(1)]
	public object GetCompare()
	{
		return this.Model;
	}

	// Token: 0x040029B7 RID: 10679
	public EffectModelAudio Model;
}
