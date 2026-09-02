using System;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.Define.SimpleTabel;

namespace CSharpScript.Launcher.Update.ResourceDiffUpdate.Config
{
	// Token: 0x020044F5 RID: 17653
	[NullableContext(1)]
	[Nullable(0)]
	public class RoleVoiceLanguageTableRow : TableBaseRow
	{
		// Token: 0x0602E873 RID: 190579 RVA: 0x00B06583 File Offset: 0x00B04783
		public override object GetId()
		{
			return this.LanguageId;
		}

		// Token: 0x0401A6F6 RID: 108278
		public int LanguageId;

		// Token: 0x0401A6F7 RID: 108279
		public string Text = "";
	}
}
