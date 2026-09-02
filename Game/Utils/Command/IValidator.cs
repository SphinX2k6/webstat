using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Utils.Command
{
	// Token: 0x0200471C RID: 18204
	[NullableContext(1)]
	public interface IValidator
	{
		// Token: 0x17008194 RID: 33172
		// (get) Token: 0x0602F4B2 RID: 193714
		Func<bool> Validate { get; }
	}
}
