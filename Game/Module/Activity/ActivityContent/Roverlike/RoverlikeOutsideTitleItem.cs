using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x020063EB RID: 25579
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RoverlikeOutsideTitleItem : SyncGridProxyAbstract<RoverlikeOutsideTitleData>
	{
		// Token: 0x0604039E RID: 263070 RVA: 0x010758D4 File Offset: 0x01073AD4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0604039F RID: 263071 RVA: 0x01075960 File Offset: 0x01073B60
		[NullableContext(1)]
		public override void Refresh(RoverlikeOutsideTitleData data)
		{
			bool flag = !StringUtils.IsEmpty(data.IconPath);
			bool flag2 = !StringUtils.IsEmpty(data.TitleKey);
			UUIText text = base.GetText(2);
			if (text != null)
			{
				text.SetUIActive(flag2);
				if (flag2)
				{
					Singleton<LguiUtil>.Instance.SetLocalTextNew(text, data.TitleKey, Array.Empty<object>());
				}
			}
			UUITexture texture = base.GetTexture(1);
			if (texture != null)
			{
				texture.SetUIActive(flag);
				if (flag)
				{
					base.SetTextureByPath(data.IconPath, texture, null, null);
				}
			}
		}

		// Token: 0x0200C450 RID: 50256
		private enum EComponents
		{
			// Token: 0x0403C6E3 RID: 247523
			SprLine,
			// Token: 0x0403C6E4 RID: 247524
			TexElementIcon,
			// Token: 0x0403C6E5 RID: 247525
			TxtName
		}
	}
}
