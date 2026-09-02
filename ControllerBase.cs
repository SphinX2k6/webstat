using System;
using System.Runtime.CompilerServices;

// Token: 0x02000BB3 RID: 2995
[NullableContext(1)]
[Nullable(0)]
[StaticVariableRuleIgnore]
public abstract class ControllerBase<T> : ControllerGenericBase, IStaticVariableResetter where T : class, new()
{
	// Token: 0x17000099 RID: 153
	// (get) Token: 0x060030BA RID: 12474 RVA: 0x0001AE34 File Offset: 0x00019034
	public static T Instance
	{
		get
		{
			return ControllerBase<T>._Instance;
		}
	}

	// Token: 0x060030BB RID: 12475 RVA: 0x0001AE3B File Offset: 0x0001903B
	public static T GetOrCreateInstance()
	{
		if (ControllerBase<T>._Instance == null)
		{
			ControllerBase<T>.CreateInstance();
		}
		return ControllerBase<T>._Instance;
	}

	// Token: 0x060030BC RID: 12476 RVA: 0x0001AE54 File Offset: 0x00019054
	static ControllerBase()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(ControllerBase<T>.CreateStaticDefaultValue), new Action(ControllerBase<T>.ResetStaticDefaultValue));
	}

	// Token: 0x060030BD RID: 12477 RVA: 0x0001AE73 File Offset: 0x00019073
	public static void CreateStaticDefaultValue()
	{
	}

	// Token: 0x060030BE RID: 12478 RVA: 0x0001AE75 File Offset: 0x00019075
	public static void ResetStaticDefaultValue()
	{
		ControllerBase<T>._Instance = default(T);
	}

	// Token: 0x060030BF RID: 12479 RVA: 0x0001AE82 File Offset: 0x00019082
	public static bool CreateInstance()
	{
		if (ControllerBase<T>._Instance != null)
		{
			return true;
		}
		ControllerBase<T>._Instance = Activator.CreateInstance<T>();
		return true;
	}

	// Token: 0x0400041A RID: 1050
	[Nullable(2)]
	private static T _Instance;
}
