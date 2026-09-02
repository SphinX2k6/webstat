using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02002FFC RID: 12284
[NullableContext(1)]
[Nullable(0)]
public class AkComponentDynamicConditionProxy : IDynamicConditionSwitch
{
	// Token: 0x06019085 RID: 102533 RVA: 0x0071ACC4 File Offset: 0x00718EC4
	public void Init(CharacterActorComponent actor, EntityAudioConfig config)
	{
		this.Clear();
		if (config.BoneHiddenSwitchLength > 0)
		{
			BoneHiddenSwitch boneHiddenSwitch = new BoneHiddenSwitch();
			boneHiddenSwitch.Init(actor, config);
			this.Conditions.Add(boneHiddenSwitch);
		}
	}

	// Token: 0x06019086 RID: 102534 RVA: 0x0071ACFC File Offset: 0x00718EFC
	public void Do(CharacterActorComponent actor)
	{
		foreach (IDynamicConditionSwitch dynamicConditionSwitch in this.Conditions)
		{
			dynamicConditionSwitch.Do(actor);
		}
	}

	// Token: 0x06019087 RID: 102535 RVA: 0x0071AD50 File Offset: 0x00718F50
	public void Clear()
	{
		foreach (IDynamicConditionSwitch dynamicConditionSwitch in this.Conditions)
		{
			dynamicConditionSwitch.Clear();
		}
		this.Conditions.Clear();
	}

	// Token: 0x0400C3EE RID: 50158
	private readonly List<IDynamicConditionSwitch> Conditions = new List<IDynamicConditionSwitch>();
}
