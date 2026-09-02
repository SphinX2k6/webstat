using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02002ED8 RID: 11992
[NullableContext(1)]
[Nullable(0)]
public class TagContainer : IClear
{
	// Token: 0x060189FE RID: 100862 RVA: 0x006F0644 File Offset: 0x006EE844
	public IEnumerable<int> GetAllExactTags()
	{
		return this.ExactTags.Keys;
	}

	// Token: 0x060189FF RID: 100863 RVA: 0x006F0651 File Offset: 0x006EE851
	public IEnumerable<ETagChannel> GetAllChannels()
	{
		return this.RawTags.Keys;
	}

	// Token: 0x06018A00 RID: 100864 RVA: 0x006F0660 File Offset: 0x006EE860
	[NullableContext(2)]
	public void BindTsTagContainer(UBaseAbilitySystemComponent tsAbilityComponent)
	{
		this.UeContainer = tsAbilityComponent;
		if (tsAbilityComponent != null)
		{
			foreach (int num in this.ExactTags.Keys)
			{
				FGameplayTag? gameplayTagById = GameplayTagUtils.GetGameplayTagById(num);
				if (gameplayTagById != null)
				{
					FGameplayTag value = gameplayTagById.Value;
					tsAbilityComponent.UpdateTagMap(value, this.ExactTags.GetValueOrDefault(num, 0));
				}
			}
		}
	}

	// Token: 0x06018A01 RID: 100865 RVA: 0x006F06E8 File Offset: 0x006EE8E8
	public bool Clear()
	{
		this.ExactTags.Clear();
		this.RawTags.Clear();
		this.ParentTags.Clear();
		this.AnyTagListeners.Clear();
		this.AnyExactTagListeners.Clear();
		this.UeContainer = null;
		return true;
	}

	// Token: 0x06018A02 RID: 100866 RVA: 0x006F0734 File Offset: 0x006EE934
	public bool ClearObject()
	{
		return this.Clear();
	}

	// Token: 0x06018A03 RID: 100867 RVA: 0x006F073C File Offset: 0x006EE93C
	[return: TupleElementNames(new string[]
	{
		"tagId",
		"newCount",
		"oldCount",
		"isExact",
		"exactTagId"
	})]
	[return: Nullable(new byte[]
	{
		1,
		0
	})]
	private ValueTuple<int, int, int, bool, int>[] ModifyTagInner(int tagId, int deltaCount)
	{
		if (deltaCount == 0)
		{
			return new ValueTuple<int, int, int, bool, int>[0];
		}
		int valueOrDefault = this.ExactTags.GetValueOrDefault(tagId, 0);
		int num = Math.Max(0, valueOrDefault + deltaCount);
		deltaCount = num - valueOrDefault;
		if (valueOrDefault == num)
		{
			return new ValueTuple<int, int, int, bool, int>[0];
		}
		if (num <= 0)
		{
			this.ExactTags.Remove(tagId);
		}
		else
		{
			this.ExactTags[tagId] = num;
		}
		int parentTag = GameplayTagUtils.GetParentTag(tagId);
		List<ValueTuple<int, int, int, bool, int>> list = new List<ValueTuple<int, int, int, bool, int>>
		{
			new ValueTuple<int, int, int, bool, int>(tagId, num, valueOrDefault, true, tagId)
		};
		while (parentTag != 0)
		{
			int valueOrDefault2 = this.ParentTags.GetValueOrDefault(parentTag, 0);
			int valueOrDefault3 = this.ExactTags.GetValueOrDefault(parentTag, 0);
			int num2 = Math.Max(0, valueOrDefault2 + deltaCount);
			if (num2 <= 0)
			{
				this.ParentTags.Remove(parentTag);
			}
			else
			{
				this.ParentTags[parentTag] = num2;
			}
			list.Add(new ValueTuple<int, int, int, bool, int>(parentTag, num2 + valueOrDefault3, valueOrDefault2 + valueOrDefault3, false, tagId));
			parentTag = GameplayTagUtils.GetParentTag(parentTag);
		}
		FGameplayTag? gameplayTagById = GameplayTagUtils.GetGameplayTagById(tagId);
		if (gameplayTagById != null)
		{
			UBaseAbilitySystemComponent ueContainer = this.UeContainer;
			if (ueContainer != null)
			{
				FGameplayTag value = gameplayTagById.Value;
				ueContainer.UpdateTagMap(value, deltaCount);
			}
		}
		return list.ToArray();
	}

	// Token: 0x06018A04 RID: 100868 RVA: 0x006F085C File Offset: 0x006EEA5C
	private void InvokeEvents([TupleElementNames(new string[]
	{
		"tagId",
		"newCount",
		"oldCount",
		"isExact",
		"exactTagId"
	})] [Nullable(new byte[]
	{
		2,
		0
	})] ValueTuple<int, int, int, bool, int>[] callbackList)
	{
		if (callbackList == null || callbackList.Length == 0)
		{
			return;
		}
		foreach (ValueTuple<int, int, int, bool, int> valueTuple in callbackList)
		{
			int item = valueTuple.Item1;
			int item2 = valueTuple.Item2;
			int item3 = valueTuple.Item3;
			bool item4 = valueTuple.Item4;
			int item5 = valueTuple.Item5;
			if (item4)
			{
				foreach (TAnyTagChangeCallback tanyTagChangeCallback in this.AnyExactTagListeners.ToArray<TAnyTagChangeCallback>())
				{
					try
					{
						tanyTagChangeCallback(item, item2, item3, item5);
					}
					catch (Exception ex)
					{
						Log instance = Singleton<Log>.Instance;
						ELogModule module = ELogModule.Character;
						ELogAuthor author = ELogAuthor.ZQR;
						string message = "执行Tag监听回调时出错";
						Exception error = ex;
						ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("error", ex.Message);
						instance.ErrorWithStack(module, author, message, error, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
					}
				}
			}
			foreach (TAnyTagChangeCallback tanyTagChangeCallback2 in this.AnyTagListeners.ToArray<TAnyTagChangeCallback>())
			{
				try
				{
					tanyTagChangeCallback2(item, item2, item3, item5);
				}
				catch (Exception ex2)
				{
					Log instance2 = Singleton<Log>.Instance;
					ELogModule module2 = ELogModule.Character;
					ELogAuthor author2 = ELogAuthor.ZQR;
					string message2 = "执行Tag监听回调时出错";
					Exception error2 = ex2;
					ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("error", ex2.Message);
					instance2.ErrorWithStack(module2, author2, message2, error2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
				}
			}
		}
	}

	// Token: 0x06018A05 RID: 100869 RVA: 0x006F09AC File Offset: 0x006EEBAC
	public void AddExactTag(ETagChannel tagChannel, int tagId)
	{
		Dictionary<int, int> dictionary;
		if (!this.RawTags.TryGetValue(tagChannel, out dictionary))
		{
			dictionary = new Dictionary<int, int>();
			this.RawTags[tagChannel] = dictionary;
		}
		dictionary[tagId] = dictionary.GetValueOrDefault(tagId, 0) + 1;
		ValueTuple<int, int, int, bool, int>[] callbackList = this.ModifyTagInner(tagId, 1);
		this.InvokeEvents(callbackList);
	}

	// Token: 0x06018A06 RID: 100870 RVA: 0x006F0A00 File Offset: 0x006EEC00
	public void RemoveTag(ETagChannel tagChannel, int tagId)
	{
		Dictionary<int, int> dictionary;
		if (!this.RawTags.TryGetValue(tagChannel, out dictionary))
		{
			return;
		}
		int valueOrDefault = dictionary.GetValueOrDefault(tagId, 0);
		dictionary.Remove(tagId);
		ValueTuple<int, int, int, bool, int>[] array = this.ModifyTagInner(tagId, -valueOrDefault) ?? new ValueTuple<int, int, int, bool, int>[0];
		if (this.ParentTags.GetValueOrDefault(tagId, 0) > 0)
		{
			List<int> list = new List<int>();
			foreach (int num in dictionary.Keys)
			{
				if (GameplayTagUtils.IsChildTag(num, tagId))
				{
					list.Add(num);
				}
			}
			foreach (int num2 in list)
			{
				int valueOrDefault2 = dictionary.GetValueOrDefault(num2, 0);
				dictionary.Remove(num2);
				ValueTuple<int, int, int, bool, int>[] array2 = this.ModifyTagInner(num2, -valueOrDefault2);
				if (array2 != null)
				{
					array = array.Concat(array2).ToArray<ValueTuple<int, int, int, bool, int>>();
				}
			}
		}
		if (dictionary.Count == 0)
		{
			this.RawTags.Remove(tagChannel);
		}
		this.InvokeEvents(array);
	}

	// Token: 0x06018A07 RID: 100871 RVA: 0x006F0B38 File Offset: 0x006EED38
	public void RemoveExactTag(ETagChannel tagChannel, int tagId)
	{
		Dictionary<int, int> dictionary;
		if (!this.RawTags.TryGetValue(tagChannel, out dictionary))
		{
			return;
		}
		int valueOrDefault = dictionary.GetValueOrDefault(tagId, 0);
		ValueTuple<int, int, int, bool, int>[] callbackList = null;
		if (valueOrDefault > 0)
		{
			callbackList = this.ModifyTagInner(tagId, -valueOrDefault);
			dictionary.Remove(tagId);
		}
		if (dictionary.Count == 0)
		{
			this.RawTags.Remove(tagChannel);
		}
		this.InvokeEvents(callbackList);
	}

	// Token: 0x06018A08 RID: 100872 RVA: 0x006F0B94 File Offset: 0x006EED94
	public void UpdateExactTag(ETagChannel tagChannel, int tagId, int deltaCount)
	{
		Dictionary<int, int> dictionary;
		if (!this.RawTags.TryGetValue(tagChannel, out dictionary))
		{
			if (deltaCount <= 0)
			{
				return;
			}
			dictionary = new Dictionary<int, int>();
			this.RawTags[tagChannel] = dictionary;
		}
		int valueOrDefault = dictionary.GetValueOrDefault(tagId, 0);
		int num = Math.Max(0, valueOrDefault + deltaCount);
		if (num > 0)
		{
			dictionary[tagId] = num;
		}
		else
		{
			dictionary.Remove(tagId);
		}
		ValueTuple<int, int, int, bool, int>[] callbackList = this.ModifyTagInner(tagId, num - valueOrDefault);
		if (dictionary.Count == 0)
		{
			this.RawTags.Remove(tagChannel);
		}
		this.InvokeEvents(callbackList);
	}

	// Token: 0x06018A09 RID: 100873 RVA: 0x006F0C1B File Offset: 0x006EEE1B
	public bool ContainsTag(int tagId)
	{
		return this.ExactTags.ContainsKey(tagId) || this.ParentTags.ContainsKey(tagId);
	}

	// Token: 0x06018A0A RID: 100874 RVA: 0x006F0C39 File Offset: 0x006EEE39
	public bool ContainsExactTag(int tagId)
	{
		return this.ExactTags.ContainsKey(tagId);
	}

	// Token: 0x06018A0B RID: 100875 RVA: 0x006F0C48 File Offset: 0x006EEE48
	public int GetRawTagCount(ETagChannel channel, int tagId)
	{
		Dictionary<int, int> dictionary;
		if (this.RawTags.TryGetValue(channel, out dictionary))
		{
			return dictionary.GetValueOrDefault(tagId, 0);
		}
		return 0;
	}

	// Token: 0x06018A0C RID: 100876 RVA: 0x006F0C6F File Offset: 0x006EEE6F
	public int GetTagCount(int tagId)
	{
		return this.ExactTags.GetValueOrDefault(tagId, 0) + this.ParentTags.GetValueOrDefault(tagId, 0);
	}

	// Token: 0x06018A0D RID: 100877 RVA: 0x006F0C8C File Offset: 0x006EEE8C
	public int GetExactTagCount(int tagId)
	{
		return this.ExactTags.GetValueOrDefault(tagId, 0);
	}

	// Token: 0x06018A0E RID: 100878 RVA: 0x006F0C9B File Offset: 0x006EEE9B
	public void AddAnyTagListener(TAnyTagChangeCallback listener)
	{
		this.AnyTagListeners.Add(listener);
	}

	// Token: 0x06018A0F RID: 100879 RVA: 0x006F0CAA File Offset: 0x006EEEAA
	public void RemoveAnyTagListener(TAnyTagChangeCallback listener)
	{
		this.AnyTagListeners.Remove(listener);
	}

	// Token: 0x06018A10 RID: 100880 RVA: 0x006F0CB9 File Offset: 0x006EEEB9
	public void AddAnyExactTagListener(TAnyTagChangeCallback listener)
	{
		this.AnyExactTagListeners.Add(listener);
	}

	// Token: 0x06018A11 RID: 100881 RVA: 0x006F0CC8 File Offset: 0x006EEEC8
	public void RemoveExactAnyTagListener(TAnyTagChangeCallback listener)
	{
		this.AnyExactTagListeners.Remove(listener);
	}

	// Token: 0x06018A12 RID: 100882 RVA: 0x006F0CD8 File Offset: 0x006EEED8
	public string GetDebugString()
	{
		return "汇总tag:\n" + this.GetExactTagsDebugString() + "\n\n父tag:\n" + string.Join("", from s in this.ParentTags.Select(delegate(KeyValuePair<int, int> kvp)
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(4, 2);
			defaultInterpolatedStringHandler.AppendFormatted(GameplayTagUtils.GetNameByTagId(kvp.Key));
			defaultInterpolatedStringHandler.AppendLiteral(" * ");
			defaultInterpolatedStringHandler.AppendFormatted<int>(kvp.Value);
			defaultInterpolatedStringHandler.AppendLiteral("\n");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		})
		orderby s
		select s);
	}

	// Token: 0x06018A13 RID: 100883 RVA: 0x006F0D5C File Offset: 0x006EEF5C
	public string GetExactTagsDebugString()
	{
		return string.Join("", from s in this.ExactTags.Select(delegate(KeyValuePair<int, int> kvp)
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(4, 2);
			defaultInterpolatedStringHandler.AppendFormatted(GameplayTagUtils.GetNameByTagId(kvp.Key));
			defaultInterpolatedStringHandler.AppendLiteral(" x ");
			defaultInterpolatedStringHandler.AppendFormatted<int>(kvp.Value);
			defaultInterpolatedStringHandler.AppendLiteral("(");
			string text = defaultInterpolatedStringHandler.ToStringAndClear();
			foreach (ETagChannel key in this.RawTags.Keys)
			{
				Dictionary<int, int> dictionary;
				if (this.RawTags.TryGetValue(key, out dictionary))
				{
					int valueOrDefault = dictionary.GetValueOrDefault(kvp.Key, 0);
					if (valueOrDefault != 0)
					{
						string str = text;
						defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(3, 2);
						defaultInterpolatedStringHandler.AppendFormatted(TagContainer.channelDebugName[key]);
						defaultInterpolatedStringHandler.AppendLiteral(" x ");
						defaultInterpolatedStringHandler.AppendFormatted<int>(valueOrDefault);
						text = str + defaultInterpolatedStringHandler.ToStringAndClear();
					}
				}
			}
			return text + ")\n";
		})
		orderby s
		select s);
	}

	// Token: 0x06018A14 RID: 100884 RVA: 0x006F0DB0 File Offset: 0x006EEFB0
	public bool HasAnyTag(TagContainer otherContainer)
	{
		foreach (int tagId in otherContainer.GetAllExactTags())
		{
			if (this.ContainsTag(tagId))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06018A15 RID: 100885 RVA: 0x006F0E08 File Offset: 0x006EF008
	public bool HasAllTag(TagContainer otherContainer)
	{
		foreach (int tagId in otherContainer.GetAllExactTags())
		{
			if (!this.ContainsTag(tagId))
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x06018A16 RID: 100886 RVA: 0x006F0E60 File Offset: 0x006EF060
	public bool NotHasAnyTag(TagContainer otherContainer)
	{
		foreach (int tagId in otherContainer.GetAllExactTags())
		{
			if (!this.ContainsTag(tagId))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06018A17 RID: 100887 RVA: 0x006F0EB8 File Offset: 0x006EF0B8
	public bool NotHasAllTag(TagContainer otherContainer)
	{
		foreach (int tagId in otherContainer.GetAllExactTags())
		{
			if (this.ContainsTag(tagId))
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x06018A19 RID: 100889 RVA: 0x006F0F50 File Offset: 0x006EF150
	// Note: this type is marked as 'beforefieldinit'.
	static TagContainer()
	{
		Dictionary<ETagChannel, string> dictionary = new Dictionary<ETagChannel, string>();
		dictionary[ETagChannel.Common] = "Tag";
		dictionary[ETagChannel.BattleBuff] = "Buff";
		dictionary[ETagChannel.LevelServer] = "关卡服务器";
		dictionary[ETagChannel.Anim] = "动画";
		dictionary[ETagChannel.Player] = "玩家编队";
		dictionary[ETagChannel.Frozen] = "Frozen";
		dictionary[ETagChannel.PassiveSkill] = "被动技能";
		TagContainer.channelDebugName = dictionary;
		TagContainer.ModifyTagInnerStat = Stat.Create("TagContainer.ModifyTagInner", "STATGROUP_KuroBattle", "");
		TagContainer.ModifyTagInnerModifyCountStat = Stat.Create("TagContainer.ModifyTagInner.ModifyCount", "STATGROUP_KuroBattle", "");
		TagContainer.ModifyTagInnerUpdateUeStat = Stat.Create("TagContainer.ModifyTagInner.UpdateUe", "STATGROUP_KuroBattle", "");
		TagContainer.InvokeEventsStat = Stat.Create("TagContainer.InvokeEvents", "STATGROUP_KuroBattle", "");
		TagContainer.UpdateExactTagStat = Stat.Create("TagContainer.UpdateExactTag", "STATGROUP_KuroBattle", "");
	}

	// Token: 0x0400BEA6 RID: 48806
	[StaticVariableRuleIgnore]
	public static readonly Dictionary<ETagChannel, string> channelDebugName;

	// Token: 0x0400BEA7 RID: 48807
	private readonly Dictionary<ETagChannel, Dictionary<int, int>> RawTags = new Dictionary<ETagChannel, Dictionary<int, int>>();

	// Token: 0x0400BEA8 RID: 48808
	private readonly Dictionary<int, int> ExactTags = new Dictionary<int, int>();

	// Token: 0x0400BEA9 RID: 48809
	private readonly Dictionary<int, int> ParentTags = new Dictionary<int, int>();

	// Token: 0x0400BEAA RID: 48810
	private readonly HashSet<TAnyTagChangeCallback> AnyTagListeners = new HashSet<TAnyTagChangeCallback>();

	// Token: 0x0400BEAB RID: 48811
	private readonly HashSet<TAnyTagChangeCallback> AnyExactTagListeners = new HashSet<TAnyTagChangeCallback>();

	// Token: 0x0400BEAC RID: 48812
	[Nullable(2)]
	private UBaseAbilitySystemComponent UeContainer;

	// Token: 0x0400BEAD RID: 48813
	[StaticVariableRuleIgnore]
	private static readonly Stat ModifyTagInnerStat;

	// Token: 0x0400BEAE RID: 48814
	[StaticVariableRuleIgnore]
	private static readonly Stat ModifyTagInnerModifyCountStat;

	// Token: 0x0400BEAF RID: 48815
	[StaticVariableRuleIgnore]
	private static readonly Stat ModifyTagInnerUpdateUeStat;

	// Token: 0x0400BEB0 RID: 48816
	[StaticVariableRuleIgnore]
	private static readonly Stat InvokeEventsStat;

	// Token: 0x0400BEB1 RID: 48817
	[StaticVariableRuleIgnore]
	private static readonly Stat UpdateExactTagStat;
}
