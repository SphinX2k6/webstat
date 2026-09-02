using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Cook.View
{
	// Token: 0x02005E15 RID: 24085
	public class IconItem : UiPanelBase
	{
		// Token: 0x0603C9A0 RID: 248224 RVA: 0x00F637FA File Offset: 0x00F619FA
		[NullableContext(1)]
		public IconItem(UUIItem uiItem)
		{
			base.CreateThenShowByActor(uiItem.GetOwner(), null);
		}

		// Token: 0x0603C9A1 RID: 248225 RVA: 0x00F63810 File Offset: 0x00F61A10
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUISprite));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603C9A2 RID: 248226 RVA: 0x00F6387C File Offset: 0x00F61A7C
		public void SetIcon(int itemId)
		{
			base.SetItemIcon(base.GetTexture(3), itemId, null, null);
		}

		// Token: 0x0603C9A3 RID: 248227 RVA: 0x00F638A4 File Offset: 0x00F61AA4
		public void SetQuality(int itemId)
		{
			base.SetItemQualityIcon(base.GetSprite(4), itemId, null, CommonDefine.EQualityIconType.BackgroundSprite, null);
		}

		// Token: 0x0200BE4C RID: 48716
		private enum EIconItemDefine
		{
			// Token: 0x0403A964 RID: 239972
			IconTexture = 3,
			// Token: 0x0403A965 RID: 239973
			QualitySprite
		}
	}
}
