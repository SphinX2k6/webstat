using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Protocol;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020010C3 RID: 4291
[NullableContext(1)]
[Nullable(0)]
public class GolemHackingGameView : UiTickViewBase
{
	// Token: 0x06006FA9 RID: 28585 RVA: 0x001D10DC File Offset: 0x001CF2DC
	public GolemHackingGameView(UiViewInfo info) : base(info)
	{
	}

	// Token: 0x06006FAA RID: 28586 RVA: 0x001D10E8 File Offset: 0x001CF2E8
	protected unsafe override void OnRegisterComponent()
	{
		int num = 3;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06006FAB RID: 28587 RVA: 0x001D1174 File Offset: 0x001CF374
	protected override UniTask OnBeforeStartAsync()
	{
		GolemHackingGameView.<OnBeforeStartAsync>d__12 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<GolemHackingGameView.<OnBeforeStartAsync>d__12>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06006FAC RID: 28588 RVA: 0x001D11B8 File Offset: 0x001CF3B8
	protected override void OnBeforeDestroy()
	{
		if (this.ActivityData != null)
		{
			this.ActivityData.SetCurrentId(null);
		}
	}

	// Token: 0x06006FAD RID: 28589 RVA: 0x001D11E1 File Offset: 0x001CF3E1
	protected override void OnAfterShow()
	{
		this.Proxy.SetCanInteractive(true);
	}

	// Token: 0x06006FAE RID: 28590 RVA: 0x001D11EF File Offset: 0x001CF3EF
	protected override void OnTick(float delta)
	{
		this.MatrixPanel.OnTick(delta);
	}

	// Token: 0x06006FAF RID: 28591 RVA: 0x001D1200 File Offset: 0x001CF400
	private void OnClickedClose()
	{
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(this.IsMainLevel ? EConfirmBoxConfigId.GolemHackingMainLevelExitConfirm : EConfirmBoxConfigId.GolemHackingNormalLevelExitConfirm);
		if (!this.IsMainLevel)
		{
			confirmBoxDataNew.IsEscViewTriggerCallBack = false;
			confirmBoxDataNew.FunctionMap[1] = delegate()
			{
				this.Proxy.Reset();
				this.Proxy.LogReport(EGolemHackingReportType.Reset, false);
				this.OpenLogReport();
				this.Proxy.FailCount = 0;
				this.Proxy.ResetCount = 0;
			};
		}
		confirmBoxDataNew.FunctionMap[2] = delegate()
		{
			if (ControllerBase<GolemHackingController>.Instance.IsActivityOpen)
			{
				this.Proxy.FailCount++;
				this.Proxy.LogReport(EGolemHackingReportType.Fail, false);
			}
			this.CloseCallback(this.IsMainLevel);
			base.CloseMe(null);
		};
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
	}

	// Token: 0x06006FB0 RID: 28592 RVA: 0x001D1272 File Offset: 0x001CF472
	private void OnSuccessCallback()
	{
		this.CloseCallback(true);
		base.CloseMe(null);
	}

	// Token: 0x06006FB1 RID: 28593 RVA: 0x001D1288 File Offset: 0x001CF488
	private void OpenLogReport()
	{
		GolemHackingController instance = ControllerBase<GolemHackingController>.Instance;
		if (!instance.IsActivityOpen)
		{
			return;
		}
		int activityOpenTime = (int)Singleton<TimeUtil>.Instance.GetServerTime();
		instance.ActivityOpenTime = activityOpenTime;
		int cacheLevelId = instance.CacheLevelId;
		GolemHackingLevelInfo levelInfo = instance.GetActivityData().GetLevelInfo(cacheLevelId);
		GolemHackingStartEvent golemHackingStartEvent = new GolemHackingStartEvent();
		golemHackingStartEvent.i_id = cacheLevelId;
		golemHackingStartEvent.i_type = (instance.CacheHardMode ? 2 : 1);
		golemHackingStartEvent.s_trace_id = activityOpenTime.ToString();
		bool flag = levelInfo.State == GolemCrackState.GolemCrackFinished;
		golemHackingStartEvent.i_first_pass = ((!flag) ? 1 : 0);
		ControllerBase<LogReportController>.Instance.LogReport(golemHackingStartEvent);
	}

	// Token: 0x06006FB2 RID: 28594 RVA: 0x001D1318 File Offset: 0x001CF518
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
	{
		if (configParams.Length == 2 && configParams[0] == "Left_Col_Panel")
		{
			int index = int.Parse(configParams[1]);
			GolemHackingMatrixVerticalPanel verticalPanelByIndex = this.MatrixPanel.GetVerticalPanelByIndex(index);
			if (verticalPanelByIndex == null)
			{
				return null;
			}
			return new UUIItem[]
			{
				verticalPanelByIndex.GetRootItem(),
				verticalPanelByIndex.GetRootItem()
			};
		}
		else if (configParams.Length == 2 && (configParams[0] == "Left_Item" || configParams[0] == "New:Left_Item"))
		{
			int index2 = int.Parse(configParams[1]);
			GolemHackingMatrixCodeButton codeButtonByIndex = this.MatrixPanel.GetCodeButtonByIndex(index2);
			if (codeButtonByIndex == null)
			{
				return null;
			}
			string a = configParams[0];
			if (!(a == "Left_Item"))
			{
				if (a == "New:Left_Item")
				{
					UUIItem codeButtonNavListenerByIndex = this.MatrixPanel.GetCodeButtonNavListenerByIndex(index2);
					if (codeButtonNavListenerByIndex != null)
					{
						return new UUIItem[]
						{
							codeButtonByIndex.GetRootItem(),
							codeButtonNavListenerByIndex
						};
					}
				}
				return null;
			}
			return new UUIItem[]
			{
				codeButtonByIndex.GetRootItem(),
				codeButtonByIndex.GetRootItem()
			};
		}
		else
		{
			if (configParams.Length != 2 || !(configParams[0] == "Right_Row_Panel"))
			{
				return null;
			}
			int index3 = int.Parse(configParams[1]);
			GolemHackingCodeKeyListItem horizontalPanelByIndex = this.HackingPanel.GetHorizontalPanelByIndex(index3);
			if (horizontalPanelByIndex == null)
			{
				return null;
			}
			return new UUIItem[]
			{
				horizontalPanelByIndex.GetRootItem(),
				horizontalPanelByIndex.GetRootItem()
			};
		}
	}

	// Token: 0x06006FB3 RID: 28595 RVA: 0x001D1468 File Offset: 0x001CF668
	public int GetConfigId()
	{
		return this.ConfigId;
	}

	// Token: 0x040035B3 RID: 13747
	private const int HELP_ID = 577;

	// Token: 0x040035B4 RID: 13748
	protected Action<bool> CloseCallback;

	// Token: 0x040035B5 RID: 13749
	protected PopupCaptionItem Caption;

	// Token: 0x040035B6 RID: 13750
	protected GolemHackingGameProxy Proxy;

	// Token: 0x040035B7 RID: 13751
	protected GolemHackingMatrixPanel MatrixPanel;

	// Token: 0x040035B8 RID: 13752
	protected GolemHackingCodePanel HackingPanel;

	// Token: 0x040035B9 RID: 13753
	protected bool IsMainLevel;

	// Token: 0x040035BA RID: 13754
	protected int ConfigId;

	// Token: 0x040035BB RID: 13755
	[Nullable(2)]
	protected GolemHackingActivityData ActivityData;

	// Token: 0x02007450 RID: 29776
	[NullableContext(0)]
	private enum EDefine
	{
		// Token: 0x0402835B RID: 164699
		CaptionItem,
		// Token: 0x0402835C RID: 164700
		MatrixPanel,
		// Token: 0x0402835D RID: 164701
		HackingPanel
	}
}
