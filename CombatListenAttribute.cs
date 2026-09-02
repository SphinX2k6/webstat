using System;
using Aki.Protocol;
using CSharpScript.Core.Common;

// Token: 0x02001864 RID: 6244
[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
public class CombatListenAttribute : DecoratorDefineAttribute
{
	// Token: 0x0600B304 RID: 45828 RVA: 0x002FCAE3 File Offset: 0x002FACE3
	public CombatListenAttribute(ENotifyMessageId notifyKey, bool needSync, bool needCache = false)
	{
	}
}
