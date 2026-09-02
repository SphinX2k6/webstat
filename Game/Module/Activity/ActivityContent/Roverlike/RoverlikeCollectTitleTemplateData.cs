using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x020063E6 RID: 25574
	[NullableContext(1)]
	[Nullable(0)]
	public class RoverlikeCollectTitleTemplateData : IMultiTemplateGridData<IRoverlikeCollectTitleData, RoverlikeCollectTitleItem>, IMultiTemplateGridData
	{
		// Token: 0x17009DC5 RID: 40389
		// (get) Token: 0x0604037D RID: 263037 RVA: 0x0107531F File Offset: 0x0107351F
		// (set) Token: 0x0604037E RID: 263038 RVA: 0x01075327 File Offset: 0x01073527
		public IRoverlikeCollectTitleData Data { get; set; }

		// Token: 0x17009DC6 RID: 40390
		// (get) Token: 0x0604037F RID: 263039 RVA: 0x01075330 File Offset: 0x01073530
		object IMultiTemplateGridData.Data
		{
			get
			{
				return this.Data;
			}
		}

		// Token: 0x06040380 RID: 263040 RVA: 0x01075338 File Offset: 0x01073538
		public int GetTemplateIndex()
		{
			return 0;
		}

		// Token: 0x06040381 RID: 263041 RVA: 0x0107533B File Offset: 0x0107353B
		public RoverlikeCollectTitleItem CreateProxy()
		{
			return new RoverlikeCollectTitleItem();
		}

		// Token: 0x06040382 RID: 263042 RVA: 0x01075342 File Offset: 0x01073542
		ISyncGridProxy IMultiTemplateGridData.CreateProxy()
		{
			return this.CreateProxy();
		}

		// Token: 0x0402402A RID: 147498
		private const int ROVERLIKE_COLLECT_TITLE_TEMPLATE_INDEX = 0;
	}
}
