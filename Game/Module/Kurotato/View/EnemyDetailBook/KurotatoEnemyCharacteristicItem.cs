using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Kurotato.Data;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Kurotato.View.EnemyDetailBook
{
	// Token: 0x02005ABF RID: 23231
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class KurotatoEnemyCharacteristicItem : GridProxyAbstract<KurotatoEnemyCharacteristicData>
	{
		// Token: 0x0603ABCC RID: 240588 RVA: 0x00EE42CC File Offset: 0x00EE24CC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603ABCD RID: 240589 RVA: 0x00EE4358 File Offset: 0x00EE2558
		[NullableContext(1)]
		public override void Refresh(KurotatoEnemyCharacteristicData data, bool isSelected, int gridIndex)
		{
			this.SetSpriteByPath(data.IconPath, base.GetSprite(0), false, null, null);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), data.Name, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), data.Desc, Array.Empty<object>());
		}

		// Token: 0x0200BAD3 RID: 47827
		private class ECharacteristicComponent
		{
			// Token: 0x04039AB7 RID: 236215
			public const int SpriteIcon = 0;

			// Token: 0x04039AB8 RID: 236216
			public const int TextTitle = 1;

			// Token: 0x04039AB9 RID: 236217
			public const int TextDesc = 2;
		}
	}
}
