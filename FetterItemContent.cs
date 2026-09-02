using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002545 RID: 9541
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class FetterItemContent : GridProxyAbstract<FetterGroupContentData>
{
	// Token: 0x0601290F RID: 76047 RVA: 0x0051D544 File Offset: 0x0051B744
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickButton))
		};
	}

	// Token: 0x06012910 RID: 76048 RVA: 0x0051D5D8 File Offset: 0x0051B7D8
	protected override UniTask OnBeforeStartAsync()
	{
		FetterItemContent.<OnBeforeStartAsync>d__3 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<FetterItemContent.<OnBeforeStartAsync>d__3>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06012911 RID: 76049 RVA: 0x0051D61C File Offset: 0x0051B81C
	public override void Refresh(FetterGroupContentData data, bool isSelected, int gridIndex)
	{
		this.CurrentData = data;
		this.RefreshVisionElement(data);
		this.RefreshName(data);
		this.RefreshNum(data);
		bool flag = data.Index == data.CurrentSelectIndex;
		base.GetExtendToggle(0).SetToggleState(flag ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x06012912 RID: 76050 RVA: 0x0051D66C File Offset: 0x0051B86C
	private void RefreshVisionElement(FetterGroupContentData data)
	{
		if (data.VisionFetterRecommendInfo == null)
		{
			return;
		}
		int recommendFetterGroupId = data.VisionFetterRecommendInfo.GetRecommendFetterGroupId();
		PhantomFetterGroup fetterGroupById = ConfigBase<PhantomBattleConfig>.Instance.GetFetterGroupById(recommendFetterGroupId);
		VisionFetterSuitItem visionElementItem = this.VisionElementItem;
		if (visionElementItem != null)
		{
			visionElementItem.Update(new PhantomFetterGroup?(fetterGroupById));
		}
		VisionFetterSuitItem visionElementItem2 = this.VisionElementItem;
		if (visionElementItem2 == null)
		{
			return;
		}
		visionElementItem2.SetUiActive(true);
	}

	// Token: 0x06012913 RID: 76051 RVA: 0x0051D6C4 File Offset: 0x0051B8C4
	private void RefreshName(FetterGroupContentData data)
	{
		if (data.VisionFetterRecommendInfo == null)
		{
			return;
		}
		int recommendFetterGroupId = data.VisionFetterRecommendInfo.GetRecommendFetterGroupId();
		string fetterGroupName = ConfigBase<PhantomBattleConfig>.Instance.GetFetterGroupById(recommendFetterGroupId).FetterGroupName;
		base.GetText(2).ShowTextNew(fetterGroupName);
	}

	// Token: 0x06012914 RID: 76052 RVA: 0x0051D708 File Offset: 0x0051B908
	private void RefreshNum(FetterGroupContentData data)
	{
		if (data.VisionFetterRecommendInfo == null)
		{
			return;
		}
		string usageText = data.VisionFetterRecommendInfo.GetUsageText();
		base.GetText(3).SetText(usageText, true);
	}

	// Token: 0x06012915 RID: 76053 RVA: 0x0051D738 File Offset: 0x0051B938
	private void OnClickButton(EToggleState toggleState)
	{
		FetterGroupContentData currentData = this.CurrentData;
		if (currentData == null)
		{
			return;
		}
		Action<FetterGroupContentData> clickCallBack = currentData.ClickCallBack;
		if (clickCallBack == null)
		{
			return;
		}
		clickCallBack(this.CurrentData);
	}

	// Token: 0x040090AF RID: 37039
	[Nullable(2)]
	private FetterGroupContentData CurrentData;

	// Token: 0x040090B0 RID: 37040
	[Nullable(2)]
	private VisionFetterSuitItem VisionElementItem;
}
