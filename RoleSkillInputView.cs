using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020028C3 RID: 10435
public class RoleSkillInputView : UiViewBase
{
	// Token: 0x06014B3E RID: 84798 RVA: 0x005BB9D1 File Offset: 0x005B9BD1
	[NullableContext(1)]
	public RoleSkillInputView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06014B3F RID: 84799 RVA: 0x005BB9DA File Offset: 0x005B9BDA
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem))
		};
	}

	// Token: 0x06014B40 RID: 84800 RVA: 0x005BBA14 File Offset: 0x005B9C14
	protected override UniTask OnBeforeStartAsync()
	{
		RoleSkillInputView.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<RoleSkillInputView.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06014B41 RID: 84801 RVA: 0x005BBA57 File Offset: 0x005B9C57
	private void OnBtnCloseClick()
	{
		Singleton<UiManager>.Instance.CloseView(EUiViewName.RoleSkillInputView, null);
	}

	// Token: 0x04009FA1 RID: 40865
	[Nullable(2)]
	private RoleSkillInputPanel SkillInputPanel;

	// Token: 0x04009FA2 RID: 40866
	[Nullable(2)]
	private PopupCaptionItem CaptionItem;

	// Token: 0x02008C0B RID: 35851
	private enum EComponent
	{
		// Token: 0x0402F2CE RID: 193230
		CaptionItem,
		// Token: 0x0402F2CF RID: 193231
		RoleSkillInputPanel
	}
}
