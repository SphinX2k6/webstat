using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace ActivityNamespace.MapTravel
{
	// Token: 0x020043C4 RID: 17348
	[NullableContext(1)]
	[Nullable(0)]
	public class MapTravelTabItemBase : UiPanelBase
	{
		// Token: 0x0602E1E5 RID: 188901 RVA: 0x00AD7CF1 File Offset: 0x00AD5EF1
		public MapTravelTabItemBase(ActivityMapTravelData activityBaseData)
		{
			this.ActivityBaseData = activityBaseData;
		}

		// Token: 0x0602E1E6 RID: 188902 RVA: 0x00AD7D00 File Offset: 0x00AD5F00
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnToggleSelectOn));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0602E1E7 RID: 188903 RVA: 0x00AD7E09 File Offset: 0x00AD6009
		private void OnToggleSelectOn(EToggleState _)
		{
			if (this.Data != null)
			{
				Action<MapTravelAreaData, int> selectedCallBack = this.SelectedCallBack;
				if (selectedCallBack == null)
				{
					return;
				}
				selectedCallBack(this.Data, this.Index);
			}
		}

		// Token: 0x0602E1E8 RID: 188904 RVA: 0x00AD7E30 File Offset: 0x00AD6030
		public void SetToggleState(bool bOn, bool bFireEvent)
		{
			EToggleState state = bOn ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
			base.GetExtendToggle(0).SetToggleState(state, bFireEvent, false, false);
		}

		// Token: 0x0602E1E9 RID: 188905 RVA: 0x00AD7E56 File Offset: 0x00AD6056
		public virtual void RefreshByData(MapTravelAreaData data, int index)
		{
			this.Data = data;
			this.Index = index;
		}

		// Token: 0x0401A16F RID: 106863
		protected MapTravelAreaData Data;

		// Token: 0x0401A170 RID: 106864
		protected int Index;

		// Token: 0x0401A171 RID: 106865
		public Action<MapTravelAreaData, int> SelectedCallBack;

		// Token: 0x0401A172 RID: 106866
		protected ActivityMapTravelData ActivityBaseData;

		// Token: 0x0200A62E RID: 42542
		[NullableContext(0)]
		protected class ETabComponents
		{
			// Token: 0x04033633 RID: 210483
			public const int Toggle = 0;

			// Token: 0x04033634 RID: 210484
			public const int Name = 1;

			// Token: 0x04033635 RID: 210485
			public const int SpriteDone = 2;

			// Token: 0x04033636 RID: 210486
			public const int SpriteLock = 3;

			// Token: 0x04033637 RID: 210487
			public const int RedDot = 4;
		}
	}
}
