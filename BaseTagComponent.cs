using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02003224 RID: 12836
[NullableContext(1)]
[Nullable(0)]
public class BaseTagComponent : EntityComponent, IStaticVariableResetter
{
	// Token: 0x0601AB1F RID: 109343 RVA: 0x007F26EC File Offset: 0x007F08EC
	static BaseTagComponent()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(BaseTagComponent.CreateStaticDefaultValue), new Action(BaseTagComponent.ResetStaticDefaultValue));
	}

	// Token: 0x0601AB20 RID: 109344 RVA: 0x007F2761 File Offset: 0x007F0961
	protected override bool OnInit()
	{
		this.TagContainer.AddAnyTagListener(new TAnyTagChangeCallback(this.OnAnyTagChanged));
		return true;
	}

	// Token: 0x0601AB21 RID: 109345 RVA: 0x007F277C File Offset: 0x007F097C
	protected override bool OnStart()
	{
		CreatureDataComponent component = base.Entity.GetComponent<CreatureDataComponent>();
		UBaseAbilitySystemComponent ubaseAbilitySystemComponent2;
		if (component != null && component.IsVehicle())
		{
			VehicleActorComponent component2 = base.Entity.GetComponent<VehicleActorComponent>();
			UBaseAbilitySystemComponent ubaseAbilitySystemComponent;
			if (component2 == null)
			{
				ubaseAbilitySystemComponent = null;
			}
			else
			{
				TsBaseVehicle actor = component2.Actor;
				ubaseAbilitySystemComponent = ((actor != null) ? actor.AbilitySystemComponent : null);
			}
			ubaseAbilitySystemComponent2 = ubaseAbilitySystemComponent;
		}
		else
		{
			CharacterActorComponent component3 = base.Entity.GetComponent<CharacterActorComponent>();
			UBaseAbilitySystemComponent ubaseAbilitySystemComponent3;
			if (component3 == null)
			{
				ubaseAbilitySystemComponent3 = null;
			}
			else
			{
				TsBaseCharacter actor2 = component3.Actor;
				ubaseAbilitySystemComponent3 = ((actor2 != null) ? actor2.AbilitySystemComponent : null);
			}
			ubaseAbilitySystemComponent2 = ubaseAbilitySystemComponent3;
		}
		if (ubaseAbilitySystemComponent2 != null && ubaseAbilitySystemComponent2.IsValid())
		{
			this.TagContainer.BindTsTagContainer(ubaseAbilitySystemComponent2);
		}
		return true;
	}

	// Token: 0x0601AB22 RID: 109346 RVA: 0x007F2806 File Offset: 0x007F0A06
	protected override bool OnEnd()
	{
		this.TagContainer.Clear();
		return true;
	}

	// Token: 0x0601AB23 RID: 109347 RVA: 0x007F2818 File Offset: 0x007F0A18
	protected unsafe void Emit(int tagId, [Nullable(new byte[]
	{
		2,
		1
	})] IEnumerable<BaseTagComponent.TTagSwitchedCallback> callbacks, int argsTagId, bool argstagExist)
	{
		if (tagId == 0 || callbacks == null)
		{
			return;
		}
		string nameByTagId = GameplayTagUtils.GetNameByTagId(tagId);
		foreach (BaseTagComponent.TTagSwitchedCallback ttagSwitchedCallback in callbacks)
		{
			try
			{
				ttagSwitchedCallback(argsTagId, argstagExist);
			}
			catch (Exception ex)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Event;
				ELogAuthor author = ELogAuthor.ZQR;
				string message = "tag事件回调执行异常";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("tag", nameByTagId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("error", ex.Message);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			}
		}
	}

	// Token: 0x0601AB24 RID: 109348 RVA: 0x007F28DC File Offset: 0x007F0ADC
	protected unsafe void Emit(int tagId, [Nullable(new byte[]
	{
		2,
		1
	})] IEnumerable<BaseTagComponent.TTagChangedCallback> callbacks, int argsCount, int argsTagId, int argsExactTagId, int argsOldCount)
	{
		if (tagId == 0 || callbacks == null)
		{
			return;
		}
		string nameByTagId = GameplayTagUtils.GetNameByTagId(tagId);
		foreach (BaseTagComponent.TTagChangedCallback ttagChangedCallback in callbacks)
		{
			try
			{
				ttagChangedCallback(argsCount, argsTagId, argsExactTagId, argsOldCount);
			}
			catch (Exception ex)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Event;
				ELogAuthor author = ELogAuthor.ZQR;
				string message = "tag事件回调执行异常";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("tag", nameByTagId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("error", ex.Message);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			}
		}
	}

	// Token: 0x0601AB25 RID: 109349 RVA: 0x007F29A4 File Offset: 0x007F0BA4
	public virtual void AddTag(int? tagId)
	{
		if (tagId == null)
		{
			return;
		}
		this.TagContainer.AddExactTag(ETagChannel.Common, tagId.Value);
	}

	// Token: 0x0601AB26 RID: 109350 RVA: 0x007F29C3 File Offset: 0x007F0BC3
	public virtual bool RemoveTag(int? tagId)
	{
		if (tagId == null)
		{
			return false;
		}
		this.TagContainer.RemoveTag(ETagChannel.Common, tagId.Value);
		this.TagContainer.RemoveTag(ETagChannel.Anim, tagId.Value);
		return true;
	}

	// Token: 0x0601AB27 RID: 109351 RVA: 0x007F29F7 File Offset: 0x007F0BF7
	public virtual bool HasTag(int tagId)
	{
		return this.TagContainer.ContainsTag(tagId);
	}

	// Token: 0x0601AB28 RID: 109352 RVA: 0x007F2A05 File Offset: 0x007F0C05
	public bool HasExactTag(int tagId)
	{
		return this.TagContainer.ContainsExactTag(tagId);
	}

	// Token: 0x0601AB29 RID: 109353 RVA: 0x007F2A14 File Offset: 0x007F0C14
	public bool HasAnyTag(IEnumerable<int> tagIds)
	{
		foreach (int tagId in tagIds)
		{
			if (this.HasTag(tagId))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x0601AB2A RID: 109354 RVA: 0x007F2A68 File Offset: 0x007F0C68
	[NullableContext(0)]
	public unsafe bool HasAnyTag(in ReadOnlySpan<int> tagIds)
	{
		ReadOnlySpan<int> readOnlySpan = tagIds;
		for (int i = 0; i < readOnlySpan.Length; i++)
		{
			int tagId = *readOnlySpan[i];
			if (this.HasTag(tagId))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x0601AB2B RID: 109355 RVA: 0x007F2AA4 File Offset: 0x007F0CA4
	public bool HasAnyTag(IEnumerable<int?> tagIds)
	{
		foreach (int? num in tagIds)
		{
			if (this.HasTag(num.GetValueOrDefault()))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x0601AB2C RID: 109356 RVA: 0x007F2AFC File Offset: 0x007F0CFC
	public bool HasAnyTagContainer(FGameplayTagContainer tagContainer)
	{
		TArray<FGameplayTag> gameplayTags = tagContainer.GameplayTags;
		for (int i = gameplayTags.Num() - 1; i >= 0; i--)
		{
			if (this.HasTag(gameplayTags.Get(i).TagId()))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x0601AB2D RID: 109357 RVA: 0x007F2B3C File Offset: 0x007F0D3C
	public bool HasAllTag(IEnumerable<int> tagIds)
	{
		foreach (int tagId in tagIds)
		{
			if (!this.HasTag(tagId))
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x0601AB2E RID: 109358 RVA: 0x007F2B90 File Offset: 0x007F0D90
	public int GetTagCount(int tagId)
	{
		if (tagId == 0)
		{
			return 0;
		}
		return this.TagContainer.GetTagCount(tagId);
	}

	// Token: 0x0601AB2F RID: 109359 RVA: 0x007F2BA4 File Offset: 0x007F0DA4
	[NullableContext(2)]
	public ITagTask ListenForTagAddOrRemove(int? tagId, [Nullable(1)] BaseTagComponent.TTagSwitchedCallback callback, Stat callbackStat = null)
	{
		if (tagId == null || callback == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Character;
			ELogAuthor author = ELogAuthor.ZQR;
			string message = "回调函数添加失败";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("tag", GameplayTagUtils.GetNameByTagId(tagId.Value));
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		TagSwitchedTask tagSwitchedTask = new TagSwitchedTask();
		tagSwitchedTask.StartTask(tagId.Value, callback, this, callbackStat);
		return tagSwitchedTask;
	}

	// Token: 0x0601AB30 RID: 109360 RVA: 0x007F2C08 File Offset: 0x007F0E08
	public bool HasTagAddOrRemoveListener(int tagId, BaseTagComponent.TTagSwitchedCallback callback)
	{
		HashSet<BaseTagComponent.TTagSwitchedCallback> hashSet;
		return this.TagSwitchedCallbacks.TryGetValue(tagId, out hashSet) && hashSet.Contains(callback);
	}

	// Token: 0x0601AB31 RID: 109361 RVA: 0x007F2C30 File Offset: 0x007F0E30
	public unsafe void AddTagAddOrRemoveListener(int tagId, BaseTagComponent.TTagSwitchedCallback callback, [Nullable(2)] Stat callbackStat = null)
	{
		if (tagId == 0 || callback == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Character;
			ELogAuthor author = ELogAuthor.ZQR;
			string message = "回调函数添加失败";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("tag", GameplayTagUtils.GetNameByTagId(tagId));
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("callbackName", (callback != null) ? callback.Method.Name : null);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return;
		}
		HashSet<BaseTagComponent.TTagSwitchedCallback> hashSet;
		if (!this.TagSwitchedCallbacks.TryGetValue(tagId, out hashSet))
		{
			hashSet = new HashSet<BaseTagComponent.TTagSwitchedCallback>();
			this.TagSwitchedCallbacks[tagId] = hashSet;
		}
		if (hashSet.Contains(callback))
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Character;
			ELogAuthor author2 = ELogAuthor.ZQR;
			string message2 = "重复添加回调函数";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("tag", GameplayTagUtils.GetNameByTagId(tagId));
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("callbackName", callback.Method.Name);
			instance2.Warn(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
			return;
		}
		hashSet.Add(callback);
	}

	// Token: 0x0601AB32 RID: 109362 RVA: 0x007F2D44 File Offset: 0x007F0F44
	public void RemoveTagAddOrRemoveListener(int tagId, BaseTagComponent.TTagSwitchedCallback callback)
	{
		HashSet<BaseTagComponent.TTagSwitchedCallback> hashSet;
		if (this.TagSwitchedCallbacks.TryGetValue(tagId, out hashSet))
		{
			hashSet.Remove(callback);
		}
	}

	// Token: 0x0601AB33 RID: 109363 RVA: 0x007F2D6C File Offset: 0x007F0F6C
	[NullableContext(2)]
	public ITagTask ListenForTagAnyCountChanged(int tagId, BaseTagComponent.TTagChangedCallback callback)
	{
		if (tagId == 0 || callback == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Character;
			ELogAuthor author = ELogAuthor.ZQR;
			string message = "回调函数添加失败";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("tag", GameplayTagUtils.GetNameByTagId(tagId));
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		TagChangedTask tagChangedTask = new TagChangedTask();
		tagChangedTask.StartTask(tagId, callback, this, null);
		return tagChangedTask;
	}

	// Token: 0x0601AB34 RID: 109364 RVA: 0x007F2DBC File Offset: 0x007F0FBC
	public unsafe void AddTagChangedListener(int tagId, BaseTagComponent.TTagChangedCallback callback, [Nullable(2)] Stat callbackStat = null)
	{
		if (tagId == 0 || callback == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Character;
			ELogAuthor author = ELogAuthor.ZQR;
			string message = "回调函数添加失败";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("tag", GameplayTagUtils.GetNameByTagId(tagId));
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		HashSet<BaseTagComponent.TTagChangedCallback> hashSet;
		if (!this.TagChangedCallbacks.TryGetValue(tagId, out hashSet))
		{
			hashSet = new HashSet<BaseTagComponent.TTagChangedCallback>();
			this.TagChangedCallbacks[tagId] = hashSet;
		}
		if (hashSet.Contains(callback))
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Character;
			ELogAuthor author2 = ELogAuthor.ZQR;
			string message2 = "重复添加回调函数";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("tag", GameplayTagUtils.GetNameByTagId(tagId));
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("callbackName", callback.Method.Name);
			instance2.Warn(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return;
		}
		if (!this.AddTagChangedListenerInEditor(hashSet, tagId, callback, callbackStat).GetValueOrDefault())
		{
			hashSet.Add(callback);
		}
	}

	// Token: 0x0601AB35 RID: 109365 RVA: 0x007F2EA8 File Offset: 0x007F10A8
	private bool? AddTagChangedListenerInEditor(HashSet<BaseTagComponent.TTagChangedCallback> callbackSet, int tagId, BaseTagComponent.TTagChangedCallback callback, [Nullable(2)] Stat callbackStat = null)
	{
		Stat stat2;
		Stat stat = callbackStat ?? (BaseTagComponent.TagChangedStats.TryGetValue(tagId, out stat2) ? stat2 : null);
		if (stat == null)
		{
			BaseTagComponent.TagChangedStats[tagId] = stat;
		}
		BaseTagComponent.TTagChangedCallback ttagChangedCallback = delegate(int count, int tagIdParam, int exactTagId, int oldCount)
		{
			callback(count, tagIdParam, exactTagId, oldCount);
		};
		Dictionary<BaseTagComponent.TTagChangedCallback, BaseTagComponent.TTagChangedCallback> dictionary;
		if (!this.WrappedTagChangedListenerMap.TryGetValue(tagId, out dictionary))
		{
			dictionary = new Dictionary<BaseTagComponent.TTagChangedCallback, BaseTagComponent.TTagChangedCallback>();
			this.WrappedTagChangedListenerMap[tagId] = dictionary;
		}
		dictionary[callback] = ttagChangedCallback;
		callbackSet.Add(ttagChangedCallback);
		return new bool?(true);
	}

	// Token: 0x0601AB36 RID: 109366 RVA: 0x007F2F3C File Offset: 0x007F113C
	public void RemoveTagChangedListener(int tagId, BaseTagComponent.TTagChangedCallback callback)
	{
		HashSet<BaseTagComponent.TTagChangedCallback> hashSet;
		if (this.TagChangedCallbacks.TryGetValue(tagId, out hashSet))
		{
			this.RemoveTagChangedListenerInEditor(hashSet, tagId, callback);
			hashSet.Remove(callback);
		}
	}

	// Token: 0x0601AB37 RID: 109367 RVA: 0x007F2F6C File Offset: 0x007F116C
	private bool? RemoveTagChangedListenerInEditor(HashSet<BaseTagComponent.TTagChangedCallback> callbackSet, int tagId, BaseTagComponent.TTagChangedCallback callback)
	{
		Dictionary<BaseTagComponent.TTagChangedCallback, BaseTagComponent.TTagChangedCallback> dictionary;
		BaseTagComponent.TTagChangedCallback item;
		if (this.WrappedTagChangedListenerMap.TryGetValue(tagId, out dictionary) && dictionary.TryGetValue(callback, out item))
		{
			callbackSet.Remove(item);
			dictionary.Remove(callback);
			if (dictionary.Count == 0)
			{
				this.WrappedTagChangedListenerMap.Remove(tagId);
			}
			return new bool?(true);
		}
		return new bool?(false);
	}

	// Token: 0x0601AB38 RID: 109368 RVA: 0x007F2FC6 File Offset: 0x007F11C6
	public string GetTagDebugStrings()
	{
		TagContainer tagContainer = this.TagContainer;
		return ((tagContainer != null) ? tagContainer.GetDebugString() : null) ?? "";
	}

	// Token: 0x0601AB39 RID: 109369 RVA: 0x007F2FE4 File Offset: 0x007F11E4
	protected virtual void OnAnyTagChanged(int tagId, int newCount, int oldCount, int exactTagId)
	{
		if (tagId == 0 || oldCount == newCount)
		{
			return;
		}
		bool flag = newCount > 0;
		if (oldCount > 0 != flag)
		{
			this.EmitSwitchedCallbacks(tagId, flag);
		}
		this.EmitChangedCallbacks(newCount, tagId, exactTagId, oldCount);
		AbilityEvent.Instance.Emit<int, int, int, int>(SceneTeam.Scene, EAbilityEventName.OnGameplayTagChanged, (long)tagId, base.Entity.Id, tagId, oldCount, newCount);
		BaseBuffComponent component = base.Entity.GetComponent<BaseBuffComponent>();
		if (component == null)
		{
			return;
		}
		component.OnTagChanged(tagId);
	}

	// Token: 0x0601AB3A RID: 109370 RVA: 0x007F3054 File Offset: 0x007F1254
	private void EmitSwitchedCallbacks(int tagId, bool tagExist)
	{
		HashSet<BaseTagComponent.TTagSwitchedCallback> source;
		if (this.TagSwitchedCallbacks.TryGetValue(tagId, out source))
		{
			BaseTagComponent.TTagSwitchedCallback[] array = source.ToArray<BaseTagComponent.TTagSwitchedCallback>();
			for (int i = 0; i < array.Length; i++)
			{
				array[i](tagId, tagExist);
			}
		}
	}

	// Token: 0x0601AB3B RID: 109371 RVA: 0x007F3090 File Offset: 0x007F1290
	private void EmitChangedCallbacks(int newCount, int tagId, int exactTagId, int oldCount)
	{
		HashSet<BaseTagComponent.TTagChangedCallback> source;
		if (this.TagChangedCallbacks.TryGetValue(tagId, out source))
		{
			BaseTagComponent.TTagChangedCallback[] array = source.ToArray<BaseTagComponent.TTagChangedCallback>();
			for (int i = 0; i < array.Length; i++)
			{
				array[i](newCount, tagId, exactTagId, oldCount);
			}
		}
	}

	// Token: 0x0601AB3C RID: 109372 RVA: 0x007F30CF File Offset: 0x007F12CF
	public static void CreateStaticDefaultValue()
	{
		BaseTagComponent.TagChangedStats = new Dictionary<int, Stat>();
	}

	// Token: 0x0601AB3D RID: 109373 RVA: 0x007F30DB File Offset: 0x007F12DB
	public static void ResetStaticDefaultValue()
	{
		BaseTagComponent.TagChangedStats = null;
	}

	// Token: 0x0601AB3E RID: 109374 RVA: 0x007F30E4 File Offset: 0x007F12E4
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		BaseTagComponent baseTagComponent = (BaseTagComponent)componentTemplate;
		if (base.CanResetComponentProperty("TagSwitchedCallbacks") && baseTagComponent.TagSwitchedCallbacks != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<int, HashSet<BaseTagComponent.TTagSwitchedCallback>>>(this.TagSwitchedCallbacks), "TagSwitchedCallbacks"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("TagChangedCallbacks") && baseTagComponent.TagChangedCallbacks != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<int, HashSet<BaseTagComponent.TTagChangedCallback>>>(this.TagChangedCallbacks), "TagChangedCallbacks"))
		{
			return false;
		}
		if (base.CanResetComponentProperty("TagContainer"))
		{
			if (baseTagComponent.TagContainer == null)
			{
				this.TagContainer = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<TagContainer>(this.TagContainer), "TagContainer"))
			{
				return false;
			}
		}
		return !base.CanResetComponentProperty("WrappedTagChangedListenerMap") || baseTagComponent.WrappedTagChangedListenerMap == null || base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<int, Dictionary<BaseTagComponent.TTagChangedCallback, BaseTagComponent.TTagChangedCallback>>>(this.WrappedTagChangedListenerMap), "WrappedTagChangedListenerMap");
	}

	// Token: 0x0400D86B RID: 55403
	protected readonly Dictionary<int, HashSet<BaseTagComponent.TTagSwitchedCallback>> TagSwitchedCallbacks = new Dictionary<int, HashSet<BaseTagComponent.TTagSwitchedCallback>>();

	// Token: 0x0400D86C RID: 55404
	protected readonly Dictionary<int, HashSet<BaseTagComponent.TTagChangedCallback>> TagChangedCallbacks = new Dictionary<int, HashSet<BaseTagComponent.TTagChangedCallback>>();

	// Token: 0x0400D86D RID: 55405
	public TagContainer TagContainer = new TagContainer();

	// Token: 0x0400D86E RID: 55406
	private static Dictionary<int, Stat> TagChangedStats;

	// Token: 0x0400D86F RID: 55407
	private readonly Dictionary<int, Dictionary<BaseTagComponent.TTagChangedCallback, BaseTagComponent.TTagChangedCallback>> WrappedTagChangedListenerMap = new Dictionary<int, Dictionary<BaseTagComponent.TTagChangedCallback, BaseTagComponent.TTagChangedCallback>>();

	// Token: 0x0400D870 RID: 55408
	[StaticVariableRuleIgnore]
	private static readonly Stat OnAnyTagChangedStat = Stat.Create("BaseTagComponent.OnAnyTagChanged", "", "");

	// Token: 0x0400D871 RID: 55409
	[StaticVariableRuleIgnore]
	private static readonly Stat OnAnyTagChangedCallbacksStat = Stat.Create("BaseTagComponent.OnAnyTagChanged.Callbacks", "", "");

	// Token: 0x0400D872 RID: 55410
	[StaticVariableRuleIgnore]
	private static readonly Stat OnAnyTagChangedOnGlobalGameplayTagChanged = Stat.Create("BaseTagComponent.OnAnyTagChanged.OnGlobalGameplayTagChanged", "", "");

	// Token: 0x0200941C RID: 37916
	// (Invoke) Token: 0x0604A2D8 RID: 303832
	[NullableContext(0)]
	public delegate void TTagSwitchedCallback(int tagId, bool tagExist);

	// Token: 0x0200941D RID: 37917
	// (Invoke) Token: 0x0604A2DC RID: 303836
	[NullableContext(0)]
	public delegate void TTagChangedCallback(int count, int tagId, int exactTagId, int oldCount);
}
