using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.MapRogue
{
	// Token: 0x02005961 RID: 22881
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RewardItem : GridProxyAbstract<ChangeItemInfoData>
	{
		// Token: 0x06039FDD RID: 237533 RVA: 0x00EACF00 File Offset: 0x00EAB100
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUITexture)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUIText))
			};
		}

		// Token: 0x06039FDE RID: 237534 RVA: 0x00EACF5A File Offset: 0x00EAB15A
		public override void Refresh(ChangeItemInfoData data, bool isSelected, int gridIndex)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), data.TitleId, Array.Empty<object>());
			base.GetText(2).SetText(data.Value, true);
		}
	}
}
