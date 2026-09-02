using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

// Token: 0x02001551 RID: 5457
[NullableContext(1)]
public interface IRegressTransitionState
{
	// Token: 0x06009931 RID: 39217
	void Transition(UiViewBase view);

	// Token: 0x06009932 RID: 39218
	EActivityRecallTransitionStatus GetNextStatus();

	// Token: 0x06009933 RID: 39219
	void End();

	// Token: 0x17000D18 RID: 3352
	// (get) Token: 0x06009934 RID: 39220
	Action<IRegressTransitionState> EndCallBack { get; }
}
