using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001398 RID: 5016
[NullableContext(1)]
[Nullable(0)]
public class TravelLevelTipsView : UiViewBase
{
	// Token: 0x060089FD RID: 35325 RVA: 0x00245444 File Offset: 0x00243644
	public TravelLevelTipsView(UiViewInfo info) : base(info)
	{
	}

	// Token: 0x060089FE RID: 35326 RVA: 0x0024547C File Offset: 0x0024367C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 3;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x060089FF RID: 35327 RVA: 0x00245508 File Offset: 0x00243708
	protected override void OnStart()
	{
		ActivityMapTravelData activityMapTravelData = this.OpenParam as ActivityMapTravelData;
		this.PreLevel = activityMapTravelData.LastTravelLevel;
		this.CurLevel = activityMapTravelData.TravelLevel;
		this.PreExpTotalCount = activityMapTravelData.LastExpCount;
		this.CurExpTotalCount = activityMapTravelData.GetExpItemCount();
		this.PreCurExpCount = activityMapTravelData.LastCurrentExpCount;
		IMapTravelLevelData mapTravelLevelData = activityMapTravelData.TravelLevelData[this.PreLevel];
		this.PreLevelTargetExp = mapTravelLevelData.TargetExp;
		this.CurExpCount = activityMapTravelData.GetCurrentExp();
		this.CurTargetExp = activityMapTravelData.GetCurrentTargetExp();
		bool flag = this.CurLevel > this.PreLevel;
		bool flag2 = this.CurExpTotalCount > this.PreExpTotalCount;
		if (flag)
		{
			if (flag2)
			{
				this.TipsType = TravelLevelTipsView.ETipsType.LevelUpAndExpAdd;
				return;
			}
			this.TipsType = TravelLevelTipsView.ETipsType.LevelUp;
			return;
		}
		else
		{
			if (flag2)
			{
				this.TipsType = TravelLevelTipsView.ETipsType.ExpAdd;
				return;
			}
			base.CloseMe(null);
			return;
		}
	}

	// Token: 0x06008A00 RID: 35328 RVA: 0x002455D7 File Offset: 0x002437D7
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<string>(EEventName.OnActivitySequenceEmitEvent, new Action<string>(this.OnActivitySequenceEmitEvent));
	}

	// Token: 0x06008A01 RID: 35329 RVA: 0x002455F5 File Offset: 0x002437F5
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnActivitySequenceEmitEvent, new Action<string>(this.OnActivitySequenceEmitEvent));
	}

	// Token: 0x06008A02 RID: 35330 RVA: 0x00245613 File Offset: 0x00243813
	private void OnActivitySequenceEmitEvent(string param)
	{
		if (param == "TipsChange")
		{
			this.SetExpMaxText();
		}
	}

	// Token: 0x06008A03 RID: 35331 RVA: 0x00245628 File Offset: 0x00243828
	protected override void OnBeforeShow()
	{
		this.TickHandle = TimerSystem.GameplayTimeInstance.Forever(new TTimerAction(this.Refresh), 20f, 1f, null, null, true);
		this.RefreshBar(0f, 1f);
		this.SetLevelText(this.PreLevel);
		switch (this.TipsType)
		{
		case TravelLevelTipsView.ETipsType.ExpAdd:
			this.SetExpText(this.CurExpCount - this.PreCurExpCount);
			this.SetExpTextVisible(true);
			this.RefreshBar((float)this.PreCurExpCount, (float)this.CurTargetExp);
			return;
		case TravelLevelTipsView.ETipsType.LevelUp:
			this.SetExpTextVisible(false);
			this.RefreshBar((float)this.PreCurExpCount, (float)this.PreLevelTargetExp);
			return;
		case TravelLevelTipsView.ETipsType.LevelUpAndExpAdd:
			this.SetExpText(this.CurExpTotalCount - this.PreExpTotalCount);
			this.SetExpTextVisible(true);
			this.RefreshBar((float)this.PreCurExpCount, (float)this.PreLevelTargetExp);
			return;
		default:
			return;
		}
	}

	// Token: 0x06008A04 RID: 35332 RVA: 0x00245710 File Offset: 0x00243910
	protected override void OnAfterShow()
	{
		switch (this.TipsType)
		{
		case TravelLevelTipsView.ETipsType.ExpAdd:
			this.RunExpAdd();
			return;
		case TravelLevelTipsView.ETipsType.LevelUp:
			this.RunLevelUp();
			return;
		case TravelLevelTipsView.ETipsType.LevelUpAndExpAdd:
			this.RunLevelUp();
			return;
		default:
			return;
		}
	}

	// Token: 0x06008A05 RID: 35333 RVA: 0x0024574E File Offset: 0x0024394E
	protected override void OnBeforeDestroy()
	{
		this.RemoveTick();
	}

	// Token: 0x06008A06 RID: 35334 RVA: 0x00245758 File Offset: 0x00243958
	private UniTask RunExpAdd()
	{
		TravelLevelTipsView.<RunExpAdd>d__20 <RunExpAdd>d__;
		<RunExpAdd>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RunExpAdd>d__.<>4__this = this;
		<RunExpAdd>d__.<>1__state = -1;
		<RunExpAdd>d__.<>t__builder.Start<TravelLevelTipsView.<RunExpAdd>d__20>(ref <RunExpAdd>d__);
		return <RunExpAdd>d__.<>t__builder.Task;
	}

	// Token: 0x06008A07 RID: 35335 RVA: 0x0024579C File Offset: 0x0024399C
	private UniTask RunLevelUp()
	{
		TravelLevelTipsView.<RunLevelUp>d__21 <RunLevelUp>d__;
		<RunLevelUp>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RunLevelUp>d__.<>4__this = this;
		<RunLevelUp>d__.<>1__state = -1;
		<RunLevelUp>d__.<>t__builder.Start<TravelLevelTipsView.<RunLevelUp>d__21>(ref <RunLevelUp>d__);
		return <RunLevelUp>d__.<>t__builder.Task;
	}

	// Token: 0x06008A08 RID: 35336 RVA: 0x002457E0 File Offset: 0x002439E0
	protected void Refresh(float delta)
	{
		if (!this.RunBarAnim)
		{
			return;
		}
		this.RunBarAnimTime += delta;
		float current = Singleton<MathUtils>.Instance.Lerp(this.StartValue, this.TargetValue, this.RunBarAnimTime / (float)this.BarAnimTime);
		this.RefreshBar(current, this.EndValue);
		if (this.RunBarAnimTime >= (float)this.BarAnimTime)
		{
			this.EndBarAnim();
		}
	}

	// Token: 0x06008A09 RID: 35337 RVA: 0x0024584C File Offset: 0x00243A4C
	private UniTask StartBarAnim(float current, float target, float end)
	{
		TravelLevelTipsView.<StartBarAnim>d__31 <StartBarAnim>d__;
		<StartBarAnim>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<StartBarAnim>d__.<>4__this = this;
		<StartBarAnim>d__.current = current;
		<StartBarAnim>d__.target = target;
		<StartBarAnim>d__.end = end;
		<StartBarAnim>d__.<>1__state = -1;
		<StartBarAnim>d__.<>t__builder.Start<TravelLevelTipsView.<StartBarAnim>d__31>(ref <StartBarAnim>d__);
		return <StartBarAnim>d__.<>t__builder.Task;
	}

	// Token: 0x06008A0A RID: 35338 RVA: 0x002458A7 File Offset: 0x00243AA7
	private void EndBarAnim()
	{
		this.RunBarAnim = false;
		this.BarAnimPromise.SetResult();
	}

	// Token: 0x06008A0B RID: 35339 RVA: 0x002458BB File Offset: 0x00243ABB
	private void RemoveTick()
	{
		if (this.TickHandle != null)
		{
			TimerSystem.GameplayTimeInstance.Remove(this.TickHandle);
			this.TickHandle = null;
		}
	}

	// Token: 0x06008A0C RID: 35340 RVA: 0x002458E0 File Offset: 0x00243AE0
	private void RefreshBar(float current, float target)
	{
		float fillAmount = Singleton<MathUtils>.Instance.Clamp(current / target, 0f, 1f);
		base.GetSprite(2).SetFillAmount(fillAmount);
	}

	// Token: 0x06008A0D RID: 35341 RVA: 0x00245912 File Offset: 0x00243B12
	private void SetExpTextVisible(bool bVisible)
	{
		base.GetText(1).SetUIActive(bVisible);
	}

	// Token: 0x06008A0E RID: 35342 RVA: 0x00245921 File Offset: 0x00243B21
	private void SetExpText(int expCount)
	{
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "MapTravelLevelUp_Text", new <>z__ReadOnlySingleElementList<object>(expCount));
	}

	// Token: 0x06008A0F RID: 35343 RVA: 0x00245944 File Offset: 0x00243B44
	private void SetExpMaxText()
	{
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "MapTravelLevelCanUp_Text", Array.Empty<object>());
		this.SetExpTextVisible(true);
	}

	// Token: 0x06008A10 RID: 35344 RVA: 0x00245968 File Offset: 0x00243B68
	private void SetLevelText(int level)
	{
		base.GetText(0).SetText(level.ToString(), true);
	}

	// Token: 0x040040AE RID: 16558
	private TravelLevelTipsView.ETipsType TipsType;

	// Token: 0x040040AF RID: 16559
	private int PreLevel;

	// Token: 0x040040B0 RID: 16560
	private int CurLevel;

	// Token: 0x040040B1 RID: 16561
	private int PreExpTotalCount;

	// Token: 0x040040B2 RID: 16562
	private int CurExpTotalCount;

	// Token: 0x040040B3 RID: 16563
	private int PreLevelTargetExp;

	// Token: 0x040040B4 RID: 16564
	private int PreCurExpCount;

	// Token: 0x040040B5 RID: 16565
	private int CurExpCount;

	// Token: 0x040040B6 RID: 16566
	private int CurTargetExp;

	// Token: 0x040040B7 RID: 16567
	protected TimerHandle TickHandle;

	// Token: 0x040040B8 RID: 16568
	protected int BarAnimTime = ConfigCommonParamById.GetIntConfig("TravelExpBarDisplayTime").Value;

	// Token: 0x040040B9 RID: 16569
	protected bool RunBarAnim;

	// Token: 0x040040BA RID: 16570
	protected float RunBarAnimTime;

	// Token: 0x040040BB RID: 16571
	protected float StartValue;

	// Token: 0x040040BC RID: 16572
	protected float TargetValue;

	// Token: 0x040040BD RID: 16573
	protected float EndValue;

	// Token: 0x040040BE RID: 16574
	protected CustomPromise BarAnimPromise = new CustomPromise();

	// Token: 0x02007742 RID: 30530
	[NullableContext(0)]
	private enum ETipsType
	{
		// Token: 0x04029119 RID: 168217
		ExpAdd,
		// Token: 0x0402911A RID: 168218
		LevelUp,
		// Token: 0x0402911B RID: 168219
		LevelUpAndExpAdd
	}

	// Token: 0x02007743 RID: 30531
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x0402911C RID: 168220
		public const int TxtLv = 0;

		// Token: 0x0402911D RID: 168221
		public const int TxtExp = 1;

		// Token: 0x0402911E RID: 168222
		public const int BarExp = 2;
	}
}
