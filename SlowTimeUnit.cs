using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001FB8 RID: 8120
[NullableContext(2)]
[Nullable(0)]
public class SlowTimeUnit : HudUnitBase
{
	// Token: 0x0600F496 RID: 62614 RVA: 0x0042EDA4 File Offset: 0x0042CFA4
	protected unsafe override void OnRegisterComponent()
	{
		int num = 7;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUINiagara));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUINiagara));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600F497 RID: 62615 RVA: 0x0042EEB4 File Offset: 0x0042D0B4
	protected override void OnStart()
	{
		base.OnStart();
		this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
		this.BarSprite = base.GetSprite(2);
		this.EffectItem = base.GetItem(5);
		this.ContainerItem = base.GetItem(1);
		this.SetTranslucence(this.TargetTranslucence);
		base.InitTweenAnim(6);
	}

	// Token: 0x0600F498 RID: 62616 RVA: 0x0042EF14 File Offset: 0x0042D114
	protected override void OnBeforeDestroy()
	{
		base.StopTweenAnim(6);
		base.OnBeforeDestroy();
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer != null)
		{
			levelSequencePlayer.Clear();
		}
		this.LevelSequencePlayer = null;
		this.BarSprite = null;
		this.ContainerItem = null;
		this.DestroyPromise();
		this.DestroyTimer();
	}

	// Token: 0x0600F499 RID: 62617 RVA: 0x0042EF60 File Offset: 0x0042D160
	protected override void OnBeforeShow()
	{
		this.LevelSequencePlayer.PlaySequencePurely("Start", false, false, null, null, false);
	}

	// Token: 0x0600F49A RID: 62618 RVA: 0x0042EF8C File Offset: 0x0042D18C
	protected override UniTask OnBeforeHideAsync()
	{
		SlowTimeUnit.<OnBeforeHideAsync>d__14 <OnBeforeHideAsync>d__;
		<OnBeforeHideAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeHideAsync>d__.<>4__this = this;
		<OnBeforeHideAsync>d__.<>1__state = -1;
		<OnBeforeHideAsync>d__.<>t__builder.Start<SlowTimeUnit.<OnBeforeHideAsync>d__14>(ref <OnBeforeHideAsync>d__);
		return <OnBeforeHideAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600F49B RID: 62619 RVA: 0x0042EFCF File Offset: 0x0042D1CF
	private void DestroyPromise()
	{
		if (this.Promise != null)
		{
			this.Promise.SetResult();
			this.Promise = null;
		}
	}

	// Token: 0x0600F49C RID: 62620 RVA: 0x0042EFEB File Offset: 0x0042D1EB
	private void DestroyTimer()
	{
		if (this.Timer != null)
		{
			TimerSystem.Instance.Remove(this.Timer);
			this.Timer = null;
		}
	}

	// Token: 0x0600F49D RID: 62621 RVA: 0x0042F00D File Offset: 0x0042D20D
	public void SetTranslucence(bool value)
	{
		this.TargetTranslucence = value;
		if (this.ContainerItem == null)
		{
			return;
		}
		if (value)
		{
			this.PlayWarnAnim(false);
		}
		this.RefreshAlpha();
		UUISprite barSprite = this.BarSprite;
		if (barSprite == null)
		{
			return;
		}
		barSprite.SetUIActive(value);
	}

	// Token: 0x0600F49E RID: 62622 RVA: 0x0042F040 File Offset: 0x0042D240
	private void RefreshAlpha()
	{
		UUIItem containerItem = this.ContainerItem;
		if (containerItem == null)
		{
			return;
		}
		containerItem.SetAlpha(this.TargetTranslucence ? 0.5f : 1f);
	}

	// Token: 0x0600F49F RID: 62623 RVA: 0x0042F068 File Offset: 0x0042D268
	public void UpdateProgress(float curValue, float maxValue)
	{
		if (this.BarSprite == null)
		{
			return;
		}
		float num = (maxValue > 0f) ? (curValue / maxValue) : 0f;
		FVector uiitemScale = new FVector(num, 1f, 1f);
		this.BarSprite.SetUIItemScale(uiitemScale);
		this.EffectItem.SetUIItemScale(uiitemScale);
		base.GetUiNiagara(3).SetNiagaraVarFloat("Dissolve", num);
		base.GetUiNiagara(4).SetNiagaraVarFloat("Dissolve", num);
		bool uiactive = num != 0f && num != 1f && !this.TargetTranslucence;
		this.EffectItem.SetUIActive(uiactive);
		this.PlayWarnAnim((double)num < 0.3 && !this.TargetTranslucence);
	}

	// Token: 0x0600F4A0 RID: 62624 RVA: 0x0042F127 File Offset: 0x0042D327
	private void PlayWarnAnim(bool bPlay)
	{
		if (this.IsPlayWarnAnim == bPlay)
		{
			return;
		}
		this.IsPlayWarnAnim = bPlay;
		if (bPlay)
		{
			base.PlayTweenAnim(6);
			return;
		}
		base.StopTweenAnim(6);
		this.RefreshAlpha();
	}

	// Token: 0x040075D7 RID: 30167
	private const int CLOSE_ANIM_TIME = 300;

	// Token: 0x040075D8 RID: 30168
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x040075D9 RID: 30169
	private UUISprite BarSprite;

	// Token: 0x040075DA RID: 30170
	private UUIItem EffectItem;

	// Token: 0x040075DB RID: 30171
	private UUIItem ContainerItem;

	// Token: 0x040075DC RID: 30172
	private bool TargetTranslucence;

	// Token: 0x040075DD RID: 30173
	private CustomPromise Promise;

	// Token: 0x040075DE RID: 30174
	private TimerHandle Timer;

	// Token: 0x040075DF RID: 30175
	private bool IsPlayWarnAnim;

	// Token: 0x0200834A RID: 33610
	[NullableContext(0)]
	private enum EChildType
	{
		// Token: 0x0402C86E RID: 182382
		EffectContainerItem,
		// Token: 0x0402C86F RID: 182383
		ContainerItem,
		// Token: 0x0402C870 RID: 182384
		BarSprite,
		// Token: 0x0402C871 RID: 182385
		LeftEffect,
		// Token: 0x0402C872 RID: 182386
		RightEffect,
		// Token: 0x0402C873 RID: 182387
		EffectItem,
		// Token: 0x0402C874 RID: 182388
		AniWarning
	}
}
