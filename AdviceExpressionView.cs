using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001783 RID: 6019
[NullableContext(1)]
[Nullable(0)]
public class AdviceExpressionView : UiViewBase
{
	// Token: 0x0600A996 RID: 43414 RVA: 0x002D36D5 File Offset: 0x002D18D5
	public AdviceExpressionView(UiViewInfo info) : base(info)
	{
	}

	// Token: 0x0600A997 RID: 43415 RVA: 0x002D36E0 File Offset: 0x002D18E0
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUILoopScrollViewComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(5, typeof(UUIButtonComponent))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(4, new Action(this.OnClickCancelBtn)),
			new ValueTuple<int, Delegate>(5, new Action(this.OnClickConfirmBtn))
		};
	}

	// Token: 0x0600A998 RID: 43416 RVA: 0x002D37B8 File Offset: 0x002D19B8
	protected override UniTask OnBeforeStartAsync()
	{
		AdviceExpressionView.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<AdviceExpressionView.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600A999 RID: 43417 RVA: 0x002D37FB File Offset: 0x002D19FB
	private void OnClickConfirmBtn()
	{
		ModelBase<AdviceModel>.Instance.CurrentExpressionId = ModelBase<AdviceModel>.Instance.PreSelectExpressionId;
		Singleton<EventSystem>.Instance.Emit(EEventName.OnSelectAdviceExpression);
		base.CloseMe(null);
	}

	// Token: 0x0600A99A RID: 43418 RVA: 0x002D3828 File Offset: 0x002D1A28
	private void OnClickCancelBtn()
	{
		base.CloseMe(null);
	}

	// Token: 0x0600A99B RID: 43419 RVA: 0x002D3831 File Offset: 0x002D1A31
	private AdviceExpressionItem OnGridProxyCreate()
	{
		return new AdviceExpressionItem();
	}

	// Token: 0x0600A99C RID: 43420 RVA: 0x002D3838 File Offset: 0x002D1A38
	private AdviceExpressionSwitchItem TabItemProxyCreate([Nullable(2)] UUIItem uiItem, int? index)
	{
		return new AdviceExpressionSwitchItem();
	}

	// Token: 0x0600A99D RID: 43421 RVA: 0x002D383F File Offset: 0x002D1A3F
	private void ToggleCallBack(int groupId)
	{
		this.UpdateExpressions(groupId);
	}

	// Token: 0x0600A99E RID: 43422 RVA: 0x002D3848 File Offset: 0x002D1A48
	private void UpdateExpressions(int groupId)
	{
		IReadOnlyList<ChatExpression> allExpressionConfigByGroupId = ConfigBase<ChatConfig>.Instance.GetAllExpressionConfigByGroupId(groupId);
		LoopScrollView<AdviceExpressionItem, ChatExpression> expressionScrollView = this.ExpressionScrollView;
		if (expressionScrollView == null)
		{
			return;
		}
		expressionScrollView.ReloadData(allExpressionConfigByGroupId ?? Array.Empty<ChatExpression>(), false);
	}

	// Token: 0x0600A99F RID: 43423 RVA: 0x002D387C File Offset: 0x002D1A7C
	private int FindExpressionGroupId()
	{
		int result = 0;
		IReadOnlyList<ChatExpression> allExpressionConfig = ConfigBase<ChatConfig>.Instance.GetAllExpressionConfig();
		if (allExpressionConfig == null)
		{
			return result;
		}
		for (int i = 0; i < allExpressionConfig.Count; i++)
		{
			if (allExpressionConfig[i].Id == ModelBase<AdviceModel>.Instance.PreSelectExpressionId)
			{
				result = allExpressionConfig[i].GroupId;
				break;
			}
		}
		return result;
	}

	// Token: 0x0600A9A0 RID: 43424 RVA: 0x002D38DC File Offset: 0x002D1ADC
	private void UpdateTabs()
	{
		IReadOnlyList<ChatExpressionGroup> allExpressionGroupConfig = ConfigBase<ChatConfig>.Instance.GetAllExpressionGroupConfig();
		if (allExpressionGroupConfig == null || this.TabGroup == null)
		{
			return;
		}
		foreach (KeyValuePair<int, AdviceExpressionSwitchItem> keyValuePair in this.TabGroup.GetTabItemMap())
		{
			keyValuePair.Value.UpdateView(allExpressionGroupConfig[keyValuePair.Key].Id);
		}
	}

	// Token: 0x0600A9A1 RID: 43425 RVA: 0x002D3968 File Offset: 0x002D1B68
	protected override void OnBeforeDestroy()
	{
		LoopScrollView<AdviceExpressionItem, ChatExpression> expressionScrollView = this.ExpressionScrollView;
		if (expressionScrollView != null)
		{
			expressionScrollView.ClearGridProxies();
		}
		TabComponent<AdviceExpressionSwitchItem> tabGroup = this.TabGroup;
		if (tabGroup == null)
		{
			return;
		}
		tabGroup.Destroy(null);
	}

	// Token: 0x04004FE3 RID: 20451
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private LoopScrollView<AdviceExpressionItem, ChatExpression> ExpressionScrollView;

	// Token: 0x04004FE4 RID: 20452
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TabComponent<AdviceExpressionSwitchItem> TabGroup;

	// Token: 0x02007AE4 RID: 31460
	[NullableContext(0)]
	private static class EComponents
	{
		// Token: 0x0402A152 RID: 172370
		public const int ExpressionScroller = 0;

		// Token: 0x0402A153 RID: 172371
		public const int ExpressionItem = 1;

		// Token: 0x0402A154 RID: 172372
		public const int HoriGroupScroller = 2;

		// Token: 0x0402A155 RID: 172373
		public const int HoriGroupItem = 3;

		// Token: 0x0402A156 RID: 172374
		public const int CancelBtn = 4;

		// Token: 0x0402A157 RID: 172375
		public const int ConfirmBtn = 5;
	}
}
