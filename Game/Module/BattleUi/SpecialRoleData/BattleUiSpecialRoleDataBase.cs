using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.BattleUi.SpecialRoleData
{
	// Token: 0x02006127 RID: 24871
	public class BattleUiSpecialRoleDataBase
	{
		// Token: 0x0603ED6F RID: 257391 RVA: 0x01019E21 File Offset: 0x01018021
		[NullableContext(1)]
		public virtual void Init(BattleUiRoleData roleData)
		{
			this.RoleData = roleData;
			this.OnInit();
		}

		// Token: 0x0603ED70 RID: 257392 RVA: 0x01019E30 File Offset: 0x01018030
		public virtual void Clear()
		{
			this.OnClear();
			this.RoleData = null;
		}

		// Token: 0x0603ED71 RID: 257393 RVA: 0x01019E3F File Offset: 0x0101803F
		public virtual void OnChangeRole(bool isCurEntity)
		{
		}

		// Token: 0x0603ED72 RID: 257394 RVA: 0x01019E41 File Offset: 0x01018041
		protected virtual void OnInit()
		{
		}

		// Token: 0x0603ED73 RID: 257395 RVA: 0x01019E43 File Offset: 0x01018043
		protected virtual void OnClear()
		{
		}

		// Token: 0x0402341C RID: 144412
		[Nullable(2)]
		protected BattleUiRoleData RoleData;
	}
}
