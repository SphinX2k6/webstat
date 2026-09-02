using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x0200642F RID: 25647
	public class RoverlikeLootElementIcon : UiPanelBase
	{
		// Token: 0x0604063E RID: 263742 RVA: 0x01081D80 File Offset: 0x0107FF80
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
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0604063F RID: 263743 RVA: 0x01081E0C File Offset: 0x0108000C
		[NullableContext(1)]
		public void Refresh(string elementIcon)
		{
			UUITexture texture = base.GetTexture(1);
			base.SetTextureByPath(elementIcon, texture, null, null);
		}

		// Token: 0x0200C4A0 RID: 50336
		private class ERoverlikeLootElementIcon
		{
			// Token: 0x0403C85B RID: 247899
			public const int SprElementBg = 0;

			// Token: 0x0403C85C RID: 247900
			public const int TxtElementIcon = 1;

			// Token: 0x0403C85D RID: 247901
			public const int PnlItem = 2;
		}
	}
}
