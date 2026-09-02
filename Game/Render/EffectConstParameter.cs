using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Render
{
	// Token: 0x0200476D RID: 18285
	[NullableContext(1)]
	[Nullable(0)]
	public class EffectConstParameter
	{
		// Token: 0x0602F723 RID: 194339 RVA: 0x00B47143 File Offset: 0x00B45343
		public EffectConstParameter(FName name, object value)
		{
			this.Name = name;
			this.Value = value;
		}

		// Token: 0x0401B199 RID: 111001
		public FName Name;

		// Token: 0x0401B19A RID: 111002
		public object Value;
	}
}
