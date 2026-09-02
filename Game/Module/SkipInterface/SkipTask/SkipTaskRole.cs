using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.SkipInterface.SkipTask
{
	// Token: 0x02004F35 RID: 20277
	public class SkipTaskRole : SkipTask
	{
		// Token: 0x060345CB RID: 214475 RVA: 0x00D1ACE0 File Offset: 0x00D18EE0
		protected override void OnRun([Nullable(new byte[]
		{
			1,
			2
		})] params object[] data)
		{
			string text = (string)data[0];
			EUiTabViewName? openTabView = null;
			if (text != "0")
			{
				openTabView = new EUiTabViewName?(new EUiTabViewName(text));
			}
			ControllerBase<RoleController>.Instance.OpenRoleMainView(ERoleAgentType.Normal, 0, new List<int>(), openTabView, null);
			base.Finish();
		}

		// Token: 0x0401E311 RID: 123665
		[Nullable(1)]
		private const string DEFAULT_PARAM = "0";
	}
}
