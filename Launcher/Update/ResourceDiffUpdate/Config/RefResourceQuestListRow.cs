using System;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.Define.SimpleTabel;

namespace CSharpScript.Launcher.Update.ResourceDiffUpdate.Config
{
	// Token: 0x020044F1 RID: 17649
	public class RefResourceQuestListRow : TableBaseRow
	{
		// Token: 0x0602E865 RID: 190565 RVA: 0x00B0635B File Offset: 0x00B0455B
		[NullableContext(1)]
		public override object GetId()
		{
			return this.BitId;
		}

		// Token: 0x0401A6EE RID: 108270
		public int BitId;

		// Token: 0x0401A6EF RID: 108271
		public int QuestId;

		// Token: 0x0401A6F0 RID: 108272
		public int HasRefResource;
	}
}
