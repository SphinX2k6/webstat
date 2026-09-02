using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Module.Util.Layout;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002BFB RID: 11259
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class TowerRecommendItem : GridProxyAbstract<TowerRecommendFormation>
{
	// Token: 0x06016781 RID: 92033 RVA: 0x0063E8F4 File Offset: 0x0063CAF4
	protected unsafe override void OnRegisterComponent()
	{
		int num = 5;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIInteractionGroup));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIHorizontalLayout));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickUseBtn));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06016782 RID: 92034 RVA: 0x0063E9FD File Offset: 0x0063CBFD
	protected override void OnStart()
	{
		this.RoleIdArray = new List<int>();
		this.RoleSkillBranchMap = new Dictionary<int, int>();
	}

	// Token: 0x06016783 RID: 92035 RVA: 0x0063EA18 File Offset: 0x0063CC18
	public override void Refresh(TowerRecommendFormation formationInfo, bool isSelected, int gridIndex)
	{
		this.RoleSkillBranchMap.Clear();
		base.GetText(2).SetText((gridIndex + 1).ToString(), true);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), "Text_ExplorationDegree_Text", new <>z__ReadOnlySingleElementList<object>(Singleton<MathUtils>.Instance.GetFloatPointFloorString((double)((float)formationInfo.Usage * 0.01f), 2)));
		this.RoleLayout = new GenericLayoutNew<MediumItemGrid>(base.GetHorizontalLayout(4), new CSharpScript.Game.Module.Util.Layout.TLayoutRefresh<MediumItemGrid>(this.InitRoleItem), null);
		List<TowerRecommendRole> list = new List<TowerRecommendRole>();
		foreach (TowerRecommendRole towerRecommendRole in formationInfo.Formation)
		{
			list.Add(towerRecommendRole);
			this.RoleSkillBranchMap[towerRecommendRole.RoleId] = towerRecommendRole.SkillBranchId;
		}
		list.Sort(delegate(TowerRecommendRole a, TowerRecommendRole b)
		{
			if (a.Level != b.Level)
			{
				return b.Level - a.Level;
			}
			int qualityId = ConfigBase<RoleConfig>.Instance.GetRoleConfig(a.RoleId).Value.QualityId;
			int qualityId2 = ConfigBase<RoleConfig>.Instance.GetRoleConfig(b.RoleId).Value.QualityId;
			if (qualityId == qualityId2)
			{
				return b.RoleId - a.RoleId;
			}
			return qualityId2 - qualityId;
		});
		this.RoleLayout.RebuildLayoutByDataNew<TowerRecommendRole>(list, null);
	}

	// Token: 0x06016784 RID: 92036 RVA: 0x0063EB34 File Offset: 0x0063CD34
	private ILayoutItem<MediumItemGrid> InitRoleItem(object data, UUIItem uiItem, int index)
	{
		MediumItemGrid mediumItemGrid = new MediumItemGrid();
		mediumItemGrid.Initialize(uiItem.GetOwner());
		TowerRecommendRole towerRecommendRole = (TowerRecommendRole)data;
		RoleInfo? roleConfig = ConfigBase<RoleConfig>.Instance.GetRoleConfig(towerRecommendRole.RoleId);
		int roleBranchIndexById = ModelBase<RoleModel>.Instance.GetRoleBranchIndexById(towerRecommendRole.RoleId, towerRecommendRole.SkillBranchId);
		CharacterMediumItemGrid parameters = new CharacterMediumItemGrid
		{
			ItemConfigId = new int?(towerRecommendRole.RoleId),
			SkinId = roleConfig.Value.SkinId,
			BottomTextId = "Text_LevelShow_Text",
			BottomTextParameter = new object[]
			{
				towerRecommendRole.Level
			},
			ElementId = new int?(roleConfig.Value.ElementId),
			IsDisable = new bool?(!this.IsRoleAllowUse(towerRecommendRole)),
			SkillBranchIndex = ((roleBranchIndexById >= 0) ? new int?(roleBranchIndexById) : null)
		};
		mediumItemGrid.Apply<CharacterMediumItemGrid>(parameters);
		return new LayoutItem<MediumItemGrid>
		{
			Key = index,
			Value = mediumItemGrid
		};
	}

	// Token: 0x06016785 RID: 92037 RVA: 0x0063EC4C File Offset: 0x0063CE4C
	private bool IsRoleAllowUse(TowerRecommendRole roleInfo)
	{
		int roleId = roleInfo.RoleId;
		if (!ModelBase<RoleModel>.Instance.IsMainRole(roleId))
		{
			if (ModelBase<RoleModel>.Instance.GetRoleDataById(roleId, true) == null)
			{
				base.GetInteractionGroup(1).SetInteractable(false);
				return false;
			}
			this.RoleIdArray.Add(roleId);
		}
		else
		{
			int playerRoleId = ModelBase<PlayerInfoModel>.Instance.GetPlayerRoleId();
			RoleInfo? roleInfo2;
			int? num = (ConfigBase<RoleConfig>.Instance.GetRoleConfig(roleId) != null) ? new int?(roleInfo2.GetValueOrDefault().ElementId) : null;
			RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(playerRoleId, true);
			ElementInfo? elementInfo;
			int? num2 = (roleDataById != null) ? ((roleDataById.GetElementInfo() != null) ? new int?(elementInfo.GetValueOrDefault().Id) : null) : null;
			if (!(num.GetValueOrDefault() == num2.GetValueOrDefault() & num != null == (num2 != null)))
			{
				base.GetInteractionGroup(1).SetInteractable(false);
				return false;
			}
			this.RoleIdArray.Add(playerRoleId);
		}
		return true;
	}

	// Token: 0x06016786 RID: 92038 RVA: 0x0063ED6B File Offset: 0x0063CF6B
	protected override void OnBeforeDestroy()
	{
		this.RoleIdArray.Clear();
		this.RoleSkillBranchMap.Clear();
		this.RoleSkillBranchMap = null;
		this.RoleLayout = null;
	}

	// Token: 0x06016787 RID: 92039 RVA: 0x0063ED94 File Offset: 0x0063CF94
	private void OnClickUseBtn()
	{
		ControllerBase<EditBattleTeamController>.Instance.ResetSlotDataThenSetEditBattleTeamByRoleId(this.RoleIdArray.ToArray());
		foreach (int num in this.RoleIdArray)
		{
			int num2;
			if (this.RoleSkillBranchMap.TryGetValue(num, out num2) && num2 != 0)
			{
				ControllerBase<RoleController>.Instance.ModifyRoleSkillBranchInCurrentGamePlay(num, num2, false);
			}
		}
		Singleton<UiManager>.Instance.CloseView(EUiViewName.TowerRecommendView, null);
	}

	// Token: 0x0400ADEB RID: 44523
	private const float PERCENT = 0.01f;

	// Token: 0x0400ADEC RID: 44524
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayoutNew<MediumItemGrid> RoleLayout;

	// Token: 0x0400ADED RID: 44525
	[Nullable(2)]
	private List<int> RoleIdArray;

	// Token: 0x0400ADEE RID: 44526
	[Nullable(2)]
	private Dictionary<int, int> RoleSkillBranchMap;

	// Token: 0x02008EF4 RID: 36596
	[NullableContext(0)]
	private enum EChildType
	{
		// Token: 0x0403006E RID: 196718
		UseBtn,
		// Token: 0x0403006F RID: 196719
		UseBtnInteractionGroup,
		// Token: 0x04030070 RID: 196720
		IndexText,
		// Token: 0x04030071 RID: 196721
		PercentText,
		// Token: 0x04030072 RID: 196722
		RoleScrollView
	}
}
