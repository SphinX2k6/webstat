using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001AE4 RID: 6884
[NullableContext(1)]
[Nullable(0)]
internal class RewardInfoItem : UiPanelBase
{
	// Token: 0x0600C60F RID: 50703 RVA: 0x00344E7C File Offset: 0x0034307C
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUISprite)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUISliderComponent)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem))
		};
	}

	// Token: 0x0600C610 RID: 50704 RVA: 0x00344F04 File Offset: 0x00343104
	protected override UniTask OnBeforeStartAsync()
	{
		RewardInfoItem.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<RewardInfoItem.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600C611 RID: 50705 RVA: 0x00344F47 File Offset: 0x00343147
	public void SetTitle(string title)
	{
		UUIText text = base.GetText(1);
		if (text == null)
		{
			return;
		}
		text.SetText(title, true);
	}

	// Token: 0x0600C612 RID: 50706 RVA: 0x00344F5C File Offset: 0x0034315C
	public void SetProgress(float progress)
	{
		UUISliderComponent slider = base.GetSlider(2);
		if (slider == null)
		{
			return;
		}
		slider.SetValue(progress, true);
	}

	// Token: 0x0600C613 RID: 50707 RVA: 0x00344F71 File Offset: 0x00343171
	public void RefreshByProgress(float progress)
	{
		this.SetProgress(progress);
		this.RefreshRewardItem(progress);
	}

	// Token: 0x0600C614 RID: 50708 RVA: 0x00344F81 File Offset: 0x00343181
	private void RefreshRewardItem(float progress)
	{
		DangoAbyssBattleTreasureRoot dangoAbyssBattleTreasureRoot = this.DangoAbyssBattleTreasureRoot;
		if (dangoAbyssBattleTreasureRoot == null)
		{
			return;
		}
		dangoAbyssBattleTreasureRoot.RefreshRewardItem(progress * 100f);
	}

	// Token: 0x04005EF1 RID: 24305
	public Dictionary<int, int> RewardTimeMap = new Dictionary<int, int>();

	// Token: 0x04005EF2 RID: 24306
	public float FullTime;

	// Token: 0x04005EF3 RID: 24307
	[Nullable(2)]
	private DangoAbyssBattleTreasureRoot DangoAbyssBattleTreasureRoot;
}
