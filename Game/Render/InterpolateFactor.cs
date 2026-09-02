using System;

namespace CSharpScript.Game.Render
{
	// Token: 0x0200475A RID: 18266
	public class InterpolateFactor
	{
		// Token: 0x1700819D RID: 33181
		// (get) Token: 0x0602F692 RID: 194194 RVA: 0x00B42620 File Offset: 0x00B40820
		// (set) Token: 0x0602F693 RID: 194195 RVA: 0x00B42628 File Offset: 0x00B40828
		public EInterpolateRangeType Type
		{
			get
			{
				return this.TypeInternal;
			}
			set
			{
				if (this.TypeInternal != value)
				{
					this.TypeInternal = value;
				}
			}
		}

		// Token: 0x0401AFF7 RID: 110583
		private EInterpolateRangeType TypeInternal;

		// Token: 0x0401AFF8 RID: 110584
		public float Factor;
	}
}
