using System;
using System.Runtime.CompilerServices;

// Token: 0x02000BAF RID: 2991
[NullableContext(1)]
[Nullable(0)]
[StaticVariableRuleIgnore]
public abstract class ConfigBase<T> : ConfigGenericBase, IStaticVariableResetter where T : class, new()
{
	// Token: 0x17000093 RID: 147
	// (get) Token: 0x0600308B RID: 12427 RVA: 0x0001AAAC File Offset: 0x00018CAC
	public static T Instance
	{
		get
		{
			return ConfigBase<T>._Instance;
		}
	}

	// Token: 0x0600308C RID: 12428 RVA: 0x0001AAB3 File Offset: 0x00018CB3
	public static T GetOrCreateInstance()
	{
		if (ConfigBase<T>._Instance == null)
		{
			ConfigBase<T>.CreateInstance();
		}
		return ConfigBase<T>._Instance;
	}

	// Token: 0x0600308D RID: 12429 RVA: 0x0001AACC File Offset: 0x00018CCC
	public static bool CreateInstance()
	{
		if (ConfigBase<T>._Instance != null)
		{
			return true;
		}
		ConfigBase<T>._Instance = Activator.CreateInstance<T>();
		return true;
	}

	// Token: 0x0600308E RID: 12430 RVA: 0x0001AAE7 File Offset: 0x00018CE7
	static ConfigBase()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(ConfigBase<T>.CreateStaticDefaultValue), new Action(ConfigBase<T>.ResetStaticDefaultValue));
	}

	// Token: 0x0600308F RID: 12431 RVA: 0x0001AB06 File Offset: 0x00018D06
	public static void CreateStaticDefaultValue()
	{
	}

	// Token: 0x06003090 RID: 12432 RVA: 0x0001AB08 File Offset: 0x00018D08
	public static void ResetStaticDefaultValue()
	{
		ConfigBase<T>._Instance = default(T);
	}

	// Token: 0x0400040F RID: 1039
	[Nullable(2)]
	private static T _Instance;
}
