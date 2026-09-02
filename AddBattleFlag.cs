using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

// Token: 0x02002EE3 RID: 12003
[NullableContext(1)]
[Nullable(0)]
public class AddBattleFlag : BuffEffect
{
	// Token: 0x06018A7B RID: 100987 RVA: 0x006F4256 File Offset: 0x006F2456
	public AddBattleFlag(int activeHandleId, int index, RequireAndLimits requireAndLimits, BaseBuffComponent ownerBuffComponent, [Nullable(2)] CharacterBuffComponent instigatorBuffComponent) : base(activeHandleId, index, requireAndLimits, ownerBuffComponent, instigatorBuffComponent)
	{
	}

	// Token: 0x06018A7C RID: 100988 RVA: 0x006F4294 File Offset: 0x006F2494
	protected override void InitParameters(ExtraEffectParameters parameters)
	{
		this.AddBattleFlagType = (EAddBattleFlagType)int.Parse(parameters.ExtraEffectParameters_[0]);
		this.BattleFlag = parameters.ExtraEffectParameters_[2];
		EAddBattleFlagType addBattleFlagType = this.AddBattleFlagType;
		if (addBattleFlagType != EAddBattleFlagType.SkillId)
		{
			if (addBattleFlagType == EAddBattleFlagType.SkillGenre)
			{
				string[] array = parameters.ExtraEffectParameters_[1].Split('#', StringSplitOptions.None);
				this.SkillGenres = new int[array.Length];
				for (int i = 0; i < array.Length; i++)
				{
					this.SkillGenres[i] = int.Parse(array[i]);
				}
			}
		}
		else
		{
			string[] array2 = parameters.ExtraEffectParameters_[1].Split('#', StringSplitOptions.None);
			this.SkillIds = new long[array2.Length];
			for (int j = 0; j < array2.Length; j++)
			{
				this.SkillIds[j] = long.Parse(array2[j]);
			}
		}
		string text = parameters.ExtraEffectParameters_[3];
		if (!string.IsNullOrEmpty(text))
		{
			this.ExcludeSkillIds = new HashSet<long>();
			string[] array3 = text.Split('#', StringSplitOptions.None);
			for (int k = 0; k < array3.Length; k++)
			{
				this.ExcludeSkillIds.Add(long.Parse(array3[k]));
			}
		}
		this.IsApplyToVision = (int.Parse(parameters.ExtraEffectParameters_.ElementAtOrDefault(4) ?? "1") == 1);
	}

	// Token: 0x06018A7D RID: 100989 RVA: 0x006F43D0 File Offset: 0x006F25D0
	[return: Nullable(2)]
	public override object OnExecute(params object[] parameters)
	{
		bool flag;
		bool flag2;
		if (parameters.Length != 0)
		{
			object obj = parameters[0];
			if (obj is bool)
			{
				flag = (bool)obj;
				flag2 = true;
			}
			else
			{
				flag2 = false;
			}
		}
		else
		{
			flag2 = false;
		}
		if (flag2 && flag && !this.IsApplyToVision)
		{
			return null;
		}
		return this.BattleFlag;
	}

	// Token: 0x06018A7E RID: 100990 RVA: 0x006F4410 File Offset: 0x006F2610
	public override string GetDebugEffectString()
	{
		string str = string.Empty;
		switch (this.AddBattleFlagType)
		{
		case EAddBattleFlagType.AllSkill:
			str = "所有技能";
			break;
		case EAddBattleFlagType.SkillId:
			str = "技能Id " + string.Join<long>(",", this.SkillIds);
			break;
		case EAddBattleFlagType.SkillGenre:
			str = "技能类型 " + string.Join<int>(",", this.SkillGenres);
			break;
		}
		return "添加战斗标记 " + this.BattleFlag + " 到 " + str;
	}

	// Token: 0x06018A7F RID: 100991 RVA: 0x006F4496 File Offset: 0x006F2696
	protected override bool CheckExecutable()
	{
		IBuffComponent ownerBuffComponent = this.OwnerBuffComponent;
		return ownerBuffComponent != null && ownerBuffComponent.HasBuffAuthority();
	}

	// Token: 0x06018A80 RID: 100992 RVA: 0x006F44AC File Offset: 0x006F26AC
	private static void ApplyEffectsInner(Entity owner, Skill skill, bool isVision, List<string> battleFlags)
	{
		CharacterBuffComponent component = owner.GetComponent<CharacterBuffComponent>();
		ExtraEffectManager extraEffectManager = (component != null) ? component.BuffEffectManager : null;
		if (extraEffectManager != null)
		{
			foreach (AddBattleFlag addBattleFlag in extraEffectManager.FilterById<AddBattleFlag>(EExtraEffectId.AddBattleFlag, null))
			{
				if (addBattleFlag.Check(new Partial_RequirementPayload(), component))
				{
					HashSet<long> excludeSkillIds = addBattleFlag.ExcludeSkillIds;
					if (excludeSkillIds == null || !excludeSkillIds.Contains((long)skill.SkillId))
					{
						string text = null;
						switch (addBattleFlag.AddBattleFlagType)
						{
						case EAddBattleFlagType.AllSkill:
							text = (addBattleFlag.Execute(new object[]
							{
								isVision
							}) as string);
							break;
						case EAddBattleFlagType.SkillId:
							for (int i = 0; i < addBattleFlag.SkillIds.Length; i++)
							{
								if (addBattleFlag.SkillIds[i] == (long)skill.SkillId)
								{
									text = (addBattleFlag.Execute(new object[]
									{
										isVision
									}) as string);
									break;
								}
							}
							break;
						case EAddBattleFlagType.SkillGenre:
							for (int j = 0; j < addBattleFlag.SkillGenres.Length; j++)
							{
								if (addBattleFlag.SkillGenres[j] == (int)skill.SkillInfo.SkillGenre)
								{
									text = (addBattleFlag.Execute(new object[]
									{
										isVision
									}) as string);
									break;
								}
							}
							break;
						}
						if (!string.IsNullOrEmpty(text))
						{
							battleFlags.Add(text);
						}
					}
				}
			}
		}
	}

	// Token: 0x06018A81 RID: 100993 RVA: 0x006F4640 File Offset: 0x006F2840
	public static void ApplyEffects(Entity owner, Skill skill)
	{
		skill.BattleContext = new SkillBattleContext
		{
			BattleFlags = new List<string>(),
			VisionId = 0
		};
		List<string> battleFlags = skill.BattleContext.BattleFlags;
		AddBattleFlag.ApplyEffectsInner(owner, skill, false, battleFlags);
		CreatureDataComponent component = owner.GetComponent<CreatureDataComponent>();
		bool? flag = (component != null) ? new bool?(component.IsVision()) : null;
		long? num = (component != null) ? new long?(component.GetSummonerId()) : null;
		if (flag.GetValueOrDefault() && num != null)
		{
			long? num2 = num;
			long num3 = 0L;
			if (!(num2.GetValueOrDefault() == num3 & num2 != null))
			{
				EntityHandle entity = ModelBase<CreatureModel>.Instance.GetEntity(num.Value);
				WorldEntity worldEntity = (entity != null) ? entity.Entity : null;
				if (worldEntity != null)
				{
					AddBattleFlag.ApplyEffectsInner(worldEntity, skill, true, battleFlags);
				}
			}
		}
		int count = battleFlags.Count;
	}

	// Token: 0x0400BF20 RID: 48928
	private EAddBattleFlagType AddBattleFlagType = EAddBattleFlagType.AllSkill;

	// Token: 0x0400BF21 RID: 48929
	private long[] SkillIds = Array.Empty<long>();

	// Token: 0x0400BF22 RID: 48930
	private int[] SkillGenres = Array.Empty<int>();

	// Token: 0x0400BF23 RID: 48931
	[Nullable(2)]
	private HashSet<long> ExcludeSkillIds;

	// Token: 0x0400BF24 RID: 48932
	private bool IsApplyToVision = true;

	// Token: 0x0400BF25 RID: 48933
	private string BattleFlag = string.Empty;
}
