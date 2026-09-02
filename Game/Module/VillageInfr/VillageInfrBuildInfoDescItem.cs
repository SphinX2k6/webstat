using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.VillageInfr
{
	// Token: 0x02004C09 RID: 19465
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class VillageInfrBuildInfoDescItem : GridProxyAbstract<string>
	{
		// Token: 0x06032CA2 RID: 208034 RVA: 0x00CB9685 File Offset: 0x00CB7885
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText))
			};
		}

		// Token: 0x06032CA3 RID: 208035 RVA: 0x00CB96A8 File Offset: 0x00CB78A8
		public override void Refresh(string data, bool isSelected, int gridIndex)
		{
			base.GetText(0).ShowTextNew(data);
		}
	}
}
