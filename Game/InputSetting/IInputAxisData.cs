using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.InputSetting
{
	// Token: 0x02006FEF RID: 28655
	[NullableContext(1)]
	internal interface IInputAxisData
	{
		// Token: 0x1700A4BC RID: 42172
		// (get) Token: 0x06045572 RID: 284018
		// (set) Token: 0x06045573 RID: 284019
		string KeyName { get; set; }

		// Token: 0x1700A4BD RID: 42173
		// (get) Token: 0x06045574 RID: 284020
		// (set) Token: 0x06045575 RID: 284021
		float Scale { get; set; }
	}
}
