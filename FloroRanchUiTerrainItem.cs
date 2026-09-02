using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001C79 RID: 7289
public class FloroRanchUiTerrainItem : FloroRanchUiItemBase
{
	// Token: 0x0600D4EF RID: 54511 RVA: 0x0038D458 File Offset: 0x0038B658
	protected unsafe override void OnRegisterComponent()
	{
		int num = 3;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickPos));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600D4F0 RID: 54512 RVA: 0x0038D51F File Offset: 0x0038B71F
	[NullableContext(1)]
	public void BindClickPosCallback(Action callback)
	{
		this.OnClickPosCallback = callback;
	}

	// Token: 0x0600D4F1 RID: 54513 RVA: 0x0038D528 File Offset: 0x0038B728
	public void OnClickPos(EToggleState toggleState)
	{
		Action onClickPosCallback = this.OnClickPosCallback;
		if (onClickPosCallback == null)
		{
			return;
		}
		onClickPosCallback();
	}

	// Token: 0x0600D4F2 RID: 54514 RVA: 0x0038D53C File Offset: 0x0038B73C
	public override UniTask RefreshItem()
	{
		FloroRanchUiTerrainItem.<RefreshItem>d__5 <RefreshItem>d__;
		<RefreshItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshItem>d__.<>4__this = this;
		<RefreshItem>d__.<>1__state = -1;
		<RefreshItem>d__.<>t__builder.Start<FloroRanchUiTerrainItem.<RefreshItem>d__5>(ref <RefreshItem>d__);
		return <RefreshItem>d__.<>t__builder.Task;
	}

	// Token: 0x0600D4F3 RID: 54515 RVA: 0x0038D57F File Offset: 0x0038B77F
	public override FTransform? GetRewardPopTransform()
	{
		return new FTransform?(base.GetRootActor().GetTransform());
	}

	// Token: 0x0600D4F4 RID: 54516 RVA: 0x0038D594 File Offset: 0x0038B794
	public override UniTask PlayShowAnim()
	{
		FloroRanchUiTerrainItem.<PlayShowAnim>d__7 <PlayShowAnim>d__;
		<PlayShowAnim>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlayShowAnim>d__.<>4__this = this;
		<PlayShowAnim>d__.<>1__state = -1;
		<PlayShowAnim>d__.<>t__builder.Start<FloroRanchUiTerrainItem.<PlayShowAnim>d__7>(ref <PlayShowAnim>d__);
		return <PlayShowAnim>d__.<>t__builder.Task;
	}

	// Token: 0x0600D4F5 RID: 54517 RVA: 0x0038D5D8 File Offset: 0x0038B7D8
	public override UniTask PlayHideAnim()
	{
		FloroRanchUiTerrainItem.<PlayHideAnim>d__8 <PlayHideAnim>d__;
		<PlayHideAnim>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlayHideAnim>d__.<>4__this = this;
		<PlayHideAnim>d__.<>1__state = -1;
		<PlayHideAnim>d__.<>t__builder.Start<FloroRanchUiTerrainItem.<PlayHideAnim>d__8>(ref <PlayHideAnim>d__);
		return <PlayHideAnim>d__.<>t__builder.Task;
	}

	// Token: 0x0600D4F6 RID: 54518 RVA: 0x0038D61B File Offset: 0x0038B81B
	public void SetSelectState(bool isSelect)
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle == null)
		{
			return;
		}
		extendToggle.SetToggleState(isSelect ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x0600D4F7 RID: 54519 RVA: 0x0038D639 File Offset: 0x0038B839
	public void SetInteractive(bool isInteractive)
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle == null)
		{
			return;
		}
		extendToggle.SetSelfInteractive(isInteractive);
	}

	// Token: 0x04006538 RID: 25912
	[Nullable(1)]
	private Action OnClickPosCallback = delegate()
	{
	};

	// Token: 0x02007FBE RID: 32702
	private class EItemComponentDefine
	{
		// Token: 0x0402B7AE RID: 178094
		public const int ItemToggle = 0;

		// Token: 0x0402B7AF RID: 178095
		public const int TerrainNormalSprite = 1;

		// Token: 0x0402B7B0 RID: 178096
		public const int TerrainChangeTexture = 2;
	}
}
