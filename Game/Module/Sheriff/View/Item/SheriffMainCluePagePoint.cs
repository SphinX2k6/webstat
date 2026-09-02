using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Sheriff.View.Item
{
	// Token: 0x02004FE5 RID: 20453
	public class SheriffMainCluePagePoint : GridProxyAbstract<bool>
	{
		// Token: 0x06034BC6 RID: 216006 RVA: 0x00D3AE94 File Offset: 0x00D39094
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06034BC7 RID: 216007 RVA: 0x00D3AEFD File Offset: 0x00D390FD
		public override void Refresh(bool data, bool isSelected, int gridIndex)
		{
			base.GetSprite(1).SetUIActive(data);
			base.GetSprite(0).SetUIActive(!data);
		}

		// Token: 0x0200AFC0 RID: 44992
		private static class EPagePoint
		{
			// Token: 0x04036893 RID: 223379
			public const int SpriteBg = 0;

			// Token: 0x04036894 RID: 223380
			public const int SpriteSelect = 1;
		}
	}
}
