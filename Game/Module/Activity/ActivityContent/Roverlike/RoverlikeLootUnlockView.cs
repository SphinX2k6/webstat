using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Protocol;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x0200642D RID: 25645
	[NullableContext(1)]
	[Nullable(0)]
	public class RoverlikeLootUnlockView : UiViewBase
	{
		// Token: 0x17009DF4 RID: 40436
		// (get) Token: 0x06040617 RID: 263703 RVA: 0x0108120C File Offset: 0x0107F40C
		[Nullable(2)]
		private IRoverlikeLootUnlockViewOpenParam Param
		{
			[NullableContext(2)]
			get
			{
				return this.OpenParam as IRoverlikeLootUnlockViewOpenParam;
			}
		}

		// Token: 0x06040618 RID: 263704 RVA: 0x01081219 File Offset: 0x0107F419
		public RoverlikeLootUnlockView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x06040619 RID: 263705 RVA: 0x01081224 File Offset: 0x0107F424
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickClose));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0604061A RID: 263706 RVA: 0x010812EC File Offset: 0x0107F4EC
		protected override void OnStart()
		{
			IRoverlikeLootUnlockViewOpenParam param = this.Param;
			this.OnClosed = ((param != null) ? param.OnClosed : null);
			this.LootLayout = new GenericLayout<RoverlikeLootItem, RoverlikeLootGainEntry>(base.GetHorizontalLayout(1), new Func<RoverlikeLootItem>(this.CreateLootItem), base.GetItem(2).GetOwner() as AUIBaseActor, false, true);
			this.RefreshLootLayout();
		}

		// Token: 0x0604061B RID: 263707 RVA: 0x01081348 File Offset: 0x0107F548
		protected override void OnBeforeDestroy()
		{
			Action onClosed = this.OnClosed;
			this.OnClosed = null;
			if (onClosed == null)
			{
				return;
			}
			onClosed();
		}

		// Token: 0x0604061C RID: 263708 RVA: 0x01081364 File Offset: 0x0107F564
		private void RefreshLootLayout()
		{
			List<RoverlikeLootGainEntry> data = this.BuildLootDataList();
			this.LootLayout.RefreshByData(data, null, true);
		}

		// Token: 0x0604061D RID: 263709 RVA: 0x01081388 File Offset: 0x0107F588
		private List<RoverlikeLootGainEntry> BuildLootDataList()
		{
			IRoverlikeLootUnlockViewOpenParam param = this.Param;
			List<RoverRogueGainEntry> list = ((param != null) ? param.Loots : null) ?? new List<RoverRogueGainEntry>();
			List<RoverlikeLootGainEntry> list2 = new List<RoverlikeLootGainEntry>();
			foreach (RoverRogueGainEntry proto in list)
			{
				list2.Add(new RoverlikeLootGainEntry(proto)
				{
					Unlock = true
				});
			}
			return list2;
		}

		// Token: 0x0604061E RID: 263710 RVA: 0x01081404 File Offset: 0x0107F604
		private RoverlikeLootItem CreateLootItem()
		{
			return new RoverlikeLootItem();
		}

		// Token: 0x0604061F RID: 263711 RVA: 0x0108140B File Offset: 0x0107F60B
		private void OnClickClose()
		{
			base.CloseMe(null);
		}

		// Token: 0x04024105 RID: 147717
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<RoverlikeLootItem, RoverlikeLootGainEntry> LootLayout;

		// Token: 0x04024106 RID: 147718
		[Nullable(2)]
		private Action OnClosed;

		// Token: 0x0200C49C RID: 50332
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x0403C849 RID: 247881
			public const int BtnClose = 0;

			// Token: 0x0403C84A RID: 247882
			public const int PnlHor = 1;

			// Token: 0x0403C84B RID: 247883
			public const int LootItem = 2;
		}
	}
}
