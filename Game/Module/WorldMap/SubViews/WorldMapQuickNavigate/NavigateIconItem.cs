using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.WorldMap.SubViews.WorldMapQuickNavigate
{
	// Token: 0x02004B66 RID: 19302
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class NavigateIconItem : GridProxyAbstract<INavigateIconItemData>
	{
		// Token: 0x0603270C RID: 206604 RVA: 0x00C9E69C File Offset: 0x00C9C89C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603270D RID: 206605 RVA: 0x00C9E744 File Offset: 0x00C9C944
		[NullableContext(1)]
		public override void Refresh(INavigateIconItemData data, bool isSelected, int gridIndex)
		{
			this.DataParam = data;
			string path = (data.IconId != null) ? ConfigBase<UiResourceConfig>.Instance.GetResourcePath(data.IconId) : data.IconPath;
			UUISprite sprite = base.GetSprite(1);
			this.SetSpriteByPath(path, sprite, false, null, null);
		}

		// Token: 0x0603270E RID: 206606 RVA: 0x00C9E794 File Offset: 0x00C9C994
		private void OnClick()
		{
			if (this.DataParam != null)
			{
				this.DataParam.ClickCallback(this.DataParam.Id, this.DataParam.MarkItem);
			}
		}

		// Token: 0x0401D6DE RID: 120542
		[Nullable(2)]
		private INavigateIconItemData DataParam;

		// Token: 0x0200AC35 RID: 44085
		public static class EChildType
		{
			// Token: 0x040358DF RID: 219359
			public const int BtnRoot = 0;

			// Token: 0x040358E0 RID: 219360
			public const int SpriteIcon = 1;
		}
	}
}
