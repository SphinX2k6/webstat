using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Kurotato.Data;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Kurotato.View.EnemyDetailBook
{
	// Token: 0x02005ABE RID: 23230
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class KurotatoEnemyBasePropertyItem : GridProxyAbstract<KurotatoEnemyBasePropertyData>
	{
		// Token: 0x0603ABC9 RID: 240585 RVA: 0x00EE41D4 File Offset: 0x00EE23D4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603ABCA RID: 240586 RVA: 0x00EE4260 File Offset: 0x00EE2460
		[NullableContext(1)]
		public override void Refresh(KurotatoEnemyBasePropertyData data, bool isSelected, int gridIndex)
		{
			base.SetTextureByPath(data.IconPath, base.GetTexture(0), null, null);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), data.Name, Array.Empty<object>());
			base.GetText(2).SetText(data.Value.ToString(), true);
		}

		// Token: 0x0200BAD2 RID: 47826
		private class EBasePropertyComponent
		{
			// Token: 0x04039AB4 RID: 236212
			public const int TexIcon = 0;

			// Token: 0x04039AB5 RID: 236213
			public const int TextTitle = 1;

			// Token: 0x04039AB6 RID: 236214
			public const int TextValue = 2;
		}
	}
}
