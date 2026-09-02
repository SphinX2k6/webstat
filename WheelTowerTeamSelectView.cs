using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Activity.ActivityContent.WheelTower;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001706 RID: 5894
[NullableContext(2)]
[Nullable(0)]
public class WheelTowerTeamSelectView : UiViewBase
{
	// Token: 0x0600A343 RID: 41795 RVA: 0x002B203A File Offset: 0x002B023A
	[NullableContext(1)]
	public WheelTowerTeamSelectView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600A344 RID: 41796 RVA: 0x002B2044 File Offset: 0x002B0244
	protected unsafe override void OnRegisterComponent()
	{
		int num = 5;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600A345 RID: 41797 RVA: 0x002B2110 File Offset: 0x002B0310
	protected override UniTask OnBeforeStartAsync()
	{
		WheelTowerTeamSelectView.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<WheelTowerTeamSelectView.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600A346 RID: 41798 RVA: 0x002B2154 File Offset: 0x002B0354
	protected override void OnStart()
	{
		PopupCaptionItem caption = this.Caption;
		if (caption != null)
		{
			caption.SetCloseCallBack(new Action(this.CloseSelf));
		}
		PopupCaptionItem caption2 = this.Caption;
		if (caption2 != null)
		{
			caption2.SetTitleIcon(ConfigBase<UiResourceConfig>.Instance.GetResourcePath("WheelTower_ActivityIcon"));
		}
		this.SeqPlayer = new LevelSequencePlayer(this.RootItem);
	}

	// Token: 0x0600A347 RID: 41799 RVA: 0x002B21B0 File Offset: 0x002B03B0
	protected override void OnBeforeShow()
	{
		WheelTowerTeamSelectMainPanel selectPanel = this.SelectPanel;
		if (selectPanel != null)
		{
			selectPanel.RefreshPanel();
		}
		this.RefreshInfoPanel(ModelBase<WheelTowerModel>.Instance.TmpSelectRoleId, true);
	}

	// Token: 0x0600A348 RID: 41800 RVA: 0x002B21D4 File Offset: 0x002B03D4
	protected override void OnBeforeDestroy()
	{
		LevelSequencePlayer seqPlayer = this.SeqPlayer;
		if (seqPlayer == null)
		{
			return;
		}
		seqPlayer.Clear();
	}

	// Token: 0x0600A349 RID: 41801 RVA: 0x002B21E8 File Offset: 0x002B03E8
	[NullableContext(1)]
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
	{
		if (!(configParams[0] == "RoleTab"))
		{
			return null;
		}
		int index = int.Parse(configParams[1]);
		WheelTowerTeamSelectMainPanel selectPanel = this.SelectPanel;
		UUIItem uuiitem = (selectPanel != null) ? selectPanel.GetTabItem(index) : null;
		if (uuiitem == null)
		{
			return null;
		}
		return new UUIItem[]
		{
			uuiitem,
			uuiitem
		};
	}

	// Token: 0x0600A34A RID: 41802 RVA: 0x002B2238 File Offset: 0x002B0438
	private void OnRoleSelect(int roleId)
	{
		bool force = ModelBase<WheelTowerModel>.Instance.SelectedRoleList.Count == 0;
		int realRoleId = ModelBase<WheelTowerModel>.Instance.GetRealRoleId(roleId);
		if (realRoleId != 0 && ModelBase<WheelTowerModel>.Instance.IsSelectRole(realRoleId))
		{
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.WheelTowerTemplateReplaceConfirm);
			confirmBoxDataNew.FunctionMap[2] = delegate()
			{
				ModelBase<WheelTowerModel>.Instance.TryAddOrDeleteRole(realRoleId);
				ModelBase<WheelTowerModel>.Instance.TryAddOrDeleteRole(roleId);
				WheelTowerTeamSelectMainPanel selectPanel = this.SelectPanel;
				if (selectPanel == null)
				{
					return;
				}
				selectPanel.RefreshPanel();
			};
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
			this.RefreshInfoPanel(roleId, force);
			return;
		}
		int templateRoleId = ModelBase<WheelTowerModel>.Instance.GetTemplateRoleId(roleId);
		if (templateRoleId != 0 && ModelBase<WheelTowerModel>.Instance.IsSelectRole(templateRoleId))
		{
			ModelBase<WheelTowerModel>.Instance.TryAddOrDeleteRole(templateRoleId);
		}
		ModelBase<WheelTowerModel>.Instance.TryAddOrDeleteRole(roleId);
		this.RefreshInfoPanel(roleId, force);
	}

	// Token: 0x0600A34B RID: 41803 RVA: 0x002B2324 File Offset: 0x002B0524
	private void OnTeamSelect(int teamId)
	{
		int teamMaxRoleCount = ModelBase<WheelTowerModel>.Instance.GetTeamMaxRoleCount();
		List<int> list = new List<int>(teamMaxRoleCount);
		for (int i = 0; i < teamMaxRoleCount; i++)
		{
			list.Add(0);
		}
		EditFormationData formationData = ModelBase<EditFormationModel>.Instance.GetFormationData(teamId);
		int num = 0;
		foreach (KeyValuePair<int, EditFormationRoleData> keyValuePair in (((formationData != null) ? formationData.GetRoleDataMapWithTrial(false) : null) ?? new Dictionary<int, EditFormationRoleData>()))
		{
			list[num] = keyValuePair.Value.ConfigId;
			num++;
		}
		foreach (int roleId in ModelBase<WheelTowerModel>.Instance.TmpSelectedRoleMap.Values)
		{
			int roleCurrentBranchId = ModelBase<RoleModel>.Instance.GetRoleCurrentBranchId(roleId);
			if (roleCurrentBranchId > 0)
			{
				ModelBase<RoleModel>.Instance.SetRoleSkillBranchGamePlayCache(roleId, roleCurrentBranchId, ESkillBranchCacheType.WheelTower);
			}
		}
		List<int> list2 = new List<int>();
		foreach (int num2 in list)
		{
			if (num2 > 0)
			{
				list2.Add(num2);
			}
		}
		ModelBase<WheelTowerModel>.Instance.SetTmpSelectRoleList(list2);
		WheelTowerStrShowPanel strPanel = this.StrPanel;
		if (strPanel == null)
		{
			return;
		}
		strPanel.Refresh();
	}

	// Token: 0x0600A34C RID: 41804 RVA: 0x002B24A0 File Offset: 0x002B06A0
	private void OnSelectModeChange(ESelectMode selectMode, int roleId)
	{
		this.RefreshInfoPanel(roleId, true);
		WheelTowerStrShowPanel strPanel = this.StrPanel;
		if (strPanel != null)
		{
			strPanel.Refresh();
		}
		WheelTowerStrShowPanel strPanel2 = this.StrPanel;
		if (strPanel2 != null)
		{
			strPanel2.SetUiActive(selectMode == ESelectMode.Team);
		}
		WheelTowerRoleInfoPanel infoPanel = this.InfoPanel;
		if (infoPanel == null)
		{
			return;
		}
		infoPanel.SetUiActive(selectMode != ESelectMode.Team);
	}

	// Token: 0x0600A34D RID: 41805 RVA: 0x002B24F4 File Offset: 0x002B06F4
	private void RefreshInfoPanel(int roleId, bool force = false)
	{
		WheelTowerRoleInfoPanel infoPanel = this.InfoPanel;
		if (infoPanel != null)
		{
			infoPanel.RefreshLeftBtn();
		}
		if ((roleId == ModelBase<WheelTowerModel>.Instance.TmpSelectRoleId || roleId <= 0) && !force)
		{
			return;
		}
		LevelSequencePlayer seqPlayer = this.SeqPlayer;
		if (seqPlayer != null)
		{
			seqPlayer.PlayOrReplaySequenceByName("Switch", false, null);
		}
		WheelTowerRoleInfoPanel infoPanel2 = this.InfoPanel;
		if (infoPanel2 == null)
		{
			return;
		}
		infoPanel2.Refresh(roleId);
	}

	// Token: 0x0600A34E RID: 41806 RVA: 0x002B255D File Offset: 0x002B075D
	private void OnClickConfirm()
	{
		ModelBase<WheelTowerModel>.Instance.TmpToSelect();
		base.CloseMe(null);
	}

	// Token: 0x04004DB9 RID: 19897
	private PopupCaptionItem Caption;

	// Token: 0x04004DBA RID: 19898
	private WheelTowerTeamSelectMainPanel SelectPanel;

	// Token: 0x04004DBB RID: 19899
	private WheelTowerRoleInfoPanel InfoPanel;

	// Token: 0x04004DBC RID: 19900
	private WheelTowerStrShowPanel StrPanel;

	// Token: 0x04004DBD RID: 19901
	private LevelSequencePlayer SeqPlayer;
}
