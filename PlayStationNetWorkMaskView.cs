using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using CSharpScript.Launcher.Platform;
using CSharpScript.Launcher.Platform.PlatformSdk;
using UnrealEngine;

// Token: 0x0200275F RID: 10079
public class PlayStationNetWorkMaskView : UiTickViewBase
{
	// Token: 0x06013E42 RID: 81474 RVA: 0x0058B132 File Offset: 0x00589332
	[NullableContext(1)]
	public PlayStationNetWorkMaskView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06013E43 RID: 81475 RVA: 0x0058B150 File Offset: 0x00589350
	protected unsafe override void OnRegisterComponent()
	{
		int num = 3;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06013E44 RID: 81476 RVA: 0x0058B1DC File Offset: 0x005893DC
	protected override void OnStart()
	{
		this.TotalTime = 0f;
		this.Number = 0;
		this.DelayTime = (float)ConfigCommonParamById.GetIntConfig("network_mask_time").GetValueOrDefault();
		base.GetItem(0).SetUIActive(false);
	}

	// Token: 0x06013E45 RID: 81477 RVA: 0x0058B221 File Offset: 0x00589421
	protected override void OnBeforeDestroy()
	{
		this.ClearConfirmId();
	}

	// Token: 0x06013E46 RID: 81478 RVA: 0x0058B229 File Offset: 0x00589429
	private void ClearConfirmId()
	{
		if (this.ConfirmBoxId != null)
		{
			ControllerBase<ConfirmBoxController>.Instance.CloseNetWorkConfirmBoxView(this.ConfirmBoxId.Value, null);
			this.ConfirmBoxId = null;
		}
	}

	// Token: 0x06013E47 RID: 81479 RVA: 0x0058B25A File Offset: 0x0058945A
	protected override void OnTick(float delta)
	{
		if (!this.CurrentTryReConnectState)
		{
			return;
		}
		this.RefreshNumberText(delta);
		this.TickTipsTimeVisible(delta);
		this.CheckPlayStationNetWork(delta);
	}

	// Token: 0x06013E48 RID: 81480 RVA: 0x0058B27C File Offset: 0x0058947C
	private void CheckPlayStationNetWork(float delta)
	{
		this.CheckPlayStationNetWorkTime += delta;
		if (this.CheckPlayStationNetWorkTime > 1000f)
		{
			this.CheckPlayStationNetWorkTime = 0f;
			if (!this.CheckPlayStationNetWorkState())
			{
				this.CurrentTryCount++;
				if (this.CurrentTryCount > 15)
				{
					this.OnReConnectFail();
					return;
				}
			}
			else
			{
				this.OnReConnectSuccess();
			}
		}
	}

	// Token: 0x06013E49 RID: 81481 RVA: 0x0058B2DC File Offset: 0x005894DC
	private void OnReConnectSuccess()
	{
		base.CloseMe(null);
	}

	// Token: 0x06013E4A RID: 81482 RVA: 0x0058B2E5 File Offset: 0x005894E5
	private void OnReConnectFail()
	{
		this.CurrentTryReConnectState = false;
		this.InitBoxItem();
	}

	// Token: 0x06013E4B RID: 81483 RVA: 0x0058B2F4 File Offset: 0x005894F4
	private void InitBoxItem()
	{
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.PlayStationConnectFail);
		confirmBoxDataNew.FunctionMap[0] = new Action(this.OkBtn);
		confirmBoxDataNew.FunctionMap[1] = new Action(this.BackBtn);
		confirmBoxDataNew.FunctionMap[2] = new Action(this.OkBtn);
		confirmBoxDataNew.IsEscViewTriggerCallBack = false;
		ControllerBase<ConfirmBoxController>.Instance.ShowNetWorkConfirmBoxView(confirmBoxDataNew, delegate(bool success, int viewId)
		{
			this.ConfirmBoxId = new int?(viewId);
		});
	}

	// Token: 0x06013E4C RID: 81484 RVA: 0x0058B372 File Offset: 0x00589572
	private void BackBtn()
	{
		ControllerBase<ReConnectController>.Instance.Logout(ELogoutReason.PsnUnAvailable);
	}

	// Token: 0x06013E4D RID: 81485 RVA: 0x0058B37F File Offset: 0x0058957F
	private void OkBtn()
	{
		this.CurrentTryCount = 0;
		this.CurrentTryReConnectState = true;
		this.ClearConfirmId();
	}

	// Token: 0x06013E4E RID: 81486 RVA: 0x0058B398 File Offset: 0x00589598
	private void RefreshNumberText(float delta)
	{
		this.TotalTime += delta;
		if (this.TotalTime > 1000f)
		{
			this.TotalTime -= 1000f;
			if (base.GetText(1).IsUIActiveSelf())
			{
				this.Number = (this.Number + 1) % ReconnectDefine.ellipsis.Count;
				Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(1), "ReconnectingInfo", new <>z__ReadOnlySingleElementList<object>(ReconnectDefine.ellipsis[this.Number]));
			}
		}
	}

	// Token: 0x06013E4F RID: 81487 RVA: 0x0058B424 File Offset: 0x00589624
	private void TickTipsTimeVisible(float deltaTime)
	{
		if (this.DelayTime < 0f)
		{
			return;
		}
		this.DelayTime -= deltaTime;
		if (this.DelayTime < 0f)
		{
			base.GetItem(0).SetUIActive(true);
		}
	}

	// Token: 0x06013E50 RID: 81488 RVA: 0x0058B45C File Offset: 0x0058965C
	private bool CheckPlayStationNetWorkState()
	{
		return Singleton<Platform>.Instance.IsPs5Platform() && Singleton<PlatformSdkManagerNew>.Instance.GetPlatformSdk().IsPlatformNetworkReachable();
	}

	// Token: 0x04009ACD RID: 39629
	private const int RETRYMAXCOUNT = 15;

	// Token: 0x04009ACE RID: 39630
	private const int CHECKGAP = 1000;

	// Token: 0x04009ACF RID: 39631
	private int? ConfirmBoxId;

	// Token: 0x04009AD0 RID: 39632
	private int Number;

	// Token: 0x04009AD1 RID: 39633
	private float TotalTime;

	// Token: 0x04009AD2 RID: 39634
	private float DelayTime;

	// Token: 0x04009AD3 RID: 39635
	private float CheckPlayStationNetWorkTime = 1000f;

	// Token: 0x04009AD4 RID: 39636
	private int CurrentTryCount;

	// Token: 0x04009AD5 RID: 39637
	private bool CurrentTryReConnectState = true;

	// Token: 0x02008B1A RID: 35610
	private static class EComponent
	{
		// Token: 0x0402EE80 RID: 192128
		public const int TipsItem = 0;

		// Token: 0x0402EE81 RID: 192129
		public const int TipsTxt = 1;

		// Token: 0x0402EE82 RID: 192130
		public const int TipsBgSpr = 2;
	}
}
