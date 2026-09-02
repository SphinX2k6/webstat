using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020020DB RID: 8411
public class DangoAbyssWorldLoadingView : LoadingViewBase
{
	// Token: 0x06010125 RID: 65829 RVA: 0x004694DE File Offset: 0x004676DE
	[NullableContext(1)]
	public DangoAbyssWorldLoadingView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06010126 RID: 65830 RVA: 0x004694E8 File Offset: 0x004676E8
	protected unsafe override void OnRegisterComponent()
	{
		int num = 4;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06010127 RID: 65831 RVA: 0x00469593 File Offset: 0x00467793
	protected override void OnStart()
	{
		base.OnStart();
		UUIItem item = base.GetItem(1);
		this.FullSize = ((item != null) ? item.Width : 0f);
	}

	// Token: 0x06010128 RID: 65832 RVA: 0x004695B8 File Offset: 0x004677B8
	protected override void UpdateProgressRate(float rate)
	{
		base.SetTextureProgressRate(0, rate);
		float anchorOffsetX = this.FullSize * rate;
		UUIItem item = base.GetItem(2);
		if (item == null)
		{
			return;
		}
		item.SetAnchorOffsetX(anchorOffsetX);
	}

	// Token: 0x06010129 RID: 65833 RVA: 0x004695E8 File Offset: 0x004677E8
	protected override void UpdateProgressValue(float value)
	{
		this.SetTextProgressValue(3, value, "%");
	}

	// Token: 0x0601012A RID: 65834 RVA: 0x004695F7 File Offset: 0x004677F7
	protected override void OnLevelSequencePlayerBandStateChange(bool state)
	{
		base.PlaySequence("Loop", null, false);
	}

	// Token: 0x04007B39 RID: 31545
	private float FullSize;

	// Token: 0x02008457 RID: 33879
	private class EChildType
	{
		// Token: 0x0402CD70 RID: 183664
		public const int Progress = 0;

		// Token: 0x0402CD71 RID: 183665
		public const int NiagaraParent = 1;

		// Token: 0x0402CD72 RID: 183666
		public const int NiagaraItem = 2;

		// Token: 0x0402CD73 RID: 183667
		public const int LoadingText = 3;
	}
}
