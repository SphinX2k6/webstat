using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Morale
{
	// Token: 0x0200570E RID: 22286
	[NullableContext(2)]
	[Nullable(0)]
	public class MoraleBuffAddTipsParams
	{
		// Token: 0x0402053B RID: 132411
		public UUIItem ItemForLocation;

		// Token: 0x0402053C RID: 132412
		public string TitleKey;

		// Token: 0x0402053D RID: 132413
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public List<IMoraleBuffAddItemData> DataList;
	}
}
