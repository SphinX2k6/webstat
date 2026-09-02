using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Map.View.BaseMap.Assistant
{
	// Token: 0x020057F4 RID: 22516
	public class MapRoadWayView : UiPanelBase
	{
		// Token: 0x06039479 RID: 234617 RVA: 0x00E88F2C File Offset: 0x00E8712C
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

		// Token: 0x0603947A RID: 234618 RVA: 0x00E88F74 File Offset: 0x00E87174
		[NullableContext(1)]
		public void SetTexture(string path)
		{
			UUITexture texture = base.GetTexture(0);
			base.TrySetTextureByPath(path, texture, null, delegate(bool success)
			{
				UUITexture texture = texture;
				if (texture == null)
				{
					return;
				}
				texture.SetSizeFromTexture();
			});
		}

		// Token: 0x0200B882 RID: 47234
		public static class EComponents
		{
			// Token: 0x040390F5 RID: 233717
			public const int RoadWayTexture = 0;
		}
	}
}
