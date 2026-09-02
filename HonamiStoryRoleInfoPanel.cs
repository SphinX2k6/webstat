using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.HonamiStory;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001F66 RID: 8038
public class HonamiStoryRoleInfoPanel : UiPanelBase
{
	// Token: 0x0600F0BA RID: 61626 RVA: 0x0041C944 File Offset: 0x0041AB44
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIVerticalLayout)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem))
		};
	}

	// Token: 0x0600F0BB RID: 61627 RVA: 0x0041C9E0 File Offset: 0x0041ABE0
	protected override void OnStart()
	{
		this.ActiveLayout = new GenericLayout<HonamiStoryEquipItemInfoItem, IHonamiStoryTipsBuffInfo>(base.GetVerticalLayout(3), new Func<HonamiStoryEquipItemInfoItem>(this.CreateEquipItemInfoItem), null, false, true);
	}

	// Token: 0x0600F0BC RID: 61628 RVA: 0x0041CA03 File Offset: 0x0041AC03
	[NullableContext(1)]
	private HonamiStoryEquipItemInfoItem CreateEquipItemInfoItem()
	{
		return new HonamiStoryEquipItemInfoItem();
	}

	// Token: 0x0600F0BD RID: 61629 RVA: 0x0041CA0A File Offset: 0x0041AC0A
	public void SetData(int roleId)
	{
		this.RoleId = roleId;
		this.RefreshEquipInfo();
	}

	// Token: 0x0600F0BE RID: 61630 RVA: 0x0041CA1C File Offset: 0x0041AC1C
	private void RefreshEquipInfo()
	{
		HonamiStoryRoleEquipData roleEquipDataByRoleId = ModelBase<HonamiStoryModel>.Instance.GetRoleEquipDataByRoleId(this.RoleId);
		if (roleEquipDataByRoleId == null)
		{
			GenericLayout<HonamiStoryEquipItemInfoItem, IHonamiStoryTipsBuffInfo> activeLayout = this.ActiveLayout;
			if (activeLayout != null)
			{
				activeLayout.SetActive(false);
			}
			base.GetItem(5).SetUIActive(false);
			return;
		}
		List<HonamiStoryEquipItemData> equipRoleItemList = roleEquipDataByRoleId.GetEquipRoleItemList();
		List<IHonamiStoryTipsBuffInfo> list = new List<IHonamiStoryTipsBuffInfo>();
		foreach (HonamiStoryEquipItemData honamiStoryEquipItemData in equipRoleItemList)
		{
			if (HonamiStoryUtil.CheckRolePowerValid(this.RoleId, honamiStoryEquipItemData.GetRoleId()))
			{
				List<IHonamiStoryTipsBuffInfo> buffTempIdList = honamiStoryEquipItemData.GetBuffTempIdList(true);
				if (buffTempIdList.Count > 0)
				{
					list.Add(buffTempIdList[0]);
				}
			}
		}
		bool flag = list.Count > 0;
		if (flag)
		{
			GenericLayout<HonamiStoryEquipItemInfoItem, IHonamiStoryTipsBuffInfo> activeLayout2 = this.ActiveLayout;
			if (activeLayout2 != null)
			{
				activeLayout2.RefreshByData(list, null, false);
			}
		}
		GenericLayout<HonamiStoryEquipItemInfoItem, IHonamiStoryTipsBuffInfo> activeLayout3 = this.ActiveLayout;
		if (activeLayout3 != null)
		{
			activeLayout3.SetActive(flag);
		}
		base.GetItem(5).SetUIActive(flag);
	}

	// Token: 0x0600F0BF RID: 61631 RVA: 0x0041CB1C File Offset: 0x0041AD1C
	[NullableContext(1)]
	public void RefreshSkillInfo(string skillName, string skillInfo, string skillType, string[] skillInfoParam)
	{
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), skillName, Array.Empty<object>());
		if (skillInfoParam != null && skillInfoParam.Length != 0)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), skillInfo, skillInfoParam);
		}
		else
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), skillInfo, Array.Empty<object>());
		}
		UUIText text = base.GetText(0);
		if (text != null)
		{
			text.SetText(skillType, true);
		}
		GenericLayout<HonamiStoryEquipItemInfoItem, IHonamiStoryTipsBuffInfo> activeLayout = this.ActiveLayout;
		if (activeLayout == null)
		{
			return;
		}
		activeLayout.RefreshWithoutDataSync();
	}

	// Token: 0x040073A7 RID: 29607
	private int RoleId;

	// Token: 0x040073A8 RID: 29608
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<HonamiStoryEquipItemInfoItem, IHonamiStoryTipsBuffInfo> ActiveLayout;

	// Token: 0x020082F7 RID: 33527
	internal enum EComponentType
	{
		// Token: 0x0402C67B RID: 181883
		SkillTypeNameText,
		// Token: 0x0402C67C RID: 181884
		SkillNameText,
		// Token: 0x0402C67D RID: 181885
		SkillInfoText,
		// Token: 0x0402C67E RID: 181886
		EquipInfoVerticalLayout,
		// Token: 0x0402C67F RID: 181887
		EquipInfoItem,
		// Token: 0x0402C680 RID: 181888
		EquipTitleItem
	}
}
