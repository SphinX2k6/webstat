using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Roguelike;

namespace CSharpScript.Game.Module.SkipInterface.SkipTask
{
	// Token: 0x02004F34 RID: 20276
	public class SkipTaskRogueActivity : SkipTask
	{
		// Token: 0x060345C9 RID: 214473 RVA: 0x00D1ACC2 File Offset: 0x00D18EC2
		protected override void OnRun([Nullable(new byte[]
		{
			1,
			2
		})] params object[] data)
		{
			ControllerBase<RoguelikeController>.Instance.OpenRoguelikeActivityView();
			base.Finish();
		}
	}
}
