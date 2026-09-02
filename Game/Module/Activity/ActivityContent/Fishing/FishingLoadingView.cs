using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x02006813 RID: 26643
	public class FishingLoadingView : UiViewBase
	{
		// Token: 0x06042687 RID: 272007 RVA: 0x01106009 File Offset: 0x01104209
		[NullableContext(1)]
		public FishingLoadingView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x06042688 RID: 272008 RVA: 0x01106014 File Offset: 0x01104214
		protected override void OnStart()
		{
			bool needOpenDock = (bool)this.OpenParam;
			UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
			if (uiViewSequence == null)
			{
				return;
			}
			TOpenViewCallBack <>9__1;
			TTimerAction <>9__2;
			uiViewSequence.AddSequenceFinishEvent("Start", delegate(string _)
			{
				if (needOpenDock)
				{
					UiManager instance = Singleton<UiManager>.Instance;
					EUiViewName fishingDockView = EUiViewName.FishingDockView;
					object param = null;
					TOpenViewCallBack finishCallback;
					if ((finishCallback = <>9__1) == null)
					{
						finishCallback = (<>9__1 = delegate(bool _, int _)
						{
							this.CloseMe(null);
						});
					}
					instance.OpenView(fishingDockView, param, finishCallback);
					return;
				}
				TimerSystemInstance gameplayTimeInstance = TimerSystem.GameplayTimeInstance;
				TTimerAction action;
				if ((action = <>9__2) == null)
				{
					action = (<>9__2 = delegate(float _)
					{
						this.CloseMe(null);
					});
				}
				gameplayTimeInstance.Next(action, null, null);
			}, false);
		}
	}
}
