using System;
using System.Collections.Generic;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.TotalTopUp
{
	// Token: 0x02006283 RID: 25219
	public class TotalTopUpPageTitlePanel : UiPanelBase
	{
		// Token: 0x0603F7FA RID: 260090 RVA: 0x01047C98 File Offset: 0x01045E98
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUIText)),
				new ValueTuple<int, Type>(3, typeof(UUIButtonComponent))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(3, new Action(this.OnClickHelp))
			};
		}

		// Token: 0x0603F7FB RID: 260091 RVA: 0x01047D2C File Offset: 0x01045F2C
		public void RefreshTime(long time)
		{
			CommonDefine.ICountDown remainTimeDataFormat = Singleton<TimeUtil>.Instance.GetRemainTimeDataFormat3((double)time);
			UUIText text = base.GetText(1);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "TotalTopUp_1001", new <>z__ReadOnlySingleElementList<object>(remainTimeDataFormat.CountDownText ?? string.Empty));
		}

		// Token: 0x0603F7FC RID: 260092 RVA: 0x01047D72 File Offset: 0x01045F72
		private void OnClickHelp()
		{
			ControllerBase<HelpController>.Instance.OpenHelpById(516);
		}

		// Token: 0x0200C368 RID: 50024
		private class ENode
		{
			// Token: 0x0403C37C RID: 246652
			public const int TextTitle = 0;

			// Token: 0x0403C37D RID: 246653
			public const int TextTime = 1;

			// Token: 0x0403C37E RID: 246654
			public const int TextDescription = 2;

			// Token: 0x0403C37F RID: 246655
			public const int BtnHelp = 3;
		}
	}
}
