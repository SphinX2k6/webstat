using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.SkipInterface.SkipTask
{
	// Token: 0x02004F2B RID: 20267
	public class SkipTaskHelp : SkipTask
	{
		// Token: 0x060345B5 RID: 214453 RVA: 0x00D1A620 File Offset: 0x00D18820
		protected override void OnRun([Nullable(new byte[]
		{
			1,
			2
		})] params object[] data)
		{
			string text = data[0] as string;
			int helpGroupId;
			if (text != null)
			{
				helpGroupId = int.Parse(text);
			}
			else
			{
				helpGroupId = (int)data[0];
			}
			ControllerBase<HelpController>.Instance.OpenHelpById(helpGroupId);
			base.Finish();
		}
	}
}
