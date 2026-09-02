using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.NewWorld.Character.Common.Component.Abilities.Follow;

namespace CSharpScript.Game.Utils.Command
{
	// Token: 0x02004717 RID: 18199
	[RequiredMember]
	public class TCommandHandleParamsAddFollower : TCommandHandleParams<ICommandTypeAddFollower>
	{
		// Token: 0x0602F4A6 RID: 193702 RVA: 0x00B36E8B File Offset: 0x00B3508B
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public TCommandHandleParamsAddFollower()
		{
		}

		// Token: 0x0401AF09 RID: 110345
		[Nullable(1)]
		[RequiredMember]
		public PlayerFollowerInfo PlayerFollowerInfo;
	}
}
