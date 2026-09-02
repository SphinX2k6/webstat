using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006DDB RID: 28123
	[NullableContext(1)]
	[Nullable(0)]
	public class ConditionPassCallback
	{
		// Token: 0x06044602 RID: 280066 RVA: 0x011C34F5 File Offset: 0x011C16F5
		public ConditionPassCallback(TConditionPassCallback callback, [Nullable(new byte[]
		{
			2,
			1
		})] object[] parameters = null)
		{
			this.Callback = callback;
			this.Params = parameters;
		}

		// Token: 0x040260FB RID: 155899
		public TConditionPassCallback Callback;

		// Token: 0x040260FC RID: 155900
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public object[] Params;
	}
}
