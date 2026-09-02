using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Render
{
	// Token: 0x0200475B RID: 18267
	[NullableContext(2)]
	[Nullable(0)]
	public class CharMaterialControlFloatGroup
	{
		// Token: 0x0602F695 RID: 194197 RVA: 0x00B42644 File Offset: 0x00B40844
		[NullableContext(1)]
		public CharMaterialControlFloatGroup(FKuroCurveFloat end, FKuroCurveFloat loop, FKuroCurveFloat start)
		{
			if (end.bUseCurve)
			{
				this.End = end;
			}
			else
			{
				this.EndConstant = new float?(end.Constant);
			}
			if (loop.bUseCurve)
			{
				this.Loop = loop;
			}
			else
			{
				this.LoopConstant = new float?(loop.Constant);
			}
			if (start.bUseCurve)
			{
				this.Start = start;
				return;
			}
			this.StartConstant = new float?(start.Constant);
		}

		// Token: 0x0401AFF9 RID: 110585
		public FKuroCurveFloat End;

		// Token: 0x0401AFFA RID: 110586
		public FKuroCurveFloat Loop;

		// Token: 0x0401AFFB RID: 110587
		public FKuroCurveFloat Start;

		// Token: 0x0401AFFC RID: 110588
		public float? EndConstant;

		// Token: 0x0401AFFD RID: 110589
		public float? LoopConstant;

		// Token: 0x0401AFFE RID: 110590
		public float? StartConstant;
	}
}
