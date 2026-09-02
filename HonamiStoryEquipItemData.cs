using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.HonamiStory;

// Token: 0x02001ED2 RID: 7890
[NullableContext(1)]
[Nullable(0)]
public class HonamiStoryEquipItemData : HonamiStoryItemDataBase
{
	// Token: 0x0600E98B RID: 59787 RVA: 0x003F57C4 File Offset: 0x003F39C4
	public override void Init(HonamiStoryItemInfo itemInfo)
	{
		base.Init(itemInfo);
		HonamiStoryEquipItemInfo honamiStoryEquipItemInfo = itemInfo.HonamiStoryEquipItemInfo;
		if (honamiStoryEquipItemInfo == null)
		{
			return;
		}
		this.MainPropLibraryId = honamiStoryEquipItemInfo.MainPropLibraryId;
		this.OriBuffTempId = honamiStoryEquipItemInfo.OriBuffTempId.ToList<int>();
		this.ChildBuffTempId = honamiStoryEquipItemInfo.ChildBuffTempId.ToList<int>();
		HonamiStoryEquip? config = this.GetConfig();
		this.RoleId = config.Value.RoleId;
		this.GroupId = config.Value.GroupId;
		this.BaseEnhance = config.Value.EnhanceLevel;
		this.WeaponTag = config.Value.Tag;
		this.WeaponEnhance = config.Value.TagEnhanceLevel;
		this.RoleEnhance = config.Value.RoleEnhanceLevel;
	}

	// Token: 0x0600E98C RID: 59788 RVA: 0x003F5896 File Offset: 0x003F3A96
	public HonamiStoryEquip? GetConfig()
	{
		return ConfigBase<HonamiStoryConfig>.Instance.GetHonamiStoryEquip(base.GetItemId());
	}

	// Token: 0x0600E98D RID: 59789 RVA: 0x003F58A8 File Offset: 0x003F3AA8
	public int GetRoleId()
	{
		return this.RoleId;
	}

	// Token: 0x0600E98E RID: 59790 RVA: 0x003F58B0 File Offset: 0x003F3AB0
	public int GetGroupId()
	{
		return this.GroupId;
	}

	// Token: 0x0600E98F RID: 59791 RVA: 0x003F58B8 File Offset: 0x003F3AB8
	public int GetBaseEnhance()
	{
		return this.BaseEnhance;
	}

	// Token: 0x0600E990 RID: 59792 RVA: 0x003F58C0 File Offset: 0x003F3AC0
	public int GetWeaponTag()
	{
		return this.WeaponTag;
	}

	// Token: 0x0600E991 RID: 59793 RVA: 0x003F58C8 File Offset: 0x003F3AC8
	public int GetWeaponEnhance()
	{
		return this.WeaponEnhance;
	}

	// Token: 0x0600E992 RID: 59794 RVA: 0x003F58D0 File Offset: 0x003F3AD0
	public int GetRoleEnhance()
	{
		return this.RoleEnhance;
	}

	// Token: 0x0600E993 RID: 59795 RVA: 0x003F58D8 File Offset: 0x003F3AD8
	public int[] GetMainPropList()
	{
		return ConfigBase<HonamiStoryConfig>.Instance.GetHonamiStoryPropLibrary(this.MainPropLibraryId);
	}

	// Token: 0x0600E994 RID: 59796 RVA: 0x003F58EC File Offset: 0x003F3AEC
	public List<string> GetOriBuffDescList()
	{
		List<string> list = new List<string>();
		foreach (int libraryId in this.OriBuffTempId)
		{
			string honamiStoryBuffTempDescFromLibrary = ConfigBase<HonamiStoryConfig>.Instance.GetHonamiStoryBuffTempDescFromLibrary(libraryId);
			if (honamiStoryBuffTempDescFromLibrary != null)
			{
				list.Add(honamiStoryBuffTempDescFromLibrary);
			}
		}
		return list;
	}

	// Token: 0x0600E995 RID: 59797 RVA: 0x003F5958 File Offset: 0x003F3B58
	public List<IHonamiStoryTipsBuffInfo> GetBuffTempIdList(bool fromTeamView = false)
	{
		List<IHonamiStoryTipsBuffInfo> list = new List<IHonamiStoryTipsBuffInfo>();
		HonamiStoryEquip? config = this.GetConfig();
		int? roleId = (config.Value.RoleId == 0) ? null : new int?(config.Value.RoleId);
		int? tagId = (config.Value.Tag == 0) ? null : new int?(config.Value.Tag);
		foreach (int id in this.OriBuffTempId)
		{
			int? honamiStoryBuffTempLibrary = ConfigBase<HonamiStoryConfig>.Instance.GetHonamiStoryBuffTempLibrary(id);
			if (honamiStoryBuffTempLibrary != null)
			{
				HonamiStoryTipsBuffInfo item = new HonamiStoryTipsBuffInfo
				{
					BuffId = honamiStoryBuffTempLibrary.Value,
					TagId = tagId,
					RoleId = roleId,
					FromTeamView = fromTeamView
				};
				list.Add(item);
			}
		}
		return list;
	}

	// Token: 0x0600E996 RID: 59798 RVA: 0x003F5A64 File Offset: 0x003F3C64
	public List<string> GetChildBuffDescList()
	{
		List<string> list = new List<string>();
		foreach (int libraryId in this.ChildBuffTempId)
		{
			string honamiStoryBuffTempDescFromLibrary = ConfigBase<HonamiStoryConfig>.Instance.GetHonamiStoryBuffTempDescFromLibrary(libraryId);
			if (honamiStoryBuffTempDescFromLibrary != null)
			{
				list.Add(honamiStoryBuffTempDescFromLibrary);
			}
		}
		return list;
	}

	// Token: 0x040070A7 RID: 28839
	protected int MainPropLibraryId = -1;

	// Token: 0x040070A8 RID: 28840
	protected List<int> OriBuffTempId = new List<int>();

	// Token: 0x040070A9 RID: 28841
	protected List<int> ChildBuffTempId = new List<int>();

	// Token: 0x040070AA RID: 28842
	protected int GroupId = -1;

	// Token: 0x040070AB RID: 28843
	protected int RoleId = -1;

	// Token: 0x040070AC RID: 28844
	protected int RoleEnhance = -1;

	// Token: 0x040070AD RID: 28845
	protected int BaseEnhance = -1;

	// Token: 0x040070AE RID: 28846
	protected int WeaponTag = -1;

	// Token: 0x040070AF RID: 28847
	protected int WeaponEnhance = -1;
}
