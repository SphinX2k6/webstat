using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.WorldMap.SubViews.Popup
{
	// Token: 0x02004B96 RID: 19350
	public class RewardPreviewListItem : UiPanelBase, IGridProxy<TLevelDropReward>
	{
		// Token: 0x170086D6 RID: 34518
		// (get) Token: 0x06032870 RID: 206960 RVA: 0x00CA5E73 File Offset: 0x00CA4073
		// (set) Token: 0x06032871 RID: 206961 RVA: 0x00CA5E7B File Offset: 0x00CA407B
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public IScrollViewDelegate<IGridProxy<TLevelDropReward>, TLevelDropReward> ScrollViewDelegate { [return: Nullable(new byte[]
		{
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1
		})] set; }

		// Token: 0x170086D7 RID: 34519
		// (get) Token: 0x06032872 RID: 206962 RVA: 0x00CA5E84 File Offset: 0x00CA4084
		// (set) Token: 0x06032873 RID: 206963 RVA: 0x00CA5E8C File Offset: 0x00CA408C
		public int GridIndex { get; set; }

		// Token: 0x170086D8 RID: 34520
		// (get) Token: 0x06032874 RID: 206964 RVA: 0x00CA5E95 File Offset: 0x00CA4095
		// (set) Token: 0x06032875 RID: 206965 RVA: 0x00CA5E9D File Offset: 0x00CA409D
		public int DisplayIndex { get; set; }

		// Token: 0x06032876 RID: 206966 RVA: 0x00CA5EA8 File Offset: 0x00CA40A8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIGridLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>();
		}

		// Token: 0x06032877 RID: 206967 RVA: 0x00CA5F5E File Offset: 0x00CA415E
		protected override void OnStart()
		{
			this.ItemsLayout = new GenericLayout<RewardItem, TPreviewItem>(base.GetGridLayout(2), new Func<RewardItem>(this.CreateRewardItemFunc), null, false, true);
		}

		// Token: 0x06032878 RID: 206968 RVA: 0x00CA5F84 File Offset: 0x00CA4184
		public void Refresh(TLevelDropReward data, bool isSelected, int gridIndex)
		{
			this.DropRewardData = new TLevelDropReward?(data);
			int worldLevel = data.WorldLevel;
			DropPackage? config = ConfigDropPackageById.GetConfig(data.DropId, true);
			WorldLevelModel instance = ModelBase<WorldLevelModel>.Instance;
			int num = (instance != null) ? instance.CurWorldLevel : 0;
			bool uiactive = worldLevel == num;
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), "World_Level_Text", new <>z__ReadOnlySingleElementList<object>(worldLevel));
			UUIItem item = base.GetItem(1);
			if (item != null)
			{
				item.SetUIActive(uiactive);
			}
			List<TPreviewItem> list = new List<TPreviewItem>();
			int calabashLevel = ModelBase<CalabashModel>.Instance.GetCalabashLevel();
			CalabashLevel? calabashConfigByLevel = ConfigBase<CalabashConfig>.Instance.GetCalabashConfigByLevel(calabashLevel);
			for (int i = 0; i < config.Value.DropPreviewLength; i++)
			{
				DicIntInt? dicIntInt = config.Value.DropPreview(i);
				ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(dicIntInt.Value.Key);
				int valueOrDefault = calabashConfigByLevel.Value.GetQualityDropWeight(itemConfigData.QualityId).GetValueOrDefault();
				if (itemConfigData == null || !itemConfigData.ShowTypes.Contains(41) || valueOrDefault > 0)
				{
					list.Add(new TPreviewItem
					{
						ItemId = dicIntInt.Value.Key,
						Count = dicIntInt.Value.Value
					});
				}
			}
			list.Sort((TPreviewItem a, TPreviewItem b) => a.ItemId - b.ItemId);
			GenericLayout<RewardItem, TPreviewItem> itemsLayout = this.ItemsLayout;
			if (itemsLayout == null)
			{
				return;
			}
			itemsLayout.RefreshByData(list, null, false);
		}

		// Token: 0x06032879 RID: 206969 RVA: 0x00CA6126 File Offset: 0x00CA4326
		public void Clear()
		{
		}

		// Token: 0x0603287A RID: 206970 RVA: 0x00CA6128 File Offset: 0x00CA4328
		public void OnSelected(bool fireEvent)
		{
		}

		// Token: 0x0603287B RID: 206971 RVA: 0x00CA612A File Offset: 0x00CA432A
		public void OnDeselected(bool fireEvent)
		{
		}

		// Token: 0x0603287C RID: 206972 RVA: 0x00CA612C File Offset: 0x00CA432C
		[NullableContext(1)]
		public object GetKey(TLevelDropReward data, int gridIndex)
		{
			return this.GridIndex;
		}

		// Token: 0x0603287D RID: 206973 RVA: 0x00CA6139 File Offset: 0x00CA4339
		[NullableContext(1)]
		private RewardItem CreateRewardItemFunc()
		{
			return new RewardItem();
		}

		// Token: 0x0401D775 RID: 120693
		private TLevelDropReward? DropRewardData;

		// Token: 0x0401D776 RID: 120694
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericLayout<RewardItem, TPreviewItem> ItemsLayout;

		// Token: 0x0200AC68 RID: 44136
		public static class EComponents
		{
			// Token: 0x0403599E RID: 219550
			public const int TxtRewardTitle = 0;

			// Token: 0x0403599F RID: 219551
			public const int PnlCurrent = 1;

			// Token: 0x040359A0 RID: 219552
			public const int PnlGridLayout = 2;

			// Token: 0x040359A1 RID: 219553
			public const int ItemGrid = 3;
		}
	}
}
