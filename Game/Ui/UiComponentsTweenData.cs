using System;

namespace CSharpScript.Game.Ui
{
	// Token: 0x020049AA RID: 18858
	internal class UiComponentsTweenData
	{
		// Token: 0x060313D1 RID: 201681 RVA: 0x00C42AC4 File Offset: 0x00C40CC4
		public UiComponentsTweenData(float alpha, float size, float time)
		{
			this.TargetAlpha = alpha;
			this.TargetSize = size;
			this.Time = time;
		}

		// Token: 0x0401C53E RID: 116030
		public float TargetAlpha;

		// Token: 0x0401C53F RID: 116031
		public float TargetSize;

		// Token: 0x0401C540 RID: 116032
		public float Time;
	}
}
