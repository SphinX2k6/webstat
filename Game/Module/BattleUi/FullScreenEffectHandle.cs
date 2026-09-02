using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.Module.BattleUi
{
	// Token: 0x02005F8E RID: 24462
	[NullableContext(1)]
	[Nullable(0)]
	public class FullScreenEffectHandle
	{
		// Token: 0x0603D6AA RID: 251562 RVA: 0x00FA0357 File Offset: 0x00F9E557
		public FullScreenEffectHandle(long uniqueId, string niagaraPath)
		{
		}

		// Token: 0x0603D6AB RID: 251563 RVA: 0x00FA0378 File Offset: 0x00F9E578
		public void SetFloatParameter(string key, float value)
		{
			this.FloatParameterMap[key] = value;
			Singleton<EventSystem>.Instance.Emit<long, string, float>(EEventName.OnChangeFullScreenNiagaraFloatParameter, this.UniqueId, key, value);
		}

		// Token: 0x0603D6AC RID: 251564 RVA: 0x00FA039F File Offset: 0x00F9E59F
		public IReadOnlyDictionary<string, float> GetFloatParameterMap()
		{
			return this.FloatParameterMap;
		}

		// Token: 0x04022835 RID: 141365
		public readonly long UniqueId = uniqueId;

		// Token: 0x04022836 RID: 141366
		public readonly string NiagaraPath = niagaraPath;

		// Token: 0x04022837 RID: 141367
		private readonly Dictionary<string, float> FloatParameterMap = new Dictionary<string, float>();
	}
}
