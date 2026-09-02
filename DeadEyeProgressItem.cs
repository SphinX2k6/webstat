using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001B29 RID: 6953
[NullableContext(2)]
[Nullable(0)]
public class DeadEyeProgressItem : UiPanelBase
{
	// Token: 0x0600C85C RID: 51292 RVA: 0x003508DC File Offset: 0x0034EADC
	protected unsafe override void OnRegisterComponent()
	{
		int num = 5;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISliderComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISliderComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600C85D RID: 51293 RVA: 0x003509A8 File Offset: 0x0034EBA8
	protected override void OnStart()
	{
		this.RootSequencePlayer = new LevelSequencePlayer(this.RootItem);
		this.EnergySlider = base.GetSlider(3);
		this.ReduceSlider = base.GetSlider(2);
		this.SetRealProgressByEnergy(ModelBase<DeadEyeModeModel>.Instance.CurrentEnergy);
		this.SetReduceProgressByEnergy(ModelBase<DeadEyeModeModel>.Instance.CurrentEnergy);
		this.EnableReduceSlider(false);
		Singleton<EventSystem>.Instance.Add(EEventName.DeadEyeModeTargetPointLocked, new Action(this.OnLockedTarget));
	}

	// Token: 0x0600C85E RID: 51294 RVA: 0x00350A24 File Offset: 0x0034EC24
	protected override void OnAfterShow()
	{
		if (this.RootSequencePlayer != null)
		{
			CustomPromise<bool> stopPromise = new CustomPromise<bool>();
			this.RootSequencePlayer.PlaySequenceAsync("Start", stopPromise, false, false, null, false).ContinueWith(delegate()
			{
				this.StartSequenceFinished = true;
			});
		}
	}

	// Token: 0x0600C85F RID: 51295 RVA: 0x00350A70 File Offset: 0x0034EC70
	protected override UniTask OnBeforeHideAsync()
	{
		DeadEyeProgressItem.<OnBeforeHideAsync>d__11 <OnBeforeHideAsync>d__;
		<OnBeforeHideAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeHideAsync>d__.<>4__this = this;
		<OnBeforeHideAsync>d__.<>1__state = -1;
		<OnBeforeHideAsync>d__.<>t__builder.Start<DeadEyeProgressItem.<OnBeforeHideAsync>d__11>(ref <OnBeforeHideAsync>d__);
		return <OnBeforeHideAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600C860 RID: 51296 RVA: 0x00350AB3 File Offset: 0x0034ECB3
	protected override void OnBeforeDestroy()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.DeadEyeModeTargetPointLocked, new Action(this.OnLockedTarget));
	}

	// Token: 0x0600C861 RID: 51297 RVA: 0x00350AD4 File Offset: 0x0034ECD4
	public void OnTick(float delta)
	{
		if (!this.StartSequenceFinished)
		{
			return;
		}
		DeadEyeModeModel instance = ModelBase<DeadEyeModeModel>.Instance;
		double num = (double)delta * Singleton<TimeUtil>.Instance.Millisecond;
		float num2 = (float)((double)instance.TimeConsumption * num);
		instance.CurrentEnergy = Math.Max(0f, instance.CurrentEnergy - num2);
		this.SetRealProgressByEnergy(instance.CurrentEnergy);
		if (this.CurLerpTime <= 1000f)
		{
			this.CurLerpTime += delta;
			float alpha = this.CurLerpTime / 1000f;
			float reduceProgress = MathCommon.Lerp(this.ReduceSliderLerpStartValue, this.EnergySlider.GetValue(), alpha);
			this.SetReduceProgress(reduceProgress);
			return;
		}
		if (this.ReduceSlider != null && this.ReduceSlider.RootUIComp.Get().IsUIActiveSelf())
		{
			this.EnableReduceSlider(false);
		}
	}

	// Token: 0x0600C862 RID: 51298 RVA: 0x00350BA4 File Offset: 0x0034EDA4
	private void OnLockedTarget()
	{
		DeadEyeModeModel instance = ModelBase<DeadEyeModeModel>.Instance;
		float currentEnergy = instance.CurrentEnergy;
		instance.CurrentEnergy -= (float)ModelBase<DeadEyeModeModel>.Instance.BulletConsumption;
		this.SetRealProgressByEnergy(instance.CurrentEnergy);
		this.CurLerpTime = (float)((currentEnergy == instance.CurrentEnergy) ? 1000 : 0);
		this.ReduceSliderLerpStartValue = this.ReduceSlider.GetValue();
		this.EnableReduceSlider(true);
	}

	// Token: 0x0600C863 RID: 51299 RVA: 0x00350C14 File Offset: 0x0034EE14
	private void EnableReduceSlider(bool enable)
	{
		UUISliderComponent reduceSlider = this.ReduceSlider;
		if (reduceSlider != null)
		{
			reduceSlider.RootUIComp.Get().SetUIActive(enable);
		}
		UUIItem item = base.GetItem(4);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(enable);
	}

	// Token: 0x0600C864 RID: 51300 RVA: 0x00350C52 File Offset: 0x0034EE52
	private void SetRealProgressByEnergy(float energy)
	{
		this.SetRealProgress(energy / (float)ModelBase<DeadEyeModeModel>.Instance.MaxEnergy);
	}

	// Token: 0x0600C865 RID: 51301 RVA: 0x00350C67 File Offset: 0x0034EE67
	private void SetReduceProgressByEnergy(float energy)
	{
		this.SetReduceProgress(energy / (float)ModelBase<DeadEyeModeModel>.Instance.MaxEnergy);
	}

	// Token: 0x0600C866 RID: 51302 RVA: 0x00350C7C File Offset: 0x0034EE7C
	private void SetRealProgress(float value)
	{
		DeadEyeProgressItem.SetSliderValue(this.EnergySlider, value);
	}

	// Token: 0x0600C867 RID: 51303 RVA: 0x00350C8A File Offset: 0x0034EE8A
	private void SetReduceProgress(float value)
	{
		DeadEyeProgressItem.SetSliderValue(this.ReduceSlider, value);
	}

	// Token: 0x0600C868 RID: 51304 RVA: 0x00350C98 File Offset: 0x0034EE98
	private static void SetSliderValue(UUISliderComponent slider, float value)
	{
		if (slider != null)
		{
			slider.SetValue(value, true);
		}
	}

	// Token: 0x0400602D RID: 24621
	private const float LERP_TIME = 1000f;

	// Token: 0x0400602E RID: 24622
	private UUISliderComponent EnergySlider;

	// Token: 0x0400602F RID: 24623
	private UUISliderComponent ReduceSlider;

	// Token: 0x04006030 RID: 24624
	private LevelSequencePlayer RootSequencePlayer;

	// Token: 0x04006031 RID: 24625
	private float CurLerpTime = 1001f;

	// Token: 0x04006032 RID: 24626
	private float ReduceSliderLerpStartValue;

	// Token: 0x04006033 RID: 24627
	private bool StartSequenceFinished;

	// Token: 0x02007E12 RID: 32274
	[NullableContext(0)]
	private class EViewComponent
	{
		// Token: 0x0402AEE6 RID: 175846
		public const int TipsNode = 0;

		// Token: 0x0402AEE7 RID: 175847
		public const int TipsText = 1;

		// Token: 0x0402AEE8 RID: 175848
		public const int ReduceSlider = 2;

		// Token: 0x0402AEE9 RID: 175849
		public const int EnergySlider = 3;

		// Token: 0x0402AEEA RID: 175850
		public const int PanelReduceLength = 4;
	}
}
