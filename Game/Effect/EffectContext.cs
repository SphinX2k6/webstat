using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Effect;
using UnrealEngine;

namespace CSharpScript.Game.Effect
{
	// Token: 0x02007041 RID: 28737
	[NullableContext(2)]
	[Nullable(0)]
	public class EffectContext
	{
		// Token: 0x060458B6 RID: 284854 RVA: 0x0122D1A6 File Offset: 0x0122B3A6
		public EffectContext(int? entityId, UObject sourceObject = null, bool disablePostProcess = false)
		{
			this.EntityId = entityId;
			this.SourceObject = sourceObject;
			this.DisablePostProcess = disablePostProcess;
		}

		// Token: 0x060458B7 RID: 284855 RVA: 0x0122D1C4 File Offset: 0x0122B3C4
		public EffectContext()
		{
			this.EntityId = null;
			this.SourceObject = null;
			this.DisablePostProcess = false;
		}

		// Token: 0x1700A516 RID: 42262
		// (get) Token: 0x060458B8 RID: 284856 RVA: 0x0122D1F4 File Offset: 0x0122B3F4
		// (set) Token: 0x060458B9 RID: 284857 RVA: 0x0122D1FC File Offset: 0x0122B3FC
		public int? EntityId { get; set; }

		// Token: 0x1700A517 RID: 42263
		// (get) Token: 0x060458BA RID: 284858 RVA: 0x0122D205 File Offset: 0x0122B405
		// (set) Token: 0x060458BB RID: 284859 RVA: 0x0122D20D File Offset: 0x0122B40D
		public UObject SourceObject { get; set; }

		// Token: 0x1700A518 RID: 42264
		// (get) Token: 0x060458BC RID: 284860 RVA: 0x0122D216 File Offset: 0x0122B416
		// (set) Token: 0x060458BD RID: 284861 RVA: 0x0122D21E File Offset: 0x0122B41E
		public bool DisablePostProcess { get; set; }

		// Token: 0x1700A519 RID: 42265
		// (get) Token: 0x060458BE RID: 284862 RVA: 0x0122D227 File Offset: 0x0122B427
		// (set) Token: 0x060458BF RID: 284863 RVA: 0x0122D22F File Offset: 0x0122B42F
		public EEffectCreateFromType CreateFromType { get; set; }

		// Token: 0x1700A51A RID: 42266
		// (get) Token: 0x060458C0 RID: 284864 RVA: 0x0122D238 File Offset: 0x0122B438
		// (set) Token: 0x060458C1 RID: 284865 RVA: 0x0122D240 File Offset: 0x0122B440
		public EEffectPlayFlag PlayFlag { get; set; }

		// Token: 0x1700A51B RID: 42267
		// (get) Token: 0x060458C2 RID: 284866 RVA: 0x0122D249 File Offset: 0x0122B449
		// (set) Token: 0x060458C3 RID: 284867 RVA: 0x0122D251 File Offset: 0x0122B451
		public EHitEffectType HitEffectType { get; set; }

		// Token: 0x1700A51C RID: 42268
		// (get) Token: 0x060458C4 RID: 284868 RVA: 0x0122D25A File Offset: 0x0122B45A
		// (set) Token: 0x060458C5 RID: 284869 RVA: 0x0122D262 File Offset: 0x0122B462
		public FName? AnsSlotName
		{
			get
			{
				return this.AnsSlotNameInternal;
			}
			set
			{
				if (this.CreateFromType != EEffectCreateFromType.An)
				{
					return;
				}
				this.AnsSlotNameInternal = value;
			}
		}

		// Token: 0x060458C6 RID: 284870 RVA: 0x0122D278 File Offset: 0x0122B478
		[NullableContext(1)]
		public virtual void ToKuroEffectContext(FKuroEffectContext context)
		{
			context.EntityId = this.EntityId.GetValueOrDefault();
			context.SourceObject = this.SourceObject;
			context.DisablePostProcess = this.DisablePostProcess;
			context.CreateFromType = (int)((byte)this.CreateFromType);
			context.PlayFlag = (int)((byte)this.PlayFlag);
			context.CreateFromBpEffectActor = (this.SourceObject is BP_EffectActor_C);
			context.HitEffectType = (int)((byte)this.HitEffectType);
			context.AnsSlotName = (this.AnsSlotName ?? FName.NAME_None);
		}

		// Token: 0x04026D4D RID: 159053
		private FName? AnsSlotNameInternal;
	}
}
