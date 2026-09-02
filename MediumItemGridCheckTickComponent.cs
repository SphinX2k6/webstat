using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;

// Token: 0x020019B3 RID: 6579
[NullableContext(1)]
[Nullable(0)]
public class MediumItemGridCheckTickComponent : MediumItemGridComponent
{
	// Token: 0x0600BD06 RID: 48390 RVA: 0x00322F84 File Offset: 0x00321184
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600BD07 RID: 48391 RVA: 0x00322FED File Offset: 0x003211ED
	protected override string GetResourceId()
	{
		return "UiItem_ItemSelTick";
	}

	// Token: 0x0600BD08 RID: 48392 RVA: 0x00322FF4 File Offset: 0x003211F4
	[NullableContext(2)]
	protected override void OnRefresh(object data)
	{
		IMediumItemGridCheckTickComponentParams mediumItemGridCheckTickComponentParams = data as IMediumItemGridCheckTickComponentParams;
		if (mediumItemGridCheckTickComponentParams == null)
		{
			return;
		}
		bool? isCheckTick = mediumItemGridCheckTickComponentParams.IsCheckTick;
		if (isCheckTick != null)
		{
			this.SetActive(isCheckTick.Value);
			string hexColor = mediumItemGridCheckTickComponentParams.HexColor;
			if (hexColor != null)
			{
				this.SetSpriteColor(hexColor);
			}
			float? alpha = mediumItemGridCheckTickComponentParams.Alpha;
			if (alpha != null)
			{
				this.SetSpriteAlpha(alpha.Value);
			}
			string tickHexColor = mediumItemGridCheckTickComponentParams.TickHexColor;
			if (tickHexColor != null)
			{
				this.SetSpriteTickColor(tickHexColor);
			}
			return;
		}
	}

	// Token: 0x0600BD09 RID: 48393 RVA: 0x00323070 File Offset: 0x00321270
	public void SetSpriteColor(string hexColor)
	{
		FColor color = FColor.FromHex(hexColor);
		UUISprite sprite = base.GetSprite(0);
		if (sprite == null)
		{
			return;
		}
		sprite.SetColor(color);
	}

	// Token: 0x0600BD0A RID: 48394 RVA: 0x00323096 File Offset: 0x00321296
	public void SetSpriteAlpha(float alpha)
	{
		UUISprite sprite = base.GetSprite(0);
		if (sprite == null)
		{
			return;
		}
		sprite.SetAlpha(alpha);
	}

	// Token: 0x0600BD0B RID: 48395 RVA: 0x003230AC File Offset: 0x003212AC
	public void SetSpriteTickColor(string hexColor)
	{
		FColor color = FColor.FromHex(hexColor);
		UUISprite sprite = base.GetSprite(1);
		if (sprite == null)
		{
			return;
		}
		sprite.SetColor(color);
	}

	// Token: 0x0600BD0C RID: 48396 RVA: 0x003230D2 File Offset: 0x003212D2
	public override EItemGridComponentLayoutLevel GetLayoutLevel()
	{
		return EItemGridComponentLayoutLevel.Bottom;
	}

	// Token: 0x02007CB8 RID: 31928
	[NullableContext(0)]
	private class EChildType
	{
		// Token: 0x0402A956 RID: 174422
		public const int Sprite = 0;

		// Token: 0x0402A957 RID: 174423
		public const int SpriteTick = 1;
	}
}
