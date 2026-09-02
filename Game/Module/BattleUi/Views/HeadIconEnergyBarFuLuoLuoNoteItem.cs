using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x0200601E RID: 24606
	internal class HeadIconEnergyBarFuLuoLuoNoteItem : UiPanelBase
	{
		// Token: 0x0603E026 RID: 253990 RVA: 0x00FD2C90 File Offset: 0x00FD0E90
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603E027 RID: 253991 RVA: 0x00FD2D5C File Offset: 0x00FD0F5C
		protected override void OnStart()
		{
			base.OnStart();
			this.ItemList.Add(base.GetItem(0));
			this.ItemList.Add(base.GetItem(1));
			this.ItemList.Add(base.GetItem(2));
			foreach (UUIItem uuiitem in this.ItemList)
			{
				uuiitem.SetUIActive(false);
			}
			this.InitTweenAnim(3);
			this.InitTweenAnim(4);
		}

		// Token: 0x0603E028 RID: 253992 RVA: 0x00FD2DF8 File Offset: 0x00FD0FF8
		public void SetEnergyType(int energyType)
		{
			if (energyType == this.EnergyType)
			{
				return;
			}
			int energyType2 = this.EnergyType;
			this.EnergyType = energyType;
			bool flag = (energyType2 == -1 || energyType2 == 0) && energyType != 0;
			bool flag2 = energyType2 != -1 && energyType2 != 0 && energyType == 0;
			for (int i = 0; i < this.ItemList.Count; i++)
			{
				UUIItem uuiitem = this.ItemList[i];
				if (flag2 && energyType2 == i + 1)
				{
					uuiitem.SetUIActive(true);
				}
				else
				{
					uuiitem.SetUIActive(energyType == i + 1);
				}
			}
			if (flag)
			{
				if (this.IsExhausted)
				{
					this.PlayTweenAnim(3);
				}
				this.IsExhausted = false;
				return;
			}
			if (flag2)
			{
				this.PlayTweenAnim(4);
				this.IsExhausted = true;
			}
		}

		// Token: 0x0603E029 RID: 253993 RVA: 0x00FD2EAA File Offset: 0x00FD10AA
		protected void InitTweenAnim(int componentType)
		{
			if (this.TweenAnimPlayer == null)
			{
				this.TweenAnimPlayer = new BattleUiTweenAnimPlayer();
			}
			this.TweenAnimPlayer.InitTweenAnim(componentType, base.GetItem(componentType), false);
		}

		// Token: 0x0603E02A RID: 253994 RVA: 0x00FD2ED3 File Offset: 0x00FD10D3
		protected void PlayTweenAnim(int componentType)
		{
			BattleUiTweenAnimPlayer tweenAnimPlayer = this.TweenAnimPlayer;
			if (tweenAnimPlayer == null)
			{
				return;
			}
			tweenAnimPlayer.PlayTweenAnim(componentType);
		}

		// Token: 0x0603E02B RID: 253995 RVA: 0x00FD2EE6 File Offset: 0x00FD10E6
		protected void StopTweenAnim(int componentType)
		{
			BattleUiTweenAnimPlayer tweenAnimPlayer = this.TweenAnimPlayer;
			if (tweenAnimPlayer == null)
			{
				return;
			}
			tweenAnimPlayer.StopTweenAnim(componentType);
		}

		// Token: 0x0603E02C RID: 253996 RVA: 0x00FD2EF9 File Offset: 0x00FD10F9
		protected void ClearAllTweenAnim()
		{
			BattleUiTweenAnimPlayer tweenAnimPlayer = this.TweenAnimPlayer;
			if (tweenAnimPlayer == null)
			{
				return;
			}
			tweenAnimPlayer.Clear(false);
		}

		// Token: 0x04022C59 RID: 142425
		[Nullable(1)]
		private readonly List<UUIItem> ItemList = new List<UUIItem>(3);

		// Token: 0x04022C5A RID: 142426
		[Nullable(2)]
		protected BattleUiTweenAnimPlayer TweenAnimPlayer;

		// Token: 0x04022C5B RID: 142427
		private int EnergyType = -1;

		// Token: 0x04022C5C RID: 142428
		private bool IsExhausted;

		// Token: 0x0200C0CB RID: 49355
		private enum ENoteChildType
		{
			// Token: 0x0403B5B9 RID: 243129
			Item1,
			// Token: 0x0403B5BA RID: 243130
			Item2,
			// Token: 0x0403B5BB RID: 243131
			Item3,
			// Token: 0x0403B5BC RID: 243132
			AniDefault,
			// Token: 0x0403B5BD RID: 243133
			AniExhaust
		}
	}
}
