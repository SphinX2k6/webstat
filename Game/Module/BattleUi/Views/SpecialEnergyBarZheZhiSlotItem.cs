using System;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x020060F3 RID: 24819
	public class SpecialEnergyBarZheZhiSlotItem : SpecialEnergyBarSlotItem
	{
		// Token: 0x0603EB37 RID: 256823 RVA: 0x0100D854 File Offset: 0x0100BA54
		protected override UniTask OnBeforeStartAsync()
		{
			SpecialEnergyBarZheZhiSlotItem.<OnBeforeStartAsync>d__1 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<SpecialEnergyBarZheZhiSlotItem.<OnBeforeStartAsync>d__1>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603EB38 RID: 256824 RVA: 0x0100D897 File Offset: 0x0100BA97
		public void SetEffectItemVisible(bool value)
		{
			SpecialEnergyBarZheZhiEffectItem effectItem = this.EffectItem;
			if (effectItem == null)
			{
				return;
			}
			effectItem.SetVisible(value);
		}

		// Token: 0x0603EB39 RID: 256825 RVA: 0x0100D8AA File Offset: 0x0100BAAA
		[NullableContext(1)]
		public void SetEffectItemNiagaraParam(string varName, float value)
		{
			SpecialEnergyBarZheZhiEffectItem effectItem = this.EffectItem;
			if (effectItem == null)
			{
				return;
			}
			effectItem.SetNiagaraParam(varName, value);
		}

		// Token: 0x040232A0 RID: 144032
		[Nullable(2)]
		private SpecialEnergyBarZheZhiEffectItem EffectItem;
	}
}
