using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.LevelGamePlay.ItemInspect.Effect
{
	// Token: 0x02006E57 RID: 28247
	[NullableContext(1)]
	[Nullable(0)]
	public class ItemInspectEffectCenter
	{
		// Token: 0x060448F4 RID: 280820 RVA: 0x011D2FF8 File Offset: 0x011D11F8
		public void Init()
		{
			this.RegisterEffect(EInteractEffectType.ModifyTipText, () => new ItemInspectEffectModifyTipText(), true);
			this.RegisterEffect(EInteractEffectType.ExecuteTag, () => new ItemInspectEffectPlayPerform(), false);
			this.RegisterEffect(EInteractEffectType.TriggerDialogues, () => new ItemInspectEffectTriggerDialogues(), true);
		}

		// Token: 0x060448F5 RID: 280821 RVA: 0x011D307C File Offset: 0x011D127C
		private void RegisterEffect(EInteractEffectType type, Func<ItemInspectEffectBase> effectClass, bool repeatable = false)
		{
			ItemInspectEffectDefine itemInspectEffectDefine = new ItemInspectEffectDefine();
			itemInspectEffectDefine.Init(effectClass, repeatable);
			this.EffectMap[type] = itemInspectEffectDefine;
		}

		// Token: 0x060448F6 RID: 280822 RVA: 0x011D30A4 File Offset: 0x011D12A4
		public void ExecuteEffects(List<IInteractEffect> effectConfigs, bool isChecked, float protectTime, [Nullable(2)] Action onFinish = null)
		{
			this.ClearEffects();
			foreach (IInteractEffect interactEffect in effectConfigs)
			{
				ItemInspectEffectDefine itemInspectEffectDefine;
				if (this.EffectMap.TryGetValue(interactEffect.Type, out itemInspectEffectDefine) && (!isChecked || itemInspectEffectDefine.IsRepeatable()))
				{
					ItemInspectEffectBase effect = itemInspectEffectDefine.GetEffect();
					this.ExecutingEffectSet.Add(effect);
					effect.ExecuteEffect(interactEffect, new Action<bool, ItemInspectEffectBase>(this.OnExecuteEffectFinish));
				}
			}
			if (protectTime > 0f)
			{
				this.ProtectHandle = TimerSystem.Instance.Delay(delegate(float _)
				{
					this.ProtectHandle = null;
					this.CheckFinish();
				}, protectTime * 1000f, null, null, true, 1f);
			}
			this.OnExecuteEffectsFinish = onFinish;
			this.CheckFinish();
		}

		// Token: 0x060448F7 RID: 280823 RVA: 0x011D317C File Offset: 0x011D137C
		public void ClearEffects()
		{
			this.ExecutingEffectSet.Clear();
			TimerHandle protectHandle = this.ProtectHandle;
			if (protectHandle != null)
			{
				protectHandle.Remove();
			}
			this.ProtectHandle = null;
			this.OnExecuteEffectsFinish = null;
		}

		// Token: 0x060448F8 RID: 280824 RVA: 0x011D31A9 File Offset: 0x011D13A9
		private void OnExecuteEffectFinish(bool result, ItemInspectEffectBase effect)
		{
			this.ExecutingEffectSet.Remove(effect);
			this.CheckFinish();
		}

		// Token: 0x060448F9 RID: 280825 RVA: 0x011D31BE File Offset: 0x011D13BE
		private void CheckFinish()
		{
			if (this.ExecutingEffectSet.Count == 0 && this.ProtectHandle == null)
			{
				Action onExecuteEffectsFinish = this.OnExecuteEffectsFinish;
				if (onExecuteEffectsFinish != null)
				{
					onExecuteEffectsFinish();
				}
				this.OnExecuteEffectsFinish = null;
			}
		}

		// Token: 0x040262AD RID: 156333
		private readonly Dictionary<EInteractEffectType, ItemInspectEffectDefine> EffectMap = new Dictionary<EInteractEffectType, ItemInspectEffectDefine>();

		// Token: 0x040262AE RID: 156334
		private readonly HashSet<ItemInspectEffectBase> ExecutingEffectSet = new HashSet<ItemInspectEffectBase>();

		// Token: 0x040262AF RID: 156335
		[Nullable(2)]
		private Action OnExecuteEffectsFinish;

		// Token: 0x040262B0 RID: 156336
		[Nullable(2)]
		private TimerHandle ProtectHandle;
	}
}
