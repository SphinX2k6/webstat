using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x020013BE RID: 5054
[Nullable(new byte[]
{
	0,
	1
})]
public class CharacterValueItem : GridProxyAbstract<CharacterData>
{
	// Token: 0x06008B78 RID: 35704 RVA: 0x0024B9AC File Offset: 0x00249BAC
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUISprite)),
			new ValueTuple<int, Type>(2, typeof(UUISprite)),
			new ValueTuple<int, Type>(3, typeof(UUISprite))
		};
	}

	// Token: 0x06008B79 RID: 35705 RVA: 0x0024BA1C File Offset: 0x00249C1C
	protected override void OnStart()
	{
		this.OriginalProgressWidth = base.GetSprite(1).Width;
		base.GetSprite(2).SetFillAmount(0f);
	}

	// Token: 0x06008B7A RID: 35706 RVA: 0x0024BA44 File Offset: 0x00249C44
	[NullableContext(1)]
	public override void Refresh(CharacterData data, bool isSelected, int gridIndex)
	{
		base.GetText(0).SetText(data.CurrentValue.ToString(), true);
		this.RefreshProgress(data.CurrentValue, data.MaxValue);
		this.RefreshSprite(data.Id);
	}

	// Token: 0x06008B7B RID: 35707 RVA: 0x0024BA8A File Offset: 0x00249C8A
	public void RefreshCurrentValue(int value)
	{
		base.GetText(0).SetText(value.ToString(), true);
	}

	// Token: 0x06008B7C RID: 35708 RVA: 0x0024BAA0 File Offset: 0x00249CA0
	public void RefreshProgress(int value, int maxValue)
	{
		float num = (value < maxValue) ? ((float)value / (float)maxValue) : 1f;
		float width = this.OriginalProgressWidth * num;
		UUISprite sprite = base.GetSprite(1);
		if (sprite == null)
		{
			return;
		}
		sprite.SetWidth(width);
	}

	// Token: 0x06008B7D RID: 35709 RVA: 0x0024BADC File Offset: 0x00249CDC
	public void RefreshSprite(int characterId)
	{
		this.SetSpriteByPath(ConfigBase<BusinessConfig>.Instance.GetCharacterConfig(characterId).BarSprite, base.GetSprite(1), false, null, null);
	}

	// Token: 0x06008B7E RID: 35710 RVA: 0x0024BB14 File Offset: 0x00249D14
	public void RefreshProgressAdd(int value, int maxValue)
	{
		float fillAmount = (float)value / (float)maxValue;
		base.GetSprite(2).SetFillAmount(fillAmount);
	}

	// Token: 0x06008B7F RID: 35711 RVA: 0x0024BB34 File Offset: 0x00249D34
	public void SetLightProgressWidth()
	{
		float width = base.GetSprite(1).GetWidth();
		UUISprite sprite = base.GetSprite(3);
		if (sprite == null)
		{
			return;
		}
		sprite.SetWidth(width);
	}

	// Token: 0x0400411C RID: 16668
	protected float OriginalProgressWidth;

	// Token: 0x02007789 RID: 30601
	private static class EComponentDefine
	{
		// Token: 0x0402925C RID: 168540
		public const int CurrentValue = 0;

		// Token: 0x0402925D RID: 168541
		public const int Progress = 1;

		// Token: 0x0402925E RID: 168542
		public const int ProgressAdd = 2;

		// Token: 0x0402925F RID: 168543
		public const int LightProgress = 3;
	}
}
