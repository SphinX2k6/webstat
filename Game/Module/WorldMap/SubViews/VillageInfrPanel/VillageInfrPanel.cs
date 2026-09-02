using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Map.Marks.MarkItem;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Module.VillageInfr;
using CSharpScript.Game.Module.WorldMap.SubViews.WorldMapSecondaryUiLayout;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.WorldMap.SubViews.VillageInfrPanel
{
	// Token: 0x02004B7B RID: 19323
	[NullableContext(1)]
	[Nullable(0)]
	public class VillageInfrPanel : WorldMapSecondaryUiLayoutA
	{
		// Token: 0x0603278C RID: 206732 RVA: 0x00CA0971 File Offset: 0x00C9EB71
		public override string GetResourceId()
		{
			return "UiItem_GeneralPanel_Prefab";
		}

		// Token: 0x0603278D RID: 206733 RVA: 0x00CA0978 File Offset: 0x00C9EB78
		protected override UniTask OnBeforeStartAsync()
		{
			VillageInfrPanel.<OnBeforeStartAsync>d__2 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<VillageInfrPanel.<OnBeforeStartAsync>d__2>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603278E RID: 206734 RVA: 0x00CA09BC File Offset: 0x00C9EBBC
		protected override void SetupWorldMapSecondaryUiLayout()
		{
			base.SetupWorldMapSecondaryUiLayout();
			base.GetVerticalLayout(7).RootUIComp.Get().SetUIActive(false);
			base.GetItem(6).SetUIActive(false);
			base.GetItem(14).SetUIActive(true);
			base.GetVerticalLayout(5).RootUIComp.Get().SetUIActive(true);
		}

		// Token: 0x0603278F RID: 206735 RVA: 0x00CA0A20 File Offset: 0x00C9EC20
		protected override void OnShowWorldMapSecondaryUi(params object[] parameters)
		{
			ConfigMarkItem configMarkItem = parameters[0] as ConfigMarkItem;
			this.LayoutContext.MarkItem = configMarkItem;
			this.UpdateConfirmButtonEnableClickByTeleportState();
			WorldMapSecondaryUiLayoutHelper.UpdateConfirmButtonTextWithFastMoveStyle(this.LayoutContext);
			WorldMapSecondaryUiLayoutHelper.UpdateTrackButtonTextWithTrackStyle(this.LayoutContext);
			WorldMapSecondaryUiLayoutHelper.UpdateIconAndTitle(this.LayoutContext);
			WorldMapSecondaryUiLayoutHelper.UpdateAreaTxtByConfigMarkItem(this.LayoutContext);
			base.GetText(4).ShowTextNew(configMarkItem.GetLocaleDesc());
			base.UpdateMultiMap();
			base.UpdateTopRightIconByTeleportState();
			bool flag = base.UpdateQuickGoto();
			this.LayoutContext.SetConfirmBtnActive(!flag);
			this.RefreshGiftTip();
			this.RefreshVerticalLayout();
		}

		// Token: 0x06032790 RID: 206736 RVA: 0x00CA0AB4 File Offset: 0x00C9ECB4
		private void UpdateConfirmButtonEnableClickByTeleportState()
		{
			ConfigMarkItem configMarkItem = this.LayoutContext.MarkItem as ConfigMarkItem;
			this.LayoutContext.SetConfirmBtnEnableClick(configMarkItem == null || !configMarkItem.IsLocked);
		}

		// Token: 0x06032791 RID: 206737 RVA: 0x00CA0AEC File Offset: 0x00C9ECEC
		private void RefreshGiftTip()
		{
			if (ModelBase<VillageInfrModel>.Instance.GetCanVillageLevelUp())
			{
				base.GetItem(25).SetUIActive(true);
				base.GetText(30).ShowTextNew("VillageInfr_Map_Village2");
				return;
			}
			base.GetItem(25).SetUIActive(false);
		}

		// Token: 0x06032792 RID: 206738 RVA: 0x00CA0B2C File Offset: 0x00C9ED2C
		private void RefreshVerticalLayout()
		{
			this.VerticalLayout.RefreshByData(this.GetVerticalLayoutData(), null, false);
			int villageLevel = ModelBase<VillageInfrModel>.Instance.GetVillageLevel();
			int infrMaxLevel = ConfigBase<VillageInfrConfig>.Instance.GetInfrMaxLevel();
			base.GetText(51).SetUIActive(villageLevel >= infrMaxLevel);
			base.GetText(51).ShowTextNew("VillageInfr_Map_Village3");
		}

		// Token: 0x06032793 RID: 206739 RVA: 0x00CA0B88 File Offset: 0x00C9ED88
		private List<IMapSubViewListItemData> GetVerticalLayoutData()
		{
			InfrV2Level? infrLevel = ConfigBase<VillageInfrConfig>.Instance.GetInfrLevel(ModelBase<VillageInfrModel>.Instance.GetVillageLevel());
			return new List<IMapSubViewListItemData>
			{
				new MapSubViewListItemData
				{
					LeftTextId = "VillageInfr_Map_Village1",
					RightTextId = infrLevel.Value.Name,
					ShowBtnHelp = false,
					ShowIcon = false,
					ShowSprite = false,
					ShowScaleIcon = false
				}
			};
		}

		// Token: 0x0401D729 RID: 120617
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<MapVerticalLayoutItem, IMapSubViewListItemData> VerticalLayout;
	}
}
