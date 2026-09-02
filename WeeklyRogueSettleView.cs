using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002D52 RID: 11602
public class WeeklyRogueSettleView : UiViewBase
{
	// Token: 0x0601768D RID: 95885 RVA: 0x0067DD2F File Offset: 0x0067BF2F
	[NullableContext(1)]
	public WeeklyRogueSettleView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0601768E RID: 95886 RVA: 0x0067DD38 File Offset: 0x0067BF38
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUITexture)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(20, typeof(UUIItem))
		};
	}

	// Token: 0x0601768F RID: 95887 RVA: 0x0067DDC0 File Offset: 0x0067BFC0
	protected override UniTask OnBeforeStartAsync()
	{
		WeeklyRogueSettleView.<OnBeforeStartAsync>d__9 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<WeeklyRogueSettleView.<OnBeforeStartAsync>d__9>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06017690 RID: 95888 RVA: 0x0067DE03 File Offset: 0x0067C003
	protected override void OnBeforeShow()
	{
		this.InitAutoLeaveTimer();
		this.RefreshTitle();
	}

	// Token: 0x06017691 RID: 95889 RVA: 0x0067DE11 File Offset: 0x0067C011
	protected override void OnBeforeDestroy()
	{
		this.ClearAutoLeaveTimer();
	}

	// Token: 0x06017692 RID: 95890 RVA: 0x0067DE1C File Offset: 0x0067C01C
	protected void RefreshTitle()
	{
		if (this.Data == null)
		{
			return;
		}
		UUIText text = base.GetText(1);
		UUITexture texture = base.GetTexture(2);
		if (texture != null)
		{
			texture.SetUIActive(false);
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "Text_ChallengeFinish_Text", Array.Empty<object>());
		base.PlaySequence("Success", null, false);
	}

	// Token: 0x06017693 RID: 95891 RVA: 0x0067DE6F File Offset: 0x0067C06F
	private void ClearAutoLeaveTimer()
	{
		if (TimerSystem.GameplayTimeInstance.Has(this.AutoLeaveTimerId))
		{
			TimerSystem.GameplayTimeInstance.Remove(this.AutoLeaveTimerId);
		}
		this.AutoLeaveTimerId = null;
	}

	// Token: 0x06017694 RID: 95892 RVA: 0x0067DE9B File Offset: 0x0067C09B
	private void OnClickBtnLeave()
	{
		WeeklyRogueController instance = ControllerBase<WeeklyRogueController>.Instance;
		if (instance != null)
		{
			instance.MarkAutoOpenDailyActivityWeekly();
		}
		base.CloseMe(delegate(bool success)
		{
			if (success)
			{
				ControllerBase<InstanceDungeonEntranceController>.Instance.LeaveInstanceDungeon();
			}
		});
	}

	// Token: 0x06017695 RID: 95893 RVA: 0x0067DED4 File Offset: 0x0067C0D4
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
			ActivityCorniceMeetingButton activityCorniceMeetingButton = this.ButtonMap[0];
			string textId = "InstanceDungeonLeftTimeToAutoLeave";
			string[] array = new string[1];
			int num = 0;
			leftSecondToAutoLeave = leftSecondToAutoLeave;
			leftSecondToAutoLeave--;
			array[num] = leftSecondToAutoLeave.ToString();
			activityCorniceMeetingButton.SetFloatText(textId, array);
		}, 1000f, 1f, null, null, true);
	}

	// Token: 0x06017696 RID: 95894 RVA: 0x0067DF20 File Offset: 0x0067C120
	private UniTask InitButtonAsync()
	{
		WeeklyRogueSettleView.<InitButtonAsync>d__16 <InitButtonAsync>d__;
		<InitButtonAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitButtonAsync>d__.<>4__this = this;
		<InitButtonAsync>d__.<>1__state = -1;
		<InitButtonAsync>d__.<>t__builder.Start<WeeklyRogueSettleView.<InitButtonAsync>d__16>(ref <InitButtonAsync>d__);
		return <InitButtonAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06017697 RID: 95895 RVA: 0x0067DF64 File Offset: 0x0067C164
	[NullableContext(1)]
	private UniTask CreateButton(UUIItem uiItem, WeeklyRogueSettleView.EButtons buttonIndex, Action clickFunction)
	{
		WeeklyRogueSettleView.<CreateButton>d__17 <CreateButton>d__;
		<CreateButton>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateButton>d__.<>4__this = this;
		<CreateButton>d__.buttonIndex = buttonIndex;
		<CreateButton>d__.clickFunction = clickFunction;
		<CreateButton>d__.<>1__state = -1;
		<CreateButton>d__.<>t__builder.Start<WeeklyRogueSettleView.<CreateButton>d__17>(ref <CreateButton>d__);
		return <CreateButton>d__.<>t__builder.Task;
	}

	// Token: 0x0400B3A0 RID: 45984
	private const int LEAVETIME = 30;

	// Token: 0x0400B3A1 RID: 45985
	[Nullable(new byte[]
	{
		2,
		1
	})]
	protected Dictionary<int, ActivityCorniceMeetingButton> ButtonMap;

	// Token: 0x0400B3A2 RID: 45986
	[Nullable(2)]
	private TimerHandle AutoLeaveTimerId;

	// Token: 0x0400B3A3 RID: 45987
	[Nullable(2)]
	protected RogueWeeklyResultNotify Data;

	// Token: 0x0400B3A4 RID: 45988
	[Nullable(2)]
	protected WeeklyRogueSettleInfoPanel InfoPanel;

	// Token: 0x02009023 RID: 36899
	private enum EComponents
	{
		// Token: 0x040305BC RID: 198076
		TxtTitle = 1,
		// Token: 0x040305BD RID: 198077
		TextureIcon,
		// Token: 0x040305BE RID: 198078
		ButtonHorizontalItem = 4,
		// Token: 0x040305BF RID: 198079
		ButtonItem,
		// Token: 0x040305C0 RID: 198080
		Content = 20
	}

	// Token: 0x02009024 RID: 36900
	private enum EButtons
	{
		// Token: 0x040305C2 RID: 198082
		LeftButton,
		// Token: 0x040305C3 RID: 198083
		RightButton
	}
}
