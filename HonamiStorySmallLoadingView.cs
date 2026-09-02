using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;

// Token: 0x02001F58 RID: 8024
public class HonamiStorySmallLoadingView : UiViewBase
{
	// Token: 0x0600F030 RID: 61488 RVA: 0x00419FE1 File Offset: 0x004181E1
	[NullableContext(1)]
	public HonamiStorySmallLoadingView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600F031 RID: 61489 RVA: 0x00419FEC File Offset: 0x004181EC
	protected override void OnStart()
	{
		bool needOpenMainView = this.OpenParam != null;
		int? viewId = null;
		UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
		if (uiViewSequence != null)
		{
			Action<int?> <>9__2;
			TTimerAction <>9__3;
			uiViewSequence.AddSequenceFinishEvent("Start", delegate(string _)
			{
				if (needOpenMainView)
				{
					UniTask<int?> task = Singleton<UiManager>.Instance.OpenViewAsync(EUiViewName.HonamiStoryMainView, this.OpenParam, null);
					Action<int?> continuationFunction;
					if ((continuationFunction = <>9__2) == null)
					{
						continuationFunction = (<>9__2 = delegate(int? id)
						{
							if (id != null)
							{
								viewId = id;
							}
							this.CloseMe(null);
						});
					}
					task.ContinueWith(continuationFunction);
					return;
				}
				TimerSystemInstance gameplayTimeInstance = TimerSystem.GameplayTimeInstance;
				TTimerAction action;
				if ((action = <>9__3) == null)
				{
					action = (<>9__3 = delegate(float _)
					{
						this.CloseMe(null);
					});
				}
				gameplayTimeInstance.Next(action, null, null);
			}, false);
		}
		UiBehaviorLevelSequence uiViewSequence2 = this.UiViewSequence;
		if (uiViewSequence2 == null)
		{
			return;
		}
		uiViewSequence2.AddSequenceFinishEvent("Close", delegate(string _)
		{
			if (viewId != null)
			{
				UiViewBase view = Singleton<UiManager>.Instance.GetView(viewId.Value);
				if (view != null)
				{
					((HonamiStoryMainView)view).RefreshSpecialButtonsStates();
				}
			}
		}, false);
	}
}
