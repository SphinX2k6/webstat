using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Audio;
using UnrealEngine;

// Token: 0x0200002C RID: 44
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class AudioModel : ModelBase<AudioModel>
{
	// Token: 0x060000B7 RID: 183 RVA: 0x00005F4C File Offset: 0x0000414C
	public AActor GetSpectrumActor()
	{
		if (this.SpectrumActor == null)
		{
			this.SpectrumActor = Singleton<ActorSystem>.Instance.Get(BP_Wwise_AudioSpectrum_C.StaticClass(), Singleton<MathUtils>.Instance.DefaultTransformDouble, null, true);
		}
		return this.SpectrumActor;
	}

	// Token: 0x060000B8 RID: 184 RVA: 0x00005F7D File Offset: 0x0000417D
	public void DestroySpectrumActor()
	{
		if (this.SpectrumActor != null)
		{
			Singleton<ActorSystem>.Instance.Put("AudioModel.DestroySpectrumActor", this.SpectrumActor, null);
			this.SpectrumActor = null;
		}
	}

	// Token: 0x060000B9 RID: 185 RVA: 0x00005FA8 File Offset: 0x000041A8
	protected override bool OnInit()
	{
		Comparison<AudioBox> compare;
		if ((compare = AudioModel.<>O.<0>__Compare) == null)
		{
			compare = (AudioModel.<>O.<0>__Compare = new Comparison<AudioBox>(AudioBox.Compare));
		}
		this.AmbientAudioQueue = new PriorityQueue<AudioBox>(compare);
		Comparison<AudioBox> compare2;
		if ((compare2 = AudioModel.<>O.<0>__Compare) == null)
		{
			compare2 = (AudioModel.<>O.<0>__Compare = new Comparison<AudioBox>(AudioBox.Compare));
		}
		this.BGMAudioQueue = new PriorityQueue<AudioBox>(compare2);
		return true;
	}

	// Token: 0x060000BA RID: 186 RVA: 0x00006002 File Offset: 0x00004202
	protected override bool OnClear()
	{
		this.AmbientAudioQueue = null;
		this.BGMAudioQueue = null;
		return true;
	}

	// Token: 0x060000BB RID: 187 RVA: 0x00006014 File Offset: 0x00004214
	[return: Nullable(2)]
	public AudioBox UpdateAudioBoxQueue(AudioBox item, EAudioUpdateType type)
	{
		AudioBox audioBox = null;
		EAudioBoxType boxType = item.BoxType;
		PriorityQueue<AudioBox> priorityQueue;
		if (boxType != EAudioBoxType.AMB)
		{
			if (boxType != EAudioBoxType.BGM)
			{
				return null;
			}
			if (this.BGMAudioQueue != null && !this.BGMAudioQueue.Empty)
			{
				audioBox = this.BGMAudioQueue.Top;
			}
			priorityQueue = this.BGMAudioQueue;
		}
		else
		{
			if (this.AmbientAudioQueue != null && !this.AmbientAudioQueue.Empty)
			{
				audioBox = this.AmbientAudioQueue.Top;
			}
			priorityQueue = this.AmbientAudioQueue;
		}
		bool flag = audioBox == item;
		switch (type)
		{
		case EAudioUpdateType.Enter:
			priorityQueue.Push(item);
			if (priorityQueue.Top == item)
			{
				return priorityQueue.Top;
			}
			break;
		case EAudioUpdateType.Leave:
			priorityQueue.Remove(item);
			if (flag && !priorityQueue.Empty)
			{
				return priorityQueue.Top;
			}
			break;
		case EAudioUpdateType.StateUpdate:
			if (flag)
			{
				return priorityQueue.Top;
			}
			break;
		default:
			return null;
		}
		return null;
	}

	// Token: 0x0400008F RID: 143
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private PriorityQueue<AudioBox> AmbientAudioQueue;

	// Token: 0x04000090 RID: 144
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private PriorityQueue<AudioBox> BGMAudioQueue;

	// Token: 0x04000091 RID: 145
	[Nullable(2)]
	private AActor SpectrumActor;

	// Token: 0x0200716F RID: 29039
	[CompilerGenerated]
	private static class <>O
	{
		// Token: 0x04027881 RID: 161921
		[Nullable(new byte[]
		{
			0,
			1
		})]
		public static Comparison<AudioBox> <0>__Compare;
	}
}
