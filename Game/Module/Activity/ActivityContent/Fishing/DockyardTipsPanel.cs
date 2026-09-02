using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x020067D1 RID: 26577
	[NullableContext(1)]
	[Nullable(0)]
	public class DockyardTipsPanel : UiPanelBase, IDockyardLeftTipsInterface
	{
		// Token: 0x1700A117 RID: 41239
		// (get) Token: 0x060424CB RID: 271563 RVA: 0x01101943 File Offset: 0x010FFB43
		// (set) Token: 0x060424CC RID: 271564 RVA: 0x0110194B File Offset: 0x010FFB4B
		public bool LockState { get; set; }

		// Token: 0x060424CD RID: 271565 RVA: 0x01101954 File Offset: 0x010FFB54
		protected unsafe override void OnRegisterComponent()
		{
			int num = 15;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUILayoutBase));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x060424CE RID: 271566 RVA: 0x01101B70 File Offset: 0x010FFD70
		protected override void OnStart()
		{
			this.SequencePlayer = new UiSequencePlayer(this.RootItem);
			this.StarLayout = new SimpleGenericLayout(base.GetLayoutBase(5));
			UUIItem item = base.GetItem(1);
			if (item != null)
			{
				item.SetUIActive(false);
			}
			UUIItem item2 = base.GetItem(0);
			if (item2 == null)
			{
				return;
			}
			item2.SetUIActive(true);
		}

		// Token: 0x060424CF RID: 271567 RVA: 0x01101BC5 File Offset: 0x010FFDC5
		protected override void OnBeforeDestroy()
		{
			this.SequencePlayer.Clear();
		}

		// Token: 0x060424D0 RID: 271568 RVA: 0x01101BD4 File Offset: 0x010FFDD4
		private void RefreshQuality(bool isActive, int quality)
		{
			base.GetLayoutBase(5).RootUIComp.Get().SetUIActive(isActive);
			if (isActive)
			{
				this.StarLayout.RebuildLayout(quality);
			}
		}

		// Token: 0x060424D1 RID: 271569 RVA: 0x01101C0C File Offset: 0x010FFE0C
		private void RefreshSize(bool isActive, int size, int cup)
		{
			base.GetItem(7).SetUIActive(isActive);
			if (isActive)
			{
				UUIText text = base.GetText(9);
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(2, 1);
				defaultInterpolatedStringHandler.AppendFormatted<int>(size);
				defaultInterpolatedStringHandler.AppendLiteral("cm");
				text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
				UUITexture texture = base.GetTexture(8);
				string texturePathByCup = DockyardPanelUtil.GetTexturePathByCup(cup);
				bool flag = !StringUtils.IsBlank(texturePathByCup);
				texture.SetUIActive(flag);
				if (flag)
				{
					base.SetTextureByPath(texturePathByCup, texture, null, null);
				}
			}
		}

		// Token: 0x060424D2 RID: 271570 RVA: 0x01101C94 File Offset: 0x010FFE94
		private void RefreshPrice(int price)
		{
			bool flag = price > 0;
			base.GetItem(10).SetUIActive(flag);
			if (flag)
			{
				base.GetText(11).SetText(price.ToString(), true);
			}
			base.SetItemIcon(base.GetTexture(12), 27, null, null);
		}

		// Token: 0x060424D3 RID: 271571 RVA: 0x01101CE8 File Offset: 0x010FFEE8
		public void Refresh(DockyardItemBlockOriginalData data)
		{
			this.Id = data.IncId;
			FishingItem? fishingItemConfig = ConfigBase<FishingConfig>.Instance.GetFishingItemConfig(data.ItemId);
			FishingTag? fishingTagConfig = ConfigBase<FishingConfig>.Instance.GetFishingTagConfig(fishingItemConfig.Value.Tech(0));
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), fishingItemConfig.Value.Name, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(13), fishingItemConfig.Value.Desc, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), fishingTagConfig.Value.Name, Array.Empty<object>());
			FColor color = FColor.FromHex(fishingTagConfig.Value.Color);
			base.GetSprite(4).SetColor(color);
			bool isActive = fishingItemConfig.Value.Type == 1;
			this.RefreshQuality(isActive, data.Quality);
			this.RefreshSize(isActive, data.Size, data.Cup);
			this.RefreshPrice(data.Price);
		}

		// Token: 0x060424D4 RID: 271572 RVA: 0x01101E04 File Offset: 0x01100004
		public void SetPanelVisible(bool bVisible)
		{
			this.SetPanelVisible(bVisible, true);
		}

		// Token: 0x060424D5 RID: 271573 RVA: 0x01101E0E File Offset: 0x0110000E
		public void SetPanelVisible(bool bVisible, bool needAnim)
		{
			if (this.LockState)
			{
				return;
			}
			if (bVisible)
			{
				this.ShowTipsPanel(needAnim);
				return;
			}
			this.HideTipsPanel(needAnim);
		}

		// Token: 0x060424D6 RID: 271574 RVA: 0x01101E2C File Offset: 0x0110002C
		private void ShowTipsPanel(bool needAnim = true)
		{
			if (needAnim)
			{
				this.SequencePlayer.StopCurrentSequenceByName("Hide", false, true);
				this.SequencePlayer.PlaySequencePurely("Show", false, false);
			}
			base.GetItem(0).SetUIActive(true);
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.FishingDockyardItemTipsShown, true);
		}

		// Token: 0x060424D7 RID: 271575 RVA: 0x01101E80 File Offset: 0x01100080
		private void HideTipsPanel(bool needAnim = true)
		{
			if (needAnim)
			{
				this.SequencePlayer.StopCurrentSequenceByName("Show", false, true);
				this.SequencePlayer.PlaySequencePurely("Hide", false, false);
			}
			base.GetItem(0).SetUIActive(false);
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.FishingDockyardItemTipsShown, false);
		}

		// Token: 0x04024E8E RID: 151182
		protected int Id;

		// Token: 0x04024E8F RID: 151183
		protected SimpleGenericLayout StarLayout;

		// Token: 0x04024E90 RID: 151184
		private UiSequencePlayer SequencePlayer;

		// Token: 0x04024E91 RID: 151185
		protected Action<int> SellClick;

		// Token: 0x0200C81E RID: 51230
		[NullableContext(0)]
		private class EComponentDefine
		{
			// Token: 0x0403D958 RID: 252248
			public const int TipsItem = 0;

			// Token: 0x0403D959 RID: 252249
			public const int EmptyItem = 1;

			// Token: 0x0403D95A RID: 252250
			public const int Title = 2;

			// Token: 0x0403D95B RID: 252251
			public const int Tag = 3;

			// Token: 0x0403D95C RID: 252252
			public const int TagBg = 4;

			// Token: 0x0403D95D RID: 252253
			public const int StarRoot = 5;

			// Token: 0x0403D95E RID: 252254
			public const int ContentRoot = 6;

			// Token: 0x0403D95F RID: 252255
			public const int SizeItem = 7;

			// Token: 0x0403D960 RID: 252256
			public const int CupIcon = 8;

			// Token: 0x0403D961 RID: 252257
			public const int SizeText = 9;

			// Token: 0x0403D962 RID: 252258
			public const int PriceItem = 10;

			// Token: 0x0403D963 RID: 252259
			public const int PriceText = 11;

			// Token: 0x0403D964 RID: 252260
			public const int PriceIcon = 12;

			// Token: 0x0403D965 RID: 252261
			public const int Description = 13;
		}
	}
}
