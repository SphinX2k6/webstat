using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x020060BA RID: 24762
	[NullableContext(1)]
	[Nullable(0)]
	public class SpecialEnergyBarFuLuoLuoNoteItem : UiPanelBase
	{
		// Token: 0x0603E88A RID: 256138 RVA: 0x00FFDA7C File Offset: 0x00FFBC7C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 8;
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
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603E88B RID: 256139 RVA: 0x00FFDBAC File Offset: 0x00FFBDAC
		protected override void OnStart()
		{
			base.OnStart();
			this.ItemList.Add(base.GetItem(0));
			this.ItemList.Add(base.GetItem(1));
			this.ItemList.Add(base.GetItem(2));
			this.InitTweenAnim(3);
			this.InitTweenAnim(4);
			this.InitTweenAnim(5);
			this.InitTweenAnim(6);
			this.InitTweenAnim(7);
			this.PlayTweenAnim(3);
		}

		// Token: 0x0603E88C RID: 256140 RVA: 0x00FFDC1F File Offset: 0x00FFBE1F
		public void SetParent(UUIItem parentUiItem)
		{
			if (this.ParentUiItem == parentUiItem)
			{
				return;
			}
			this.ParentUiItem = parentUiItem;
			UUIItem rootItem = base.GetRootItem();
			if (rootItem == null)
			{
				return;
			}
			rootItem.SetUIParent(this.ParentUiItem, false);
		}

		// Token: 0x0603E88D RID: 256141 RVA: 0x00FFDC4C File Offset: 0x00FFBE4C
		public void SetEnergyType(int energyType)
		{
			if (energyType == this.EnergyType)
			{
				return;
			}
			int energyType2 = this.EnergyType;
			this.EnergyType = energyType;
			for (int i = 0; i < this.ItemList.Count; i++)
			{
				this.ItemList[i].SetUIActive(energyType == i + 1);
			}
			this.RefreshState();
			if (energyType2 == 0 && this.EnergyType != 0)
			{
				this.PlayTweenAnim(6);
				return;
			}
			if (energyType2 != 0 && this.EnergyType == 0 && !this.PerformState)
			{
				this.PlayTweenAnim(7);
			}
		}

		// Token: 0x0603E88E RID: 256142 RVA: 0x00FFDCD1 File Offset: 0x00FFBED1
		public void SetLockState(bool state)
		{
			if (this.LockState == state)
			{
				return;
			}
			this.LockState = state;
			this.RefreshState();
		}

		// Token: 0x0603E88F RID: 256143 RVA: 0x00FFDCEA File Offset: 0x00FFBEEA
		public void SetPerformState(bool state)
		{
			if (this.PerformState == state)
			{
				return;
			}
			this.PerformState = state;
			this.RefreshState();
		}

		// Token: 0x0603E890 RID: 256144 RVA: 0x00FFDD04 File Offset: 0x00FFBF04
		private void RefreshState()
		{
			int num = 0;
			if (this.PerformState)
			{
				num = 1;
			}
			else if (this.LockState && this.EnergyType > 0)
			{
				num = 2;
			}
			if (this.State == num)
			{
				return;
			}
			if (this.State == 0)
			{
				this.StopTweenAnim(3);
			}
			else if (this.State == 1)
			{
				this.StopTweenAnim(5);
			}
			else if (this.State == 2)
			{
				this.StopTweenAnim(4);
			}
			this.State = num;
			if (this.State == 0)
			{
				this.PlayTweenAnim(3);
				return;
			}
			if (this.State == 1)
			{
				this.PlayTweenAnim(5);
				return;
			}
			if (this.State == 2)
			{
				this.PlayTweenAnim(4);
			}
		}

		// Token: 0x0603E891 RID: 256145 RVA: 0x00FFDDA7 File Offset: 0x00FFBFA7
		protected void InitTweenAnim(int componentType)
		{
			this.TweenAnimPlayer.InitTweenAnim(componentType, base.GetItem(componentType), false);
		}

		// Token: 0x0603E892 RID: 256146 RVA: 0x00FFDDBD File Offset: 0x00FFBFBD
		protected void PlayTweenAnim(int componentType)
		{
			this.TweenAnimPlayer.PlayTweenAnim(componentType);
		}

		// Token: 0x0603E893 RID: 256147 RVA: 0x00FFDDCB File Offset: 0x00FFBFCB
		protected void StopTweenAnim(int componentType)
		{
			this.TweenAnimPlayer.StopTweenAnim(componentType);
		}

		// Token: 0x0603E894 RID: 256148 RVA: 0x00FFDDD9 File Offset: 0x00FFBFD9
		protected void ClearAllTweenAnim()
		{
			this.TweenAnimPlayer.Clear(false);
		}

		// Token: 0x040230DD RID: 143581
		private readonly BattleUiTweenAnimPlayer TweenAnimPlayer = new BattleUiTweenAnimPlayer();

		// Token: 0x040230DE RID: 143582
		private readonly List<UUIItem> ItemList = new List<UUIItem>();

		// Token: 0x040230DF RID: 143583
		private int EnergyType = -1;

		// Token: 0x040230E0 RID: 143584
		private bool LockState;

		// Token: 0x040230E1 RID: 143585
		private bool PerformState;

		// Token: 0x040230E2 RID: 143586
		private int State;

		// Token: 0x0200C1E9 RID: 49641
		[NullableContext(0)]
		private enum EChildType
		{
			// Token: 0x0403BB9A RID: 244634
			Item1,
			// Token: 0x0403BB9B RID: 244635
			Item2,
			// Token: 0x0403BB9C RID: 244636
			Item3,
			// Token: 0x0403BB9D RID: 244637
			AniDefault,
			// Token: 0x0403BB9E RID: 244638
			AniLock,
			// Token: 0x0403BB9F RID: 244639
			AniPerform,
			// Token: 0x0403BBA0 RID: 244640
			AniCast,
			// Token: 0x0403BBA1 RID: 244641
			AniExhaust
		}
	}
}
