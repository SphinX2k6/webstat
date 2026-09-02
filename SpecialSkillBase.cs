using System;
using System.Runtime.CompilerServices;

// Token: 0x02003144 RID: 12612
[NullableContext(1)]
[Nullable(0)]
public abstract class SpecialSkillBase
{
	// Token: 0x0601A1C6 RID: 106950 RVA: 0x007A9526 File Offset: 0x007A7726
	protected SpecialSkillBase(CharacterSpecialSkillComponent specialSkillComponent)
	{
		this.SpecialSkillComponent = specialSkillComponent;
	}

	// Token: 0x0601A1C7 RID: 106951 RVA: 0x007A9535 File Offset: 0x007A7735
	public static T Spawn<[Nullable(0)] T>(CharacterSpecialSkillComponent specialSkillComponent) where T : SpecialSkillBase
	{
		return (T)((object)Activator.CreateInstance(typeof(T), new object[]
		{
			specialSkillComponent
		}));
	}

	// Token: 0x0601A1C8 RID: 106952 RVA: 0x007A9555 File Offset: 0x007A7755
	public virtual void OnStart()
	{
	}

	// Token: 0x0601A1C9 RID: 106953 RVA: 0x007A9557 File Offset: 0x007A7757
	public virtual void OnActivate()
	{
	}

	// Token: 0x0601A1CA RID: 106954 RVA: 0x007A9559 File Offset: 0x007A7759
	public virtual void OnEnd()
	{
	}

	// Token: 0x0601A1CB RID: 106955 RVA: 0x007A955B File Offset: 0x007A775B
	public virtual void OnTick(float delta)
	{
	}

	// Token: 0x0601A1CC RID: 106956 RVA: 0x007A955D File Offset: 0x007A775D
	public virtual void OnEnable()
	{
	}

	// Token: 0x0601A1CD RID: 106957 RVA: 0x007A955F File Offset: 0x007A775F
	public virtual void OnDisable()
	{
	}

	// Token: 0x0601A1CE RID: 106958 RVA: 0x007A9561 File Offset: 0x007A7761
	public static void SetOptimizeEnable(bool enable)
	{
	}

	// Token: 0x0601A1CF RID: 106959 RVA: 0x007A9563 File Offset: 0x007A7763
	public virtual void EndAddMoveByInputDirect()
	{
	}

	// Token: 0x0400D18F RID: 53647
	protected readonly CharacterSpecialSkillComponent SpecialSkillComponent;
}
