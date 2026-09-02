using System;
using System.Runtime.CompilerServices;

// Token: 0x020024C9 RID: 9417
public class PhantomInteractDropDownItemOptionTextId : IStaticVariableResetter
{
	// Token: 0x0601248E RID: 74894 RVA: 0x0050718C File Offset: 0x0050538C
	static PhantomInteractDropDownItemOptionTextId()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(PhantomInteractDropDownItemOptionTextId.CreateStaticDefaultValue), new Action(PhantomInteractDropDownItemOptionTextId.ResetStaticDefaultValue));
	}

	// Token: 0x0601248F RID: 74895 RVA: 0x005071AB File Offset: 0x005053AB
	public static void CreateStaticDefaultValue()
	{
		PhantomInteractDropDownItemOptionTextId.TextIds = new string[]
		{
			"PhantomDisplay_SelectAll",
			"PhantomDisplay_SelectSpecial",
			"PhantomDisplay_SelectCommon"
		};
	}

	// Token: 0x06012490 RID: 74896 RVA: 0x005071D0 File Offset: 0x005053D0
	public static void ResetStaticDefaultValue()
	{
		PhantomInteractDropDownItemOptionTextId.TextIds = null;
	}

	// Token: 0x04008EA3 RID: 36515
	[Nullable(1)]
	public static string[] TextIds;
}
