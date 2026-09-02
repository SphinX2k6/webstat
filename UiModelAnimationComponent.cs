using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

// Token: 0x02002C74 RID: 11380
[NullableContext(2)]
[Nullable(0)]
public class UiModelAnimationComponent : UiModelComponentBase
{
	// Token: 0x06016D48 RID: 93512 RVA: 0x0065602F File Offset: 0x0065422F
	protected override void OnInit()
	{
		this.ActorComponent = base.Owner.CheckGetComponent<UiModelActorComponent>();
		this.ModelDataComponent = base.Owner.CheckGetComponent<UiModelDataComponent>();
	}

	// Token: 0x06016D49 RID: 93513 RVA: 0x00656053 File Offset: 0x00654253
	protected override void OnStart()
	{
		Singleton<EventSystem>.Instance.AddWithTarget(base.Owner, EEventName.OnUiModelLoadComplete, new Action(this.OnModelLoadComplete));
	}

	// Token: 0x06016D4A RID: 93514 RVA: 0x00656077 File Offset: 0x00654277
	protected override void OnEnd()
	{
		Singleton<EventSystem>.Instance.RemoveWithTarget(base.Owner, EEventName.OnUiModelLoadComplete, new Action(this.OnModelLoadComplete));
	}

	// Token: 0x06016D4B RID: 93515 RVA: 0x0065609C File Offset: 0x0065429C
	private void OnModelLoadComplete()
	{
		this.UpdateAnimInstance();
		if (this.MontageWaitToPlay != null)
		{
			this.PlayMontage(this.MontageWaitToPlay);
			this.MontageWaitToPlay = null;
		}
		if (this.AnimationWaitToPlay != null)
		{
			this.PlayAnimation(this.AnimationWaitToPlay, this.IsAnimationLoop);
			this.AnimationWaitToPlay = null;
		}
		if (this.AnimationMode != null)
		{
			this.SetAnimationMode(this.AnimationMode.Value);
			this.AnimationMode = null;
		}
	}

	// Token: 0x06016D4C RID: 93516 RVA: 0x00656118 File Offset: 0x00654318
	private unsafe void CheckLinkAnimInstance()
	{
		UiModelActorComponent actorComponent = this.ActorComponent;
		USkeletalMeshComponent uskeletalMeshComponent = (actorComponent != null) ? actorComponent.MainMeshComponent : null;
		if (((uskeletalMeshComponent != null) ? uskeletalMeshComponent.GetLinkedAnimGraphInstanceByTag(FNameUtil.NONE) : null) != null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Character;
			ELogAuthor author = ELogAuthor.LZK;
			string message = "检测出该Actor有空的动画LinkGraph节点,将会影响同步,GAS等功能,请找对应策划修复";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0);
			string item = "Actor";
			UiModelActorComponent actorComponent2 = this.ActorComponent;
			object item2;
			if (actorComponent2 == null)
			{
				item2 = null;
			}
			else
			{
				AActor actor = actorComponent2.Actor;
				item2 = ((actor != null) ? actor.GetName() : null);
			}
			ptr = new ValueTuple<string, object>(item, item2);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("AnimInstance", (uskeletalMeshComponent != null) ? uskeletalMeshComponent.GetAnimInstance() : null);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}
	}

	// Token: 0x06016D4D RID: 93517 RVA: 0x006561C8 File Offset: 0x006543C8
	protected void UpdateAnimInstance()
	{
		UiModelActorComponent actorComponent = this.ActorComponent;
		USkeletalMeshComponent uskeletalMeshComponent = (actorComponent != null) ? actorComponent.MainMeshComponent : null;
		if (uskeletalMeshComponent == null)
		{
			return;
		}
		this.CheckLinkAnimInstance();
		this.MainAnimInstanceInternal = uskeletalMeshComponent.GetLinkedAnimGraphInstanceByTag(Singleton<CharacterNameDefines>.Instance.ABP_BASE);
		if (this.MainAnimInstanceInternal == null)
		{
			this.MainAnimInstanceInternal = uskeletalMeshComponent.GetAnimInstance();
		}
	}

	// Token: 0x06016D4E RID: 93518 RVA: 0x0065621C File Offset: 0x0065441C
	public bool IsMontagePlaying()
	{
		UAnimInstance mainAnimInstanceInternal = this.MainAnimInstanceInternal;
		return mainAnimInstanceInternal != null && mainAnimInstanceInternal.IsAnyMontagePlaying();
	}

	// Token: 0x06016D4F RID: 93519 RVA: 0x0065622F File Offset: 0x0065442F
	[NullableContext(1)]
	public void PlayMontage(UAnimMontage asset)
	{
		UiModelDataComponent modelDataComponent = this.ModelDataComponent;
		if (modelDataComponent == null || modelDataComponent.GetModelLoadState() != EUiModelLoadState.LoadComplete)
		{
			this.MontageWaitToPlay = asset;
			return;
		}
		this.MainAnimInstanceInternal.Montage_Play(asset, 1f, EMontagePlayReturnType.MontageLength, 0f, true);
	}

	// Token: 0x06016D50 RID: 93520 RVA: 0x0065626C File Offset: 0x0065446C
	public void StopMontage(float blendOutTime = 0f)
	{
		UiModelDataComponent modelDataComponent = this.ModelDataComponent;
		if (modelDataComponent == null || modelDataComponent.GetModelLoadState() != EUiModelLoadState.LoadComplete)
		{
			this.MontageWaitToPlay = null;
			return;
		}
		this.MainAnimInstanceInternal.Montage_Stop(blendOutTime, null);
	}

	// Token: 0x06016D51 RID: 93521 RVA: 0x006562A0 File Offset: 0x006544A0
	public FName? GetCurrentSection()
	{
		UAnimInstance mainAnimInstanceInternal = this.MainAnimInstanceInternal;
		if (mainAnimInstanceInternal == null)
		{
			return null;
		}
		return new FName?(mainAnimInstanceInternal.Montage_GetCurrentSection(null));
	}

	// Token: 0x06016D52 RID: 93522 RVA: 0x006562CC File Offset: 0x006544CC
	public bool IsAnimationPlaying()
	{
		UiModelActorComponent actorComponent = this.ActorComponent;
		bool? flag;
		if (actorComponent == null)
		{
			flag = null;
		}
		else
		{
			USkeletalMeshComponent mainMeshComponent = actorComponent.MainMeshComponent;
			flag = ((mainMeshComponent != null) ? new bool?(mainMeshComponent.IsPlaying()) : null);
		}
		bool? flag2 = flag;
		return flag2.GetValueOrDefault();
	}

	// Token: 0x06016D53 RID: 93523 RVA: 0x00656314 File Offset: 0x00654514
	[NullableContext(1)]
	public void PlayAnimation(UAnimationAsset asset, bool bLoop = true)
	{
		UiModelDataComponent modelDataComponent = this.ModelDataComponent;
		if (modelDataComponent == null || modelDataComponent.GetModelLoadState() != EUiModelLoadState.LoadComplete)
		{
			this.AnimationWaitToPlay = asset;
			this.IsAnimationLoop = bLoop;
			return;
		}
		this.ActorComponent.MainMeshComponent.PlayAnimation(asset, bLoop);
	}

	// Token: 0x06016D54 RID: 93524 RVA: 0x00656351 File Offset: 0x00654551
	public void StopAnimation()
	{
		UiModelDataComponent modelDataComponent = this.ModelDataComponent;
		if (modelDataComponent == null || modelDataComponent.GetModelLoadState() != EUiModelLoadState.LoadComplete)
		{
			this.AnimationWaitToPlay = null;
			return;
		}
		this.ActorComponent.MainMeshComponent.Stop();
	}

	// Token: 0x06016D55 RID: 93525 RVA: 0x00656385 File Offset: 0x00654585
	public void SetAnimationMode(EAnimationMode animationMode)
	{
		UiModelDataComponent modelDataComponent = this.ModelDataComponent;
		if (modelDataComponent == null || modelDataComponent.GetModelLoadState() != EUiModelLoadState.LoadComplete)
		{
			this.AnimationMode = new EAnimationMode?(animationMode);
			return;
		}
		this.ActorComponent.MainMeshComponent.SetAnimationMode(animationMode);
	}

	// Token: 0x0400B001 RID: 45057
	private UiModelDataComponent ModelDataComponent;

	// Token: 0x0400B002 RID: 45058
	private UiModelActorComponent ActorComponent;

	// Token: 0x0400B003 RID: 45059
	private UAnimInstance MainAnimInstanceInternal;

	// Token: 0x0400B004 RID: 45060
	private UAnimMontage MontageWaitToPlay;

	// Token: 0x0400B005 RID: 45061
	private UAnimationAsset AnimationWaitToPlay;

	// Token: 0x0400B006 RID: 45062
	private bool IsAnimationLoop = true;

	// Token: 0x0400B007 RID: 45063
	private EAnimationMode? AnimationMode;
}
