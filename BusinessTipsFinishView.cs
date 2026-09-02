using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020013DE RID: 5086
[NullableContext(2)]
[Nullable(0)]
public class BusinessTipsFinishView : UiViewBase
{
	// Token: 0x06008CA1 RID: 36001 RVA: 0x0024F6CF File Offset: 0x0024D8CF
	[NullableContext(1)]
	public BusinessTipsFinishView(UiViewInfo info) : base(info)
	{
	}

	// Token: 0x06008CA2 RID: 36002 RVA: 0x0024F6D8 File Offset: 0x0024D8D8
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUITexture)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(7, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(6, new Action(this.OnConfirm))
		};
	}

	// Token: 0x06008CA3 RID: 36003 RVA: 0x0024F7C4 File Offset: 0x0024D9C4
	private UniTask InitCaptionItem()
	{
		BusinessTipsFinishView.<InitCaptionItem>d__9 <InitCaptionItem>d__;
		<InitCaptionItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitCaptionItem>d__.<>4__this = this;
		<InitCaptionItem>d__.<>1__state = -1;
		<InitCaptionItem>d__.<>t__builder.Start<BusinessTipsFinishView.<InitCaptionItem>d__9>(ref <InitCaptionItem>d__);
		return <InitCaptionItem>d__.<>t__builder.Task;
	}

	// Token: 0x06008CA4 RID: 36004 RVA: 0x0024F808 File Offset: 0x0024DA08
	private void InitSequenceData()
	{
		if (ModelBase<MoonChasingBusinessModel>.Instance.GetResultData().EvaluationLevel < 7)
		{
			UiViewData uiViewData = new UiViewData();
			uiViewData.StartSequenceName = "Start01";
			UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
			if (uiViewSequence == null)
			{
				return;
			}
			uiViewSequence.SetSequenceName(uiViewData);
		}
	}

	// Token: 0x06008CA5 RID: 36005 RVA: 0x0024F84C File Offset: 0x0024DA4C
	protected override UniTask OnBeforeStartAsync()
	{
		BusinessTipsFinishView.<OnBeforeStartAsync>d__11 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<BusinessTipsFinishView.<OnBeforeStartAsync>d__11>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06008CA6 RID: 36006 RVA: 0x0024F890 File Offset: 0x0024DA90
	protected override void OnAfterPlayStartSequence()
	{
		Singleton<AudioSystem>.Instance.PostEvent("play_ui_figure_up_end");
		RewardItem firstReward = this.FirstReward;
		if (firstReward != null)
		{
			firstReward.ShowAddValue().Forget();
		}
		RewardItem secondReward = this.SecondReward;
		if (secondReward == null)
		{
			return;
		}
		secondReward.ShowAddValue().ContinueWith(delegate()
		{
			this.TimerHandle = TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
			{
				this.TimerHandle = null;
				UUIButtonComponent button = base.GetButton(6);
				if (button != null)
				{
					button.RootUIComp.Get().SetUIActive(true);
				}
				UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
				if (uiViewSequence == null)
				{
					return;
				}
				uiViewSequence.PlaySequencePurely("AtnStart", false, false);
			}, 1000f, null, null, true, 1f);
		}).Forget();
	}

	// Token: 0x06008CA7 RID: 36007 RVA: 0x0024F8E9 File Offset: 0x0024DAE9
	protected override void OnBeforeDestroy()
	{
		AUIBaseActor rootActor = this.RootActor;
		if (rootActor != null)
		{
			rootActor.OnSequencePlayEvent.Unbind();
		}
		this.RemoveTimerHandle();
	}

	// Token: 0x06008CA8 RID: 36008 RVA: 0x0024F907 File Offset: 0x0024DB07
	private void RemoveTimerHandle()
	{
		if (this.TimerHandle != null)
		{
			TimerSystem.GameplayTimeInstance.Remove(this.TimerHandle);
			this.TimerHandle = null;
		}
	}

	// Token: 0x06008CA9 RID: 36009 RVA: 0x0024F929 File Offset: 0x0024DB29
	[NullableContext(1)]
	private CharacterItemWithLine InitCharacterItem()
	{
		return new CharacterItemWithLine();
	}

	// Token: 0x06008CAA RID: 36010 RVA: 0x0024F930 File Offset: 0x0024DB30
	private void OnConfirm()
	{
		DelegationResultData resultData = ModelBase<MoonChasingBusinessModel>.Instance.GetResultData();
		int popularityValue = ModelBase<MoonChasingModel>.Instance.GetPopularityValue();
		int playerRoleId = ModelBase<MoonChasingBusinessModel>.Instance.GetPlayerRoleId();
		string title = (resultData.LastPopularity < popularityValue) ? "Moonfiesta_Title1" : "Moonfiesta_Title2";
		MoonChasingPopularityUpData popularityUpData = new MoonChasingPopularityUpData(playerRoleId, resultData.LastPopularity, popularityValue, resultData.GetRoleDialog(), title);
		ControllerBase<MoonChasingController>.Instance.OpenTipsPopularityUpView(popularityUpData);
	}

	// Token: 0x06008CAB RID: 36011 RVA: 0x0024F992 File Offset: 0x0024DB92
	[NullableContext(1)]
	private void PlayNewAudio(string sequenceName, string eventName)
	{
		if (eventName == "New01" && ModelBase<MoonChasingBusinessModel>.Instance.GetResultData().IsBest)
		{
			Singleton<AudioSystem>.Instance.PostEvent("play_ui_zhuiyuejie_positive");
		}
	}

	// Token: 0x04004186 RID: 16774
	[Nullable(new byte[]
	{
		2,
		1
	})]
	protected CharacterListModule<CharacterItemWithLine> CharacterListModule;

	// Token: 0x04004187 RID: 16775
	protected RewardItem FirstReward;

	// Token: 0x04004188 RID: 16776
	protected RewardItem SecondReward;

	// Token: 0x04004189 RID: 16777
	protected PopupCaptionItem CaptionItem;

	// Token: 0x0400418A RID: 16778
	private TimerHandle TimerHandle;

	// Token: 0x0400418B RID: 16779
	private const int TWEEN_TIME = 1;

	// Token: 0x020077BE RID: 30654
	[NullableContext(0)]
	private static class EComponentDefine
	{
		// Token: 0x0402934F RID: 168783
		public const int Texture = 0;

		// Token: 0x04029350 RID: 168784
		public const int UnChangeItem = 1;

		// Token: 0x04029351 RID: 168785
		public const int NewRecordItem = 2;

		// Token: 0x04029352 RID: 168786
		public const int CharacterListItem = 3;

		// Token: 0x04029353 RID: 168787
		public const int FirstReward = 4;

		// Token: 0x04029354 RID: 168788
		public const int SecondReward = 5;

		// Token: 0x04029355 RID: 168789
		public const int ConfirmBtn = 6;

		// Token: 0x04029356 RID: 168790
		public const int CaptionItem = 7;
	}
}
