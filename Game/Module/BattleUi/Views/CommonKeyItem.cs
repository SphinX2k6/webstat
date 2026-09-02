using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02006047 RID: 24647
	public class CommonKeyItem : KeyItemBase
	{
		// Token: 0x0603E2C3 RID: 254659 RVA: 0x00FDFFC4 File Offset: 0x00FDE1C4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 1;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int index = 0;
			*span[index] = new ValueTuple<int, Type>(0, typeof(UUITexture));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603E2C4 RID: 254660 RVA: 0x00FE000C File Offset: 0x00FDE20C
		[NullableContext(2)]
		protected override UUIText GetKeyText()
		{
			return null;
		}

		// Token: 0x0603E2C5 RID: 254661 RVA: 0x00FE000F File Offset: 0x00FDE20F
		[NullableContext(2)]
		protected override UUITexture GetKeyTexture()
		{
			return base.GetTexture(0);
		}

		// Token: 0x0603E2C6 RID: 254662 RVA: 0x00FE0018 File Offset: 0x00FDE218
		protected override void OnSetGray()
		{
			UUITexture keyTexture = this.GetKeyTexture();
			UUIItem uuiitem = keyTexture;
			bool isGray = this.IsGray;
			FColor? fcolor = new FColor?(keyTexture.changeColor);
			uuiitem.SetChangeColor(isGray, fcolor);
		}

		// Token: 0x0200C108 RID: 49416
		private enum EChildType
		{
			// Token: 0x0403B717 RID: 243479
			KeyTexture
		}
	}
}
