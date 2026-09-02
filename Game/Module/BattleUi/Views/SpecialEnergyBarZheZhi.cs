using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x020060F1 RID: 24817
	[NullableContext(1)]
	[Nullable(0)]
	public class SpecialEnergyBarZheZhi : SpecialEnergyBarSlot
	{
		// Token: 0x0603EB24 RID: 256804 RVA: 0x0100D200 File Offset: 0x0100B400
		protected override UniTask InitSlotItem(UUIItem slotItem)
		{
			SpecialEnergyBarZheZhi.<InitSlotItem>d__4 <InitSlotItem>d__;
			<InitSlotItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitSlotItem>d__.<>4__this = this;
			<InitSlotItem>d__.slotItem = slotItem;
			<InitSlotItem>d__.<>1__state = -1;
			<InitSlotItem>d__.<>t__builder.Start<SpecialEnergyBarZheZhi.<InitSlotItem>d__4>(ref <InitSlotItem>d__);
			return <InitSlotItem>d__.<>t__builder.Task;
		}

		// Token: 0x0603EB25 RID: 256805 RVA: 0x0100D24C File Offset: 0x0100B44C
		protected override void OnInitData()
		{
			base.OnInitData();
			BattleUiRoleData roleData = this.RoleData;
			CreatureDataComponent creatureDataComponent = (roleData != null) ? roleData.CreatureDataComponent : null;
			if (creatureDataComponent == null)
			{
				return;
			}
			IList<long> customServerEntityIds = creatureDataComponent.CustomServerEntityIds;
			int num = 0;
			while (num < 3 && num <= customServerEntityIds.Count - 1)
			{
				EntityHandle entity = ModelBase<CreatureModel>.Instance.GetEntity(customServerEntityIds[num]);
				if (entity == null || !entity.IsInit)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Battle;
					ELogAuthor author = ELogAuthor.CFT;
					string message = "折枝能量条读取伴生物实体时异常";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("creatureDataId", customServerEntityIds[num]);
					instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				}
				else
				{
					this.SummonedList.Add(entity);
				}
				num++;
			}
		}

		// Token: 0x0603EB26 RID: 256806 RVA: 0x0100D2FC File Offset: 0x0100B4FC
		protected override void AddEvents()
		{
			base.AddEvents();
			foreach (EntityHandle entityHandle in this.SummonedList)
			{
				WorldEntity entity = entityHandle.Entity;
				BaseTagComponent baseTagComponent = (entity != null) ? entity.GetComponent<BaseTagComponent>() : null;
				if (baseTagComponent != null)
				{
					ITagTask tagTask = baseTagComponent.ListenForTagAddOrRemove(new int?(GameplayTagDefine.EGameplayTagId["角色.R2T1ZhezhiMd10011.状态.飞鹤可触发"]), new BaseTagComponent.TTagSwitchedCallback(this.OnSummonedTagChange), null);
					if (tagTask != null)
					{
						this.TagTaskList.Add(tagTask);
					}
				}
			}
		}

		// Token: 0x0603EB27 RID: 256807 RVA: 0x0100D39C File Offset: 0x0100B59C
		private void OnSummonedTagChange(int tagId, bool bTagExists)
		{
			this.UpdateSummonedEnableCount();
			this.RefreshBarPercent(false);
		}

		// Token: 0x0603EB28 RID: 256808 RVA: 0x0100D3AC File Offset: 0x0100B5AC
		private void UpdateSummonedEnableCount()
		{
			this.SummonedEnableCount = 0;
			foreach (EntityHandle entityHandle in this.SummonedList)
			{
				WorldEntity entity = entityHandle.Entity;
				BaseTagComponent baseTagComponent = (entity != null) ? entity.GetComponent<BaseTagComponent>() : null;
				if (baseTagComponent != null && baseTagComponent.HasTag(GameplayTagDefine.EGameplayTagId["角色.R2T1ZhezhiMd10011.状态.飞鹤可触发"]))
				{
					this.SummonedEnableCount++;
				}
			}
		}

		// Token: 0x0603EB29 RID: 256809 RVA: 0x0100D43C File Offset: 0x0100B63C
		protected override void OnStart()
		{
			for (int i = 0; i < this.SlotItemList.Count; i++)
			{
				(this.SlotItemList[i] as SpecialEnergyBarZheZhiSlotItem).SetEffectItemNiagaraParam("Color_Offset", SpecialEnergyBarZheZhi.ExtraEnergyEffectParams[i]);
			}
			this.UpdateSummonedEnableCount();
			base.OnStart();
		}

		// Token: 0x0603EB2A RID: 256810 RVA: 0x0100D490 File Offset: 0x0100B690
		protected override void RefreshBarPercent(bool isStart = false)
		{
			float curPercent = this.PercentMachine.GetCurPercent();
			bool keyEnable = this.GetKeyEnable();
			for (int i = 0; i < this.SlotItemList.Count; i++)
			{
				SpecialEnergyBarZheZhiSlotItem specialEnergyBarZheZhiSlotItem = this.SlotItemList[i] as SpecialEnergyBarZheZhiSlotItem;
				if (i < this.SummonedEnableCount)
				{
					specialEnergyBarZheZhiSlotItem.UpdatePercent(0f, false, true);
					specialEnergyBarZheZhiSlotItem.SetEffectItemVisible(true);
				}
				else
				{
					specialEnergyBarZheZhiSlotItem.UpdatePercent(curPercent * (float)this.SlotNum - (float)(i - this.SummonedEnableCount), keyEnable, true);
					specialEnergyBarZheZhiSlotItem.SetEffectItemVisible(false);
				}
			}
			SpecialEnergyBarKeyItem keyItem = this.KeyItem;
			if (keyItem == null)
			{
				return;
			}
			keyItem.RefreshKeyEnable(keyEnable, isStart);
		}

		// Token: 0x0402329A RID: 144026
		private const int SUMMON_NUM = 3;

		// Token: 0x0402329B RID: 144027
		[StaticVariableRuleIgnore]
		private static readonly float[] ExtraEnergyEffectParams = new float[]
		{
			0.1f,
			0.3f,
			0.6f
		};

		// Token: 0x0402329C RID: 144028
		private readonly List<EntityHandle> SummonedList = new List<EntityHandle>();

		// Token: 0x0402329D RID: 144029
		private int SummonedEnableCount;
	}
}
