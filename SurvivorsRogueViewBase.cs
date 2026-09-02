using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002B71 RID: 11121
[NullableContext(2)]
[Nullable(0)]
public class SurvivorsRogueViewBase : UiPanelBase
{
	// Token: 0x06016267 RID: 90727 RVA: 0x006257B0 File Offset: 0x006239B0
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIText)),
			new ValueTuple<int, Type>(5, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(1, new Action(this.OnBackBtnClick))
		};
	}

	// Token: 0x06016268 RID: 90728 RVA: 0x00625870 File Offset: 0x00623A70
	protected override UniTask OnBeforeStartAsync()
	{
		SurvivorsRogueViewBase.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<SurvivorsRogueViewBase.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06016269 RID: 90729 RVA: 0x006258B3 File Offset: 0x00623AB3
	private void OnBtnHelp()
	{
		ControllerBase<SurvivorsRogueController>.Instance.OpenRogueHelp();
	}

	// Token: 0x0601626A RID: 90730 RVA: 0x006258BF File Offset: 0x00623ABF
	private void OnBackBtnClick()
	{
		ControllerBase<SurvivorsRogueController>.Instance.OpenLeaveInstanceView();
	}

	// Token: 0x0601626B RID: 90731 RVA: 0x006258CC File Offset: 0x00623ACC
	[NullableContext(1)]
	public void SetMainTitle(string txtId, params string[] args)
	{
		object[] array = new object[args.Length];
		for (int i = 0; i < args.Length; i++)
		{
			array[i] = args[i];
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), txtId, array);
	}

	// Token: 0x0601626C RID: 90732 RVA: 0x00625909 File Offset: 0x00623B09
	public void SetMainTitleVisible(bool bVisible)
	{
		UUIItem item = base.GetItem(3);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(bVisible);
	}

	// Token: 0x0400AB3E RID: 43838
	public PopupCaptionItem CaptionItem;

	// Token: 0x0400AB3F RID: 43839
	private SurvivorsRogueResidentWaveTipsPanel WaveTips;

	// Token: 0x0400AB40 RID: 43840
	public SurvivorsRogueRoleStatePanel RoleStatePanel;

	// Token: 0x0400AB41 RID: 43841
	private SurvivorsRogueCurrencyItem CurrencyItem;
}
