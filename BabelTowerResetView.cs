using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001240 RID: 4672
public class BabelTowerResetView : UiViewBase
{
	// Token: 0x06007C7D RID: 31869 RVA: 0x0020BF6A File Offset: 0x0020A16A
	[NullableContext(1)]
	public BabelTowerResetView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06007C7E RID: 31870 RVA: 0x0020BF74 File Offset: 0x0020A174
	protected unsafe override void OnRegisterComponent()
	{
		int num = 3;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
		this.ComponentRegisterInfos = list;
		num2 = 2;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnClickCancelBtn));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnClickConfirmBtn));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06007C7F RID: 31871 RVA: 0x0020C060 File Offset: 0x0020A260
	protected override UniTask OnBeforeStartAsync()
	{
		BabelTowerResetView.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<BabelTowerResetView.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06007C80 RID: 31872 RVA: 0x0020C0A3 File Offset: 0x0020A2A3
	private void OnClickCancelBtn()
	{
		base.CloseMe(null);
	}

	// Token: 0x06007C81 RID: 31873 RVA: 0x0020C0AC File Offset: 0x0020A2AC
	private void OnClickConfirmBtn()
	{
		ControllerBase<BabelTowerController>.Instance.ResetBabelTowerLevelRequest(this.LevelId);
		base.CloseMe(null);
	}

	// Token: 0x04003B91 RID: 15249
	private int LevelId;

	// Token: 0x020075AF RID: 30127
	private class EComponentDefine
	{
		// Token: 0x04028999 RID: 166297
		public const int LevelItem = 0;

		// Token: 0x0402899A RID: 166298
		public const int CancelBtn = 1;

		// Token: 0x0402899B RID: 166299
		public const int ConfirmBtn = 2;
	}
}
