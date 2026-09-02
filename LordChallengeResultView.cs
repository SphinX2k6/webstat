using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020021EE RID: 8686
[NullableContext(1)]
[Nullable(0)]
public class LordChallengeResultView : UiViewBase
{
	// Token: 0x06010611 RID: 67089 RVA: 0x00479EB9 File Offset: 0x004780B9
	public LordChallengeResultView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06010612 RID: 67090 RVA: 0x00479EC4 File Offset: 0x004780C4
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUITexture)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIText)),
			new ValueTuple<int, Type>(9, typeof(UUIItem)),
			new ValueTuple<int, Type>(10, typeof(UUIText)),
			new ValueTuple<int, Type>(11, typeof(UUIText)),
			new ValueTuple<int, Type>(12, typeof(UUIItem)),
			new ValueTuple<int, Type>(13, typeof(UUIItem)),
			new ValueTuple<int, Type>(14, typeof(UUIText))
		};
	}

	// Token: 0x06010613 RID: 67091 RVA: 0x00479FD4 File Offset: 0x004781D4
	protected override UniTask OnBeforeStartAsync()
	{
		LordChallengeResultView.<OnBeforeStartAsync>d__11 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<LordChallengeResultView.<OnBeforeStartAsync>d__11>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06010614 RID: 67092 RVA: 0x0047A018 File Offset: 0x00478218
	private UniTask InitButtonAsync()
	{
		LordChallengeResultView.<InitButtonAsync>d__12 <InitButtonAsync>d__;
		<InitButtonAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitButtonAsync>d__.<>4__this = this;
		<InitButtonAsync>d__.<>1__state = -1;
		<InitButtonAsync>d__.<>t__builder.Start<LordChallengeResultView.<InitButtonAsync>d__12>(ref <InitButtonAsync>d__);
		return <InitButtonAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06010615 RID: 67093 RVA: 0x0047A05C File Offset: 0x0047825C
	private UniTask CreateButton(UUIItem uiItem, int buttonIndex, string title, Action clickFunction)
	{
		LordChallengeResultView.<CreateButton>d__13 <CreateButton>d__;
		<CreateButton>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateButton>d__.<>4__this = this;
		<CreateButton>d__.buttonIndex = buttonIndex;
		<CreateButton>d__.title = title;
		<CreateButton>d__.clickFunction = clickFunction;
		<CreateButton>d__.<>1__state = -1;
		<CreateButton>d__.<>t__builder.Start<LordChallengeResultView.<CreateButton>d__13>(ref <CreateButton>d__);
		return <CreateButton>d__.<>t__builder.Task;
	}

	// Token: 0x06010616 RID: 67094 RVA: 0x0047A0B8 File Offset: 0x004782B8
	protected override void OnStart()
	{
		this.CurrentShowData = (this.OpenParam as IResultData);
	}

	// Token: 0x06010617 RID: 67095 RVA: 0x0047A0CB File Offset: 0x004782CB
	protected override void OnBeforeShow()
	{
		this.RefreshHead();
		this.RefreshScore();
		this.RefreshTime();
		this.InitAutoLeaveTimer();
	}

	// Token: 0x06010618 RID: 67096 RVA: 0x0047A0E5 File Offset: 0x004782E5
	private void ClearAutoLeaveTimer()
	{
		if (TimerSystem.GameplayTimeInstance.Has(this.AutoLeaveTimerId))
		{
			TimerSystem.GameplayTimeInstance.Remove(this.AutoLeaveTimerId);
		}
		this.AutoLeaveTimerId = null;
	}

	// Token: 0x06010619 RID: 67097 RVA: 0x0047A114 File Offset: 0x00478314
	private void InitAutoLeaveTimer()
	{
		int leftSecondToAutoLeave = this.CurrentShowData.AutoCloseTime + 1;
		this.AutoLeaveTimerId = TimerSystem.GameplayTimeInstance.Forever(delegate(float _)
		{
			int leftSecondToAutoLeave;
			if (leftSecondToAutoLeave <= 0)
			{
				TimerSystem.GameplayTimeInstance.Remove(this.AutoLeaveTimerId);
				this.OnClickBtnLeave();
				return;
			}
			LordChallengeResultButton valueOrDefault = this.ButtonMap.GetValueOrDefault(-1);
			string textId = "Text_InstanceDungeonLeftTimeToAutoLeave_Text";
			string[] array = new string[1];
			int num = 0;
			leftSecondToAutoLeave = leftSecondToAutoLeave;
			leftSecondToAutoLeave--;
			array[num] = leftSecondToAutoLeave.ToString();
			valueOrDefault.SetFloatText(textId, array);
		}, 1000f, 1f, null, null, true);
	}

	// Token: 0x0601061A RID: 67098 RVA: 0x0047A16C File Offset: 0x0047836C
	private void RefreshTime()
	{
		bool flag = this.CurrentShowData.PassTime != null;
		UUIItem item = base.GetItem(13);
		if (item != null)
		{
			item.SetUIActive(flag);
		}
		if (flag)
		{
			string timeString = Singleton<TimeUtil>.Instance.GetTimeString((double)this.CurrentShowData.PassTime.Value);
			base.GetText(10).SetText(timeString, true);
		}
	}

	// Token: 0x0601061B RID: 67099 RVA: 0x0047A1D4 File Offset: 0x004783D4
	private void RefreshScore()
	{
		IResultData currentShowData = this.CurrentShowData;
		bool flag = currentShowData != null && currentShowData.Score != null;
		UUIItem item = base.GetItem(12);
		if (item != null)
		{
			item.SetUIActive(flag);
		}
		if (flag)
		{
			base.GetText(8).SetText(this.CurrentShowData.Score.Value.ToString(), true);
			UUIItem item2 = base.GetItem(9);
			IResultData currentShowData2 = this.CurrentShowData;
			item2.SetUIActive(currentShowData2 != null && currentShowData2.IsNewRecord);
		}
	}

	// Token: 0x0601061C RID: 67100 RVA: 0x0047A25A File Offset: 0x0047845A
	protected override void OnBeforeDestroy()
	{
		this.ClearAutoLeaveTimer();
	}

	// Token: 0x0601061D RID: 67101 RVA: 0x0047A264 File Offset: 0x00478464
	private void RefreshHead()
	{
		IResultData currentShowData = this.CurrentShowData;
		bool flag = currentShowData != null && currentShowData.Result == EGamePlayResult.Success;
		base.GetItem(12).SetUIActive(flag);
		base.GetItem(13).SetUIActive(flag);
		base.GetText(14).SetUIActive(!flag);
		UUITexture texture = base.GetTexture(2);
		string path = flag ? "/Game/Aki/UI/UIResources/Common/Image/IconForceLogo/T_Logo_10_UI.T_Logo_10_UI" : "/Game/Aki/UI/UIResources/Common/Image/IconForceLogo/T_Logo_10_UI.T_Logo_10_UI";
		string hexStr = flag ? "C48B29FF" : "B33100FF";
		string textStringId = flag ? "GenericPromptTypes_3_GeneralText" : "GenericPromptTypes_4_GeneralText";
		texture.SetColor(FColor.FromHex(hexStr));
		base.SetTextureByPath(path, texture, null, null);
		UUIText text = base.GetText(1);
		text.SetColor(FColor.FromHex(hexStr));
		Singleton<LguiUtil>.Instance.SetLocalTextNew(text, textStringId, Array.Empty<object>());
	}

	// Token: 0x0601061E RID: 67102 RVA: 0x0047A335 File Offset: 0x00478535
	private void OnClickBtnLeave()
	{
		base.CloseMe(null);
	}

	// Token: 0x0400812D RID: 33069
	private const string SUCCESS_OUTLINE_COLOR = "C48B29FF";

	// Token: 0x0400812E RID: 33070
	private const string SUCCESS_TEX = "/Game/Aki/UI/UIResources/Common/Image/IconForceLogo/T_Logo_10_UI.T_Logo_10_UI";

	// Token: 0x0400812F RID: 33071
	private const string FAIL_OUTLINE_COLOR = "B33100FF";

	// Token: 0x04008130 RID: 33072
	private const string FAIL_TEX = "/Game/Aki/UI/UIResources/Common/Image/IconForceLogo/T_Logo_10_UI.T_Logo_10_UI";

	// Token: 0x04008131 RID: 33073
	private const int CLOSE_BUTTON_KEY = -1;

	// Token: 0x04008132 RID: 33074
	[Nullable(2)]
	private TimerHandle AutoLeaveTimerId;

	// Token: 0x04008133 RID: 33075
	[Nullable(2)]
	private IResultData CurrentShowData;

	// Token: 0x04008134 RID: 33076
	[Nullable(new byte[]
	{
		2,
		1
	})]
	protected Dictionary<int, LordChallengeResultButton> ButtonMap;

	// Token: 0x020084AD RID: 33965
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x0402CF2C RID: 184108
		public const int TxtTitle = 1;

		// Token: 0x0402CF2D RID: 184109
		public const int TexIcon = 2;

		// Token: 0x0402CF2E RID: 184110
		public const int ButtonHorizontalItem = 4;

		// Token: 0x0402CF2F RID: 184111
		public const int ButtonItem = 5;

		// Token: 0x0402CF30 RID: 184112
		public const int ScoreText = 8;

		// Token: 0x0402CF31 RID: 184113
		public const int NewRecordItem = 9;

		// Token: 0x0402CF32 RID: 184114
		public const int PassTimeText = 10;

		// Token: 0x0402CF33 RID: 184115
		public const int PassTimeDescText = 11;

		// Token: 0x0402CF34 RID: 184116
		public const int PnlRecord = 12;

		// Token: 0x0402CF35 RID: 184117
		public const int PnlPassTime = 13;

		// Token: 0x0402CF36 RID: 184118
		public const int TxtFailTip = 14;
	}
}
