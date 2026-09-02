using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x0200220C RID: 8716
public class LordGymThird5LoadingView : LoadingViewBase
{
	// Token: 0x06010746 RID: 67398 RVA: 0x0047E73C File Offset: 0x0047C93C
	[NullableContext(1)]
	public LordGymThird5LoadingView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06010747 RID: 67399 RVA: 0x0047E745 File Offset: 0x0047C945
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIItem))
		};
	}

	// Token: 0x06010748 RID: 67400 RVA: 0x0047E77E File Offset: 0x0047C97E
	protected override void OnStart()
	{
		base.OnStart();
	}

	// Token: 0x06010749 RID: 67401 RVA: 0x0047E786 File Offset: 0x0047C986
	protected override void UpdateProgressRate(float rate)
	{
	}

	// Token: 0x0601074A RID: 67402 RVA: 0x0047E788 File Offset: 0x0047C988
	protected override void UpdateProgressValue(float value)
	{
		this.SetTextProgressValue(0, value, "");
		this.ChangeSize(value);
	}

	// Token: 0x0601074B RID: 67403 RVA: 0x0047E7A0 File Offset: 0x0047C9A0
	[NullableContext(1)]
	protected override void SetTextProgressValue(int textKey, float value, string suffix = "")
	{
		int num = (int)MathF.Round(value);
		base.GetText(textKey).SetText(num.ToString() + "%", true);
	}

	// Token: 0x0601074C RID: 67404 RVA: 0x0047E7D4 File Offset: 0x0047C9D4
	private void ChangeSize(float value)
	{
		UUIItem item = base.GetItem(3);
		float num = 0.9f;
		float num2 = 1.1f;
		float num3 = num + (num2 - num) * value / 100f;
		item.SetUIItemScale(new FVector(num3, num3, num3));
	}

	// Token: 0x0601074D RID: 67405 RVA: 0x0047E80F File Offset: 0x0047CA0F
	protected override void OnLevelSequencePlayerBandStateChange(bool state)
	{
		base.PlaySequence("Start", null, false);
	}

	// Token: 0x020084E3 RID: 34019
	private class EComponent
	{
		// Token: 0x0402D035 RID: 184373
		public const int ProgressText = 0;

		// Token: 0x0402D036 RID: 184374
		public const int SizeChangeItem = 3;
	}
}
