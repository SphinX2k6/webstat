using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02003474 RID: 13428
[NullableContext(1)]
[Nullable(0)]
public class DebugInfo
{
	// Token: 0x0601C502 RID: 115970 RVA: 0x008787E4 File Offset: 0x008769E4
	public DebugInfo(string 场景模式, bool 是否场景主, int 场景号, float 时间流速, int 玩家Id, IReadOnlyList<string> 玩家位置, bool 是否联机, IReadOnlyList<int> 编队玩家, IReadOnlyList<string> 队伍buff, string 队伍属性, IReadOnlyList<FormationRoleInfo> 编队角色, IReadOnlyList<SkillButtonDebugInfo> 技能按钮)
	{
		this.场景模式 = 场景模式;
		this.是否场景主 = 是否场景主;
		this.场景号 = 场景号;
		this.时间流速 = 时间流速;
		this.玩家Id = 玩家Id;
		this.玩家位置 = 玩家位置;
		this.是否联机 = 是否联机;
		this.编队玩家 = 编队玩家;
		this.队伍buff = 队伍buff;
		this.队伍属性 = 队伍属性;
		this.编队角色 = 编队角色;
		this.技能按钮 = 技能按钮;
	}

	// Token: 0x0400E3AB RID: 58283
	public string 场景模式;

	// Token: 0x0400E3AC RID: 58284
	public bool 是否场景主;

	// Token: 0x0400E3AD RID: 58285
	public int 场景号;

	// Token: 0x0400E3AE RID: 58286
	public float 时间流速;

	// Token: 0x0400E3AF RID: 58287
	public int 玩家Id;

	// Token: 0x0400E3B0 RID: 58288
	public IReadOnlyList<string> 玩家位置;

	// Token: 0x0400E3B1 RID: 58289
	public bool 是否联机;

	// Token: 0x0400E3B2 RID: 58290
	public IReadOnlyList<int> 编队玩家;

	// Token: 0x0400E3B3 RID: 58291
	public IReadOnlyList<string> 队伍buff;

	// Token: 0x0400E3B4 RID: 58292
	public string 队伍属性;

	// Token: 0x0400E3B5 RID: 58293
	public IReadOnlyList<FormationRoleInfo> 编队角色;

	// Token: 0x0400E3B6 RID: 58294
	public IReadOnlyList<SkillButtonDebugInfo> 技能按钮;
}
