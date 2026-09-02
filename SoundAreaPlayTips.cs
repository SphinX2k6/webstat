using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002A82 RID: 10882
public class SoundAreaPlayTips : UiTickViewBase
{
	// Token: 0x06015C8E RID: 89230 RVA: 0x0060AF6B File Offset: 0x0060916B
	[NullableContext(1)]
	public SoundAreaPlayTips(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06015C8F RID: 89231 RVA: 0x0060AF74 File Offset: 0x00609174
	protected unsafe override void OnRegisterComponent()
	{
		int num = 11;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06015C90 RID: 89232 RVA: 0x0060B10A File Offset: 0x0060930A
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.SilentTipsRefresh, new Action<int>(this.OnSilentTipsRefresh));
	}

	// Token: 0x06015C91 RID: 89233 RVA: 0x0060B128 File Offset: 0x00609328
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.SilentTipsRefresh, new Action<int>(this.OnSilentTipsRefresh));
	}

	// Token: 0x06015C92 RID: 89234 RVA: 0x0060B146 File Offset: 0x00609346
	protected override void OnStart()
	{
		this.SetBuffInfo((int)this.OpenParam);
	}

	// Token: 0x06015C93 RID: 89235 RVA: 0x0060B15C File Offset: 0x0060935C
	public void SetBuffInfo(int buffId)
	{
		SoundAreaPlayInfo value = ConfigSoundAreaPlayInfoById.GetConfig(buffId, true).Value;
		if (value.ShowTitle)
		{
			base.GetItem(3).SetUIActive(true);
			base.GetItem(4).SetUIActive(false);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), value.BuffTitle, Array.Empty<object>());
		}
		else
		{
			base.GetItem(3).SetUIActive(false);
			base.GetItem(4).SetUIActive(true);
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), value.BuffDescription, Array.Empty<object>());
		if (value.Time > 0)
		{
			this.CloseTime = Singleton<TimeUtil>.Instance.GetServerTimeStamp() + (double)(value.Time * Singleton<TimeUtil>.Instance.InverseMillisecond);
		}
		if (value.MaxCount > 0)
		{
			ModelBase<SoundAreaPlayTipsModel>.Instance.AddShowInfoIdCount(value.Id);
		}
	}

	// Token: 0x06015C94 RID: 89236 RVA: 0x0060B23B File Offset: 0x0060943B
	protected override void OnTick(float delta)
	{
		if (this.CloseTime > 0.0 && Singleton<TimeUtil>.Instance.GetServerTimeStamp() > this.CloseTime)
		{
			base.CloseMe(null);
			this.CloseTime = 0.0;
		}
	}

	// Token: 0x06015C95 RID: 89237 RVA: 0x0060B276 File Offset: 0x00609476
	protected override void OnAfterPlayStartSequence()
	{
		if (this.CloseTime == 0.0)
		{
			base.CloseMe(null);
		}
	}

	// Token: 0x06015C96 RID: 89238 RVA: 0x0060B290 File Offset: 0x00609490
	private void OnSilentTipsRefresh(int configId)
	{
		this.SetBuffInfo(configId);
	}

	// Token: 0x0400A73B RID: 42811
	private double CloseTime;

	// Token: 0x02008DF1 RID: 36337
	private enum EChildType
	{
		// Token: 0x0402FC2C RID: 195628
		TitleText = 1,
		// Token: 0x0402FC2D RID: 195629
		DesText,
		// Token: 0x0402FC2E RID: 195630
		PanelHaveTitle,
		// Token: 0x0402FC2F RID: 195631
		PanelNoTitle,
		// Token: 0x0402FC30 RID: 195632
		ItemTagNew,
		// Token: 0x0402FC31 RID: 195633
		SpriteTagBg,
		// Token: 0x0402FC32 RID: 195634
		PanelClockIcon,
		// Token: 0x0402FC33 RID: 195635
		TxtNew,
		// Token: 0x0402FC34 RID: 195636
		ItemCheck,
		// Token: 0x0402FC35 RID: 195637
		ItemInvalid,
		// Token: 0x0402FC36 RID: 195638
		ItemInvalidLine
	}
}
