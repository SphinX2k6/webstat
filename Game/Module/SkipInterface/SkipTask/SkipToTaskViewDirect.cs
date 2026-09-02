using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.SkipInterface.SkipTask
{
	// Token: 0x02004F58 RID: 20312
	public class SkipToTaskViewDirect : SkipToMoonChasingBase
	{
		// Token: 0x06034614 RID: 214548 RVA: 0x00D1C064 File Offset: 0x00D1A264
		protected override void OnRun([Nullable(new byte[]
		{
			1,
			2
		})] params object[] data)
		{
			string s = (string)data[0];
			if (!base.CheckMainViewOpen())
			{
				base.SkipToMap(int.Parse(s));
				return;
			}
			ControllerBase<MoonChasingController>.Instance.OpenTaskView(EMoonChasingTaskType.MainLine, 0, false);
		}
	}
}
