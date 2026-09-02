using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;

// Token: 0x02001CC7 RID: 7367
public abstract class GachaAccumulateBonusContentBase : UiPanelBase
{
	// Token: 0x0600D829 RID: 55337
	public abstract void RefreshView(int accumulateId);

	// Token: 0x0600D82A RID: 55338
	public abstract UniTask PlayStartSequence();

	// Token: 0x0600D82B RID: 55339
	public abstract UniTask PlayCloseSequence();

	// Token: 0x0600D82C RID: 55340
	[NullableContext(1)]
	public abstract void SetOnClickBackButtonCallBack(Action callback);
}
