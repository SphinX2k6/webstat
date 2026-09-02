using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.WuwaGo.Model.Role;

namespace CSharpScript.Game.Module.WuwaGo.Controller.GameplayEntity
{
	// Token: 0x02004B04 RID: 19204
	[NullableContext(2)]
	public interface IArrowShootResult
	{
		// Token: 0x17008579 RID: 34169
		// (get) Token: 0x06032148 RID: 205128
		// (set) Token: 0x06032149 RID: 205129
		WuWaGoRole HitRole { get; set; }

		// Token: 0x1700857A RID: 34170
		// (get) Token: 0x0603214A RID: 205130
		// (set) Token: 0x0603214B RID: 205131
		bool HitWall { get; set; }

		// Token: 0x1700857B RID: 34171
		// (get) Token: 0x0603214C RID: 205132
		// (set) Token: 0x0603214D RID: 205133
		float TargetDistanceMeter { get; set; }
	}
}
