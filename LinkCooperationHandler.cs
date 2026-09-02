using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Battle;

// Token: 0x020017AF RID: 6063
public class LinkCooperationHandler : ICooperationHandler
{
	// Token: 0x0600AB1E RID: 43806 RVA: 0x002DBBEC File Offset: 0x002D9DEC
	[NullableContext(1)]
	public bool Trigger(SceneTeamItem goDownRole, SceneTeamItem goBattleRole)
	{
		if (!goBattleRole.IsAutoRole())
		{
			return false;
		}
		WorldEntity entity = goBattleRole.EntityHandle.Entity;
		if (entity == null)
		{
			return false;
		}
		if (!ModelBase<BattleLinkModel>.Instance.CanUseLinkSkill(new int?(entity.Id)))
		{
			return false;
		}
		long num;
		if (this.TriggerCd.TryGetValue(entity.Id, out num) && (float)(DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() - num) < 200f)
		{
			return false;
		}
		this.TriggerCd[entity.Id] = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
		ControllerBase<BattleLinkController>.Instance.UseLinkSkill(entity);
		return true;
	}

	// Token: 0x0600AB1F RID: 43807 RVA: 0x002DBC85 File Offset: 0x002D9E85
	public void Clear()
	{
		this.TriggerCd.Clear();
	}

	// Token: 0x0400516B RID: 20843
	[Nullable(1)]
	private readonly Dictionary<int, long> TriggerCd = new Dictionary<int, long>();
}
