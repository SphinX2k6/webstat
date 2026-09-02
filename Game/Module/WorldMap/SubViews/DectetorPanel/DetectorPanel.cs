using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Map;
using CSharpScript.Game.Module.Map.Controller;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.Map.Marks.MarkItem;
using CSharpScript.Game.Module.Map.Misc;
using CSharpScript.Game.Module.WorldMap.SubViews.WorldMapSecondaryUiLayout;
using UnrealEngine;

namespace CSharpScript.Game.Module.WorldMap.SubViews.DectetorPanel
{
	// Token: 0x02004BC3 RID: 19395
	public class DetectorPanel : WorldMapSecondaryUiLayoutA
	{
		// Token: 0x06032A00 RID: 207360 RVA: 0x00CAE3FB File Offset: 0x00CAC5FB
		[NullableContext(1)]
		public override string GetResourceId()
		{
			return "UiItem_GeneralPanel_Prefab";
		}

		// Token: 0x06032A01 RID: 207361 RVA: 0x00CAE404 File Offset: 0x00CAC604
		protected override void SetupWorldMapSecondaryUiLayout()
		{
			base.SetupWorldMapSecondaryUiLayout();
			UUIItem item = base.GetItem(12);
			if (item != null)
			{
				item.SetUIActive(false);
			}
			UUIItem item2 = base.GetItem(2);
			if (item2 != null)
			{
				item2.SetUIActive(false);
			}
			UUIVerticalLayout verticalLayout = base.GetVerticalLayout(7);
			if (verticalLayout != null)
			{
				verticalLayout.RootUIComp.Get().SetUIActive(false);
			}
			UUIItem item3 = base.GetItem(6);
			if (item3 != null)
			{
				item3.SetUIActive(false);
			}
			UUIVerticalLayout verticalLayout2 = base.GetVerticalLayout(5);
			if (verticalLayout2 != null)
			{
				verticalLayout2.RootUIComp.Get().SetUIActive(false);
			}
			WorldMapSecondaryUiContext layoutContext = this.LayoutContext;
			if (layoutContext != null)
			{
				UUIButtonComponent delButton = layoutContext.DelButton;
				if (delButton != null)
				{
					delButton.RootUIComp.Get().SetUIActive(true);
				}
			}
			WorldMapSecondaryUiContext layoutContext2 = this.LayoutContext;
			if (layoutContext2 == null)
			{
				return;
			}
			layoutContext2.SetConfirmBtnActive(false);
		}

		// Token: 0x06032A02 RID: 207362 RVA: 0x00CAE4CC File Offset: 0x00CAC6CC
		[NullableContext(1)]
		protected override void OnShowWorldMapSecondaryUi(params object[] param)
		{
			if (param.Length != 0)
			{
				TreasureBoxDetectorMarkItem treasureBoxDetectorMarkItem = param[0] as TreasureBoxDetectorMarkItem;
				if (treasureBoxDetectorMarkItem != null)
				{
					this.SelectedMarkItem = treasureBoxDetectorMarkItem;
					this.LayoutContext.MarkItem = treasureBoxDetectorMarkItem;
					int valueOrDefault = ConfigCommonParamById.GetIntConfig("TreasureBoxDetectionMaxNum").GetValueOrDefault();
					int markCountByType = ModelBase<MapModel>.Instance.GetMarkCountByType(EMarkType.TreasureBoxDetector);
					string newText = StringUtils.Format("{0}{1}/{2}", new string[]
					{
						this.SelectedMarkItem.GetTitleText() ?? "",
						markCountByType.ToString(),
						valueOrDefault.ToString()
					});
					UUIText text = base.GetText(1);
					if (text != null)
					{
						text.SetText(newText, true);
					}
					UUIText descriptionText = this.LayoutContext.DescriptionText;
					if (descriptionText != null)
					{
						descriptionText.SetText(treasureBoxDetectorMarkItem.GetDescText() ?? "", true);
					}
					this.SetSpriteByPath(this.SelectedMarkItem.IconPath, base.GetSprite(0), false, null, null);
					WorldMapSecondaryUiLayoutHelper.UpdateConfirmButtonTextWithTrackStyle(this.LayoutContext);
					WorldMapSecondaryUiLayoutHelper.UpdateTrackButtonTextWithTrackStyle(this.LayoutContext);
					base.UpdateQuickGotoActive(true);
				}
			}
		}

		// Token: 0x06032A03 RID: 207363 RVA: 0x00CAE5DC File Offset: 0x00CAC7DC
		protected unsafe override void HandleTrack()
		{
			TreasureBoxDetectorMarkItem treasureBoxDetectorMarkItem = this.LayoutContext.MarkItem as TreasureBoxDetectorMarkItem;
			if (treasureBoxDetectorMarkItem == null)
			{
				return;
			}
			base.CheckAndShowCrossMapTips(treasureBoxDetectorMarkItem);
			ELogAuthor author = ELogAuthor.LRX;
			string message = "[地图系统]->追踪";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("markId", treasureBoxDetectorMarkItem.MarkId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("IsTracked", treasureBoxDetectorMarkItem.IsTracked);
			MapLogger.Debug(author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			ControllerBase<MapController>.Instance.RequestTrackMapMark(new TrackMapMarkParams
			{
				MarkType = treasureBoxDetectorMarkItem.MarkType,
				MarkId = treasureBoxDetectorMarkItem.MarkId,
				Track = !treasureBoxDetectorMarkItem.IsTracked,
				TrackMode = new ETrackMapMarkMode?(ETrackMapMarkMode.Local)
			}, null);
			base.Close();
		}

		// Token: 0x06032A04 RID: 207364 RVA: 0x00CAE6AE File Offset: 0x00CAC8AE
		protected override void OnDelBtnClick()
		{
			if (this.SelectedMarkItem != null && this.SelectedMarkItem.MarkId > 0)
			{
				ControllerBase<MapExploreToolController>.Instance.RemoveTreasureBoxSlotRequest(this.SelectedMarkItem.MarkId);
			}
			base.Close();
		}

		// Token: 0x0401D7F2 RID: 120818
		[Nullable(2)]
		private TreasureBoxDetectorMarkItem SelectedMarkItem;

		// Token: 0x0200ACA9 RID: 44201
		public static class EComponents
		{
			// Token: 0x04035A4E RID: 219726
			public const int DetectorPanel = 0;
		}
	}
}
