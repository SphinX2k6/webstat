using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.DollGrabMachine.View
{
	// Token: 0x02006F04 RID: 28420
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1,
		1
	})]
	public class DollDescriptionItemTemplateData : MultiTemplateGridDataBase<IDollDescriptionItemData, DollDescriptionItem>
	{
		// Token: 0x06044DA8 RID: 282024 RVA: 0x011EA76E File Offset: 0x011E896E
		public override int GetTemplateIndex()
		{
			return 1;
		}

		// Token: 0x06044DA9 RID: 282025 RVA: 0x011EA771 File Offset: 0x011E8971
		public override DollDescriptionItem CreateProxy()
		{
			return new DollDescriptionItem();
		}
	}
}
