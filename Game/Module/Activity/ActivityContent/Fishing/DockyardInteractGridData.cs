using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x020067AC RID: 26540
	[NullableContext(1)]
	[Nullable(0)]
	public class DockyardInteractGridData
	{
		// Token: 0x1700A0FE RID: 41214
		// (get) Token: 0x060422F0 RID: 271088 RVA: 0x010FA079 File Offset: 0x010F8279
		public int TargetId
		{
			get
			{
				return this.TargetIdInternal;
			}
		}

		// Token: 0x060422F1 RID: 271089 RVA: 0x010FA081 File Offset: 0x010F8281
		public DockyardInteractGridData(IPanelPos posData)
		{
			this.PosData = posData;
			this.TargetIdInternal = -1;
			this.IsFinish = false;
		}

		// Token: 0x060422F2 RID: 271090 RVA: 0x010FA09E File Offset: 0x010F829E
		public void SetTargetId(int id)
		{
			this.TargetIdInternal = id;
		}

		// Token: 0x04024DE3 RID: 151011
		private int TargetIdInternal;

		// Token: 0x04024DE4 RID: 151012
		public bool IsFinish;

		// Token: 0x04024DE5 RID: 151013
		protected readonly IPanelPos PosData;
	}
}
