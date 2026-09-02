using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x0200191D RID: 6429
public class PinballFilterIconView : UiPanelBase
{
	// Token: 0x0600B8EF RID: 47343 RVA: 0x00312BCC File Offset: 0x00310DCC
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600B8F0 RID: 47344 RVA: 0x00312C38 File Offset: 0x00310E38
	[NullableContext(1)]
	public void SetIcon(bool bVisible, string iconPath = "")
	{
		UUITexture texture = base.GetTexture(1);
		if (texture != null)
		{
			texture.SetUIActive(bVisible);
		}
		if (!StringUtils.IsBlank(iconPath))
		{
			base.TrySetTextureByPath(iconPath, base.GetTexture(1), null, null);
		}
	}

	// Token: 0x0600B8F1 RID: 47345 RVA: 0x00312C78 File Offset: 0x00310E78
	public void SetBgChangeColor(bool needChangeColor, FColor? changeColor = null)
	{
		UUISprite sprite = base.GetSprite(0);
		if (sprite == null)
		{
			return;
		}
		sprite.SetChangeColor(needChangeColor, changeColor);
	}

	// Token: 0x02007C70 RID: 31856
	private enum EPinballFilterIconComponent
	{
		// Token: 0x0402A7FC RID: 174076
		SprBg,
		// Token: 0x0402A7FD RID: 174077
		TexIcon
	}
}
