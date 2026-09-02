using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020016F2 RID: 5874
public class WheelTowerRoundTipsView : UiTickViewBase
{
	// Token: 0x0600A2E8 RID: 41704 RVA: 0x002B0051 File Offset: 0x002AE251
	[NullableContext(1)]
	public WheelTowerRoundTipsView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600A2E9 RID: 41705 RVA: 0x002B005C File Offset: 0x002AE25C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 4;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIArtText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600A2EA RID: 41706 RVA: 0x002B0108 File Offset: 0x002AE308
	protected override void OnStart()
	{
		object openParam = this.OpenParam;
		int num2;
		if (openParam is int)
		{
			int num = (int)openParam;
			num2 = num;
		}
		else
		{
			num2 = 0;
		}
		int num3 = num2;
		UUIArtText artText = base.GetArtText(0);
		if (artText != null)
		{
			artText.SetText(num3.ToString());
		}
		UUIItem item = base.GetItem(1);
		if (item != null)
		{
			item.SetUIActive(true);
		}
		UUIText text = base.GetText(2);
		if (text != null)
		{
			text.ShowTextNew("WheelTower_NextRoundTips");
		}
		UUIText text2 = base.GetText(3);
		if (text2 != null)
		{
			text2.ShowTextNew("WheelTower_NextRoundName");
		}
		this.RemainTime = 3000f;
	}

	// Token: 0x0600A2EB RID: 41707 RVA: 0x002B0197 File Offset: 0x002AE397
	protected override void OnTick(float delta)
	{
		if (this.IsTimerDone)
		{
			return;
		}
		this.RemainTime -= delta;
		if (this.RemainTime <= 0f)
		{
			this.IsTimerDone = true;
			base.CloseMe(null);
		}
	}

	// Token: 0x04004D56 RID: 19798
	private const float ShowTimeMs = 3000f;

	// Token: 0x04004D57 RID: 19799
	private float RemainTime;

	// Token: 0x04004D58 RID: 19800
	private bool IsTimerDone;
}
