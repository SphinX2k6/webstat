using System;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02002902 RID: 10498
[NullableContext(1)]
[Nullable(0)]
public class FormationAttrListScrollData : AttrListScrollData
{
	// Token: 0x06014D9C RID: 85404 RVA: 0x005C6BFB File Offset: 0x005C4DFB
	public FormationAttrListScrollData(int id, double baseValue, double addValue, int priority, bool isRatio, CommonComponentDefine.EAttributeType attributeType) : base(id, baseValue, addValue, priority, isRatio, attributeType)
	{
	}

	// Token: 0x06014D9D RID: 85405 RVA: 0x005C6C0C File Offset: 0x005C4E0C
	private FormationProperty? GetFormationPropertyConfig()
	{
		FormationProperty? config = ConfigFormationPropertyById.GetConfig(this.Id, true);
		if (config == null)
		{
			return null;
		}
		return new FormationProperty?(config.Value);
	}

	// Token: 0x06014D9E RID: 85406 RVA: 0x005C6C48 File Offset: 0x005C4E48
	public override string GetName()
	{
		FormationProperty? formationPropertyConfig = this.GetFormationPropertyConfig();
		if (formationPropertyConfig == null)
		{
			return "";
		}
		return formationPropertyConfig.Value.Name;
	}

	// Token: 0x06014D9F RID: 85407 RVA: 0x005C6C7C File Offset: 0x005C4E7C
	public override string GetIcon()
	{
		FormationProperty? formationPropertyConfig = this.GetFormationPropertyConfig();
		if (formationPropertyConfig == null)
		{
			return "";
		}
		return formationPropertyConfig.Value.Icon;
	}

	// Token: 0x06014DA0 RID: 85408 RVA: 0x005C6CB0 File Offset: 0x005C4EB0
	public override string GetDesc()
	{
		FormationProperty? formationPropertyConfig = this.GetFormationPropertyConfig();
		if (formationPropertyConfig == null)
		{
			return "";
		}
		return formationPropertyConfig.Value.Dec;
	}
}
