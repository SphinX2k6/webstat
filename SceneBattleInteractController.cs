using System;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Framework;
using CSharpScript.Game.Module;

// Token: 0x0200294A RID: 10570
[Nullable(new byte[]
{
	0,
	1
})]
[TickController(2)]
public class SceneBattleInteractController : ControllerBase<SceneBattleInteractController>
{
	// Token: 0x0601501B RID: 86043 RVA: 0x005CF698 File Offset: 0x005CD898
	protected override void OnTick(float delta)
	{
		if (!ModelBase<SceneBattleInteractModel>.Instance.Open)
		{
			return;
		}
		foreach (SceneBattleInteractEffect sceneBattleInteractEffect in ModelBase<SceneBattleInteractModel>.Instance.EffectMap.Values)
		{
			sceneBattleInteractEffect.OnTick(delta * Singleton<Time>.Instance.TimeDilation);
		}
	}
}
