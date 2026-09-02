using System;
using System.Collections.Generic;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.FeiXue
{
	// Token: 0x02006843 RID: 26691
	public class FeiXueCheckDetailItem : UiPanelBase
	{
		// Token: 0x0604288C RID: 272524 RVA: 0x01113C6F File Offset: 0x01111E6F
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText))
			};
		}

		// Token: 0x0604288D RID: 272525 RVA: 0x01113C92 File Offset: 0x01111E92
		protected override void OnStart()
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), "FeiXueWarmup_1031", Array.Empty<object>());
		}
	}
}
