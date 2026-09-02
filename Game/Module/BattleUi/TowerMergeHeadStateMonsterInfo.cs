using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

namespace CSharpScript.Game.Module.BattleUi
{
	// Token: 0x02005F8B RID: 24459
	[NullableContext(2)]
	[Nullable(0)]
	public class TowerMergeHeadStateMonsterInfo
	{
		// Token: 0x0603D691 RID: 251537 RVA: 0x00F9FAAC File Offset: 0x00F9DCAC
		public bool AddListener()
		{
			if (this.AttributeComponent != null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Battle;
				ELogAuthor author = ELogAuthor.CFT;
				string message = "[Tower合并怪物血条]重复添加监听";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("entityId", this.EntityHandle.Id);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				this.RemoveListener();
			}
			this.AttributeComponent = this.EntityHandle.Entity.GetComponent<BaseAttributeComponent>();
			if (this.AttributeComponent == null)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.Battle;
				ELogAuthor author2 = ELogAuthor.CFT;
				string message2 = "[Tower合并怪物血条]监听的实体不存在AttributeComponent";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("entityId", this.EntityHandle.Id);
				instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				return false;
			}
			this.AttributeComponent.AddListener(EAttributeType.Life, new Action<EAttributeType, float, float>(this.OnHealthChanged), null);
			this.AttributeComponent.AddListener(EAttributeType.LifeMax, new Action<EAttributeType, float, float>(this.OnHealthMaxChanged), null);
			return true;
		}

		// Token: 0x0603D692 RID: 251538 RVA: 0x00F9FB88 File Offset: 0x00F9DD88
		public void RemoveListener()
		{
			if (this.AttributeComponent != null)
			{
				this.AttributeComponent.RemoveListener(EAttributeType.Life, new Action<EAttributeType, float, float>(this.OnHealthChanged));
				this.AttributeComponent.RemoveListener(EAttributeType.LifeMax, new Action<EAttributeType, float, float>(this.OnHealthMaxChanged));
				this.AttributeComponent = null;
			}
		}

		// Token: 0x0603D693 RID: 251539 RVA: 0x00F9FBD6 File Offset: 0x00F9DDD6
		private void OnHealthChanged(EAttributeType attributeId, float newValue, float oldValue)
		{
			if (this.Hp == newValue)
			{
				return;
			}
			this.Hp = newValue;
			ModelBase<BattleUiModel>.Instance.TowerMergeHeadStateData.OnMonsterHpChanged(this.MonsterInfoId);
		}

		// Token: 0x0603D694 RID: 251540 RVA: 0x00F9FBFE File Offset: 0x00F9DDFE
		private void OnHealthMaxChanged(EAttributeType attributeId, float newValue, float oldValue)
		{
			if (this.HpMax == newValue)
			{
				return;
			}
			this.HpMax = newValue;
			ModelBase<BattleUiModel>.Instance.TowerMergeHeadStateData.OnMonsterHpChanged(this.MonsterInfoId);
		}

		// Token: 0x04022825 RID: 141349
		public int MonsterInfoId;

		// Token: 0x04022826 RID: 141350
		public long CreatureDataId;

		// Token: 0x04022827 RID: 141351
		public EntityHandle EntityHandle;

		// Token: 0x04022828 RID: 141352
		public BaseAttributeComponent AttributeComponent;

		// Token: 0x04022829 RID: 141353
		public float Hp;

		// Token: 0x0402282A RID: 141354
		public float HpMax;
	}
}
