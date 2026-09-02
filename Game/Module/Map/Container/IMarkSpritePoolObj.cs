using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Map.Container
{
	// Token: 0x020058F0 RID: 22768
	[NullableContext(1)]
	public interface IMarkSpritePoolObj
	{
		// Token: 0x170093B9 RID: 37817
		// (get) Token: 0x06039C94 RID: 236692
		// (set) Token: 0x06039C95 RID: 236693
		string SpritePath { get; set; }

		// Token: 0x170093BA RID: 37818
		// (get) Token: 0x06039C96 RID: 236694
		// (set) Token: 0x06039C97 RID: 236695
		double RecycleTimeStamp { get; set; }

		// Token: 0x170093BB RID: 37819
		// (get) Token: 0x06039C98 RID: 236696
		// (set) Token: 0x06039C99 RID: 236697
		ULGUISpriteData_BaseObject Obj { get; set; }

		// Token: 0x170093BC RID: 37820
		// (get) Token: 0x06039C9A RID: 236698
		// (set) Token: 0x06039C9B RID: 236699
		int Ref { get; set; }
	}
}
