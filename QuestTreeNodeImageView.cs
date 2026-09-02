using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020026C5 RID: 9925
public class QuestTreeNodeImageView : UiViewBase
{
	// Token: 0x0601394B RID: 80203 RVA: 0x00576684 File Offset: 0x00574884
	[NullableContext(1)]
	public QuestTreeNodeImageView(UiViewInfo info) : base(info)
	{
	}

	// Token: 0x0601394C RID: 80204 RVA: 0x00576690 File Offset: 0x00574890
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnClickCloseBtn));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0601394D RID: 80205 RVA: 0x00576738 File Offset: 0x00574938
	protected override UniTask OnBeforeStartAsync()
	{
		QuestTreeNodeImageView.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<QuestTreeNodeImageView.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0601394E RID: 80206 RVA: 0x0057677B File Offset: 0x0057497B
	protected override void OnBeforeHide()
	{
		ControllerBase<QuestTreeController>.Instance.OpenNodeDetailView(this.Data);
	}

	// Token: 0x0601394F RID: 80207 RVA: 0x0057678D File Offset: 0x0057498D
	private void OnClickCloseBtn()
	{
		base.CloseMe(null);
	}

	// Token: 0x04009873 RID: 39027
	[Nullable(1)]
	private QuestTreeNodeData Data;

	// Token: 0x02008A74 RID: 35444
	private class EComponentDefine
	{
		// Token: 0x0402EB32 RID: 191282
		public const int TextureDetail = 0;

		// Token: 0x0402EB33 RID: 191283
		public const int BtnMask = 1;
	}
}
