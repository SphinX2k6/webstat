using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BossPiling.View.Item
{
	// Token: 0x02005F05 RID: 24325
	public class BossPilingBuffTitleItem : SyncGridProxyAbstract<int>
	{
		// Token: 0x0603D1A5 RID: 250277 RVA: 0x00F851B8 File Offset: 0x00F833B8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603D1A6 RID: 250278 RVA: 0x00F85224 File Offset: 0x00F83424
		public override void Refresh(int data)
		{
			string key = (data == 5) ? "BossPilingActivity_Buff01" : "BossPilingActivity_Buff02";
			UUIText text = base.GetText(0);
			FColor changeColor = text.changeColor;
			UUIItem uuiitem = text;
			bool bUseChangeColor = data != 5;
			FColor? fcolor = new FColor?(changeColor);
			uuiitem.SetChangeColor(bUseChangeColor, fcolor);
			text.ShowTextNew(key);
			UUIItem sprite = base.GetSprite(1);
			FColor changeColor2 = text.changeColor;
			bool bUseChangeColor2 = data != 5;
			fcolor = new FColor?(changeColor2);
			sprite.SetChangeColor(bUseChangeColor2, fcolor);
		}

		// Token: 0x0200BF06 RID: 48902
		private enum ETitle
		{
			// Token: 0x0403ACB4 RID: 240820
			Txt,
			// Token: 0x0403ACB5 RID: 240821
			Sprite
		}
	}
}
