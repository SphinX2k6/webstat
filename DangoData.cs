using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Dango.DangoLogic;

// Token: 0x02001B1A RID: 6938
[NullableContext(1)]
[Nullable(0)]
public class DangoData
{
	// Token: 0x0600C7E4 RID: 51172 RVA: 0x0034E584 File Offset: 0x0034C784
	private DangoData(int id)
	{
		this.Id = id;
	}

	// Token: 0x0600C7E5 RID: 51173 RVA: 0x0034E5F6 File Offset: 0x0034C7F6
	public static DangoData Create(int id)
	{
		DangoData dangoData = new DangoData(id);
		dangoData.Init();
		return dangoData;
	}

	// Token: 0x0600C7E6 RID: 51174 RVA: 0x0034E604 File Offset: 0x0034C804
	private void Init()
	{
		Dango? dangoById = ConfigBase<CSharpScript.Game.Module.Dango.DangoLogic.DangoConfig>.Instance.GetDangoById(this.Id);
		if (dangoById == null)
		{
			return;
		}
		this.DangoConfig = new Dango?(dangoById.Value);
		this.NameKey = dangoById.Value.Name;
		this.DiceId = dangoById.Value.DiceId;
		this.SkillId = dangoById.Value.SkillId;
		this.ModelId = dangoById.Value.ModelId;
		this.Icon = dangoById.Value.Icon;
		this.IconDamage = dangoById.Value.IconDamage;
		this.IconDamageLarge = dangoById.Value.IconDamageLarge;
		this.IconAttack = dangoById.Value.IconAttack;
		this.IconAttackLarge = dangoById.Value.IconAttackLarge;
		this.DangoSay = dangoById.Value.Dialog;
		this.DangoVoice = dangoById.Value.Audio;
		this.ModelHeight = dangoById.Value.ModelHeight;
	}

	// Token: 0x0600C7E7 RID: 51175 RVA: 0x0034E73A File Offset: 0x0034C93A
	public Dice? GetDiceConfig()
	{
		return ConfigBase<CSharpScript.Game.Module.Dango.DangoLogic.DangoConfig>.Instance.GetDiceById(this.DiceId);
	}

	// Token: 0x0600C7E8 RID: 51176 RVA: 0x0034E74C File Offset: 0x0034C94C
	public DangoSkill? GetSkillConfig()
	{
		return ConfigBase<CSharpScript.Game.Module.Dango.DangoLogic.DangoConfig>.Instance.GetDangoSkillById(this.SkillId);
	}

	// Token: 0x0600C7E9 RID: 51177 RVA: 0x0034E760 File Offset: 0x0034C960
	public DangoSkillEffect? GetSkillEffectConfig()
	{
		DangoSkill? skillConfig = this.GetSkillConfig();
		if (skillConfig == null)
		{
			return null;
		}
		return ConfigBase<CSharpScript.Game.Module.Dango.DangoLogic.DangoConfig>.Instance.GetDangoSkillEffectById(skillConfig.Value.SkillEffect);
	}

	// Token: 0x0600C7EA RID: 51178 RVA: 0x0034E7A0 File Offset: 0x0034C9A0
	public string GetDangoActiveSkillDesc()
	{
		DangoSkill? skillConfig = this.GetSkillConfig();
		string multiTextByKey = ConfigBase<TextConfig>.Instance.GetMultiTextByKey(skillConfig.Value.Name);
		string multiTextByKey2 = ConfigBase<TextConfig>.Instance.GetMultiTextByKey(skillConfig.Value.ActivateDesc);
		return ConfigBase<TextConfig>.Instance.GetMultiText("Dango_InGame_SkillActivated", new string[]
		{
			multiTextByKey,
			multiTextByKey2
		});
	}

	// Token: 0x04005FCD RID: 24525
	public int Id;

	// Token: 0x04005FCE RID: 24526
	public string NameKey = string.Empty;

	// Token: 0x04005FCF RID: 24527
	public int DiceId;

	// Token: 0x04005FD0 RID: 24528
	public int SkillId;

	// Token: 0x04005FD1 RID: 24529
	public int ModelId;

	// Token: 0x04005FD2 RID: 24530
	public string Icon = string.Empty;

	// Token: 0x04005FD3 RID: 24531
	public string IconDamage = string.Empty;

	// Token: 0x04005FD4 RID: 24532
	public string IconDamageLarge = string.Empty;

	// Token: 0x04005FD5 RID: 24533
	public string IconAttack = string.Empty;

	// Token: 0x04005FD6 RID: 24534
	public string IconAttackLarge = string.Empty;

	// Token: 0x04005FD7 RID: 24535
	public string DangoSay = string.Empty;

	// Token: 0x04005FD8 RID: 24536
	public string DangoVoice = string.Empty;

	// Token: 0x04005FD9 RID: 24537
	public int ModelHeight;

	// Token: 0x04005FDA RID: 24538
	public Dango? DangoConfig;
}
