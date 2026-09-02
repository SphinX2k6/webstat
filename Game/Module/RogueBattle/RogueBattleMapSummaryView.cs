using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Roguelike;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.RogueBattle
{
	// Token: 0x0200526C RID: 21100
	[NullableContext(1)]
	[Nullable(0)]
	public class RogueBattleMapSummaryView : UiViewBase
	{
		// Token: 0x06035FDA RID: 221146 RVA: 0x00D9621B File Offset: 0x00D9441B
		public RogueBattleMapSummaryView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06035FDB RID: 221147 RVA: 0x00D96230 File Offset: 0x00D94430
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIExtendToggle)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIItem))
			};
		}

		// Token: 0x06035FDC RID: 221148 RVA: 0x00D962CC File Offset: 0x00D944CC
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.RogueResMapSummaryTeamToBondUpdate, new Action(this.OnJumpToBondTab));
		}

		// Token: 0x06035FDD RID: 221149 RVA: 0x00D962EA File Offset: 0x00D944EA
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.RogueResMapSummaryTeamToBondUpdate, new Action(this.OnJumpToBondTab));
		}

		// Token: 0x06035FDE RID: 221150 RVA: 0x00D96308 File Offset: 0x00D94508
		protected override void OnStart()
		{
			this.TsUiSceneRoleActor = Singleton<UiSceneManager>.Instance.InitRoleSystemRoleActor(EUiModelUseWay.RoleInRoleView);
			TsUiSceneRoleActor tsUiSceneRoleActor = this.TsUiSceneRoleActor;
			object obj;
			if (tsUiSceneRoleActor == null)
			{
				obj = null;
			}
			else
			{
				UiModelBase model = tsUiSceneRoleActor.Model;
				obj = ((model != null) ? model.CheckGetComponent<UiModelDataComponent>() : null);
			}
			object obj2 = obj;
			if (obj2 != null)
			{
				obj2.SetVisible(false);
			}
			TsUiSceneRoleActor tsUiSceneRoleActor2 = this.TsUiSceneRoleActor;
			object obj3;
			if (tsUiSceneRoleActor2 == null)
			{
				obj3 = null;
			}
			else
			{
				UiModelBase model2 = tsUiSceneRoleActor2.Model;
				obj3 = ((model2 != null) ? model2.CheckGetComponent<UiModelLoadingIconComponent>() : null);
			}
			object obj4 = obj3;
			if (obj4 != null)
			{
				obj4.SetLoadingOpen(false);
			}
			this.InitTabComponent();
			if (this.OpenParam != null)
			{
				IRogueBattleMapSummeryOpenInfo rogueBattleMapSummeryOpenInfo = (IRogueBattleMapSummeryOpenInfo)this.OpenParam;
				this.CurSelectTabView = new EUiTabViewName?(rogueBattleMapSummeryOpenInfo.TabName);
				ModelBase<RogueBattleModel>.Instance.CurrentMapSummaryBond = rogueBattleMapSummeryOpenInfo.FetterId.GetValueOrDefault();
				if (rogueBattleMapSummeryOpenInfo.FetterId != null && rogueBattleMapSummeryOpenInfo.FetterId.Value > 0)
				{
					ModelBase<RogueBattleModel>.Instance.IsMapSummaryBondJumping = true;
				}
			}
			else
			{
				ModelBase<RogueBattleModel>.Instance.CurrentMapSummaryBond = 0;
			}
			this.InitExtendToggle();
		}

		// Token: 0x06035FDF RID: 221151 RVA: 0x00D96400 File Offset: 0x00D94600
		protected override UniTask OnBeforeShowAsyncImplementImplement()
		{
			RogueBattleMapSummaryView.<OnBeforeShowAsyncImplementImplement>d__11 <OnBeforeShowAsyncImplementImplement>d__;
			<OnBeforeShowAsyncImplementImplement>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeShowAsyncImplementImplement>d__.<>4__this = this;
			<OnBeforeShowAsyncImplementImplement>d__.<>1__state = -1;
			<OnBeforeShowAsyncImplementImplement>d__.<>t__builder.Start<RogueBattleMapSummaryView.<OnBeforeShowAsyncImplementImplement>d__11>(ref <OnBeforeShowAsyncImplementImplement>d__);
			return <OnBeforeShowAsyncImplementImplement>d__.<>t__builder.Task;
		}

		// Token: 0x06035FE0 RID: 221152 RVA: 0x00D96443 File Offset: 0x00D94643
		protected override void OnBeforeDestroy()
		{
			if (this.TabComponent != null)
			{
				this.TabComponent.Destroy(null);
				this.TabComponent = null;
			}
		}

		// Token: 0x06035FE1 RID: 221153 RVA: 0x00D96460 File Offset: 0x00D94660
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
			if (this.CurSelectTabView == EUiTabViewName.RogueBattleMapSummaryTeamTabView)
			{
				Singleton<EventSystem>.Instance.Emit(EEventName.RogueResMapSummaryTeamShowAgain);
			}
		}

		// Token: 0x06035FE2 RID: 221154 RVA: 0x00D964E5 File Offset: 0x00D946E5
		protected override void OnHandleReleaseScene()
		{
			Singleton<UiSceneManager>.Instance.DestroyRoleSystemRoleActor(this.TsUiSceneRoleActor);
			this.TsUiSceneRoleActor = null;
		}

		// Token: 0x06035FE3 RID: 221155 RVA: 0x00D964FF File Offset: 0x00D946FF
		private void OnCloseClicked()
		{
			base.CloseMe(null);
		}

		// Token: 0x06035FE4 RID: 221156 RVA: 0x00D96508 File Offset: 0x00D94708
		protected void InitTabComponent()
		{
			CommonTabComponentData<CommonTabItem> data = new CommonTabComponentData<CommonTabItem>(new Func<UUIItem, int?, CommonTabItem>(this.ProxyCreate), new Action<int>(this.ToggleCallBack), new Func<int, CommonTabData>(this.GetCommonData));
			this.TabComponent = new TabComponentWithCaptionItem<CommonTabItem>(base.GetItem(0), data, new Action(this.OnCloseClicked), false);
			this.TabComponent.SetHelpButtonShowState(false);
			this.LastClickTime = null;
			this.TabComponent.SetCanChange(new Func<int, bool?, bool>(this.CanToggleChange));
			this.TabViewComponent = new TabViewComponent<UiDynamicTab>(base.GetItem(1), EKeyMode.Default);
		}

		// Token: 0x06035FE5 RID: 221157 RVA: 0x00D965A4 File Offset: 0x00D947A4
		private UniTask RefreshTabListAsync()
		{
			RogueBattleMapSummaryView.<RefreshTabListAsync>d__17 <RefreshTabListAsync>d__;
			<RefreshTabListAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshTabListAsync>d__.<>4__this = this;
			<RefreshTabListAsync>d__.<>1__state = -1;
			<RefreshTabListAsync>d__.<>t__builder.Start<RogueBattleMapSummaryView.<RefreshTabListAsync>d__17>(ref <RefreshTabListAsync>d__);
			return <RefreshTabListAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06035FE6 RID: 221158 RVA: 0x00D965E8 File Offset: 0x00D947E8
		private CommonTabData GetCommonData(int index)
		{
			UiDynamicTab uiDynamicTab = this.TabDataList[index];
			return new CommonTabData(uiDynamicTab.Icon, new CommonTabTitleData(uiDynamicTab.TabName, Array.Empty<object>()), null);
		}

		// Token: 0x06035FE7 RID: 221159 RVA: 0x00D96620 File Offset: 0x00D94820
		protected bool CanToggleChange(int index, bool? _)
		{
			if (Singleton<Info>.Instance.IsInGamepad())
			{
				return true;
			}
			int? intConfig = ConfigCommonParamById.GetIntConfig("panel_interval_time");
			return this.LastClickTime == null || Singleton<Time>.Instance.Now - this.LastClickTime.Value >= (double)intConfig.Value;
		}

		// Token: 0x06035FE8 RID: 221160 RVA: 0x00D96676 File Offset: 0x00D94876
		private CommonTabItem ProxyCreate([Nullable(2)] UUIItem uiItem, int? index)
		{
			return new CommonTabItem();
		}

		// Token: 0x06035FE9 RID: 221161 RVA: 0x00D96680 File Offset: 0x00D94880
		private void ToggleCallBack(int index)
		{
			this.LastClickTime = new double?(Singleton<Time>.Instance.Now);
			UiDynamicTab data = this.TabDataList[index];
			EUiTabViewName euiTabViewName = (EUiTabViewName)data.ChildViewName;
			this.OnTeamTabShow(euiTabViewName == EUiTabViewName.RogueBattleMapSummaryTeamTabView);
			this.OnTokenTabShow(euiTabViewName == EUiTabViewName.RogueBattleSummaryTokenTabView);
			CommonTabItem tabItemByIndex = this.TabComponent.GetTabItemByIndex(index);
			this.TabViewComponent.ToggleCallBack(data, euiTabViewName, tabItemByIndex, null, null);
			this.CurSelectTabView = new EUiTabViewName?(euiTabViewName);
		}

		// Token: 0x06035FEA RID: 221162 RVA: 0x00D96710 File Offset: 0x00D94910
		private void OnTeamTabShow(bool isVisible)
		{
			TsUiSceneRoleActor tsUiSceneRoleActor = this.TsUiSceneRoleActor;
			object obj;
			if (tsUiSceneRoleActor == null)
			{
				obj = null;
			}
			else
			{
				UiModelBase model = tsUiSceneRoleActor.Model;
				obj = ((model != null) ? model.CheckGetComponent<UiModelDataComponent>() : null);
			}
			object obj2 = obj;
			if (obj2 != null)
			{
				obj2.SetVisible(isVisible);
			}
			UUIItem item = base.GetItem(4);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(!isVisible);
		}

		// Token: 0x06035FEB RID: 221163 RVA: 0x00D96760 File Offset: 0x00D94960
		private void OnTokenTabShow(bool isOpen)
		{
			if (!isOpen)
			{
				UUIItem item = base.GetItem(2);
				if (item != null)
				{
					item.SetUIActive(false);
				}
				UUIItem item2 = base.GetItem(5);
				if (item2 == null)
				{
					return;
				}
				item2.SetUIActive(false);
				return;
			}
			else
			{
				bool flag = ModelBase<RogueBattleModel>.Instance.GetTokenData().Count == 0;
				UUIItem item3 = base.GetItem(2);
				if (item3 != null)
				{
					item3.SetUIActive(flag);
				}
				UUIItem item4 = base.GetItem(5);
				if (item4 == null)
				{
					return;
				}
				item4.SetUIActive(!flag);
				return;
			}
		}

		// Token: 0x06035FEC RID: 221164 RVA: 0x00D967D4 File Offset: 0x00D949D4
		private void OnJumpToBondTab()
		{
			for (int i = 0; i < this.TabDataList.Count; i++)
			{
				if ((EUiTabViewName)this.TabDataList[i].ChildViewName == EUiTabViewName.RogueBattleMapSummaryFettersTabView)
				{
					this.TabComponent.SelectToggleByIndex(i, false);
					return;
				}
			}
		}

		// Token: 0x06035FED RID: 221165 RVA: 0x00D9682A File Offset: 0x00D94A2A
		private void OnExtendToggleStateChange(EToggleState newState)
		{
			ModelBase<RogueBattleModel>.Instance.ChangeDescMode();
		}

		// Token: 0x06035FEE RID: 221166 RVA: 0x00D96838 File Offset: 0x00D94A38
		protected void InitExtendToggle()
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(3);
			EToggleState state = (ModelBase<RogueBattleModel>.Instance.DescMode == EDescModel.DETAIL) ? EToggleState.ETT_UnChecked : EToggleState.ETT_Checked;
			if (extendToggle != null)
			{
				extendToggle.SetToggleState(state, false, false, false);
			}
			if (extendToggle == null)
			{
				return;
			}
			extendToggle.OnStateChange.Add(new Action<EToggleState>(this.OnExtendToggleStateChange));
		}

		// Token: 0x0401F056 RID: 127062
		[Nullable(new byte[]
		{
			2,
			1
		})]
		protected TabComponentWithCaptionItem<CommonTabItem> TabComponent;

		// Token: 0x0401F057 RID: 127063
		[Nullable(2)]
		protected TabViewComponent<UiDynamicTab> TabViewComponent;

		// Token: 0x0401F058 RID: 127064
		private double? LastClickTime;

		// Token: 0x0401F059 RID: 127065
		protected List<UiDynamicTab> TabDataList = new List<UiDynamicTab>();

		// Token: 0x0401F05A RID: 127066
		private EUiTabViewName? CurSelectTabView;

		// Token: 0x0401F05B RID: 127067
		[Nullable(2)]
		private TsUiSceneRoleActor TsUiSceneRoleActor;
	}
}
