using System;

// Token: 0x02002FBA RID: 12218
public class GameplayCueSkinDamage : GameplayCueBase
{
	// Token: 0x06018EAF RID: 102063 RVA: 0x0070F2D0 File Offset: 0x0070D4D0
	protected override void OnCreate()
	{
		WorldEntity entity = this.EntityHandle.Entity;
		CharacterSkinDamageComponent characterSkinDamageComponent = (entity != null) ? entity.GetComponent<CharacterSkinDamageComponent>() : null;
		if (characterSkinDamageComponent != null)
		{
			characterSkinDamageComponent.CuePath = base.GetPath();
			bool flag = this.IsIgnoreEnableSetting();
			characterSkinDamageComponent.IsCueIgnoreEnableSetting = flag;
			characterSkinDamageComponent.ApplySkinDamage(characterSkinDamageComponent.CuePath, flag, "GameplayCueSkinDamage生成", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
	}

	// Token: 0x06018EB0 RID: 102064 RVA: 0x0070F330 File Offset: 0x0070D530
	protected override void OnDestroy()
	{
		WorldEntity entity = this.EntityHandle.Entity;
		CharacterSkinDamageComponent characterSkinDamageComponent = (entity != null) ? entity.GetComponent<CharacterSkinDamageComponent>() : null;
		if (characterSkinDamageComponent != null)
		{
			characterSkinDamageComponent.ResetCueSkinDamage();
		}
	}

	// Token: 0x06018EB1 RID: 102065 RVA: 0x0070F35E File Offset: 0x0070D55E
	protected bool IsIgnoreEnableSetting()
	{
		return this.CueConfig.ParametersLength > 0 && this.CueConfig.Parameters(0) == "1";
	}
}
