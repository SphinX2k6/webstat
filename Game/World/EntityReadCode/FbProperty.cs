using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.World.EntityReadCode
{
	// Token: 0x020046D9 RID: 18137
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class FbProperty : Singleton<FbProperty>
	{
		// Token: 0x0401ADDF RID: 110047
		public readonly Dictionary<string, HashSet<string>> AllPropertySet = new Dictionary<string, HashSet<string>>();

		// Token: 0x0401ADE0 RID: 110048
		public readonly Dictionary<string, HashSet<string>> InitPropertySet = new Dictionary<string, HashSet<string>>();

		// Token: 0x0401ADE1 RID: 110049
		public readonly HashSet<string> CreateClassSet = new HashSet<string>();
	}
}
