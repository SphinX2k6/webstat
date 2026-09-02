using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004E3D RID: 20029
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class TrapDefenseTagAttrItem : GridProxyAbstract<ITrapDefenseAttrItemData>
	{
		// Token: 0x06033C4E RID: 212046 RVA: 0x00CF0CD0 File Offset: 0x00CEEED0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06033C4F RID: 212047 RVA: 0x00CF0D5C File Offset: 0x00CEEF5C
		public override void Refresh(ITrapDefenseAttrItemData data, bool isSelected, int gridIndex)
		{
			this.ItemData = data;
			UUISprite sprite = base.GetSprite(0);
			UUIText text = base.GetText(1);
			UUIText text2 = base.GetText(2);
			text.ShowTextNew(data.NameKey);
			text2.SetUIActive(!string.IsNullOrEmpty(data.Value));
			sprite.SetUIActive(!string.IsNullOrEmpty(data.IconPath));
			if (!string.IsNullOrEmpty(data.IconPath))
			{
				this.SetSpriteByPath(data.IconPath, sprite, false, null, null);
			}
			if (!string.IsNullOrEmpty(data.Value))
			{
				text2.ShowTextNew(data.Value);
			}
		}

		// Token: 0x0401DF5D RID: 122717
		public ITrapDefenseAttrItemData ItemData;

		// Token: 0x0401DF5E RID: 122718
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Action<ITrapDefenseAttrItemData> ClickCallBack;

		// Token: 0x0200ADC5 RID: 44485
		[NullableContext(0)]
		private class ETagType
		{
			// Token: 0x04035F61 RID: 221025
			public const int SpriteIcon = 0;

			// Token: 0x04035F62 RID: 221026
			public const int TextName = 1;

			// Token: 0x04035F63 RID: 221027
			public const int TextValue = 2;
		}
	}
}
