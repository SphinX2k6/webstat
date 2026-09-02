using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x0200275E RID: 10078
public class NetWorkMaskView : UiTickViewBase
{
	// Token: 0x06013E33 RID: 81459 RVA: 0x0058ADCE File Offset: 0x00588FCE
	[NullableContext(1)]
	public NetWorkMaskView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06013E34 RID: 81460 RVA: 0x0058ADE3 File Offset: 0x00588FE3
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.ReConnectSuccess, new Action(this.ReConnectSuccess));
		Singleton<EventSystem>.Instance.Add(EEventName.ReConnectFail, new Action(this.ReConnectFail));
	}

	// Token: 0x06013E35 RID: 81461 RVA: 0x0058AE1D File Offset: 0x0058901D
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.ReConnectSuccess, new Action(this.ReConnectSuccess));
		Singleton<EventSystem>.Instance.Remove(EEventName.ReConnectFail, new Action(this.ReConnectFail));
	}

	// Token: 0x06013E36 RID: 81462 RVA: 0x0058AE58 File Offset: 0x00589058
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

	// Token: 0x06013E37 RID: 81463 RVA: 0x0058AEE4 File Offset: 0x005890E4
	protected override void OnStart()
	{
		this.TotalTime = 0f;
		this.Number = 0;
		bool flag = ModelBase<ReConnectModel>.Instance.IsRpcEmpty();
		int? intConfig = ConfigCommonParamById.GetIntConfig("network_mask_time");
		this.DelayTime = (float)(flag ? 100 : intConfig.GetValueOrDefault(100));
		base.GetItem(0).SetUIActive(false);
	}

	// Token: 0x06013E38 RID: 81464 RVA: 0x0058AF3D File Offset: 0x0058913D
	protected override void OnBeforeDestroy()
	{
		this.ClearConfirmId();
	}

	// Token: 0x06013E39 RID: 81465 RVA: 0x0058AF45 File Offset: 0x00589145
	private void ClearConfirmId()
	{
		if (this.ConfirmBoxId != null)
		{
			ControllerBase<ConfirmBoxController>.Instance.CloseNetWorkConfirmBoxView(this.ConfirmBoxId.Value, null);
			this.ConfirmBoxId = null;
		}
	}

	// Token: 0x06013E3A RID: 81466 RVA: 0x0058AF78 File Offset: 0x00589178
	private void TickTipsTimeVisible(float deltaTime)
	{
		if (this.DelayTime < 0f || Singleton<Net>.Instance.IsNotifyCallbackPaused())
		{
			return;
		}
		this.DelayTime -= deltaTime;
		if (this.DelayTime < 0f)
		{
			base.GetItem(0).SetUIActive(true);
			int length = ModelBase<ReConnectModel>.Instance.GetUnResponsedRpcStr().Length;
		}
	}

	// Token: 0x06013E3B RID: 81467 RVA: 0x0058AFDC File Offset: 0x005891DC
	protected override void OnTick(float delta)
	{
		this.TotalTime += delta;
		if (this.TotalTime > 1000f)
		{
			this.TotalTime -= 1000f;
			if (base.GetText(1).IsUIActiveSelf())
			{
				this.Number++;
				if (this.Number >= ReconnectDefine.ellipsis.Count)
				{
					this.Number = 0;
				}
				Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(1), "ReconnectingInfo", new <>z__ReadOnlySingleElementList<object>(ReconnectDefine.ellipsis[this.Number]));
			}
		}
		this.TickTipsTimeVisible(delta);
	}

	// Token: 0x06013E3C RID: 81468 RVA: 0x0058B080 File Offset: 0x00589280
	private void InitBoxItem()
	{
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.NetWorkMaskTip);
		confirmBoxDataNew.FunctionMap[0] = new Action(this.OkBtn);
		confirmBoxDataNew.FunctionMap[1] = new Action(this.BackBtn);
		confirmBoxDataNew.FunctionMap[2] = new Action(this.OkBtn);
		confirmBoxDataNew.IsEscViewTriggerCallBack = false;
		ControllerBase<ConfirmBoxController>.Instance.ShowNetWorkConfirmBoxView(confirmBoxDataNew, delegate(bool success, int viewId)
		{
			this.ConfirmBoxId = new int?(viewId);
		});
	}

	// Token: 0x06013E3D RID: 81469 RVA: 0x0058B0FB File Offset: 0x005892FB
	private void BackBtn()
	{
		ControllerBase<ReConnectController>.Instance.Logout(ELogoutReason.NetWorkMaskViewBackBtn);
	}

	// Token: 0x06013E3E RID: 81470 RVA: 0x0058B108 File Offset: 0x00589308
	private void OkBtn()
	{
	}

	// Token: 0x06013E3F RID: 81471 RVA: 0x0058B10A File Offset: 0x0058930A
	private void ReConnectSuccess()
	{
		Singleton<UiManager>.Instance.CloseView(EUiViewName.NetWorkMaskView, null);
	}

	// Token: 0x06013E40 RID: 81472 RVA: 0x0058B11C File Offset: 0x0058931C
	private void ReConnectFail()
	{
		this.InitBoxItem();
	}

	// Token: 0x04009AC9 RID: 39625
	private int Number;

	// Token: 0x04009ACA RID: 39626
	private float TotalTime;

	// Token: 0x04009ACB RID: 39627
	private int? ConfirmBoxId = new int?(0);

	// Token: 0x04009ACC RID: 39628
	private float DelayTime;
}
