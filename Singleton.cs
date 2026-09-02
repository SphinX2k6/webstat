using System;
using System.Runtime.CompilerServices;

// Token: 0x02000BBA RID: 3002
[StaticVariableRuleIgnore]
public class Singleton<[Nullable(1)] T> : SingletonGenericBase, ISingleton, IStaticVariableResetter where T : class, new()
{
	// Token: 0x060030DB RID: 12507 RVA: 0x0001AF78 File Offset: 0x00019178
	static Singleton()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(Singleton<T>.CreateStaticDefaultValue), new Action(Singleton<T>.ResetStaticDefaultValue));
	}

	// Token: 0x060030DC RID: 12508 RVA: 0x0001AF97 File Offset: 0x00019197
	public static void CreateStaticDefaultValue()
	{
	}

	// Token: 0x060030DD RID: 12509 RVA: 0x0001AF99 File Offset: 0x00019199
	public static void ResetStaticDefaultValue()
	{
		Singleton<T> singleton = Singleton<T>._instance as Singleton<T>;
		if (singleton != null)
		{
			singleton.OnClear();
		}
		Singleton<T>._instance = default(T);
	}

	// Token: 0x1700009C RID: 156
	// (get) Token: 0x060030DE RID: 12510 RVA: 0x0001AFC1 File Offset: 0x000191C1
	[Nullable(1)]
	public static T Instance
	{
		[NullableContext(1)]
		get
		{
			if (Singleton<T>._instance == null)
			{
				Singleton<T>._instance = Activator.CreateInstance<T>();
				Singleton<T> singleton = Singleton<T>._instance as Singleton<T>;
				if (singleton != null)
				{
					singleton.OnInit();
				}
			}
			return Singleton<T>._instance;
		}
	}

	// Token: 0x0400041D RID: 1053
	[Nullable(2)]
	private static T _instance;
}
