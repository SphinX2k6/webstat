using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200158A RID: 5514
[NullableContext(1)]
[Nullable(0)]
public class ActivityRunFailView : UiViewBase
{
	// Token: 0x06009B0E RID: 39694 RVA: 0x00289A8C File Offset: 0x00287C8C
	public ActivityRunFailView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06009B0F RID: 39695 RVA: 0x00289A98 File Offset: 0x00287C98
	protected unsafe override void OnRegisterComponent()
	{
		int num = 14;
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
		num2++;
		*span[num2] = new ValueTuple<int, Type>(15, typeof(UUINiagara));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(16, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(17, typeof(UUITexture));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06009B10 RID: 39696 RVA: 0x00289C98 File Offset: 0x00287E98
	protected override UniTask OnBeforeStartAsync()
	{
		ActivityRunFailView.<OnBeforeStartAsync>d__10 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ActivityRunFailView.<OnBeforeStartAsync>d__10>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06009B11 RID: 39697 RVA: 0x00289CDB File Offset: 0x00287EDB
	protected override void OnStart()
	{
		this.CurrentShowData = (this.OpenParam as RunEndData);
		this.InitAutoLeaveTimer();
	}

	// Token: 0x06009B12 RID: 39698 RVA: 0x00289CF4 File Offset: 0x00287EF4
	protected override void OnBeforeShow()
	{
		base.GetItem(12).SetUIActive(false);
		base.GetItem(13).SetUIActive(false);
		base.GetTexture(16).SetUIActive(false);
		base.GetTexture(17).SetUIActive(false);
		base.GetText(14).SetUIActive(true);
		UUINiagara uiNiagara = base.GetUiNiagara(15);
		if (uiNiagara != null)
		{
			uiNiagara.SetUIActive(false);
		}
		this.RefreshHead();
	}

	// Token: 0x06009B13 RID: 39699 RVA: 0x00289D64 File Offset: 0x00287F64
	private void RefreshHead()
	{
		UUITexture texture = base.GetTexture(2);
		texture.SetColor(FColor.FromHex("63323AFF"));
		base.SetTextureByPath("/Game/Aki/UI/UIResources/Common/Image/IconForceLogo/T_Logo_10_UI.T_Logo_10_UI", texture, null, null);
		base.GetText(1).ShowTextNew("GenericPromptTypes_4_GeneralText");
	}

	// Token: 0x06009B14 RID: 39700 RVA: 0x00289DB0 File Offset: 0x00287FB0
	private UniTask InitButtonAsync()
	{
		ActivityRunFailView.<InitButtonAsync>d__14 <InitButtonAsync>d__;
		<InitButtonAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitButtonAsync>d__.<>4__this = this;
		<InitButtonAsync>d__.<>1__state = -1;
		<InitButtonAsync>d__.<>t__builder.Start<ActivityRunFailView.<InitButtonAsync>d__14>(ref <InitButtonAsync>d__);
		return <InitButtonAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06009B15 RID: 39701 RVA: 0x00289DF3 File Offset: 0x00287FF3
	private void ClearAutoLeaveTimer()
	{
		if (TimerSystem.GameplayTimeInstance.Has(this.AutoLeaveTimerId))
		{
			TimerSystem.GameplayTimeInstance.Remove(this.AutoLeaveTimerId);
		}
		this.AutoLeaveTimerId = null;
	}

	// Token: 0x06009B16 RID: 39702 RVA: 0x00289E20 File Offset: 0x00288020
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

	// Token: 0x06009B17 RID: 39703 RVA: 0x00289E6B File Offset: 0x0028806B
	protected override void OnBeforeDestroy()
	{
		UUINiagara uiNiagara = base.GetUiNiagara(15);
		if (uiNiagara != null)
		{
			uiNiagara.SetUIActive(true);
		}
		base.GetTexture(16).SetUIActive(true);
		base.GetTexture(17).SetUIActive(true);
		this.ClearAutoLeaveTimer();
	}

	// Token: 0x06009B18 RID: 39704 RVA: 0x00289EA4 File Offset: 0x002880A4
	private UniTask CreateButton(UUIItem uiItem, int buttonIndex, Action clickFunction)
	{
		ActivityRunFailView.<CreateButton>d__18 <CreateButton>d__;
		<CreateButton>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateButton>d__.<>4__this = this;
		<CreateButton>d__.buttonIndex = buttonIndex;
		<CreateButton>d__.clickFunction = clickFunction;
		<CreateButton>d__.<>1__state = -1;
		<CreateButton>d__.<>t__builder.Start<ActivityRunFailView.<CreateButton>d__18>(ref <CreateButton>d__);
		return <CreateButton>d__.<>t__builder.Task;
	}

	// Token: 0x06009B19 RID: 39705 RVA: 0x00289EF7 File Offset: 0x002880F7
	private void OnClickContinueButton()
	{
		ControllerBase<ActivityRunController>.Instance.RequestTransToParkourChallenge(this.CurrentShowData.CurrentChallengeId);
	}

	// Token: 0x06009B1A RID: 39706 RVA: 0x00289F0E File Offset: 0x0028810E
	private void OnClickBtnLeave()
	{
		base.CloseMe(null);
	}

	// Token: 0x04004761 RID: 18273
	private const int LEAVETIME = 30;

	// Token: 0x04004762 RID: 18274
	private const string FAIL_OUTLINE_COLOR = "63323AFF";

	// Token: 0x04004763 RID: 18275
	private const string TARGET_ICON_PATH = "/Game/Aki/UI/UIResources/Common/Image/IconForceLogo/T_Logo_10_UI.T_Logo_10_UI";

	// Token: 0x04004764 RID: 18276
	[Nullable(2)]
	private TimerHandle AutoLeaveTimerId;

	// Token: 0x04004765 RID: 18277
	[Nullable(2)]
	private RunEndData CurrentShowData;

	// Token: 0x04004766 RID: 18278
	[Nullable(new byte[]
	{
		2,
		1
	})]
	protected Dictionary<int, ActivityParkourButton> ButtonMap;

	// Token: 0x0200794D RID: 31053
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x04029ABA RID: 170682
		public const int TxtTitle = 1;

		// Token: 0x04029ABB RID: 170683
		public const int TexIcon = 2;

		// Token: 0x04029ABC RID: 170684
		public const int ButtonHorizontalItem = 4;

		// Token: 0x04029ABD RID: 170685
		public const int ButtonItem = 5;

		// Token: 0x04029ABE RID: 170686
		public const int ScoreText = 8;

		// Token: 0x04029ABF RID: 170687
		public const int NewRecordItem = 9;

		// Token: 0x04029AC0 RID: 170688
		public const int PassTimeText = 10;

		// Token: 0x04029AC1 RID: 170689
		public const int PassTimeDescText = 11;

		// Token: 0x04029AC2 RID: 170690
		public const int PnlRecord = 12;

		// Token: 0x04029AC3 RID: 170691
		public const int PnlPassTime = 13;

		// Token: 0x04029AC4 RID: 170692
		public const int Desc = 14;

		// Token: 0x04029AC5 RID: 170693
		public const int TitleNia = 15;

		// Token: 0x04029AC6 RID: 170694
		public const int TexTitleBgL = 16;

		// Token: 0x04029AC7 RID: 170695
		public const int TexTitleBgR = 17;
	}

	// Token: 0x0200794E RID: 31054
	[NullableContext(0)]
	private class EButtons
	{
		// Token: 0x04029AC8 RID: 170696
		public const int LeftButton = 0;

		// Token: 0x04029AC9 RID: 170697
		public const int RightButton = 1;
	}
}
