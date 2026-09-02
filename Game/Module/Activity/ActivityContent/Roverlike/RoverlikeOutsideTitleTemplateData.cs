using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x020063EC RID: 25580
	[NullableContext(1)]
	[Nullable(0)]
	public class RoverlikeOutsideTitleTemplateData : IMultiTemplateGridData<RoverlikeOutsideTitleData, RoverlikeOutsideTitleItem>, IMultiTemplateGridData
	{
		// Token: 0x17009DCA RID: 40394
		// (get) Token: 0x060403A1 RID: 263073 RVA: 0x010759EB File Offset: 0x01073BEB
		// (set) Token: 0x060403A2 RID: 263074 RVA: 0x010759F3 File Offset: 0x01073BF3
		public RoverlikeOutsideTitleData Data { get; set; }

		// Token: 0x17009DCB RID: 40395
		// (get) Token: 0x060403A3 RID: 263075 RVA: 0x010759FC File Offset: 0x01073BFC
		object IMultiTemplateGridData.Data
		{
			get
			{
				return this.Data;
			}
		}

		// Token: 0x060403A4 RID: 263076 RVA: 0x01075A04 File Offset: 0x01073C04
		public int GetTemplateIndex()
		{
			return 0;
		}

		// Token: 0x060403A5 RID: 263077 RVA: 0x01075A07 File Offset: 0x01073C07
		public RoverlikeOutsideTitleItem CreateProxy()
		{
			return new RoverlikeOutsideTitleItem();
		}

		// Token: 0x060403A6 RID: 263078 RVA: 0x01075A0E File Offset: 0x01073C0E
		ISyncGridProxy IMultiTemplateGridData.CreateProxy()
		{
			return this.CreateProxy();
		}
	}
}
