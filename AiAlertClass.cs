using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.BattleUi.Views;
using UnrealEngine;

// Token: 0x02000CF0 RID: 3312
[NullableContext(1)]
[Nullable(0)]
public class AiAlertClass
{
	// Token: 0x060041F2 RID: 16882 RVA: 0x00070E5F File Offset: 0x0006F05F
	public AiAlertClass(AiController aiController)
	{
		this.AiController = aiController;
	}

	// Token: 0x060041F3 RID: 16883 RVA: 0x00070E80 File Offset: 0x0006F080
	public void Init(CharacterActorComponent actorComp)
	{
		this.ActorComp = actorComp;
		Singleton<EventSystem>.Instance.AddWithTarget<float>(this.ActorComp.Entity, EEventName.SmartObjectAiAlterNotify, new Action<float>(this.ExtraModifyAlterValue));
	}

	// Token: 0x17000314 RID: 788
	// (get) Token: 0x060041F4 RID: 16884 RVA: 0x00070EB0 File Offset: 0x0006F0B0
	// (set) Token: 0x060041F5 RID: 16885 RVA: 0x00070EB8 File Offset: 0x0006F0B8
	public AiAlert? AiAlertConfig
	{
		get
		{
			return this.AiAlertInternal;
		}
		set
		{
			this.AiAlertInternal = value;
			if (value == null)
			{
				return;
			}
			if (value.Value.ForwardAngle >= 180f)
			{
				this.CosLimit = 1f;
			}
			else
			{
				this.CosLimit = (float)Math.Cos((double)(value.Value.ForwardAngle * 0.017453292f));
			}
			if (value.Value.DecreaseByDist > 0f)
			{
				this.SquaredDistLimit = (float)Singleton<MathUtils>.Instance.Square((double)(value.Value.BaseIncrease / value.Value.DecreaseByDist));
			}
			else
			{
				this.SquaredDistLimit = 0f;
				if (value.Value.MaxDist > 0f && value.Value.AlertnessType == 3)
				{
					this.SquaredDistLimit = (float)Singleton<MathUtils>.Instance.Square((double)value.Value.MaxDist);
				}
			}
			if (value.Value.AlertnessType == 2 || value.Value.AlertnessType == 3)
			{
				if (!ModelBase<AlertMarkModel>.Instance.AlertMarkInit)
				{
					ModelBase<AlertMarkModel>.Instance.AddPendingMarkInfo(this.ActorComp.Entity.Id, this.ActorComp.Owner, (EAlertnessType)value.Value.AlertnessType, (float)value.Value.ShowDist);
					return;
				}
				if (value.Value.AlertnessType == 2)
				{
					Singleton<EventSystem>.Instance.Emit<int, AActor>(EEventName.AddStalkAlertMark, this.ActorComp.Entity.Id, this.ActorComp.Owner);
					return;
				}
				if (value.Value.AlertnessType == 3)
				{
					Singleton<EventSystem>.Instance.Emit<int, AActor, float>(EEventName.AddEavesdropMark, this.ActorComp.Entity.Id, this.ActorComp.Owner, (float)value.Value.ShowDist);
				}
			}
		}
	}

	// Token: 0x17000315 RID: 789
	// (get) Token: 0x060041F6 RID: 16886 RVA: 0x000710BB File Offset: 0x0006F2BB
	public float AlertValue
	{
		get
		{
			return this.CurrentValue;
		}
	}

	// Token: 0x060041F7 RID: 16887 RVA: 0x000710C4 File Offset: 0x0006F2C4
	public void Clear()
	{
		this.CurrentValue = 0f;
		this.InAlertRange = false;
		this.IsAlertState = false;
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RemoveAlterMark, this.AiController.CharActorComp.Entity.Id);
		Entity entity = this.ActorComp.Entity;
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RemoveStalkAlertMark, entity.Id);
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RemoveEavesdropMark, entity.Id);
		Singleton<EventSystem>.Instance.RemoveWithTarget<float>(this.ActorComp.Entity, EEventName.SmartObjectAiAlterNotify, new Action<float>(this.ExtraModifyAlterValue));
	}

	// Token: 0x060041F8 RID: 16888 RVA: 0x00071170 File Offset: 0x0006F370
	public void Tick(float delta)
	{
		GameModeModel instance = ModelBase<GameModeModel>.Instance;
		if (instance != null && instance.IsTeleport)
		{
			this.CurrentValue = 0f;
			this.InAlertRange = false;
			this.IsAlertState = false;
			return;
		}
		if (this.AiAlertInternal == null)
		{
			this.InAlertRange = false;
			return;
		}
		if (this.CurrentValue == 100f)
		{
			if (this.AiController.AiHateList.GetCurrentTarget() == null)
			{
				this.CurrentValue = Math.Max(0f, this.CurrentValue - delta * this.AiAlertInternal.Value.BaseDecrease * 0.001f);
				foreach (int id in this.AiController.AiPerception.Enemies)
				{
					CharacterBuffComponent component = Singleton<EntitySystem>.Instance.GetComponent<CharacterBuffComponent>(id);
					if (component != null && component.Valid)
					{
						component.RemoveBuff(70000049L, -1, "AiAlterClass MaxValue", null, null, null);
					}
				}
			}
			return;
		}
		global::Vector actorLocationProxy = this.AiController.CharActorComp.ActorLocationProxy;
		global::Vector actorForwardProxy = this.AiController.CharActorComp.ActorForwardProxy;
		float num = 0f;
		if (this.AiController.AiPerception.Enemies.Count == 0)
		{
			this.InAlertRange = false;
		}
		foreach (int id2 in this.AiController.AiPerception.Enemies)
		{
			Entity entity = Singleton<EntitySystem>.Instance.Get(id2);
			if (entity.GetComponent<CreatureDataComponent>().GetEntityType() != EEntityType.Player)
			{
				this.InAlertRange = false;
			}
			else
			{
				entity.GetComponent<BaseActorComponent>().ActorLocationProxy.Subtraction(actorLocationProxy, this.TmpVector);
				double num2 = this.TmpVector.SizeSquared();
				if (this.SquaredDistLimit > 0f && num2 > (double)this.SquaredDistLimit)
				{
					this.InAlertRange = false;
				}
				else
				{
					this.InAlertRange = true;
					float num3 = (float)Math.Sqrt(num2);
					float num4 = this.AiAlertInternal.Value.BaseIncrease - this.AiAlertInternal.Value.DecreaseByDist * num3;
					if (num4 >= num)
					{
						if (this.TmpVector.DotProduct(actorForwardProxy) < (double)(this.CosLimit * num3))
						{
							num4 *= this.AiAlertInternal.Value.BackwardRate;
						}
						if (num4 >= num)
						{
							num = num4;
						}
					}
				}
			}
		}
		if (num == 0f)
		{
			this.CurrentValue = Math.Max(0f, this.CurrentValue - delta * this.AiAlertInternal.Value.BaseDecrease * 0.001f);
		}
		else
		{
			this.CurrentValue += delta * num * 0.001f;
			if (this.CurrentValue >= 100f)
			{
				this.CurrentValue = 100f;
				foreach (int id3 in this.AiController.AiPerception.Enemies)
				{
					CharacterBuffComponent component2 = Singleton<EntitySystem>.Instance.GetComponent<CharacterBuffComponent>(id3);
					if (component2 != null && component2.Valid)
					{
						component2.RemoveBuff(70000049L, -1, "AiAlterClass MaxValue", null, null, null);
					}
				}
				if (this.CallbackEvent != null)
				{
					this.CallbackEvent.Callback.Broadcast(true);
				}
			}
		}
		this.ProcessAlertness();
	}

	// Token: 0x060041F9 RID: 16889 RVA: 0x0007157C File Offset: 0x0006F77C
	private void ProcessAlertness()
	{
		switch (this.AiAlertConfig.Value.AlertnessType)
		{
		case 1:
			this.JudgeAlertState();
			return;
		case 2:
			this.JudgeTrackingAlertness();
			return;
		case 3:
			this.JudgeEavesdropAlertness();
			return;
		default:
			return;
		}
	}

	// Token: 0x060041FA RID: 16890 RVA: 0x000715CC File Offset: 0x0006F7CC
	private void JudgeAlertState()
	{
		if (this.CurrentValue <= 1f || this.IsAlertState)
		{
			if (this.CurrentValue < 1f)
			{
				if (this.IsAlertState)
				{
					this.IsAlertState = false;
					Singleton<EventSystem>.Instance.Emit<int>(EEventName.RemoveAlterMark, this.AiController.CharActorComp.Entity.Id);
				}
				this.ShowUiFrameCount = 5;
			}
			return;
		}
		int showUiFrameCount = this.ShowUiFrameCount;
		this.ShowUiFrameCount = showUiFrameCount - 1;
		if (showUiFrameCount > 0)
		{
			return;
		}
		this.ShowUiFrameCount = 5;
		this.IsAlertState = true;
		Singleton<EventSystem>.Instance.Emit<int, global::Vector, AActor>(EEventName.AddAlterMark, this.AiController.CharActorComp.Entity.Id, global::Vector.Create(), this.AiController.CharActorComp.Owner);
	}

	// Token: 0x060041FB RID: 16891 RVA: 0x00071694 File Offset: 0x0006F894
	private void JudgeTrackingAlertness()
	{
		Entity entity = this.ActorComp.Entity;
		if (this.IsAlertState)
		{
			if (this.CurrentValue < 1f)
			{
				this.IsAlertState = false;
				this.IsFullAlert = false;
				Singleton<EventSystem>.Instance.EmitWithTarget(entity, EEventName.OnStalkAlertLifted);
				return;
			}
			if (this.CurrentValue >= 100f && !this.IsFullAlert)
			{
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnStalkFound, entity.Id);
				this.IsFullAlert = true;
				return;
			}
		}
		else if (this.CurrentValue > 1f)
		{
			this.IsAlertState = true;
			Singleton<EventSystem>.Instance.EmitWithTarget(entity, EEventName.OnStalkAlert);
		}
	}

	// Token: 0x060041FC RID: 16892 RVA: 0x0007173A File Offset: 0x0006F93A
	private void JudgeEavesdropAlertness()
	{
		if (this.CurrentValue >= 100f)
		{
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnEavesdropFound, this.ActorComp.Entity.Id);
		}
	}

	// Token: 0x060041FD RID: 16893 RVA: 0x00071769 File Offset: 0x0006F969
	public void ExtraModifyAlterValue(float value)
	{
		this.CurrentValue += value;
		this.CurrentValue = Singleton<MathUtils>.Instance.Clamp(this.CurrentValue, 0f, 100f);
		this.ProcessAlertness();
	}

	// Token: 0x060041FE RID: 16894 RVA: 0x0007179F File Offset: 0x0006F99F
	public bool CheckInAlertRange()
	{
		return this.InAlertRange;
	}

	// Token: 0x04001038 RID: 4152
	public const float MAX_ALERT = 100f;

	// Token: 0x04001039 RID: 4153
	private const float ALERT_THRESHOLD = 1f;

	// Token: 0x0400103A RID: 4154
	private const int SHOW_UI_FRAMES = 5;

	// Token: 0x0400103B RID: 4155
	private AiAlert? AiAlertInternal;

	// Token: 0x0400103C RID: 4156
	private float CurrentValue;

	// Token: 0x0400103D RID: 4157
	private float CosLimit;

	// Token: 0x0400103E RID: 4158
	private float SquaredDistLimit;

	// Token: 0x0400103F RID: 4159
	[Nullable(2)]
	public UKuroBooleanEventBinder CallbackEvent;

	// Token: 0x04001040 RID: 4160
	private readonly global::Vector TmpVector = global::Vector.Create();

	// Token: 0x04001041 RID: 4161
	private int ShowUiFrameCount = 5;

	// Token: 0x04001042 RID: 4162
	private bool IsAlertState;

	// Token: 0x04001043 RID: 4163
	private bool IsFullAlert;

	// Token: 0x04001044 RID: 4164
	private bool InAlertRange;

	// Token: 0x04001045 RID: 4165
	[Nullable(2)]
	private CharacterActorComponent ActorComp;

	// Token: 0x04001046 RID: 4166
	private readonly AiController AiController;
}
