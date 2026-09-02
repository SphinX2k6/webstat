using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Reward;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x020051B0 RID: 20912
	[NullableContext(1)]
	[Nullable(0)]
	public class RoguelikeTokenOverView : UiViewBase
	{
		// Token: 0x06035C3C RID: 220220 RVA: 0x00D85729 File Offset: 0x00D83929
		public RoguelikeTokenOverView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06035C3D RID: 220221 RVA: 0x00D85748 File Offset: 0x00D83948
		protected unsafe override void OnRegisterComponent()
		{
			int num = 14;
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
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06035C3E RID: 220222 RVA: 0x00D85943 File Offset: 0x00D83B43
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.RoguelikeSelectToken, new Action<RoguelikeTokenGrid>(this.RefreshDetail));
			Singleton<EventSystem>.Instance.Add(EEventName.RoguelikeGetTokenReward, new Action(this.RoguelikeGetTokenReward));
		}

		// Token: 0x06035C3F RID: 220223 RVA: 0x00D8597D File Offset: 0x00D83B7D
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.RoguelikeSelectToken, new Action<RoguelikeTokenGrid>(this.RefreshDetail));
			Singleton<EventSystem>.Instance.Remove(EEventName.RoguelikeGetTokenReward, new Action(this.RoguelikeGetTokenReward));
		}

		// Token: 0x06035C40 RID: 220224 RVA: 0x00D859B7 File Offset: 0x00D83BB7
		private CommonTabItem ProxyCreate([Nullable(2)] UUIItem uiItem, int? index)
		{
			return new CommonTabItem();
		}

		// Token: 0x06035C41 RID: 220225 RVA: 0x00D859C0 File Offset: 0x00D83BC0
		private void ToggleCallBack(int index)
		{
			IReadOnlyList<RogueToken> allData = ConfigBase<RoguelikeConfig>.Instance.GetRogueTokenBySeasonId(this.SeasonId);
			List<RogueTokenData> data = new List<RogueTokenData>();
			int unlockCount = 0;
			Action<EPerkType?> action = delegate(EPerkType? perkType)
			{
				foreach (RogueToken value in allData)
				{
					RogueBuffPool? rogueBuffConfig = ConfigBase<RoguelikeConfig>.Instance.GetRogueBuffConfig(value.Token);
					if (perkType == null || rogueBuffConfig.Value.PerkType == (int)perkType.Value)
					{
						bool value2;
						bool? isReceive = this.DataMap.TryGetValue((long)value.Token, out value2) ? new bool?(value2) : null;
						RogueTokenData rogueTokenData = new RogueTokenData();
						rogueTokenData.IsReceive = isReceive;
						rogueTokenData.Config = new RogueToken?(value);
						if (isReceive != null)
						{
							int unlockCount = unlockCount;
							unlockCount++;
						}
						data.Add(rogueTokenData);
					}
				}
			};
			switch (index)
			{
			case 0:
				action(null);
				break;
			case 1:
				action(new EPerkType?(EPerkType.Common));
				break;
			case 2:
				action(new EPerkType?(EPerkType.CommonRole));
				break;
			}
			base.GetItem(13).SetUIActive(false);
			this.LoopScrollView.ReloadData(data, false);
			this.LoopScrollView.ScrollToGridIndex(0, true);
			this.LoopScrollView.SelectGridProxy(0, true);
			this.LoopScrollView.RefreshAllGridProxies();
			base.GetItem(12).SetUIActive(data.Count > 0);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), "Roguelike_TokenOverView_Collect", new <>z__ReadOnlyArray<object>(new object[]
			{
				unlockCount,
				data.Count
			}));
		}

		// Token: 0x06035C42 RID: 220226 RVA: 0x00D85AF0 File Offset: 0x00D83CF0
		private CommonTabData GetCommonData(int index)
		{
			UiDynamicTab uiDynamicTab = this.TabDataList[index];
			return new CommonTabData(uiDynamicTab.Icon, new CommonTabTitleData(uiDynamicTab.TabName, Array.Empty<object>()), null);
		}

		// Token: 0x06035C43 RID: 220227 RVA: 0x00D85B28 File Offset: 0x00D83D28
		protected RoguelikeTokenGrid CreateLoopScrollItem()
		{
			return new RoguelikeTokenGrid();
		}

		// Token: 0x06035C44 RID: 220228 RVA: 0x00D85B30 File Offset: 0x00D83D30
		protected override UniTask OnBeforeStartAsync()
		{
			RoguelikeTokenOverView.<OnBeforeStartAsync>d__16 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RoguelikeTokenOverView.<OnBeforeStartAsync>d__16>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06035C45 RID: 220229 RVA: 0x00D85B73 File Offset: 0x00D83D73
		protected override void OnBeforeShow()
		{
			this.TabComponent.SelectToggleByIndex(0, false);
		}

		// Token: 0x06035C46 RID: 220230 RVA: 0x00D85B82 File Offset: 0x00D83D82
		protected void OnCloseClick()
		{
			Singleton<UiManager>.Instance.CloseView(this.ViewInfo.Name, null);
		}

		// Token: 0x06035C47 RID: 220231 RVA: 0x00D85B9C File Offset: 0x00D83D9C
		protected void RefreshDetail(RoguelikeTokenGrid grid)
		{
			if (this.LastSelectGrid == grid)
			{
				return;
			}
			this.LastSelectGrid = grid;
			RogueTokenData data = grid.Data;
			RogueBuffPool? rogueBuffConfig = ConfigBase<RoguelikeConfig>.Instance.GetRogueBuffConfig(data.Config.Value.Token);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(11), rogueBuffConfig.Value.BuffName, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(6), rogueBuffConfig.Value.BuffDesc, rogueBuffConfig.Value.BuffDescParam());
			base.GetText(7).SetUIActive(false);
			base.SetTextureByPath(rogueBuffConfig.Value.BuffIcon, base.GetTexture(9), null, null);
			List<KeyValuePair<int, int>> list = ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackagePreview(data.Config.Value.DropId).ToList<KeyValuePair<int, int>>();
			TItem data2 = new TItem
			{
				ItemData = new InventoryDefine.GetItemData(list[0].Key, 0),
				Count = list[0].Value
			};
			int num = 10;
			int num2 = 0;
			foreach (DicIntInt dicIntInt in rogueBuffConfig.Value.BuffElementIter())
			{
				int key = dicIntInt.Key;
				int value = dicIntInt.Value;
				num = key;
				num2 = value;
			}
			base.GetTexture(5).SetUIActive(num < 10);
			base.GetText(4).SetUIActive(num < 10);
			if (num < 10)
			{
				base.SetTextureByPath(ConfigBase<ElementInfoConfig>.Instance.GetElementInfo(num).Value.Icon5, base.GetTexture(5), null, null);
				base.GetText(4).SetText(num2.ToString(), true);
			}
			this.CommonGridItem.Refresh(data2);
			this.CommonGridItem.SetActive(!data.IsReceive.GetValueOrDefault());
			base.GetItem(13).SetUIActive(true);
		}

		// Token: 0x06035C48 RID: 220232 RVA: 0x00D85DE0 File Offset: 0x00D83FE0
		protected void RoguelikeGetTokenReward()
		{
			RogueTokenData data = this.LastSelectGrid.Data;
			if (data.IsReceive == null)
			{
				return;
			}
			ControllerBase<RoguelikeController>.Instance.RoguelikeTokenReceiveRequest(this.SeasonId, data.Config.Value.Id).ContinueWith(delegate(bool success)
			{
				if (!success)
				{
					return;
				}
				data.IsReceive = new bool?(true);
				this.CommonGridItem.SetActive(!data.IsReceive.GetValueOrDefault());
			});
		}

		// Token: 0x0401ED9E RID: 126366
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public TabComponentWithCaptionItem<CommonTabItem> TabComponent;

		// Token: 0x0401ED9F RID: 126367
		public List<UiDynamicTab> TabDataList = new List<UiDynamicTab>();

		// Token: 0x0401EDA0 RID: 126368
		public Dictionary<long, bool> DataMap = new Dictionary<long, bool>();

		// Token: 0x0401EDA1 RID: 126369
		public int SeasonId;

		// Token: 0x0401EDA2 RID: 126370
		[Nullable(2)]
		private RogueTokenCommonItemSmallItemGrid CommonGridItem;

		// Token: 0x0401EDA3 RID: 126371
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		public LoopScrollView<RoguelikeTokenGrid, RogueTokenData> LoopScrollView;

		// Token: 0x0401EDA4 RID: 126372
		[Nullable(2)]
		public RoguelikeTokenGrid LastSelectGrid;

		// Token: 0x0200B18D RID: 45453
		[NullableContext(0)]
		private static class ERoguelikeTokenOverViewDefine
		{
			// Token: 0x040370FB RID: 225531
			public const int CaptionItem = 0;

			// Token: 0x040370FC RID: 225532
			public const int LoopScrollView = 1;

			// Token: 0x040370FD RID: 225533
			public const int LoopScrollItem = 2;

			// Token: 0x040370FE RID: 225534
			public const int TxtNum = 3;

			// Token: 0x040370FF RID: 225535
			public const int TxtElementCount = 4;

			// Token: 0x04037100 RID: 225536
			public const int TexElementIcon = 5;

			// Token: 0x04037101 RID: 225537
			public const int TxtEffect = 6;

			// Token: 0x04037102 RID: 225538
			public const int TxtDescription = 7;

			// Token: 0x04037103 RID: 225539
			public const int UnlockRewardItem = 8;

			// Token: 0x04037104 RID: 225540
			public const int TexItemIcon = 9;

			// Token: 0x04037105 RID: 225541
			public const int TexItemQuality = 10;

			// Token: 0x04037106 RID: 225542
			public const int TxtItemName = 11;

			// Token: 0x04037107 RID: 225543
			public const int TokenGridContent = 12;

			// Token: 0x04037108 RID: 225544
			public const int TipsItem = 13;
		}
	}
}
