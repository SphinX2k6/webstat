using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Utils.ResponsibilityChain;

namespace CSharpScript.Game.NewWorld.Character.Common.Component.Abilities.Follow
{
	// Token: 0x02004977 RID: 18807
	public class EntityHandleParameterContext : IParameterContext
	{
		// Token: 0x06031291 RID: 201361 RVA: 0x00C3DE6F File Offset: 0x00C3C06F
		[NullableContext(1)]
		public EntityHandleParameterContext(EntityHandle entityHandle)
		{
		}

		// Token: 0x06031292 RID: 201362 RVA: 0x00C3DE7E File Offset: 0x00C3C07E
		public bool IsValid()
		{
			return this.EntityHandle.Valid;
		}

		// Token: 0x0401C4C8 RID: 115912
		[Nullable(1)]
		public EntityHandle EntityHandle = entityHandle;

		// Token: 0x0401C4C9 RID: 115913
		public EPlayerFollowerHandlerType? OutPlayerFollowerHandlerType;
	}
}
