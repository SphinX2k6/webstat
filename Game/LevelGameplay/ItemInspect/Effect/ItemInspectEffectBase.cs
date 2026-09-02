using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.LevelGamePlay.ItemInspect.Effect
{
	// Token: 0x02006E55 RID: 28245
	[NullableContext(1)]
	[Nullable(0)]
	public abstract class ItemInspectEffectBase
	{
		// Token: 0x060448EB RID: 280811 RVA: 0x011D2F00 File Offset: 0x011D1100
		public void ExecuteEffect(IInteractEffect @params, Action<bool, ItemInspectEffectBase> onFinish)
		{
			this.Params = @params;
			this.OnFinish = onFinish;
			float valueOrDefault = @params.DelayTime.GetValueOrDefault();
			if (valueOrDefault <= 0f)
			{
				this.Execute(@params);
				return;
			}
			TimerSystem.Instance.Delay(delegate(float _)
			{
				this.Execute(@params);
			}, valueOrDefault * 1000f, null, null, true, 1f);
		}

		// Token: 0x060448EC RID: 280812 RVA: 0x011D2F84 File Offset: 0x011D1184
		public EInteractEffectType? GetEffectType()
		{
			IInteractEffect @params = this.Params;
			if (@params == null)
			{
				return null;
			}
			return new EInteractEffectType?(@params.Type);
		}

		// Token: 0x060448ED RID: 280813
		protected abstract void Execute(IInteractEffect @params);

		// Token: 0x060448EE RID: 280814 RVA: 0x011D2FAF File Offset: 0x011D11AF
		protected void FinishExecute(bool result)
		{
			Action<bool, ItemInspectEffectBase> onFinish = this.OnFinish;
			if (onFinish == null)
			{
				return;
			}
			onFinish(result, this);
		}

		// Token: 0x040262A9 RID: 156329
		[Nullable(2)]
		private IInteractEffect Params;

		// Token: 0x040262AA RID: 156330
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Action<bool, ItemInspectEffectBase> OnFinish;
	}
}
