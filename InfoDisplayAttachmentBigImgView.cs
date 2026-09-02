using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.PhoneMessage;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001FF6 RID: 8182
public class InfoDisplayAttachmentBigImgView : UiViewBase
{
	// Token: 0x0600F723 RID: 63267 RVA: 0x0043A61B File Offset: 0x0043881B
	[NullableContext(1)]
	public InfoDisplayAttachmentBigImgView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600F724 RID: 63268 RVA: 0x0043A624 File Offset: 0x00438824
	protected unsafe override void OnRegisterComponent()
	{
		int num = 5;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(USpineSkeletonAnimationComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUITexture));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnClickCloseBtn));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600F725 RID: 63269 RVA: 0x0043A72D File Offset: 0x0043892D
	private void OnClickCloseBtn()
	{
		base.CloseMe(null);
	}

	// Token: 0x0600F726 RID: 63270 RVA: 0x0043A738 File Offset: 0x00438938
	protected override UniTask OnBeforeStartAsync()
	{
		InfoDisplayAttachmentBigImgView.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<InfoDisplayAttachmentBigImgView.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x04007754 RID: 30548
	private EAttachmentType CurrentShowAttachmentType;

	// Token: 0x02008375 RID: 33653
	private enum EInfoDisplayImgViewComponents
	{
		// Token: 0x0402C965 RID: 182629
		TexInfoImage,
		// Token: 0x0402C966 RID: 182630
		CloseMaskBtn,
		// Token: 0x0402C967 RID: 182631
		SpineItem,
		// Token: 0x0402C968 RID: 182632
		SpineFatherNode,
		// Token: 0x0402C969 RID: 182633
		TexBgFrame
	}
}
