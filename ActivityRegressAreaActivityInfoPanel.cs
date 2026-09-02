using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Map;
using CSharpScript.Game.Module.Map.Controller;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001522 RID: 5410
[NullableContext(2)]
[Nullable(0)]
public class ActivityRegressAreaActivityInfoPanel : UiPanelBase
{
	// Token: 0x060097A1 RID: 38817 RVA: 0x0027BDF0 File Offset: 0x00279FF0
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

	// Token: 0x060097A2 RID: 38818 RVA: 0x0027BE9C File Offset: 0x0027A09C
	protected override UniTask OnBeforeStartAsync()
	{
		ActivityRegressAreaActivityInfoPanel.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ActivityRegressAreaActivityInfoPanel.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060097A3 RID: 38819 RVA: 0x0027BEE0 File Offset: 0x0027A0E0
	protected override void OnStart()
	{
		this.ActivityBottom.FunctionButton.SetFunction(new Action(this.OnGotoAreaBtnClick));
		this.ActivityBottom.FunctionButton.SetLocalTextNew("RecallActivity_Go", Array.Empty<object>());
		this.ActivityRewardListPanel.InitGridLayout(new Func<CommonItemSmallItemGrid>(this.ActivityRewardListPanel.InitCommonGridItem));
		this.ActivityTitlePanel.SetTimeTextVisible(false);
	}

	// Token: 0x060097A4 RID: 38820 RVA: 0x0027BF4B File Offset: 0x0027A14B
	public void RefreshByData(RegressBase config)
	{
		this.Config = new RegressBase?(config);
		this.RefreshTitle();
		this.RefreshDesc();
		this.RefreshReward();
	}

	// Token: 0x060097A5 RID: 38821 RVA: 0x0027BF6C File Offset: 0x0027A16C
	private void RefreshTitle()
	{
		this.ActivityTitlePanel.SetTitleByTextId(this.Config.Value.Title, Array.Empty<string>());
	}

	// Token: 0x060097A6 RID: 38822 RVA: 0x0027BF9C File Offset: 0x0027A19C
	private void RefreshDesc()
	{
		string subTitle = this.Config.Value.SubTitle;
		string description = this.Config.Value.Description;
		bool flag = !StringUtils.IsEmpty(subTitle);
		this.ActivityTitlePanel.SetSubTitleVisible(flag);
		if (flag)
		{
			this.ActivityTitlePanel.SetSubTitleByTextId(subTitle, Array.Empty<string>());
		}
		this.ActivityDescPanel.SetContentByTextId(description, Array.Empty<string>());
	}

	// Token: 0x060097A7 RID: 38823 RVA: 0x0027C00C File Offset: 0x0027A20C
	private void RefreshReward()
	{
	}

	// Token: 0x060097A8 RID: 38824 RVA: 0x0027C010 File Offset: 0x0027A210
	private void OnGotoAreaBtnClick()
	{
		ActivityRegressHelper.ReportRecallLog1024(EReportLogEventType.NewArea, 0);
		int markId = this.Config.Value.GetArgIdArray()[0];
		MapMark? configMark = ConfigBase<MapConfig>.Instance.GetConfigMark(markId);
		if (configMark == null)
		{
			return;
		}
		MapMark value = configMark.Value;
		ControllerBase<MapController>.Instance.OpenMapViewAndFocusMark((EMarkType)value.ObjectType, markId, null, false, 1f);
	}

	// Token: 0x04004650 RID: 18000
	private RegressBase? Config;

	// Token: 0x04004651 RID: 18001
	private ActivityTitleTypeA ActivityTitlePanel;

	// Token: 0x04004652 RID: 18002
	private ActivityDescriptionTypeB ActivityDescPanel;

	// Token: 0x04004653 RID: 18003
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private ActivityRewardList<CommonItemSmallItemGrid, TItem> ActivityRewardListPanel;

	// Token: 0x04004654 RID: 18004
	private ActivityFunctionalTypeA ActivityBottom;

	// Token: 0x020078DB RID: 30939
	[NullableContext(0)]
	private enum EComponents
	{
		// Token: 0x040298A1 RID: 170145
		ComActivityTitle,
		// Token: 0x040298A2 RID: 170146
		ComActivityDesc,
		// Token: 0x040298A3 RID: 170147
		ComActivityReward,
		// Token: 0x040298A4 RID: 170148
		ComActivityBottom
	}
}
