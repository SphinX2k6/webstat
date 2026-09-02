using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.BossPiling.View.Item
{
	// Token: 0x02005F09 RID: 24329
	public class BossPilingBuffSimpleItem : GridProxyAbstract<int>
	{
		// Token: 0x0603D1B5 RID: 250293 RVA: 0x00F85680 File Offset: 0x00F83880
		protected unsafe override void OnRegisterComponent()
		{
			int num = 10;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603D1B6 RID: 250294 RVA: 0x00F857F3 File Offset: 0x00F839F3
		protected override void OnStart()
		{
			UUISprite sprite = base.GetSprite(4);
			if (sprite != null)
			{
				sprite.SetUIActive(false);
			}
			UUIText text = base.GetText(3);
			if (text != null)
			{
				text.SetUIActive(false);
			}
			UUIExtendToggle extendToggle = base.GetExtendToggle(7);
			if (extendToggle == null)
			{
				return;
			}
			extendToggle.SetSelfInteractive(false);
		}

		// Token: 0x0603D1B7 RID: 250295 RVA: 0x00F85830 File Offset: 0x00F83A30
		public override void Refresh(int data, bool isSelected, int gridIndex)
		{
			BossPilingBuff value = ConfigBase<BossPilingConfig>.Instance.GetBuffInfo(data).Value;
			base.SetQualityIconById(base.GetSprite(0), value.Quality, null, null, null);
			base.SetTextureByPath(value.Icon, base.GetTexture(1), null, null);
		}

		// Token: 0x0200BF09 RID: 48905
		private enum EChildType
		{
			// Token: 0x0403ACC3 RID: 240835
			QualitySprite,
			// Token: 0x0403ACC4 RID: 240836
			ItemTexture,
			// Token: 0x0403ACC5 RID: 240837
			BottomTextItem,
			// Token: 0x0403ACC6 RID: 240838
			BottomText,
			// Token: 0x0403ACC7 RID: 240839
			BottomTextBgSprite,
			// Token: 0x0403ACC8 RID: 240840
			BottomAdditionItem,
			// Token: 0x0403ACC9 RID: 240841
			TopAdditionItem,
			// Token: 0x0403ACCA RID: 240842
			ExtendToggle,
			// Token: 0x0403ACCB RID: 240843
			SkinQualitySprite,
			// Token: 0x0403ACCC RID: 240844
			UnderTextAdditionItem
		}
	}
}
