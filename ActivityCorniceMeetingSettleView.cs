using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Protocol;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020012B1 RID: 4785
[NullableContext(1)]
[Nullable(0)]
public class ActivityCorniceMeetingSettleView : UiViewBase
{
	// Token: 0x06008069 RID: 32873 RVA: 0x0021E9F4 File Offset: 0x0021CBF4
	public ActivityCorniceMeetingSettleView(UiViewInfo info) : base(info)
	{
	}

	// Token: 0x0600806A RID: 32874 RVA: 0x0021EA00 File Offset: 0x0021CC00
	protected unsafe override void OnRegisterComponent()
	{
		int num = 5;
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
		*span[num2] = new ValueTuple<int, Type>(20, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600806B RID: 32875 RVA: 0x0021EAD0 File Offset: 0x0021CCD0
	protected override UniTask OnBeforeStartAsync()
	{
		ActivityCorniceMeetingSettleView.<OnBeforeStartAsync>d__15 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ActivityCorniceMeetingSettleView.<OnBeforeStartAsync>d__15>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600806C RID: 32876 RVA: 0x0021EB13 File Offset: 0x0021CD13
	protected override void OnBeforeShow()
	{
		this.InitAutoLeaveTimer();
		this.RefreshTitle();
	}

	// Token: 0x0600806D RID: 32877 RVA: 0x0021EB21 File Offset: 0x0021CD21
	protected override void OnBeforeDestroy()
	{
		this.ClearAutoLeaveTimer();
	}

	// Token: 0x0600806E RID: 32878 RVA: 0x0021EB2C File Offset: 0x0021CD2C
	protected void RefreshTitle()
	{
		if (this.Data == null)
		{
			return;
		}
		UUIText text = base.GetText(1);
		UUITexture texture = base.GetTexture(2);
		UUIEffectOutline uuieffectOutline = text.GetOwner().GetComponentByClass(UUIEffectOutline.StaticClass()) as UUIEffectOutline;
		base.SetTextureByPath("/Game/Aki/UI/UIResources/Common/Image/IconForceLogo/T_Logo_12_UI.T_Logo_12_UI", texture, null, null);
		if (this.Data.Score > 0)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "CorniceMeetingSettleSuccess", Array.Empty<object>());
			text.outlineColor = FColor.FromHex("C48B29FF");
			texture.SetColor(FColor.FromHex("8C754D7F"));
			uuieffectOutline.SetOutlineColor(FColor.FromHex("C48B29FF"));
			text.SetColor(FColor.FromHex("f2efd5"));
			RewardExploreDescription rewardExploreDescription = this.RewardExploreDescription;
			if (rewardExploreDescription != null)
			{
				rewardExploreDescription.SetUiActive(false);
			}
			base.PlaySequence("Success", null, false);
			return;
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "GenericPromptTypes_4_GeneralText", Array.Empty<object>());
		texture.SetColor(FColor.FromHex("6e363f"));
		text.SetColor(FColor.FromHex("F08086FF"));
		text.outlineColor = FColor.FromHex("B33100FF");
		uuieffectOutline.SetOutlineColor(FColor.FromHex("B33100FF"));
		RewardExploreDescription rewardExploreDescription2 = this.RewardExploreDescription;
		if (rewardExploreDescription2 != null)
		{
			rewardExploreDescription2.SetUiActive(true);
		}
		base.PlaySequence("Fail", null, false);
	}

	// Token: 0x0600806F RID: 32879 RVA: 0x0021EC7A File Offset: 0x0021CE7A
	private void ClearAutoLeaveTimer()
	{
		if (TimerSystem.GameplayTimeInstance.Has(this.AutoLeaveTimerId))
		{
			TimerSystem.GameplayTimeInstance.Remove(this.AutoLeaveTimerId);
		}
		this.AutoLeaveTimerId = null;
	}

	// Token: 0x06008070 RID: 32880 RVA: 0x0021ECA6 File Offset: 0x0021CEA6
	private void OnClickContinueButton()
	{
		base.CloseMe(delegate(bool success)
		{
			if (success)
			{
				ControllerBase<ActivityCorniceMeetingController>.Instance.CorniceMeetingChallengeTransRequest(this.Data.LevelPlayId);
			}
		});
	}

	// Token: 0x06008071 RID: 32881 RVA: 0x0021ECBA File Offset: 0x0021CEBA
	private void OnClickBtnLeave()
	{
		base.CloseMe(null);
	}

	// Token: 0x06008072 RID: 32882 RVA: 0x0021ECC4 File Offset: 0x0021CEC4
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

	// Token: 0x06008073 RID: 32883 RVA: 0x0021ED10 File Offset: 0x0021CF10
	private UniTask InitButtonAsync()
	{
		ActivityCorniceMeetingSettleView.<InitButtonAsync>d__23 <InitButtonAsync>d__;
		<InitButtonAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitButtonAsync>d__.<>4__this = this;
		<InitButtonAsync>d__.<>1__state = -1;
		<InitButtonAsync>d__.<>t__builder.Start<ActivityCorniceMeetingSettleView.<InitButtonAsync>d__23>(ref <InitButtonAsync>d__);
		return <InitButtonAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06008074 RID: 32884 RVA: 0x0021ED54 File Offset: 0x0021CF54
	private UniTask CreateButton(UUIItem uiItem, int buttonIndex, Action clickFunction)
	{
		ActivityCorniceMeetingSettleView.<CreateButton>d__24 <CreateButton>d__;
		<CreateButton>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateButton>d__.<>4__this = this;
		<CreateButton>d__.buttonIndex = buttonIndex;
		<CreateButton>d__.clickFunction = clickFunction;
		<CreateButton>d__.<>1__state = -1;
		<CreateButton>d__.<>t__builder.Start<ActivityCorniceMeetingSettleView.<CreateButton>d__24>(ref <CreateButton>d__);
		return <CreateButton>d__.<>t__builder.Task;
	}

	// Token: 0x04003D45 RID: 15685
	private const int LEAVETIME = 30;

	// Token: 0x04003D46 RID: 15686
	private const string ICON_PATH = "/Game/Aki/UI/UIResources/Common/Image/IconForceLogo/T_Logo_12_UI.T_Logo_12_UI";

	// Token: 0x04003D47 RID: 15687
	private const string SUCCESS_OUTLINE_COLOR = "C48B29FF";

	// Token: 0x04003D48 RID: 15688
	private const string FAIL_OUTLINE_COLOR = "B33100FF";

	// Token: 0x04003D49 RID: 15689
	private const string FAIL_TEXT_COLOR = "F08086FF";

	// Token: 0x04003D4A RID: 15690
	private const string SUCCESS_TEXT_COLOR = "f2efd5";

	// Token: 0x04003D4B RID: 15691
	protected Dictionary<int, ActivityCorniceMeetingButton> ButtonMap;

	// Token: 0x04003D4C RID: 15692
	[Nullable(2)]
	private TimerHandle AutoLeaveTimerId;

	// Token: 0x04003D4D RID: 15693
	protected CorniceChallengeEndNotify Data;

	// Token: 0x04003D4E RID: 15694
	protected ActivityCorniceMeetingSettleDetailPanel DetailPanel;

	// Token: 0x04003D4F RID: 15695
	protected RewardExploreDescription RewardExploreDescription;

	// Token: 0x02007625 RID: 30245
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x04028BA2 RID: 166818
		public const int TxtTitle = 1;

		// Token: 0x04028BA3 RID: 166819
		public const int TextureIcon = 2;

		// Token: 0x04028BA4 RID: 166820
		public const int ButtonHorizontalItem = 4;

		// Token: 0x04028BA5 RID: 166821
		public const int ButtonItem = 5;

		// Token: 0x04028BA6 RID: 166822
		public const int Content = 20;
	}

	// Token: 0x02007626 RID: 30246
	[NullableContext(0)]
	private class EButtons
	{
		// Token: 0x04028BA7 RID: 166823
		public const int LeftButton = 0;

		// Token: 0x04028BA8 RID: 166824
		public const int RightButton = 1;
	}
}
