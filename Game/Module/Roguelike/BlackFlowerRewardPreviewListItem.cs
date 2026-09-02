using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Module.WorldMap.SubViews.Popup;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x02005186 RID: 20870
	public class BlackFlowerRewardPreviewListItem : UiPanelBase, IGridProxy<TLevelDropReward>
	{
		// Token: 0x17008C89 RID: 35977
		// (get) Token: 0x06035B1D RID: 219933 RVA: 0x00D7D7AF File Offset: 0x00D7B9AF
		// (set) Token: 0x06035B1E RID: 219934 RVA: 0x00D7D7B7 File Offset: 0x00D7B9B7
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

		// Token: 0x17008C8A RID: 35978
		// (get) Token: 0x06035B1F RID: 219935 RVA: 0x00D7D7C0 File Offset: 0x00D7B9C0
		// (set) Token: 0x06035B20 RID: 219936 RVA: 0x00D7D7C8 File Offset: 0x00D7B9C8
		public int GridIndex { get; set; }

		// Token: 0x17008C8B RID: 35979
		// (get) Token: 0x06035B21 RID: 219937 RVA: 0x00D7D7D1 File Offset: 0x00D7B9D1
		// (set) Token: 0x06035B22 RID: 219938 RVA: 0x00D7D7D9 File Offset: 0x00D7B9D9
		public int DisplayIndex { get; set; }

		// Token: 0x17008C8C RID: 35980
		// (get) Token: 0x06035B23 RID: 219939 RVA: 0x00D7D7E2 File Offset: 0x00D7B9E2
		// (set) Token: 0x06035B24 RID: 219940 RVA: 0x00D7D7EA File Offset: 0x00D7B9EA
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericLayout<CSharpScript.Game.Module.WorldMap.SubViews.Popup.RewardItem, TPreviewItem> ItemsLayout { [return: Nullable(new byte[]
		{
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1
		})] set; }

		// Token: 0x06035B25 RID: 219941 RVA: 0x00D7D7F4 File Offset: 0x00D7B9F4
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

		// Token: 0x06035B26 RID: 219942 RVA: 0x00D7D8AA File Offset: 0x00D7BAAA
		protected override void OnStart()
		{
			this.ItemsLayout = new GenericLayout<CSharpScript.Game.Module.WorldMap.SubViews.Popup.RewardItem, TPreviewItem>(base.GetGridLayout(2), new Func<CSharpScript.Game.Module.WorldMap.SubViews.Popup.RewardItem>(this.CreateRewardItemFunc), null, false, true);
		}

		// Token: 0x06035B27 RID: 219943 RVA: 0x00D7D8D0 File Offset: 0x00D7BAD0
		public void Refresh(TLevelDropReward data, bool isSelected, int gridIndex)
		{
			this.DropId = data.DropId;
			DropPackage? config = ConfigDropPackageById.GetConfig(this.DropId, true);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), "BlackFlower_Reward_Title", Array.Empty<object>());
			base.GetItem(1).SetUIActive(false);
			List<TPreviewItem> list = new List<TPreviewItem>();
			foreach (DicIntInt dicIntInt in config.Value.DropPreviewIter())
			{
				TPreviewItem item = new TPreviewItem
				{
					ItemId = dicIntInt.Key,
					Count = dicIntInt.Value
				};
				list.Add(item);
			}
			GenericLayout<CSharpScript.Game.Module.WorldMap.SubViews.Popup.RewardItem, TPreviewItem> itemsLayout = this.ItemsLayout;
			if (itemsLayout == null)
			{
				return;
			}
			itemsLayout.RefreshByData(list, null, false);
		}

		// Token: 0x06035B28 RID: 219944 RVA: 0x00D7D9AC File Offset: 0x00D7BBAC
		public void Clear()
		{
		}

		// Token: 0x06035B29 RID: 219945 RVA: 0x00D7D9AE File Offset: 0x00D7BBAE
		public void OnSelected(bool fireEvent)
		{
		}

		// Token: 0x06035B2A RID: 219946 RVA: 0x00D7D9B0 File Offset: 0x00D7BBB0
		public void OnDeselected(bool fireEvent)
		{
		}

		// Token: 0x06035B2B RID: 219947 RVA: 0x00D7D9B2 File Offset: 0x00D7BBB2
		[NullableContext(1)]
		public object GetKey(TLevelDropReward data, int gridIndex)
		{
			return this.GridIndex;
		}

		// Token: 0x06035B2C RID: 219948 RVA: 0x00D7D9BF File Offset: 0x00D7BBBF
		[NullableContext(1)]
		private CSharpScript.Game.Module.WorldMap.SubViews.Popup.RewardItem CreateRewardItemFunc()
		{
			return new CSharpScript.Game.Module.WorldMap.SubViews.Popup.RewardItem();
		}

		// Token: 0x0401ED14 RID: 126228
		private int DropId;

		// Token: 0x0200B143 RID: 45379
		private class EComponents
		{
			// Token: 0x04036F99 RID: 225177
			public const int TxtRewardTitle = 0;

			// Token: 0x04036F9A RID: 225178
			public const int PnlCurrent = 1;

			// Token: 0x04036F9B RID: 225179
			public const int PnlGridLayout = 2;

			// Token: 0x04036F9C RID: 225180
			public const int ItemGrid = 3;
		}
	}
}
