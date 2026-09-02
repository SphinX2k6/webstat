using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;

// Token: 0x020024B3 RID: 9395
[NullableContext(1)]
[Nullable(0)]
public class PhantomInteractGridData : IPhantomInteractGridData
{
	// Token: 0x17001707 RID: 5895
	// (get) Token: 0x060123B5 RID: 74677 RVA: 0x00504BB9 File Offset: 0x00502DB9
	// (set) Token: 0x060123B6 RID: 74678 RVA: 0x00504BC1 File Offset: 0x00502DC1
	public int MonsterId { get; set; }

	// Token: 0x17001708 RID: 5896
	// (get) Token: 0x060123B7 RID: 74679 RVA: 0x00504BCA File Offset: 0x00502DCA
	// (set) Token: 0x060123B8 RID: 74680 RVA: 0x00504BD2 File Offset: 0x00502DD2
	public int MonsterInfoId { get; set; }

	// Token: 0x17001709 RID: 5897
	// (get) Token: 0x060123B9 RID: 74681 RVA: 0x00504BDB File Offset: 0x00502DDB
	// (set) Token: 0x060123BA RID: 74682 RVA: 0x00504BE3 File Offset: 0x00502DE3
	public List<int> SkinIds { get; set; } = new List<int>();

	// Token: 0x1700170A RID: 5898
	// (get) Token: 0x060123BB RID: 74683 RVA: 0x00504BEC File Offset: 0x00502DEC
	// (set) Token: 0x060123BC RID: 74684 RVA: 0x00504BF4 File Offset: 0x00502DF4
	public int EquippedSkin { get; set; }

	// Token: 0x1700170B RID: 5899
	// (get) Token: 0x060123BD RID: 74685 RVA: 0x00504BFD File Offset: 0x00502DFD
	// (set) Token: 0x060123BE RID: 74686 RVA: 0x00504C05 File Offset: 0x00502E05
	public bool IsSpecial { get; set; }

	// Token: 0x1700170C RID: 5900
	// (get) Token: 0x060123BF RID: 74687 RVA: 0x00504C0E File Offset: 0x00502E0E
	// (set) Token: 0x060123C0 RID: 74688 RVA: 0x00504C16 File Offset: 0x00502E16
	public int Cost { get; set; }

	// Token: 0x1700170D RID: 5901
	// (get) Token: 0x060123C1 RID: 74689 RVA: 0x00504C1F File Offset: 0x00502E1F
	// (set) Token: 0x060123C2 RID: 74690 RVA: 0x00504C27 File Offset: 0x00502E27
	[Nullable(2)]
	public string Name { [NullableContext(2)] get; [NullableContext(2)] set; }

	// Token: 0x1700170E RID: 5902
	// (get) Token: 0x060123C3 RID: 74691 RVA: 0x00504C30 File Offset: 0x00502E30
	// (set) Token: 0x060123C4 RID: 74692 RVA: 0x00504C38 File Offset: 0x00502E38
	public bool IsUnlocked { get; set; }

	// Token: 0x1700170F RID: 5903
	// (get) Token: 0x060123C5 RID: 74693 RVA: 0x00504C41 File Offset: 0x00502E41
	// (set) Token: 0x060123C6 RID: 74694 RVA: 0x00504C49 File Offset: 0x00502E49
	public List<int> InteractAreaList { get; set; } = new List<int>();

	// Token: 0x17001710 RID: 5904
	// (get) Token: 0x060123C7 RID: 74695 RVA: 0x00504C52 File Offset: 0x00502E52
	// (set) Token: 0x060123C8 RID: 74696 RVA: 0x00504C5A File Offset: 0x00502E5A
	public int InSlotIndex { get; set; } = -1;

	// Token: 0x17001711 RID: 5905
	// (get) Token: 0x060123C9 RID: 74697 RVA: 0x00504C63 File Offset: 0x00502E63
	// (set) Token: 0x060123CA RID: 74698 RVA: 0x00504C6B File Offset: 0x00502E6B
	[Nullable(2)]
	public string IconPath { [NullableContext(2)] get; [NullableContext(2)] set; }

	// Token: 0x17001712 RID: 5906
	// (get) Token: 0x060123CB RID: 74699 RVA: 0x00504C74 File Offset: 0x00502E74
	// (set) Token: 0x060123CC RID: 74700 RVA: 0x00504C7C File Offset: 0x00502E7C
	public bool HasSkin { get; set; }

	// Token: 0x17001713 RID: 5907
	// (get) Token: 0x060123CD RID: 74701 RVA: 0x00504C85 File Offset: 0x00502E85
	// (set) Token: 0x060123CE RID: 74702 RVA: 0x00504C8D File Offset: 0x00502E8D
	public int GetWayConfigId { get; set; }

	// Token: 0x17001714 RID: 5908
	// (get) Token: 0x060123CF RID: 74703 RVA: 0x00504C96 File Offset: 0x00502E96
	// (set) Token: 0x060123D0 RID: 74704 RVA: 0x00504C9E File Offset: 0x00502E9E
	public int SortId { get; set; }

	// Token: 0x060123D1 RID: 74705 RVA: 0x00504CA8 File Offset: 0x00502EA8
	public void LoadSkinId(int skinId)
	{
		this.EquippedSkin = skinId;
		int monsterId = this.MonsterId;
		bool flag = false;
		if (skinId != 0)
		{
			Aki.Config.PhantomItem? phantomItemById = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomItemById(skinId);
			if (phantomItemById != null)
			{
				monsterId = phantomItemById.Value.MonsterId;
				this.IconPath = phantomItemById.Value.IconMiddle;
				flag = true;
			}
			else
			{
				monsterId = -1;
			}
		}
		CalabashDevelopReward? calabashDevelopRewardByMonsterId = ConfigBase<CalabashConfig>.Instance.GetCalabashDevelopRewardByMonsterId(monsterId);
		int num = (calabashDevelopRewardByMonsterId != null) ? calabashDevelopRewardByMonsterId.Value.MonsterInfoId : 0;
		Aki.Config.MonsterInfo? monsterInfoConfig = ConfigBase<MonsterInfoConfig>.Instance.GetMonsterInfoConfig(num);
		if (monsterInfoConfig != null)
		{
			this.Name = monsterInfoConfig.Value.Name;
		}
		this.MonsterInfoId = num;
		if (flag)
		{
			return;
		}
		IReadOnlyList<Aki.Config.PhantomItem> phantomItemByMonsterId = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomItemByMonsterId(this.MonsterId);
		if (phantomItemByMonsterId == null || phantomItemByMonsterId.Count <= 0)
		{
			return;
		}
		this.IconPath = phantomItemByMonsterId[0].IconMiddle;
	}

	// Token: 0x060123D2 RID: 74706 RVA: 0x00504DA4 File Offset: 0x00502FA4
	public void LoadData(UnlockIllustratedPhantom proto)
	{
		int monsterId = proto.MonsterId;
		int monsterId2 = monsterId;
		if (proto.EqupiedSkin > 0)
		{
			monsterId2 = proto.EqupiedSkin;
		}
		CalabashDevelopReward? calabashDevelopRewardByMonsterId = ConfigBase<CalabashConfig>.Instance.GetCalabashDevelopRewardByMonsterId(monsterId2);
		IReadOnlyList<Aki.Config.PhantomItem> phantomItemByMonsterId = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomItemByMonsterId(monsterId);
		if (phantomItemByMonsterId == null || phantomItemByMonsterId.Count <= 0)
		{
			return;
		}
		Aki.Config.PhantomItem phantomItem = phantomItemByMonsterId[0];
		this.IsUnlocked = true;
		this.HasSkin = PhantomInteractGridData.CheckHasSkin(proto.MonsterId);
		this.MonsterId = monsterId;
		this.SkinIds = new List<int>
		{
			0
		};
		foreach (int item in proto.SkinIds)
		{
			this.SkinIds.Add(item);
		}
		this.GetWayConfigId = ((calabashDevelopRewardByMonsterId != null) ? calabashDevelopRewardByMonsterId.Value.ItemAccess : 0);
		this.SortId = ((calabashDevelopRewardByMonsterId != null) ? calabashDevelopRewardByMonsterId.Value.SortId : 0);
		this.LoadSkinId(proto.EqupiedSkin);
		this.IsSpecial = (calabashDevelopRewardByMonsterId != null && calabashDevelopRewardByMonsterId.Value.IsWorldInteractable);
		this.InteractAreaList = new List<int>();
		if (calabashDevelopRewardByMonsterId != null)
		{
			int[] interactAreaListArray = calabashDevelopRewardByMonsterId.Value.GetInteractAreaListArray();
			if (interactAreaListArray != null)
			{
				foreach (int item2 in interactAreaListArray)
				{
					this.InteractAreaList.Add(item2);
				}
			}
		}
		int rarity = phantomItem.Rarity;
		PhantomRarity? phantomRareConfig = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomRareConfig(rarity);
		if (phantomRareConfig != null)
		{
			this.Cost = phantomRareConfig.Value.Cost;
		}
	}

	// Token: 0x060123D3 RID: 74707 RVA: 0x00504F74 File Offset: 0x00503174
	public void LoadLockData(int monsterId)
	{
		CalabashDevelopReward? calabashDevelopRewardByMonsterId = ConfigBase<CalabashConfig>.Instance.GetCalabashDevelopRewardByMonsterId(monsterId);
		int monsterInfoId = calabashDevelopRewardByMonsterId.Value.MonsterInfoId;
		Aki.Config.MonsterInfo? monsterInfoConfig = ConfigBase<MonsterInfoConfig>.Instance.GetMonsterInfoConfig(monsterInfoId);
		IReadOnlyList<Aki.Config.PhantomItem> phantomItemByMonsterId = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomItemByMonsterId(monsterId);
		if (phantomItemByMonsterId == null || phantomItemByMonsterId.Count <= 0)
		{
			return;
		}
		Aki.Config.PhantomItem phantomItem = phantomItemByMonsterId[0];
		this.IsUnlocked = false;
		this.MonsterInfoId = monsterInfoId;
		this.MonsterId = monsterId;
		this.SkinIds = new List<int>();
		this.LoadSkinId(0);
		this.EquippedSkin = 0;
		this.IsSpecial = calabashDevelopRewardByMonsterId.Value.IsWorldInteractable;
		this.GetWayConfigId = calabashDevelopRewardByMonsterId.Value.ItemAccess;
		this.SortId = calabashDevelopRewardByMonsterId.Value.SortId;
		this.Name = monsterInfoConfig.Value.Name;
		int rarity = phantomItem.Rarity;
		this.Cost = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomRareConfig(rarity).Value.Cost;
		this.InteractAreaList = new List<int>();
		int[] interactAreaListArray = calabashDevelopRewardByMonsterId.Value.GetInteractAreaListArray();
		if (interactAreaListArray != null)
		{
			foreach (int item in interactAreaListArray)
			{
				this.InteractAreaList.Add(item);
			}
		}
		this.HasSkin = false;
	}

	// Token: 0x060123D4 RID: 74708 RVA: 0x005050D4 File Offset: 0x005032D4
	private static bool CheckHasSkin(int monsterId)
	{
		IReadOnlyList<Aki.Config.PhantomItem> phantomItemByParentMonsterId = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomItemByParentMonsterId(monsterId);
		return phantomItemByParentMonsterId != null && phantomItemByParentMonsterId.Count > 0;
	}
}
