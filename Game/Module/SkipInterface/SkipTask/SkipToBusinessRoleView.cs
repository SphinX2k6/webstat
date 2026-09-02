using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.SkipInterface.SkipTask
{
	// Token: 0x02004F3F RID: 20287
	public class SkipToBusinessRoleView : SkipToMoonChasingBase
	{
		// Token: 0x060345E0 RID: 214496 RVA: 0x00D1B31C File Offset: 0x00D1951C
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
			ControllerBase<MoonChasingController>.Instance.OpenHelperView();
		}
	}
}
