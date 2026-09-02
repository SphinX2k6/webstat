using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common;
using CSharpScript.Game.Module.Area;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x0200681D RID: 26653
	[NullableContext(1)]
	[Nullable(0)]
	public class FishingHandBookView : UiViewBase
	{
		// Token: 0x060426D3 RID: 272083 RVA: 0x01107E72 File Offset: 0x01106072
		public FishingHandBookView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x060426D4 RID: 272084 RVA: 0x01107E88 File Offset: 0x01106088
		protected unsafe override void OnRegisterComponent()
		{
			int num = 21;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUILoopScrollViewComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIVerticalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(17, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(18, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(19, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(20, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(16, new Action(this.OnClickTraceBtn));
			this.BtnBindInfo = list2;
		}

		// Token: 0x060426D5 RID: 272085 RVA: 0x011081B0 File Offset: 0x011063B0
		protected override UniTask OnBeforeStartAsync()
		{
			FishingHandBookView.<OnBeforeStartAsync>d__15 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<FishingHandBookView.<OnBeforeStartAsync>d__15>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060426D6 RID: 272086 RVA: 0x011081F4 File Offset: 0x011063F4
		protected override void OnStart()
		{
			List<IFishingHandBookItemData> fishingItemList = ModelBase<FishingModel>.Instance.GetFishingItemList();
			FilterSortEntrance<IFishingHandBookItemData> filterSortBtn = this.FilterSortBtn;
			if (filterSortBtn != null)
			{
				filterSortBtn.UpdateData(EFilterSortGroupId.FishingItem, fishingItemList, Array.Empty<object>());
			}
			UUIText text = base.GetText(3);
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted<int>(ModelBase<FishingModel>.Instance.UnLockFishingItemCount);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted<int>(ModelBase<FishingModel>.Instance.AllFishingItemCount);
			text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
		}

		// Token: 0x060426D7 RID: 272087 RVA: 0x01108270 File Offset: 0x01106470
		private void RefreshView(int itemId)
		{
			this.ItemId = itemId;
			FishingItem? fishingItemConfig = ConfigBase<FishingConfig>.Instance.GetFishingItemConfig(itemId);
			if (fishingItemConfig.Value.TechLength > 0)
			{
				GenericLayout<FishingHandBookTagItem, int> tagItemLayout = this.TagItemLayout;
				if (tagItemLayout != null)
				{
					tagItemLayout.RefreshByData(fishingItemConfig.Value.Tech().ToList<int>(), null, false);
				}
				base.GetItem(12).SetUIActive(true);
			}
			else
			{
				base.GetItem(12).SetUIActive(false);
			}
			this.RelationItemId = 0;
			if (fishingItemConfig.Value.Relation > 0)
			{
				this.RelationItemId = fishingItemConfig.Value.Relation;
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(20), "FishingRelationText", Array.Empty<object>());
				FishingHandBookItem relationItem = this.RelationItem;
				if (relationItem != null)
				{
					relationItem.Refresh(this.RelationItemId, false, 0);
				}
			}
			else if (fishingItemConfig.Value.ChildRelation > 0)
			{
				this.RelationItemId = fishingItemConfig.Value.ChildRelation;
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(20), "FishingChildRelationText", Array.Empty<object>());
				FishingHandBookItem relationItem2 = this.RelationItem;
				if (relationItem2 != null)
				{
					relationItem2.Refresh(this.RelationItemId, false, 0);
				}
			}
			base.GetItem(10).SetUIActive(this.RelationItemId > 0);
			IFishingHandBook fishingHandBook;
			bool flag = !ModelBase<FishingModel>.Instance.FishingItemHandBookDataMap.TryGetValue(itemId, out fishingHandBook);
			string text = flag ? ConfigMultiTextLang.GetLocalTextNew("FishingLockItemName", null) : ConfigMultiTextLang.GetLocalTextNew(fishingItemConfig.Value.Name, null);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(11), "Fishing_ArchiveTitle", new <>z__ReadOnlyArray<object>(new object[]
			{
				fishingItemConfig.Value.IllustratedNum.ToString(),
				text
			}));
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(8), flag ? "FishingLockItemName" : fishingItemConfig.Value.Desc, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(7), flag ? "FishingItemLockState" : "FishingItemUnlockState", Array.Empty<object>());
			FishingQuestShapePanel fishingShapePanel = this.FishingShapePanel;
			if (fishingShapePanel != null)
			{
				fishingShapePanel.RefreshPanel(itemId, !flag);
			}
			this.RefreshDesLayout(itemId);
			bool flag2 = ModelBase<FishingModel>.Instance.FishingItemHandBookUnlockTraceList.Contains(this.ItemId);
			UUIButtonComponent button = base.GetButton(16);
			if (!flag)
			{
				button.RootUIComp.Get().SetUIActive(true);
				button.SetSelfInteractive(true);
				base.GetItem(17).SetUIActive(false);
			}
			else if (flag2)
			{
				button.RootUIComp.Get().SetUIActive(true);
				button.SetSelfInteractive(true);
				base.GetItem(17).SetUIActive(false);
			}
			else if (fishingItemConfig.Value.DetectionUnlockCondition > 0)
			{
				button.RootUIComp.Get().SetUIActive(false);
				base.GetItem(17).SetUIActive(true);
				ConditionGroup? conditionGroupConfig = ConfigBase<ConditionConfig>.Instance.GetConditionGroupConfig(fishingItemConfig.Value.DetectionUnlockCondition);
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(18), conditionGroupConfig.Value.HintText, Array.Empty<object>());
			}
			else
			{
				button.RootUIComp.Get().SetUIActive(true);
				button.SetSelfInteractive(false);
				button.SetCanClickWhenDisable(true);
				base.GetItem(17).SetUIActive(false);
			}
			this.ReadItemNewFlag();
		}

		// Token: 0x060426D8 RID: 272088 RVA: 0x011085F4 File Offset: 0x011067F4
		private void RefreshDesLayout(int itemId)
		{
			FishingItem? fishingItemConfig = ConfigBase<FishingConfig>.Instance.GetFishingItemConfig(itemId);
			List<IFishingHandBookDesData> list = new List<IFishingHandBookDesData>();
			if (fishingItemConfig.Value.AreaLength > 0)
			{
				int areaId = fishingItemConfig.Value.Area(0);
				Area? areaInfo = ConfigBase<AreaConfig>.Instance.GetAreaInfo(areaId);
				string areaLocalName = ConfigBase<AreaConfig>.Instance.GetAreaLocalName(areaInfo.Value.Title);
				FishingHandBookDesData item = new FishingHandBookDesData
				{
					DesText = "Fishing_Area",
					DataText = areaLocalName
				};
				list.Add(item);
			}
			if (fishingItemConfig.Value.Time > 0)
			{
				string dataText = ConfigMultiTextLang.GetLocalTextNew(FishingDefine.fishingItemTimeText[fishingItemConfig.Value.Time], null) ?? "";
				FishingHandBookDesData item2 = new FishingHandBookDesData
				{
					DesText = "Fishing_Time",
					DataText = dataText
				};
				list.Add(item2);
			}
			if (fishingItemConfig.Value.SizeWeightLength > 0)
			{
				IFishingHandBook fishingHandBook2;
				IFishingHandBook fishingHandBook = ModelBase<FishingModel>.Instance.FishingItemHandBookDataMap.TryGetValue(itemId, out fishingHandBook2) ? fishingHandBook2 : null;
				if (fishingHandBook == null)
				{
					string dataText2 = ConfigMultiTextLang.GetLocalTextNew("FishingLockItemName", null) ?? "";
					FishingHandBookDesData item3 = new FishingHandBookDesData
					{
						DesText = "Fishing_MinSize",
						DataText = dataText2
					};
					FishingHandBookDesData item4 = new FishingHandBookDesData
					{
						DesText = "Fishing_MaxSize",
						DataText = dataText2
					};
					list.Add(item3);
					list.Add(item4);
				}
				else
				{
					string str = ConfigMultiTextLang.GetLocalTextNew("Fishing_SizeDes", null) ?? "";
					int minSize = fishingHandBook.MinSize;
					List<EFishingSize> sizeIsGoldSize = ModelBase<FishingModel>.Instance.GetSizeIsGoldSize(itemId);
					bool value = sizeIsGoldSize.Contains(EFishingSize.Silver);
					FishingHandBookDesData item5 = new FishingHandBookDesData
					{
						DesText = "Fishing_MinSize",
						DataText = minSize.ToString() + str,
						IsSliver = new bool?(value)
					};
					int maxSize = fishingHandBook.MaxSize;
					bool value2 = sizeIsGoldSize.Contains(EFishingSize.Golden);
					FishingHandBookDesData item6 = new FishingHandBookDesData
					{
						DesText = "Fishing_MaxSize",
						DataText = maxSize.ToString() + str,
						IsGolden = new bool?(value2)
					};
					list.Add(item5);
					list.Add(item6);
				}
			}
			if (fishingItemConfig.Value.Reputation > 0)
			{
				FishingHandBookDesData item7 = new FishingHandBookDesData
				{
					DesText = "Fishing_AddCount",
					DataText = "+" + fishingItemConfig.Value.Reputation.ToString()
				};
				list.Add(item7);
			}
			base.GetVerticalLayout(15).RootUIComp.Get().SetUIActive(list.Count > 0);
			GenericLayout<FishingHandBookDesItem, IFishingHandBookDesData> desLayout = this.DesLayout;
			if (desLayout == null)
			{
				return;
			}
			desLayout.RefreshByData(list, null, false);
		}

		// Token: 0x060426D9 RID: 272089 RVA: 0x011088BA File Offset: 0x01106ABA
		private FishingHandBookItem InitLoopScrollItem()
		{
			return new FishingHandBookItem
			{
				OnClickToggleCallBack = new Action<int, UUIExtendToggle, int>(this.OnClickHandBookItem)
			};
		}

		// Token: 0x060426DA RID: 272090 RVA: 0x011088D3 File Offset: 0x01106AD3
		private FishingHandBookTagItem InitTagLayoutItem()
		{
			return new FishingHandBookTagItem();
		}

		// Token: 0x060426DB RID: 272091 RVA: 0x011088DA File Offset: 0x01106ADA
		private FishingHandBookDesItem InitDesLayoutItem()
		{
			return new FishingHandBookDesItem();
		}

		// Token: 0x060426DC RID: 272092 RVA: 0x011088E4 File Offset: 0x01106AE4
		private void OnClickTraceBtn()
		{
			IFishingHandBook fishingHandBook;
			if (ModelBase<FishingModel>.Instance.FishingItemHandBookDataMap.TryGetValue(this.ItemId, out fishingHandBook) || ModelBase<FishingModel>.Instance.FishingItemHandBookUnlockTraceList.Contains(this.ItemId))
			{
				int[] array = ConfigBase<FishingConfig>.Instance.GetFishingItemConfig(this.ItemId).Value.Tech();
				for (int i = 0; i < array.Length; i++)
				{
					if (array[i] == 6)
					{
						ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Fishing_CageDetect", Array.Empty<object>());
						return;
					}
				}
				int relation = ConfigBase<FishingConfig>.Instance.GetFishingItemConfig(this.ItemId).Value.Relation;
				int item = (relation > 0) ? relation : this.ItemId;
				ModelBase<FishingQuestModel>.Instance.TraceItem(item);
				return;
			}
			if (this.RelationItemId > 0)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Fishing_VariationItemCannotTrace", Array.Empty<object>());
				return;
			}
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Fishing_NormalItemCannotTrace", Array.Empty<object>());
		}

		// Token: 0x060426DD RID: 272093 RVA: 0x011089E8 File Offset: 0x01106BE8
		private void OnClickHandBookItem(int itemId, UUIExtendToggle toggle, int index)
		{
			UUIExtendToggle currentToggle = this.CurrentToggle;
			if (currentToggle != null)
			{
				currentToggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
			}
			this.CurrentToggle = toggle;
			this.RefreshView(itemId);
			this.HandBookLoopScrollView.SelectGridProxy(index, false);
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer == null)
			{
				return;
			}
			levelSequencePlayer.PlayLevelSequenceByName("Switch", false, null, false);
		}

		// Token: 0x060426DE RID: 272094 RVA: 0x01108A48 File Offset: 0x01106C48
		private void OnClickRelationItem(int itemId, UUIExtendToggle toggle, int _)
		{
			int num = 0;
			using (List<IFishingHandBookItemData>.Enumerator enumerator = this.ItemDataList.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.Id == itemId)
					{
						break;
					}
					num++;
				}
			}
			this.HandBookLoopScrollView.ScrollToGridIndex(num, true);
			this.HandBookLoopScrollView.SelectGridProxy(num, true);
		}

		// Token: 0x060426DF RID: 272095 RVA: 0x01108AC0 File Offset: 0x01106CC0
		private void OnFilterUpdate(List<IFishingHandBookItemData> list, bool isOutSideChange, EFilterSortType sortType)
		{
			List<int> filteredArr = new List<int>();
			this.ItemDataList = list;
			foreach (IFishingHandBookItemData fishingHandBookItemData in list)
			{
				filteredArr.Add(fishingHandBookItemData.Id);
			}
			if (filteredArr.Count > 0)
			{
				LoopScrollView<FishingHandBookItem, int> handBookLoopScrollView = this.HandBookLoopScrollView;
				if (handBookLoopScrollView != null)
				{
					handBookLoopScrollView.RefreshByData(filteredArr, false, delegate
					{
						LoopScrollView<FishingHandBookItem, int> handBookLoopScrollView2 = this.HandBookLoopScrollView;
						if (handBookLoopScrollView2 != null)
						{
							handBookLoopScrollView2.SelectGridProxy(0, true);
						}
						this.RefreshView(filteredArr[0]);
					}, false);
				}
				base.GetItem(4).SetUIActive(false);
				base.GetLoopScrollViewComponent(1).RootUIComp.Get().SetUIActive(true);
				base.GetItem(19).SetUIActive(true);
				return;
			}
			base.GetItem(4).SetUIActive(true);
			base.GetLoopScrollViewComponent(1).RootUIComp.Get().SetUIActive(false);
			base.GetItem(19).SetUIActive(false);
		}

		// Token: 0x060426E0 RID: 272096 RVA: 0x01108BD8 File Offset: 0x01106DD8
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
			if (configParams[0] == "FishingHandBookItem")
			{
				if (configParams.Length != 2)
				{
					return null;
				}
				int num;
				if (int.TryParse(configParams[1], out num) && num >= 0 && num < this.ItemDataList.Count)
				{
					LoopScrollView<FishingHandBookItem, int> handBookLoopScrollView = this.HandBookLoopScrollView;
					UUIItem uuiitem = (handBookLoopScrollView != null) ? handBookLoopScrollView.GetGridByDisplayIndex(num) : null;
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
			}
			return null;
		}

		// Token: 0x060426E1 RID: 272097 RVA: 0x01108C4C File Offset: 0x01106E4C
		private void ReadItemNewFlag()
		{
			IFishingHandBook fishingHandBook;
			if (!ModelBase<FishingModel>.Instance.FishingItemHandBookDataMap.TryGetValue(this.ItemId, out fishingHandBook))
			{
				return;
			}
			ModelBase<NewFlagModel>.Instance.AddNewFlag(ELocalStoragePlayerKey.FishingHandBookItemRecord, this.ItemId);
			ModelBase<NewFlagModel>.Instance.SaveNewFlagConfig(ELocalStoragePlayerKey.FishingHandBookItemRecord);
		}

		// Token: 0x04024FB3 RID: 151475
		private int ItemId;

		// Token: 0x04024FB4 RID: 151476
		private List<IFishingHandBookItemData> ItemDataList = new List<IFishingHandBookItemData>();

		// Token: 0x04024FB5 RID: 151477
		[Nullable(2)]
		private PopupCaptionItem CaptionItem;

		// Token: 0x04024FB6 RID: 151478
		[Nullable(2)]
		private FishingQuestShapePanel FishingShapePanel;

		// Token: 0x04024FB7 RID: 151479
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private LoopScrollView<FishingHandBookItem, int> HandBookLoopScrollView;

		// Token: 0x04024FB8 RID: 151480
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericLayout<FishingHandBookTagItem, int> TagItemLayout;

		// Token: 0x04024FB9 RID: 151481
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<FishingHandBookDesItem, IFishingHandBookDesData> DesLayout;

		// Token: 0x04024FBA RID: 151482
		[Nullable(2)]
		private UUIExtendToggle CurrentToggle;

		// Token: 0x04024FBB RID: 151483
		[Nullable(2)]
		private FishingHandBookItem RelationItem;

		// Token: 0x04024FBC RID: 151484
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private FilterSortEntrance<IFishingHandBookItemData> FilterSortBtn;

		// Token: 0x04024FBD RID: 151485
		private int RelationItemId;

		// Token: 0x04024FBE RID: 151486
		[Nullable(2)]
		private LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x0200C855 RID: 51285
		[NullableContext(0)]
		private class EComponentDefine
		{
			// Token: 0x0403DA5C RID: 252508
			public const int CaptionItem = 0;

			// Token: 0x0403DA5D RID: 252509
			public const int ItemLoopScrollView = 1;

			// Token: 0x0403DA5E RID: 252510
			public const int ItemLoopScrollItem = 2;

			// Token: 0x0403DA5F RID: 252511
			public const int CollectCountText = 3;

			// Token: 0x0403DA60 RID: 252512
			public const int EmptyItem = 4;

			// Token: 0x0403DA61 RID: 252513
			public const int FilterSortItem = 5;

			// Token: 0x0403DA62 RID: 252514
			public const int ShapePanelItem = 6;

			// Token: 0x0403DA63 RID: 252515
			public const int ItemStateText = 7;

			// Token: 0x0403DA64 RID: 252516
			public const int ItemDesText = 8;

			// Token: 0x0403DA65 RID: 252517
			public const int VariationItem = 9;

			// Token: 0x0403DA66 RID: 252518
			public const int VariationPanelItem = 10;

			// Token: 0x0403DA67 RID: 252519
			public const int NumberAndNameText = 11;

			// Token: 0x0403DA68 RID: 252520
			public const int AreaItem = 12;

			// Token: 0x0403DA69 RID: 252521
			public const int PositionText = 13;

			// Token: 0x0403DA6A RID: 252522
			public const int TagLayout = 14;

			// Token: 0x0403DA6B RID: 252523
			public const int DesVerticalLayout = 15;

			// Token: 0x0403DA6C RID: 252524
			public const int TraceBtn = 16;

			// Token: 0x0403DA6D RID: 252525
			public const int LockItem = 17;

			// Token: 0x0403DA6E RID: 252526
			public const int LockText = 18;

			// Token: 0x0403DA6F RID: 252527
			public const int NotEmptyItem = 19;

			// Token: 0x0403DA70 RID: 252528
			public const int VariationText = 20;
		}
	}
}
