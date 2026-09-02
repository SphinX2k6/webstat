using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.NewWorld.Pawn.Component;

namespace CSharpScript.Game.NewWorld.Pawn.Controllers
{
	// Token: 0x020048A5 RID: 18597
	[NullableContext(1)]
	[Nullable(0)]
	public class SubEntityInteractLogicController
	{
		// Token: 0x0603074C RID: 198476 RVA: 0x00BE0F81 File Offset: 0x00BDF181
		public SubEntityInteractLogicController(CreatureDataComponent creatureDataComp)
		{
			this.CreatureDataComp = creatureDataComp;
			this.Entity = creatureDataComp.Entity;
			PawnInteractNewComponent component = this.Entity.GetComponent<PawnInteractNewComponent>();
			this.InteractComp = ((component != null) ? component.GetInteractController() : null);
		}

		// Token: 0x0603074D RID: 198477 RVA: 0x00BE0FB9 File Offset: 0x00BDF1B9
		public virtual bool Possess(Entity masterEntity, bool force = false)
		{
			return true;
		}

		// Token: 0x0603074E RID: 198478 RVA: 0x00BE0FBC File Offset: 0x00BDF1BC
		public virtual bool UnPossess(Entity masterEntity)
		{
			return true;
		}

		// Token: 0x0603074F RID: 198479 RVA: 0x00BE0FBF File Offset: 0x00BDF1BF
		public bool IsPossessed()
		{
			return this.MasterEntity != null;
		}

		// Token: 0x06030750 RID: 198480 RVA: 0x00BE0FCA File Offset: 0x00BDF1CA
		public bool IsPossessedBy(Entity masterEntity)
		{
			return this.MasterEntity != null && this.MasterEntity == masterEntity;
		}

		// Token: 0x06030751 RID: 198481 RVA: 0x00BE0FDF File Offset: 0x00BDF1DF
		public virtual void Dispose()
		{
			this.MasterEntity = null;
			this.Entity = null;
			this.CreatureDataComp = null;
			this.InteractComp = null;
		}

		// Token: 0x0401BD54 RID: 114004
		[Nullable(2)]
		public Entity MasterEntity;

		// Token: 0x0401BD55 RID: 114005
		[Nullable(2)]
		public Entity Entity;

		// Token: 0x0401BD56 RID: 114006
		[Nullable(2)]
		protected CreatureDataComponent CreatureDataComp;

		// Token: 0x0401BD57 RID: 114007
		[Nullable(2)]
		protected PawnInteractController InteractComp;

		// Token: 0x0401BD58 RID: 114008
		[StaticVariableRuleIgnore]
		protected static Vector TmpVector = Vector.Create();

		// Token: 0x0401BD59 RID: 114009
		[StaticVariableRuleIgnore]
		protected static Vector TmpVector2 = Vector.Create();
	}
}
