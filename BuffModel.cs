using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02002EA4 RID: 11940
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class BuffModel : ModelBase<BuffModel>
{
	// Token: 0x06018820 RID: 100384 RVA: 0x006DF87C File Offset: 0x006DDA7C
	protected override bool OnClear()
	{
		this.BuffDefMaps.Clear();
		return true;
	}

	// Token: 0x17002116 RID: 8470
	// (get) Token: 0x06018821 RID: 100385 RVA: 0x006DF88A File Offset: 0x006DDA8A
	// (set) Token: 0x06018822 RID: 100386 RVA: 0x006DF892 File Offset: 0x006DDA92
	public int HandlePrefix { get; set; }

	// Token: 0x17002117 RID: 8471
	// (get) Token: 0x06018823 RID: 100387 RVA: 0x006DF89B File Offset: 0x006DDA9B
	// (set) Token: 0x06018824 RID: 100388 RVA: 0x006DF8A3 File Offset: 0x006DDAA3
	public int LastHandle { get; set; } = 1;

	// Token: 0x06018825 RID: 100389 RVA: 0x006DF8AC File Offset: 0x006DDAAC
	public void Add(long buffId, BuffDefinition buffDefinition)
	{
		this.BuffDefMaps[buffId] = buffDefinition;
	}

	// Token: 0x06018826 RID: 100390 RVA: 0x006DF8BB File Offset: 0x006DDABB
	[NullableContext(2)]
	public BuffDefinition Get(long buffId)
	{
		return this.BuffDefMaps.GetValueOrDefault(buffId);
	}

	// Token: 0x06018827 RID: 100391 RVA: 0x006DF8CC File Offset: 0x006DDACC
	public void ClearAllDefs()
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.CombatInfo;
		ELogAuthor author = ELogAuthor.GHY;
		string message = "[热更][db_buff.db] 清空解析后缓存";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("清空前条数", this.BuffDefMaps.Count);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		this.BuffDefMaps.Clear();
	}

	// Token: 0x0400BD1E RID: 48414
	private readonly Dictionary<long, BuffDefinition> BuffDefMaps = new Dictionary<long, BuffDefinition>();
}
