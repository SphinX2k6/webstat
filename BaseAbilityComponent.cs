using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

// Token: 0x02002E4E RID: 11854
[NullableContext(1)]
[Nullable(0)]
public class BaseAbilityComponent : EntityComponent, IStaticVariableResetter
{
	// Token: 0x06018491 RID: 99473 RVA: 0x006C8706 File Offset: 0x006C6906
	static BaseAbilityComponent()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(BaseAbilityComponent.CreateStaticDefaultValue), new Action(BaseAbilityComponent.ResetStaticDefaultValue));
	}

	// Token: 0x06018492 RID: 99474 RVA: 0x006C8728 File Offset: 0x006C6928
	protected override bool OnStart()
	{
		this.ActorComponent = base.Entity.GetComponent<BaseActorComponent>();
		this.TsAbilityComponentInternal = this.GetAbilitySystemComponent();
		if (!this.TsAbilityComponentInternal.IsValid())
		{
			Singleton<Log>.Instance.Error(ELogModule.Battle, ELogAuthor.ZQR, "技能组件TsAbilityComponentInternal Add失败，AbilityComponent Start失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		this.TsAbilityComponentInternal.SetComponentTickEnabled(false);
		this.RefreshMeshAnim();
		this.InitClass();
		this.TagComponent = base.Entity.CheckGetComponent<BaseTagComponent>();
		this.GameplayEventTask = this.CreateGameplayEventTask(new Action<FGameplayTag, FGameplayEventData>(this.GameplayEventCallback));
		Singleton<EventSystem>.Instance.AddWithTarget<Entity, EMorphType, EMorphType>(base.Entity, EEventName.OnCharacterMorphTypeChanged, new Action<Entity, EMorphType, EMorphType>(this.OnCharacterMorphTypeChanged));
		return true;
	}

	// Token: 0x06018493 RID: 99475 RVA: 0x006C87E1 File Offset: 0x006C69E1
	protected override bool OnEnd()
	{
		if (this.GameplayEventTask != null)
		{
			this.GameplayEventTask.EndTask();
		}
		Singleton<EventSystem>.Instance.RemoveWithTarget<Entity, EMorphType, EMorphType>(base.Entity, EEventName.OnCharacterMorphTypeChanged, new Action<Entity, EMorphType, EMorphType>(this.OnCharacterMorphTypeChanged));
		return true;
	}

	// Token: 0x06018494 RID: 99476 RVA: 0x006C8819 File Offset: 0x006C6A19
	protected override bool OnClear()
	{
		if (this.TsAbilityComponentInternal != null)
		{
			this.TsAbilityComponentInternal.K2_DestroyComponent(this.TsAbilityComponentInternal);
			this.TsAbilityComponentInternal = null;
		}
		return true;
	}

	// Token: 0x06018495 RID: 99477 RVA: 0x006C883C File Offset: 0x006C6A3C
	protected override void OnTick(float delta)
	{
		this.TsAbilityComponentInternal.KuroTickComponentOutside(delta * 0.001f * this.ActorComponent.Owner.CustomTimeDilation);
	}

	// Token: 0x06018496 RID: 99478 RVA: 0x006C8861 File Offset: 0x006C6A61
	private void OnCharacterMorphTypeChanged(Entity entity, EMorphType morphType, EMorphType oldMorphType)
	{
		this.RefreshMeshAnim();
	}

	// Token: 0x06018497 RID: 99479 RVA: 0x006C886C File Offset: 0x006C6A6C
	protected void RefreshMeshAnim()
	{
		ACharacter acharacter = this.ActorComponent.Owner as ACharacter;
		if (acharacter != null)
		{
			FName abp_BASE = Singleton<CharacterNameDefines>.Instance.ABP_BASE;
			if (acharacter.Mesh.GetLinkedAnimGraphInstanceByTag(abp_BASE) != null)
			{
				this.TsAbilityComponentInternal.BP_InitAbilityActorInfo(abp_BASE);
				return;
			}
			this.TsAbilityComponentInternal.BP_InitAbilityActorInfo(FNameUtil.NONE);
		}
	}

	// Token: 0x06018498 RID: 99480 RVA: 0x006C88C3 File Offset: 0x006C6AC3
	[NullableContext(2)]
	protected virtual UBaseAbilitySystemComponent GetAbilitySystemComponent()
	{
		return null;
	}

	// Token: 0x06018499 RID: 99481 RVA: 0x006C88C6 File Offset: 0x006C6AC6
	public void AddPerformanceTag(string tagName)
	{
		this.LastPerformanceTag = tagName;
		this.TagComponent.AddTag(new int?(GameplayTagUtils.GetTagIdByName(tagName)));
	}

	// Token: 0x0601849A RID: 99482 RVA: 0x006C88E5 File Offset: 0x006C6AE5
	public void ClearLastPerformanceTag()
	{
		if (!string.IsNullOrEmpty(this.LastPerformanceTag))
		{
			this.TagComponent.RemoveTag(new int?(GameplayTagUtils.GetTagIdByName(this.LastPerformanceTag)));
		}
	}

	// Token: 0x0601849B RID: 99483 RVA: 0x006C8910 File Offset: 0x006C6B10
	[NullableContext(2)]
	public void SendGameplayEventToActor(FGameplayTag eventTag, FGameplayEventData payload = null)
	{
		UAbilitySystemBlueprintLibrary.SendGameplayEventToActor(this.ActorComponent.Owner, eventTag, payload ?? BaseAbilityComponent._cachedGameplayEventData);
	}

	// Token: 0x0601849C RID: 99484 RVA: 0x006C892D File Offset: 0x006C6B2D
	public bool TryActivateAbilityByClass(UClassStackOnlyPtr inAbilityToActivate, bool bAllowRemoteActivation = true)
	{
		return this.TsAbilityComponentInternal.TryActivateAbilityByClass(inAbilityToActivate, bAllowRemoteActivation);
	}

	// Token: 0x0601849D RID: 99485 RVA: 0x006C8941 File Offset: 0x006C6B41
	[NullableContext(2)]
	public UGameplayAbility GetCurrentWaitAndPlayedMontageCorrespondingGa()
	{
		return this.TsAbilityComponentInternal.LocalAnimMontageInfo.AnimatingAbility;
	}

	// Token: 0x0601849E RID: 99486 RVA: 0x006C8954 File Offset: 0x006C6B54
	public FGameplayAbilitySpecHandle GetAbility(UClassStackOnlyPtr ability)
	{
		UBaseAbilitySystemComponent tsAbilityComponentInternal = this.TsAbilityComponentInternal;
		TSubclassOf<UGameplayAbility> tsubclassOf = ability;
		return tsAbilityComponentInternal.GetAbility(tsubclassOf);
	}

	// Token: 0x0601849F RID: 99487 RVA: 0x006C8975 File Offset: 0x006C6B75
	public void ClearAbility(FGameplayAbilitySpecHandle handle)
	{
		this.TsAbilityComponentInternal.RemoveAbility(handle);
	}

	// Token: 0x060184A0 RID: 99488 RVA: 0x006C8984 File Offset: 0x006C6B84
	public int GetAbilityScopeLockCount()
	{
		return this.TsAbilityComponentInternal.GetAbilityScopeLockCount();
	}

	// Token: 0x060184A1 RID: 99489 RVA: 0x006C8991 File Offset: 0x006C6B91
	public void InitClass()
	{
		if (BaseAbilityComponent._isClassInitiated)
		{
			return;
		}
		BaseAbilityComponent._cachedGameplayEventData = new FGameplayEventData();
		BaseAbilityComponent._isClassInitiated = true;
	}

	// Token: 0x060184A2 RID: 99490 RVA: 0x006C89AB File Offset: 0x006C6BAB
	public UAsyncTaskWaitGameplayEvent CreateGameplayEventTask(Action<FGameplayTag, FGameplayEventData> callback)
	{
		UAsyncTaskWaitGameplayEvent uasyncTaskWaitGameplayEvent = UAsyncTaskWaitGameplayEvent.ListenForGameplayEvent(this.TsAbilityComponentInternal);
		uasyncTaskWaitGameplayEvent.EventReceived.Add(callback);
		return uasyncTaskWaitGameplayEvent;
	}

	// Token: 0x060184A3 RID: 99491 RVA: 0x006C89C4 File Offset: 0x006C6BC4
	private unsafe void GameplayEventCallback(FGameplayTag eventTag, FGameplayEventData payload)
	{
		int num = eventTag.TagId();
		if (num == 0)
		{
			return;
		}
		HashSet<TGameplayEventCallback> collection;
		if (!this.GameplayEventCallbacks.TryGetValue(num, out collection))
		{
			return;
		}
		string nameByTagId = GameplayTagUtils.GetNameByTagId(num);
		foreach (TGameplayEventCallback tgameplayEventCallback in new List<TGameplayEventCallback>(collection))
		{
			try
			{
				tgameplayEventCallback(num, payload);
			}
			catch (Exception ex)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Event;
				ELogAuthor author = ELogAuthor.HXY;
				string message = "gameplayEvent事件回调执行异常";
				Exception error = ex;
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("gameplayEvent", nameByTagId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("error", ex.Message);
				instance.ErrorWithStack(module, author, message, error, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			}
		}
	}

	// Token: 0x060184A4 RID: 99492 RVA: 0x006C8AAC File Offset: 0x006C6CAC
	public unsafe void AddGameplayEventListener(int tagId, TGameplayEventCallback callback)
	{
		if (callback == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Character;
			ELogAuthor author = ELogAuthor.HXY;
			string message = "回调函数添加失败";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("gameplayEvent", GameplayTagUtils.GetNameByTagId(tagId));
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("callbackName", (callback != null) ? callback.Method.Name : null);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return;
		}
		HashSet<TGameplayEventCallback> hashSet;
		if (!this.GameplayEventCallbacks.TryGetValue(tagId, out hashSet))
		{
			hashSet = new HashSet<TGameplayEventCallback>();
			this.GameplayEventCallbacks[tagId] = hashSet;
		}
		if (hashSet.Contains(callback))
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Character;
			ELogAuthor author2 = ELogAuthor.HXY;
			string message2 = "重复添加回调函数";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("gameplayEvent", GameplayTagUtils.GetNameByTagId(tagId));
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("callbackName", callback.Method.Name);
			instance2.Warn(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
			return;
		}
		hashSet.Add(callback);
	}

	// Token: 0x060184A5 RID: 99493 RVA: 0x006C8BBC File Offset: 0x006C6DBC
	public void RemoveGameplayEventListener(int tagId, TGameplayEventCallback callback)
	{
		HashSet<TGameplayEventCallback> hashSet;
		if (!this.GameplayEventCallbacks.TryGetValue(tagId, out hashSet))
		{
			return;
		}
		hashSet.Remove(callback);
	}

	// Token: 0x060184A6 RID: 99494 RVA: 0x006C8BE2 File Offset: 0x006C6DE2
	public static void CreateStaticDefaultValue()
	{
		BaseAbilityComponent._cachedGameplayEventData = null;
		BaseAbilityComponent._isClassInitiated = false;
	}

	// Token: 0x060184A7 RID: 99495 RVA: 0x006C8BF0 File Offset: 0x006C6DF0
	public static void ResetStaticDefaultValue()
	{
		BaseAbilityComponent._cachedGameplayEventData = null;
		BaseAbilityComponent._isClassInitiated = false;
	}

	// Token: 0x060184A8 RID: 99496 RVA: 0x006C8C00 File Offset: 0x006C6E00
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		BaseAbilityComponent baseAbilityComponent = (BaseAbilityComponent)componentTemplate;
		if (base.CanResetComponentProperty("ActorComponent"))
		{
			if (baseAbilityComponent.ActorComponent == null)
			{
				this.ActorComponent = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BaseActorComponent>(this.ActorComponent), "ActorComponent"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("TsAbilityComponentInternal"))
		{
			if (baseAbilityComponent.TsAbilityComponentInternal == null)
			{
				this.TsAbilityComponentInternal = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<UBaseAbilitySystemComponent>(this.TsAbilityComponentInternal), "TsAbilityComponentInternal"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("TagComponent"))
		{
			if (baseAbilityComponent.TagComponent == null)
			{
				this.TagComponent = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BaseTagComponent>(this.TagComponent), "TagComponent"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("LastPerformanceTag"))
		{
			this.LastPerformanceTag = baseAbilityComponent.LastPerformanceTag;
		}
		if (base.CanResetComponentProperty("GameplayEventTask"))
		{
			if (baseAbilityComponent.GameplayEventTask == null)
			{
				this.GameplayEventTask = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<UAsyncTaskWaitGameplayEvent>(this.GameplayEventTask), "GameplayEventTask"))
			{
				return false;
			}
		}
		return !base.CanResetComponentProperty("GameplayEventCallbacks") || baseAbilityComponent.GameplayEventCallbacks == null || base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<int, HashSet<TGameplayEventCallback>>>(this.GameplayEventCallbacks), "GameplayEventCallbacks");
	}

	// Token: 0x0400BAA0 RID: 47776
	public const int DEFAULT_SOURCE_SKILL_LEVEL = 1;

	// Token: 0x0400BAA1 RID: 47777
	public const int DEFAULT_SOURCE_SKILL_LEVEL_NOT_FOUND = -1;

	// Token: 0x0400BAA2 RID: 47778
	[Nullable(2)]
	private BaseActorComponent ActorComponent;

	// Token: 0x0400BAA3 RID: 47779
	[Nullable(2)]
	private UBaseAbilitySystemComponent TsAbilityComponentInternal;

	// Token: 0x0400BAA4 RID: 47780
	[Nullable(2)]
	private BaseTagComponent TagComponent;

	// Token: 0x0400BAA5 RID: 47781
	[Nullable(2)]
	private static FGameplayEventData _cachedGameplayEventData;

	// Token: 0x0400BAA6 RID: 47782
	private string LastPerformanceTag = "";

	// Token: 0x0400BAA7 RID: 47783
	private static bool _isClassInitiated;

	// Token: 0x0400BAA8 RID: 47784
	[Nullable(2)]
	private UAsyncTaskWaitGameplayEvent GameplayEventTask;

	// Token: 0x0400BAA9 RID: 47785
	protected readonly Dictionary<int, HashSet<TGameplayEventCallback>> GameplayEventCallbacks = new Dictionary<int, HashSet<TGameplayEventCallback>>();
}
