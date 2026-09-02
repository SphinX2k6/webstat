using System;
using System.Runtime.CompilerServices;

// Token: 0x02002F36 RID: 12086
[NullableContext(1)]
[Nullable(0)]
public class AddPassiveSkill : BuffEffect
{
	// Token: 0x06018BD9 RID: 101337 RVA: 0x006FD9AB File Offset: 0x006FBBAB
	public AddPassiveSkill(int activeHandleId, int index, RequireAndLimits requireAndLimits, BaseBuffComponent ownerBuffComponent, [Nullable(2)] CharacterBuffComponent instigatorBuffComponent) : base(activeHandleId, index, requireAndLimits, ownerBuffComponent, instigatorBuffComponent)
	{
	}

	// Token: 0x06018BDA RID: 101338 RVA: 0x006FD9C8 File Offset: 0x006FBBC8
	protected override void InitParameters(ExtraEffectParameters parameters)
	{
		string[] extraEffectParameters_ = parameters.ExtraEffectParameters_;
		if (extraEffectParameters_ == null || extraEffectParameters_.Length == 0)
		{
			this.SkillIds = Array.Empty<long>();
			return;
		}
		string[] array = extraEffectParameters_[0].Split('#', StringSplitOptions.None);
		this.SkillIds = new long[array.Length];
		for (int i = 0; i < array.Length; i++)
		{
			this.SkillIds[i] = long.Parse(array[i]);
		}
	}

	// Token: 0x06018BDB RID: 101339 RVA: 0x006FDA28 File Offset: 0x006FBC28
	public override void OnCreated()
	{
		IBuffComponent ownerBuffComponent = this.OwnerBuffComponent;
		CharacterPassiveSkillComponent characterPassiveSkillComponent = (ownerBuffComponent != null) ? ownerBuffComponent.GetPassiveSkillComponent() : null;
		if (characterPassiveSkillComponent != null && characterPassiveSkillComponent.Valid)
		{
			foreach (long skillId in this.SkillIds)
			{
				if (base.Buff == null)
				{
					Singleton<Log>.Instance.Warn(ELogModule.BuffItem, ELogAuthor.ZFJ, "没有Buff不能加被动技能", default(ReadOnlySpan<ValueTuple<string, object>>));
				}
				else
				{
					characterPassiveSkillComponent.LearnPassiveSkill(skillId, new AddPassiveSkillParam
					{
						NeedBroadcast = new bool?(true),
						PreMessageId = base.Buff.MessageId,
						CombatMessageId = base.Buff.MessageId.Value
					});
				}
			}
		}
	}

	// Token: 0x06018BDC RID: 101340 RVA: 0x006FDADD File Offset: 0x006FBCDD
	[return: Nullable(2)]
	public override object OnExecute(params object[] parameters)
	{
		return null;
	}

	// Token: 0x06018BDD RID: 101341 RVA: 0x006FDAE0 File Offset: 0x006FBCE0
	public override void OnRemoved(bool bPremature)
	{
		IBuffComponent ownerBuffComponent = this.OwnerBuffComponent;
		CharacterPassiveSkillComponent characterPassiveSkillComponent = (ownerBuffComponent != null) ? ownerBuffComponent.GetPassiveSkillComponent() : null;
		if (characterPassiveSkillComponent != null && characterPassiveSkillComponent.Valid)
		{
			foreach (long skillId in this.SkillIds)
			{
				characterPassiveSkillComponent.ForgetPassiveSkill(skillId, true);
			}
		}
	}

	// Token: 0x06018BDE RID: 101342 RVA: 0x006FDB2C File Offset: 0x006FBD2C
	public override string GetDebugEffectString()
	{
		return "添加被动技能" + string.Join<long>(",", this.SkillIds);
	}

	// Token: 0x0400C0B0 RID: 49328
	protected long[] SkillIds = Array.Empty<long>();
}
