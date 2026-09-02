using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Role
{
	// Token: 0x020065D0 RID: 26064
	public class PinballRoleClassIconItem : UiPanelBase
	{
		// Token: 0x060411E8 RID: 266728 RVA: 0x010B52D8 File Offset: 0x010B34D8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x060411E9 RID: 266729 RVA: 0x010B5344 File Offset: 0x010B3544
		[NullableContext(1)]
		public void Refresh(IPinballRoleClassIconItemData data)
		{
			base.GetSprite(0).SetColor(FColor.FromHex(data.BgColor));
			base.SetTextureByPath(data.IconPath, base.GetTexture(1), null, null);
		}

		// Token: 0x0200C5D2 RID: 50642
		private enum EComponent
		{
			// Token: 0x0403CE43 RID: 249411
			BgSprite,
			// Token: 0x0403CE44 RID: 249412
			ClassIconTexture
		}
	}
}
