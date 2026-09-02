using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02001BE5 RID: 7141
[NullableContext(1)]
[Nullable(0)]
[FloroRanchEntityComponent(EFloroRanchEntityComponent.FloroRanchRoleSkillDataComponent)]
public class FloroRanchRoleSkillDataComponent : FloroRanchEntityDataBaseComponent
{
	// Token: 0x0600CFB3 RID: 53171 RVA: 0x003729D8 File Offset: 0x00370BD8
	public override void RefreshEntityData(FloroRanchPlayUnit entityData)
	{
		if (entityData.SKillData == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.FloroRanchGamePlay, ELogAuthor.BB, base.GetType().Name + " RefreshEntityData failed, SkillData is undefined", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		this.SkillData = ModelBase<FloroRanchModel>.Instance.GetFloroRanchSkillData(entityData.SKillData.SkillId);
		this.CanUseCount = entityData.SKillData.CurCanUseNum;
		this.CurDayCanUseNum = entityData.SKillData.CurDayCanUseNum;
	}

	// Token: 0x0600CFB4 RID: 53172 RVA: 0x00372A5A File Offset: 0x00370C5A
	public bool CanUseSkill()
	{
		return this.CanUseCount > 0 && this.CurDayCanUseNum > 0;
	}

	// Token: 0x0600CFB5 RID: 53173 RVA: 0x00372A70 File Offset: 0x00370C70
	public override string Info()
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(22, 2);
		defaultInterpolatedStringHandler.AppendLiteral("SkillId: ");
		defaultInterpolatedStringHandler.AppendFormatted<int>(this.SkillData.Id);
		defaultInterpolatedStringHandler.AppendLiteral(", SkillName: ");
		defaultInterpolatedStringHandler.AppendFormatted(this.SkillData.GetRealName());
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x0600CFB6 RID: 53174 RVA: 0x00372ACA File Offset: 0x00370CCA
	public override string DebugInfo()
	{
		return this.SkillData.GetRealName();
	}

	// Token: 0x040062EA RID: 25322
	[Nullable(2)]
	public FloroRanchSkillData SkillData;

	// Token: 0x040062EB RID: 25323
	public int CanUseCount;

	// Token: 0x040062EC RID: 25324
	public int CurDayCanUseNum;
}
