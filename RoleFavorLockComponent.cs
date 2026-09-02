using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02002877 RID: 10359
[NullableContext(1)]
[Nullable(0)]
public class RoleFavorLockComponent : RoleFavorViewComponentBase
{
	// Token: 0x06014828 RID: 84008 RVA: 0x005B0E3C File Offset: 0x005AF03C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIVerticalLayout)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem))
		};
	}

	// Token: 0x06014829 RID: 84009 RVA: 0x005B0ED8 File Offset: 0x005AF0D8
	protected override void OnStart()
	{
		this.GenericLayout = new GenericLayout<RoleFavorLockItem, RoleFavorLockItemData>(base.GetVerticalLayout(0), new Func<RoleFavorLockItem>(this.CreateLockItem), base.GetItem(5).GetOwner() as AUIBaseActor, false, true);
	}

	// Token: 0x0601482A RID: 84010 RVA: 0x005B0F0B File Offset: 0x005AF10B
	protected override void OnBeforeDestroy()
	{
		this.ClearGenericLayout();
		this.RoleFavorLockItemData = new List<RoleFavorLockItemData>();
	}

	// Token: 0x0601482B RID: 84011 RVA: 0x005B0F1E File Offset: 0x005AF11E
	protected override void OnSetData(RoleFavorContentDataBase contentData)
	{
		this.RoleFavorLockItemData = new List<RoleFavorLockItemData>();
	}

	// Token: 0x0601482C RID: 84012 RVA: 0x005B0F2B File Offset: 0x005AF12B
	protected override void OnRefreshView()
	{
		this.SetTitleText();
		this.SetTipsText();
		this.SetConditionDesc();
	}

	// Token: 0x0601482D RID: 84013 RVA: 0x005B0F3F File Offset: 0x005AF13F
	private void ClearGenericLayout()
	{
		if (this.GenericLayout != null)
		{
			this.GenericLayout.ClearChildren();
			this.GenericLayout = null;
		}
	}

	// Token: 0x0601482E RID: 84014 RVA: 0x005B0F5B File Offset: 0x005AF15B
	private void SetConditionDesc()
	{
		this.RoleFavorLockItemData = this.GetRoleFavorLockItemData();
		GenericLayout<RoleFavorLockItem, RoleFavorLockItemData> genericLayout = this.GenericLayout;
		if (genericLayout == null)
		{
			return;
		}
		genericLayout.RefreshByData(this.RoleFavorLockItemData, null, false);
	}

	// Token: 0x0601482F RID: 84015 RVA: 0x005B0F81 File Offset: 0x005AF181
	private RoleFavorLockItem CreateLockItem()
	{
		return new RoleFavorLockItem();
	}

	// Token: 0x06014830 RID: 84016 RVA: 0x005B0F88 File Offset: 0x005AF188
	private void SetTitleText()
	{
		string titleTableId = this.GetTitleTableId();
		Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(2), titleTableId, Array.Empty<object>());
	}

	// Token: 0x06014831 RID: 84017 RVA: 0x005B0FB4 File Offset: 0x005AF1B4
	private void SetTipsText()
	{
		UUIItem item = base.GetItem(4);
		UUIItem item2 = base.GetItem(3);
		if (this.ContentData != null && this.ContentData.FavorContentType == EFavorContentType.Action)
		{
			RoleFavorActionContentData roleFavorActionContentData = this.ContentData as RoleFavorActionContentData;
			if (roleFavorActionContentData != null && roleFavorActionContentData.FavorActionParamType == EFavorActionType.IdleAction)
			{
				if (item != null)
				{
					item.SetUIActive(true);
				}
				if (item2 != null)
				{
					item2.SetUIActive(true);
				}
				Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(1), "FavorUnlockNewIdleAction", Array.Empty<object>());
				return;
			}
		}
		if (item != null)
		{
			item.SetUIActive(false);
		}
		if (item2 != null)
		{
			item2.SetUIActive(false);
		}
	}

	// Token: 0x06014832 RID: 84018 RVA: 0x005B1044 File Offset: 0x005AF244
	private string GetTitleTableId()
	{
		string result = "";
		if (this.ContentData == null)
		{
			return result;
		}
		switch (this.ContentData.FavorContentType)
		{
		case EFavorContentType.Voice:
			result = "FavorUnlockVoiceCondition";
			break;
		case EFavorContentType.ExperienceFile:
		case EFavorContentType.ExperienceStory:
			result = "FavorUnlockkStoryCondition";
			break;
		case EFavorContentType.Action:
			result = "FavorUnlockActionCondition";
			break;
		case EFavorContentType.PreciousItem:
			result = "FavorUnlockPreciousItemCondition";
			break;
		}
		return result;
	}

	// Token: 0x06014833 RID: 84019 RVA: 0x005B10A8 File Offset: 0x005AF2A8
	private List<RoleFavorLockItemData> GetRoleFavorLockItemData()
	{
		List<RoleFavorLockItemData> result = new List<RoleFavorLockItemData>();
		if (this.ContentData == null)
		{
			return result;
		}
		int configId = this.ContentData.ConfigId;
		int configConGroupId = this.ContentData.ConfigConGroupId;
		return this.GetRoleFavorLockItemDataByConfig(configId, configConGroupId);
	}

	// Token: 0x06014834 RID: 84020 RVA: 0x005B10E8 File Offset: 0x005AF2E8
	private List<RoleFavorLockItemData> GetRoleFavorLockItemDataByConfig(int id, int condGroupId)
	{
		List<RoleFavorLockItemData> list = new List<RoleFavorLockItemData>();
		if (this.ContentData == null)
		{
			return list;
		}
		int roleId = this.ContentData.RoleId;
		EFavorContentType favorContentType = this.ContentData.FavorContentType;
		ConditionGroup? conditionGroupConfig = ConfigBase<ConditionConfig>.Instance.GetConditionGroupConfig(condGroupId);
		if (conditionGroupConfig == null)
		{
			return list;
		}
		int[] groupIdArray = conditionGroupConfig.Value.GetGroupIdArray();
		int num = groupIdArray.Length;
		for (int i = 0; i < num; i++)
		{
			int conditionId = groupIdArray[i];
			Condition? conditionConfig = ConfigBase<ConditionConfig>.Instance.GetConditionConfig(conditionId);
			bool flag;
			if (favorContentType == EFavorContentType.Action)
			{
				flag = ModelBase<MotionModel>.Instance.IsCondtionFinish(roleId, id, conditionId);
			}
			else
			{
				flag = ModelBase<RoleFavorConditionModel>.Instance.IsConditionFinish(roleId, favorContentType, id, conditionId);
			}
			string localTextNew = ConfigMultiTextLang.GetLocalTextNew(conditionConfig.Value.Description, null);
			list.Add(new RoleFavorLockItemData(!flag, localTextNew ?? ""));
		}
		return list;
	}

	// Token: 0x04009E9B RID: 40603
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<RoleFavorLockItem, RoleFavorLockItemData> GenericLayout;

	// Token: 0x04009E9C RID: 40604
	private List<RoleFavorLockItemData> RoleFavorLockItemData = new List<RoleFavorLockItemData>();
}
