using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Component;
using CSharpScript.Game.Module.WuwaGo.Model.Role;

namespace CSharpScript.Game.Module.WuwaGo.Controller.Role.Capability
{
	// Token: 0x02004AFF RID: 19199
	[NullableContext(1)]
	[Nullable(0)]
	public abstract class CapabilityBase
	{
		// Token: 0x06032117 RID: 205079 RVA: 0x00C871F1 File Offset: 0x00C853F1
		protected CapabilityBase(WuWaGoRole role)
		{
		}

		// Token: 0x17008577 RID: 34167
		// (get) Token: 0x06032118 RID: 205080 RVA: 0x00C87200 File Offset: 0x00C85400
		protected EWuWaGoRoleType RoleType
		{
			get
			{
				return this.Role.Type;
			}
		}

		// Token: 0x0401D452 RID: 119890
		protected readonly WuWaGoRole Role = role;
	}
}
