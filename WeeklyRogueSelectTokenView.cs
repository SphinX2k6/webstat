using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Module.Roguelike;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002D51 RID: 11601
public class WeeklyRogueSelectTokenView : UiViewBase
{
	// Token: 0x06017683 RID: 95875 RVA: 0x0067DAE2 File Offset: 0x0067BCE2
	[NullableContext(1)]
	public WeeklyRogueSelectTokenView(UiViewInfo info) : base(info)
	{
	}

	// Token: 0x06017684 RID: 95876 RVA: 0x0067DAEC File Offset: 0x0067BCEC
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(1, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(2, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(3, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(4, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(5, typeof(UUIText)),
			new ValueTuple<int, Type>(6, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(1, new Action(this.OnBtnConfirm)),
			new ValueTuple<int, Delegate>(2, new Action(this.OnBtnBack)),
			new ValueTuple<int, Delegate>(3, new Action(this.OnBtnInfo)),
			new ValueTuple<int, Delegate>(4, new Action<EToggleState>(this.OnToggleDesc))
		};
	}

	// Token: 0x06017685 RID: 95877 RVA: 0x0067DC0C File Offset: 0x0067BE0C
	protected override UniTask OnBeforeStartAsync()
	{
		WeeklyRogueSelectTokenView.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<WeeklyRogueSelectTokenView.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06017686 RID: 95878 RVA: 0x0067DC50 File Offset: 0x0067BE50
	protected override void OnBeforeShow()
	{
		EToggleState state = (ModelBase<WeeklyRogueModel>.Instance.DescMode == EDescModel.SIMPLE) ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
		base.GetExtendToggle(4).SetToggleState(state, false, false, false);
	}

	// Token: 0x06017687 RID: 95879 RVA: 0x0067DC7F File Offset: 0x0067BE7F
	[NullableContext(1)]
	private WeeklyRogueTokenItem CreateTokenItem()
	{
		return new WeeklyRogueTokenItem
		{
			OnSelectedChange = new Action<int?>(this.OnSelectChange)
		};
	}

	// Token: 0x06017688 RID: 95880 RVA: 0x0067DC98 File Offset: 0x0067BE98
	private void OnSelectChange(int? selectIndex)
	{
		if (selectIndex == null)
		{
			GenericLayout<WeeklyRogueTokenItem, RogueWeeklyEntry> tokenLayout = this.TokenLayout;
			if (tokenLayout != null)
			{
				tokenLayout.DeselectCurrentGridProxy();
			}
			base.GetButton(1).SetSelfInteractive(false);
			return;
		}
		GenericLayout<WeeklyRogueTokenItem, RogueWeeklyEntry> tokenLayout2 = this.TokenLayout;
		if (tokenLayout2 != null)
		{
			tokenLayout2.SelectGridProxy(selectIndex.Value, false);
		}
		base.GetButton(1).SetSelfInteractive(true);
	}

	// Token: 0x06017689 RID: 95881 RVA: 0x0067DCF3 File Offset: 0x0067BEF3
	private void OnBtnConfirm()
	{
		ControllerBase<WeeklyRogueController>.Instance.SelectOptionRequest(null);
		base.CloseMe(null);
	}

	// Token: 0x0601768A RID: 95882 RVA: 0x0067DD07 File Offset: 0x0067BF07
	private void OnBtnBack()
	{
		base.CloseMe(null);
	}

	// Token: 0x0601768B RID: 95883 RVA: 0x0067DD10 File Offset: 0x0067BF10
	private void OnBtnInfo()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.WeeklyRogueInfo, null, null);
	}

	// Token: 0x0601768C RID: 95884 RVA: 0x0067DD23 File Offset: 0x0067BF23
	private void OnToggleDesc(EToggleState toggleState)
	{
		ModelBase<WeeklyRogueModel>.Instance.ChangeDescMode();
	}

	// Token: 0x0400B39E RID: 45982
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<WeeklyRogueTokenItem, RogueWeeklyEntry> TokenLayout;

	// Token: 0x0400B39F RID: 45983
	[Nullable(2)]
	private PopupCaptionItem CaptionItem;

	// Token: 0x02009021 RID: 36897
	private enum EWeeklyRogueSelectTokenDefine
	{
		// Token: 0x040305B0 RID: 198064
		Layout,
		// Token: 0x040305B1 RID: 198065
		BtnConfirm,
		// Token: 0x040305B2 RID: 198066
		BtnBack,
		// Token: 0x040305B3 RID: 198067
		BtnInfo,
		// Token: 0x040305B4 RID: 198068
		ToggleDesc,
		// Token: 0x040305B5 RID: 198069
		TxtToggleDesc,
		// Token: 0x040305B6 RID: 198070
		CaptionItem
	}
}
