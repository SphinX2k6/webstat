using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Map.MapDefine
{
	// Token: 0x020058E8 RID: 22760
	[NullableContext(1)]
	[Nullable(0)]
	public class TTrackTarget_AActor : TTrackTarget
	{
		// Token: 0x06039C29 RID: 236585 RVA: 0x00EA0902 File Offset: 0x00E9EB02
		public TTrackTarget_AActor(AActor Value)
		{
		}

		// Token: 0x06039C2A RID: 236586 RVA: 0x00EA0911 File Offset: 0x00E9EB11
		public static implicit operator AActor(TTrackTarget_AActor target)
		{
			return target.Value;
		}

		// Token: 0x06039C2B RID: 236587 RVA: 0x00EA0919 File Offset: 0x00E9EB19
		public new static implicit operator TTrackTarget_AActor(AActor value)
		{
			return new TTrackTarget_AActor(value);
		}

		// Token: 0x04020C02 RID: 134146
		public AActor Value = Value;
	}
}
