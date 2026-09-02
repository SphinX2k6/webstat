using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Utils.StaticVariableReset;

// Token: 0x020000A1 RID: 161
[StaticVariablePriority(100)]
public class EventConstant : IStaticVariableResetter
{
	// Token: 0x0600041B RID: 1051 RVA: 0x00018409 File Offset: 0x00016609
	static EventConstant()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(EventConstant.CreateStaticDefaultValue), new Action(EventConstant.ResetStaticDefaultValue));
	}

	// Token: 0x0600041C RID: 1052 RVA: 0x00018428 File Offset: 0x00016628
	public static void CreateStaticDefaultValue()
	{
		EventConstant.NameStateMap = new Dictionary<Enum, Stat>();
		EventConstant.HandleStatMap = new Dictionary<MethodInfo, Stat>();
	}

	// Token: 0x0600041D RID: 1053 RVA: 0x0001843E File Offset: 0x0001663E
	public static void ResetStaticDefaultValue()
	{
		EventConstant.NameStateMap = null;
		EventConstant.HandleStatMap = null;
	}

	// Token: 0x040003DD RID: 989
	[Nullable(1)]
	public static Dictionary<Enum, Stat> NameStateMap;

	// Token: 0x040003DE RID: 990
	[Nullable(1)]
	public static Dictionary<MethodInfo, Stat> HandleStatMap;
}
