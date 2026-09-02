using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Tetris
{
	// Token: 0x020062E8 RID: 25320
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	internal class TetrisTipsTargetGrid : GridProxyAbstract<ITetrisTargetData>
	{
		// Token: 0x0603FAA7 RID: 260775 RVA: 0x010529B7 File Offset: 0x01050BB7
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUISprite)),
				new ValueTuple<int, Type>(1, typeof(UUIText))
			};
		}

		// Token: 0x0603FAA8 RID: 260776 RVA: 0x010529F0 File Offset: 0x01050BF0
		public override void Refresh(ITetrisTargetData data, bool isSelected, int gridIndex)
		{
			this.SetSpriteByPath(data.Icon, base.GetSprite(0), false, null, null);
			base.GetText(1).SetText(data.Num.ToString(), true);
		}
	}
}
