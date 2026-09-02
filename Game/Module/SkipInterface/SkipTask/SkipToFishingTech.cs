using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Activity.ActivityContent.Fishing;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.SkipInterface.SkipTask
{
	// Token: 0x02004F49 RID: 20297
	public class SkipToFishingTech : SkipTask
	{
		// Token: 0x060345F4 RID: 214516 RVA: 0x00D1BAF0 File Offset: 0x00D19CF0
		protected override void OnRun([Nullable(new byte[]
		{
			1,
			2
		})] params object[] data)
		{
			string s = (string)data[0];
			string s2 = (string)data[1];
			int type = int.Parse(s);
			int nodeId = int.Parse(s2);
			FishingTechOpenParam param = new FishingTechOpenParam
			{
				Type = type,
				NodeId = nodeId
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.FishingTechRootView, param, null);
			base.Finish();
		}
	}
}
