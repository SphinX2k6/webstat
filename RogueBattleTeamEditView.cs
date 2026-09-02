using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.MapRogue;
using CSharpScript.Game.Module.RogueBattle;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using Google.Protobuf.Collections;
using UnrealEngine;

// Token: 0x0200277E RID: 10110
[NullableContext(1)]
[Nullable(0)]
public class RogueBattleTeamEditView : UiTickViewBase
{
	// Token: 0x06013F06 RID: 81670 RVA: 0x0058EAA8 File Offset: 0x0058CCA8
	public RogueBattleTeamEditView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06013F07 RID: 81671 RVA: 0x0058EABC File Offset: 0x0058CCBC
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(4, typeof(UUIText)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUISprite)),
			new ValueTuple<int, Type>(9, typeof(UUIItem)),
			new ValueTuple<int, Type>(10, typeof(UUIItem)),
			new ValueTuple<int, Type>(11, typeof(UUIItem)),
			new ValueTuple<int, Type>(12, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(3, new Action(this.OnClickBtnConfirm)),
			new ValueTuple<int, Delegate>(6, new Action(this.OnClickBtnBuffDetail))
		};
	}

	// Token: 0x06013F08 RID: 81672 RVA: 0x0058EC34 File Offset: 0x0058CE34
	private void OnClickBtnBuffDetail()
	{
		MapRogueOp opData = ModelBase<MapRogueModel>.Instance.GetOpData((int)this.OpenParam);
		if (opData == null)
		{
			return;
		}
		UiManager instance = Singleton<UiManager>.Instance;
		EUiViewName rogueBattleEnvironmentBuffView = EUiViewName.RogueBattleEnvironmentBuffView;
		RogueGotoLevelPlayOp rogueGotoLevelPlayOp = opData.Data.RogueGotoLevelPlayOp;
		instance.OpenView(rogueBattleEnvironmentBuffView, (rogueGotoLevelPlayOp != null) ? new int?(rogueGotoLevelPlayOp.RoomId) : null, null);
	}

	// Token: 0x06013F09 RID: 81673 RVA: 0x0058EC94 File Offset: 0x0058CE94
	private void OnClickBtnLink()
	{
		if (this.WaitClose)
		{
			return;
		}
		RogueBattleTeamEditData param = new RogueBattleTeamEditData(this.TabComponent.GetSelectedIndex(), new Func<List<int>, UniTask>(this.OnTeamEditConfirm));
		Singleton<UiManager>.Instance.OpenView(EUiViewName.RogueBattleTeamRoleSelectView, param, null);
	}

	// Token: 0x06013F0A RID: 81674 RVA: 0x0058ECD8 File Offset: 0x0058CED8
	private void OnClickSlot(int position)
	{
		if (this.WaitClose)
		{
			return;
		}
		RogueBattleTeamEditData param = new RogueBattleTeamEditData(this.TabComponent.GetSelectedIndex(), new Func<List<int>, UniTask>(this.OnTeamEditConfirm));
		Singleton<UiManager>.Instance.OpenView(EUiViewName.RogueBattleTeamRoleSelectView, param, null);
	}

	// Token: 0x06013F0B RID: 81675 RVA: 0x0058ED1C File Offset: 0x0058CF1C
	private void OnClickBtnConfirm()
	{
		RogueBattleTeamEditView.<>c__DisplayClass11_0 CS$<>8__locals1 = new RogueBattleTeamEditView.<>c__DisplayClass11_0();
		CS$<>8__locals1.<>4__this = this;
		CS$<>8__locals1.gameInfo = ModelBase<MapRogueModel>.Instance.GameInfo;
		RogueResFormation formationDataByIndex = ModelBase<RogueBattleModel>.Instance.GetFormationDataByIndex(this.TabComponent.GetSelectedIndex());
		if (!CS$<>8__locals1.gameInfo.NotTipsInactiveLink && formationDataByIndex.LinkId == 0 && ModelBase<RogueBattleModel>.Instance.IsAnyBondLinkCanActivate())
		{
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.RogueResInactiveLinkConfirm);
			confirmBoxDataNew.HasToggle = true;
			confirmBoxDataNew.ToggleTextKey = "RogueRes_LvlHint_Desc";
			confirmBoxDataNew.FunctionMap.Add(1, new Action(this.OnClickBtnLink));
			confirmBoxDataNew.FunctionMap.Add(2, new Action(CS$<>8__locals1.<OnClickBtnConfirm>g__Confirm|0));
			confirmBoxDataNew.SetToggleFunction(delegate(bool isSelectOn)
			{
				CS$<>8__locals1.gameInfo.NotTipsInactiveLink = isSelectOn;
			});
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
			return;
		}
		CS$<>8__locals1.<OnClickBtnConfirm>g__Confirm|0();
	}

	// Token: 0x06013F0C RID: 81676 RVA: 0x0058EDF2 File Offset: 0x0058CFF2
	private bool CheckCanOpenFetter()
	{
		return !this.WaitClose;
	}

	// Token: 0x06013F0D RID: 81677 RVA: 0x0058EE00 File Offset: 0x0058D000
	private CommonTabData GetCommonData(int index)
	{
		string resourceId = EditFormationDefine.FORMATION_SPRITES[index];
		CommonTabData commonTabData = new CommonTabData(ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId), new CommonTabTitleData("RogueRes_TeamName", Array.Empty<object>()), null);
		commonTabData.SetSmallIcon(ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_TeamTitle"));
		return commonTabData;
	}

	// Token: 0x06013F0E RID: 81678 RVA: 0x0058EE4C File Offset: 0x0058D04C
	private void OnClickTab(int index)
	{
		RogueResFormation formationDataByIndex = ModelBase<RogueBattleModel>.Instance.GetFormationDataByIndex(index);
		if (formationDataByIndex != null)
		{
			for (int i = 0; i < this.RoleSlotList.Count; i++)
			{
				if (i >= formationDataByIndex.RoleId.Count)
				{
					(this.RoleSlotList[i] as RogueBattleTeamEditSlot).UpdateRoleInfo(0, index);
				}
				else
				{
					(this.RoleSlotList[i] as RogueBattleTeamEditSlot).UpdateRoleInfo(formationDataByIndex.RoleId[i], index);
				}
			}
		}
		this.RefreshView();
	}

	// Token: 0x06013F0F RID: 81679 RVA: 0x0058EED0 File Offset: 0x0058D0D0
	private UniTask OnTeamEditConfirm(List<int> roleIdList)
	{
		RogueBattleTeamEditView.<OnTeamEditConfirm>d__15 <OnTeamEditConfirm>d__;
		<OnTeamEditConfirm>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnTeamEditConfirm>d__.<>4__this = this;
		<OnTeamEditConfirm>d__.roleIdList = roleIdList;
		<OnTeamEditConfirm>d__.<>1__state = -1;
		<OnTeamEditConfirm>d__.<>t__builder.Start<RogueBattleTeamEditView.<OnTeamEditConfirm>d__15>(ref <OnTeamEditConfirm>d__);
		return <OnTeamEditConfirm>d__.<>t__builder.Task;
	}

	// Token: 0x06013F10 RID: 81680 RVA: 0x0058EF1C File Offset: 0x0058D11C
	protected override UniTask OnBeforeStartAsync()
	{
		RogueBattleTeamEditView.<OnBeforeStartAsync>d__16 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<RogueBattleTeamEditView.<OnBeforeStartAsync>d__16>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06013F11 RID: 81681 RVA: 0x0058EF5F File Offset: 0x0058D15F
	protected override void OnBeforeDestroy()
	{
		LevelSequencePlayer progressLevelSequencePlayer = this.ProgressLevelSequencePlayer;
		if (progressLevelSequencePlayer != null)
		{
			progressLevelSequencePlayer.StopPlayingSequence(false, true);
		}
		LevelSequencePlayer progressLevelSequencePlayer2 = this.ProgressLevelSequencePlayer;
		if (progressLevelSequencePlayer2 != null)
		{
			progressLevelSequencePlayer2.Clear();
		}
		this.ProgressLevelSequencePlayer = null;
		ControllerBase<FormationDragController>.Instance.ClearDragData();
	}

	// Token: 0x06013F12 RID: 81682 RVA: 0x0058EF98 File Offset: 0x0058D198
	protected override void OnTick(float delta)
	{
		foreach (FormationRoleSlot formationRoleSlot in this.RoleSlotList)
		{
			RogueBattleTeamEditSlot rogueBattleTeamEditSlot = formationRoleSlot as RogueBattleTeamEditSlot;
			if (rogueBattleTeamEditSlot != null)
			{
				rogueBattleTeamEditSlot.OnTick(delta);
			}
		}
	}

	// Token: 0x06013F13 RID: 81683 RVA: 0x0058EFF4 File Offset: 0x0058D1F4
	private void RefreshView()
	{
		this.RefreshLinkItem();
		this.RefreshConfirmButton();
		this.RefreshBuffDetailButton();
	}

	// Token: 0x06013F14 RID: 81684 RVA: 0x0058F008 File Offset: 0x0058D208
	private void RefreshLinkItem()
	{
		RogueBattleLinkItem linkItem = this.LinkItem;
		if (linkItem == null)
		{
			return;
		}
		linkItem.RefreshLinkInfo(this.TabComponent.GetSelectedIndex());
	}

	// Token: 0x06013F15 RID: 81685 RVA: 0x0058F028 File Offset: 0x0058D228
	private void RefreshBuffDetailButton()
	{
		MapRogueOp opData = ModelBase<MapRogueModel>.Instance.GetOpData((int)this.OpenParam);
		if (opData == null)
		{
			return;
		}
		RogueResRoomPool? roomPoolConfig = ConfigBase<RogueBattleConfig>.Instance.GetRoomPoolConfig(opData.Data.RogueGotoLevelPlayOp.RoomId);
		bool uiactive = roomPoolConfig == null || roomPoolConfig.GetValueOrDefault().EnvDescLength != 0 || roomPoolConfig == null || roomPoolConfig.GetValueOrDefault().MonsterDescLength != 0;
		base.GetButton(6).RootUIComp.Get().SetUIActive(uiactive);
	}

	// Token: 0x06013F16 RID: 81686 RVA: 0x0058F0C8 File Offset: 0x0058D2C8
	private void RefreshConfirmButton()
	{
		RogueResFormation formationDataByIndex = ModelBase<RogueBattleModel>.Instance.GetFormationDataByIndex(this.TabComponent.GetSelectedIndex());
		bool flag = true;
		if (formationDataByIndex != null)
		{
			using (IEnumerator<int> enumerator = formationDataByIndex.RoleId.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current != 0)
					{
						flag = false;
						break;
					}
				}
			}
		}
		base.GetButton(3).SetSelfInteractive(!flag);
	}

	// Token: 0x06013F17 RID: 81687 RVA: 0x0058F140 File Offset: 0x0058D340
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
	{
		if (configParams.Length == 0)
		{
			return null;
		}
		if (!(configParams[0] == "FirstFetter"))
		{
			return null;
		}
		MapRoguePanelFetter panelFetter = this.PanelFetter;
		if (panelFetter == null)
		{
			return null;
		}
		return panelFetter.GetGuideUiItemAndUiItemForShowEx(configParams);
	}

	// Token: 0x06013F18 RID: 81688 RVA: 0x0058F16C File Offset: 0x0058D36C
	private void ExchangeRoleCallBack(int position1, int position2, int roleId1, int roleId2)
	{
		int selectedIndex = this.TabComponent.GetSelectedIndex();
		RogueResFormation formationDataByIndex = ModelBase<RogueBattleModel>.Instance.GetFormationDataByIndex(selectedIndex);
		List<int> list = new List<int>();
		RepeatedField<int> roleId3 = formationDataByIndex.RoleId;
		for (int i = 1; i < 4; i++)
		{
			int item = (roleId3.Count >= i) ? roleId3[i - 1] : 0;
			if (i == position1)
			{
				item = roleId1;
			}
			if (i == position2)
			{
				item = roleId2;
			}
			list.Add(item);
		}
		ControllerBase<RogueBattleController>.Instance.ChangeFormationAllListRequest(selectedIndex, list).Forget();
		(this.RoleSlotList[position1 - 1] as RogueBattleTeamEditSlot).UpdateRoleInfo(roleId1, selectedIndex);
		(this.RoleSlotList[position2 - 1] as RogueBattleTeamEditSlot).UpdateRoleInfo(roleId2, selectedIndex);
	}

	// Token: 0x04009B48 RID: 39752
	[Nullable(2)]
	private RogueBattleLinkItem LinkItem;

	// Token: 0x04009B49 RID: 39753
	[Nullable(2)]
	private MapRoguePanelFetter PanelFetter;

	// Token: 0x04009B4A RID: 39754
	private List<FormationRoleSlot> RoleSlotList = new List<FormationRoleSlot>();

	// Token: 0x04009B4B RID: 39755
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TabComponentWithCaptionItem<RogueBattleTeamEditTab> TabComponent;

	// Token: 0x04009B4C RID: 39756
	private bool WaitClose;

	// Token: 0x04009B4D RID: 39757
	[Nullable(2)]
	private LevelSequencePlayer ProgressLevelSequencePlayer;
}
