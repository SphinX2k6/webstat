using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002B35 RID: 11061
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1,
	1
})]
public class SurvivorsRoleTabView : SurvivorsTabViewBase<SurvivorsRoleTabItem, SurvivorsHandbookItemDataBase>
{
	// Token: 0x17001CBD RID: 7357
	// (get) Token: 0x0601610D RID: 90381 RVA: 0x0061F8C9 File Offset: 0x0061DAC9
	protected override ESurvivorsRogueItemType ItemType
	{
		get
		{
			return ESurvivorsRogueItemType.Character;
		}
	}

	// Token: 0x0601610E RID: 90382 RVA: 0x0061F8CC File Offset: 0x0061DACC
	protected override int GetLoopItemIndex()
	{
		return 3;
	}

	// Token: 0x0601610F RID: 90383 RVA: 0x0061F8CF File Offset: 0x0061DACF
	protected override int GetLoopScrollComponentIndex()
	{
		return 1;
	}

	// Token: 0x06016110 RID: 90384 RVA: 0x0061F8D4 File Offset: 0x0061DAD4
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUILoopScrollViewComponent)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem))
		};
	}

	// Token: 0x06016111 RID: 90385 RVA: 0x0061F970 File Offset: 0x0061DB70
	protected override UniTask InitSubComponents()
	{
		SurvivorsRoleTabView.<InitSubComponents>d__8 <InitSubComponents>d__;
		<InitSubComponents>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitSubComponents>d__.<>4__this = this;
		<InitSubComponents>d__.<>1__state = -1;
		<InitSubComponents>d__.<>t__builder.Start<SurvivorsRoleTabView.<InitSubComponents>d__8>(ref <InitSubComponents>d__);
		return <InitSubComponents>d__.<>t__builder.Task;
	}

	// Token: 0x06016112 RID: 90386 RVA: 0x0061F9B3 File Offset: 0x0061DBB3
	protected override void OnTriggerSequenceStartEvent()
	{
		SurvivorsRoleTabDetail roleDetailItem = this.RoleDetailItem;
		if (roleDetailItem == null)
		{
			return;
		}
		roleDetailItem.Refresh(this.CurrentItemId.Value, true, 6);
	}

	// Token: 0x06016113 RID: 90387 RVA: 0x0061F9D2 File Offset: 0x0061DBD2
	protected override void OnBeforeShow()
	{
		UiModelBase model = Singleton<UiSceneManager>.Instance.GetRoleSystemRoleActor().Model;
		UiModelLoadingIconComponent uiModelLoadingIconComponent = (model != null) ? model.CheckGetComponent<UiModelLoadingIconComponent>() : null;
		if (uiModelLoadingIconComponent != null)
		{
			uiModelLoadingIconComponent.SetLoadingOpen(true);
		}
		Singleton<UiSceneManager>.Instance.ShowRoleSystemRoleActor();
	}

	// Token: 0x06016114 RID: 90388 RVA: 0x0061FA05 File Offset: 0x0061DC05
	protected override void OnHideUiTabViewBase(bool fromToggle)
	{
		Singleton<UiSceneManager>.Instance.HideRoleSystemRoleActor();
		if (Singleton<UiSceneManager>.Instance.HasRoleSystemRoleActor())
		{
			UiModelBase model = Singleton<UiSceneManager>.Instance.GetRoleSystemRoleActor().Model;
			UiModelLoadingIconComponent uiModelLoadingIconComponent = (model != null) ? model.CheckGetComponent<UiModelLoadingIconComponent>() : null;
			if (uiModelLoadingIconComponent == null)
			{
				return;
			}
			uiModelLoadingIconComponent.SetLoadingOpen(false);
		}
	}

	// Token: 0x06016115 RID: 90389 RVA: 0x0061FA43 File Offset: 0x0061DC43
	protected override void OnStart()
	{
		this.PanelLock.SetButtonVisible(false);
	}

	// Token: 0x06016116 RID: 90390 RVA: 0x0061FA51 File Offset: 0x0061DC51
	protected override SurvivorsRoleTabItem CreateLoopItem()
	{
		SurvivorsRoleTabItem survivorsRoleTabItem = new SurvivorsRoleTabItem();
		survivorsRoleTabItem.BindOnCanExecuteChange(new Func<object, bool, EToggleState, bool>(base.OnCanClickItem));
		survivorsRoleTabItem.OnClickCallBack = new Action<SurvivorsHandbookItemDataBase, SurvivorsRoleTabItem>(base.OnItemClick);
		return survivorsRoleTabItem;
	}

	// Token: 0x06016117 RID: 90391 RVA: 0x0061FA7C File Offset: 0x0061DC7C
	protected override IReadOnlyList<SurvivorsHandbookItemDataBase> GenerateItemUiDataList()
	{
		SurvivorsRogueModel instance = ModelBase<SurvivorsRogueModel>.Instance;
		SurvivorsActivityData activityData = instance.ActivityData;
		if (activityData == null)
		{
			return Array.Empty<SurvivorsHandbookItemDataBase>();
		}
		List<SurvivorsHandbookItemDataBase> list = new List<SurvivorsHandbookItemDataBase>();
		List<int> showRoleList = activityData.GetShowRoleList();
		for (int i = 0; i < showRoleList.Count; i++)
		{
			int id = showRoleList[i];
			SurvivorsHandbookItemDataBase item = new SurvivorsHandbookItemDataBase
			{
				Id = id,
				LockState = new bool?(instance.GetItemIsLock(this.ItemType, id)),
				IsNew = new bool?(instance.GetItemIsNew(this.ItemType, id))
			};
			list.Add(item);
		}
		return list;
	}

	// Token: 0x06016118 RID: 90392 RVA: 0x0061FB18 File Offset: 0x0061DD18
	protected override void OnSelectItem(SurvivorsHandbookItemDataBase data, bool isFromClick)
	{
		SurvivorsRole value = ConfigBase<SurvivorsRogueConfig>.Instance.GetSurvivorsRole(data.Id).Value;
		FunctionalPanelConditionLock panelLock = this.PanelLock;
		if (panelLock != null)
		{
			panelLock.SetUiActive(data.LockState.GetValueOrDefault());
		}
		if (data.LockState.GetValueOrDefault())
		{
			string conditionGroupHintText = LevelGeneralCommons.GetConditionGroupHintText(value.UnlockConditionId);
			FunctionalPanelConditionLock panelLock2 = this.PanelLock;
			if (panelLock2 != null)
			{
				panelLock2.SetTextByTextId(conditionGroupHintText ?? string.Empty, Array.Empty<string>());
			}
		}
		this.RoleDetailItem.Refresh(data.Id, isFromClick, 6);
		this.RefreshDisplayModel(value.TrialRoleId);
		if (isFromClick)
		{
			UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
			if (uiViewSequence != null)
			{
				uiViewSequence.StopSequenceByKey("Switch", false, false);
			}
			UiBehaviorLevelSequence uiViewSequence2 = this.UiViewSequence;
			if (uiViewSequence2 == null)
			{
				return;
			}
			uiViewSequence2.PlaySequence("Switch", false, null);
		}
	}

	// Token: 0x06016119 RID: 90393 RVA: 0x0061FBF8 File Offset: 0x0061DDF8
	private void RefreshDisplayModel(int trialRoleId)
	{
		RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(trialRoleId, true);
		if (roleDataById != null)
		{
			ControllerBase<RoleController>.Instance.OnSelectedRoleChangeByConfig(roleDataById.GetRoleConfig().Id, roleDataById.GetRoleSkinId(), null);
		}
	}

	// Token: 0x0400A9E8 RID: 43496
	[Nullable(2)]
	private SurvivorsRoleTabDetail RoleDetailItem;

	// Token: 0x0400A9E9 RID: 43497
	[Nullable(2)]
	private FunctionalPanelConditionLock PanelLock;

	// Token: 0x0400A9EA RID: 43498
	private const int SHOW_ATTRIBUTE_NUM = 6;
}
