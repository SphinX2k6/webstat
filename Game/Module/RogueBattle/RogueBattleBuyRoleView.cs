using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Module.MapRogue;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.RogueBattle
{
	// Token: 0x0200525C RID: 21084
	[NullableContext(2)]
	[Nullable(0)]
	public class RogueBattleBuyRoleView : UiViewBase
	{
		// Token: 0x06035F8E RID: 221070 RVA: 0x00D94776 File Offset: 0x00D92976
		[NullableContext(1)]
		public RogueBattleBuyRoleView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06035F8F RID: 221071 RVA: 0x00D94788 File Offset: 0x00D92988
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUILoopScrollViewComponent)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIItem)),
				new ValueTuple<int, Type>(6, typeof(UUIItem)),
				new ValueTuple<int, Type>(7, typeof(UUIItem)),
				new ValueTuple<int, Type>(8, typeof(UUIItem)),
				new ValueTuple<int, Type>(9, typeof(UUIButtonComponent))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(9, new Action(this.OnSelectOnPanelBack))
			};
		}

		// Token: 0x06035F90 RID: 221072 RVA: 0x00D948A1 File Offset: 0x00D92AA1
		private void OnBtnHelp()
		{
			ControllerBase<MapRogueController>.Instance.OpenMapHelpView();
		}

		// Token: 0x06035F91 RID: 221073 RVA: 0x00D948B0 File Offset: 0x00D92AB0
		private void OnBtnCancel()
		{
			MapRogueOpSelectView mapRogueOpSelectView = ModelBase<MapRogueModel>.Instance.GetOpData(this.IncId) as MapRogueOpSelectView;
			if (mapRogueOpSelectView == null)
			{
				return;
			}
			mapRogueOpSelectView.Select(-2);
		}

		// Token: 0x06035F92 RID: 221074 RVA: 0x00D948E0 File Offset: 0x00D92AE0
		private void OnBtnRefresh()
		{
			MapRogueOpSelectView mapRogueOpSelectView = ModelBase<MapRogueModel>.Instance.GetOpData(this.IncId) as MapRogueOpSelectView;
			if (mapRogueOpSelectView == null)
			{
				return;
			}
			RogueResOption rogueResOption = mapRogueOpSelectView.Data.SelectViewOp.RogueResOption;
			if (rogueResOption.RefreshCost > ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(rogueResOption.RefreshItem, 0))
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("RogueBattle_RefreshItemNotEnough", Array.Empty<object>());
				return;
			}
			if (rogueResOption.UseRefreshCount >= rogueResOption.MaxRefreshCount)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("RogueBattle_RefreshCountMax", Array.Empty<object>());
				return;
			}
			mapRogueOpSelectView.Select(-1);
		}

		// Token: 0x06035F93 RID: 221075 RVA: 0x00D94970 File Offset: 0x00D92B70
		private int GetGroupIndex(int index)
		{
			return index / 2;
		}

		// Token: 0x06035F94 RID: 221076 RVA: 0x00D94975 File Offset: 0x00D92B75
		private void OnSelectOnPanelBack()
		{
			if (this.ViewSelectState)
			{
				this.DeselectCurrentRole();
			}
		}

		// Token: 0x06035F95 RID: 221077 RVA: 0x00D94988 File Offset: 0x00D92B88
		private void DeselectCurrentRole()
		{
			if (this.SelectUiIndex >= 0)
			{
				int groupIndex = this.GetGroupIndex(this.SelectUiIndex);
				if (this.ScrollViewComponent.IsGridDisplaying(groupIndex))
				{
					RogueBattleBuyRoleGroupItem rogueBattleBuyRoleGroupItem = this.ScrollViewComponent.UnsafeGetGridProxy(groupIndex, false);
					if (rogueBattleBuyRoleGroupItem != null)
					{
						rogueBattleBuyRoleGroupItem.Deselect(this.SelectUiIndex);
					}
				}
			}
			this.SelectUiIndex = -1;
			this.SetViewState(false);
		}

		// Token: 0x06035F96 RID: 221078 RVA: 0x00D949E8 File Offset: 0x00D92BE8
		[NullableContext(1)]
		private void OnSelectCallback(int index, RogueResGainData data)
		{
			int selectUiIndex = this.SelectUiIndex;
			if (this.SelectUiIndex >= 0)
			{
				int groupIndex = this.GetGroupIndex(this.SelectUiIndex);
				if (this.ScrollViewComponent.IsGridDisplaying(groupIndex))
				{
					RogueBattleBuyRoleGroupItem rogueBattleBuyRoleGroupItem = this.ScrollViewComponent.UnsafeGetGridProxy(groupIndex, false);
					if (rogueBattleBuyRoleGroupItem != null)
					{
						rogueBattleBuyRoleGroupItem.Deselect(this.SelectUiIndex);
					}
				}
			}
			this.SelectUiIndex = index;
			RogueBattleBuyRoleGroupItem rogueBattleBuyRoleGroupItem2 = this.ScrollViewComponent.UnsafeGetGridProxy(this.GetGroupIndex(this.SelectUiIndex), false);
			if (rogueBattleBuyRoleGroupItem2 != null)
			{
				rogueBattleBuyRoleGroupItem2.Select(index);
			}
			RogueBattleShopButton refreshButton = this.RefreshButton;
			RogueResRole rogueResRole = data.RogueResRole;
			refreshButton.SetInteractive(rogueResRole == null || !rogueResRole.IsSell);
			this.PanelSelectOn.Refresh(data);
			this.SetViewState(true);
			if (selectUiIndex != -1)
			{
				if (selectUiIndex != this.SelectUiIndex)
				{
					UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
					if (uiViewSequence != null)
					{
						uiViewSequence.StopSequenceByKey("Switch02", false, true);
					}
					UiBehaviorLevelSequence uiViewSequence2 = this.UiViewSequence;
					if (uiViewSequence2 != null)
					{
						uiViewSequence2.StopSequenceByKey("Switch", false, true);
					}
					UiBehaviorLevelSequence uiViewSequence3 = this.UiViewSequence;
					if (uiViewSequence3 == null)
					{
						return;
					}
					uiViewSequence3.PlaySequence("Switch02", false, null);
				}
				return;
			}
			UiBehaviorLevelSequence uiViewSequence4 = this.UiViewSequence;
			if (uiViewSequence4 != null)
			{
				uiViewSequence4.StopSequenceByKey("Switch02", false, true);
			}
			UiBehaviorLevelSequence uiViewSequence5 = this.UiViewSequence;
			if (uiViewSequence5 != null)
			{
				uiViewSequence5.StopSequenceByKey("Switch", false, true);
			}
			UiBehaviorLevelSequence uiViewSequence6 = this.UiViewSequence;
			if (uiViewSequence6 == null)
			{
				return;
			}
			uiViewSequence6.PlaySequence("Switch", false, null);
		}

		// Token: 0x06035F97 RID: 221079 RVA: 0x00D94B48 File Offset: 0x00D92D48
		private bool IsSelectOn(int index)
		{
			return this.SelectUiIndex == index;
		}

		// Token: 0x06035F98 RID: 221080 RVA: 0x00D94B53 File Offset: 0x00D92D53
		[NullableContext(1)]
		private RogueBattleBuyRoleGroupItem CreateItem()
		{
			return new RogueBattleBuyRoleGroupItem
			{
				OnSelectCallback = new Action<int, RogueResGainData>(this.OnSelectCallback),
				IsSelectOn = new Func<int, bool>(this.IsSelectOn)
			};
		}

		// Token: 0x06035F99 RID: 221081 RVA: 0x00D94B80 File Offset: 0x00D92D80
		protected override UniTask OnBeforeStartAsync()
		{
			RogueBattleBuyRoleView.<OnBeforeStartAsync>d__20 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RogueBattleBuyRoleView.<OnBeforeStartAsync>d__20>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06035F9A RID: 221082 RVA: 0x00D94BC3 File Offset: 0x00D92DC3
		private void InitViewState()
		{
			this.ViewSelectState = false;
			this.CaptionItem.SetCloseBtnActive(true);
			this.CaptionItem.SetHelpBtnActive(true);
			base.GetItem(5).SetUIActive(true);
			base.GetItem(7).SetUIActive(false);
		}

		// Token: 0x06035F9B RID: 221083 RVA: 0x00D94C00 File Offset: 0x00D92E00
		private void SetViewState(bool selectOn)
		{
			if (this.ViewSelectState == selectOn)
			{
				return;
			}
			this.ViewSelectState = selectOn;
			this.CaptionItem.SetCloseBtnActive(!selectOn);
			this.CaptionItem.SetHelpBtnActive(!selectOn);
			this.RefreshBtnRefresh();
			UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
			if (uiViewSequence != null)
			{
				uiViewSequence.StopSequenceByKey("SwClose", false, true);
			}
			base.GetItem(7).SetUIActive(true);
			if (!selectOn)
			{
				this.PanelFetter.RefreshFetter();
				UiBehaviorLevelSequence uiViewSequence2 = this.UiViewSequence;
				if (uiViewSequence2 == null)
				{
					return;
				}
				uiViewSequence2.PlaySequence("SwClose", false, null);
			}
		}

		// Token: 0x06035F9C RID: 221084 RVA: 0x00D94C94 File Offset: 0x00D92E94
		private UniTask RefreshRoleList()
		{
			RogueBattleBuyRoleView.<RefreshRoleList>d__23 <RefreshRoleList>d__;
			<RefreshRoleList>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshRoleList>d__.<>4__this = this;
			<RefreshRoleList>d__.<>1__state = -1;
			<RefreshRoleList>d__.<>t__builder.Start<RogueBattleBuyRoleView.<RefreshRoleList>d__23>(ref <RefreshRoleList>d__);
			return <RefreshRoleList>d__.<>t__builder.Task;
		}

		// Token: 0x06035F9D RID: 221085 RVA: 0x00D94CD8 File Offset: 0x00D92ED8
		private void RefreshBtnRefresh()
		{
			MapRogueOpSelectView mapRogueOpSelectView = ModelBase<MapRogueModel>.Instance.GetOpData(this.IncId) as MapRogueOpSelectView;
			if (mapRogueOpSelectView == null)
			{
				return;
			}
			RogueResOption rogueResOption = mapRogueOpSelectView.Data.SelectViewOp.RogueResOption;
			bool flag = rogueResOption.MaxRefreshCount > 0 && !this.ViewSelectState;
			this.RefreshButton.SetActive(flag);
			if (!flag)
			{
				return;
			}
			if (rogueResOption.RefreshCost != 0)
			{
				int itemCountByConfigId = ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(rogueResOption.RefreshItem, 0);
				this.RefreshButton.SetCostText(rogueResOption.RefreshCost.ToString(), new bool?(itemCountByConfigId < rogueResOption.RefreshCost));
			}
			this.RefreshButton.SetText("RogueBattle_BuyRole_RefreshCost", new object[]
			{
				rogueResOption.UseRefreshCount,
				rogueResOption.MaxRefreshCount
			});
			if (rogueResOption.RefreshItem != 0)
			{
				this.RefreshButton.SetCostItem(rogueResOption.RefreshItem);
			}
		}

		// Token: 0x06035F9E RID: 221086 RVA: 0x00D94DC8 File Offset: 0x00D92FC8
		[NullableContext(1)]
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
			string a = configParams[0];
			if (a == "FirstRole")
			{
				LoopScrollView<RogueBattleBuyRoleGroupItem, RoleBuyInfoGroupData> scrollViewComponent = this.ScrollViewComponent;
				if (scrollViewComponent == null)
				{
					return null;
				}
				RogueBattleBuyRoleGroupItem rogueBattleBuyRoleGroupItem = scrollViewComponent.UnsafeGetGridProxy(0, false);
				if (rogueBattleBuyRoleGroupItem == null)
				{
					return null;
				}
				return rogueBattleBuyRoleGroupItem.GetGuideUiItemAndUiItemForShowEx(configParams);
			}
			else
			{
				if (!(a == "FirstFetter"))
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
		}

		// Token: 0x0401F008 RID: 126984
		private int SelectUiIndex = -1;

		// Token: 0x0401F009 RID: 126985
		private bool ViewSelectState;

		// Token: 0x0401F00A RID: 126986
		private int IncId;

		// Token: 0x0401F00B RID: 126987
		private MapRogueTitleItem MapTitleItem;

		// Token: 0x0401F00C RID: 126988
		private PopupCaptionItem CaptionItem;

		// Token: 0x0401F00D RID: 126989
		private MapRoguePanelFetter PanelFetter;

		// Token: 0x0401F00E RID: 126990
		private RogueBattleBuyRolePreviewPanel PanelSelectOn;

		// Token: 0x0401F00F RID: 126991
		private RogueBattleShopButton RefreshButton;

		// Token: 0x0401F010 RID: 126992
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private LoopScrollView<RogueBattleBuyRoleGroupItem, RoleBuyInfoGroupData> ScrollViewComponent;
	}
}
