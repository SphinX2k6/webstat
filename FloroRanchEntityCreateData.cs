using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02001BF0 RID: 7152
public class FloroRanchEntityCreateData
{
	// Token: 0x0600D027 RID: 53287 RVA: 0x00374300 File Offset: 0x00372500
	public FloroRanchEntityCreateData(EFloroRanchEntityType entityType, [TupleElementNames(new string[]
	{
		"ComponentType",
		"Ctor"
	})] [Nullable(new byte[]
	{
		1,
		0,
		1,
		1,
		1
	})] List<ValueTuple<Type, Func<FloroRanchEntityComponentBase>>> components)
	{
		this.EntityType = entityType;
		this.Components = components;
	}

	// Token: 0x040062F9 RID: 25337
	public EFloroRanchEntityType EntityType;

	// Token: 0x040062FA RID: 25338
	[TupleElementNames(new string[]
	{
		"ComponentType",
		"Ctor"
	})]
	[Nullable(new byte[]
	{
		1,
		0,
		1,
		1,
		1
	})]
	public List<ValueTuple<Type, Func<FloroRanchEntityComponentBase>>> Components;
}
