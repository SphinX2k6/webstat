using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Menu.SubViews.EyeProtect
{
	// Token: 0x020057AE RID: 22446
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class EyeProtectItem : GridProxyAbstract<EyeProtectItemData>
	{
		// Token: 0x06039117 RID: 233751 RVA: 0x00E76928 File Offset: 0x00E74B28
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIText)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIScrollViewWithScrollbarComponent)),
				new ValueTuple<int, Type>(5, typeof(UUIItem)),
				new ValueTuple<int, Type>(6, typeof(UUIItem)),
				new ValueTuple<int, Type>(7, typeof(UUIItem)),
				new ValueTuple<int, Type>(8, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.TagToggle))
			};
		}

		// Token: 0x06039118 RID: 233752 RVA: 0x00E76A29 File Offset: 0x00E74C29
		private void TagToggle(EToggleState toggleState)
		{
			Action<int> selectCallback = this.SelectCallback;
			if (selectCallback == null)
			{
				return;
			}
			selectCallback(base.GridIndex);
		}

		// Token: 0x06039119 RID: 233753 RVA: 0x00E76A41 File Offset: 0x00E74C41
		public void SetSelected(bool selected)
		{
			base.GetExtendToggle(0).SetToggleState(selected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
			base.GetItem(3).SetUIActive(selected);
		}

		// Token: 0x0603911A RID: 233754 RVA: 0x00E76A67 File Offset: 0x00E74C67
		[NullableContext(1)]
		public override void Refresh(EyeProtectItemData data, bool isSelected, int gridIndex)
		{
			this.Data = data;
			this.InitData();
			if (isSelected)
			{
				this.OnSelected(false);
				return;
			}
			this.OnDeselected(false);
		}

		// Token: 0x0603911B RID: 233755 RVA: 0x00E76A88 File Offset: 0x00E74C88
		public void InitData()
		{
			if (this.Data == null)
			{
				return;
			}
			Singleton<LguiUtil>.Instance.TrySetLocalTextNew(base.GetText(2), this.Data.GetModeName(), Array.Empty<object>());
			if (this.Data.IsCustom())
			{
				base.GetItem(6).SetUIActive(false);
				base.GetItem(8).SetUIActive(true);
			}
			else
			{
				base.GetItem(6).SetUIActive(true);
				base.GetItem(8).SetUIActive(false);
			}
			this.ScrollView = new GenericScrollViewNew<EyeProtectSliderItem, EyeProtectSliderData>(base.GetScrollViewWithScrollbar(4), new Func<EyeProtectSliderItem>(this.CreateSliderItem), null, false, null);
			List<EyeProtectSliderData> sliderDataList = this.Data.GetViewModel().GetSliderDataList((EModeValue)this.Data.GetModeValue());
			if (sliderDataList != null)
			{
				this.ScrollView.RefreshByData(sliderDataList, null, false);
			}
			this.OnApply(Singleton<GameSettingsManager>.Instance.GetCurrentValueSafely(EFunction.EyeProtectionMode, 0, true));
		}

		// Token: 0x0603911C RID: 233756 RVA: 0x00E76B67 File Offset: 0x00E74D67
		[NullableContext(1)]
		private EyeProtectSliderItem CreateSliderItem()
		{
			return new EyeProtectSliderItem();
		}

		// Token: 0x0603911D RID: 233757 RVA: 0x00E76B6E File Offset: 0x00E74D6E
		public override void OnSelected(bool fireEvent)
		{
			this.SetSelected(true);
		}

		// Token: 0x0603911E RID: 233758 RVA: 0x00E76B77 File Offset: 0x00E74D77
		public override void OnDeselected(bool fireEvent)
		{
			this.SetSelected(false);
		}

		// Token: 0x0603911F RID: 233759 RVA: 0x00E76B80 File Offset: 0x00E74D80
		public void OnApply(int value)
		{
			UUIItem item = base.GetItem(7);
			EyeProtectItemData data = this.Data;
			int? num = (data != null) ? new int?(data.GetModeValue()) : null;
			item.SetUIActive(value == num.GetValueOrDefault() & num != null);
		}

		// Token: 0x040207D0 RID: 133072
		public EyeProtectItemData Data;

		// Token: 0x040207D1 RID: 133073
		public Action<int> SelectCallback;

		// Token: 0x040207D2 RID: 133074
		public Func<int, bool> CanExecuteChange;

		// Token: 0x040207D3 RID: 133075
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		public GenericScrollViewNew<EyeProtectSliderItem, EyeProtectSliderData> ScrollView;

		// Token: 0x0200B832 RID: 47154
		[NullableContext(0)]
		public class EComponent
		{
			// Token: 0x04038F93 RID: 233363
			public const int ItemSelf = 0;

			// Token: 0x04038F94 RID: 233364
			public const int RedPoint = 1;

			// Token: 0x04038F95 RID: 233365
			public const int Title = 2;

			// Token: 0x04038F96 RID: 233366
			public const int SliderLayout = 3;

			// Token: 0x04038F97 RID: 233367
			public const int Scroll = 4;

			// Token: 0x04038F98 RID: 233368
			public const int SliderItem = 5;

			// Token: 0x04038F99 RID: 233369
			public const int Mask = 6;

			// Token: 0x04038F9A RID: 233370
			public const int Toggle = 7;

			// Token: 0x04038F9B RID: 233371
			public const int GamePadKey = 8;
		}
	}
}
