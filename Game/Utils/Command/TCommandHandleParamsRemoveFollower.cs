using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Utils.Command
{
	// Token: 0x02004718 RID: 18200
	[RequiredMember]
	public class TCommandHandleParamsRemoveFollower : TCommandHandleParams<ICommandTypeRemoveFollower>
	{
		// Token: 0x0602F4A7 RID: 193703 RVA: 0x00B36E93 File Offset: 0x00B35093
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public TCommandHandleParamsRemoveFollower()
		{
		}

		// Token: 0x0401AF0A RID: 110346
		[RequiredMember]
		public long CreatureDataId;
	}
}
