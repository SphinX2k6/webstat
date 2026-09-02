using System;
using System.Runtime.CompilerServices;

// Token: 0x0200295B RID: 10587
[NullableContext(1)]
[Nullable(0)]
public class SceneTeam : IStaticVariableResetter
{
	// Token: 0x0601509E RID: 86174 RVA: 0x005D2C9E File Offset: 0x005D0E9E
	static SceneTeam()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(SceneTeam.CreateStaticDefaultValue), new Action(SceneTeam.ResetStaticDefaultValue));
	}

	// Token: 0x0601509F RID: 86175 RVA: 0x005D2CBD File Offset: 0x005D0EBD
	public static void CreateStaticDefaultValue()
	{
		SceneTeam.Scene = new object();
		SceneTeam.All = new object();
		SceneTeam.Local = new object();
	}

	// Token: 0x060150A0 RID: 86176 RVA: 0x005D2CDD File Offset: 0x005D0EDD
	public static void ResetStaticDefaultValue()
	{
		SceneTeam.Scene = null;
		SceneTeam.All = null;
		SceneTeam.Local = null;
	}

	// Token: 0x0400A214 RID: 41492
	public static object Scene;

	// Token: 0x0400A215 RID: 41493
	public static object All;

	// Token: 0x0400A216 RID: 41494
	public static object Local;
}
