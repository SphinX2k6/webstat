using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02000C0F RID: 3087
[NullableContext(1)]
[Nullable(0)]
public class GameplayTagUtils : IStaticVariableResetter
{
	// Token: 0x06003344 RID: 13124 RVA: 0x000285A5 File Offset: 0x000267A5
	static GameplayTagUtils()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(GameplayTagUtils.CreateStaticDefaultValue), new Action(GameplayTagUtils.ResetStaticDefaultValue));
	}

	// Token: 0x06003345 RID: 13125 RVA: 0x000285E0 File Offset: 0x000267E0
	public static int GetTagIdByName(string tagName)
	{
		int result;
		if (!GameplayTagDefine.EGameplayTagId.TryGetValue(tagName, out result))
		{
			result = UGASBPLibrary.FnvHash(tagName);
		}
		return result;
	}

	// Token: 0x06003346 RID: 13126 RVA: 0x00028604 File Offset: 0x00026804
	[NullableContext(2)]
	public static string GetNameByTagId(int tagId)
	{
		FGameplayTag? gameplayTagById = GameplayTagUtils.GetGameplayTagById(tagId);
		if (gameplayTagById == null)
		{
			return null;
		}
		string text = gameplayTagById.Value.OriginalTagName().ToString();
		if (!string.IsNullOrEmpty(text) && text != "None")
		{
			return text;
		}
		return gameplayTagById.Value.TagName.ToString();
	}

	// Token: 0x06003347 RID: 13127 RVA: 0x0002866F File Offset: 0x0002686F
	public static FGameplayTag? GetGameplayTagByName(string tagName)
	{
		return GameplayTagUtils.GetGameplayTagById(GameplayTagUtils.GetTagIdByName(tagName));
	}

	// Token: 0x06003348 RID: 13128 RVA: 0x0002867C File Offset: 0x0002687C
	public static FGameplayTag? GetGameplayTagById(int tagId)
	{
		FGameplayTag? fgameplayTag;
		if (!GameplayTagUtils.GameplayTagMap.TryGetValue(tagId, out fgameplayTag))
		{
			fgameplayTag = new FGameplayTag?(UGASBPLibrary.GetGameplayTagFromTagHash(tagId));
			GameplayTagUtils.GameplayTagMap[tagId] = fgameplayTag;
		}
		if (fgameplayTag == null)
		{
			if (!GameplayTagUtils.ErrorIdSet.Contains(tagId))
			{
				GameplayTagUtils.ErrorIdSet.Add(tagId);
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Game;
				ELogAuthor author = ELogAuthor.WLJ;
				string message = "TagId对应的GameplayTag不存在，请检查GameplayTag设置";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("TagId", tagId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			return null;
		}
		return fgameplayTag;
	}

	// Token: 0x06003349 RID: 13129 RVA: 0x0002870A File Offset: 0x0002690A
	public static int GetParentTag(int tag)
	{
		return GameplayTagDefine.ParentTagIdMap.GetValueOrDefault(tag, 0);
	}

	// Token: 0x0600334A RID: 13130 RVA: 0x00028718 File Offset: 0x00026918
	public static bool IsChildTag(int tagA, int tagB)
	{
		if (tagA == tagB)
		{
			return true;
		}
		IReadOnlyDictionary<int, int> parentTagIdMap = GameplayTagDefine.ParentTagIdMap;
		int key = tagA;
		int num;
		while (parentTagIdMap.TryGetValue(key, out num))
		{
			if (num == tagB)
			{
				return true;
			}
			key = num;
		}
		return false;
	}

	// Token: 0x0600334B RID: 13131 RVA: 0x0002874C File Offset: 0x0002694C
	[NullableContext(2)]
	public static bool Contains(IEnumerable<int> tagContainer, int tag)
	{
		if (tagContainer == null)
		{
			return false;
		}
		foreach (int tagB in tagContainer)
		{
			if (GameplayTagUtils.IsChildTag(tag, tagB))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x0600334C RID: 13132 RVA: 0x000287A4 File Offset: 0x000269A4
	[NullableContext(2)]
	public static bool ContainsExact(IEnumerable<int> tagContainer, int tag)
	{
		if (tagContainer == null)
		{
			return false;
		}
		using (IEnumerator<int> enumerator = tagContainer.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current == tag)
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x0600334D RID: 13133 RVA: 0x000287F4 File Offset: 0x000269F4
	[NullableContext(2)]
	public static bool HasAll(IEnumerable<int> tagContainerA, IEnumerable<int> tagContainerB)
	{
		if (tagContainerB == null)
		{
			return true;
		}
		foreach (int tag in tagContainerB)
		{
			if (!GameplayTagUtils.Contains(tagContainerA, tag))
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x0600334E RID: 13134 RVA: 0x0002884C File Offset: 0x00026A4C
	[NullableContext(2)]
	public static bool HasAny(IEnumerable<int> tagContainerA, IEnumerable<int> tagContainerB)
	{
		if (tagContainerB == null)
		{
			return false;
		}
		foreach (int tag in tagContainerB)
		{
			if (GameplayTagUtils.Contains(tagContainerA, tag))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x0600334F RID: 13135 RVA: 0x000288A4 File Offset: 0x00026AA4
	public static List<int> ConvertFromUeContainer([Nullable(2)] FGameplayTagContainer ueContainer)
	{
		if (ueContainer == null)
		{
			return new List<int>();
		}
		List<int> list = new List<int>();
		int num = ueContainer.GameplayTags.Num();
		for (int i = 0; i < num; i++)
		{
			list.Add(ueContainer.GameplayTags.Get(i).TagId());
		}
		return list;
	}

	// Token: 0x06003350 RID: 13136 RVA: 0x000288F6 File Offset: 0x00026AF6
	public static bool IsValidTag(FGameplayTag? gameplayTag)
	{
		return gameplayTag != null && gameplayTag.Value.TagName != FName.NAME_None;
	}

	// Token: 0x06003351 RID: 13137 RVA: 0x00028919 File Offset: 0x00026B19
	public static void CreateStaticDefaultValue()
	{
		GameplayTagUtils.ErrorIdSet = new HashSet<int>();
		GameplayTagUtils.GameplayTagMap = new Dictionary<int, FGameplayTag?>();
	}

	// Token: 0x06003352 RID: 13138 RVA: 0x0002892F File Offset: 0x00026B2F
	public static void ResetStaticDefaultValue()
	{
		GameplayTagUtils.ErrorIdSet = null;
		GameplayTagUtils.GameplayTagMap = null;
	}

	// Token: 0x06003353 RID: 13139 RVA: 0x00028940 File Offset: 0x00026B40
	public static IList<int> GameplayTagsToTagIds(TArray<FGameplayTag> tags)
	{
		List<int> list = new List<int>();
		if (tags.Num() > 0)
		{
			for (int i = 0; i < tags.Num(); i++)
			{
				list.Add(tags.Get(i).TagId());
			}
		}
		return list;
	}

	// Token: 0x06003354 RID: 13140 RVA: 0x00028980 File Offset: 0x00026B80
	public static IList<string> GameplayTagsToTagNames(TArray<FGameplayTag> tags)
	{
		List<string> list = new List<string>();
		if (tags.Num() > 0)
		{
			for (int i = 0; i < tags.Num(); i++)
			{
				list.Add(tags.Get(i).TagName.ToString());
			}
		}
		return list;
	}

	// Token: 0x040005E2 RID: 1506
	private static HashSet<int> ErrorIdSet;

	// Token: 0x040005E3 RID: 1507
	[StaticVariableRuleIgnore]
	private static readonly Stat Stat = Stat.Create("GameplayTagUtils.FnvHash", "", "");

	// Token: 0x040005E4 RID: 1508
	private static Dictionary<int, FGameplayTag?> GameplayTagMap;
}
