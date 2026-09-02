using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Map;
using CSharpScript.Game.Module.Map.Controller;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.Map.Marks.MarkItem;
using CSharpScript.Game.Module.Map.Misc;
using CSharpScript.Game.Module.WorldMap.SubViews.WorldMapSecondaryUiLayout;
using UnrealEngine;

namespace CSharpScript.Game.Module.WorldMap.SubViews.Enrichment
{
	// Token: 0x02004BC1 RID: 19393
	public class EnrichmentAreaPanel : WorldMapSecondaryUiLayoutA
	{
		// Token: 0x060329F1 RID: 207345 RVA: 0x00CADEC5 File Offset: 0x00CAC0C5
		[NullableContext(1)]
		public override string GetResourceId()
		{
			return "UiItem_GeneralPanel_Prefab";
		}

		// Token: 0x060329F2 RID: 207346 RVA: 0x00CADECC File Offset: 0x00CAC0CC
		protected override void SetupWorldMapSecondaryUiLayout()
		{
			base.SetupWorldMapSecondaryUiLayout();
			UUIVerticalLayout verticalLayout = base.GetVerticalLayout(7);
			if (verticalLayout != null)
			{
				verticalLayout.RootUIComp.Get().SetUIActive(false);
			}
			UUIItem item = base.GetItem(6);
			if (item != null)
			{
				item.SetUIActive(false);
			}
			WorldMapSecondaryUiContext layoutContext = this.LayoutContext;
			if (layoutContext != null)
			{
				layoutContext.SetConfirmBtnActive(false);
			}
			WorldMapSecondaryUiContext layoutContext2 = this.LayoutContext;
			if (layoutContext2 == null)
			{
				return;
			}
			UUIButtonComponent delButton = layoutContext2.DelButton;
			if (delButton == null)
			{
				return;
			}
			delButton.RootUIComp.Get().SetUIActive(true);
		}

		// Token: 0x060329F3 RID: 207347 RVA: 0x00CADF4C File Offset: 0x00CAC14C
		[NullableContext(1)]
		protected override void OnShowWorldMapSecondaryUi(params object[] param)
		{
			if (param.Length != 0)
			{
				EnrichmentAreaItem enrichmentAreaItem = param[0] as EnrichmentAreaItem;
				if (enrichmentAreaItem != null)
				{
					this.SelectedMarkItem = enrichmentAreaItem;
					this.LayoutContext.MarkItem = enrichmentAreaItem;
					WorldMapSecondaryUiLayoutHelper.UpdateConfirmButtonEnableClickByTeleportState(this.LayoutContext);
					string markTitle = this.SelectedMarkItem.MarkConfig.MarkTitle;
					MapConfig instance = ConfigBase<MapConfig>.Instance;
					string item = (instance != null) ? instance.GetLocalText(this.SelectedMarkItem.GetEnrichmentItemNameId()) : null;
					Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), markTitle, new <>z__ReadOnlySingleElementList<object>(item));
					WorldMapSecondaryUiLayoutHelper.UpdateAreaTxtByServerMarkItem(this.LayoutContext);
					WorldMapSecondaryUiLayoutHelper.UpdateTrackButtonTextWithTrackStyle(this.LayoutContext);
					string markDesc = this.SelectedMarkItem.MarkConfig.MarkDesc;
					Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), markDesc, new <>z__ReadOnlySingleElementList<object>(item));
					this.SetSpriteByPath(this.SelectedMarkItem.IconPath, base.GetSprite(0), false, null, null);
					base.UpdateRightDownIconActive();
					base.UpdateTopRightIconByTeleportState();
					base.UpdateQuickGotoActive(true);
				}
			}
		}

		// Token: 0x060329F4 RID: 207348 RVA: 0x00CAE054 File Offset: 0x00CAC254
		protected unsafe override void HandleTrack()
		{
			EnrichmentAreaItem enrichmentAreaItem = this.LayoutContext.MarkItem as EnrichmentAreaItem;
			if (enrichmentAreaItem == null)
			{
				return;
			}
			base.CheckAndShowCrossMapTips(enrichmentAreaItem);
			ELogAuthor author = ELogAuthor.LRX;
			string message = "[地图系统]->追踪";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("markId", enrichmentAreaItem.MarkId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("IsTracked", enrichmentAreaItem.IsTracked);
			MapLogger.Debug(author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			ControllerBase<MapController>.Instance.RequestTrackMapMark(new TrackMapMarkParams
			{
				MarkType = enrichmentAreaItem.MarkType,
				MarkId = enrichmentAreaItem.MarkId,
				Track = !enrichmentAreaItem.IsTracked,
				TrackMode = new ETrackMapMarkMode?(ETrackMapMarkMode.Local)
			}, null);
			base.Close();
		}

		// Token: 0x060329F5 RID: 207349 RVA: 0x00CAE128 File Offset: 0x00CAC328
		protected override void OnDelBtnClick()
		{
			if (this.SelectedMarkItem == null)
			{
				return;
			}
			ControllerBase<MapController>.Instance.RequestTrackEnrichmentArea(null);
			base.Close();
		}

		// Token: 0x0401D7EF RID: 120815
		[Nullable(2)]
		private EnrichmentAreaItem SelectedMarkItem;

		// Token: 0x0200ACA5 RID: 44197
		public static class EComponents
		{
			// Token: 0x04035A41 RID: 219713
			public const int EnrichmentAreaPanel = 0;
		}
	}
}
