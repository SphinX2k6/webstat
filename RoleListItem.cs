using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020027A6 RID: 10150
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class RoleListItem : GridProxyAbstract<RoleListItemData>
{
	// Token: 0x060140A0 RID: 82080 RVA: 0x00598034 File Offset: 0x00596234
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUISprite)),
			new ValueTuple<int, Type>(9, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.ToggleCallBackInternal))
		};
	}

	// Token: 0x060140A1 RID: 82081 RVA: 0x0059814C File Offset: 0x0059634C
	protected override UniTask OnBeforeStartAsync()
	{
		RoleListItem.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<RoleListItem.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060140A2 RID: 82082 RVA: 0x00598190 File Offset: 0x00596390
	protected override void OnStart()
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle != null)
		{
			extendToggle.CanExecuteChange.Unbind();
			extendToggle.CanExecuteChange.Bind(new Func<bool>(this.CanToggleExecuteChangeInternal));
		}
	}

	// Token: 0x060140A3 RID: 82083 RVA: 0x005981CA File Offset: 0x005963CA
	private void ToggleCallBackInternal(EToggleState toggleState)
	{
		if (this.ToggleCallBack != null)
		{
			this.ToggleCallBack(base.GridIndex);
		}
	}

	// Token: 0x060140A4 RID: 82084 RVA: 0x005981E5 File Offset: 0x005963E5
	public bool CanToggleExecuteChangeInternal()
	{
		return this.CanToggleExecuteChange == null || this.CanToggleExecuteChange(base.GridIndex);
	}

	// Token: 0x060140A5 RID: 82085 RVA: 0x00598204 File Offset: 0x00596404
	private void UpdateRoleItem(RoleDataBase roleInstance, bool needTrial = true)
	{
		this.RoleIconItem.Refresh(roleInstance);
		UUISprite sprite = base.GetSprite(8);
		base.GetItem(4).SetUIActive(false);
		if (needTrial && roleInstance.IsTrialRole())
		{
			string trailRoleLabelIconById = RoleUtils.GetTrailRoleLabelIconById(this.DataId);
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(trailRoleLabelIconById);
			this.SetSpriteByPath(resourcePath, sprite, false, null, null);
			if (sprite != null)
			{
				sprite.SetUIActive(true);
				return;
			}
		}
		else if (sprite != null)
		{
			sprite.SetUIActive(false);
		}
	}

	// Token: 0x060140A6 RID: 82086 RVA: 0x00598280 File Offset: 0x00596480
	private void UpdateRoleTeamItem(RoleListItemData data)
	{
		int dataId = this.DataId;
		ETeamPositionType teamPositionType = data.TeamPositionType;
		if (teamPositionType == ETeamPositionType.EditFormation)
		{
			this.UpdateRoleTeamEditFormation(dataId);
			return;
		}
		if (teamPositionType != ETeamPositionType.RoleSelect)
		{
			this.UpdateRoleTeamNormal(dataId);
			return;
		}
		this.UpdateRoleTeamRoleSelect(dataId);
	}

	// Token: 0x060140A7 RID: 82087 RVA: 0x005982BC File Offset: 0x005964BC
	private void UpdateRoleTeamNormal(int roleId)
	{
		List<SceneTeamItem> teamItems = ModelBase<SceneTeamModel>.Instance.GetTeamItems(true);
		SceneTeamItem sceneTeamItem = null;
		int val = 1;
		for (int i = 0; i < teamItems.Count; i++)
		{
			SceneTeamItem sceneTeamItem2 = teamItems[i];
			if (sceneTeamItem2.GetConfigId == roleId)
			{
				sceneTeamItem = sceneTeamItem2;
				val = i + 1;
			}
		}
		if (sceneTeamItem == null)
		{
			this.SetRoleTeamItemRes(0, false);
			return;
		}
		int pos = Math.Min(val, 4);
		this.SetRoleTeamItemRes(pos, false);
	}

	// Token: 0x060140A8 RID: 82088 RVA: 0x0059832C File Offset: 0x0059652C
	private void UpdateRoleTeamEditFormation(int roleId)
	{
		int roleIndex = ModelBase<RoleSelectModel>.Instance.GetRoleIndex(roleId);
		if (roleIndex <= 0)
		{
			this.SetRoleTeamItemRes(0, false);
			return;
		}
		int pos = (int)Math.Ceiling((double)roleIndex / 3.0);
		this.SetRoleTeamItemRes(pos, true);
	}

	// Token: 0x060140A9 RID: 82089 RVA: 0x00598370 File Offset: 0x00596570
	private void UpdateRoleTeamRoleSelect(int roleId)
	{
		int roleIndex = ModelBase<RoleSelectModel>.Instance.GetRoleIndex(roleId);
		if (roleIndex <= 0)
		{
			this.SetRoleTeamItemRes(0, false);
			return;
		}
		this.SetRoleTeamItemRes(roleIndex, true);
	}

	// Token: 0x060140AA RID: 82090 RVA: 0x005983A0 File Offset: 0x005965A0
	private void UpdateIsNewRole()
	{
		RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(this.DataId, true);
		base.GetItem(7).SetUIActive(roleDataById.GetIsNew());
	}

	// Token: 0x060140AB RID: 82091 RVA: 0x005983D4 File Offset: 0x005965D4
	private void UpdateWarningItem(RoleListItemData data)
	{
		if (data.Source == ERoleViewSource.WheelTower)
		{
			IConflictInfo conflictInfo = ModelBase<WheelTowerModel>.Instance.CheckConflict(data.RoleDataId);
			base.GetItem(9).SetUIActive(conflictInfo != null);
			return;
		}
		base.GetItem(9).SetUIActive(false);
	}

	// Token: 0x060140AC RID: 82092 RVA: 0x0059841C File Offset: 0x0059661C
	private void SetRoleTeamItemRes(int pos = 0, bool setSize = false)
	{
		bool flag = pos > 0;
		base.GetItem(2).SetUIActive(flag);
		base.GetItem(5).SetUIActive(flag);
		if (!flag)
		{
			return;
		}
		UUIText text = base.GetText(3);
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
		defaultInterpolatedStringHandler.AppendLiteral("0");
		defaultInterpolatedStringHandler.AppendFormatted<int>(pos);
		text.text = defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x060140AD RID: 82093 RVA: 0x0059847C File Offset: 0x0059667C
	[NullableContext(2)]
	public UUIItem GetRedDotItem()
	{
		return base.GetItem(6);
	}

	// Token: 0x060140AE RID: 82094 RVA: 0x00598488 File Offset: 0x00596688
	public void SetToggleState(EToggleState state, bool force = false)
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (force)
		{
			extendToggle.SetToggleStateForce(state, false, false, false);
			return;
		}
		extendToggle.SetToggleState(state, false, false, false);
	}

	// Token: 0x060140AF RID: 82095 RVA: 0x005984B8 File Offset: 0x005966B8
	public override void Refresh(RoleListItemData data, bool isSelected, int gridIndex)
	{
		this.DataId = data.RoleDataId;
		RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(this.DataId, true);
		this.UpdateRoleItem(roleDataById, data.NeedShowTrial);
		this.UpdateRoleTeamItem(data);
		this.UpdateIsNewRole();
		this.UpdateWarningItem(data);
		if (data.NeedRedDot)
		{
			ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.RoleSystemRoleList, this.GetRedDotItem(), null, this.DataId);
		}
		else
		{
			this.GetRedDotItem().SetUIActive(false);
		}
		if (isSelected)
		{
			this.OnSelected(false);
			return;
		}
		this.OnDeselected(false);
	}

	// Token: 0x060140B0 RID: 82096 RVA: 0x00598544 File Offset: 0x00596744
	public override void OnSelected(bool fireEvent)
	{
		this.SetToggleState(EToggleState.ETT_Checked, true);
		this.TryRemoveRoleNewFlag(this.DataId);
		this.UpdateIsNewRole();
		RoleIconItem roleIconItem = this.RoleIconItem;
		if (roleIconItem == null)
		{
			return;
		}
		roleIconItem.PlaySelectSequence();
	}

	// Token: 0x060140B1 RID: 82097 RVA: 0x00598570 File Offset: 0x00596770
	private void TryRemoveRoleNewFlag(int roleId)
	{
		RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(roleId, true);
		if (roleDataById == null)
		{
			return;
		}
		if (!roleDataById.TryRemoveNewFlag())
		{
			return;
		}
		ModelBase<NewFlagModel>.Instance.SaveNewFlagConfig(ELocalStoragePlayerKey.RoleDataItem);
		Singleton<EventSystem>.Instance.Emit(EEventName.RoleSelectionListUpdate);
	}

	// Token: 0x060140B2 RID: 82098 RVA: 0x005985B4 File Offset: 0x005967B4
	public override void OnDeselected(bool fireEvent)
	{
		this.SetToggleState(EToggleState.ETT_UnChecked, true);
		RoleIconItem roleIconItem = this.RoleIconItem;
		if (roleIconItem == null)
		{
			return;
		}
		roleIconItem.StopSelectSequence();
	}

	// Token: 0x060140B3 RID: 82099 RVA: 0x005985CE File Offset: 0x005967CE
	public UUIExtendToggle GetToggleForGuide()
	{
		return base.GetExtendToggle(0);
	}

	// Token: 0x04009C2E RID: 39982
	private const int ROLE_MAX_POSITION = 4;

	// Token: 0x04009C2F RID: 39983
	protected int DataId;

	// Token: 0x04009C30 RID: 39984
	[Nullable(2)]
	public RoleIconItem RoleIconItem;

	// Token: 0x04009C31 RID: 39985
	[Nullable(2)]
	public Action<int> ToggleCallBack;

	// Token: 0x04009C32 RID: 39986
	[Nullable(2)]
	public Func<int, bool> CanToggleExecuteChange;

	// Token: 0x02008B60 RID: 35680
	[NullableContext(0)]
	private enum ERoleListItemDefine
	{
		// Token: 0x0402EFBA RID: 192442
		Toggle,
		// Token: 0x0402EFBB RID: 192443
		RoleIconItem,
		// Token: 0x0402EFBC RID: 192444
		PositionItem,
		// Token: 0x0402EFBD RID: 192445
		PositionText,
		// Token: 0x0402EFBE RID: 192446
		TrialItem,
		// Token: 0x0402EFBF RID: 192447
		TeamItem,
		// Token: 0x0402EFC0 RID: 192448
		RedDotItem,
		// Token: 0x0402EFC1 RID: 192449
		IsNewItem,
		// Token: 0x0402EFC2 RID: 192450
		TrialSprite,
		// Token: 0x0402EFC3 RID: 192451
		ItemWarning
	}
}
