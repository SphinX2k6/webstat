using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Effect;
using CSharpScript.Game.NewWorld.Pawn.Component;

// Token: 0x02002C62 RID: 11362
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class UiModelEffectController : ControllerBase<UiModelEffectController>
{
	// Token: 0x06016CDE RID: 93406 RVA: 0x00653194 File Offset: 0x00651394
	public void SetEffectAdditionTimeScaleEnable(bool bEnable, int modelId)
	{
		if (bEnable)
		{
			this.EnabledAdditionTimeScaleModelIdSet.Add(modelId);
		}
		else
		{
			this.EnabledAdditionTimeScaleModelIdSet.Remove(modelId);
		}
		bool enable = this.EnabledAdditionTimeScaleModelIdSet.Count > 0;
		Singleton<EffectSystem>.Instance.SetAdditionTimeScaleEnable(ETimeScaleSourceType.UiModel, enable);
	}

	// Token: 0x0400AFA7 RID: 44967
	private readonly HashSet<int> EnabledAdditionTimeScaleModelIdSet = new HashSet<int>();
}
