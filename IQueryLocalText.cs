using System;
using System.Runtime.CompilerServices;

// Token: 0x02000056 RID: 86
public interface IQueryLocalText : global::IConfigQuery, IStaticVariableResetter
{
	// Token: 0x060001B5 RID: 437
	[NullableContext(2)]
	public abstract static string GetLocalText(int id, string culture = null);
}
