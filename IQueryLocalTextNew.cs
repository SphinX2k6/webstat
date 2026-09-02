using System;
using System.Runtime.CompilerServices;

// Token: 0x02000057 RID: 87
public interface IQueryLocalTextNew : global::IConfigQuery, IStaticVariableResetter
{
	// Token: 0x060001B6 RID: 438
	[NullableContext(2)]
	public abstract static string GetLocalTextNew([Nullable(1)] string id, string culture = null);
}
