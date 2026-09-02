using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;

// Token: 0x02003139 RID: 12601
[NullableContext(1)]
[Nullable(0)]
public abstract class SkillTriggerBaseHandle
{
	// Token: 0x0601A171 RID: 106865 RVA: 0x007A72C4 File Offset: 0x007A54C4
	protected SkillTriggerBaseHandle(Entity entity)
	{
		this.Entity = entity;
	}

	// Token: 0x0601A172 RID: 106866 RVA: 0x007A72D3 File Offset: 0x007A54D3
	public static T Spawn<[Nullable(0)] T>(Entity entity) where T : SkillTriggerBaseHandle
	{
		T t = (T)((object)Activator.CreateInstance(typeof(T), new object[]
		{
			entity
		}));
		t.Create();
		return t;
	}

	// Token: 0x0601A173 RID: 106867 RVA: 0x007A72FE File Offset: 0x007A54FE
	public virtual void Create()
	{
	}

	// Token: 0x0601A174 RID: 106868 RVA: 0x007A7300 File Offset: 0x007A5500
	public virtual void Destroy()
	{
	}

	// Token: 0x0601A175 RID: 106869 RVA: 0x007A7302 File Offset: 0x007A5502
	public virtual void AddSkillTrigger(SkillTriggerBase skillTrigger, int skillId, SSkillInfo info)
	{
	}

	// Token: 0x0400D15B RID: 53595
	protected readonly Entity Entity;
}
