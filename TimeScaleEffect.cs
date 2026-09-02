using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

// Token: 0x02002F35 RID: 12085
[NullableContext(1)]
[Nullable(0)]
public class TimeScaleEffect : BuffEffect
{
	// Token: 0x06018BCC RID: 101324 RVA: 0x006FD424 File Offset: 0x006FB624
	public TimeScaleEffect(int activeHandleId, int index, RequireAndLimits requireAndLimits, BaseBuffComponent ownerBuffComponent, [Nullable(2)] CharacterBuffComponent instigatorBuffComponent) : base(activeHandleId, index, requireAndLimits, ownerBuffComponent, instigatorBuffComponent)
	{
	}

	// Token: 0x06018BCD RID: 101325 RVA: 0x006FD44C File Offset: 0x006FB64C
	protected override void InitParameters(ExtraEffectParameters parameters)
	{
		string[] extraEffectParameters_ = parameters.ExtraEffectParameters_;
		if (extraEffectParameters_ == null)
		{
			return;
		}
		if (extraEffectParameters_.Length != 0)
		{
			this.Priority = int.Parse(extraEffectParameters_[0]);
		}
		if (extraEffectParameters_.Length > 1)
		{
			this.Dilation = float.Parse(extraEffectParameters_[1]);
		}
		float num = float.Parse((extraEffectParameters_.Length > 3) ? extraEffectParameters_[3] : "-1");
		this.CurveId = ((Math.Abs(num % 1f) < float.Epsilon) ? ((int)num) : -1);
	}

	// Token: 0x06018BCE RID: 101326 RVA: 0x006FD4BE File Offset: 0x006FB6BE
	public override void OnCreated()
	{
		this.AddTimeScaleByBuff();
	}

	// Token: 0x06018BCF RID: 101327 RVA: 0x006FD4C6 File Offset: 0x006FB6C6
	[return: Nullable(2)]
	public override object OnExecute(params object[] parameters)
	{
		return null;
	}

	// Token: 0x06018BD0 RID: 101328 RVA: 0x006FD4C9 File Offset: 0x006FB6C9
	public override void OnRemoved(bool bPremature)
	{
		this.Active = false;
		this.RemoveTimeScaleByBuff();
		this.CurveDt = null;
	}

	// Token: 0x06018BD1 RID: 101329 RVA: 0x006FD4DF File Offset: 0x006FB6DF
	public void StartTimeScaleEffect()
	{
		this.AddTimeScaleByBuff();
	}

	// Token: 0x06018BD2 RID: 101330 RVA: 0x006FD4E7 File Offset: 0x006FB6E7
	public void StopTimeScaleEffect()
	{
		this.RemoveTimeScaleByBuff();
	}

	// Token: 0x06018BD3 RID: 101331 RVA: 0x006FD4EF File Offset: 0x006FB6EF
	private void AddTimeScaleByBuff()
	{
		if (this.CurveId != -1 && this.CurveDt == null)
		{
			Singleton<ResourceSystem>.Instance.LoadAsync<UDataTable>("/Game/Aki/Data/Fight/DT_BuffTimeScaleCurve.DT_BuffTimeScaleCurve", delegate([Nullable(2)] UDataTable table, string _)
			{
				if (!this.Active)
				{
					return;
				}
				this.CurveDt = table;
				this.AddTimeScaleByBuffInner();
			}, 100, "js_undefined");
			return;
		}
		this.AddTimeScaleByBuffInner();
	}

	// Token: 0x06018BD4 RID: 101332 RVA: 0x006FD52C File Offset: 0x006FB72C
	private void AddTimeScaleByBuffInner()
	{
		STimeScale stimeScale = (this.CurveDt != null) ? DataTableUtil.GetDataTableRow<STimeScale>(this.CurveDt, this.CurveId.ToString()) : null;
		Entity exactOwnerEntity = base.ExactOwnerEntity;
		BaseBuffComponent baseBuffComponent = (exactOwnerEntity != null) ? exactOwnerEntity.CheckGetComponent<BaseBuffComponent>() : null;
		foreach (BaseFrozenComponent baseFrozenComponent in (((baseBuffComponent != null) ? baseBuffComponent.GetTargetComponents<BaseFrozenComponent>(EComponent.BaseFrozenComponent, null) : null) ?? new List<BaseFrozenComponent>()))
		{
			int activeHandleId = this.ActiveHandleId;
			int priority = this.Priority;
			double timeDilation = (double)this.Dilation;
			float? num = (stimeScale != null) ? new float?(stimeScale.时间膨胀时长) : null;
			baseFrozenComponent.AddTimeScaleByBuff(activeHandleId, priority, timeDilation, (num != null) ? new double?((double)num.GetValueOrDefault()) : null, (stimeScale != null) ? stimeScale.时间膨胀变化曲线 : null);
		}
		if (baseBuffComponent != null && baseBuffComponent.IsTeamBuffComponent())
		{
			this.TeamEntityIds = BaseBuffComponent.GetCurrentEntityIds();
			Singleton<EventSystem>.Instance.Add(EEventName.OnUpdateSceneTeam, new Action(this.OnChangeTeam));
		}
	}

	// Token: 0x06018BD5 RID: 101333 RVA: 0x006FD65C File Offset: 0x006FB85C
	private void RemoveTimeScaleByBuff()
	{
		Entity exactOwnerEntity = base.ExactOwnerEntity;
		BaseBuffComponent baseBuffComponent = (exactOwnerEntity != null) ? exactOwnerEntity.CheckGetComponent<BaseBuffComponent>() : null;
		foreach (BaseFrozenComponent baseFrozenComponent in (((baseBuffComponent != null) ? baseBuffComponent.GetTargetComponents<BaseFrozenComponent>(EComponent.BaseFrozenComponent, null) : null) ?? new List<BaseFrozenComponent>()))
		{
			baseFrozenComponent.RemoveTimeScaleByBuff(this.ActiveHandleId);
		}
		if (baseBuffComponent != null && baseBuffComponent.IsTeamBuffComponent())
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnUpdateSceneTeam, new Action(this.OnChangeTeam));
		}
	}

	// Token: 0x06018BD6 RID: 101334 RVA: 0x006FD708 File Offset: 0x006FB908
	private void OnChangeTeam()
	{
		List<int> newOrRemoveTeamEntityIds = BaseBuffComponent.GetNewOrRemoveTeamEntityIds(this.TeamEntityIds, true);
		STimeScale stimeScale = null;
		if (newOrRemoveTeamEntityIds.Count > 0)
		{
			stimeScale = ((this.CurveDt != null) ? DataTableUtil.GetDataTableRow<STimeScale>(this.CurveDt, this.CurveId.ToString()) : null);
		}
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
				int activeHandleId = this.ActiveHandleId;
				int priority = this.Priority;
				double timeDilation = (double)this.Dilation;
				float? num = (stimeScale != null) ? new float?(stimeScale.时间膨胀时长) : null;
				obj2.AddTimeScaleByBuff(activeHandleId, priority, timeDilation, (num != null) ? new double?((double)num.GetValueOrDefault()) : null, (stimeScale != null) ? stimeScale.时间膨胀变化曲线 : null);
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
				obj4.RemoveTimeScaleByBuff(this.ActiveHandleId);
			}
		}
		this.TeamEntityIds = BaseBuffComponent.GetCurrentEntityIds();
	}

	// Token: 0x06018BD7 RID: 101335 RVA: 0x006FD8A8 File Offset: 0x006FBAA8
	public override string GetDebugEffectString()
	{
		Entity exactOwnerEntity = base.ExactOwnerEntity;
		BaseBuffComponent baseBuffComponent = (exactOwnerEntity != null) ? exactOwnerEntity.CheckGetComponent<BaseBuffComponent>() : null;
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler;
		if (this.CurveId == -1)
		{
			defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(11, 2);
			defaultInterpolatedStringHandler.AppendFormatted((baseBuffComponent != null && baseBuffComponent.IsTeamBuffComponent()) ? "编队buff" : "非编队buff");
			defaultInterpolatedStringHandler.AppendLiteral(",设置时间膨胀(倍率");
			defaultInterpolatedStringHandler.AppendFormatted<float>(this.Dilation);
			defaultInterpolatedStringHandler.AppendLiteral(")");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}
		defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(14, 3);
		defaultInterpolatedStringHandler.AppendFormatted((baseBuffComponent != null && baseBuffComponent.IsTeamBuffComponent()) ? "编队buff" : "非编队buff");
		defaultInterpolatedStringHandler.AppendLiteral(",设置时间膨胀(倍率");
		defaultInterpolatedStringHandler.AppendFormatted<float>(this.Dilation);
		defaultInterpolatedStringHandler.AppendLiteral(" 曲线");
		defaultInterpolatedStringHandler.AppendFormatted<int>(this.CurveId);
		defaultInterpolatedStringHandler.AppendLiteral(")");
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x0400C0AA RID: 49322
	protected int Priority;

	// Token: 0x0400C0AB RID: 49323
	protected float Dilation;

	// Token: 0x0400C0AC RID: 49324
	protected int CurveId = -1;

	// Token: 0x0400C0AD RID: 49325
	[Nullable(2)]
	protected UDataTable CurveDt;

	// Token: 0x0400C0AE RID: 49326
	protected bool Active = true;

	// Token: 0x0400C0AF RID: 49327
	private List<int> TeamEntityIds = new List<int>();
}
