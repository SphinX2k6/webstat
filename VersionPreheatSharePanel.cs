using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x0200162A RID: 5674
public class VersionPreheatSharePanel : UiPanelBase
{
	// Token: 0x06009FF7 RID: 40951 RVA: 0x0029D0B4 File Offset: 0x0029B2B4
	protected unsafe override void OnRegisterComponent()
	{
		int num = 4;
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
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06009FF8 RID: 40952 RVA: 0x0029D160 File Offset: 0x0029B360
	protected override void OnStart()
	{
		VersionPreheatShareData versionPreheatShareData = (VersionPreheatShareData)this.OpenParam;
		UUIText text = base.GetText(2);
		if (text != null)
		{
			text.SetUIActive(false);
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), versionPreheatShareData.NameTextId, Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), versionPreheatShareData.ThemeTextId, Array.Empty<object>());
		base.SetTextureByPath(versionPreheatShareData.PhotoPath, base.GetTexture(0), null, null);
	}

	// Token: 0x020079E6 RID: 31206
	private class EComponents
	{
		// Token: 0x04029DA1 RID: 171425
		public const int Texture = 0;

		// Token: 0x04029DA2 RID: 171426
		public const int Name = 1;

		// Token: 0x04029DA3 RID: 171427
		public const int Time = 2;

		// Token: 0x04029DA4 RID: 171428
		public const int Desc = 3;
	}
}
