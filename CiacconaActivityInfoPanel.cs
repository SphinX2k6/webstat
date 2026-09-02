using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.CiacconaGal;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001297 RID: 4759
[NullableContext(1)]
[Nullable(0)]
public class CiacconaActivityInfoPanel : UiPanelBase
{
	// Token: 0x06007F6A RID: 32618 RVA: 0x0021A9D5 File Offset: 0x00218BD5
	public CiacconaActivityInfoPanel(ActivityBaseData activityBaseData)
	{
		this.ActivityBaseData = activityBaseData;
	}

	// Token: 0x06007F6B RID: 32619 RVA: 0x0021A9E4 File Offset: 0x00218BE4
	protected unsafe override void OnRegisterComponent()
	{
		int num = 4;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06007F6C RID: 32620 RVA: 0x0021AA90 File Offset: 0x00218C90
	protected override UniTask OnBeforeStartAsync()
	{
		CiacconaActivityInfoPanel.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<CiacconaActivityInfoPanel.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06007F6D RID: 32621 RVA: 0x0021AAD3 File Offset: 0x00218CD3
	protected override void OnBeforeShow()
	{
		this.RefreshFunctionArea();
	}

	// Token: 0x06007F6E RID: 32622 RVA: 0x0021AADC File Offset: 0x00218CDC
	public void RefreshFunctionArea()
	{
		CiacconaGalActivityData activityDataById = ModelBase<CiacconaGalModel>.Instance.GetActivityDataById(this.ActivityBaseData.Id);
		ActivityFunctionAreaParams parameters = new ActivityFunctionAreaParams
		{
			UnlockBtnFunction = new Action(this.OnBtnConfirmClick),
			UnlockBtnTextId = (activityDataById.State2Unlock ? "XKAVG_SystemTitle_17" : "XKAVG_SystemTitle_16")
		};
		ActivityFunctionalTypeA bottomItem = this.BottomItem;
		if (bottomItem != null)
		{
			bottomItem.RefreshGeneralPerformance(parameters);
		}
		bool flag = ModelBase<CiacconaGalModel>.Instance.HasAnyEndingReward();
		bool flag2 = ModelBase<CiacconaGalModel>.Instance.HasAnyProgressReward();
		bool flag3 = ModelBase<CiacconaGalModel>.Instance.HasAnySubEndingReward();
		ActivityFunctionalTypeA bottomItem2 = this.BottomItem;
		if (bottomItem2 == null)
		{
			return;
		}
		bottomItem2.SetFunctionRedDotVisible(flag || flag2 || flag3);
	}

	// Token: 0x06007F6F RID: 32623 RVA: 0x0021AB7B File Offset: 0x00218D7B
	public void SetTimer(bool visible, string text)
	{
		ActivityTitleTypeA commonActivityTitle = this.CommonActivityTitle;
		if (commonActivityTitle != null)
		{
			commonActivityTitle.SetTimeTextVisible(visible);
		}
		ActivityTitleTypeA commonActivityTitle2 = this.CommonActivityTitle;
		if (commonActivityTitle2 == null)
		{
			return;
		}
		commonActivityTitle2.SetTimeTextByText(text);
	}

	// Token: 0x06007F70 RID: 32624 RVA: 0x0021ABA0 File Offset: 0x00218DA0
	public void SetTitle(string text)
	{
		ActivityTitleTypeA commonActivityTitle = this.CommonActivityTitle;
		if (commonActivityTitle != null)
		{
			commonActivityTitle.SetActivityBaseData(this.ActivityBaseData);
		}
		ActivityTitleTypeA commonActivityTitle2 = this.CommonActivityTitle;
		if (commonActivityTitle2 == null)
		{
			return;
		}
		commonActivityTitle2.SetTitleByText(text);
	}

	// Token: 0x06007F71 RID: 32625 RVA: 0x0021ABCA File Offset: 0x00218DCA
	public void SetSubTitle(bool visible, string text)
	{
		ActivityTitleTypeA commonActivityTitle = this.CommonActivityTitle;
		if (commonActivityTitle != null)
		{
			commonActivityTitle.SetSubTitleVisible(visible);
		}
		ActivityTitleTypeA commonActivityTitle2 = this.CommonActivityTitle;
		if (commonActivityTitle2 == null)
		{
			return;
		}
		commonActivityTitle2.SetSubTitleByText(text);
	}

	// Token: 0x06007F72 RID: 32626 RVA: 0x0021ABEF File Offset: 0x00218DEF
	public void SetDesc(bool visible, string text)
	{
		ActivityDescriptionTypeA commonActivityDesc = this.CommonActivityDesc;
		if (commonActivityDesc != null)
		{
			commonActivityDesc.SetContentVisible(visible);
		}
		ActivityDescriptionTypeA commonActivityDesc2 = this.CommonActivityDesc;
		if (commonActivityDesc2 == null)
		{
			return;
		}
		commonActivityDesc2.SetContentByTextId(text, Array.Empty<string>());
	}

	// Token: 0x06007F73 RID: 32627 RVA: 0x0021AC19 File Offset: 0x00218E19
	public void SetReward(bool visible, List<TItem> rewardList)
	{
		ActivityRewardList<CommonItemSmallItemGrid, TItem> commonActivityReward = this.CommonActivityReward;
		if (commonActivityReward != null)
		{
			commonActivityReward.SetUiActive(visible);
		}
		ActivityRewardList<CommonItemSmallItemGrid, TItem> commonActivityReward2 = this.CommonActivityReward;
		if (commonActivityReward2 == null)
		{
			return;
		}
		commonActivityReward2.RefreshItemLayout(rewardList, null);
	}

	// Token: 0x06007F74 RID: 32628 RVA: 0x0021AC40 File Offset: 0x00218E40
	private void OnBtnConfirmClick()
	{
		int unFinishPreGuideQuestId = this.ActivityBaseData.GetUnFinishPreGuideQuestId();
		ECiacconaGalActivityState state = ModelBase<CiacconaGalModel>.Instance.GetActivityDataById(this.ActivityBaseData.Id).State;
		if (state != ECiacconaGalActivityState.Init)
		{
			if (state - ECiacconaGalActivityState.TaskFinish > 1)
			{
				return;
			}
			ControllerBase<CiacconaGalController>.Instance.OpenChapterEntryView(this.ActivityBaseData.Id, ECiacconaEntryType.FromActivity);
		}
		else if (unFinishPreGuideQuestId != 0)
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.QuestView, unFinishPreGuideQuestId, null);
			return;
		}
	}

	// Token: 0x06007F75 RID: 32629 RVA: 0x0021ACB0 File Offset: 0x00218EB0
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
	{
		if (configParams.Length == 0)
		{
			return null;
		}
		ActivityFunctionalTypeA bottomItem = this.BottomItem;
		UUIItem uuiitem;
		if (bottomItem == null)
		{
			uuiitem = null;
		}
		else
		{
			ActivityButtonItem functionButton = bottomItem.FunctionButton;
			uuiitem = ((functionButton != null) ? functionButton.GetRootItem() : null);
		}
		UUIItem uuiitem2 = uuiitem;
		if (uuiitem2 == null)
		{
			return null;
		}
		return new UUIItem[]
		{
			uuiitem2,
			uuiitem2
		};
	}

	// Token: 0x04003CF7 RID: 15607
	[Nullable(2)]
	private ActivityTitleTypeA CommonActivityTitle;

	// Token: 0x04003CF8 RID: 15608
	[Nullable(2)]
	private ActivityDescriptionTypeA CommonActivityDesc;

	// Token: 0x04003CF9 RID: 15609
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private ActivityRewardList<CommonItemSmallItemGrid, TItem> CommonActivityReward;

	// Token: 0x04003CFA RID: 15610
	[Nullable(2)]
	private ActivityFunctionalTypeA BottomItem;

	// Token: 0x04003CFB RID: 15611
	private ActivityBaseData ActivityBaseData;

	// Token: 0x02007613 RID: 30227
	[NullableContext(0)]
	private class EComponentDefine
	{
		// Token: 0x04028B52 RID: 166738
		public const int ItemCommonActivityTitle = 0;

		// Token: 0x04028B53 RID: 166739
		public const int ItemCommonActivityDesc = 1;

		// Token: 0x04028B54 RID: 166740
		public const int ItemCommonActivityReward = 2;

		// Token: 0x04028B55 RID: 166741
		public const int ItemCommonActivityBottom = 3;
	}
}
