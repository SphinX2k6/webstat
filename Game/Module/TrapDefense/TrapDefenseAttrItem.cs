using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004E3C RID: 20028
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class TrapDefenseAttrItem : GridProxyAbstract<ITrapDefenseAttrItemData>
	{
		// Token: 0x06033C4B RID: 212043 RVA: 0x00CF0B9C File Offset: 0x00CEED9C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06033C4C RID: 212044 RVA: 0x00CF0C28 File Offset: 0x00CEEE28
		public override void Refresh(ITrapDefenseAttrItemData data, bool isSelected, int gridIndex)
		{
			this.ItemData = data;
			UUITexture texture = base.GetTexture(0);
			UUIText text = base.GetText(1);
			UUIText text2 = base.GetText(2);
			text.ShowTextNew(data.NameKey);
			text2.SetUIActive(!string.IsNullOrEmpty(data.Value));
			texture.SetUIActive(!string.IsNullOrEmpty(data.IconPath));
			if (!string.IsNullOrEmpty(data.IconPath))
			{
				base.SetTextureByPath(data.IconPath, texture, null, null);
			}
			if (!string.IsNullOrEmpty(data.Value))
			{
				text2.SetText(data.Value, true);
			}
		}

		// Token: 0x0401DF5B RID: 122715
		public ITrapDefenseAttrItemData ItemData;

		// Token: 0x0401DF5C RID: 122716
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Action<ITrapDefenseAttrItemData> ClickCallBack;

		// Token: 0x0200ADC4 RID: 44484
		[NullableContext(0)]
		private class EChildType
		{
			// Token: 0x04035F5E RID: 221022
			public const int TextureIcon = 0;

			// Token: 0x04035F5F RID: 221023
			public const int TextName = 1;

			// Token: 0x04035F60 RID: 221024
			public const int TextValue = 2;
		}
	}
}
