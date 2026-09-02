using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;

// Token: 0x02002F43 RID: 12099
[NullableContext(1)]
[Nullable(0)]
public class ForeverTimeScaleEffect : BuffEffect
{
	// Token: 0x06018C20 RID: 101408 RVA: 0x006FF6F8 File Offset: 0x006FD8F8
	public ForeverTimeScaleEffect(int activeHandleId, int index, RequireAndLimits requireAndLimits, BaseBuffComponent ownerBuffComponent, [Nullable(2)] CharacterBuffComponent instigatorBuffComponent) : base(activeHandleId, index, requireAndLimits, ownerBuffComponent, instigatorBuffComponent)
	{
	}

	// Token: 0x06018C21 RID: 101409 RVA: 0x006FF714 File Offset: 0x006FD914
	protected override void InitParameters(ExtraEffectParameters parameters)
	{
		string[] extraEffectParameters_ = parameters.ExtraEffectParameters_;
		if (extraEffectParameters_ == null)
		{
			return;
		}
		if (extraEffectParameters_.Length > 1)
		{
			this.Priority = int.Parse(extraEffectParameters_[1]);
		}
		if (extraEffectParameters_.Length > 2)
		{
			this.InitTimeScale = float.Parse(extraEffectParameters_[2]);
		}
		if (extraEffectParameters_.Length > 3)
		{
			this.BuffStackTimeScale = float.Parse(extraEffectParameters_[3]);
		}
	}

	// Token: 0x06018C22 RID: 101410 RVA: 0x006FF768 File Offset: 0x006FD968
	public override void OnCreated()
	{
		this.UpdateTimeScale();
		Entity exactOwnerEntity = base.ExactOwnerEntity;
		BaseBuffComponent baseBuffComponent = (exactOwnerEntity != null) ? exactOwnerEntity.CheckGetComponent<BaseBuffComponent>() : null;
		if (baseBuffComponent != null && baseBuffComponent.IsTeamBuffComponent())
		{
			this.TeamEntityIds = BaseBuffComponent.GetCurrentEntityIds();
			Singleton<EventSystem>.Instance.Add(EEventName.OnUpdateSceneTeam, new Action(this.OnChangeTeam));
		}
	}

	// Token: 0x06018C23 RID: 101411 RVA: 0x006FF7C2 File Offset: 0x006FD9C2
	public override void OnStackDecreased(int newCount, int oldCount, bool bPremature)
	{
		this.UpdateTimeScale();
	}

	// Token: 0x06018C24 RID: 101412 RVA: 0x006FF7CA File Offset: 0x006FD9CA
	public override void OnStackIncreased(int newCount, int oldCount, long? instigatorId)
	{
		this.UpdateTimeScale();
	}

	// Token: 0x06018C25 RID: 101413 RVA: 0x006FF7D2 File Offset: 0x006FD9D2
	[return: Nullable(2)]
	public override object OnExecute(params object[] parameters)
	{
		return null;
	}

	// Token: 0x06018C26 RID: 101414 RVA: 0x006FF7D8 File Offset: 0x006FD9D8
	public override void OnRemoved(bool bPremature)
	{
		Entity exactOwnerEntity = base.ExactOwnerEntity;
		BaseBuffComponent baseBuffComponent = (exactOwnerEntity != null) ? exactOwnerEntity.CheckGetComponent<BaseBuffComponent>() : null;
		foreach (BaseFrozenComponent baseFrozenComponent in (((baseBuffComponent != null) ? baseBuffComponent.GetTargetComponents<BaseFrozenComponent>(EComponent.BaseFrozenComponent, null) : null) ?? new List<BaseFrozenComponent>()))
		{
			baseFrozenComponent.RemoveForeverTimeScale(this.ActiveHandleId);
		}
		if (baseBuffComponent != null && baseBuffComponent.IsTeamBuffComponent())
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnUpdateSceneTeam, new Action(this.OnChangeTeam));
		}
	}

	// Token: 0x06018C27 RID: 101415 RVA: 0x006FF884 File Offset: 0x006FDA84
	private void UpdateTimeScale()
	{
		float initTimeScale = this.InitTimeScale;
		float buffStackTimeScale = this.BuffStackTimeScale;
		IActiveBuff buff = base.Buff;
		float timeDilation = initTimeScale + buffStackTimeScale * (float)((buff != null) ? buff.StackCount : 1);
		Entity exactOwnerEntity = base.ExactOwnerEntity;
		BaseBuffComponent baseBuffComponent = (exactOwnerEntity != null) ? exactOwnerEntity.CheckGetComponent<BaseBuffComponent>() : null;
		foreach (BaseFrozenComponent baseFrozenComponent in (((baseBuffComponent != null) ? baseBuffComponent.GetTargetComponents<BaseFrozenComponent>(EComponent.BaseFrozenComponent, null) : null) ?? new List<BaseFrozenComponent>()))
		{
			baseFrozenComponent.SetForeverTimeScale(this.ActiveHandleId, this.Priority, timeDilation);
		}
	}

	// Token: 0x06018C28 RID: 101416 RVA: 0x006FF930 File Offset: 0x006FDB30
	private void OnChangeTeam()
	{
		List<int> newOrRemoveTeamEntityIds = BaseBuffComponent.GetNewOrRemoveTeamEntityIds(this.TeamEntityIds, true);
		float num;
		if (newOrRemoveTeamEntityIds.Count <= 0)
		{
			num = 0f;
		}
		else
		{
			float initTimeScale = this.InitTimeScale;
			float buffStackTimeScale = this.BuffStackTimeScale;
			IActiveBuff buff = base.Buff;
			num = initTimeScale + buffStackTimeScale * (float)((buff != null) ? buff.StackCount : 1);
		}
		float timeDilation = num;
		foreach (int id in newOrRemoveTeamEntityIds)
		{
			CharacterModel instance = ModelBase<CharacterModel>.Instance;
			object obj;
			if (instance == null)
			{
				obj = null;
			}
			else
			{
				EntityHandle handle = instance.GetHandle(id);
				if (handle == null)
				{
					obj = null;
				}
				else
				{
					WorldEntity entity = handle.Entity;
					obj = ((entity != null) ? entity.CheckGetComponent<BaseFrozenComponent>() : null);
				}
			}
			object obj2 = obj;
			if (obj2 != null)
			{
				obj2.SetForeverTimeScale(this.ActiveHandleId, this.Priority, timeDilation);
			}
		}
		foreach (int id2 in BaseBuffComponent.GetNewOrRemoveTeamEntityIds(this.TeamEntityIds, false))
		{
			CharacterModel instance2 = ModelBase<CharacterModel>.Instance;
			object obj3;
			if (instance2 == null)
			{
				obj3 = null;
			}
			else
			{
				EntityHandle handle2 = instance2.GetHandle(id2);
				if (handle2 == null)
				{
					obj3 = null;
				}
				else
				{
					WorldEntity entity2 = handle2.Entity;
					obj3 = ((entity2 != null) ? entity2.CheckGetComponent<BaseFrozenComponent>() : null);
				}
			}
			object obj4 = obj3;
			if (obj4 != null)
			{
				obj4.RemoveForeverTimeScale(this.ActiveHandleId);
			}
		}
		this.TeamEntityIds = BaseBuffComponent.GetCurrentEntityIds();
	}

	// Token: 0x06018C29 RID: 101417 RVA: 0x006FFA80 File Offset: 0x006FDC80
	public override string GetDebugEffectString()
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(29, 3);
		defaultInterpolatedStringHandler.AppendLiteral("设置时间膨胀 初始倍率");
		defaultInterpolatedStringHandler.AppendFormatted<float>(this.InitTimeScale);
		defaultInterpolatedStringHandler.AppendLiteral(" + buff层数");
		IActiveBuff buff = base.Buff;
		defaultInterpolatedStringHandler.AppendFormatted<int?>((buff != null) ? new int?(buff.StackCount) : null);
		defaultInterpolatedStringHandler.AppendLiteral(" * 层数变更系数");
		defaultInterpolatedStringHandler.AppendFormatted<float>(this.BuffStackTimeScale);
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x0400C0D6 RID: 49366
	protected int Priority;

	// Token: 0x0400C0D7 RID: 49367
	protected float InitTimeScale;

	// Token: 0x0400C0D8 RID: 49368
	protected float BuffStackTimeScale;

	// Token: 0x0400C0D9 RID: 49369
	private List<int> TeamEntityIds = new List<int>();
}
