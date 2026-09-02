using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x020063E4 RID: 25572
	[NullableContext(1)]
	[Nullable(0)]
	public class RoverlikeCollectEmptyItemTemplateData : IMultiTemplateGridData<IRoverlikeCollectEmptyData, RoverlikeCollectEmptyItem>, IMultiTemplateGridData
	{
		// Token: 0x17009DC3 RID: 40387
		// (get) Token: 0x06040373 RID: 263027 RVA: 0x0107526F File Offset: 0x0107346F
		// (set) Token: 0x06040374 RID: 263028 RVA: 0x01075277 File Offset: 0x01073477
		public IRoverlikeCollectEmptyData Data { get; set; }

		// Token: 0x17009DC4 RID: 40388
		// (get) Token: 0x06040375 RID: 263029 RVA: 0x01075280 File Offset: 0x01073480
		object IMultiTemplateGridData.Data
		{
			get
			{
				return this.Data;
			}
		}

		// Token: 0x06040376 RID: 263030 RVA: 0x01075288 File Offset: 0x01073488
		public int GetTemplateIndex()
		{
			return 2;
		}

		// Token: 0x06040377 RID: 263031 RVA: 0x0107528B File Offset: 0x0107348B
		public RoverlikeCollectEmptyItem CreateProxy()
		{
			return new RoverlikeCollectEmptyItem();
		}

		// Token: 0x06040378 RID: 263032 RVA: 0x01075292 File Offset: 0x01073492
		ISyncGridProxy IMultiTemplateGridData.CreateProxy()
		{
			return this.CreateProxy();
		}

		// Token: 0x04024028 RID: 147496
		private const int ROVERLIKE_COLLECT_EMPTY_TEMPLATE_INDEX = 2;
	}
}
