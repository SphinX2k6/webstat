using System;
using System.Runtime.CompilerServices;

// Token: 0x02002FB8 RID: 12216
[NullableContext(2)]
[Nullable(0)]
public class GameplayCueRtpc : GameplayCueMagnitude
{
	// Token: 0x06018E9E RID: 102046 RVA: 0x0070EE00 File Offset: 0x0070D000
	protected override void OnInit()
	{
		base.OnInit();
		this.RtpcKey = ((this.CueConfig.ParametersLength > 0) ? this.CueConfig.Parameters(0) : string.Empty);
		this.SendZeroOnDestroy = (this.CueConfig.ParametersLength > 1 && this.CueConfig.Parameters(1) == "1");
		WorldEntity entity = this.EntityHandle.Entity;
		CreatureDataComponent creatureDataComponent = (entity != null) ? entity.GetComponent<CreatureDataComponent>() : null;
		int playerId = ModelBase<CreatureModel>.Instance.GetPlayerId();
		int? num = (creatureDataComponent != null) ? new int?(creatureDataComponent.GetPlayerId()) : null;
		this.DisableByTeammate = !(playerId == num.GetValueOrDefault() & num != null);
		if (this.DisableByTeammate)
		{
			return;
		}
		WorldEntity entity2 = this.EntityHandle.Entity;
		this.ActorComp = ((entity2 != null) ? entity2.GetComponent<BaseActorComponent>() : null);
	}

	// Token: 0x06018E9F RID: 102047 RVA: 0x0070EEE3 File Offset: 0x0070D0E3
	protected override bool UseMagnitude()
	{
		return !this.DisableByTeammate && base.UseMagnitude();
	}

	// Token: 0x06018EA0 RID: 102048 RVA: 0x0070EEF5 File Offset: 0x0070D0F5
	protected override void OnDestroy()
	{
		if (this.SendZeroOnDestroy)
		{
			this.SetRtpcValue(0f);
		}
		this.ActorComp = null;
		base.OnDestroy();
	}

	// Token: 0x06018EA1 RID: 102049 RVA: 0x0070EF17 File Offset: 0x0070D117
	protected override void OnSetMagnitude(float normalizedValue)
	{
		this.SetRtpcValue(normalizedValue);
	}

	// Token: 0x06018EA2 RID: 102050 RVA: 0x0070EF20 File Offset: 0x0070D120
	protected override float Normalize()
	{
		return this.Value;
	}

	// Token: 0x06018EA3 RID: 102051 RVA: 0x0070EF28 File Offset: 0x0070D128
	private void SetRtpcValue(float value)
	{
		if (this.ActorComp == null)
		{
			return;
		}
		Singleton<AudioSystem>.Instance.SetRtpcValue(this.RtpcKey, value, new SetRtpcValueArgs?(new SetRtpcValueArgs
		{
			Actor = this.ActorComp.Owner
		}));
	}

	// Token: 0x0400C2B4 RID: 49844
	private bool DisableByTeammate;

	// Token: 0x0400C2B5 RID: 49845
	private BaseActorComponent ActorComp;

	// Token: 0x0400C2B6 RID: 49846
	private string RtpcKey;

	// Token: 0x0400C2B7 RID: 49847
	private bool SendZeroOnDestroy;
}
