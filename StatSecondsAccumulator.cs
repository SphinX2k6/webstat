using System;
using System.Runtime.CompilerServices;

// Token: 0x02000BDC RID: 3036
[NullableContext(1)]
[Nullable(0)]
public class StatSecondsAccumulator : IStaticVariableResetter
{
	// Token: 0x060031E8 RID: 12776 RVA: 0x000202B8 File Offset: 0x0001E4B8
	static StatSecondsAccumulator()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(StatSecondsAccumulator.CreateStaticDefaultValue), new Action(StatSecondsAccumulator.ResetStaticDefaultValue));
	}

	// Token: 0x060031E9 RID: 12777 RVA: 0x000202D7 File Offset: 0x0001E4D7
	private StatSecondsAccumulator(string name)
	{
		this.StatName = name;
	}

	// Token: 0x060031EA RID: 12778 RVA: 0x000202F4 File Offset: 0x0001E4F4
	public static StatSecondsAccumulator Create(string nameIn, string desc = "", string group = "")
	{
		if (!Singleton<CycleCounter>.Instance.IsEnabled)
		{
			return StatSecondsAccumulator.Empty;
		}
		string text = nameIn;
		if (text.Length > 800)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Stat;
			ELogAuthor author = ELogAuthor.MZJ;
			string message = "名字过长";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("name", nameIn);
			instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			text = nameIn.Substring(0, 800);
		}
		KuroJsStatsLibrary.CreateSimpleSeconds(text, desc, group, true);
		return new StatSecondsAccumulator(text);
	}

	// Token: 0x060031EB RID: 12779 RVA: 0x00020368 File Offset: 0x0001E568
	public void Start()
	{
		if (!Singleton<CycleCounter>.Instance.IsEnabled)
		{
			return;
		}
		KuroJsStatsLibrary.StartSimpleSeconds(this.StatName);
	}

	// Token: 0x060031EC RID: 12780 RVA: 0x00020382 File Offset: 0x0001E582
	public void Stop()
	{
		if (!Singleton<CycleCounter>.Instance.IsEnabled)
		{
			return;
		}
		KuroJsStatsLibrary.StopSimpleSeconds(this.StatName);
	}

	// Token: 0x060031ED RID: 12781 RVA: 0x0002039C File Offset: 0x0001E59C
	public static void CreateStaticDefaultValue()
	{
		StatSecondsAccumulator.Empty = new StatSecondsAccumulator("");
	}

	// Token: 0x060031EE RID: 12782 RVA: 0x000203AD File Offset: 0x0001E5AD
	public static void ResetStaticDefaultValue()
	{
		StatSecondsAccumulator.Empty = null;
	}

	// Token: 0x040004E0 RID: 1248
	private readonly string StatName = "";

	// Token: 0x040004E1 RID: 1249
	private static StatSecondsAccumulator Empty;
}
