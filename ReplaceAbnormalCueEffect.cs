using System;
using System.Linq;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;

// Token: 0x02002F4C RID: 12108
[NullableContext(1)]
[Nullable(0)]
public class ReplaceAbnormalCueEffect : BuffEffect
{
	// Token: 0x06018C69 RID: 101481 RVA: 0x00700FE3 File Offset: 0x006FF1E3
	public ReplaceAbnormalCueEffect(int activeHandleId, int index, RequireAndLimits requireAndLimits, BaseBuffComponent ownerBuffComponent, [Nullable(2)] CharacterBuffComponent instigatorBuffComponent) : base(activeHandleId, index, requireAndLimits, ownerBuffComponent, instigatorBuffComponent)
	{
	}

	// Token: 0x06018C6A RID: 101482 RVA: 0x00701000 File Offset: 0x006FF200
	protected override void InitParameters(ExtraEffectParameters parameters)
	{
		string[] extraEffectParameters_ = parameters.ExtraEffectParameters_;
		if (extraEffectParameters_ != null && extraEffectParameters_.Length != 0)
		{
			this.SpecialTag = extraEffectParameters_[0];
		}
		if (extraEffectParameters_ != null && extraEffectParameters_.Length > 1)
		{
			this.TargetCueId = long.Parse(extraEffectParameters_[1]);
		}
		if (extraEffectParameters_ != null && extraEffectParameters_.Length > 2)
		{
			this.NewTargetCueId = long.Parse(extraEffectParameters_[2]);
		}
	}

	// Token: 0x06018C6B RID: 101483 RVA: 0x00701052 File Offset: 0x006FF252
	public override void OnCreated()
	{
		this.CheckTeamRolesForSpecialTag();
		Singleton<EventSystem>.Instance.Add(EEventName.OnUpdateSceneTeam, new Action(this.OnRoleJoinTeam));
	}

	// Token: 0x06018C6C RID: 101484 RVA: 0x00701076 File Offset: 0x006FF276
	public override void OnRemoved(bool bPremature)
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnUpdateSceneTeam, new Action(this.OnRoleJoinTeam));
	}

	// Token: 0x06018C6D RID: 101485 RVA: 0x00701094 File Offset: 0x006FF294
	[return: Nullable(2)]
	public override object OnExecute(params object[] parameters)
	{
		if (parameters.Length == 0 || !(parameters[0] is long))
		{
			return null;
		}
		long num = (long)parameters[0];
		if (!this.ReplaceCueEnabled)
		{
			return num;
		}
		if (num == this.TargetCueId)
		{
			return this.NewTargetCueId;
		}
		return num;
	}

	// Token: 0x06018C6E RID: 101486 RVA: 0x007010E4 File Offset: 0x006FF2E4
	[NullableContext(2)]
	public static long ApplyEffects(Entity ownerEntity, long cueId)
	{
		if (ownerEntity == null)
		{
			return cueId;
		}
		BaseBuffComponent component = ownerEntity.GetComponent<BaseBuffComponent>();
		if (component == null)
		{
			return cueId;
		}
		ExtraEffectManager buffEffectManager = component.BuffEffectManager;
		if (buffEffectManager == null)
		{
			return cueId;
		}
		foreach (ReplaceAbnormalCueEffect replaceAbnormalCueEffect in buffEffectManager.FilterById<ReplaceAbnormalCueEffect>(EExtraEffectId.ReplaceAbnormalCue, null))
		{
			object obj = replaceAbnormalCueEffect.Execute(new object[]
			{
				cueId
			});
			if (obj is long)
			{
				long num = (long)obj;
				if (num != cueId)
				{
					return num;
				}
			}
		}
		return cueId;
	}

	// Token: 0x06018C6F RID: 101487 RVA: 0x00701180 File Offset: 0x006FF380
	private void CheckTeamRolesForSpecialTag()
	{
		if (string.IsNullOrEmpty(this.SpecialTag))
		{
			this.ReplaceCueEnabled = false;
			return;
		}
		bool replaceCueEnabled = ModelBase<SceneTeamModel>.Instance.GetTeamEntities(false).Any(delegate(EntityHandle entityHandle)
		{
			WorldEntity entity = entityHandle.Entity;
			object obj = (entity != null) ? entity.GetComponent<BaseTagComponent>() : null;
			int tagIdByName = GameplayTagUtils.GetTagIdByName(this.SpecialTag);
			object obj2 = obj;
			return obj2 != null && obj2.HasTag(tagIdByName);
		});
		this.ReplaceCueEnabled = replaceCueEnabled;
	}

	// Token: 0x06018C70 RID: 101488 RVA: 0x007011C6 File Offset: 0x006FF3C6
	private void OnRoleJoinTeam()
	{
		this.CheckTeamRolesForSpecialTag();
	}

	// Token: 0x06018C71 RID: 101489 RVA: 0x007011D0 File Offset: 0x006FF3D0
	public override string GetDebugEffectString()
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(38, 4);
		defaultInterpolatedStringHandler.AppendLiteral("当队伍中有Tag[");
		defaultInterpolatedStringHandler.AppendFormatted(this.SpecialTag);
		defaultInterpolatedStringHandler.AppendLiteral("]的角色时，CueId[");
		defaultInterpolatedStringHandler.AppendFormatted<long>(this.TargetCueId);
		defaultInterpolatedStringHandler.AppendLiteral("]替换为CueId[");
		defaultInterpolatedStringHandler.AppendFormatted<long>(this.NewTargetCueId);
		defaultInterpolatedStringHandler.AppendLiteral("]，当前状态:");
		defaultInterpolatedStringHandler.AppendFormatted(this.ReplaceCueEnabled ? "生效" : "未生效");
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x0400C0EB RID: 49387
	private string SpecialTag = "";

	// Token: 0x0400C0EC RID: 49388
	private long TargetCueId;

	// Token: 0x0400C0ED RID: 49389
	private long NewTargetCueId;

	// Token: 0x0400C0EE RID: 49390
	private bool ReplaceCueEnabled;
}
