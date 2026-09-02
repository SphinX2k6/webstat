using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x02005153 RID: 20819
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RoguelikePopularEntriesGroup : GridProxyAbstract<RoguelikeEntriesGroupData>
	{
		// Token: 0x06035971 RID: 219505 RVA: 0x00D759C0 File Offset: 0x00D73BC0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 11;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUISprite));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06035972 RID: 219506 RVA: 0x00D75B58 File Offset: 0x00D73D58
		protected override UniTask OnBeforeStartAsync()
		{
			RoguelikePopularEntriesGroup.<OnBeforeStartAsync>d__11 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RoguelikePopularEntriesGroup.<OnBeforeStartAsync>d__11>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06035973 RID: 219507 RVA: 0x00D75B9C File Offset: 0x00D73D9C
		protected override void OnStart()
		{
			this.LayoutRow1 = new GenericLayout<RoguelikePopularEntryItem, RoguelikeEntryData>(base.GetHorizontalLayout(0), new Func<RoguelikePopularEntryItem>(this.CreateEntryItem), null, false, true);
			this.LayoutRow2 = new GenericLayout<RoguelikePopularEntryItem, RoguelikeEntryData>(base.GetHorizontalLayout(1), new Func<RoguelikePopularEntryItem>(this.CreateEntryItem), null, false, true);
			this.LayoutRow3 = new GenericLayout<RoguelikePopularEntryItem, RoguelikeEntryData>(base.GetHorizontalLayout(2), new Func<RoguelikePopularEntryItem>(this.CreateEntryItem), null, false, true);
		}

		// Token: 0x06035974 RID: 219508 RVA: 0x00D75C0C File Offset: 0x00D73E0C
		protected override void OnBeforeDestroy()
		{
			if (this.Data != null)
			{
				this.Data.ActiveStateChange = null;
				this.Data.FocusStateChange = null;
			}
		}

		// Token: 0x06035975 RID: 219509 RVA: 0x00D75C30 File Offset: 0x00D73E30
		[NullableContext(1)]
		public override UniTask RefreshAsync(RoguelikeEntriesGroupData data, bool isSelected, int gridIndex)
		{
			RoguelikePopularEntriesGroup.<RefreshAsync>d__14 <RefreshAsync>d__;
			<RefreshAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshAsync>d__.<>4__this = this;
			<RefreshAsync>d__.data = data;
			<RefreshAsync>d__.gridIndex = gridIndex;
			<RefreshAsync>d__.<>1__state = -1;
			<RefreshAsync>d__.<>t__builder.Start<RoguelikePopularEntriesGroup.<RefreshAsync>d__14>(ref <RefreshAsync>d__);
			return <RefreshAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06035976 RID: 219510 RVA: 0x00D75C83 File Offset: 0x00D73E83
		[NullableContext(1)]
		private RoguelikePopularEntryItem CreateEntryItem()
		{
			return new RoguelikePopularEntryItem();
		}

		// Token: 0x06035977 RID: 219511 RVA: 0x00D75C8A File Offset: 0x00D73E8A
		[NullableContext(1)]
		private List<RoguelikePopularEntryItem> GetAllEntryItems()
		{
			List<RoguelikePopularEntryItem> list = new List<RoguelikePopularEntryItem>();
			list.AddRange(this.LayoutRow1.GetLayoutItemList());
			list.AddRange(this.LayoutRow2.GetLayoutItemList());
			list.AddRange(this.LayoutRow3.GetLayoutItemList());
			return list;
		}

		// Token: 0x06035978 RID: 219512 RVA: 0x00D75CC4 File Offset: 0x00D73EC4
		private void ActiveStateChange(bool isActive)
		{
			this.BarLevelSequencePlayer.StopPlayingSequence(false, true);
			this.BarLevelSequencePlayer.PlayOrReplaySequenceByName(isActive ? "Close" : "Start", false, null);
			foreach (RoguelikePopularEntryItem roguelikePopularEntryItem in this.GetAllEntryItems())
			{
				roguelikePopularEntryItem.SetActiveState(isActive);
			}
		}

		// Token: 0x06035979 RID: 219513 RVA: 0x00D75D48 File Offset: 0x00D73F48
		private void FocusStateChange(bool isFocus)
		{
			foreach (RoguelikePopularEntryItem roguelikePopularEntryItem in this.GetAllEntryItems())
			{
				roguelikePopularEntryItem.SetFocusState(isFocus);
			}
		}

		// Token: 0x0603597A RID: 219514 RVA: 0x00D75D9C File Offset: 0x00D73F9C
		[NullableContext(1)]
		public override object GetKey(RoguelikeEntriesGroupData data, int displayIndex)
		{
			return data.Id;
		}

		// Token: 0x0401EC83 RID: 126083
		private RoguelikeEntriesGroupData Data;

		// Token: 0x0401EC84 RID: 126084
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<RoguelikePopularEntryItem, RoguelikeEntryData> LayoutRow1;

		// Token: 0x0401EC85 RID: 126085
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<RoguelikePopularEntryItem, RoguelikeEntryData> LayoutRow2;

		// Token: 0x0401EC86 RID: 126086
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<RoguelikePopularEntryItem, RoguelikeEntryData> LayoutRow3;

		// Token: 0x0401EC87 RID: 126087
		private RoguelikePopularEntryItem EntryRow1;

		// Token: 0x0401EC88 RID: 126088
		private RoguelikePopularEntryItem EntryRow2;

		// Token: 0x0401EC89 RID: 126089
		private RoguelikePopularEntryItem EntryRow3;

		// Token: 0x0401EC8A RID: 126090
		private LevelSequencePlayer BarLevelSequencePlayer;

		// Token: 0x0401EC8B RID: 126091
		public Func<int, bool> IsLastGroup;

		// Token: 0x0200B0FE RID: 45310
		[NullableContext(0)]
		private class EComponent
		{
			// Token: 0x04036E62 RID: 224866
			public const int LayoutGroupRow1 = 0;

			// Token: 0x04036E63 RID: 224867
			public const int LayoutGroupRow2 = 1;

			// Token: 0x04036E64 RID: 224868
			public const int LayoutGroupRow3 = 2;

			// Token: 0x04036E65 RID: 224869
			public const int LayoutItemRow1 = 3;

			// Token: 0x04036E66 RID: 224870
			public const int LayoutItemRow2 = 4;

			// Token: 0x04036E67 RID: 224871
			public const int LayoutItemRow3 = 5;

			// Token: 0x04036E68 RID: 224872
			public const int ItemLine = 6;

			// Token: 0x04036E69 RID: 224873
			public const int PanelValue = 7;

			// Token: 0x04036E6A RID: 224874
			public const int TxtMultiplier = 8;

			// Token: 0x04036E6B RID: 224875
			public const int PanelLock = 9;

			// Token: 0x04036E6C RID: 224876
			public const int SpriteLock = 10;
		}
	}
}
