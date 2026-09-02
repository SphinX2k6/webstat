using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001736 RID: 5942
public class ActivitySevenDaySignView : ActivitySubViewBase
{
	// Token: 0x0600A5ED RID: 42477 RVA: 0x002BE598 File Offset: 0x002BC798
	protected unsafe override void OnRegisterComponent()
	{
		int num = 11;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnClickLook));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600A5EE RID: 42478 RVA: 0x002BE76C File Offset: 0x002BC96C
	protected override UniTask OnBeforeStartAsync()
	{
		ActivitySevenDaySignView.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ActivitySevenDaySignView.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600A5EF RID: 42479 RVA: 0x002BE7B0 File Offset: 0x002BC9B0
	protected override void OnBeforeShow()
	{
		foreach (SignRewardItemBase child in this.ItemList)
		{
			base.AddChild(child);
		}
	}

	// Token: 0x0600A5F0 RID: 42480 RVA: 0x002BE7DD File Offset: 0x002BC9DD
	protected override void OnSetData()
	{
		this.ActivitySignData = (this.ActivityBaseData as ActivitySevenDaySignData);
	}

	// Token: 0x0600A5F1 RID: 42481 RVA: 0x002BE7F0 File Offset: 0x002BC9F0
	protected override void OnTimer(float gap)
	{
		ValueTuple<bool, string, long> timeVisibleAndRemainTime = this.GetTimeVisibleAndRemainTime();
		bool item = timeVisibleAndRemainTime.Item1;
		string item2 = timeVisibleAndRemainTime.Item2;
		base.GetText(1).SetUIActive(item);
		if (item)
		{
			base.GetText(1).SetText(item2, true);
		}
	}

	// Token: 0x0600A5F2 RID: 42482 RVA: 0x002BE830 File Offset: 0x002BCA30
	protected override void OnBeforeDestroy()
	{
		foreach (SignRewardItemBase child in this.ItemList)
		{
			base.AddChild(child);
		}
	}

	// Token: 0x0600A5F3 RID: 42483 RVA: 0x002BE860 File Offset: 0x002BCA60
	[NullableContext(1)]
	private string GetDesc()
	{
		return ConfigMultiTextLang.GetLocalTextNew(this.ActivitySignData.LocalConfig.Value.Desc, null);
	}

	// Token: 0x0600A5F4 RID: 42484 RVA: 0x002BE88B File Offset: 0x002BCA8B
	protected override void OnRefreshView()
	{
		base.GetText(0).SetText(this.ActivitySignData.GetTitle(), true);
		base.GetText(2).SetText(this.GetDesc(), true);
		this.RefreshReward();
	}

	// Token: 0x0600A5F5 RID: 42485 RVA: 0x002BE8C0 File Offset: 0x002BCAC0
	private void RefreshReward()
	{
		this.OnTimer(1f);
		for (int i = 0; i < 7; i++)
		{
			OneItemConfig[] rewardByDay = this.ActivitySignData.GetRewardByDay(i);
			SignState? rewardStateByDay = this.ActivitySignData.GetRewardStateByDay(i);
			OneItemConfig data = rewardByDay[0];
			SignRewardItemBase signRewardItemBase = this.ItemList[i];
			if (signRewardItemBase != null)
			{
				signRewardItemBase.RefreshByData(data, rewardStateByDay.Value, i);
			}
		}
		bool flag = this.ActivitySignData.GetImportantRewardType() != 0;
		UUIButtonComponent button = base.GetButton(3);
		if (button != null)
		{
			button.RootUIComp.Get().SetUIActive(flag);
		}
		UUIButtonComponent button2 = base.GetButton(3);
		if (button2 == null)
		{
			return;
		}
		button2.RootUIComp.Get().SetRaycastTarget(flag);
	}

	// Token: 0x0600A5F6 RID: 42486 RVA: 0x002BE974 File Offset: 0x002BCB74
	private bool IsRewardCanGet(int day)
	{
		return this.ActivitySignData.GetRewardStateByDay(day).GetValueOrDefault() == SignState.Unlock;
	}

	// Token: 0x0600A5F7 RID: 42487 RVA: 0x002BE998 File Offset: 0x002BCB98
	private void OnClickToGetReward(int index)
	{
		if (this.IsRewardCanGet(index))
		{
			ControllerBase<ActivitySevenDaySignController>.Instance.GetRewardByDay(this.ActivitySignData.Id, index);
			return;
		}
		if (index == this.ActivitySignData.GetImportantItemIndex())
		{
			this.OnClickLook();
		}
	}

	// Token: 0x0600A5F8 RID: 42488 RVA: 0x002BE9D0 File Offset: 0x002BCBD0
	private void OnClickLook()
	{
		ActivitySign? activitySignById = ConfigBase<ActivitySevenDaySignConfig>.Instance.GetActivitySignById(this.ActivitySignData.Id);
		int importantRewardType = activitySignById.Value.ImportantRewardType;
		if (importantRewardType == 1)
		{
			ControllerBase<RoleController>.Instance.OpenRoleMainView(ERoleAgentType.Preview, 0, activitySignById.Value.PreviewListIter().ToList<int>(), null, null);
			return;
		}
		if (importantRewardType != 2)
		{
			return;
		}
		List<WeaponTrialData> list = new List<WeaponTrialData>();
		foreach (int trialId in activitySignById.Value.PreviewList())
		{
			WeaponTrialData weaponTrialData = new WeaponTrialData();
			weaponTrialData.SetTrialId(trialId, true);
			list.Add(weaponTrialData);
		}
		WeaponPreviewViewParam weaponPreviewViewParam = new WeaponPreviewViewParam();
		WeaponDataBase[] weaponDataList = list.ToArray();
		weaponPreviewViewParam.WeaponDataList = weaponDataList;
		weaponPreviewViewParam.SelectedIndex = 0;
		WeaponPreviewViewParam param = weaponPreviewViewParam;
		Singleton<UiManager>.Instance.OpenView(EUiViewName.WeaponPreviewView, param, null);
	}

	// Token: 0x04004EAA RID: 20138
	private const int ITEM_START_INDEX = 4;

	// Token: 0x04004EAB RID: 20139
	private const int SIGN_DAY_COUNT = 7;

	// Token: 0x04004EAC RID: 20140
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private SignRewardItemBase[] ItemList;

	// Token: 0x04004EAD RID: 20141
	[Nullable(2)]
	private ActivitySevenDaySignData ActivitySignData;

	// Token: 0x02007A8F RID: 31375
	private class EMainSignInComponents
	{
		// Token: 0x04029FD4 RID: 171988
		public const int TxtTitle = 0;

		// Token: 0x04029FD5 RID: 171989
		public const int TxtTime = 1;

		// Token: 0x04029FD6 RID: 171990
		public const int TxtInfo = 2;

		// Token: 0x04029FD7 RID: 171991
		public const int BtnLook = 3;

		// Token: 0x04029FD8 RID: 171992
		public const int ItemOne = 4;

		// Token: 0x04029FD9 RID: 171993
		public const int ItemTwo = 5;

		// Token: 0x04029FDA RID: 171994
		public const int ItemThree = 6;

		// Token: 0x04029FDB RID: 171995
		public const int ItemFour = 7;

		// Token: 0x04029FDC RID: 171996
		public const int ItemFive = 8;

		// Token: 0x04029FDD RID: 171997
		public const int ItemSix = 9;

		// Token: 0x04029FDE RID: 171998
		public const int ItemSeven = 10;
	}
}
