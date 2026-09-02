using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001D31 RID: 7473
public class MotorcycleArrowCollectionTipsView : UiViewBase
{
	// Token: 0x0600DC0D RID: 56333 RVA: 0x003B26C6 File Offset: 0x003B08C6
	[NullableContext(1)]
	public MotorcycleArrowCollectionTipsView(UiViewInfo info) : base(info)
	{
	}

	// Token: 0x0600DC0E RID: 56334 RVA: 0x003B26D0 File Offset: 0x003B08D0
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action(this.OnClickBtnClose))
		};
	}

	// Token: 0x0600DC0F RID: 56335 RVA: 0x003B2738 File Offset: 0x003B0938
	protected override UniTask OnBeforeStartAsync()
	{
		MotorcycleArrowCollectionTipsView.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<MotorcycleArrowCollectionTipsView.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600DC10 RID: 56336 RVA: 0x003B277B File Offset: 0x003B097B
	private void OnClickBtnClose()
	{
		base.CloseMe(null);
	}

	// Token: 0x04006944 RID: 26948
	[Nullable(2)]
	protected MotorcycleArrowCollectionItem CollectionItem;

	// Token: 0x04006945 RID: 26949
	[Nullable(2)]
	protected MotorcycleArrowCollectionItemData Data;

	// Token: 0x020080C1 RID: 32961
	private static class EComponentDefine
	{
		// Token: 0x0402BC97 RID: 179351
		public const int ButtonClose = 0;

		// Token: 0x0402BC98 RID: 179352
		public const int ItemTopCollection = 1;
	}
}
