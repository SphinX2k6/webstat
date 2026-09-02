using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020015FE RID: 5630
[NullableContext(1)]
[Nullable(0)]
public class ActivityProgressComponents : UiPanelBase
{
	// Token: 0x06009EA6 RID: 40614 RVA: 0x00298320 File Offset: 0x00296520
	protected unsafe override void OnRegisterComponent()
	{
		int num = 4;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06009EA7 RID: 40615 RVA: 0x002983CB File Offset: 0x002965CB
	public void SetProgressPercent(float progress)
	{
		UUISprite sprite = base.GetSprite(0);
		if (sprite == null)
		{
			return;
		}
		sprite.SetFillAmount(progress);
	}

	// Token: 0x06009EA8 RID: 40616 RVA: 0x002983DF File Offset: 0x002965DF
	public void SetProgressTextByText(string text)
	{
		UUIText text2 = base.GetText(1);
		if (text2 == null)
		{
			return;
		}
		text2.SetText(text, true);
	}

	// Token: 0x06009EA9 RID: 40617 RVA: 0x002983F4 File Offset: 0x002965F4
	public void SetTitleByTextId(string textId, [Nullable(new byte[]
	{
		2,
		1
	})] params string[] args)
	{
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), textId, args);
	}

	// Token: 0x06009EAA RID: 40618 RVA: 0x00298409 File Offset: 0x00296609
	public void SetTitleByText(string text)
	{
		UUIText text2 = base.GetText(2);
		if (text2 == null)
		{
			return;
		}
		text2.SetText(text, true);
	}

	// Token: 0x06009EAB RID: 40619 RVA: 0x0029841E File Offset: 0x0029661E
	public void SetDescriptionByTextId(string textId, [Nullable(new byte[]
	{
		2,
		1
	})] params string[] args)
	{
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), textId, args);
	}

	// Token: 0x06009EAC RID: 40620 RVA: 0x00298433 File Offset: 0x00296633
	public void SetDescriptionByText(string text)
	{
		UUIText text2 = base.GetText(3);
		if (text2 == null)
		{
			return;
		}
		text2.SetText(text, true);
	}

	// Token: 0x020079BE RID: 31166
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x04029CD1 RID: 171217
		public const int SpriteProgress = 0;

		// Token: 0x04029CD2 RID: 171218
		public const int TextProgress = 1;

		// Token: 0x04029CD3 RID: 171219
		public const int Title = 2;

		// Token: 0x04029CD4 RID: 171220
		public const int TextDescription = 3;
	}
}
