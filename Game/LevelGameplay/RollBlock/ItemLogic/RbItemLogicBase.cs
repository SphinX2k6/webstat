using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using Aki.Protocol;

namespace CSharpScript.Game.LevelGamePlay.RollBlock.ItemLogic
{
	// Token: 0x02006B28 RID: 27432
	public class RbItemLogicBase
	{
		// Token: 0x06043C76 RID: 277622 RVA: 0x011822FC File Offset: 0x011804FC
		[NullableContext(1)]
		public RbItemLogicBase(RbItemComponent owner)
		{
			this.Owner = owner;
			MethodInfo method = base.GetType().GetMethod("Update", BindingFlags.Instance | BindingFlags.Public);
			MethodInfo method2 = typeof(RbItemLogicBase).GetMethod("Update", BindingFlags.Instance | BindingFlags.Public);
			this.NeedUpdate = (method != null && method2 != null && method != method2);
		}

		// Token: 0x06043C77 RID: 277623 RVA: 0x01182362 File Offset: 0x01180562
		public virtual void Start([Nullable(new byte[]
		{
			0,
			1,
			1
		})] OneOf<RbBreakableObstaclePbType, RbLaserEmitterPbType> info)
		{
		}

		// Token: 0x06043C78 RID: 277624 RVA: 0x01182364 File Offset: 0x01180564
		public virtual void End()
		{
		}

		// Token: 0x06043C79 RID: 277625 RVA: 0x01182366 File Offset: 0x01180566
		public virtual void Update(float delta)
		{
		}

		// Token: 0x06043C7A RID: 277626 RVA: 0x01182368 File Offset: 0x01180568
		public virtual void OnRbItemUpdate([Nullable(new byte[]
		{
			0,
			1,
			1
		})] OneOf<RbBreakableObstaclePbType, RbLaserEmitterPbType> info)
		{
		}

		// Token: 0x06043C7B RID: 277627 RVA: 0x0118236A File Offset: 0x0118056A
		public virtual void OnStateChange(int stateId)
		{
		}

		// Token: 0x04025E83 RID: 155267
		[Nullable(2)]
		protected RbItemComponent Owner;

		// Token: 0x04025E84 RID: 155268
		public bool NeedUpdate;
	}
}
