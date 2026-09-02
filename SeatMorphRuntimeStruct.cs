using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.NewWorld.SceneItem;

// Token: 0x02001795 RID: 6037
public class SeatMorphRuntimeStruct
{
	// Token: 0x0600AA6F RID: 43631 RVA: 0x002D75F1 File Offset: 0x002D57F1
	public void SetTargetSeatMorph(double v)
	{
		this.TargetSeatMorph = Singleton<MathUtils>.Instance.Clamp(v, 0.0, 1.0);
	}

	// Token: 0x0600AA70 RID: 43632 RVA: 0x002D7616 File Offset: 0x002D5816
	[NullableContext(1)]
	public SeatMorphRuntimeStruct(Entity seatEntity, int charEntityId)
	{
		this.SeatEntityId = seatEntity.Id;
		this.CharEntityId = charEntityId;
		this.SceneItemProceduralMatComp = seatEntity.GetComponent<SceneItemProceduralMaterialComponent>();
	}

	// Token: 0x0600AA71 RID: 43633 RVA: 0x002D763D File Offset: 0x002D583D
	public bool TrySetTargetSeatMorph(int charEntityId, double v)
	{
		if (this.CharEntityId != charEntityId)
		{
			if (this.TargetSeatMorph != 0.0)
			{
				return false;
			}
			this.CharEntityId = charEntityId;
		}
		this.SetTargetSeatMorph(v);
		return true;
	}

	// Token: 0x0600AA72 RID: 43634 RVA: 0x002D766C File Offset: 0x002D586C
	public bool Update(float delta)
	{
		if (Singleton<EntitySystem>.Instance.Get(this.SeatEntityId) == null)
		{
			return true;
		}
		if (Singleton<EntitySystem>.Instance.Get(this.CharEntityId) == null && this.TargetSeatMorph != 0.0)
		{
			this.TargetSeatMorph = 0.0;
		}
		if (this.SceneItemProceduralMatComp == null)
		{
			return this.TargetSeatMorph < 0.0001;
		}
		if (this.TargetSeatMorph > this.CurrentSeatMorph)
		{
			this.CurrentSeatMorph = this.TargetSeatMorph;
			this.SceneItemProceduralMatComp.SetCustomPrimitiveData(SceneItemProceduralMaterialComponent.ECustomPrimitiveDataSceneItemType.Chair, (float)this.CurrentSeatMorph);
			return false;
		}
		if (this.CurrentSeatMorph - this.TargetSeatMorph < 0.0001)
		{
			return this.CurrentSeatMorph < 0.0001;
		}
		this.CurrentSeatMorph = Singleton<MathUtils>.Instance.InterpConstantTo(this.CurrentSeatMorph, this.TargetSeatMorph, (double)delta, 0.0005);
		this.SceneItemProceduralMatComp.SetCustomPrimitiveData(SceneItemProceduralMaterialComponent.ECustomPrimitiveDataSceneItemType.Chair, (float)this.CurrentSeatMorph);
		return false;
	}

	// Token: 0x04005018 RID: 20504
	private int SeatEntityId;

	// Token: 0x04005019 RID: 20505
	private double TargetSeatMorph;

	// Token: 0x0400501A RID: 20506
	private double CurrentSeatMorph;

	// Token: 0x0400501B RID: 20507
	[Nullable(2)]
	private SceneItemProceduralMaterialComponent SceneItemProceduralMatComp;

	// Token: 0x0400501C RID: 20508
	private int CharEntityId;
}
