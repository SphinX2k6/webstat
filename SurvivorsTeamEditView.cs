using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using AkiClient.Game.Aki.Character.Role.Common.Data.Enum;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002B60 RID: 11104
[NullableContext(2)]
[Nullable(0)]
public class SurvivorsTeamEditView : UiViewBase
{
	// Token: 0x0601621F RID: 90655 RVA: 0x00624757 File Offset: 0x00622957
	[NullableContext(1)]
	public SurvivorsTeamEditView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06016220 RID: 90656 RVA: 0x0062476C File Offset: 0x0062296C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUILoopScrollViewComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIInturnAnimController)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIItem)),
			new ValueTuple<int, Type>(9, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(10, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(11, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(6, new Action(this.OnConfirmBtnClick)),
			new ValueTuple<int, Delegate>(10, new Action(this.OnHandBookBtnClick))
		};
	}

	// Token: 0x06016221 RID: 90657 RVA: 0x006248CC File Offset: 0x00622ACC
	protected override UniTask OnBeforeStartAsync()
	{
		SurvivorsTeamEditView.<OnBeforeStartAsync>d__11 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<SurvivorsTeamEditView.<OnBeforeStartAsync>d__11>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06016222 RID: 90658 RVA: 0x0062490F File Offset: 0x00622B0F
	protected override void OnBeforeShow()
	{
		ControllerBase<SurvivorsActivityController>.Instance.CheckIsActivityClose();
	}

	// Token: 0x06016223 RID: 90659 RVA: 0x0062491B File Offset: 0x00622B1B
	protected override void OnBeforeDestroy()
	{
		if (this.TsUiSceneRoleActor != null)
		{
			Singleton<UiSceneManager>.Instance.DestroyRoleSystemRoleActor(this.TsUiSceneRoleActor);
			this.TsUiSceneRoleActor = null;
		}
	}

	// Token: 0x06016224 RID: 90660 RVA: 0x00624940 File Offset: 0x00622B40
	private UniTask InitItemScroll()
	{
		SurvivorsTeamEditView.<InitItemScroll>d__14 <InitItemScroll>d__;
		<InitItemScroll>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitItemScroll>d__.<>4__this = this;
		<InitItemScroll>d__.<>1__state = -1;
		<InitItemScroll>d__.<>t__builder.Start<SurvivorsTeamEditView.<InitItemScroll>d__14>(ref <InitItemScroll>d__);
		return <InitItemScroll>d__.<>t__builder.Task;
	}

	// Token: 0x06016225 RID: 90661 RVA: 0x00624984 File Offset: 0x00622B84
	private void GetData()
	{
		this.SurvivorsLevelInfo = ModelBase<SurvivorsRogueModel>.Instance.SelectLevelInfo;
		SurvivorsActivityData activityData = ModelBase<SurvivorsRogueModel>.Instance.ActivityData;
		if (activityData == null)
		{
			return;
		}
		SurvivorsLevel value = ConfigBase<SurvivorsRogueConfig>.Instance.GetSurvivorsLevel(this.SurvivorsLevelInfo.LevelId).Value;
		foreach (int num in activityData.GetShowRoleList())
		{
			int trialRoleId = ConfigBase<SurvivorsRogueConfig>.Instance.GetSurvivorsRole(num).Value.TrialRoleId;
			bool flag = activityData.RoleMap[num];
			bool flag2 = false;
			for (int i = 0; i < value.InitRolesLength; i++)
			{
				if (value.InitRoles(i) == num)
				{
					flag2 = true;
					break;
				}
			}
			SurvivorsRoleData survivorsRoleData = new SurvivorsRoleData(num, trialRoleId, flag || flag2);
			survivorsRoleData.IsSurvivorsTrial = flag2;
			this.RoleDataList.Add(survivorsRoleData);
		}
		this.RoleDataList.Sort(delegate(SurvivorsRoleData a, SurvivorsRoleData b)
		{
			if (a.IsSurvivorsTrial != b.IsSurvivorsTrial)
			{
				if (!a.IsSurvivorsTrial)
				{
					return 1;
				}
				return -1;
			}
			else
			{
				if (a.IsUnLock == b.IsUnLock)
				{
					return 0;
				}
				if (!a.IsUnLock)
				{
					return 1;
				}
				return -1;
			}
		});
	}

	// Token: 0x06016226 RID: 90662 RVA: 0x00624AC0 File Offset: 0x00622CC0
	private void RefreshView()
	{
		UUIItem item = base.GetItem(5);
		if (item != null)
		{
			item.SetUIActive(this.CurSelectRoleData.IsUnLock);
		}
		UUIButtonComponent button = base.GetButton(6);
		if (button != null)
		{
			button.RootUIComp.Get().SetUIActive(this.CurSelectRoleData.IsUnLock);
		}
		this.PnlRedTips.SetUiActive(!this.CurSelectRoleData.IsUnLock);
		if (!this.CurSelectRoleData.IsUnLock)
		{
			string conditionGroupHintText = LevelGeneralCommons.GetConditionGroupHintText(this.CurSelectRoleData.UnlockConditionId);
			this.PnlRedTips.SetTextByTextId(conditionGroupHintText, Array.Empty<string>());
		}
		this.RoleInfoPanel.RefreshFourAttr(this.CurSelectRoleData.SurRoleId, true);
		SurvivorsRogueWeaponCard survivorsRogueWeaponCard = SurvivorsRogueCardDataFactory.CreateGeneralWeapon(this.CurSelectRoleData.InitWeaponID);
		survivorsRogueWeaponCard.TagVisible = new bool?(false);
		this.CardItem.Apply(survivorsRogueWeaponCard);
		RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(this.CurSelectRoleData.TrialRoleId, true);
		if (roleDataById == null)
		{
			return;
		}
		ControllerBase<RoleController>.Instance.OnSelectedRoleChangeByConfig(roleDataById.GetRoleConfig().Id, roleDataById.GetRoleSkinId(), null);
	}

	// Token: 0x06016227 RID: 90663 RVA: 0x00624BD8 File Offset: 0x00622DD8
	protected override void OnHandleLoadScene()
	{
		if (this.TsUiSceneRoleActor == null)
		{
			this.TsUiSceneRoleActor = Singleton<UiSceneManager>.Instance.InitRoleSystemRoleActor(EUiModelUseWay.RoleInRoleView);
		}
		UiModelBase model = this.TsUiSceneRoleActor.Model;
		UiModelActorComponent uiModelActorComponent = (model != null) ? model.CheckGetComponent<UiModelActorComponent>() : null;
		if (uiModelActorComponent != null)
		{
			uiModelActorComponent.SetTransformByTag("RoleCase");
		}
		ControllerBase<RoleController>.Instance.PlayRoleMontage(EPerformanceRoleState.Attribute_Perform, false, false, false);
		this.RefreshView();
	}

	// Token: 0x06016228 RID: 90664 RVA: 0x00624C39 File Offset: 0x00622E39
	[NullableContext(1)]
	private SurvivorsTeamEditRoleItemGird OnGridProxyCreate()
	{
		SurvivorsTeamEditRoleItemGird survivorsTeamEditRoleItemGird = new SurvivorsTeamEditRoleItemGird();
		survivorsTeamEditRoleItemGird.BindOnExtendToggleStateChanged(new Action<MediumItemGridExtendCallback>(this.ToggleFunction));
		survivorsTeamEditRoleItemGird.BindOnCanExecuteChange(new Func<object, bool, EToggleState, bool>(this.CanExecuteChangeFunction));
		return survivorsTeamEditRoleItemGird;
	}

	// Token: 0x06016229 RID: 90665 RVA: 0x00624C64 File Offset: 0x00622E64
	[NullableContext(1)]
	private void ToggleFunction(MediumItemGridExtendCallback callbackParameter)
	{
		int state = (int)callbackParameter.State;
		SurvivorsRoleData survivorsRoleData = (SurvivorsRoleData)callbackParameter.Data;
		if (state == 1)
		{
			this.RoleScrollView.DeselectCurrentGridProxy(false);
			int gridIndex = this.RoleDataList.IndexOf(survivorsRoleData);
			this.RoleScrollView.SelectGridProxy(gridIndex, false);
			this.CurSelectRoleData = survivorsRoleData;
			this.RefreshView();
		}
	}

	// Token: 0x0601622A RID: 90666 RVA: 0x00624CB9 File Offset: 0x00622EB9
	[NullableContext(1)]
	private bool CanExecuteChangeFunction(object data, bool isForceSelected, EToggleState state)
	{
		return true;
	}

	// Token: 0x0601622B RID: 90667 RVA: 0x00624CBC File Offset: 0x00622EBC
	private void OnConfirmBtnClick()
	{
		this.SurvivorsLevelInfo.RoleId = this.CurSelectRoleData.SurRoleId;
		ControllerBase<SurvivorsRogueController>.Instance.OpenEnterInstConfirm();
	}

	// Token: 0x0601622C RID: 90668 RVA: 0x00624CE0 File Offset: 0x00622EE0
	private void OnHandBookBtnClick()
	{
		SurvivorsHandbookViewOpenParams survivorsHandbookViewOpenParams = new SurvivorsHandbookViewOpenParams();
		survivorsHandbookViewOpenParams.SelectTabType = ESurvivorsRogueItemType.Weapon;
		SurvivorsRoleData curSelectRoleData = this.CurSelectRoleData;
		survivorsHandbookViewOpenParams.SelectCfgId = ((curSelectRoleData != null) ? new int?(curSelectRoleData.InitWeaponID) : null);
		SurvivorsHandbookViewOpenParams param = survivorsHandbookViewOpenParams;
		Singleton<UiManager>.Instance.OpenView(EUiViewName.SurvivorsHandbookView, param, null);
	}

	// Token: 0x0601622D RID: 90669 RVA: 0x00624D30 File Offset: 0x00622F30
	private void OnBackBtnClick()
	{
		Singleton<UiManager>.Instance.CloseView(EUiViewName.SurvivorsTeamEditView, null);
	}

	// Token: 0x0400AAF9 RID: 43769
	private TsUiSceneRoleActor TsUiSceneRoleActor;

	// Token: 0x0400AAFA RID: 43770
	private SurvivorsActivityDefine.SurvivorsLevelInfo SurvivorsLevelInfo;

	// Token: 0x0400AAFB RID: 43771
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private LoopScrollView<SurvivorsTeamEditRoleItemGird, SurvivorsRoleData> RoleScrollView;

	// Token: 0x0400AAFC RID: 43772
	private SurvivorsRoleData CurSelectRoleData;

	// Token: 0x0400AAFD RID: 43773
	[Nullable(1)]
	private readonly List<SurvivorsRoleData> RoleDataList = new List<SurvivorsRoleData>();

	// Token: 0x0400AAFE RID: 43774
	private PopupCaptionItem CaptionItem;

	// Token: 0x0400AAFF RID: 43775
	private SurvivorsRogueCardBase CardItem;

	// Token: 0x0400AB00 RID: 43776
	private SurvivorsRoleTabDetail RoleInfoPanel;

	// Token: 0x0400AB01 RID: 43777
	private FunctionalPanelConditionLock PnlRedTips;
}
