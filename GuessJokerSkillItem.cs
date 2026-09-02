using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001135 RID: 4405
public class GuessJokerSkillItem : UiPanelBase
{
	// Token: 0x06007359 RID: 29529 RVA: 0x001E2E45 File Offset: 0x001E1045
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem))
		};
	}

	// Token: 0x0600735A RID: 29530 RVA: 0x001E2E68 File Offset: 0x001E1068
	protected override UniTask OnBeforeStartAsync()
	{
		GuessJokerSkillItem.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<GuessJokerSkillItem.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600735B RID: 29531 RVA: 0x001E2EAB File Offset: 0x001E10AB
	protected override void OnStart()
	{
		this.ActionItem.SetFunction(delegate(bool? b)
		{
			Action clickCallback = this.ClickCallback;
			if (clickCallback == null)
			{
				return;
			}
			clickCallback();
		});
	}

	// Token: 0x0600735C RID: 29532 RVA: 0x001E2EC4 File Offset: 0x001E10C4
	[NullableContext(1)]
	public void BindClickCallback(Action callback)
	{
		this.ClickCallback = callback;
	}

	// Token: 0x0600735D RID: 29533 RVA: 0x001E2ECD File Offset: 0x001E10CD
	[NullableContext(1)]
	public void SetText(string text)
	{
		this.ActionItem.SetToggleText(text);
	}

	// Token: 0x040037B0 RID: 14256
	[Nullable(2)]
	private ToggleActionItem ActionItem;

	// Token: 0x040037B1 RID: 14257
	[Nullable(2)]
	private Action ClickCallback;

	// Token: 0x020074C5 RID: 29893
	private static class EComponentDefine
	{
		// Token: 0x0402851C RID: 165148
		public const int Interaction = 0;
	}
}
