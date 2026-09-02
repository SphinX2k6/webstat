using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x0200189D RID: 6301
[NullableContext(2)]
[Nullable(0)]
public class LongPressButtonItem
{
	// Token: 0x0600B4D7 RID: 46295 RVA: 0x003027F0 File Offset: 0x003009F0
	[NullableContext(1)]
	public LongPressButtonItem([Nullable(new byte[]
	{
		0,
		1,
		1
	})] OneOf<UUIButtonComponent, UUIExtendToggle>? longPressComponent = null, LongPressButtonItem.ELongPressConfigId? configId = null, Action<bool> pointClickAction = null)
	{
		if (longPressComponent != null)
		{
			this.Initialize(longPressComponent.Value, pointClickAction, null, null, null);
		}
		if (configId != null)
		{
			this.Activate(configId.Value);
		}
	}

	// Token: 0x0600B4D8 RID: 46296 RVA: 0x00302850 File Offset: 0x00300A50
	public void Initialize([Nullable(new byte[]
	{
		0,
		1,
		1
	})] OneOf<UUIButtonComponent, UUIExtendToggle> longPressComponent, Action<bool> pointClickAction = null, Action onPressCallback = null, Action onReleaseCallback = null, Action onCancelCallback = null)
	{
		this.LongPressComponent = longPressComponent;
		if (this.LongPressComponent.IsT1)
		{
			UUIButtonComponent asT = this.LongPressComponent.AsT1;
			asT.OnPointDownCallBack.Bind(delegate()
			{
				this.IsInFirstStage = true;
				this.IsPress = true;
				this.FirstPointDownPos.DeepCopy(Singleton<LguiEventSystemManager>.Instance.GetPointerEventDataPosition(0));
				Action onPressCallback2 = this.OnPressCallback;
				if (onPressCallback2 == null)
				{
					return;
				}
				onPressCallback2();
			});
			asT.OnPointCancelCallBack.Bind(delegate()
			{
				this.IsPress = false;
				this.PressTime = 0f;
				this.TickTime = 0f;
				Action onCancelCallback2 = this.OnCancelCallback;
				if (onCancelCallback2 == null)
				{
					return;
				}
				onCancelCallback2();
			});
			asT.OnPointUpCallBack.Bind(delegate()
			{
				this.IsPress = false;
				Action onReleaseCallback2 = this.OnReleaseCallback;
				if (onReleaseCallback2 == null)
				{
					return;
				}
				onReleaseCallback2();
			});
			asT.OnSelfInteractiveChanged.Bind(new Action<bool>(this.InteractiveChangeEvent));
		}
		else if (this.LongPressComponent.IsT2)
		{
			UUIExtendToggle asT2 = this.LongPressComponent.AsT2;
			asT2.OnPointDownCallBack.Bind(delegate(EToggleState _)
			{
				this.IsInFirstStage = true;
				this.IsPress = true;
				this.FirstPointDownPos.DeepCopy(Singleton<LguiEventSystemManager>.Instance.GetPointerEventDataPosition(0));
				Action onPressCallback2 = this.OnPressCallback;
				if (onPressCallback2 == null)
				{
					return;
				}
				onPressCallback2();
			});
			asT2.OnPointCancelCallBack.Bind(delegate(EToggleState _)
			{
				this.IsPress = false;
				this.PressTime = 0f;
				this.TickTime = 0f;
				Action onCancelCallback2 = this.OnCancelCallback;
				if (onCancelCallback2 == null)
				{
					return;
				}
				onCancelCallback2();
			});
			asT2.OnPointUpCallBack.Bind(delegate(EToggleState _)
			{
				this.IsPress = false;
				Action onReleaseCallback2 = this.OnReleaseCallback;
				if (onReleaseCallback2 == null)
				{
					return;
				}
				onReleaseCallback2();
			});
			asT2.OnSelfInteractiveChanged.Bind(new Action<bool>(this.InteractiveChangeEvent));
		}
		this.PointClickAction = pointClickAction;
		this.OnPressCallback = onPressCallback;
		this.OnReleaseCallback = onReleaseCallback;
		this.OnCancelCallback = onCancelCallback;
		this.BindAudioEvent();
	}

	// Token: 0x0600B4D9 RID: 46297 RVA: 0x00302970 File Offset: 0x00300B70
	public void Activate(LongPressButtonItem.ELongPressConfigId configId)
	{
		this.Config = ConfigBase<CommonConfig>.Instance.GetLongPressConfig((int)configId);
		Ticker ticker = Singleton<TickSystem>.Instance.Add(new Action<float>(this.Tick), "LongPressComponent", ETickingGroup.TG_PrePhysics, true, 0, true);
		this.TickId = ((ticker != null) ? ticker.Id : -1);
		this.IsPress = false;
	}

	// Token: 0x0600B4DA RID: 46298 RVA: 0x003029C6 File Offset: 0x00300BC6
	public void Deactivate()
	{
		this.IsPress = false;
		if (this.TickId != -1)
		{
			Singleton<TickSystem>.Instance.Remove(this.TickId);
			this.TickId = -1;
		}
	}

	// Token: 0x0600B4DB RID: 46299 RVA: 0x003029F0 File Offset: 0x00300BF0
	public bool IsActivate()
	{
		return this.TickId != -1 && Singleton<TickSystem>.Instance.Has(this.TickId);
	}

	// Token: 0x0600B4DC RID: 46300 RVA: 0x00302A0D File Offset: 0x00300C0D
	private void InteractiveChangeEvent(bool selfInteractive)
	{
		if (!selfInteractive)
		{
			this.IsPress = false;
		}
	}

	// Token: 0x0600B4DD RID: 46301 RVA: 0x00302A1C File Offset: 0x00300C1C
	private void BindAudioEvent()
	{
		if (!this.LongPressComponent.HasValue)
		{
			return;
		}
		string componentName;
		if (!this.LongPressComponent.IsT1)
		{
			AActor owner = this.LongPressComponent.AsT2.GetOwner();
			componentName = ((owner != null) ? owner.GetName() : null);
		}
		else
		{
			AActor owner2 = this.LongPressComponent.AsT1.GetOwner();
			componentName = ((owner2 != null) ? owner2.GetName() : null);
		}
		this.ComponentName = componentName;
		UiComponentUtil.BindAudioEvent(this.LongPressComponent.IsT1 ? this.LongPressComponent.AsT1 : this.LongPressComponent.AsT2);
	}

	// Token: 0x0600B4DE RID: 46302 RVA: 0x00302AAE File Offset: 0x00300CAE
	private void StopAudioEvent()
	{
		if (!StringUtils.IsBlank(this.ComponentName))
		{
			UiComponentUtil.UnBindAudioEventByName(this.ComponentName);
		}
	}

	// Token: 0x0600B4DF RID: 46303 RVA: 0x00302AC8 File Offset: 0x00300CC8
	private bool CheckTickCondition()
	{
		Func<bool> tickConditionDelegate = this.TickConditionDelegate;
		return tickConditionDelegate == null || tickConditionDelegate();
	}

	// Token: 0x0600B4E0 RID: 46304 RVA: 0x00302ADC File Offset: 0x00300CDC
	private bool CheckDragging()
	{
		this.SubVector.DeepCopy(Singleton<LguiEventSystemManager>.Instance.GetPointerEventDataPosition(0));
		this.FirstPointDownPos.Subtraction(this.SubVector, this.SubVector);
		return this.SubVector.SizeSquared() >= 40000.0;
	}

	// Token: 0x0600B4E1 RID: 46305 RVA: 0x00302B35 File Offset: 0x00300D35
	private void Tick(float delta)
	{
		if (this.TickPreEnterLongPress(delta))
		{
			return;
		}
		this.TickLongPressAction(delta);
		this.TickAudioEvent(delta);
	}

	// Token: 0x0600B4E2 RID: 46306 RVA: 0x00302B50 File Offset: 0x00300D50
	private bool TickPreEnterLongPress(float delta)
	{
		int? num;
		float? num2;
		if (!this.IsPress)
		{
			float pressTime = this.PressTime;
			num = ((this.Config != null) ? new int?(this.Config.GetValueOrDefault().PressTime(0)) : null);
			num2 = ((num != null) ? new float?((float)num.GetValueOrDefault()) : null);
			if ((pressTime < num2.GetValueOrDefault() & num2 != null) && this.PressTime > 0f)
			{
				Action<bool> pointClickAction = this.PointClickAction;
				if (pointClickAction != null)
				{
					pointClickAction(true);
				}
			}
			this.PressTime = 0f;
			this.TickTime = 0f;
			this.AudioTickTime = 0f;
			return true;
		}
		if (!this.CheckTickCondition())
		{
			this.PressTime = 1f;
			return true;
		}
		if (this.CheckDragging())
		{
			this.IsPress = false;
			this.PressTime = 0f;
			this.TickTime = 0f;
			this.AudioTickTime = 0f;
			return true;
		}
		this.PressTime += delta;
		float pressTime2 = this.PressTime;
		num = ((this.Config != null) ? new int?(this.Config.GetValueOrDefault().PressTime(0)) : null);
		num2 = ((num != null) ? new float?((float)num.GetValueOrDefault()) : null);
		if (pressTime2 < num2.GetValueOrDefault() & num2 != null)
		{
			return true;
		}
		if (this.IsInFirstStage)
		{
			this.IsInFirstStage = false;
			Action<bool> pointClickAction2 = this.PointClickAction;
			if (pointClickAction2 != null)
			{
				pointClickAction2(true);
			}
			return true;
		}
		return false;
	}

	// Token: 0x0600B4E3 RID: 46307 RVA: 0x00302CFC File Offset: 0x00300EFC
	private void TickLongPressAction(float delta)
	{
		this.TickTime += delta;
		int triggerTime = this.GetTriggerTime();
		if (this.TickTime < (float)triggerTime)
		{
			return;
		}
		this.TickTime -= (float)triggerTime;
		Action<bool> pointClickAction = this.PointClickAction;
		if (pointClickAction == null)
		{
			return;
		}
		pointClickAction(false);
	}

	// Token: 0x0600B4E4 RID: 46308 RVA: 0x00302D4C File Offset: 0x00300F4C
	private void TickAudioEvent(float delta)
	{
		if (!this.ShouldPlayLongPressSound)
		{
			return;
		}
		this.AudioTickTime += delta;
		int num = Math.Max(this.GetTriggerTime(), (this.Config != null) ? this.Config.GetValueOrDefault().AudioIntervalLimit : 0);
		if (this.AudioTickTime >= (float)num)
		{
			Singleton<AudioSystem>.Instance.PostEvent(this.OverriddenLongPressAudioEvent ?? "play_ui_com_slider_tick");
			this.AudioTickTime -= (float)num;
		}
	}

	// Token: 0x0600B4E5 RID: 46309 RVA: 0x00302DD0 File Offset: 0x00300FD0
	private int GetTriggerTime()
	{
		if (this.Config == null)
		{
			return 0;
		}
		int num = (this.Config != null) ? this.Config.GetValueOrDefault().PressTimeLength : 1;
		for (int i = 1; i < num; i++)
		{
			float pressTime = this.PressTime;
			int? num2 = (this.Config != null) ? new int?(this.Config.GetValueOrDefault().PressTime(i)) : null;
			float? num3 = (num2 != null) ? new float?((float)num2.GetValueOrDefault()) : null;
			if (pressTime < num3.GetValueOrDefault() & num3 != null)
			{
				int num4 = (this.Config != null) ? this.Config.GetValueOrDefault().TriggerTime(i - 1) : 1;
				return 1000 / num4;
			}
		}
		int num5 = (this.Config != null) ? this.Config.GetValueOrDefault().TriggerTime(num - 1) : 1;
		return 1000 / num5;
	}

	// Token: 0x0600B4E6 RID: 46310 RVA: 0x00302EE2 File Offset: 0x003010E2
	[NullableContext(1)]
	public void SetTickConditionDelegate(Func<bool> @delegate)
	{
		this.TickConditionDelegate = @delegate;
	}

	// Token: 0x0600B4E7 RID: 46311 RVA: 0x00302EEB File Offset: 0x003010EB
	public void SetInteractive(bool value)
	{
		if (!this.LongPressComponent.HasValue)
		{
			return;
		}
		UUISelectableComponent selectableComp = this.GetSelectableComp();
		if (selectableComp == null)
		{
			return;
		}
		selectableComp.SetSelfInteractive(value);
	}

	// Token: 0x0600B4E8 RID: 46312 RVA: 0x00302F0C File Offset: 0x0030110C
	public void SetActive(bool value)
	{
		if (!this.LongPressComponent.HasValue)
		{
			return;
		}
		UUISelectableComponent selectableComp = this.GetSelectableComp();
		if (selectableComp == null)
		{
			return;
		}
		UUIItem uuiitem = selectableComp.RootUIComp.Get();
		if (uuiitem == null)
		{
			return;
		}
		uuiitem.SetUIActive(value);
	}

	// Token: 0x0600B4E9 RID: 46313 RVA: 0x00302F4C File Offset: 0x0030114C
	public void Clear()
	{
		this.Deactivate();
		if (this.LongPressComponent.HasValue)
		{
			if (this.LongPressComponent.IsT1)
			{
				UUIButtonComponent asT = this.LongPressComponent.AsT1;
				asT.OnPointDownCallBack.Unbind();
				asT.OnPointCancelCallBack.Unbind();
				asT.OnPointUpCallBack.Unbind();
				asT.OnSelfInteractiveChanged.Unbind();
			}
			else if (this.LongPressComponent.IsT2)
			{
				UUIExtendToggle asT2 = this.LongPressComponent.AsT2;
				asT2.OnPointDownCallBack.Unbind();
				asT2.OnPointCancelCallBack.Unbind();
				asT2.OnPointUpCallBack.Unbind();
				asT2.OnSelfInteractiveChanged.Unbind();
			}
		}
		this.StopAudioEvent();
		this.LongPressComponent.Clear();
		this.PointClickAction = null;
		this.OnPressCallback = null;
		this.OnReleaseCallback = null;
	}

	// Token: 0x0600B4EA RID: 46314 RVA: 0x00303020 File Offset: 0x00301220
	private UUISelectableComponent GetSelectableComp()
	{
		if (!this.LongPressComponent.HasValue)
		{
			return null;
		}
		if (this.LongPressComponent.IsT1)
		{
			return this.LongPressComponent.AsT1;
		}
		if (this.LongPressComponent.IsT2)
		{
			return this.LongPressComponent.AsT2;
		}
		return null;
	}

	// Token: 0x04005561 RID: 21857
	[Nullable(new byte[]
	{
		0,
		1,
		1
	})]
	private OneOf<UUIButtonComponent, UUIExtendToggle> LongPressComponent;

	// Token: 0x04005562 RID: 21858
	private LongPressConfig? Config;

	// Token: 0x04005563 RID: 21859
	private bool IsPress;

	// Token: 0x04005564 RID: 21860
	private int TickId = -1;

	// Token: 0x04005565 RID: 21861
	private float PressTime;

	// Token: 0x04005566 RID: 21862
	private float TickTime;

	// Token: 0x04005567 RID: 21863
	private float AudioTickTime;

	// Token: 0x04005568 RID: 21864
	private bool IsInFirstStage;

	// Token: 0x04005569 RID: 21865
	public string OverriddenLongPressAudioEvent;

	// Token: 0x0400556A RID: 21866
	public bool ShouldPlayLongPressSound;

	// Token: 0x0400556B RID: 21867
	private Action<bool> PointClickAction;

	// Token: 0x0400556C RID: 21868
	private Action OnPressCallback;

	// Token: 0x0400556D RID: 21869
	private Action OnReleaseCallback;

	// Token: 0x0400556E RID: 21870
	private Action OnCancelCallback;

	// Token: 0x0400556F RID: 21871
	private Func<bool> TickConditionDelegate;

	// Token: 0x04005570 RID: 21872
	[Nullable(1)]
	private readonly global::Vector FirstPointDownPos = global::Vector.Create();

	// Token: 0x04005571 RID: 21873
	[Nullable(1)]
	private readonly global::Vector SubVector = global::Vector.Create();

	// Token: 0x04005572 RID: 21874
	private string ComponentName;

	// Token: 0x04005573 RID: 21875
	private const int DRAG_TOLERANCE = 200;

	// Token: 0x04005574 RID: 21876
	private const int ONE_SECOND_TO_MILLISECOND = 1000;

	// Token: 0x04005575 RID: 21877
	[Nullable(1)]
	private const string LONG_PRESS_AUDIO_EVENT = "play_ui_com_slider_tick";

	// Token: 0x02007C19 RID: 31769
	[NullableContext(0)]
	public enum ELongPressConfigId
	{
		// Token: 0x0402A63F RID: 173631
		LongPressOne = 1,
		// Token: 0x0402A640 RID: 173632
		LongPressSecond,
		// Token: 0x0402A641 RID: 173633
		LongPressThird,
		// Token: 0x0402A642 RID: 173634
		LongPressFourth
	}
}
