using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.RogueBattle
{
	// Token: 0x020051CB RID: 20939
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RogueBattleEnvironmentBuffItemWithTexture : GridProxyAbstract<IRogueBattleEnvironmentInfo>
	{
		// Token: 0x06035D12 RID: 220434 RVA: 0x00D8A220 File Offset: 0x00D88420
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUITexture)),
				new ValueTuple<int, Type>(1, typeof(UUIText))
			};
		}

		// Token: 0x06035D13 RID: 220435 RVA: 0x00D8A25C File Offset: 0x00D8845C
		public override void Refresh(IRogueBattleEnvironmentInfo data, bool isSelected, int gridIndex)
		{
			base.SetTextureByPath(data.Icon, base.GetTexture(0), null, null);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), data.TextId, data.Param);
		}
	}
}
