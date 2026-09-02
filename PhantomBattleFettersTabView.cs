using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x02001803 RID: 6147
public class PhantomBattleFettersTabView : UiTabViewBase
{
	// Token: 0x0600AEBA RID: 44730 RVA: 0x002E8B3C File Offset: 0x002E6D3C
	protected override UniTask OnBeforeStartAsync()
	{
		PhantomBattleFettersTabView.<OnBeforeStartAsync>d__1 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<PhantomBattleFettersTabView.<OnBeforeStartAsync>d__1>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600AEBB RID: 44731 RVA: 0x002E8B80 File Offset: 0x002E6D80
	protected override void OnBeforeShow()
	{
		int? num = this.ExtraParams as int?;
		if (num != null)
		{
			int? num2 = num;
			int num3 = 0;
			if (num2.GetValueOrDefault() > num3 & num2 != null)
			{
				this.ViewItem.SelectByFetterId(num.Value);
			}
		}
	}

	// Token: 0x040052ED RID: 21229
	[Nullable(2)]
	private PhantomBattleFettersViewItem ViewItem;
}
