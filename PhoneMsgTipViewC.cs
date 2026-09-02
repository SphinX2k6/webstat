using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x0200257A RID: 9594
public class PhoneMsgTipViewC : UiViewBase
{
	// Token: 0x06012A95 RID: 76437 RVA: 0x005253CB File Offset: 0x005235CB
	[NullableContext(1)]
	public PhoneMsgTipViewC(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06012A96 RID: 76438 RVA: 0x005253D4 File Offset: 0x005235D4
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText))
		};
	}

	// Token: 0x06012A97 RID: 76439 RVA: 0x005253F8 File Offset: 0x005235F8
	protected override void OnStart()
	{
		this.MsgData = (this.OpenParam as ShortMessage?);
		if (this.MsgData == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.PhoneSystem, ELogAuthor.LZK, "[PhoneMsgTipViewC] MsgData is undefined", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
	}

	// Token: 0x06012A98 RID: 76440 RVA: 0x00525447 File Offset: 0x00523647
	protected override void OnAfterShowImplement()
	{
		this.Timer = TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
		{
			this.Timer = null;
			this.CloseAndOpenPhoneMsgPanelViewSmall();
		}, 4000f, null, null, true, 1f);
	}

	// Token: 0x06012A99 RID: 76441 RVA: 0x00525472 File Offset: 0x00523672
	private void CloseAndOpenPhoneMsgPanelViewSmall()
	{
		Singleton<UiManager>.Instance.CloseAndOpenView(EUiViewName.PhoneMsgTipViewC, EUiViewName.PhoneMsgPanelViewSmall, this.MsgData, null, true);
	}

	// Token: 0x06012A9A RID: 76442 RVA: 0x00525495 File Offset: 0x00523695
	private void ReleaseTimer()
	{
		if (this.Timer != null)
		{
			TimerSystem.GameplayTimeInstance.Remove(this.Timer);
			this.Timer = null;
		}
	}

	// Token: 0x06012A9B RID: 76443 RVA: 0x005254B8 File Offset: 0x005236B8
	protected override void OnBeforeDestroy()
	{
		if (this.Timer != null)
		{
			Singleton<Log>.Instance.Error(ELogModule.PhoneSystem, ELogAuthor.LZK, "[PhoneMsgTipViewC] Timer is not released", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.ReleaseTimer();
		}
	}

	// Token: 0x040091CE RID: 37326
	private ShortMessage? MsgData;

	// Token: 0x040091CF RID: 37327
	[Nullable(2)]
	private TimerHandle Timer;

	// Token: 0x040091D0 RID: 37328
	private const float CLOSE_TIME = 4000f;

	// Token: 0x02008898 RID: 34968
	private enum EComponent
	{
		// Token: 0x0402E225 RID: 188965
		TxtMsgInfo
	}
}
