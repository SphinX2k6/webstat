using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;

// Token: 0x0200237B RID: 9083
public class BattlePassFirstOpenView : UiViewBase
{
	// Token: 0x0601162E RID: 71214 RVA: 0x004CA12A File Offset: 0x004C832A
	[NullableContext(1)]
	public BattlePassFirstOpenView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0601162F RID: 71215 RVA: 0x004CA133 File Offset: 0x004C8333
	protected override void OnBeforeShow()
	{
		ControllerBase<BattlePassController>.Instance.SetBattlePassEnter();
		base.PlaySequence("BpStart", delegate
		{
			Singleton<UiManager>.Instance.OpenViewAsync(EUiViewName.BattlePassMainView, null, null).ContinueWith(delegate(int? _)
			{
				base.CloseMe(null);
			}).Forget();
		}, false);
	}
}
