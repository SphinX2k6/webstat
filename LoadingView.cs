using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020020DC RID: 8412
[NullableContext(1)]
[Nullable(0)]
public class LoadingView : LoadingViewBase
{
	// Token: 0x0601012B RID: 65835 RVA: 0x00469606 File Offset: 0x00467806
	public LoadingView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0601012C RID: 65836 RVA: 0x00469610 File Offset: 0x00467810
	protected unsafe override void OnRegisterComponent()
	{
		int num = 10;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUILayoutBase));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(4, new Action(base.ChangeShowTips));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0601012D RID: 65837 RVA: 0x004697C0 File Offset: 0x004679C0
	protected override void OnStart()
	{
		this.FillWidth = base.GetItem(9).Width;
		base.OnStart();
		base.GetButton(4).RootUIComp.Get().SetUIActive(this.ShowData.GetTipCount() > 1);
		UUIItem rootItem = this.RootItem;
		if (rootItem == null)
		{
			return;
		}
		rootItem.SetAlpha(1f);
	}

	// Token: 0x0601012E RID: 65838 RVA: 0x00469822 File Offset: 0x00467A22
	protected override void OnAfterShow()
	{
		base.OnAfterShow();
		this.InitContent();
	}

	// Token: 0x0601012F RID: 65839 RVA: 0x00469830 File Offset: 0x00467A30
	private void InitContent()
	{
		UUILayoutBase layout = base.GetLayoutBase(7);
		UUILayoutBase layout5 = layout;
		if (layout5 != null)
		{
			UUIItem rootComponent = layout5.GetRootComponent();
			if (rootComponent != null)
			{
				rootComponent.SetAlpha(0f);
			}
		}
		UUILayoutBase layout2 = layout;
		if (layout2 == null)
		{
			return;
		}
		layout2.OnLateUpdate.Bind(delegate(float _)
		{
			UUILayoutBase layout3 = layout;
			if (layout3 != null)
			{
				layout3.OnLateUpdate.Unbind();
			}
			UUILayoutBase layout4 = layout;
			if (layout4 == null)
			{
				return;
			}
			UUIItem rootComponent2 = layout4.GetRootComponent();
			if (rootComponent2 == null)
			{
				return;
			}
			rootComponent2.SetAlpha(1f);
		});
	}

	// Token: 0x06010130 RID: 65840 RVA: 0x00469892 File Offset: 0x00467A92
	protected override void UpdateShowTipsUi(string title, string tips)
	{
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), tips, Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), title, Array.Empty<object>());
	}

	// Token: 0x06010131 RID: 65841 RVA: 0x004698C4 File Offset: 0x00467AC4
	protected override void UpdateProgressRate(float rate)
	{
		base.SetTextureProgressRate(0, rate);
		float anchorOffsetX = this.FillWidth * rate;
		UUIItem item = base.GetItem(8);
		if (item == null)
		{
			return;
		}
		item.SetAnchorOffsetX(anchorOffsetX);
	}

	// Token: 0x06010132 RID: 65842 RVA: 0x004698F4 File Offset: 0x00467AF4
	protected override void UpdateProgressValue(float value)
	{
		this.SetTextProgressValue(5, value, "");
	}

	// Token: 0x06010133 RID: 65843 RVA: 0x00469903 File Offset: 0x00467B03
	protected override void UpdateBgUi(string path)
	{
		base.SetTextureByPath(path, base.GetTexture(3), new EUiViewName?(this.ViewInfo.Name), null);
	}

	// Token: 0x04007B3A RID: 31546
	private float FillWidth;

	// Token: 0x02008458 RID: 33880
	[NullableContext(0)]
	[StaticVariableRuleIgnore]
	public static class EChildType
	{
		// Token: 0x0402CD74 RID: 183668
		public const int Progress = 0;

		// Token: 0x0402CD75 RID: 183669
		public const int Tips = 1;

		// Token: 0x0402CD76 RID: 183670
		public const int Title = 2;

		// Token: 0x0402CD77 RID: 183671
		public const int BgTexture = 3;

		// Token: 0x0402CD78 RID: 183672
		public const int NextButton = 4;

		// Token: 0x0402CD79 RID: 183673
		public const int ProgressText = 5;

		// Token: 0x0402CD7A RID: 183674
		public const int TypeSprite = 6;

		// Token: 0x0402CD7B RID: 183675
		public const int Layout = 7;

		// Token: 0x0402CD7C RID: 183676
		public const int MoveHandle = 8;

		// Token: 0x0402CD7D RID: 183677
		public const int MoveHandleFollowTarget = 9;
	}
}
