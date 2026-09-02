using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Render
{
	// Token: 0x0200476E RID: 18286
	[NullableContext(1)]
	[Nullable(0)]
	public class EffectCurveParameter
	{
		// Token: 0x0602F724 RID: 194340 RVA: 0x00B47159 File Offset: 0x00B45359
		public EffectCurveParameter(FName name, object parameter)
		{
			this.Name = name;
			this.Value = parameter;
		}

		// Token: 0x0401B19B RID: 111003
		public FName Name;

		// Token: 0x0401B19C RID: 111004
		public object Value;
	}
}
