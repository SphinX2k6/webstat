using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Map.Marks.MarkItem;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Module.VillageInfr;
using CSharpScript.Game.Module.WorldMap.SubViews.WorldMapSecondaryUiLayout;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.WorldMap.SubViews.VillageInfrPanel
{
	// Token: 0x02004B7C RID: 19324
	[NullableContext(1)]
	[Nullable(0)]
	public class VillageInfrTreePanel : WorldMapSecondaryUiLayoutA
	{
		// Token: 0x06032796 RID: 206742 RVA: 0x00CA0C06 File Offset: 0x00C9EE06
		public override string GetResourceId()
		{
			return "UiItem_GeneralPanel_Prefab";
		}

		// Token: 0x06032797 RID: 206743 RVA: 0x00CA0C10 File Offset: 0x00C9EE10
		protected override UniTask OnBeforeStartAsync()
		{
			VillageInfrTreePanel.<OnBeforeStartAsync>d__3 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<VillageInfrTreePanel.<OnBeforeStartAsync>d__3>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06032798 RID: 206744 RVA: 0x00CA0C54 File Offset: 0x00C9EE54
		protected override void SetupWorldMapSecondaryUiLayout()
		{
			base.SetupWorldMapSecondaryUiLayout();
			base.GetVerticalLayout(7).RootUIComp.Get().SetUIActive(false);
			base.GetItem(6).SetUIActive(false);
			base.GetItem(14).SetUIActive(true);
			base.GetVerticalLayout(5).RootUIComp.Get().SetUIActive(true);
		}

		// Token: 0x06032799 RID: 206745 RVA: 0x00CA0CB8 File Offset: 0x00C9EEB8
		private UniTask CreateRewardItemBar()
		{
			VillageInfrTreePanel.<CreateRewardItemBar>d__5 <CreateRewardItemBar>d__;
			<CreateRewardItemBar>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateRewardItemBar>d__.<>4__this = this;
			<CreateRewardItemBar>d__.<>1__state = -1;
			<CreateRewardItemBar>d__.<>t__builder.Start<VillageInfrTreePanel.<CreateRewardItemBar>d__5>(ref <CreateRewardItemBar>d__);
			return <CreateRewardItemBar>d__.<>t__builder.Task;
		}

		// Token: 0x0603279A RID: 206746 RVA: 0x00CA0CFC File Offset: 0x00C9EEFC
		protected override void OnShowWorldMapSecondaryUi(params object[] parameters)
		{
			VillageInfrTreeMarkItem villageInfrTreeMarkItem = (VillageInfrTreeMarkItem)parameters[0];
			this.LayoutContext.MarkItem = villageInfrTreeMarkItem;
			this.UpdateConfirmButtonEnableClickByTeleportState();
			WorldMapSecondaryUiLayoutHelper.UpdateConfirmButtonTextWithFastMoveStyle(this.LayoutContext);
			WorldMapSecondaryUiLayoutHelper.UpdateTrackButtonTextWithTrackStyle(this.LayoutContext);
			WorldMapSecondaryUiLayoutHelper.UpdateIconAndTitle(this.LayoutContext);
			WorldMapSecondaryUiLayoutHelper.UpdateAreaTxtByConfigMarkItem(this.LayoutContext);
			base.GetText(4).ShowTextNew(villageInfrTreeMarkItem.GetLocaleDesc());
			base.UpdateMultiMap();
			base.UpdateTopRightIconActive();
			bool flag = base.UpdateQuickGoto();
			this.LayoutContext.SetConfirmBtnActive(!flag);
			this.RefreshGiftTip();
			this.VerticalLayout.RefreshByData(this.GetVerticalLayoutData(), null, false);
			this.RefreshRewardItemBar();
		}

		// Token: 0x0603279B RID: 206747 RVA: 0x00CA0DA4 File Offset: 0x00C9EFA4
		private void UpdateConfirmButtonEnableClickByTeleportState()
		{
			VillageInfrTreeMarkItem villageInfrTreeMarkItem = (VillageInfrTreeMarkItem)this.LayoutContext.MarkItem;
			this.LayoutContext.SetConfirmBtnEnableClick(!villageInfrTreeMarkItem.IsLocked);
		}

		// Token: 0x0603279C RID: 206748 RVA: 0x00CA0DD8 File Offset: 0x00C9EFD8
		private void RefreshGiftTip()
		{
			VillageInfrTreeMarkItem villageInfrTreeMarkItem = (VillageInfrTreeMarkItem)this.LayoutContext.MarkItem;
			InfrV2TreeBuild? treeConfigByMarkId = ConfigBase<VillageInfrConfig>.Instance.GetTreeConfigByMarkId(villageInfrTreeMarkItem.MarkId);
			if (ModelBase<VillageInfrModel>.Instance.GetCanTreeLevelUp(treeConfigByMarkId.Value.Id))
			{
				base.GetItem(25).SetUIActive(true);
				base.GetText(30).ShowTextNew("VillageInfr_Map_Tree5");
				return;
			}
			base.GetItem(25).SetUIActive(false);
		}

		// Token: 0x0603279D RID: 206749 RVA: 0x00CA0E54 File Offset: 0x00C9F054
		private List<IMapSubViewListItemData> GetVerticalLayoutData()
		{
			VillageInfrTreeMarkItem villageInfrTreeMarkItem = (VillageInfrTreeMarkItem)this.LayoutContext.MarkItem;
			InfrV2TreeBuild? treeConfigByMarkId = ConfigBase<VillageInfrConfig>.Instance.GetTreeConfigByMarkId(villageInfrTreeMarkItem.MarkId);
			IVillageInfrTreeData treeData = ModelBase<VillageInfrModel>.Instance.GetTreeData(treeConfigByMarkId.Value.Id);
			InfrV2StatusPb infrV2StatusPb = (treeData != null) ? treeData.Status : InfrV2StatusPb.InfrV2StatusLock;
			MapSubViewListItemData item = new MapSubViewListItemData
			{
				LeftTextId = "VillageInfr_Map_Tree1",
				RightTextId = ((infrV2StatusPb == InfrV2StatusPb.InfrV2StatusComplete) ? "VillageInfr_Map_Tree3" : "VillageInfr_Map_Tree2"),
				ShowBtnHelp = false,
				ShowIcon = false,
				ShowSprite = false,
				ShowScaleIcon = false
			};
			return new List<IMapSubViewListItemData>
			{
				item
			};
		}

		// Token: 0x0603279E RID: 206750 RVA: 0x00CA0EFC File Offset: 0x00C9F0FC
		private void RefreshRewardItemBar()
		{
			VillageInfrTreeMarkItem villageInfrTreeMarkItem = (VillageInfrTreeMarkItem)this.LayoutContext.MarkItem;
			InfrV2TreeBuild? treeConfigByMarkId = ConfigBase<VillageInfrConfig>.Instance.GetTreeConfigByMarkId(villageInfrTreeMarkItem.MarkId);
			IVillageInfrTreeData treeData = ModelBase<VillageInfrModel>.Instance.GetTreeData(treeConfigByMarkId.Value.Id);
			if (treeData != null && treeData.Status == InfrV2StatusPb.InfrV2StatusComplete)
			{
				return;
			}
			base.GetVerticalLayout(7).RootUIComp.Get().SetUIActive(true);
			base.GetItem(8).SetUIActive(true);
			TItem[] data = (from r in treeConfigByMarkId.Value.RequirementIter()
			orderby r.Key
			select new TItem(new InventoryDefine.GetItemData(r.Key, 0), r.Value)).ToArray<TItem>();
			this.RewardsView.RebuildRewardsByData(data);
			this.RewardsView.SetTitleNewTxt("VillageInfr_Map_Tree4");
		}

		// Token: 0x0401D72A RID: 120618
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<MapVerticalLayoutItem, IMapSubViewListItemData> VerticalLayout;

		// Token: 0x0401D72B RID: 120619
		public MapSubViewRewardPanel RewardsView = new MapSubViewRewardPanel();
	}
}
