using System;
using System.Runtime.CompilerServices;

// Token: 0x02002217 RID: 8727
public static class MailFilterDisplayOrder
{
	// Token: 0x0400819D RID: 33181
	[Nullable(1)]
	[StaticVariableRuleIgnore]
	public static readonly EMailFilter[] mailFilterDisplayOrder = new EMailFilter[]
	{
		EMailFilter.FilterAll,
		EMailFilter.FilterFavorite,
		EMailFilter.FilterImportant
	};
}
