using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.DollGrabMachine.View
{
	// Token: 0x02006F05 RID: 28421
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1,
		1
	})]
	public class DollPlayDescriptionItemTemplateData : MultiTemplateGridDataBase<IDollDescriptionItemData, DollPlayDescriptionItem>
	{
		// Token: 0x06044DAB RID: 282027 RVA: 0x011EA780 File Offset: 0x011E8980
		public override int GetTemplateIndex()
		{
			return 0;
		}

		// Token: 0x06044DAC RID: 282028 RVA: 0x011EA783 File Offset: 0x011E8983
		public override DollPlayDescriptionItem CreateProxy()
		{
			return new DollPlayDescriptionItem();
		}
	}
}
