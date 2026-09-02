using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.GenericPrompt.View
{
	// Token: 0x02005CB6 RID: 23734
	public class DungeonAutoExitFloatTips : GenericPromptFloatTipsBase
	{
		// Token: 0x0603BE33 RID: 245299 RVA: 0x00F2D88E File Offset: 0x00F2BA8E
		[NullableContext(1)]
		public DungeonAutoExitFloatTips(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603BE34 RID: 245300 RVA: 0x00F2D897 File Offset: 0x00F2BA97
		protected override void OnAddEventListener()
		{
			base.OnAddEventListener();
			Singleton<EventSystem>.Instance.Add<double, double>(EEventName.OnGamePlayCdChanged, new Action<double, double>(this.UpdateCountDown));
		}

		// Token: 0x0603BE35 RID: 245301 RVA: 0x00F2D8BB File Offset: 0x00F2BABB
		protected override void OnRemoveEventListener()
		{
			base.OnRemoveEventListener();
			Singleton<EventSystem>.Instance.Remove(EEventName.OnGamePlayCdChanged, new Action<double, double>(this.UpdateCountDown));
		}

		// Token: 0x0603BE36 RID: 245302 RVA: 0x00F2D8DF File Offset: 0x00F2BADF
		private void UpdateCountDown(double cdRemainTime, double d)
		{
			this.SetMainText(new <>z__ReadOnlySingleElementList<object>(cdRemainTime.ToString(CultureInfo.InvariantCulture)));
		}
	}
}
