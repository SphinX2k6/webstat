using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Utils.StaticVariableReset;
using UnrealEngine;

// Token: 0x02000C0E RID: 3086
[NullableContext(1)]
[Nullable(0)]
[StaticVariablePriority(100)]
public class FNameUtil : IStaticVariableResetter
{
	// Token: 0x0600333A RID: 13114 RVA: 0x00028488 File Offset: 0x00026688
	static FNameUtil()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(FNameUtil.CreateStaticDefaultValue), new Action(FNameUtil.ResetStaticDefaultValue));
	}

	// Token: 0x170000D8 RID: 216
	// (get) Token: 0x0600333B RID: 13115 RVA: 0x000284C0 File Offset: 0x000266C0
	private static Dictionary<string, FName> CacheNameMap
	{
		get
		{
			return FNameUtil._cacheNameMap;
		}
	}

	// Token: 0x0600333C RID: 13116 RVA: 0x000284C8 File Offset: 0x000266C8
	[NullableContext(2)]
	public static FName? GetDynamicFName(string key)
	{
		if (string.IsNullOrEmpty(key))
		{
			return null;
		}
		FName value;
		if (!FNameUtil.CacheNameMap.TryGetValue(key, out value))
		{
			value = new FName(key);
			FNameUtil.CacheNameMap[key] = value;
		}
		return new FName?(value);
	}

	// Token: 0x0600333D RID: 13117 RVA: 0x00028510 File Offset: 0x00026710
	public static FName GetCheckDynamicFName(string key)
	{
		FName? dynamicFName = FNameUtil.GetDynamicFName(key);
		if (dynamicFName == null)
		{
			return FName.NAME_None;
		}
		return dynamicFName.Value;
	}

	// Token: 0x0600333E RID: 13118 RVA: 0x0002853C File Offset: 0x0002673C
	public static bool IsEmpty(FName? content)
	{
		return content == null || content == FNameUtil.EMPTY;
	}

	// Token: 0x0600333F RID: 13119 RVA: 0x00028574 File Offset: 0x00026774
	public static bool IsNothing(FName? content)
	{
		return FNameUtil.IsEmpty(content);
	}

	// Token: 0x06003340 RID: 13120 RVA: 0x0002857C File Offset: 0x0002677C
	public static bool IsNothing(FName content)
	{
		return content == FNameUtil.NONE;
	}

	// Token: 0x06003341 RID: 13121 RVA: 0x00028589 File Offset: 0x00026789
	public static void CreateStaticDefaultValue()
	{
		FNameUtil._cacheNameMap = new Dictionary<string, FName>();
	}

	// Token: 0x06003342 RID: 13122 RVA: 0x00028595 File Offset: 0x00026795
	public static void ResetStaticDefaultValue()
	{
		FNameUtil._cacheNameMap = null;
	}

	// Token: 0x040005DF RID: 1503
	[StaticVariableRuleIgnore]
	public static readonly FName EMPTY = new FName("");

	// Token: 0x040005E0 RID: 1504
	[StaticVariableRuleIgnore]
	public static readonly FName NONE = FName.NAME_None;

	// Token: 0x040005E1 RID: 1505
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private static Dictionary<string, FName> _cacheNameMap;
}
