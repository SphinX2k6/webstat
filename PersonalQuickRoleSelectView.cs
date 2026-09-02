using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002438 RID: 9272
[NullableContext(1)]
[Nullable(0)]
public class PersonalQuickRoleSelectView : QuickRoleSelectView
{
	// Token: 0x06011EE8 RID: 73448 RVA: 0x004EF262 File Offset: 0x004ED462
	public PersonalQuickRoleSelectView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06011EE9 RID: 73449 RVA: 0x004EF26C File Offset: 0x004ED46C
	protected override void OnStart()
	{
		this.Data = (this.OpenParam as QuickRoleSelectViewData);
		this.RoleScrollView = new LoopScrollView<TeamRoleGrid, RoleDataBase>(base.GetLoopScrollViewComponent(1), base.GetItem(10).GetOwner() as AUIBaseActor, new Func<TeamRoleGrid>(this.OnPersonalGridProxyCreate), false);
		this.LoadingSequencePlayer = new UiSequencePlayer(base.GetItem(13));
	}

	// Token: 0x06011EEA RID: 73450 RVA: 0x004EF2CE File Offset: 0x004ED4CE
	protected override void OnBeforeShow()
	{
		base.RefreshRoleList();
	}

	// Token: 0x06011EEB RID: 73451 RVA: 0x004EF2D6 File Offset: 0x004ED4D6
	private PersonalQuickRoleSelectGrid OnPersonalGridProxyCreate()
	{
		PersonalQuickRoleSelectGrid personalQuickRoleSelectGrid = new PersonalQuickRoleSelectGrid();
		personalQuickRoleSelectGrid.BindOnExtendToggleStateChanged(new Action<MediumItemGridExtendCallback>(base.ToggleFunction));
		personalQuickRoleSelectGrid.BindOnCanExecuteChange(new Func<object, bool, EToggleState, bool>(this.CanExecuteChange));
		return personalQuickRoleSelectGrid;
	}

	// Token: 0x06011EEC RID: 73452 RVA: 0x004EF304 File Offset: 0x004ED504
	protected override bool CanExecuteChange(object data, bool isForceSelected, EToggleState state)
	{
		if (state != EToggleState.ETT_UnChecked)
		{
			return true;
		}
		RoleDataBase roleDataBase = data as RoleDataBase;
		if (ModelBase<NewFlagModel>.Instance.HasNewFlag(ELocalStoragePlayerKey.PersonalDataItem, roleDataBase.GetDataId()))
		{
			ModelBase<NewFlagModel>.Instance.RemoveNewFlag(ELocalStoragePlayerKey.PersonalDataItem, roleDataBase.GetDataId());
			int gridIndex = this.RoleList.IndexOf(roleDataBase);
			this.RoleScrollView.RefreshGridProxy(gridIndex);
		}
		bool flag = ModelBase<RoleSelectModel>.Instance.RoleIndexMap.Count >= 3;
		if (flag)
		{
			QuickRoleSelectViewData data2 = this.Data;
			if (((data2 != null) ? data2.OnRoleSelectFull : null) != null)
			{
				QuickRoleSelectViewData data3 = this.Data;
				if (data3 != null)
				{
					data3.OnRoleSelectFull();
				}
			}
			else
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("EditBattleTeamRoleFull", Array.Empty<object>());
			}
		}
		return !flag;
	}
}
