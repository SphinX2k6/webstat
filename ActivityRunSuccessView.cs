using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200158E RID: 5518
[NullableContext(1)]
[Nullable(0)]
public class ActivityRunSuccessView : UiViewBase
{
	// Token: 0x06009B41 RID: 39745 RVA: 0x0028A5FE File Offset: 0x002887FE
	public ActivityRunSuccessView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06009B42 RID: 39746 RVA: 0x0028A608 File Offset: 0x00288808
	protected unsafe override void OnRegisterComponent()
	{
		int num = 11;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06009B43 RID: 39747 RVA: 0x0028A7A4 File Offset: 0x002889A4
	protected override UniTask OnBeforeStartAsync()
	{
		ActivityRunSuccessView.<OnBeforeStartAsync>d__10 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ActivityRunSuccessView.<OnBeforeStartAsync>d__10>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06009B44 RID: 39748 RVA: 0x0028A7E8 File Offset: 0x002889E8
	private UniTask InitButtonAsync()
	{
		ActivityRunSuccessView.<InitButtonAsync>d__11 <InitButtonAsync>d__;
		<InitButtonAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitButtonAsync>d__.<>4__this = this;
		<InitButtonAsync>d__.<>1__state = -1;
		<InitButtonAsync>d__.<>t__builder.Start<ActivityRunSuccessView.<InitButtonAsync>d__11>(ref <InitButtonAsync>d__);
		return <InitButtonAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06009B45 RID: 39749 RVA: 0x0028A82C File Offset: 0x00288A2C
	private UniTask CreateButton(UUIItem uiItem, int buttonIndex, Action clickFunction)
	{
		ActivityRunSuccessView.<CreateButton>d__12 <CreateButton>d__;
		<CreateButton>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateButton>d__.<>4__this = this;
		<CreateButton>d__.buttonIndex = buttonIndex;
		<CreateButton>d__.clickFunction = clickFunction;
		<CreateButton>d__.<>1__state = -1;
		<CreateButton>d__.<>t__builder.Start<ActivityRunSuccessView.<CreateButton>d__12>(ref <CreateButton>d__);
		return <CreateButton>d__.<>t__builder.Task;
	}

	// Token: 0x06009B46 RID: 39750 RVA: 0x0028A87F File Offset: 0x00288A7F
	protected override void OnStart()
	{
		this.CurrentShowData = (this.OpenParam as RunEndData);
	}

	// Token: 0x06009B47 RID: 39751 RVA: 0x0028A892 File Offset: 0x00288A92
	protected override void OnBeforeShow()
	{
		this.RefreshHead();
		this.RefreshScore();
		this.RefreshIfNewRecord();
		this.RefreshTime();
		this.InitAutoLeaveTimer();
	}

	// Token: 0x06009B48 RID: 39752 RVA: 0x0028A8B2 File Offset: 0x00288AB2
	private void ClearAutoLeaveTimer()
	{
		if (TimerSystem.GameplayTimeInstance.Has(this.AutoLeaveTimerId))
		{
			TimerSystem.GameplayTimeInstance.Remove(this.AutoLeaveTimerId);
		}
		this.AutoLeaveTimerId = null;
	}

	// Token: 0x06009B49 RID: 39753 RVA: 0x0028A8E0 File Offset: 0x00288AE0
	private void InitAutoLeaveTimer()
	{
		int leftSecondToAutoLeave = 31;
		this.AutoLeaveTimerId = TimerSystem.GameplayTimeInstance.Forever(delegate(float _)
		{
			int leftSecondToAutoLeave;
			if (leftSecondToAutoLeave <= 0)
			{
				TimerSystem.GameplayTimeInstance.Remove(this.AutoLeaveTimerId);
				this.OnClickBtnLeave();
				return;
			}
			ActivityParkourButton activityParkourButton = this.ButtonMap[0];
			string textId = "InstanceDungeonLeftTimeToAutoLeave";
			string[] array = new string[1];
			int num = 0;
			leftSecondToAutoLeave = leftSecondToAutoLeave;
			leftSecondToAutoLeave--;
			array[num] = leftSecondToAutoLeave.ToString();
			activityParkourButton.SetFloatText(textId, array);
		}, 1000f, 1f, null, null, true);
	}

	// Token: 0x06009B4A RID: 39754 RVA: 0x0028A92C File Offset: 0x00288B2C
	private void RefreshTime()
	{
		string timeString = Singleton<TimeUtil>.Instance.GetTimeString((double)this.CurrentShowData.CurrentTime);
		base.GetText(10).SetText(timeString, true);
	}

	// Token: 0x06009B4B RID: 39755 RVA: 0x0028A95F File Offset: 0x00288B5F
	protected override void OnBeforeDestroy()
	{
		this.ClearAutoLeaveTimer();
	}

	// Token: 0x06009B4C RID: 39756 RVA: 0x0028A967 File Offset: 0x00288B67
	private void RefreshIfNewRecord()
	{
		base.GetItem(9).SetUIActive(this.CurrentShowData.IfNewRecord);
	}

	// Token: 0x06009B4D RID: 39757 RVA: 0x0028A984 File Offset: 0x00288B84
	private void RefreshHead()
	{
		base.GetItem(12).SetUIActive(true);
		base.GetItem(13).SetUIActive(true);
		base.GetText(14).SetUIActive(false);
		UUITexture texture = base.GetTexture(2);
		texture.SetColor(FColor.FromHex("CC9548FF"));
		base.SetTextureByPath("/Game/Aki/UI/UIResources/Common/Image/IconForceLogo/T_Logo_10_UI.T_Logo_10_UI", texture, null, null);
		UUIText text = base.GetText(1);
		text.SetColor(FColor.FromHex("FFFFFFFF"));
		text.ShowTextNew("GenericPromptTypes_3_GeneralText");
	}

	// Token: 0x06009B4E RID: 39758 RVA: 0x0028AA0A File Offset: 0x00288C0A
	private void RefreshScore()
	{
		base.GetText(8).SetText(this.CurrentShowData.CurrentScore.ToString(), true);
	}

	// Token: 0x06009B4F RID: 39759 RVA: 0x0028AA29 File Offset: 0x00288C29
	private void OnClickContinueButton()
	{
		ControllerBase<ActivityRunController>.Instance.RequestTransToParkourChallenge(this.CurrentShowData.CurrentChallengeId);
	}

	// Token: 0x06009B50 RID: 39760 RVA: 0x0028AA40 File Offset: 0x00288C40
	private void OnClickBtnLeave()
	{
		base.CloseMe(null);
	}

	// Token: 0x04004773 RID: 18291
	private const int LEAVETIME = 30;

	// Token: 0x04004774 RID: 18292
	private const string SUCCESS_OUTLINE_COLOR = "CC9548FF";

	// Token: 0x04004775 RID: 18293
	private const string TARGET_ICON_PATH = "/Game/Aki/UI/UIResources/Common/Image/IconForceLogo/T_Logo_10_UI.T_Logo_10_UI";

	// Token: 0x04004776 RID: 18294
	[Nullable(2)]
	private TimerHandle AutoLeaveTimerId;

	// Token: 0x04004777 RID: 18295
	[Nullable(2)]
	private RunEndData CurrentShowData;

	// Token: 0x04004778 RID: 18296
	[Nullable(new byte[]
	{
		2,
		1
	})]
	protected Dictionary<int, ActivityParkourButton> ButtonMap;

	// Token: 0x02007954 RID: 31060
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x04029AE1 RID: 170721
		public const int TxtTitle = 1;

		// Token: 0x04029AE2 RID: 170722
		public const int TexIcon = 2;

		// Token: 0x04029AE3 RID: 170723
		public const int ButtonHorizontalItem = 4;

		// Token: 0x04029AE4 RID: 170724
		public const int ButtonItem = 5;

		// Token: 0x04029AE5 RID: 170725
		public const int ScoreText = 8;

		// Token: 0x04029AE6 RID: 170726
		public const int NewRecordItem = 9;

		// Token: 0x04029AE7 RID: 170727
		public const int PassTimeText = 10;

		// Token: 0x04029AE8 RID: 170728
		public const int PassTimeDescText = 11;

		// Token: 0x04029AE9 RID: 170729
		public const int PnlRecord = 12;

		// Token: 0x04029AEA RID: 170730
		public const int PnlPassTime = 13;

		// Token: 0x04029AEB RID: 170731
		public const int TxtFailTip = 14;
	}

	// Token: 0x02007955 RID: 31061
	[NullableContext(0)]
	private class EButtons
	{
		// Token: 0x04029AEC RID: 170732
		public const int LeftButton = 0;

		// Token: 0x04029AED RID: 170733
		public const int RightButton = 1;
	}
}
