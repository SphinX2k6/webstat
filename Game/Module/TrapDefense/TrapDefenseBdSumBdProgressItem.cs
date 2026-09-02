using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004E5E RID: 20062
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class TrapDefenseBdSumBdProgressItem : GridProxyAbstract<ITrapDefenseBdProgressInfo>
	{
		// Token: 0x06033D87 RID: 212359 RVA: 0x00CF70DC File Offset: 0x00CF52DC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06033D88 RID: 212360 RVA: 0x00CF7168 File Offset: 0x00CF5368
		public override void Refresh(ITrapDefenseBdProgressInfo data, bool isSelected, int gridIndex)
		{
			this.ItemData = data;
			bool isShowQualityArrow = data.IsShowQualityArrow;
			UUISprite sprite = base.GetSprite(0);
			sprite.SetUIActive(false);
			UUIItem item = base.GetItem(1);
			if (item != null)
			{
				item.SetUIActive(data.IsActive);
			}
			if (isShowQualityArrow)
			{
				string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(data.QualityArrowRes.ToString());
				this.SetSpriteByPath(resourcePath, sprite, false, null, null);
			}
			ETrapDefenseBdBuffQuality curActiveQualityPool = data.BdData.GetCurActiveQualityPool();
			UiResourceConfig instance = ConfigBase<UiResourceConfig>.Instance;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(14, 1);
			defaultInterpolatedStringHandler.AppendLiteral("SP_BdProgress_");
			defaultInterpolatedStringHandler.AppendFormatted<int>((int)curActiveQualityPool);
			string resourcePath2 = instance.GetResourcePath(defaultInterpolatedStringHandler.ToStringAndClear());
			this.SetSpriteByPath(resourcePath2, base.GetSprite(2), false, null, null);
		}

		// Token: 0x06033D89 RID: 212361 RVA: 0x00CF7235 File Offset: 0x00CF5435
		public void SetQualityArrowShow(bool show)
		{
			if (!this.ItemData.IsShowQualityArrow)
			{
				return;
			}
			UUISprite sprite = base.GetSprite(0);
			if (sprite == null)
			{
				return;
			}
			sprite.SetUIActive(show);
		}

		// Token: 0x0401DFD0 RID: 122832
		public ITrapDefenseBdProgressInfo ItemData;

		// Token: 0x0401DFD1 RID: 122833
		public Action<ITrapDefenseBdProgressInfo> ClickCallBack;

		// Token: 0x0200AE0A RID: 44554
		[NullableContext(0)]
		private class EChildType
		{
			// Token: 0x040360D1 RID: 221393
			public const int SpriteArrow = 0;

			// Token: 0x040360D2 RID: 221394
			public const int ItemProgressRoot = 1;

			// Token: 0x040360D3 RID: 221395
			public const int SpriteProgress = 2;
		}
	}
}
