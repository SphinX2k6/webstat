using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.DropCatch.Gameplay.Logic
{
	// Token: 0x02006939 RID: 26937
	[NullableContext(1)]
	[Nullable(0)]
	public class DropCatchGameplayInput<[Nullable(2)] TValue>
	{
		// Token: 0x06042D94 RID: 273812 RVA: 0x01128E75 File Offset: 0x01127075
		[NullableContext(2)]
		public void Init(Action<EDropCatchGameplayInputSource?> activeSourceCallback = null)
		{
			this.ActiveSourceCallback = activeSourceCallback;
		}

		// Token: 0x06042D95 RID: 273813 RVA: 0x01128E80 File Offset: 0x01127080
		public void Set(EDropCatchGameplayInputSource source, TValue value)
		{
			TValue tvalue;
			if (this.Values.TryGetValue(source, out tvalue) && tvalue.Equals(value))
			{
				return;
			}
			if (this.Values.ContainsKey(source))
			{
				this.Values[source] = value;
				return;
			}
			this.Values.Add(source, value);
		}

		// Token: 0x06042D96 RID: 273814 RVA: 0x01128EDC File Offset: 0x011270DC
		public TValue Get(TValue fallback)
		{
			TValue result;
			if (this.ActiveSource != null && this.Values.TryGetValue(this.ActiveSource.Value, out result))
			{
				return result;
			}
			return fallback;
		}

		// Token: 0x06042D97 RID: 273815 RVA: 0x01128F13 File Offset: 0x01127113
		public void Delete(EDropCatchGameplayInputSource source)
		{
			this.Values.Remove(source);
		}

		// Token: 0x06042D98 RID: 273816 RVA: 0x01128F22 File Offset: 0x01127122
		public void OnTick()
		{
			this.RefreshActiveSource();
		}

		// Token: 0x06042D99 RID: 273817 RVA: 0x01128F2C File Offset: 0x0112712C
		public void RefreshActiveSource()
		{
			foreach (EDropCatchGameplayInputSource edropCatchGameplayInputSource in Singleton<DropCatchDefine>.Instance.InputPriority)
			{
				TValue tvalue;
				if (this.Values.TryGetValue(edropCatchGameplayInputSource, out tvalue))
				{
					this.ActiveSource = new EDropCatchGameplayInputSource?(edropCatchGameplayInputSource);
					break;
				}
			}
			Action<EDropCatchGameplayInputSource?> activeSourceCallback = this.ActiveSourceCallback;
			if (activeSourceCallback == null)
			{
				return;
			}
			activeSourceCallback(this.ActiveSource);
		}

		// Token: 0x04025407 RID: 152583
		private readonly Dictionary<EDropCatchGameplayInputSource, TValue> Values = new Dictionary<EDropCatchGameplayInputSource, TValue>();

		// Token: 0x04025408 RID: 152584
		private EDropCatchGameplayInputSource? ActiveSource;

		// Token: 0x04025409 RID: 152585
		[Nullable(2)]
		private Action<EDropCatchGameplayInputSource?> ActiveSourceCallback;
	}
}
