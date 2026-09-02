using System;
using System.Runtime.CompilerServices;

// Token: 0x02001BE1 RID: 7137
public class FloroRanchEntityComponentBase
{
	// Token: 0x0600CF98 RID: 53144 RVA: 0x0037233B File Offset: 0x0037053B
	[NullableContext(1)]
	public void Create(FloroRanchEntityBase ownerEntity)
	{
		this.OwnerEntity = ownerEntity;
		this.OnCreate();
	}

	// Token: 0x0600CF99 RID: 53145 RVA: 0x0037234A File Offset: 0x0037054A
	public void Init()
	{
		this.OnInit();
	}

	// Token: 0x0600CF9A RID: 53146 RVA: 0x00372352 File Offset: 0x00370552
	public void Tick(float deltaTime)
	{
		if (!this.NeedTick)
		{
			return;
		}
		this.OnTick(deltaTime);
	}

	// Token: 0x0600CF9B RID: 53147 RVA: 0x00372364 File Offset: 0x00370564
	public void End()
	{
		this.OnEnd();
	}

	// Token: 0x0600CF9C RID: 53148 RVA: 0x0037236C File Offset: 0x0037056C
	protected virtual void OnCreate()
	{
	}

	// Token: 0x0600CF9D RID: 53149 RVA: 0x0037236E File Offset: 0x0037056E
	protected virtual void OnInit()
	{
	}

	// Token: 0x0600CF9E RID: 53150 RVA: 0x00372370 File Offset: 0x00370570
	protected virtual void OnTick(float deltaTime)
	{
	}

	// Token: 0x0600CF9F RID: 53151 RVA: 0x00372372 File Offset: 0x00370572
	protected virtual void OnEnd()
	{
	}

	// Token: 0x040062D7 RID: 25303
	[StaticVariableRuleIgnore]
	public static int Id;

	// Token: 0x040062D8 RID: 25304
	protected bool NeedTick;

	// Token: 0x040062D9 RID: 25305
	[Nullable(2)]
	protected FloroRanchEntityBase OwnerEntity;
}
