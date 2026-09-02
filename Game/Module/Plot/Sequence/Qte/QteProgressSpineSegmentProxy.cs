using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Plot.Sequence.Qte
{
	// Token: 0x02005393 RID: 21395
	[NullableContext(1)]
	[Nullable(0)]
	public class QteProgressSpineSegmentProxy
	{
		// Token: 0x060368E7 RID: 223463 RVA: 0x00DCA9AA File Offset: 0x00DC8BAA
		public static QteProgressSpineSegmentProxy CreateLegacyProgressSegment(List<SpineDataProxy> spines)
		{
			return new QteProgressSpineSegmentProxy
			{
				Spines = spines
			};
		}

		// Token: 0x060368E8 RID: 223464 RVA: 0x00DCA9B8 File Offset: 0x00DC8BB8
		public bool IsActive(float qteProgress)
		{
			if (Singleton<MathUtils>.Instance.IsNearlyEqual((double)this.QteStartProgress, (double)this.QteEndProgress, null))
			{
				return Singleton<MathUtils>.Instance.IsNearlyEqual((double)qteProgress, (double)this.QteEndProgress, null);
			}
			float rangePct = Singleton<MathUtils>.Instance.GetRangePct(this.QteStartProgress, this.QteEndProgress, qteProgress);
			return rangePct > 0f && rangePct <= 1f;
		}

		// Token: 0x060368E9 RID: 223465 RVA: 0x00DCAA34 File Offset: 0x00DC8C34
		public float GetSpineProgress(float qteProgress)
		{
			if (Singleton<MathUtils>.Instance.IsNearlyEqual((double)this.QteStartProgress, (double)this.QteEndProgress, null))
			{
				return this.SpineEndProgress;
			}
			return Singleton<MathUtils>.Instance.RangeClamp(qteProgress, this.QteStartProgress, this.QteEndProgress, this.SpineStartProgress, this.SpineEndProgress);
		}

		// Token: 0x0401F6E2 RID: 128738
		public List<SpineDataProxy> Spines = new List<SpineDataProxy>();

		// Token: 0x0401F6E3 RID: 128739
		public float QteStartProgress;

		// Token: 0x0401F6E4 RID: 128740
		public float QteEndProgress = 1f;

		// Token: 0x0401F6E5 RID: 128741
		public float SpineStartProgress;

		// Token: 0x0401F6E6 RID: 128742
		public float SpineEndProgress = 1f;

		// Token: 0x0401F6E7 RID: 128743
		public float BlendInTime = 0.5f;

		// Token: 0x0401F6E8 RID: 128744
		public float BlendOutTime;
	}
}
