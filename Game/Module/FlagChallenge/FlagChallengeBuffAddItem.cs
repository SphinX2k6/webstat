using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.FlagChallenge
{
	// Token: 0x02005D56 RID: 23894
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class FlagChallengeBuffAddItem : GridProxyAbstract<FlagChallengeBuffAddItemData>
	{
		// Token: 0x0603C385 RID: 246661 RVA: 0x00F46688 File Offset: 0x00F44888
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUITexture)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUIText))
			};
		}

		// Token: 0x0603C386 RID: 246662 RVA: 0x00F466E4 File Offset: 0x00F448E4
		public override void Refresh(FlagChallengeBuffAddItemData data, bool isSelected, int gridIndex)
		{
			this.ItemData = data;
			UUITexture texture = base.GetTexture(0);
			base.SetTextureByPath(data.IconPath, texture, null, null);
			base.GetText(1).ShowTextNew(data.NameKey);
			base.GetText(2).SetText(data.Value, true);
		}

		// Token: 0x04021D3A RID: 138554
		public FlagChallengeBuffAddItemData ItemData;
	}
}
