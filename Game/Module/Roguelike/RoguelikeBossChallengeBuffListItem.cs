using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x0200513E RID: 20798
	[NullableContext(1)]
	[Nullable(0)]
	public class RoguelikeBossChallengeBuffListItem : UiPanelBase
	{
		// Token: 0x060358A2 RID: 219298 RVA: 0x00D70C20 File Offset: 0x00D6EE20
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x060358A3 RID: 219299 RVA: 0x00D70CAA File Offset: 0x00D6EEAA
		protected override void OnStart()
		{
			this.DebuffScrollView = new GenericScrollViewNew<RoguelikeBossChallengeDebuffItem, RoguelikeBossChallengeBuffData>(base.GetScrollViewWithScrollbar(1), new Func<RoguelikeBossChallengeDebuffItem>(this.CreateDebuffItem), base.GetItem(2).GetOwner() as AUIBaseActor, false, null);
		}

		// Token: 0x060358A4 RID: 219300 RVA: 0x00D70CDD File Offset: 0x00D6EEDD
		public void RefreshBuffList(List<RoguelikeBossChallengeBuffData> dataList)
		{
			this.CurrentDataList = dataList;
			GenericScrollViewNew<RoguelikeBossChallengeDebuffItem, RoguelikeBossChallengeBuffData> debuffScrollView = this.DebuffScrollView;
			if (debuffScrollView == null)
			{
				return;
			}
			debuffScrollView.RefreshByData(dataList, null, false);
		}

		// Token: 0x060358A5 RID: 219301 RVA: 0x00D70CF9 File Offset: 0x00D6EEF9
		protected override void OnBeforeDestroy()
		{
			this.DebuffScrollView = null;
			this.CurrentDataList = new List<RoguelikeBossChallengeBuffData>();
		}

		// Token: 0x060358A6 RID: 219302 RVA: 0x00D70D0D File Offset: 0x00D6EF0D
		private RoguelikeBossChallengeDebuffItem CreateDebuffItem()
		{
			return new RoguelikeBossChallengeDebuffItem();
		}

		// Token: 0x0401EC31 RID: 126001
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericScrollViewNew<RoguelikeBossChallengeDebuffItem, RoguelikeBossChallengeBuffData> DebuffScrollView;

		// Token: 0x0401EC32 RID: 126002
		protected List<RoguelikeBossChallengeBuffData> CurrentDataList = new List<RoguelikeBossChallengeBuffData>();

		// Token: 0x0200B0DD RID: 45277
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x04036DD8 RID: 224728
			public const int TxtTitle = 0;

			// Token: 0x04036DD9 RID: 224729
			public const int DebuffItemScroll = 1;

			// Token: 0x04036DDA RID: 224730
			public const int ItemBossDebuffItem = 2;
		}
	}
}
