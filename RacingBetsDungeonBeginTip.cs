using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;

// Token: 0x02002739 RID: 10041
public class RacingBetsDungeonBeginTip : UiViewBase
{
	// Token: 0x06013CE3 RID: 81123 RVA: 0x0058338B File Offset: 0x0058158B
	[NullableContext(1)]
	public RacingBetsDungeonBeginTip(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06013CE4 RID: 81124 RVA: 0x00583394 File Offset: 0x00581594
	protected override void OnAfterPlayStartSequence()
	{
		TimerSystem.Instance.Next(delegate(float _)
		{
			UniTaskCompletionSource uniTaskCompletionSource = this.OpenParam as UniTaskCompletionSource;
			base.CloseMe(null);
			if (uniTaskCompletionSource == null)
			{
				return;
			}
			uniTaskCompletionSource.TrySetResult();
		}, null, null);
	}
}
