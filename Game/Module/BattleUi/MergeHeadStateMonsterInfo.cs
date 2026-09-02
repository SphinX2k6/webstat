using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

namespace CSharpScript.Game.Module.BattleUi
{
	// Token: 0x02005F7A RID: 24442
	[NullableContext(2)]
	[Nullable(0)]
	public class MergeHeadStateMonsterInfo
	{
		// Token: 0x0603D58E RID: 251278 RVA: 0x00F9A074 File Offset: 0x00F98274
		public bool AddListener()
		{
			if (this.FightTagListenTask != null || this.AttributeComponent != null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Battle;
				ELogAuthor author = ELogAuthor.CFT;
				string message = "合并怪物血条重复添加进战监听";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("entityId", this.EntityHandle.Id);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				this.RemoveListener();
			}
			BaseTagComponent component = this.EntityHandle.Entity.GetComponent<BaseTagComponent>();
			if (component == null)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.Battle;
				ELogAuthor author2 = ELogAuthor.CFT;
				string message2 = "合并怪物血条监听的实体不存在tagComponent";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("entityId", this.EntityHandle.Id);
				instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				return false;
			}
			this.AttributeComponent = this.EntityHandle.Entity.GetComponent<BaseAttributeComponent>();
			if (this.AttributeComponent == null)
			{
				Log instance3 = Singleton<Log>.Instance;
				ELogModule module3 = ELogModule.Battle;
				ELogAuthor author3 = ELogAuthor.CFT;
				string message3 = "合并怪物血条监听的实体不存在AttributeComponent";
				ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("entityId", this.EntityHandle.Id);
				instance3.Error(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
				return false;
			}
			this.FightTagListenTask = component.ListenForTagAddOrRemove(new int?(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.进入战斗"]), new BaseTagComponent.TTagSwitchedCallback(this.OnFightTagChanged), null);
			this.HasFightTag = component.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.进入战斗"]);
			BaseAttributeComponent attributeComponent = this.AttributeComponent;
			attributeComponent.AddListener(EAttributeType.Life, new Action<EAttributeType, float, float>(this.OnHealthChanged), null);
			attributeComponent.AddListener(EAttributeType.LifeMax, new Action<EAttributeType, float, float>(this.OnHealthMaxChanged), null);
			return true;
		}

		// Token: 0x0603D58F RID: 251279 RVA: 0x00F9A1E8 File Offset: 0x00F983E8
		public void RemoveListener()
		{
			if (this.FightTagListenTask != null)
			{
				this.FightTagListenTask.EndTask();
				this.FightTagListenTask = null;
			}
			if (this.AttributeComponent != null)
			{
				BaseAttributeComponent attributeComponent = this.AttributeComponent;
				attributeComponent.RemoveListener(EAttributeType.Life, new Action<EAttributeType, float, float>(this.OnHealthChanged));
				attributeComponent.RemoveListener(EAttributeType.LifeMax, new Action<EAttributeType, float, float>(this.OnHealthMaxChanged));
				this.AttributeComponent = null;
			}
		}

		// Token: 0x0603D590 RID: 251280 RVA: 0x00F9A24B File Offset: 0x00F9844B
		private void OnFightTagChanged(int tagId, bool bTagExists)
		{
			if (this.HasFightTag == bTagExists)
			{
				return;
			}
			this.HasFightTag = bTagExists;
			ModelBase<BattleUiModel>.Instance.MergeHeadStateData.OnMonsterFightTagChange(this.Id, bTagExists);
		}

		// Token: 0x0603D591 RID: 251281 RVA: 0x00F9A274 File Offset: 0x00F98474
		private void OnHealthChanged(EAttributeType attributeId, float newValue, float oldValue)
		{
			float hp = this.Hp;
			this.Hp = newValue;
			if (this.HpMax <= 0f)
			{
				return;
			}
			float hpChange = (this.Hp - hp) / this.HpMax * this.BaseLife;
			ModelBase<BattleUiModel>.Instance.MergeHeadStateData.OnMonsterHealthChange(this.Id, hpChange);
		}

		// Token: 0x0603D592 RID: 251282 RVA: 0x00F9A2CC File Offset: 0x00F984CC
		private void OnHealthMaxChanged(EAttributeType attributeId, float newValue, float oldValue)
		{
			float hpMax = this.HpMax;
			this.HpMax = newValue;
			float num = 0f;
			if (hpMax > 0f)
			{
				num = this.Hp / hpMax;
			}
			float num2 = 0f;
			if (this.HpMax > 0f)
			{
				num2 = this.Hp / this.HpMax;
			}
			float hpChange = (num2 - num) * this.BaseLife;
			ModelBase<BattleUiModel>.Instance.MergeHeadStateData.OnMonsterHealthChange(this.Id, hpChange);
		}

		// Token: 0x04022737 RID: 141111
		public int Id;

		// Token: 0x04022738 RID: 141112
		public int PbDataId;

		// Token: 0x04022739 RID: 141113
		public EntityHandle EntityHandle;

		// Token: 0x0402273A RID: 141114
		public bool IsDead;

		// Token: 0x0402273B RID: 141115
		public float BaseLife;

		// Token: 0x0402273C RID: 141116
		public BaseAttributeComponent AttributeComponent;

		// Token: 0x0402273D RID: 141117
		public ITagTask FightTagListenTask;

		// Token: 0x0402273E RID: 141118
		public bool HasFightTag;

		// Token: 0x0402273F RID: 141119
		public float Hp;

		// Token: 0x04022740 RID: 141120
		public float HpMax;
	}
}
