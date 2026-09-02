using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.WorldMap.SubViews.MapMarkToggle
{
	// Token: 0x02004B9C RID: 19356
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class MapMarkProgressItem : GridProxyAbstract<IMapMarkProgressItemData>
	{
		// Token: 0x060328AE RID: 207022 RVA: 0x00CA73DC File Offset: 0x00CA55DC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISliderComponent));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x060328AF RID: 207023 RVA: 0x00CA7468 File Offset: 0x00CA5668
		[NullableContext(1)]
		public override void Refresh(IMapMarkProgressItemData data, bool isSelected, int gridIndex)
		{
			this.DataParam = data;
			UUIText text = base.GetText(0);
			if (text != null)
			{
				text.ShowTextNew(data.NameId);
			}
			float progress = data.Progress;
			UUISliderComponent slider = base.GetSlider(2);
			if (slider != null)
			{
				slider.SetMinValue(data.ProgressMin, false, false);
				slider.SetMaxValue(data.ProgressMax, false, false);
				slider.SetValue(progress, true);
				slider.OnValueChangeCb.Bind(new Action<float>(this.SetProgressCallback));
			}
			float num = progress / this.DataParam.ProgressMax * 100f;
			UUIText text2 = base.GetText(1);
			if (text2 == null)
			{
				return;
			}
			text2.SetText(num.ToString("F0"), true);
		}

		// Token: 0x060328B0 RID: 207024 RVA: 0x00CA7514 File Offset: 0x00CA5714
		private void SetProgressCallback(float progress)
		{
			IMapMarkProgressItemData dataParam = this.DataParam;
			if (dataParam != null)
			{
				Action<float> setProgressCallback = dataParam.SetProgressCallback;
				if (setProgressCallback != null)
				{
					setProgressCallback(progress);
				}
			}
			float num = progress / this.DataParam.ProgressMax * 100f;
			UUIText text = base.GetText(1);
			if (text == null)
			{
				return;
			}
			text.SetText(num.ToString("F0"), true);
		}

		// Token: 0x0401D785 RID: 120709
		[Nullable(2)]
		private IMapMarkProgressItemData DataParam;

		// Token: 0x0200AC7A RID: 44154
		public static class EChildType
		{
			// Token: 0x040359D9 RID: 219609
			public const int TextName = 0;

			// Token: 0x040359DA RID: 219610
			public const int TextSettingNum = 1;

			// Token: 0x040359DB RID: 219611
			public const int Slider = 2;
		}
	}
}
