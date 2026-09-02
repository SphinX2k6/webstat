using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x020063FD RID: 25597
	[NullableContext(1)]
	[Nullable(0)]
	public class RoverlikeEntryGridItemTemplateData : IMultiTemplateGridData<RoverlikeGainEntry, RoverlikeEntryGridItem>, IMultiTemplateGridData
	{
		// Token: 0x17009DD2 RID: 40402
		// (get) Token: 0x06040450 RID: 263248 RVA: 0x01078CA0 File Offset: 0x01076EA0
		// (set) Token: 0x06040451 RID: 263249 RVA: 0x01078CA8 File Offset: 0x01076EA8
		public RoverlikeGainEntry Data { get; set; }

		// Token: 0x17009DD3 RID: 40403
		// (get) Token: 0x06040452 RID: 263250 RVA: 0x01078CB1 File Offset: 0x01076EB1
		object IMultiTemplateGridData.Data
		{
			get
			{
				return this.Data;
			}
		}

		// Token: 0x06040453 RID: 263251 RVA: 0x01078CB9 File Offset: 0x01076EB9
		public int GetTemplateIndex()
		{
			return 1;
		}

		// Token: 0x06040454 RID: 263252 RVA: 0x01078CBC File Offset: 0x01076EBC
		public RoverlikeEntryGridItem CreateProxy()
		{
			return new RoverlikeEntryGridItem
			{
				OnClickCb = this.OnClickCb,
				IsGridSelected = this.IsSelected,
				GetSlotId = this.GetSlotId
			};
		}

		// Token: 0x06040455 RID: 263253 RVA: 0x01078CE7 File Offset: 0x01076EE7
		ISyncGridProxy IMultiTemplateGridData.CreateProxy()
		{
			return this.CreateProxy();
		}

		// Token: 0x04024081 RID: 147585
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Action<RoverlikeGainEntry, int> OnClickCb;

		// Token: 0x04024082 RID: 147586
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Func<RoverlikeGainEntry, int, bool> IsSelected;

		// Token: 0x04024083 RID: 147587
		[Nullable(2)]
		public Func<int, int> GetSlotId;

		// Token: 0x04024084 RID: 147588
		private const int ROVERLIKE_COLLECT_GRID_TEMPLATE_INDEX = 1;
	}
}
