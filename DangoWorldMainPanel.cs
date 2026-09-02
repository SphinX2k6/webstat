using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.BattleUi;
using CSharpScript.Game.Module.BattleUi.Views;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001B0F RID: 6927
[NullableContext(2)]
[Nullable(0)]
public class DangoWorldMainPanel : BattleChildViewPanel
{
	// Token: 0x0600C788 RID: 51080 RVA: 0x0034C6F8 File Offset: 0x0034A8F8
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIScrollViewWithScrollbarComponent)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action(this.OnCloseBtnClick))
		};
	}

	// Token: 0x0600C789 RID: 51081 RVA: 0x0034C7B8 File Offset: 0x0034A9B8
	protected override void AddEvents()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnAbyssRoleInfoUpdate, new Action(this.OnRoleChange));
		Singleton<EventSystem>.Instance.Add(EEventName.OnAbyssAddRole, new Action(this.OnRoleChange));
		Singleton<EventSystem>.Instance.Add<IReadOnlySet<int>>(EEventName.OnActivityOpen, new Action<IReadOnlySet<int>>(this.OnActivityOpen));
	}

	// Token: 0x0600C78A RID: 51082 RVA: 0x0034C81C File Offset: 0x0034AA1C
	protected override void RemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnAbyssRoleInfoUpdate, new Action(this.OnRoleChange));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnAbyssAddRole, new Action(this.OnRoleChange));
		Singleton<EventSystem>.Instance.Remove<IReadOnlySet<int>>(EEventName.OnActivityOpen, new Action<IReadOnlySet<int>>(this.OnActivityOpen));
	}

	// Token: 0x0600C78B RID: 51083 RVA: 0x0034C87D File Offset: 0x0034AA7D
	[NullableContext(1)]
	private void OnActivityOpen(IReadOnlySet<int> _)
	{
		this.CurrentData = ModelBase<DangoAbyssModel>.Instance.GetCurrentOpenAbyssActivityData();
		this.RefreshView();
	}

	// Token: 0x0600C78C RID: 51084 RVA: 0x0034C895 File Offset: 0x0034AA95
	private void OnRoleChange()
	{
		this.RefreshRightTopPanel();
	}

	// Token: 0x0600C78D RID: 51085 RVA: 0x0034C8A0 File Offset: 0x0034AAA0
	protected override UniTask OnBeforeStartAsync()
	{
		DangoWorldMainPanel.<OnBeforeStartAsync>d__12 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<DangoWorldMainPanel.<OnBeforeStartAsync>d__12>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600C78E RID: 51086 RVA: 0x0034C8E4 File Offset: 0x0034AAE4
	protected override void OnBeforeDestroy()
	{
		this.RemoveEvents();
		DangoWorldQuestItem dangoWorldQuestItem = this.DangoWorldQuestItem;
		if (dangoWorldQuestItem != null)
		{
			dangoWorldQuestItem.Clear();
		}
		BattleUiChildViewData childViewData = ModelBase<BattleUiModel>.Instance.ChildViewData;
		if (childViewData != null)
		{
			childViewData.SetChildVisible(EBattleUiVisibleReason.UiControl, EBattleUiChild.Mission, true, true, 0);
		}
		BattleUiChildViewData childViewData2 = ModelBase<BattleUiModel>.Instance.ChildViewData;
		if (childViewData2 != null)
		{
			childViewData2.SetChildVisible(EBattleUiVisibleReason.UiControl, EBattleUiChild.Formation, true, true, 0);
		}
		BattleUiChildViewData childViewData3 = ModelBase<BattleUiModel>.Instance.ChildViewData;
		if (childViewData3 != null)
		{
			childViewData3.SetChildVisible(EBattleUiVisibleReason.UiControl, EBattleUiChild.GamepadFormation, true, true, 0);
		}
		UiSequencePlayer uiSequencePlayer = this.UiSequencePlayer;
		if (uiSequencePlayer == null)
		{
			return;
		}
		uiSequencePlayer.Clear();
	}

	// Token: 0x0600C78F RID: 51087 RVA: 0x0034C96C File Offset: 0x0034AB6C
	protected override void OnBeforeShow()
	{
		this.RefreshView();
		this.RefreshRedDot();
	}

	// Token: 0x0600C790 RID: 51088 RVA: 0x0034C97C File Offset: 0x0034AB7C
	private void RefreshRedDot()
	{
		AbyssButtonItem dangoUpItem = this.DangoUpItem;
		if (dangoUpItem != null)
		{
			dangoUpItem.BindRedDot(ERedDotName.RedDotDangoDevelop, null);
		}
		AbyssButtonItem shopItem = this.ShopItem;
		if (shopItem == null)
		{
			return;
		}
		shopItem.BindRedDot(ERedDotName.RedDotDangoPayShop, null);
	}

	// Token: 0x0600C791 RID: 51089 RVA: 0x0034C9C6 File Offset: 0x0034ABC6
	private void RefreshView()
	{
		DangoWorldQuestItem dangoWorldQuestItem = this.DangoWorldQuestItem;
		if (dangoWorldQuestItem != null)
		{
			dangoWorldQuestItem.Refresh();
		}
		this.RefreshRightTopPanel();
		this.RefreshBtns();
	}

	// Token: 0x0600C792 RID: 51090 RVA: 0x0034C9E5 File Offset: 0x0034ABE5
	private void RefreshRightTopPanel()
	{
		if (this.CurrentData != null)
		{
			this.RightTopPanel.Refresh(this.CurrentData);
		}
	}

	// Token: 0x0600C793 RID: 51091 RVA: 0x0034CA00 File Offset: 0x0034AC00
	private void RefreshBtns()
	{
		if (this.CurrentData != null)
		{
			bool dangoUpAvailable = ModelBase<DangoAbyssModel>.Instance.GetDangoUpAvailable();
			this.DangoUpItem.SetUiActive(dangoUpAvailable);
			bool shopAvailable = ModelBase<DangoAbyssModel>.Instance.GetShopAvailable();
			this.ShopItem.SetUiActive(shopAvailable);
		}
	}

	// Token: 0x0600C794 RID: 51092 RVA: 0x0034CA43 File Offset: 0x0034AC43
	private void OnClickDangoUp()
	{
		if (!ModelBase<DangoAbyssModel>.Instance.GetDangoUpAvailable())
		{
			return;
		}
		ControllerBase<DangoAbyssActivityController>.Instance.OpenCurrentRoleUpView();
	}

	// Token: 0x0600C795 RID: 51093 RVA: 0x0034CA5C File Offset: 0x0034AC5C
	private void OnClickShop()
	{
		if (!ModelBase<DangoAbyssModel>.Instance.GetShopAvailable())
		{
			return;
		}
		Singleton<UiManager>.Instance.OpenView(EUiViewName.DangoAbyssShopView, null, null);
	}

	// Token: 0x0600C796 RID: 51094 RVA: 0x0034CA7C File Offset: 0x0034AC7C
	private void OnCloseBtnClick()
	{
		if (!ControllerBase<DangoAbyssController>.Instance.OpenCurrentActivityAbyssEntrance())
		{
			ControllerBase<InstanceDungeonEntranceController>.Instance.LeaveInstanceDungeon().Forget<bool>();
		}
	}

	// Token: 0x0600C797 RID: 51095 RVA: 0x0034CA99 File Offset: 0x0034AC99
	public override void OnTickBattleChildViewPanel(float delta)
	{
		DangoWorldQuestItem dangoWorldQuestItem = this.DangoWorldQuestItem;
		if (dangoWorldQuestItem == null)
		{
			return;
		}
		dangoWorldQuestItem.Tick();
	}

	// Token: 0x0600C798 RID: 51096 RVA: 0x0034CAAB File Offset: 0x0034ACAB
	protected override void OnBeforeHide()
	{
		this.UnbindRedDot();
	}

	// Token: 0x0600C799 RID: 51097 RVA: 0x0034CAB3 File Offset: 0x0034ACB3
	private void UnbindRedDot()
	{
		AbyssButtonItem dangoUpItem = this.DangoUpItem;
		if (dangoUpItem != null)
		{
			dangoUpItem.UnBindRedDot();
		}
		AbyssButtonItem shopItem = this.ShopItem;
		if (shopItem == null)
		{
			return;
		}
		shopItem.UnBindRedDot();
	}

	// Token: 0x0600C79A RID: 51098 RVA: 0x0034CAD8 File Offset: 0x0034ACD8
	[NullableContext(1)]
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
	{
		if (configParams.Length != 2)
		{
			return null;
		}
		UUIItem uuiitem = null;
		if (configParams[1] == "DangoUp")
		{
			uuiitem = base.GetItem(5);
		}
		if (configParams[1] == "DangoShop")
		{
			uuiitem = base.GetItem(4);
		}
		if (configParams[1] == "CloseBtn")
		{
			UUIButtonComponent button = base.GetButton(0);
			uuiitem = ((button != null) ? button.RootUIComp.Get() : null);
		}
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

	// Token: 0x04005F8B RID: 24459
	private DangoAbyssActivityData CurrentData;

	// Token: 0x04005F8C RID: 24460
	private DangoWorldMainProgressPanel RightTopPanel;

	// Token: 0x04005F8D RID: 24461
	private AbyssButtonItem DangoUpItem;

	// Token: 0x04005F8E RID: 24462
	private AbyssButtonItem ShopItem;

	// Token: 0x04005F8F RID: 24463
	private DangoWorldQuestItem DangoWorldQuestItem;

	// Token: 0x04005F90 RID: 24464
	private UiSequencePlayer UiSequencePlayer;

	// Token: 0x02007DE9 RID: 32233
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402AE2E RID: 175662
		CloseBtn,
		// Token: 0x0402AE2F RID: 175663
		GoalScroller,
		// Token: 0x0402AE30 RID: 175664
		GoalItem,
		// Token: 0x0402AE31 RID: 175665
		RightTopPanel,
		// Token: 0x0402AE32 RID: 175666
		ShopItem,
		// Token: 0x0402AE33 RID: 175667
		DangoUpItem
	}
}
