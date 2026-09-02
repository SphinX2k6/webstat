using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.InstanceDungeon.InstanceDungeonSubComponent
{
	// Token: 0x02005BED RID: 23533
	public class InstanceDungeonPicItem : UiPanelBase
	{
		// Token: 0x0603B91B RID: 243995 RVA: 0x00F19BB4 File Offset: 0x00F17DB4
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

		// Token: 0x0603B91C RID: 243996 RVA: 0x00F19BFC File Offset: 0x00F17DFC
		[NullableContext(2)]
		public void RefreshItem(string picPath)
		{
			base.TrySetTextureByPath(picPath, base.GetTexture(0), null, null);
		}

		// Token: 0x0200BC65 RID: 48229
		private enum EComponent
		{
			// Token: 0x0403A17D RID: 237949
			PicTexture
		}
	}
}
