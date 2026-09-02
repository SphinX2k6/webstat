using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02000C0B RID: 3083
[NullableContext(1)]
[Nullable(0)]
[StaticVariableRuleIgnore]
public class DelegateUtils
{
	// Token: 0x170000D7 RID: 215
	// (get) Token: 0x0600332C RID: 13100 RVA: 0x00028158 File Offset: 0x00026358
	private static Dictionary<Delegate, UnrealScriptDelegate> ManualReleaseDelegates
	{
		get
		{
			return global::DelegateUtils._manualReleaseDelegates;
		}
	}

	// Token: 0x0600332D RID: 13101 RVA: 0x00028160 File Offset: 0x00026360
	public static T ToManualReleaseDelegate<[Nullable(0)] T>(Delegate callback) where T : UnrealScriptDelegate, new()
	{
		T t = Activator.CreateInstance<T>();
		t.DynamicBind(callback);
		global::DelegateUtils.ManualReleaseDelegates.Add(callback, t);
		return t;
	}

	// Token: 0x0600332E RID: 13102 RVA: 0x00028191 File Offset: 0x00026391
	public static void ReleaseManualReleaseDelegate(Delegate callBack)
	{
		global::DelegateUtils.ManualReleaseDelegates.Remove(callBack);
	}

	// Token: 0x0600332F RID: 13103 RVA: 0x0002819F File Offset: 0x0002639F
	public static void CreateStaticDefaultValue()
	{
		global::DelegateUtils._manualReleaseDelegates = new Dictionary<Delegate, UnrealScriptDelegate>();
	}

	// Token: 0x06003330 RID: 13104 RVA: 0x000281AB File Offset: 0x000263AB
	public static void ResetStaticDefaultValue()
	{
		global::DelegateUtils._manualReleaseDelegates = null;
	}

	// Token: 0x040005DA RID: 1498
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private static Dictionary<Delegate, UnrealScriptDelegate> _manualReleaseDelegates;
}
