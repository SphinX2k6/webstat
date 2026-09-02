using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02001C93 RID: 7315
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class FriendConfig : ConfigBase<FriendConfig>
{
	// Token: 0x0600D60A RID: 54794 RVA: 0x003926CC File Offset: 0x003908CC
	public List<FriendFilter> GetAllFilterConfigDuplicate()
	{
		IReadOnlyList<FriendFilter> configList = ConfigFriendFilterAll.GetConfigList(true);
		if (configList != null)
		{
			List<FriendFilter> list = new List<FriendFilter>();
			foreach (FriendFilter item in configList)
			{
				list.Add(item);
			}
			return list;
		}
		return new List<FriendFilter>();
	}

	// Token: 0x0600D60B RID: 54795 RVA: 0x0039272C File Offset: 0x0039092C
	[NullableContext(2)]
	public string GetHeadIconPath(int headPhotoId)
	{
		HeadIcon? config = ConfigHeadIconById.GetConfig(headPhotoId, true);
		if (config != null)
		{
			return config.Value.IconPath;
		}
		return null;
	}

	// Token: 0x0600D60C RID: 54796 RVA: 0x0039275C File Offset: 0x0039095C
	public int GetFriendLimitByViewType(EFriendFilter viewType)
	{
		string id = "";
		switch (viewType)
		{
		case EFriendFilter.FriendList:
			id = "friend_list_limit";
			break;
		case EFriendFilter.FriendRequest:
			id = "friend_apply_list_limit";
			break;
		case EFriendFilter.RecentMultiple:
			id = "RecentlyTeamLimit";
			break;
		}
		return ConfigCommonParamById.GetIntConfig(id).Value;
	}

	// Token: 0x0600D60D RID: 54797 RVA: 0x003927AC File Offset: 0x003909AC
	public List<int> GetProcessViewFunctionList()
	{
		IEnumerable<PersonalTips> configList = ConfigPersonalTipsByFunctionId.GetConfigList(1, true);
		List<int> list = new List<int>();
		foreach (PersonalTips personalTips in configList)
		{
			list.Add(personalTips.Id);
		}
		list.Sort(this.SortProcessFunctionList);
		return list;
	}

	// Token: 0x0600D60E RID: 54798 RVA: 0x00392814 File Offset: 0x00390A14
	public int GetDefaultBackgroundCardId()
	{
		return ConfigCommonParamById.GetIntConfig("default_background_card").Value;
	}

	// Token: 0x04006593 RID: 26003
	private readonly Comparison<int> SortProcessFunctionList = delegate(int a, int b)
	{
		PersonalTips? config = ConfigPersonalTipsById.GetConfig(a, true);
		PersonalTips? config2 = ConfigPersonalTipsById.GetConfig(b, true);
		return config.Value.Sort - config2.Value.Sort;
	};
}
