using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001FFD RID: 8189
public class InfoDisplayImgView : UiViewBase
{
	// Token: 0x0600F74F RID: 63311 RVA: 0x0043B258 File Offset: 0x00439458
	[NullableContext(1)]
	public InfoDisplayImgView(UiViewInfo uiViewInfo) : base(uiViewInfo)
	{
	}

	// Token: 0x0600F750 RID: 63312 RVA: 0x0043B264 File Offset: 0x00439464
	protected unsafe override void OnRegisterComponent()
	{
		int num = 3;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnClickCloseBtn));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600F751 RID: 63313 RVA: 0x0043B32B File Offset: 0x0043952B
	private void OnClickCloseBtn()
	{
		base.CloseMe(null);
	}

	// Token: 0x0600F752 RID: 63314 RVA: 0x0043B334 File Offset: 0x00439534
	protected override void OnStart()
	{
		this.RefreshView();
	}

	// Token: 0x0600F753 RID: 63315 RVA: 0x0043B33C File Offset: 0x0043953C
	private void RefreshView()
	{
		string path2 = ModelBase<InfoDisplayModel>.Instance.CurrentCurrentInformationTexture();
		UUITexture uiTexture = base.GetTexture(0);
		Singleton<ResourceSystem>.Instance.LoadAsync<UTexture>(path2, delegate([Nullable(2)] UTexture texture, string path)
		{
			if (texture != null && texture.IsValid() && uiTexture != null && uiTexture.IsValid())
			{
				uiTexture.SetTexture(texture);
			}
		}, 100, this.MemoryTag);
	}

	// Token: 0x0200837D RID: 33661
	private class EInfoDisplayImgViewComponents
	{
		// Token: 0x0402C980 RID: 182656
		public const int DetailImg = 0;

		// Token: 0x0402C981 RID: 182657
		public const int CloseText = 1;

		// Token: 0x0402C982 RID: 182658
		public const int MaskBtn = 2;
	}
}
