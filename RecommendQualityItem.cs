using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x0200274F RID: 10063
[Nullable(new byte[]
{
	0,
	1
})]
public class RecommendQualityItem : GridProxyAbstract<IRecommendQualityItemData>
{
	// Token: 0x06013DDE RID: 81374 RVA: 0x005894B4 File Offset: 0x005876B4
	protected unsafe override void OnRegisterComponent()
	{
		int num = 4;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnToggleRoot));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06013DDF RID: 81375 RVA: 0x0058959C File Offset: 0x0058779C
	[NullableContext(1)]
	public override void Refresh(IRecommendQualityItemData data, bool isSelected, int gridIndex)
	{
		base.SetTextureShowUntilLoaded(data.Bg, base.GetTexture(1), null);
		UUIText text = base.GetText(2);
		if (text != null)
		{
			text.ShowTextNew(data.Name);
		}
		UUISprite sprite = base.GetSprite(3);
		if (sprite == null)
		{
			return;
		}
		sprite.SetUIActive(data.IsRecommend);
	}

	// Token: 0x06013DE0 RID: 81376 RVA: 0x005895EC File Offset: 0x005877EC
	private void OnToggleRoot(EToggleState check)
	{
		if (check == EToggleState.ETT_Checked)
		{
			IScrollViewDelegate<IGridProxy<IRecommendQualityItemData>, IRecommendQualityItemData> scrollViewDelegate = base.ScrollViewDelegate;
			if (scrollViewDelegate == null)
			{
				return;
			}
			scrollViewDelegate.SelectGridProxy(base.GridIndex, base.DisplayIndex, false);
		}
	}

	// Token: 0x06013DE1 RID: 81377 RVA: 0x0058960F File Offset: 0x0058780F
	public override void OnSelected(bool fireEvent)
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle == null)
		{
			return;
		}
		extendToggle.SetToggleState(EToggleState.ETT_Checked, false, false, false);
	}

	// Token: 0x06013DE2 RID: 81378 RVA: 0x00589627 File Offset: 0x00587827
	public override void OnDeselected(bool fireEvent)
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle == null)
		{
			return;
		}
		extendToggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x02008B0E RID: 35598
	private class EChildType
	{
		// Token: 0x0402EE5C RID: 192092
		public const int Root = 0;

		// Token: 0x0402EE5D RID: 192093
		public const int Bg = 1;

		// Token: 0x0402EE5E RID: 192094
		public const int Name = 2;

		// Token: 0x0402EE5F RID: 192095
		public const int RecommendIcon = 3;
	}
}
