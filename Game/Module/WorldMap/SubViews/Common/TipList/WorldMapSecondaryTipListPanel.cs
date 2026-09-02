using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.WorldMap.SubViews.Common.TipList
{
	// Token: 0x02004BD5 RID: 19413
	public class WorldMapSecondaryTipListPanel : UiPanelBase
	{
		// Token: 0x06032A8C RID: 207500 RVA: 0x00CB01EC File Offset: 0x00CAE3EC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIVerticalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06032A8D RID: 207501 RVA: 0x00CB0258 File Offset: 0x00CAE458
		protected override void OnStart()
		{
			UUIVerticalLayout verticalLayout = base.GetVerticalLayout(0);
			this.TipsLayout = new GenericLayout<WorldMapSecondaryTipListItem, IWorldMapSecondaryTipItemParam>(verticalLayout, new Func<WorldMapSecondaryTipListItem>(this.CreateListItem), null, false, true);
		}

		// Token: 0x06032A8E RID: 207502 RVA: 0x00CB0289 File Offset: 0x00CAE489
		[NullableContext(1)]
		protected virtual WorldMapSecondaryTipListItem CreateListItem()
		{
			return new WorldMapSecondaryTipListItem();
		}

		// Token: 0x06032A8F RID: 207503 RVA: 0x00CB0290 File Offset: 0x00CAE490
		protected override void OnBeforeDestroy()
		{
			GenericLayout<WorldMapSecondaryTipListItem, IWorldMapSecondaryTipItemParam> tipsLayout = this.TipsLayout;
			if (tipsLayout == null)
			{
				return;
			}
			tipsLayout.ClearChildren();
		}

		// Token: 0x06032A90 RID: 207504 RVA: 0x00CB02A2 File Offset: 0x00CAE4A2
		[NullableContext(1)]
		public void RefreshByData(List<IWorldMapSecondaryTipItemParam> data)
		{
			GenericLayout<WorldMapSecondaryTipListItem, IWorldMapSecondaryTipItemParam> tipsLayout = this.TipsLayout;
			if (tipsLayout == null)
			{
				return;
			}
			tipsLayout.RefreshByData(data, null, false);
		}

		// Token: 0x0401D81A RID: 120858
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<WorldMapSecondaryTipListItem, IWorldMapSecondaryTipItemParam> TipsLayout;

		// Token: 0x0200ACBA RID: 44218
		public static class EComponents
		{
			// Token: 0x04035A7F RID: 219775
			public const int PnlMapTipsListItemA = 0;

			// Token: 0x04035A80 RID: 219776
			public const int PnlList = 1;
		}
	}
}
