using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002A8F RID: 10895
[NullableContext(1)]
[Nullable(0)]
public class SpecialTransitionView : UiViewBase
{
	// Token: 0x06015CF4 RID: 89332 RVA: 0x0060BF78 File Offset: 0x0060A178
	public SpecialTransitionView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06015CF5 RID: 89333 RVA: 0x0060BF88 File Offset: 0x0060A188
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUITexture)),
			new ValueTuple<int, Type>(3, typeof(UUIItem))
		};
	}

	// Token: 0x06015CF6 RID: 89334 RVA: 0x0060BFE4 File Offset: 0x0060A1E4
	protected override UniTask OnBeforeStartAsync()
	{
		SpecialTransitionView.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<SpecialTransitionView.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06015CF7 RID: 89335 RVA: 0x0060C028 File Offset: 0x0060A228
	protected override void OnBeforeHide()
	{
		if (this.AudioHandle != -1)
		{
			Singleton<AudioSystem>.Instance.ExecuteAction(this.AudioHandle, EAudioActionType.Stop, null);
			this.AudioHandle = -1;
		}
	}

	// Token: 0x06015CF8 RID: 89336 RVA: 0x0060C060 File Offset: 0x0060A260
	private UniTask InitContent()
	{
		SpecialTransitionView.<InitContent>d__8 <InitContent>d__;
		<InitContent>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitContent>d__.<>4__this = this;
		<InitContent>d__.<>1__state = -1;
		<InitContent>d__.<>t__builder.Start<SpecialTransitionView.<InitContent>d__8>(ref <InitContent>d__);
		return <InitContent>d__.<>t__builder.Task;
	}

	// Token: 0x06015CF9 RID: 89337 RVA: 0x0060C0A4 File Offset: 0x0060A2A4
	private void PlayAkEvent(string akEvent)
	{
		if (StringUtils.IsEmpty(akEvent))
		{
			return;
		}
		string text = Singleton<AudioSystem>.Instance.parseAudioEventPath(akEvent);
		if (text != null)
		{
			this.AudioHandle = Singleton<AudioSystem>.Instance.PostEvent(text);
		}
	}

	// Token: 0x06015CFA RID: 89338 RVA: 0x0060C0DC File Offset: 0x0060A2DC
	public UniTask LoadSpine(int id, bool isLoop)
	{
		SpecialTransitionView.<LoadSpine>d__10 <LoadSpine>d__;
		<LoadSpine>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<LoadSpine>d__.<>4__this = this;
		<LoadSpine>d__.id = id;
		<LoadSpine>d__.isLoop = isLoop;
		<LoadSpine>d__.<>1__state = -1;
		<LoadSpine>d__.<>t__builder.Start<SpecialTransitionView.<LoadSpine>d__10>(ref <LoadSpine>d__);
		return <LoadSpine>d__.<>t__builder.Task;
	}

	// Token: 0x06015CFB RID: 89339 RVA: 0x0060C130 File Offset: 0x0060A330
	public void LoadTextureBg(string path)
	{
		base.TrySetTextureByPath(path, base.GetTexture(2), null, null);
	}

	// Token: 0x0400A74C RID: 42828
	[Nullable(2)]
	private ISpecialTransitionViewParams Param;

	// Token: 0x0400A74D RID: 42829
	[Nullable(2)]
	private ChildSpineView ChildSpineView;

	// Token: 0x0400A74E RID: 42830
	private int AudioHandle = -1;

	// Token: 0x02008DFF RID: 36351
	[NullableContext(0)]
	private enum EChildType
	{
		// Token: 0x0402FC7C RID: 195708
		PanelFull,
		// Token: 0x0402FC7D RID: 195709
		SpineNode,
		// Token: 0x0402FC7E RID: 195710
		TexBg,
		// Token: 0x0402FC7F RID: 195711
		LoadingItem,
		// Token: 0x0402FC80 RID: 195712
		NextButton,
		// Token: 0x0402FC81 RID: 195713
		TxtInfo,
		// Token: 0x0402FC82 RID: 195714
		DynamicNode1,
		// Token: 0x0402FC83 RID: 195715
		DynamicNode2
	}
}
