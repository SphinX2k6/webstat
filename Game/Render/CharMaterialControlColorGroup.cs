using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Render
{
	// Token: 0x0200475C RID: 18268
	[NullableContext(2)]
	[Nullable(0)]
	public class CharMaterialControlColorGroup
	{
		// Token: 0x0602F696 RID: 194198 RVA: 0x00B426BC File Offset: 0x00B408BC
		[NullableContext(1)]
		public CharMaterialControlColorGroup(FKuroCurveLinearColor end, FKuroCurveLinearColor loop, FKuroCurveLinearColor start)
		{
			if (end.bUseCurve)
			{
				this.End = end;
			}
			else
			{
				this.EndConstant = new FLinearColor?(end.Constant);
			}
			if (loop.bUseCurve)
			{
				this.Loop = loop;
			}
			else
			{
				this.LoopConstant = new FLinearColor?(loop.Constant);
			}
			if (start.bUseCurve)
			{
				this.Start = start;
				return;
			}
			this.StartConstant = new FLinearColor?(start.Constant);
		}

		// Token: 0x0401AFFF RID: 110591
		public FKuroCurveLinearColor End;

		// Token: 0x0401B000 RID: 110592
		public FKuroCurveLinearColor Loop;

		// Token: 0x0401B001 RID: 110593
		public FKuroCurveLinearColor Start;

		// Token: 0x0401B002 RID: 110594
		public FLinearColor? EndConstant;

		// Token: 0x0401B003 RID: 110595
		public FLinearColor? LoopConstant;

		// Token: 0x0401B004 RID: 110596
		public FLinearColor? StartConstant;
	}
}
