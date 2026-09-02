using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Role
{
	// Token: 0x020065C8 RID: 26056
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class PinballAttributeItem : GridProxyAbstract<IPinballAttributeItemData>
	{
		// Token: 0x060411A5 RID: 266661 RVA: 0x010B3F68 File Offset: 0x010B2168
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x060411A6 RID: 266662 RVA: 0x010B4014 File Offset: 0x010B2214
		[NullableContext(1)]
		public override void Refresh(IPinballAttributeItemData data, bool isSelected, int gridIndex)
		{
			base.SetTextureByPath(data.AttributeConfig.Icon, base.GetTexture(2), null, null);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), data.AttributeConfig.Name, Array.Empty<object>());
			string formatAttributeValueString = ModelBase<PinballModel>.Instance.GetFormatAttributeValueString(data.AttributeConfig, (float)data.AttributeValue);
			base.GetText(1).SetText(formatAttributeValueString, true);
			base.GetSprite(3).SetUIActive(data.IsBgShow);
		}

		// Token: 0x0200C5CA RID: 50634
		private enum EComponent
		{
			// Token: 0x0403CE0E RID: 249358
			AttributeNameText,
			// Token: 0x0403CE0F RID: 249359
			AttributeValueText,
			// Token: 0x0403CE10 RID: 249360
			IconTexture,
			// Token: 0x0403CE11 RID: 249361
			BgSprite
		}
	}
}
