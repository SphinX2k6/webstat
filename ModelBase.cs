using System;
using System.Runtime.CompilerServices;

// Token: 0x02000BB7 RID: 2999
[NullableContext(1)]
[Nullable(0)]
[StaticVariableRuleIgnore]
public abstract class ModelBase<T> : ModelGenericBase, IStaticVariableResetter where T : class, new()
{
	// Token: 0x1700009B RID: 155
	// (get) Token: 0x060030D1 RID: 12497 RVA: 0x0001AEF9 File Offset: 0x000190F9
	public static T Instance
	{
		get
		{
			return ModelBase<T>._Instance;
		}
	}

	// Token: 0x060030D2 RID: 12498 RVA: 0x0001AF00 File Offset: 0x00019100
	public static T GetOrCreateInstance()
	{
		if (ModelBase<T>._Instance == null)
		{
			ModelBase<T>.CreateInstance();
		}
		return ModelBase<T>._Instance;
	}

	// Token: 0x060030D3 RID: 12499 RVA: 0x0001AF19 File Offset: 0x00019119
	static ModelBase()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(ModelBase<T>.CreateStaticDefaultValue), new Action(ModelBase<T>.ResetStaticDefaultValue));
	}

	// Token: 0x060030D4 RID: 12500 RVA: 0x0001AF38 File Offset: 0x00019138
	public static void CreateStaticDefaultValue()
	{
	}

	// Token: 0x060030D5 RID: 12501 RVA: 0x0001AF3A File Offset: 0x0001913A
	public static void ResetStaticDefaultValue()
	{
		ModelBase<T>._Instance = default(T);
	}

	// Token: 0x060030D6 RID: 12502 RVA: 0x0001AF47 File Offset: 0x00019147
	public static bool CreateInstance()
	{
		if (ModelBase<T>._Instance != null)
		{
			return true;
		}
		ModelBase<T>._Instance = Activator.CreateInstance<T>();
		return true;
	}

	// Token: 0x0400041C RID: 1052
	[Nullable(2)]
	private static T _Instance;
}
