using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.SkipInterface.SkipTask
{
	// Token: 0x02004F23 RID: 20259
	public class SkipTaskActivity : SkipTask
	{
		// Token: 0x06034597 RID: 214423 RVA: 0x00D19CC0 File Offset: 0x00D17EC0
		protected override void OnRun([Nullable(new byte[]
		{
			1,
			2
		})] params object[] data)
		{
			string text = data[0] as string;
			int num = (text != null) ? int.Parse(text) : ((int)data[0]);
			if (num > 0)
			{
				ActivityBaseData activityById = ModelBase<ActivityModel>.Instance.GetActivityById(num);
				if (activityById == null || !activityById.CheckIfInShowTime())
				{
					ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("ActivityAdvice", Array.Empty<object>());
				}
			}
			ControllerBase<ActivityController>.Instance.OpenActivityById(num, EActivityViewOpenType.Other, null, null);
			base.Finish();
		}
	}
}
