using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Inventory;

// Token: 0x0200160A RID: 5642
[NullableContext(1)]
[Nullable(0)]
public class VersionPreheatConfigContext
{
	// Token: 0x06009F6A RID: 40810 RVA: 0x0029A668 File Offset: 0x00298868
	public string GetQuestTitleTextIdById(int id)
	{
		PreheatQuestText? config = ConfigPreheatQuestTextById.GetConfig(id, true);
		return ((config != null) ? config.GetValueOrDefault().MainTexPath : null) ?? "";
	}

	// Token: 0x06009F6B RID: 40811 RVA: 0x0029A6A4 File Offset: 0x002988A4
	public string GetQuestContentTextIdById(int id)
	{
		PreheatQuestText? config = ConfigPreheatQuestTextById.GetConfig(id, true);
		return ((config != null) ? config.GetValueOrDefault().QuestContent : null) ?? "";
	}

	// Token: 0x06009F6C RID: 40812 RVA: 0x0029A6E0 File Offset: 0x002988E0
	public string GetQuestBeforeThemeTextIdById(int id)
	{
		PreheatQuestText? config = ConfigPreheatQuestTextById.GetConfig(id, true);
		return ((config != null) ? config.GetValueOrDefault().ThemeBefore : null) ?? "";
	}

	// Token: 0x06009F6D RID: 40813 RVA: 0x0029A71C File Offset: 0x0029891C
	public string GetQuestAfterThemeTextIdById(int id)
	{
		PreheatQuestText? config = ConfigPreheatQuestTextById.GetConfig(id, true);
		return ((config != null) ? config.GetValueOrDefault().ThemeAfter : null) ?? "";
	}

	// Token: 0x06009F6E RID: 40814 RVA: 0x0029A758 File Offset: 0x00298958
	public string GetQuestPhotoPathById(int id)
	{
		PreheatQuestText? config = ConfigPreheatQuestTextById.GetConfig(id, true);
		return ((config != null) ? config.GetValueOrDefault().DisplayTex : null) ?? "";
	}

	// Token: 0x06009F6F RID: 40815 RVA: 0x0029A794 File Offset: 0x00298994
	public string GetQuestSharePhotoPathById(int id)
	{
		PreheatQuestText? config = ConfigPreheatQuestTextById.GetConfig(id, true);
		return ((config != null) ? config.GetValueOrDefault().ShareTex : null) ?? "";
	}

	// Token: 0x06009F70 RID: 40816 RVA: 0x0029A7D0 File Offset: 0x002989D0
	public int GetQuestCrestIndexById(int id)
	{
		PreheatQuestText? config = ConfigPreheatQuestTextById.GetConfig(id, true);
		if (config == null)
		{
			return 0;
		}
		return config.GetValueOrDefault().CrestIndex;
	}

	// Token: 0x06009F71 RID: 40817 RVA: 0x0029A800 File Offset: 0x00298A00
	public int GetQuestIdById(int id)
	{
		PreheatSignRe? config = ConfigPreheatSignReById.GetConfig(id, true);
		if (config == null)
		{
			return 0;
		}
		return config.GetValueOrDefault().QuestId;
	}

	// Token: 0x06009F72 RID: 40818 RVA: 0x0029A830 File Offset: 0x00298A30
	public int GetPreIdById(int id)
	{
		PreheatSignRe? config = ConfigPreheatSignReById.GetConfig(id, true);
		if (config == null)
		{
			return 0;
		}
		return config.GetValueOrDefault().PreSignId;
	}

	// Token: 0x06009F73 RID: 40819 RVA: 0x0029A860 File Offset: 0x00298A60
	public List<TItem> GetQuestRewardItemListById(int id)
	{
		List<TItem> list = new List<TItem>();
		PreheatSignRe? config = ConfigPreheatSignReById.GetConfig(id, true);
		if (config == null)
		{
			return list;
		}
		DropPackage? config2 = ConfigDropPackageById.GetConfig(config.Value.DropId, true);
		if (config2 == null)
		{
			return list;
		}
		for (int i = 0; i < config2.Value.DropPreviewLength; i++)
		{
			DicIntInt? dicIntInt = config2.Value.DropPreview(i);
			int key = dicIntInt.Value.Key;
			int value = dicIntInt.Value.Value;
			list.Add(new TItem(new InventoryDefine.GetItemData(key, 0), value));
		}
		return list;
	}

	// Token: 0x06009F74 RID: 40820 RVA: 0x0029A914 File Offset: 0x00298B14
	public string GetVoteTitleTextIdById(int id)
	{
		PreheatVote? config = ConfigPreheatVoteById.GetConfig(id, true);
		return ((config != null) ? config.GetValueOrDefault().Title : null) ?? "";
	}

	// Token: 0x06009F75 RID: 40821 RVA: 0x0029A950 File Offset: 0x00298B50
	public string GetVoteContentTextIdById(int id)
	{
		PreheatVote? config = ConfigPreheatVoteById.GetConfig(id, true);
		return ((config != null) ? config.GetValueOrDefault().Content : null) ?? "";
	}

	// Token: 0x06009F76 RID: 40822 RVA: 0x0029A98C File Offset: 0x00298B8C
	public string GetVoteLeftThemeTextIdById(int id)
	{
		PreheatVote? config = ConfigPreheatVoteById.GetConfig(id, true);
		return ((config != null) ? config.GetValueOrDefault().OptionTheme1 : null) ?? "";
	}

	// Token: 0x06009F77 RID: 40823 RVA: 0x0029A9C8 File Offset: 0x00298BC8
	public string GetVoteRightThemeTextIdById(int id)
	{
		PreheatVote? config = ConfigPreheatVoteById.GetConfig(id, true);
		return ((config != null) ? config.GetValueOrDefault().OptionTheme2 : null) ?? "";
	}

	// Token: 0x06009F78 RID: 40824 RVA: 0x0029AA04 File Offset: 0x00298C04
	public string GetVoteLeftTipsTextIdById(int id)
	{
		PreheatVote? config = ConfigPreheatVoteById.GetConfig(id, true);
		return ((config != null) ? config.GetValueOrDefault().Option1 : null) ?? "";
	}

	// Token: 0x06009F79 RID: 40825 RVA: 0x0029AA40 File Offset: 0x00298C40
	public string GetVoteRightTipsTextIdById(int id)
	{
		PreheatVote? config = ConfigPreheatVoteById.GetConfig(id, true);
		return ((config != null) ? config.GetValueOrDefault().Option2 : null) ?? "";
	}

	// Token: 0x06009F7A RID: 40826 RVA: 0x0029AA7C File Offset: 0x00298C7C
	public string GetNpcContentTextIdById(int id)
	{
		PreheatVote? config = ConfigPreheatVoteById.GetConfig(id, true);
		return ((config != null) ? config.GetValueOrDefault().NpcContent : null) ?? "";
	}

	// Token: 0x06009F7B RID: 40827 RVA: 0x0029AAB8 File Offset: 0x00298CB8
	public string GetNpcIconPathById(int id)
	{
		PreheatVote? config = ConfigPreheatVoteById.GetConfig(id, true);
		return ((config != null) ? config.GetValueOrDefault().NpcIconPath : null) ?? "";
	}

	// Token: 0x06009F7C RID: 40828 RVA: 0x0029AAF4 File Offset: 0x00298CF4
	public string GetSelfChatContentTextIdById(int id)
	{
		PreheatVote? config = ConfigPreheatVoteById.GetConfig(id, true);
		return ((config != null) ? config.GetValueOrDefault().OptionContent1 : null) ?? "";
	}

	// Token: 0x17000D70 RID: 3440
	// (get) Token: 0x06009F7D RID: 40829 RVA: 0x0029AB30 File Offset: 0x00298D30
	public string BonusPhotoPath
	{
		get
		{
			PreheatBonus? config = ConfigPreheatBonusById.GetConfig(1, true);
			return ((config != null) ? config.GetValueOrDefault().Photo : null) ?? "";
		}
	}

	// Token: 0x17000D71 RID: 3441
	// (get) Token: 0x06009F7E RID: 40830 RVA: 0x0029AB6C File Offset: 0x00298D6C
	public string BonusSharePhotoPath
	{
		get
		{
			PreheatBonus? config = ConfigPreheatBonusById.GetConfig(1, true);
			return ((config != null) ? config.GetValueOrDefault().SharePhoto : null) ?? "";
		}
	}

	// Token: 0x17000D72 RID: 3442
	// (get) Token: 0x06009F7F RID: 40831 RVA: 0x0029ABA8 File Offset: 0x00298DA8
	public string BonusQuestTitleTextId
	{
		get
		{
			PreheatBonus? config = ConfigPreheatBonusById.GetConfig(1, true);
			return ((config != null) ? config.GetValueOrDefault().Title : null) ?? "";
		}
	}

	// Token: 0x17000D73 RID: 3443
	// (get) Token: 0x06009F80 RID: 40832 RVA: 0x0029ABE4 File Offset: 0x00298DE4
	public string BonusQuestContentTextId
	{
		get
		{
			PreheatBonus? config = ConfigPreheatBonusById.GetConfig(1, true);
			return ((config != null) ? config.GetValueOrDefault().Content : null) ?? "";
		}
	}

	// Token: 0x17000D74 RID: 3444
	// (get) Token: 0x06009F81 RID: 40833 RVA: 0x0029AC20 File Offset: 0x00298E20
	public string BonusNpcIconPath
	{
		get
		{
			PreheatBonus? config = ConfigPreheatBonusById.GetConfig(1, true);
			return ((config != null) ? config.GetValueOrDefault().NpcIconPath : null) ?? "";
		}
	}

	// Token: 0x17000D75 RID: 3445
	// (get) Token: 0x06009F82 RID: 40834 RVA: 0x0029AC5C File Offset: 0x00298E5C
	public string BonusNpcContentTextId
	{
		get
		{
			PreheatBonus? config = ConfigPreheatBonusById.GetConfig(1, true);
			return ((config != null) ? config.GetValueOrDefault().NpcContent : null) ?? "";
		}
	}

	// Token: 0x17000D76 RID: 3446
	// (get) Token: 0x06009F83 RID: 40835 RVA: 0x0029AC98 File Offset: 0x00298E98
	public string BonusTextId
	{
		get
		{
			PreheatBonus? config = ConfigPreheatBonusById.GetConfig(1, true);
			return ((config != null) ? config.GetValueOrDefault().BonusTxt : null) ?? "";
		}
	}

	// Token: 0x17000D77 RID: 3447
	// (get) Token: 0x06009F84 RID: 40836 RVA: 0x0029ACD4 File Offset: 0x00298ED4
	public int BonusCrestIndex
	{
		get
		{
			PreheatBonus? config = ConfigPreheatBonusById.GetConfig(1, true);
			if (config == null)
			{
				return 0;
			}
			return config.GetValueOrDefault().CrestIndex;
		}
	}

	// Token: 0x17000D78 RID: 3448
	// (get) Token: 0x06009F85 RID: 40837 RVA: 0x0029AD03 File Offset: 0x00298F03
	public IReadOnlyList<PreheatSignRe> AllQuestCfg
	{
		get
		{
			return ConfigPreheatSignReAll.GetConfigList(true) ?? new List<PreheatSignRe>();
		}
	}
}
