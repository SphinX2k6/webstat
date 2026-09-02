using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Typing
{
	// Token: 0x0200446C RID: 17516
	[NullableContext(1)]
	[Nullable(0)]
	public class FKuroDataTableFunctionLibrary
	{
		// Token: 0x0602E430 RID: 189488
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern IntPtr GetDataTableAllRowNames(UDataTable Table);

		// Token: 0x0602E431 RID: 189489
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern IntPtr GetDataTableRowFromName(UDataTable Table, string RowName);

		// Token: 0x0602E432 RID: 189490
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern IntPtr[] GetDataTableAllRows(UDataTable Table);

		// Token: 0x0602E433 RID: 189491
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static extern void GetDataTableAllRowWithKeys(UDataTable Table, ref IntPtr OutRowNames, ref IntPtr[] OutRows);
	}
}
