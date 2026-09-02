using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x020067BE RID: 26558
	[NullableContext(1)]
	[Nullable(0)]
	public class DockyardViewModel : DockyardViewModelBase
	{
		// Token: 0x1700A10E RID: 41230
		// (get) Token: 0x06042422 RID: 271394 RVA: 0x010FF49E File Offset: 0x010FD69E
		public virtual DockyardTrawlBackpackPanelModel BackpackPanelModel { [PreserveBaseOverrides] get; } = new DockyardTrawlBackpackPanelModel();

		// Token: 0x1700A10F RID: 41231
		// (get) Token: 0x06042423 RID: 271395 RVA: 0x010FF4A6 File Offset: 0x010FD6A6
		public virtual DockyardTrawlListPanelModel ListPanelModel { [PreserveBaseOverrides] get; } = new DockyardTrawlListPanelModel();
	}
}
