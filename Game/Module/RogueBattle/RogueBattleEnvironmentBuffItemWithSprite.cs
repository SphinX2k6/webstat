using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.RogueBattle
{
	// Token: 0x020051CD RID: 20941
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RogueBattleEnvironmentBuffItemWithSprite : GridProxyAbstract<IRogueBattleEnvironmentInfo>
	{
		// Token: 0x06035D15 RID: 220437 RVA: 0x00D8A2AB File Offset: 0x00D884AB
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUISprite)),
				new ValueTuple<int, Type>(1, typeof(UUIText))
			};
		}

		// Token: 0x06035D16 RID: 220438 RVA: 0x00D8A2E4 File Offset: 0x00D884E4
		public override void Refresh(IRogueBattleEnvironmentInfo data, bool isSelected, int gridIndex)
		{
			this.SetSpriteByPath(data.Icon, base.GetSprite(0), false, null, null);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), data.TextId, data.Param);
		}
	}
}
