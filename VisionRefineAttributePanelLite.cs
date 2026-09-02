using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001814 RID: 6164
[NullableContext(2)]
[Nullable(0)]
public class VisionRefineAttributePanelLite : UiPanelBase
{
	// Token: 0x0600AF75 RID: 44917 RVA: 0x002EC0F4 File Offset: 0x002EA2F4
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIButtonComponent))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(1, new Action(this.OnClickMainNew))
		};
	}

	// Token: 0x0600AF76 RID: 44918 RVA: 0x002EC15C File Offset: 0x002EA35C
	protected override UniTask OnBeforeStartAsync()
	{
		VisionRefineAttributePanelLite.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<VisionRefineAttributePanelLite.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600AF77 RID: 44919 RVA: 0x002EC19F File Offset: 0x002EA39F
	public void RefreshItemSwitch(IRefineAttrItemData data)
	{
		this.ItemMainNew.RefreshUi(data);
	}

	// Token: 0x0600AF78 RID: 44920 RVA: 0x002EC1AD File Offset: 0x002EA3AD
	[NullableContext(1)]
	public void RefreshTitle(string textId)
	{
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), textId, Array.Empty<object>());
	}

	// Token: 0x0600AF79 RID: 44921 RVA: 0x002EC1C6 File Offset: 0x002EA3C6
	public void RefreshInteractive(bool active)
	{
		UUIButtonComponent button = base.GetButton(1);
		if (button == null)
		{
			return;
		}
		button.SetSelfInteractive(active);
	}

	// Token: 0x0600AF7A RID: 44922 RVA: 0x002EC1DA File Offset: 0x002EA3DA
	[NullableContext(1)]
	public void BindClickCallBack(Action callback)
	{
		this.OnClickCallBack = callback;
	}

	// Token: 0x0600AF7B RID: 44923 RVA: 0x002EC1E3 File Offset: 0x002EA3E3
	private void OnClickMainNew()
	{
		if (this.OnClickCallBack != null)
		{
			this.OnClickCallBack();
		}
	}

	// Token: 0x04005334 RID: 21300
	private AttributeSelectItem ItemMainNew;

	// Token: 0x04005335 RID: 21301
	private Action OnClickCallBack;

	// Token: 0x02007B96 RID: 31638
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402A3DC RID: 173020
		TextTips,
		// Token: 0x0402A3DD RID: 173021
		ItemMainNew
	}
}
