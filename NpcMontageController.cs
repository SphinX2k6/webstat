using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x020031C0 RID: 12736
[NullableContext(2)]
[Nullable(0)]
public class NpcMontageController
{
	// Token: 0x0601A68B RID: 108171 RVA: 0x007CA284 File Offset: 0x007C8484
	[NullableContext(1)]
	public NpcMontageController(Entity entity)
	{
		this.Entity = entity;
		this.AnimComp = this.Entity.GetComponent<BaseAnimationComponent>();
	}

	// Token: 0x0601A68C RID: 108172 RVA: 0x007CA2A4 File Offset: 0x007C84A4
	[NullableContext(1)]
	public int LoadAsync(string path, [Nullable(new byte[]
	{
		1,
		2,
		1
	})] Action<UAnimMontage, string> callback)
	{
		throw new NotImplementedException();
	}

	// Token: 0x0601A68D RID: 108173 RVA: 0x007CA2AB File Offset: 0x007C84AB
	[NullableContext(1)]
	public void Play(UAnimMontage asset, [Nullable(2)] Action<UAnimMontage, bool> onEnded = null)
	{
		this.AnimComp.MainAnimInstance.Montage_Play(asset, 1f, EMontagePlayReturnType.MontageLength, 0f, true);
		if (onEnded != null)
		{
			this.AnimComp.MainAnimInstance.OnMontageEnded.Add(onEnded);
		}
	}

	// Token: 0x0601A68E RID: 108174 RVA: 0x007CA2E4 File Offset: 0x007C84E4
	public void PlayOnce(UAnimMontage asset, Action<UAnimMontage, bool> onEnded = null)
	{
		this.AnimComp.MainAnimInstance.Montage_Play(asset, 1f, EMontagePlayReturnType.MontageLength, 0f, true);
		this.AnimComp.MainAnimInstance.Montage_SetNextSection(Singleton<CharacterNameDefines>.Instance.LOOP_SECTION, Singleton<CharacterNameDefines>.Instance.END_SECTION, asset);
		if (onEnded != null)
		{
			this.AnimComp.MainAnimInstance.OnMontageEnded.Add(onEnded);
		}
	}

	// Token: 0x0601A68F RID: 108175 RVA: 0x007CA350 File Offset: 0x007C8550
	[NullableContext(1)]
	public void PlayFromLoop(UAnimMontage asset, [Nullable(2)] Action<UAnimMontage, bool> onEnded = null)
	{
		this.AnimComp.MainAnimInstance.Montage_Play(asset, 1f, EMontagePlayReturnType.MontageLength, 0f, true);
		this.AnimComp.MainAnimInstance.Montage_JumpToSection(Singleton<CharacterNameDefines>.Instance.LOOP_SECTION, asset);
		if (onEnded != null)
		{
			this.AnimComp.MainAnimInstance.OnMontageEnded.Add(onEnded);
		}
	}

	// Token: 0x0601A690 RID: 108176 RVA: 0x007CA3B0 File Offset: 0x007C85B0
	[NullableContext(1)]
	public void PlayFromEnd(UAnimMontage asset, [Nullable(2)] Action<UAnimMontage, bool> onEnded = null)
	{
		this.AnimComp.MainAnimInstance.Montage_Play(asset, 1f, EMontagePlayReturnType.MontageLength, 0f, true);
		this.AnimComp.MainAnimInstance.Montage_JumpToSection(Singleton<CharacterNameDefines>.Instance.END_SECTION, asset);
		if (onEnded != null)
		{
			this.AnimComp.MainAnimInstance.OnMontageEnded.Add(onEnded);
		}
	}

	// Token: 0x0601A691 RID: 108177 RVA: 0x007CA410 File Offset: 0x007C8610
	public void Stop(bool immediately = false, UAnimMontage asset = null)
	{
		if (immediately)
		{
			this.AnimComp.MainAnimInstance.Montage_JumpToSection(Singleton<CharacterNameDefines>.Instance.END_SECTION, asset);
			return;
		}
		this.AnimComp.MainAnimInstance.Montage_SetNextSection(Singleton<CharacterNameDefines>.Instance.LOOP_SECTION, Singleton<CharacterNameDefines>.Instance.END_SECTION, asset);
	}

	// Token: 0x0601A692 RID: 108178 RVA: 0x007CA461 File Offset: 0x007C8661
	public void ForceStop(float? blendOutTime = null, UAnimMontage asset = null)
	{
		this.AnimComp.MainAnimInstance.Montage_Stop(blendOutTime.GetValueOrDefault(), asset);
	}

	// Token: 0x0601A693 RID: 108179 RVA: 0x007CA47B File Offset: 0x007C867B
	[NullableContext(1)]
	public void ForceStopWithBlendOut(float blendOutTime, UAnimMontage asset)
	{
	}

	// Token: 0x0601A694 RID: 108180 RVA: 0x007CA47D File Offset: 0x007C867D
	public void AddOnMontageEnded(Action<UAnimMontage, bool> onEnded)
	{
		if (onEnded != null)
		{
			UAnimInstance mainAnimInstance = this.AnimComp.MainAnimInstance;
			if (mainAnimInstance == null)
			{
				return;
			}
			mainAnimInstance.OnMontageEnded.Add(onEnded);
		}
	}

	// Token: 0x0601A695 RID: 108181 RVA: 0x007CA49D File Offset: 0x007C869D
	public void RemoveOnMontageEnded(Action<UAnimMontage, bool> onEnded)
	{
		if (onEnded != null)
		{
			UAnimInstance mainAnimInstance = this.AnimComp.MainAnimInstance;
			if (mainAnimInstance == null)
			{
				return;
			}
			mainAnimInstance.OnMontageEnded.Remove(onEnded);
		}
	}

	// Token: 0x0400D522 RID: 54562
	private readonly Entity Entity;

	// Token: 0x0400D523 RID: 54563
	private readonly BaseAnimationComponent AnimComp;
}
