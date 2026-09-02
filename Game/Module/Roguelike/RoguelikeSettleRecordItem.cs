using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x020051A0 RID: 20896
	public class RoguelikeSettleRecordItem : UiPanelBase
	{
		// Token: 0x06035BD9 RID: 220121 RVA: 0x00D82C67 File Offset: 0x00D80E67
		public RoguelikeSettleRecordItem(ERoguelikeSettleItemType itemType, int num)
		{
			this.ItemType = new ERoguelikeSettleItemType?(itemType);
			this.Count = num;
		}

		// Token: 0x06035BDA RID: 220122 RVA: 0x00D82C84 File Offset: 0x00D80E84
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06035BDB RID: 220123 RVA: 0x00D82CF0 File Offset: 0x00D80EF0
		protected override void OnStart()
		{
			base.GetText(1).SetText(this.Count.ToString(), true);
			ERoguelikeSettleItemType? itemType = this.ItemType;
			if (itemType != null)
			{
				switch (itemType.GetValueOrDefault())
				{
				case ERoguelikeSettleItemType.KillCount:
					Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), "RoguelikeSettleKill", Array.Empty<object>());
					return;
				case ERoguelikeSettleItemType.TokenCount:
					Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), "RoguelikeSettleToken", Array.Empty<object>());
					return;
				case ERoguelikeSettleItemType.MoneyCount:
					Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), "RoguelikeSettleMoney", Array.Empty<object>());
					break;
				default:
					return;
				}
			}
		}

		// Token: 0x0401ED74 RID: 126324
		public ERoguelikeSettleItemType? ItemType;

		// Token: 0x0401ED75 RID: 126325
		public int Count;

		// Token: 0x0200B171 RID: 45425
		private class ERoguelikeSettleRecordItemDefine
		{
			// Token: 0x04037070 RID: 225392
			public const int TxtTitle = 0;

			// Token: 0x04037071 RID: 225393
			public const int TxtNum = 1;
		}
	}
}
