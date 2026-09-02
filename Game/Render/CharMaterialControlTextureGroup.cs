using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Render
{
	// Token: 0x0200475D RID: 18269
	[NullableContext(2)]
	[Nullable(0)]
	public class CharMaterialControlTextureGroup
	{
		// Token: 0x0602F697 RID: 194199 RVA: 0x00B42734 File Offset: 0x00B40934
		public CharMaterialControlTextureGroup(UTexture2D end, UTexture2D loop, UTexture2D start)
		{
			this.End = end;
			this.Loop = loop;
			this.Start = start;
		}

		// Token: 0x0401B005 RID: 110597
		public UTexture2D End;

		// Token: 0x0401B006 RID: 110598
		public UTexture2D Loop;

		// Token: 0x0401B007 RID: 110599
		public UTexture2D Start;
	}
}
