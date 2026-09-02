using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002200 RID: 8704
public class LordGymLoadingView : LoadingViewBase
{
	// Token: 0x060106D0 RID: 67280 RVA: 0x0047D167 File Offset: 0x0047B367
	[NullableContext(1)]
	public LordGymLoadingView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x060106D1 RID: 67281 RVA: 0x0047D170 File Offset: 0x0047B370
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIArtText))
		};
	}

	// Token: 0x060106D2 RID: 67282 RVA: 0x0047D193 File Offset: 0x0047B393
	protected override void OnStart()
	{
		base.OnStart();
		Singleton<AudioSystem>.Instance.PostEvent("play_ui_daoguan_3_0_loading_percent");
	}

	// Token: 0x060106D3 RID: 67283 RVA: 0x0047D1AB File Offset: 0x0047B3AB
	protected override void UpdateProgressRate(float rate)
	{
	}

	// Token: 0x060106D4 RID: 67284 RVA: 0x0047D1AD File Offset: 0x0047B3AD
	protected override void UpdateProgressValue(float value)
	{
		this.SetTextProgressValue(0, value, "");
	}

	// Token: 0x060106D5 RID: 67285 RVA: 0x0047D1BC File Offset: 0x0047B3BC
	[NullableContext(1)]
	protected override void SetTextProgressValue(int textKey, float value, string suffix = "")
	{
		int num = (int)MathF.Round(value);
		base.GetArtText(textKey).SetText(num.ToString());
	}

	// Token: 0x020084D0 RID: 34000
	private class EComponent
	{
		// Token: 0x0402CFF4 RID: 184308
		public const int ProgressText = 0;
	}
}
