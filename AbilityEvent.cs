using System;
using System.Runtime.CompilerServices;

// Token: 0x02002E41 RID: 11841
public class AbilityEvent : IStaticVariableResetter
{
	// Token: 0x0601845D RID: 99421 RVA: 0x006C855E File Offset: 0x006C675E
	static AbilityEvent()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(AbilityEvent.CreateStaticDefaultValue), new Action(AbilityEvent.ResetStaticDefaultValue));
	}

	// Token: 0x0601845E RID: 99422 RVA: 0x006C857D File Offset: 0x006C677D
	public static void CreateStaticDefaultValue()
	{
		AbilityEvent.Instance = new AbilityEventInstance();
	}

	// Token: 0x0601845F RID: 99423 RVA: 0x006C8589 File Offset: 0x006C6789
	public static void ResetStaticDefaultValue()
	{
		AbilityEvent.Instance = null;
	}

	// Token: 0x0400BA9E RID: 47774
	public const long DEFAULT_KEY = 0L;

	// Token: 0x0400BA9F RID: 47775
	[Nullable(1)]
	public static AbilityEventInstance Instance;
}
