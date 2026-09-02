using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Item.ItemComponent
{
	// Token: 0x0200661B RID: 26139
	[NullableContext(1)]
	[Nullable(0)]
	public class PinballItemGridReduceBtnComponent : PinballItemGridComponentBase
	{
		// Token: 0x06041518 RID: 267544 RVA: 0x010C0F98 File Offset: 0x010BF198
		protected unsafe override void OnRegisterComponent()
		{
			int num = 1;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickedReduceButton));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06041519 RID: 267545 RVA: 0x010C1020 File Offset: 0x010BF220
		protected override void OnStart()
		{
			this.LongPressButton = new LongPressButtonItem(null, null, null);
			this.LongPressButton.Initialize(base.GetButton(0), new Action<bool>(this.OnLongPressActive), null, null, null);
		}

		// Token: 0x0604151A RID: 267546 RVA: 0x010C1071 File Offset: 0x010BF271
		protected override string OnGetResourceId()
		{
			return "UiItem_ItemBaseChoose";
		}

		// Token: 0x0604151B RID: 267547 RVA: 0x010C1078 File Offset: 0x010BF278
		protected override void OnRefresh(params object[] args)
		{
			bool active = (bool)args[0];
			this.SetActive(active);
		}

		// Token: 0x0604151C RID: 267548 RVA: 0x010C1095 File Offset: 0x010BF295
		private void OnLongPressActive(bool isShortPress)
		{
			if (this.OnLongPressClickCallback != null)
			{
				this.OnLongPressClickCallback(isShortPress);
			}
		}

		// Token: 0x0604151D RID: 267549 RVA: 0x010C10AB File Offset: 0x010BF2AB
		public void BindReduceButtonCallback(Action onClickedReduceButton)
		{
			this.OnClickedCallback = onClickedReduceButton;
		}

		// Token: 0x0604151E RID: 267550 RVA: 0x010C10B4 File Offset: 0x010BF2B4
		public void UnBindReduceButtonCallback()
		{
			this.OnClickedCallback = null;
		}

		// Token: 0x0604151F RID: 267551 RVA: 0x010C10BD File Offset: 0x010BF2BD
		private void OnClickedReduceButton()
		{
			if (this.OnClickedCallback != null)
			{
				this.OnClickedCallback();
			}
		}

		// Token: 0x06041520 RID: 267552 RVA: 0x010C10D2 File Offset: 0x010BF2D2
		public void BindLongPressCallback(Action<bool> callback)
		{
			this.OnLongPressClickCallback = callback;
		}

		// Token: 0x06041521 RID: 267553 RVA: 0x010C10DB File Offset: 0x010BF2DB
		public void UnBindLongPressCallback()
		{
			this.OnLongPressClickCallback = null;
			this.LongPressButton.Deactivate();
		}

		// Token: 0x040248B7 RID: 149687
		[Nullable(2)]
		private Action OnClickedCallback;

		// Token: 0x040248B8 RID: 149688
		[Nullable(2)]
		private LongPressButtonItem LongPressButton;

		// Token: 0x040248B9 RID: 149689
		[Nullable(2)]
		private Action<bool> OnLongPressClickCallback;

		// Token: 0x0200C646 RID: 50758
		[NullableContext(0)]
		private enum EComponent
		{
			// Token: 0x0403D092 RID: 250002
			ReduceButton
		}
	}
}
