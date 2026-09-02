using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;

// Token: 0x020027BA RID: 10170
[NullableContext(1)]
[Nullable(0)]
public class RoleFavorData : RoleModuleDataBase
{
	// Token: 0x060141B5 RID: 82357 RVA: 0x0059DD92 File Offset: 0x0059BF92
	public RoleFavorData(int roleId) : base(roleId)
	{
	}

	// Token: 0x060141B6 RID: 82358 RVA: 0x0059DDA6 File Offset: 0x0059BFA6
	public int GetFavorLevel()
	{
		return this.Level;
	}

	// Token: 0x060141B7 RID: 82359 RVA: 0x0059DDAE File Offset: 0x0059BFAE
	public void SetFavorLevel(int level)
	{
		this.Level = level;
	}

	// Token: 0x060141B8 RID: 82360 RVA: 0x0059DDB7 File Offset: 0x0059BFB7
	public int GetFavorExp()
	{
		return this.Exp;
	}

	// Token: 0x060141B9 RID: 82361 RVA: 0x0059DDBF File Offset: 0x0059BFBF
	public void SetFavorExp(int exp)
	{
		this.Exp = exp;
		Singleton<EventSystem>.Instance.Emit(EEventName.RoleFavorExpChange);
	}

	// Token: 0x060141BA RID: 82362 RVA: 0x0059DDD8 File Offset: 0x0059BFD8
	public void UpdateRoleFavorData(EFavorContentType favorContentType, FavorItem[] favorItemList)
	{
		this.FavorItemMap[favorContentType] = this.BuildFavorItemInfoList(favorItemList);
	}

	// Token: 0x060141BB RID: 82363 RVA: 0x0059DDF0 File Offset: 0x0059BFF0
	public void UpdateUnlockId(FavorItemType favorItemType, int roleId, int itemId)
	{
		EFavorContentType value = this.GetClientFavorTabType(favorItemType).Value;
		FavorItemInfo[] array = this.FavorItemMap[value];
		int num = array.Length;
		for (int i = 0; i < num; i++)
		{
			FavorItemInfo favorItemInfo = array[i];
			if (favorItemInfo.Id == itemId)
			{
				favorItemInfo.Status = EFavorItemStatus.ItemUnLocked;
			}
		}
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.UpdateRoleFavorData, this.RoleId);
		Singleton<EventSystem>.Instance.Emit<int, int>(EEventName.UnLockRoleFavorItem, roleId, itemId);
	}

	// Token: 0x060141BC RID: 82364 RVA: 0x0059DE70 File Offset: 0x0059C070
	public void UpdateCanUnlockId(FavorItemType favorItemType, int itemId)
	{
		EFavorContentType value = this.GetClientFavorTabType(favorItemType).Value;
		FavorItemInfo[] array2;
		FavorItemInfo[] array = this.FavorItemMap.TryGetValue(value, out array2) ? array2 : null;
		if (array == null)
		{
			List<FavorItemInfo> list = new List<FavorItemInfo>();
			list.Add(new FavorItemInfo(itemId, EFavorItemStatus.ItemCanUnLock));
			this.FavorItemMap[value] = list.ToArray();
			return;
		}
		int num = array.Length;
		bool flag = false;
		for (int i = 0; i < num; i++)
		{
			FavorItemInfo favorItemInfo = array[i];
			if (favorItemInfo.Id == itemId)
			{
				flag = true;
				favorItemInfo.Status = EFavorItemStatus.ItemCanUnLock;
				break;
			}
		}
		if (!flag)
		{
			List<FavorItemInfo> list2 = new List<FavorItemInfo>(array);
			list2.Add(new FavorItemInfo(itemId, EFavorItemStatus.ItemCanUnLock));
			this.FavorItemMap[value] = list2.ToArray();
		}
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.UpdateRoleFavorData, this.RoleId);
	}

	// Token: 0x060141BD RID: 82365 RVA: 0x0059DF48 File Offset: 0x0059C148
	private FavorItemInfo[] BuildFavorItemInfoList(FavorItem[] favorItem)
	{
		List<FavorItemInfo> list = new List<FavorItemInfo>();
		int num = favorItem.Length;
		for (int i = 0; i < num; i++)
		{
			FavorItem favorItem2 = favorItem[i];
			list.Add(this.BuildFavorItemInfo(favorItem2));
		}
		return list.ToArray();
	}

	// Token: 0x060141BE RID: 82366 RVA: 0x0059DF84 File Offset: 0x0059C184
	private FavorItemInfo BuildFavorItemInfo(FavorItem favorItem)
	{
		EFavorItemStatus? clientFavorItemStatus = this.GetClientFavorItemStatus(favorItem.Status);
		return new FavorItemInfo(favorItem.Id, clientFavorItemStatus.Value);
	}

	// Token: 0x060141BF RID: 82367 RVA: 0x0059DFB0 File Offset: 0x0059C1B0
	public EFavorItemStatus GetFavorItemState(int id, EFavorContentType type)
	{
		FavorItemInfo[] array2;
		FavorItemInfo[] array = this.FavorItemMap.TryGetValue(type, out array2) ? array2 : null;
		if (array == null)
		{
			return EFavorItemStatus.ItemLocked;
		}
		int num = array.Length;
		for (int i = 0; i < num; i++)
		{
			FavorItemInfo favorItemInfo = array[i];
			if (favorItemInfo.Id == id)
			{
				return favorItemInfo.Status;
			}
		}
		return EFavorItemStatus.ItemLocked;
	}

	// Token: 0x060141C0 RID: 82368 RVA: 0x0059E000 File Offset: 0x0059C200
	public EFavorItemStatus? GetClientFavorItemStatus(FavorItemStatus favorItemStatus)
	{
		EFavorItemStatus? result = null;
		if (favorItemStatus == FavorItemStatus.ItemLocked)
		{
			result = new EFavorItemStatus?(EFavorItemStatus.ItemLocked);
		}
		else if (favorItemStatus == FavorItemStatus.ItemCanUnLock)
		{
			result = new EFavorItemStatus?(EFavorItemStatus.ItemCanUnLock);
		}
		else if (favorItemStatus == FavorItemStatus.ItemUnLocked)
		{
			result = new EFavorItemStatus?(EFavorItemStatus.ItemUnLocked);
		}
		return result;
	}

	// Token: 0x060141C1 RID: 82369 RVA: 0x0059E040 File Offset: 0x0059C240
	public EFavorContentType? GetClientFavorTabType(FavorItemType favorItemType)
	{
		if (favorItemType == FavorItemType.Word)
		{
			return new EFavorContentType?(EFavorContentType.Voice);
		}
		if (favorItemType == FavorItemType.Story)
		{
			return new EFavorContentType?(EFavorContentType.ExperienceStory);
		}
		if (favorItemType == FavorItemType.Goods)
		{
			return new EFavorContentType?(EFavorContentType.PreciousItem);
		}
		return null;
	}

	// Token: 0x060141C2 RID: 82370 RVA: 0x0059E078 File Offset: 0x0059C278
	public bool IsExistCanUnlockFavorItem()
	{
		foreach (EFavorContentType favorContentType in this.FavorItemMap.Keys)
		{
			if (this.IsFavorItemCanUnlock(favorContentType))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x060141C3 RID: 82371 RVA: 0x0059E0DC File Offset: 0x0059C2DC
	public bool IsFavorItemCanUnlock(EFavorContentType favorContentType)
	{
		if (favorContentType == EFavorContentType.Action)
		{
			return ModelBase<MotionModel>.Instance.IfRoleMotionCanUnlock(this.RoleId);
		}
		FavorItemInfo[] array2;
		FavorItemInfo[] array = this.FavorItemMap.TryGetValue(favorContentType, out array2) ? array2 : null;
		if (array == null)
		{
			return false;
		}
		int num = array.Length;
		for (int i = 0; i < num; i++)
		{
			if (array[i].Status == EFavorItemStatus.ItemCanUnLock)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x060141C4 RID: 82372 RVA: 0x0059E138 File Offset: 0x0059C338
	public int[] GetUnlockActionIndexList()
	{
		List<int> list = new List<int>();
		FavorItemInfo[] array2;
		FavorItemInfo[] array = this.FavorItemMap.TryGetValue(EFavorContentType.Action, out array2) ? array2 : null;
		if (array == null)
		{
			return list.ToArray();
		}
		int num = array.Length;
		for (int i = 0; i < num; i++)
		{
			FavorItemInfo favorItemInfo = array[i];
			if (favorItemInfo.Status == EFavorItemStatus.ItemUnLocked)
			{
				list.Add(ConfigBase<MotionConfig>.Instance.GetMotionConfig(favorItemInfo.Id).Value.Sort);
			}
		}
		return list.ToArray();
	}

	// Token: 0x04009C6E RID: 40046
	protected int Level;

	// Token: 0x04009C6F RID: 40047
	protected int Exp;

	// Token: 0x04009C70 RID: 40048
	private readonly Dictionary<EFavorContentType, FavorItemInfo[]> FavorItemMap = new Dictionary<EFavorContentType, FavorItemInfo[]>();
}
