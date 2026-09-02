using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Common.NumberSelect
{
	// Token: 0x02005E4F RID: 24143
	[NullableContext(2)]
	[Nullable(0)]
	public class NumberSelectComponent : UiPanelBase
	{
		// Token: 0x0603CBF3 RID: 248819 RVA: 0x00F6D04C File Offset: 0x00F6B24C
		[NullableContext(1)]
		public NumberSelectComponent(UUIItem uiItem)
		{
			base.CreateThenShowByActor(uiItem.GetOwner(), null);
		}

		// Token: 0x0603CBF4 RID: 248820 RVA: 0x00F6D074 File Offset: 0x00F6B274
		protected unsafe override void OnRegisterComponent()
		{
			int num = 8;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUISliderComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIButtonComponent));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(7, new Action(this.OnClickMax));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603CBF5 RID: 248821 RVA: 0x00F6D1E0 File Offset: 0x00F6B3E0
		private void OnClickMax()
		{
			this.SelectMax();
		}

		// Token: 0x0603CBF6 RID: 248822 RVA: 0x00F6D1E8 File Offset: 0x00F6B3E8
		protected override void OnStart()
		{
			this.Slider = base.GetSlider(4);
			this.Slider.OnValueChangeCb.Bind(new Action<float>(this.SliderValueChange));
			this.ReduceLongPress = new LongPressButtonItem(new OneOf<UUIButtonComponent, UUIExtendToggle>?(base.GetButton(0)), new LongPressButtonItem.ELongPressConfigId?(LongPressButtonItem.ELongPressConfigId.LongPressOne), new Action<bool>(this.ReducePointClick));
			this.AddLongPress = new LongPressButtonItem(new OneOf<UUIButtonComponent, UUIExtendToggle>?(base.GetButton(1)), new LongPressButtonItem.ELongPressConfigId?(LongPressButtonItem.ELongPressConfigId.LongPressOne), new Action<bool>(this.AddPointClick));
			this.BuyNumberTips = base.GetText(5);
			this.SelectNumber = 1;
			this.ReduceLongPress.ShouldPlayLongPressSound = true;
			this.AddLongPress.ShouldPlayLongPressSound = true;
		}

		// Token: 0x0603CBF7 RID: 248823 RVA: 0x00F6D2A8 File Offset: 0x00F6B4A8
		private void SliderValueChange(float value)
		{
			this.SelectNumber = (int)value;
			this.AddLongPress.SetInteractive(value != this.Slider.MaxValue);
			this.ReduceLongPress.SetInteractive(value != this.Slider.MinValue);
			base.GetButton(7).SetSelfInteractive(value != this.Slider.MaxValue);
			Func<int, TableTextArgNew> getExchangeTableText = this.Data.GetExchangeTableText;
			TableTextArgNew tableTextArgNew = (getExchangeTableText != null) ? getExchangeTableText(this.SelectNumber) : null;
			if (tableTextArgNew != null)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(this.BuyNumberTips, tableTextArgNew.TextKey, tableTextArgNew.Params);
			}
			Action<int> valueChangeFunction = this.Data.ValueChangeFunction;
			if (valueChangeFunction == null)
			{
				return;
			}
			valueChangeFunction(this.SelectNumber);
		}

		// Token: 0x0603CBF8 RID: 248824 RVA: 0x00F6D36A File Offset: 0x00F6B56A
		private void ReducePointClick(bool _)
		{
			this.Slider.SetValue((float)(this.SelectNumber - 1), true);
		}

		// Token: 0x0603CBF9 RID: 248825 RVA: 0x00F6D381 File Offset: 0x00F6B581
		private void AddPointClick(bool _)
		{
			this.Slider.SetValue((float)(this.SelectNumber + 1), true);
		}

		// Token: 0x0603CBFA RID: 248826 RVA: 0x00F6D398 File Offset: 0x00F6B598
		protected override void OnBeforeDestroy()
		{
			this.Slider.OnValueChangeCb.Unbind();
			this.AddLongPress.ShouldPlayLongPressSound = false;
			this.ReduceLongPress.ShouldPlayLongPressSound = false;
			this.ReduceLongPress.Clear();
			this.AddLongPress.Clear();
		}

		// Token: 0x0603CBFB RID: 248827 RVA: 0x00F6D3D8 File Offset: 0x00F6B5D8
		private void InitSlider()
		{
			UUIText text = base.GetText(2);
			UUIText text2 = base.GetText(3);
			bool ifLimit = this.GetIfLimit();
			int num = (!ifLimit) ? 1 : 0;
			int num2 = this.UseCustomMinValue ? this.MinValue : num;
			int num3 = this.UseCustomMinValue ? this.MinValue : 1;
			text.SetText(num2.ToString(), true);
			text2.SetText(this.MaxValue.ToString(), true);
			this.Slider.SetMaxValue((float)this.MaxValue, false, true);
			this.Slider.SetMinValue((float)num2, false, true);
			this.Slider.SetValue((float)num3, false);
			this.SliderValueChange((float)num3);
			this.SetComponentLimitState(ifLimit);
		}

		// Token: 0x0603CBFC RID: 248828 RVA: 0x00F6D488 File Offset: 0x00F6B688
		public void SetMaxBtnShowState(bool state)
		{
			UUIButtonComponent button = base.GetButton(7);
			if (button == null)
			{
				return;
			}
			button.RootUIComp.Get().SetUIActive(state);
		}

		// Token: 0x0603CBFD RID: 248829 RVA: 0x00F6D4B4 File Offset: 0x00F6B6B4
		public bool GetIfLimit()
		{
			return this.MaxValue <= 1;
		}

		// Token: 0x0603CBFE RID: 248830 RVA: 0x00F6D4C2 File Offset: 0x00F6B6C2
		public bool GetIfSelectMax()
		{
			return this.SelectNumber == this.MaxValue;
		}

		// Token: 0x0603CBFF RID: 248831 RVA: 0x00F6D4D2 File Offset: 0x00F6B6D2
		public void SelectMax()
		{
			this.Slider.SetValue((float)this.MaxValue, false);
			this.SliderValueChange((float)this.MaxValue);
		}

		// Token: 0x0603CC00 RID: 248832 RVA: 0x00F6D4F4 File Offset: 0x00F6B6F4
		[NullableContext(1)]
		public void SetNumberSelectTipsText(string text)
		{
			this.BuyNumberTips.SetText(text, true);
		}

		// Token: 0x0603CC01 RID: 248833 RVA: 0x00F6D503 File Offset: 0x00F6B703
		public void SetNumberSelectTipsVisible(bool bVisible)
		{
			this.BuyNumberTips.SetUIActive(bVisible);
		}

		// Token: 0x0603CC02 RID: 248834 RVA: 0x00F6D511 File Offset: 0x00F6B711
		public void SetComponentLimitState(bool isLimit)
		{
			this.SetMinTextShowState(!isLimit);
			base.GetItem(6).SetRaycastTarget(!isLimit);
			this.Slider.SetSelfInteractive(!isLimit);
			this.SetAddReduceButtonActive(!isLimit);
		}

		// Token: 0x0603CC03 RID: 248835 RVA: 0x00F6D546 File Offset: 0x00F6B746
		public void SetMinTextShowState(bool state)
		{
			base.GetText(2).SetUIActive(state);
		}

		// Token: 0x0603CC04 RID: 248836 RVA: 0x00F6D555 File Offset: 0x00F6B755
		public void SetAddReduceButtonActive(bool state)
		{
			this.ReduceLongPress.SetActive(state);
			this.AddLongPress.SetActive(state);
		}

		// Token: 0x0603CC05 RID: 248837 RVA: 0x00F6D56F File Offset: 0x00F6B76F
		public void SetAddReduceButtonInteractive(bool state)
		{
			this.SetAddButtonInteractive(state);
			this.SetReduceButtonInteractive(state);
		}

		// Token: 0x0603CC06 RID: 248838 RVA: 0x00F6D57F File Offset: 0x00F6B77F
		public void SetAddButtonInteractive(bool state)
		{
			base.GetButton(1).SetSelfInteractive(state);
		}

		// Token: 0x0603CC07 RID: 248839 RVA: 0x00F6D58E File Offset: 0x00F6B78E
		public void SetReduceButtonInteractive(bool state)
		{
			base.GetButton(0).SetSelfInteractive(state);
		}

		// Token: 0x0603CC08 RID: 248840 RVA: 0x00F6D59D File Offset: 0x00F6B79D
		[NullableContext(1)]
		public void Init(INumberSelectData data)
		{
			this.Data = data;
			this.Refresh(this.Data.MaxNumber);
		}

		// Token: 0x0603CC09 RID: 248841 RVA: 0x00F6D5B7 File Offset: 0x00F6B7B7
		public int GetSelectNumber()
		{
			return this.SelectNumber;
		}

		// Token: 0x0603CC0A RID: 248842 RVA: 0x00F6D5BF File Offset: 0x00F6B7BF
		public void SetLimitMaxValue(int value)
		{
			this.LimitMaxValue = Math.Min(value, 9999);
		}

		// Token: 0x0603CC0B RID: 248843 RVA: 0x00F6D5D2 File Offset: 0x00F6B7D2
		public void SetLimitMaxValueForce(int value)
		{
			this.LimitMaxValue = value;
		}

		// Token: 0x0603CC0C RID: 248844 RVA: 0x00F6D5DB File Offset: 0x00F6B7DB
		public void ResetLimitMaxValue()
		{
			this.LimitMaxValue = 9999;
		}

		// Token: 0x0603CC0D RID: 248845 RVA: 0x00F6D5E8 File Offset: 0x00F6B7E8
		public void SetMinValue(int value)
		{
			this.MinValue = value;
		}

		// Token: 0x0603CC0E RID: 248846 RVA: 0x00F6D5F1 File Offset: 0x00F6B7F1
		public void EnableUseCustomMinValue(bool enable)
		{
			this.UseCustomMinValue = enable;
		}

		// Token: 0x0603CC0F RID: 248847 RVA: 0x00F6D5FA File Offset: 0x00F6B7FA
		public void Refresh(int maxNumber)
		{
			this.MaxValue = Singleton<MathUtils>.Instance.Clamp(maxNumber, this.MinValue, this.LimitMaxValue);
			this.InitSlider();
		}

		// Token: 0x0603CC10 RID: 248848 RVA: 0x00F6D61F File Offset: 0x00F6B81F
		public void ChangeValue(int value, bool forceRefresh = true)
		{
			if (!forceRefresh && this.SelectNumber == value)
			{
				return;
			}
			this.Slider.SetValue((float)value, false);
			this.SliderValueChange((float)value);
		}

		// Token: 0x0603CC11 RID: 248849 RVA: 0x00F6D644 File Offset: 0x00F6B844
		public void SetSliderAndButtonInteractive(bool state)
		{
			this.ReduceLongPress.SetInteractive(state);
			this.AddLongPress.SetInteractive(state);
			this.Slider.SetSelfInteractive(state);
			base.GetItem(6).SetRaycastTarget(state);
		}

		// Token: 0x040221A4 RID: 139684
		private const int MAX_VALUE = 9999;

		// Token: 0x040221A5 RID: 139685
		private LongPressButtonItem ReduceLongPress;

		// Token: 0x040221A6 RID: 139686
		private LongPressButtonItem AddLongPress;

		// Token: 0x040221A7 RID: 139687
		private UUISliderComponent Slider;

		// Token: 0x040221A8 RID: 139688
		private UUIText BuyNumberTips;

		// Token: 0x040221A9 RID: 139689
		private INumberSelectData Data;

		// Token: 0x040221AA RID: 139690
		private int SelectNumber;

		// Token: 0x040221AB RID: 139691
		private int MaxValue;

		// Token: 0x040221AC RID: 139692
		private int LimitMaxValue = 9999;

		// Token: 0x040221AD RID: 139693
		private int MinValue = 1;

		// Token: 0x040221AE RID: 139694
		private bool UseCustomMinValue;

		// Token: 0x0200BE75 RID: 48757
		[NullableContext(0)]
		public enum ECompDefine
		{
			// Token: 0x0403AA48 RID: 240200
			ReduceButton,
			// Token: 0x0403AA49 RID: 240201
			AddButton,
			// Token: 0x0403AA4A RID: 240202
			MinText,
			// Token: 0x0403AA4B RID: 240203
			MaxText,
			// Token: 0x0403AA4C RID: 240204
			Slider,
			// Token: 0x0403AA4D RID: 240205
			BuyNumberTips,
			// Token: 0x0403AA4E RID: 240206
			SpriteHandle,
			// Token: 0x0403AA4F RID: 240207
			MaxButton
		}
	}
}
