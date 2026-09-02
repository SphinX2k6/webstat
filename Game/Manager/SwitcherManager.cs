using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Render;

namespace CSharpScript.Game.Manager
{
	// Token: 0x020069F6 RID: 27126
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class SwitcherManager : Singleton<SwitcherManager>
	{
		// Token: 0x0604336C RID: 275308 RVA: 0x01146698 File Offset: 0x01144898
		public void Initialize()
		{
			this.AllSwitcher["特效生成Log"] = new ValueTuple<Func<bool>, Action<bool>>(() => Singleton<EffectGlobal>.Instance.EnableSpawnLog, delegate(bool value)
			{
				Singleton<EffectGlobal>.Instance.EnableSpawnLog = value;
			});
			this.AllSwitcher["打开TOD时间同步"] = new ValueTuple<Func<bool>, Action<bool>>(() => ControllerBase<TimeOfDayController>.Instance.IsSyncToEngine, delegate(bool value)
			{
				ControllerBase<TimeOfDayController>.Instance.IsSyncToEngine = value;
			});
		}

		// Token: 0x04025793 RID: 153491
		[TupleElementNames(new string[]
		{
			"GetValue",
			"SetValue"
		})]
		[Nullable(new byte[]
		{
			1,
			1,
			0,
			1,
			1
		})]
		public readonly Dictionary<string, ValueTuple<Func<bool>, Action<bool>>> AllSwitcher = new Dictionary<string, ValueTuple<Func<bool>, Action<bool>>>();
	}
}
