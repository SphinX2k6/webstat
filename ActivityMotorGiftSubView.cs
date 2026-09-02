using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001424 RID: 5156
public class ActivityMotorGiftSubView : ActivitySubViewBase
{
	// Token: 0x06008EFF RID: 36607 RVA: 0x00258740 File Offset: 0x00256940
	protected unsafe override void OnRegisterComponent()
	{
		int num = 8;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnPreviewButtonClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06008F00 RID: 36608 RVA: 0x002588AC File Offset: 0x00256AAC
	protected override void OnSetData()
	{
		this.MotorGiftData = (this.ActivityBaseData as ActivityMotorGiftData);
	}

	// Token: 0x06008F01 RID: 36609 RVA: 0x002588C0 File Offset: 0x00256AC0
	protected override UniTask OnBeforeStartAsync()
	{
		ActivityMotorGiftSubView.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ActivityMotorGiftSubView.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06008F02 RID: 36610 RVA: 0x00258903 File Offset: 0x00256B03
	protected override void OnStart()
	{
		this.OnRefreshView();
	}

	// Token: 0x06008F03 RID: 36611 RVA: 0x0025890B File Offset: 0x00256B0B
	protected override void OnRefreshView()
	{
		this.RefreshMotorInfo();
		this.RefreshFinishState();
	}

	// Token: 0x06008F04 RID: 36612 RVA: 0x0025891C File Offset: 0x00256B1C
	private void RefreshMotorInfo()
	{
		ActivityMotorGiftData motorGiftData = this.MotorGiftData;
		MotorGeneralPreview? motorGeneralPreview = (motorGiftData != null) ? motorGiftData.GetMotorPreviewConfig() : null;
		if (motorGeneralPreview == null)
		{
			return;
		}
		MotorGeneralPreview value = motorGeneralPreview.Value;
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), value.Title, Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), value.SubTitle, Array.Empty<object>());
	}

	// Token: 0x06008F05 RID: 36613 RVA: 0x00258990 File Offset: 0x00256B90
	private void RefreshFinishState()
	{
		ActivityMotorGiftData motorGiftData = this.MotorGiftData;
		bool flag = motorGiftData != null && motorGiftData.IsRewardObtained();
		UUIItem item = base.GetItem(7);
		if (item != null)
		{
			item.SetUIActive(flag);
		}
		UUIItem item2 = base.GetItem(4);
		if (item2 != null)
		{
			item2.SetUIActive(!flag);
		}
		if (flag)
		{
			this.RefreshFinishText();
			return;
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(6), "MotorGiftHintDes", Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), "MotorGiftHintName", Array.Empty<object>());
		UUIText text = base.GetText(5);
		if (text == null)
		{
			return;
		}
		text.SetUIActive(true);
	}

	// Token: 0x06008F06 RID: 36614 RVA: 0x00258A2C File Offset: 0x00256C2C
	private void RefreshFinishText()
	{
		UUIItem item = base.GetItem(7);
		if (item == null)
		{
			return;
		}
		UUIText uiText = ULGUIBPLibrary.GetComponentInChildren(item.GetOwner(), UUIText.StaticClass(), false) as UUIText;
		Singleton<LguiUtil>.Instance.SetLocalTextNew(uiText, "MotorGiftFinishDes", Array.Empty<object>());
	}

	// Token: 0x06008F07 RID: 36615 RVA: 0x00258A76 File Offset: 0x00256C76
	private void OnPreviewButtonClick()
	{
		ActivityMotorGiftData motorGiftData = this.MotorGiftData;
		if (motorGiftData == null)
		{
			return;
		}
		motorGiftData.OpenMotorPreviewView();
	}

	// Token: 0x04004283 RID: 17027
	[Nullable(2)]
	private ActivityMotorGiftData MotorGiftData;

	// Token: 0x04004284 RID: 17028
	[Nullable(2)]
	private ActivitySubViewGeneralInfo CommonInfoPanel;

	// Token: 0x02007825 RID: 30757
	[NullableContext(1)]
	[Nullable(0)]
	private static class EMotorGiftTextKey
	{
		// Token: 0x04029526 RID: 169254
		public const string MotorGiftHintDes = "MotorGiftHintDes";

		// Token: 0x04029527 RID: 169255
		public const string MotorGiftHintName = "MotorGiftHintName";

		// Token: 0x04029528 RID: 169256
		public const string MotorGiftFinishDes = "MotorGiftFinishDes";
	}

	// Token: 0x02007826 RID: 30758
	private class EComponents
	{
		// Token: 0x04029529 RID: 169257
		public const int BtnLookA = 0;

		// Token: 0x0402952A RID: 169258
		public const int ComActivityInfo = 1;

		// Token: 0x0402952B RID: 169259
		public const int TxtSkinMainTitle = 2;

		// Token: 0x0402952C RID: 169260
		public const int TxtSubTitle = 3;

		// Token: 0x0402952D RID: 169261
		public const int PnlLayout = 4;

		// Token: 0x0402952E RID: 169262
		public const int TxtTip2 = 5;

		// Token: 0x0402952F RID: 169263
		public const int TxtTip1 = 6;

		// Token: 0x04029530 RID: 169264
		public const int PnlFinish = 7;
	}
}
