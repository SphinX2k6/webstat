using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.PrizeDrawing.Components
{
	// Token: 0x0200656C RID: 25964
	[NullableContext(2)]
	[Nullable(0)]
	internal class GotItem : UiPanelBase
	{
		// Token: 0x06040DDF RID: 265695 RVA: 0x010A31A4 File Offset: 0x010A13A4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06040DE0 RID: 265696 RVA: 0x010A320D File Offset: 0x010A140D
		protected override void OnStart()
		{
			this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
			this.TxtItem = base.GetText(0);
			this.PnlGotItem = base.GetItem(1);
			UUIItem pnlGotItem = this.PnlGotItem;
			if (pnlGotItem == null)
			{
				return;
			}
			pnlGotItem.SetUIActive(false);
		}

		// Token: 0x06040DE1 RID: 265697 RVA: 0x010A324B File Offset: 0x010A144B
		protected override void OnBeforeDestroy()
		{
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer == null)
			{
				return;
			}
			levelSequencePlayer.Clear();
		}

		// Token: 0x06040DE2 RID: 265698 RVA: 0x010A325D File Offset: 0x010A145D
		public void SetIndexText(int index)
		{
			UUIText txtItem = this.TxtItem;
			if (txtItem == null)
			{
				return;
			}
			txtItem.SetText((index < 10) ? ("0" + index.ToString()) : index.ToString(), true);
		}

		// Token: 0x06040DE3 RID: 265699 RVA: 0x010A3290 File Offset: 0x010A1490
		public void RefreshGotState(bool isGot, bool animBanned = false)
		{
			UUIItem pnlGotItem = this.PnlGotItem;
			if ((pnlGotItem == null || !pnlGotItem.IsUIActiveSelf()) && isGot && !animBanned)
			{
				LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
				if (levelSequencePlayer != null)
				{
					levelSequencePlayer.PlaySequencePurely("Start", false, false, null, null, false);
				}
			}
			UUIItem pnlGotItem2 = this.PnlGotItem;
			if (pnlGotItem2 == null)
			{
				return;
			}
			pnlGotItem2.SetUIActive(isGot);
		}

		// Token: 0x04024655 RID: 149077
		private UUIItem PnlGotItem;

		// Token: 0x04024656 RID: 149078
		private UUIText TxtItem;

		// Token: 0x04024657 RID: 149079
		private LevelSequencePlayer LevelSequencePlayer;
	}
}
