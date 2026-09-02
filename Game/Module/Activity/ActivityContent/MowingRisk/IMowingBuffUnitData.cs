using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MowingRisk
{
	// Token: 0x02006678 RID: 26232
	[NullableContext(1)]
	public interface IMowingBuffUnitData
	{
		// Token: 0x17009F9B RID: 40859
		// (get) Token: 0x06041843 RID: 268355
		// (set) Token: 0x06041844 RID: 268356
		int Index { get; set; }

		// Token: 0x17009F9C RID: 40860
		// (get) Token: 0x06041845 RID: 268357
		// (set) Token: 0x06041846 RID: 268358
		int BuffId { get; set; }

		// Token: 0x17009F9D RID: 40861
		// (get) Token: 0x06041847 RID: 268359
		// (set) Token: 0x06041848 RID: 268360
		bool IsActive { get; set; }

		// Token: 0x17009F9E RID: 40862
		// (get) Token: 0x06041849 RID: 268361
		// (set) Token: 0x0604184A RID: 268362
		bool IsChosen { get; set; }

		// Token: 0x17009F9F RID: 40863
		// (get) Token: 0x0604184B RID: 268363
		// (set) Token: 0x0604184C RID: 268364
		string IconPath { get; set; }

		// Token: 0x17009FA0 RID: 40864
		// (get) Token: 0x0604184D RID: 268365
		// (set) Token: 0x0604184E RID: 268366
		string NameTextId { get; set; }

		// Token: 0x17009FA1 RID: 40865
		// (get) Token: 0x0604184F RID: 268367
		// (set) Token: 0x06041850 RID: 268368
		int ThresholdCount { get; set; }
	}
}
