using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002D50 RID: 11600
public class WeeklyRogueSelectArtifactView : UiViewBase
{
	// Token: 0x06017677 RID: 95863 RVA: 0x0067D88A File Offset: 0x0067BA8A
	[NullableContext(1)]
	public WeeklyRogueSelectArtifactView(UiViewInfo info) : base(info)
	{
	}

	// Token: 0x06017678 RID: 95864 RVA: 0x0067D894 File Offset: 0x0067BA94
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIButtonComponent))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(3, new Action(this.OnBtnConfirm))
		};
	}

	// Token: 0x06017679 RID: 95865 RVA: 0x0067D928 File Offset: 0x0067BB28
	protected override UniTask OnBeforeStartAsync()
	{
		WeeklyRogueSelectArtifactView.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<WeeklyRogueSelectArtifactView.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0601767A RID: 95866 RVA: 0x0067D96B File Offset: 0x0067BB6B
	protected override void OnBeforeShow()
	{
		this.TokenLayout.PlayGridAnim();
	}

	// Token: 0x0601767B RID: 95867 RVA: 0x0067D978 File Offset: 0x0067BB78
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.WeeklyRogueCycleRefresh, new Action(this.OnCycleRefresh));
	}

	// Token: 0x0601767C RID: 95868 RVA: 0x0067D996 File Offset: 0x0067BB96
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.WeeklyRogueCycleRefresh, new Action(this.OnCycleRefresh));
	}

	// Token: 0x0601767D RID: 95869 RVA: 0x0067D9B4 File Offset: 0x0067BBB4
	private void OnCycleRefresh()
	{
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.WeeklyRogueCycleRefresh);
		confirmBoxDataNew.FunctionMap.Add(1, new Action(WeeklyRogueSelectArtifactView.<OnCycleRefresh>g__ConfirmCallback|9_0));
		confirmBoxDataNew.FunctionMap.Add(0, new Action(WeeklyRogueSelectArtifactView.<OnCycleRefresh>g__ConfirmCallback|9_0));
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
	}

	// Token: 0x0601767E RID: 95870 RVA: 0x0067DA08 File Offset: 0x0067BC08
	[NullableContext(1)]
	private WeeklyRogueArtifactItem CreateTokenItem()
	{
		return new WeeklyRogueArtifactItem
		{
			OnSelectedChange = new Action<int?>(this.OnSelectChange)
		};
	}

	// Token: 0x0601767F RID: 95871 RVA: 0x0067DA24 File Offset: 0x0067BC24
	private void OnSelectChange(int? selectIndex)
	{
		if (selectIndex == null)
		{
			GenericLayout<WeeklyRogueArtifactItem, RogueWeeklyEntry> tokenLayout = this.TokenLayout;
			if (tokenLayout != null)
			{
				tokenLayout.DeselectCurrentGridProxy();
			}
			base.GetButton(3).SetSelfInteractive(false);
			return;
		}
		GenericLayout<WeeklyRogueArtifactItem, RogueWeeklyEntry> tokenLayout2 = this.TokenLayout;
		if (tokenLayout2 != null)
		{
			tokenLayout2.SelectGridProxy(selectIndex.Value, false);
		}
		base.GetButton(3).SetSelfInteractive(true);
	}

	// Token: 0x06017680 RID: 95872 RVA: 0x0067DA80 File Offset: 0x0067BC80
	private void OnBtnConfirm()
	{
		Singleton<UiLayer>.Instance.SetShowMaskLayer("WeeklyRogueSelectArtifactView.SelectArtifactRequest", true);
		ControllerBase<WeeklyRogueController>.Instance.SelectArtifactRequest().ContinueWith(delegate(bool success)
		{
			if (success)
			{
				List<int> selectRoleIdList = ModelBase<WeeklyRogueModel>.Instance.SelectRoleIdList;
				ControllerBase<WeeklyRogueController>.Instance.RogueWeeklyStartRequest(selectRoleIdList);
			}
			Singleton<UiLayer>.Instance.SetShowMaskLayer("WeeklyRogueSelectArtifactView.SelectArtifactRequest", false);
		});
	}

	// Token: 0x06017681 RID: 95873 RVA: 0x0067DACC File Offset: 0x0067BCCC
	private void OnBtnBack()
	{
		base.CloseMe(null);
	}

	// Token: 0x06017682 RID: 95874 RVA: 0x0067DAD5 File Offset: 0x0067BCD5
	[CompilerGenerated]
	internal static void <OnCycleRefresh>g__ConfirmCallback|9_0()
	{
		Singleton<UiManager>.Instance.ResetToBattleView(null);
	}

	// Token: 0x0400B39C RID: 45980
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<WeeklyRogueArtifactItem, RogueWeeklyEntry> TokenLayout;

	// Token: 0x0400B39D RID: 45981
	[Nullable(2)]
	private WeeklyRogueCaptionItem CaptionItem;

	// Token: 0x0200901E RID: 36894
	private enum EWeeklyRogueSelectTokenDefine
	{
		// Token: 0x040305A5 RID: 198053
		CaptionItem,
		// Token: 0x040305A6 RID: 198054
		ArtifactLayout,
		// Token: 0x040305A7 RID: 198055
		ArtifactItem,
		// Token: 0x040305A8 RID: 198056
		BtnConfirm
	}
}
