using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001ACA RID: 6858
[NullableContext(1)]
[Nullable(0)]
public class AbyssDangoCircleQualityItem : UiPanelBase
{
	// Token: 0x0600C573 RID: 50547 RVA: 0x00342474 File Offset: 0x00340674
	protected unsafe override void OnRegisterComponent()
	{
		int num = 9;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUISprite));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600C574 RID: 50548 RVA: 0x003425C8 File Offset: 0x003407C8
	protected override void OnStart()
	{
		this.SpriteList.Add(base.GetSprite(0));
		this.QualitySpriteMap[0] = base.GetSprite(0);
		this.SpriteList.Add(base.GetSprite(2));
		this.QualitySpriteMap[1] = base.GetSprite(2);
		this.SpriteList.Add(base.GetSprite(1));
		this.QualitySpriteMap[2] = base.GetSprite(1);
		for (int i = 0; i < 6; i++)
		{
			UUISprite sprite = base.GetSprite(8 - i);
			this.SpriteList.Add(sprite);
			this.QualitySpriteMap[i + 3] = sprite;
		}
		foreach (UUISprite uuisprite in this.SpriteList)
		{
			uuisprite.SetUIActive(false);
		}
	}

	// Token: 0x0600C575 RID: 50549 RVA: 0x003426BC File Offset: 0x003408BC
	public void RefreshData(DangoCircleQualityData data)
	{
		foreach (UUISprite uuisprite in this.SpriteList)
		{
			uuisprite.SetUIActive(false);
		}
		foreach (KeyValuePair<int, int> keyValuePair in data.PluginIdMap)
		{
			if (keyValuePair.Key == 0)
			{
				this.RefreshMiddleSprite(keyValuePair.Value);
			}
			else
			{
				this.RefreshOtherSprite(keyValuePair.Key, keyValuePair.Value);
			}
		}
	}

	// Token: 0x0600C576 RID: 50550 RVA: 0x00342774 File Offset: 0x00340974
	private void RefreshMiddleSprite(int configId)
	{
		if (configId == 0)
		{
			this.QualitySpriteMap[0].SetUIActive(false);
			return;
		}
		this.QualitySpriteMap[0].SetUIActive(true);
		int qualityId = ConfigBase<DangoAbyssConfig>.Instance.GetDangoItemById(configId).Value.QualityId;
		AbyssQuality? abyssQualityById = ConfigBase<DangoAbyssConfig>.Instance.GetAbyssQualityById(qualityId);
		this.SetSpriteByPath(((abyssQualityById != null) ? abyssQualityById.GetValueOrDefault().AbyssCoreItemFormationBg : null) ?? "", this.QualitySpriteMap[0], false, null, null);
	}

	// Token: 0x0600C577 RID: 50551 RVA: 0x00342814 File Offset: 0x00340A14
	private void RefreshOtherSprite(int index, int configId)
	{
		UUISprite uuisprite;
		if (!this.QualitySpriteMap.TryGetValue(index, out uuisprite))
		{
			return;
		}
		if (configId == 0)
		{
			uuisprite.SetUIActive(false);
			return;
		}
		uuisprite.SetUIActive(true);
		int qualityId = ConfigBase<DangoAbyssConfig>.Instance.GetDangoItemById(configId).Value.QualityId;
		AbyssQuality? abyssQualityById = ConfigBase<DangoAbyssConfig>.Instance.GetAbyssQualityById(qualityId);
		this.SetSpriteByPath(((abyssQualityById != null) ? abyssQualityById.GetValueOrDefault().AbyssItemFormationBg : null) ?? "", uuisprite, false, null, null);
		FColor color = FColor.FromHex(((abyssQualityById != null) ? abyssQualityById.GetValueOrDefault().AbyssItemFormationBgColor : null) ?? "");
		uuisprite.SetColor(color);
	}

	// Token: 0x04005EA3 RID: 24227
	private readonly Dictionary<int, UUISprite> QualitySpriteMap = new Dictionary<int, UUISprite>();

	// Token: 0x04005EA4 RID: 24228
	private readonly List<UUISprite> SpriteList = new List<UUISprite>();

	// Token: 0x02007D9C RID: 32156
	[NullableContext(0)]
	private class EComponent
	{
		// Token: 0x0402AC85 RID: 175237
		public const int MiddleSprite = 0;

		// Token: 0x0402AC86 RID: 175238
		public const int TopSprite = 1;

		// Token: 0x0402AC87 RID: 175239
		public const int LeftTopSprite = 2;

		// Token: 0x0402AC88 RID: 175240
		public const int LeftSprite = 3;

		// Token: 0x0402AC89 RID: 175241
		public const int LeftBottomSprite = 4;

		// Token: 0x0402AC8A RID: 175242
		public const int BottomSprite = 5;

		// Token: 0x0402AC8B RID: 175243
		public const int RightBottomSprite = 6;

		// Token: 0x0402AC8C RID: 175244
		public const int RightSprite = 7;

		// Token: 0x0402AC8D RID: 175245
		public const int RightTopSprite = 8;
	}
}
