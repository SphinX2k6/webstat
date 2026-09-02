using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x020067CD RID: 26573
	[NullableContext(1)]
	[Nullable(0)]
	public class DockyardQuicklySellPanel : UiPanelBase
	{
		// Token: 0x060424AA RID: 271530 RVA: 0x01101030 File Offset: 0x010FF230
		protected unsafe override void OnRegisterComponent()
		{
			int num = 6;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIButtonComponent));
			this.ComponentRegisterInfos = list;
			num2 = 2;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(2, this.ConfirmBtnClick);
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(5, this.CloseBtnClick);
			this.BtnBindInfo = list2;
		}

		// Token: 0x060424AB RID: 271531 RVA: 0x01101171 File Offset: 0x010FF371
		protected override void OnStart()
		{
			this.SequencePlayer = new LevelSequencePlayer(this.RootItem);
			this.SequencePlayer.BindSequenceCloseEvent(delegate(string eventName)
			{
				if (eventName == "Close")
				{
					this.SetActive(false);
				}
			}, false);
		}

		// Token: 0x060424AC RID: 271532 RVA: 0x0110119C File Offset: 0x010FF39C
		protected override void OnBeforeDestroy()
		{
			this.SequencePlayer.Clear();
		}

		// Token: 0x060424AD RID: 271533 RVA: 0x011011AC File Offset: 0x010FF3AC
		public void SetPanelVisible(bool bVisible)
		{
			if (bVisible)
			{
				this.SequencePlayer.StopCurrentSequence(false, true);
				this.SequencePlayer.PlaySequencePurely("Start", false, false, null, null, false);
				this.SetActive(true);
				return;
			}
			this.SequencePlayer.StopCurrentSequence(false, true);
			this.SequencePlayer.PlaySequencePurely("Close", false, false, null, null, false);
		}

		// Token: 0x060424AE RID: 271534 RVA: 0x01101218 File Offset: 0x010FF418
		public void RefreshPanel(int price, EBackpackQuicklySellType sellType)
		{
			bool flag = sellType == EBackpackQuicklySellType.Full;
			UUIButtonComponent button = base.GetButton(2);
			if (button != null)
			{
				button.RootUIComp.Get().SetUIActive(flag);
			}
			UUIItem item = base.GetItem(3);
			if (item != null)
			{
				item.SetUIActive(!flag);
			}
			UUIText text = base.GetText(0);
			if (text != null)
			{
				text.SetText(price.ToString(), true);
			}
			base.SetItemIcon(base.GetTexture(1), 27, null, null);
			if (!flag)
			{
				if (sellType == EBackpackQuicklySellType.RangeError)
				{
					Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), "Fishing_ShapeNotMatch", Array.Empty<object>());
					return;
				}
				if (sellType == EBackpackQuicklySellType.ItemError)
				{
					Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), "Fishing_ShapeCantSell", Array.Empty<object>());
				}
			}
		}

		// Token: 0x04024E86 RID: 151174
		public Action ConfirmBtnClick;

		// Token: 0x04024E87 RID: 151175
		public Action CloseBtnClick;

		// Token: 0x04024E88 RID: 151176
		protected LevelSequencePlayer SequencePlayer;

		// Token: 0x0200C814 RID: 51220
		[NullableContext(0)]
		private class EComponentDefine
		{
			// Token: 0x0403D92E RID: 252206
			public const int PriceText = 0;

			// Token: 0x0403D92F RID: 252207
			public const int PriceIcon = 1;

			// Token: 0x0403D930 RID: 252208
			public const int ConfirmBtn = 2;

			// Token: 0x0403D931 RID: 252209
			public const int ConditionItem = 3;

			// Token: 0x0403D932 RID: 252210
			public const int ConditionText = 4;

			// Token: 0x0403D933 RID: 252211
			public const int CloseBtn = 5;
		}
	}
}
