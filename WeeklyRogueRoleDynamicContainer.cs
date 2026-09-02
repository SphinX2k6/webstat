using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002D33 RID: 11571
[NullableContext(1)]
[Nullable(0)]
public class WeeklyRogueRoleDynamicContainer : UiPanelBase, IDynamicScrollItem<IWeeklyRogueRoleGroupInfo>
{
	// Token: 0x0601759D RID: 95645 RVA: 0x00679664 File Offset: 0x00677864
	public UniTask Init(UUIItem actor)
	{
		WeeklyRogueRoleDynamicContainer.<Init>d__4 <Init>d__;
		<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<Init>d__.<>4__this = this;
		<Init>d__.actor = actor;
		<Init>d__.<>1__state = -1;
		<Init>d__.<>t__builder.Start<WeeklyRogueRoleDynamicContainer.<Init>d__4>(ref <Init>d__);
		return <Init>d__.<>t__builder.Task;
	}

	// Token: 0x0601759E RID: 95646 RVA: 0x006796AF File Offset: 0x006778AF
	public void ClearItem()
	{
	}

	// Token: 0x0601759F RID: 95647 RVA: 0x006796B1 File Offset: 0x006778B1
	public AUIBaseActor GetUsingItem(IWeeklyRogueRoleGroupInfo data)
	{
		if (data.IsTitleType)
		{
			return (AUIBaseActor)base.GetItem(2).GetOwner();
		}
		return (AUIBaseActor)base.GetGridLayout(0).GetOwner();
	}

	// Token: 0x060175A0 RID: 95648 RVA: 0x006796DE File Offset: 0x006778DE
	public void Update(IWeeklyRogueRoleGroupInfo data, int index)
	{
		this.Data = data;
		if (data.IsTitleType)
		{
			this.RefreshTitle(this.Data);
			return;
		}
		this.RefreshRoleList(this.Data);
	}

	// Token: 0x060175A1 RID: 95649 RVA: 0x00679708 File Offset: 0x00677908
	public void InitData(IWeeklyRogueRoleGroupInfo data)
	{
		this.Data = data;
	}

	// Token: 0x060175A2 RID: 95650 RVA: 0x00679711 File Offset: 0x00677911
	public void Refresh()
	{
		if (this.Data.IsTitleType)
		{
			this.RefreshTitle(this.Data);
			return;
		}
		GenericLayout<WeeklyRogueRoleGridItem, RoleDataBase> roleLayout = this.RoleLayout;
		if (roleLayout == null)
		{
			return;
		}
		roleLayout.RefreshWithoutDataSync();
	}

	// Token: 0x060175A3 RID: 95651 RVA: 0x00679740 File Offset: 0x00677940
	public void RefreshRoleByRoleId(int roleId)
	{
		if (this.Data.IsTitleType || this.RoleLayout == null)
		{
			return;
		}
		List<RoleDataBase> dataList = this.Data.DataList;
		RoleDataBase roleDataBase = (dataList != null) ? dataList.Find((RoleDataBase role) => role.GetDataId() == roleId) : null;
		if (roleDataBase == null)
		{
			return;
		}
		WeeklyRogueRoleGridItem layoutItemByKey = this.RoleLayout.GetLayoutItemByKey(roleId);
		if (layoutItemByKey == null)
		{
			return;
		}
		bool isSelected = ModelBase<RoleSelectModel>.Instance.SelectedRoleSet.Contains(roleId);
		int gridIndex = this.Data.DataList.IndexOf(roleDataBase);
		layoutItemByKey.Refresh(roleDataBase, isSelected, gridIndex);
	}

	// Token: 0x060175A4 RID: 95652 RVA: 0x006797E8 File Offset: 0x006779E8
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIGridLayout)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIText)),
			new ValueTuple<int, Type>(6, typeof(UUIItem))
		};
	}

	// Token: 0x060175A5 RID: 95653 RVA: 0x0067989C File Offset: 0x00677A9C
	protected override void OnStart()
	{
		base.GetItem(2).SetUIActive(false);
		base.GetGridLayout(0).RootUIComp.Get().SetUIActive(false);
	}

	// Token: 0x060175A6 RID: 95654 RVA: 0x006798D0 File Offset: 0x00677AD0
	private void RefreshTitle(IWeeklyRogueRoleGroupInfo info)
	{
		base.GetGridLayout(0).RootUIComp.Get().SetUIActive(false);
		IWeeklyRogueRoleGroupTitleInfo titleInfo = info.TitleInfo;
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), titleInfo.TitleId, Array.Empty<object>());
		base.GetItem(4).SetUIActive(titleInfo.IsUp);
		if (titleInfo.IsUp)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), "WeRougeFormationIntegralMultiplier", new <>z__ReadOnlySingleElementList<object>(titleInfo.ScoreRate));
		}
		base.GetItem(6).SetUIActive(titleInfo.IsEmpty);
		base.GetItem(2).SetUIActive(true);
	}

	// Token: 0x060175A7 RID: 95655 RVA: 0x0067997C File Offset: 0x00677B7C
	private void RefreshRoleList(IWeeklyRogueRoleGroupInfo info)
	{
		WeeklyRogueRoleDynamicContainer.<>c__DisplayClass14_0 CS$<>8__locals1 = new WeeklyRogueRoleDynamicContainer.<>c__DisplayClass14_0();
		CS$<>8__locals1.<>4__this = this;
		base.GetItem(2).SetUIActive(false);
		if (this.RoleLayout == null)
		{
			this.RoleLayout = new GenericLayout<WeeklyRogueRoleGridItem, RoleDataBase>(base.GetGridLayout(0), new Func<WeeklyRogueRoleGridItem>(this.OnCreateRole), null, false, true);
		}
		CS$<>8__locals1.newDataList = info.DataList;
		bool flag = CS$<>8__locals1.newDataList.Count > 0;
		this.RoleLayout.GetRootUiItem().SetUIActive(flag);
		if (flag)
		{
			this.RoleLayout.RefreshByData(CS$<>8__locals1.newDataList, new Action(CS$<>8__locals1.<RefreshRoleList>g__RefreshSelectOn|0), true);
		}
	}

	// Token: 0x060175A8 RID: 95656 RVA: 0x00679A19 File Offset: 0x00677C19
	private WeeklyRogueRoleGridItem OnCreateRole()
	{
		WeeklyRogueRoleGridItem weeklyRogueRoleGridItem = new WeeklyRogueRoleGridItem();
		weeklyRogueRoleGridItem.BindOnExtendToggleStateChanged(new Action<MediumItemGridExtendCallback>(this.ToggleFunction));
		weeklyRogueRoleGridItem.BindOnCanExecuteChange(new Func<object, bool, EToggleState, bool>(this.CanExecuteChangeFunction));
		return weeklyRogueRoleGridItem;
	}

	// Token: 0x060175A9 RID: 95657 RVA: 0x00679A44 File Offset: 0x00677C44
	protected void ToggleFunction(MediumItemGridExtendCallback @params)
	{
		Dictionary<int, RoleDataBase> roleIndexMap = ModelBase<RoleSelectModel>.Instance.RoleIndexMap;
		HashSet<int> selectedRoleSet = ModelBase<RoleSelectModel>.Instance.SelectedRoleSet;
		RoleDataBase roleDataBase = (RoleDataBase)@params.Data;
		if (@params.State == EToggleState.ETT_UnChecked)
		{
			using (Dictionary<int, RoleDataBase>.Enumerator enumerator = roleIndexMap.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					KeyValuePair<int, RoleDataBase> keyValuePair = enumerator.Current;
					if (keyValuePair.Value == roleDataBase)
					{
						roleIndexMap.Remove(keyValuePair.Key);
						selectedRoleSet.Remove(roleDataBase.GetDataId());
						break;
					}
				}
				goto IL_B7;
			}
		}
		if (@params.State == EToggleState.ETT_Checked)
		{
			for (int i = 1; i <= 3; i++)
			{
				if (!roleIndexMap.ContainsKey(i))
				{
					roleIndexMap[i] = roleDataBase;
					selectedRoleSet.Add(roleDataBase.GetDataId());
					break;
				}
			}
		}
		IL_B7:
		GenericLayout<WeeklyRogueRoleGridItem, RoleDataBase> roleLayout = this.RoleLayout;
		if (roleLayout != null)
		{
			roleLayout.RefreshWithoutDataSync();
		}
		Action<RoleDataBase> refreshRole = this.RefreshRole;
		if (refreshRole == null)
		{
			return;
		}
		refreshRole(roleDataBase);
	}

	// Token: 0x060175AA RID: 95658 RVA: 0x00679B3C File Offset: 0x00677D3C
	protected bool CanExecuteChangeFunction(object data, bool isForceSelected, EToggleState state)
	{
		if (((RoleDataBase)data).IsTrialRole())
		{
			return false;
		}
		if (state != EToggleState.ETT_UnChecked)
		{
			return true;
		}
		if (ModelBase<RoleSelectModel>.Instance.RoleIndexMap.Count >= 3)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("EditBattleTeamRoleFull", Array.Empty<object>());
			return false;
		}
		return true;
	}

	// Token: 0x0400B35C RID: 45916
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Action<RoleDataBase> RefreshRole;

	// Token: 0x0400B35D RID: 45917
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<WeeklyRogueRoleGridItem, RoleDataBase> RoleLayout;

	// Token: 0x0400B35E RID: 45918
	private IWeeklyRogueRoleGroupInfo Data;

	// Token: 0x0400B35F RID: 45919
	private List<RoleDataBase> RoleDataList = new List<RoleDataBase>();
}
