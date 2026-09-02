using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02006032 RID: 24626
	[NullableContext(2)]
	[Nullable(0)]
	public class MonsterNpcAttackHeadStateData : HeadStateData
	{
		// Token: 0x0603E1F2 RID: 254450 RVA: 0x00FDB0BD File Offset: 0x00FD92BD
		public override void UnBindAllCallback()
		{
			base.UnBindAllCallback();
			this.OnSpecialEnergy4ChangedCallback = null;
			this.OnSlowChargeStateChangedCallback = null;
			this.OnFastChargeStateChangedCallback = null;
			this.OnAttackReadyStateChangedCallback = null;
			this.OnAttackBeginStateChangedCallback = null;
			this.OnAttackEndStateChangedCallback = null;
			this.OnAttackBrokenStateChangedCallback = null;
		}

		// Token: 0x0603E1F3 RID: 254451 RVA: 0x00FDB0F8 File Offset: 0x00FD92F8
		protected override void AddEntityEvents()
		{
			base.AddEntityEvents();
			Entity entity = this.Entity;
			BaseAttributeComponent baseAttributeComponent = (entity != null) ? entity.GetComponent<BaseAttributeComponent>() : null;
			if (baseAttributeComponent != null && baseAttributeComponent.Valid)
			{
				baseAttributeComponent.AddListener(EAttributeType.SpecialEnergy4, new Action<EAttributeType, float, float>(this.OnSpecialEnergy4Changed), "SpecialEnergy4.MonsterNpcAttackHeadState");
				baseAttributeComponent.AddListener(EAttributeType.SpecialEnergy4Max, new Action<EAttributeType, float, float>(this.OnSpecialEnergy4Changed), "SpecialEnergy4Max.HeadState");
			}
			Entity entity2 = this.Entity;
			BaseTagComponent baseTagComponent = (entity2 != null) ? entity2.GetComponent<BaseTagComponent>() : null;
			if (baseTagComponent != null && baseTagComponent.Valid)
			{
				this.SlowChargeListenTask = baseTagComponent.ListenForTagAddOrRemove(new int?(GameplayTagDefine.EGameplayTagId["怪物.角色怪.未出手状态_慢充"]), new BaseTagComponent.TTagSwitchedCallback(this.OnSlowChargeStateChanged), null);
				this.FastChargeListenTask = baseTagComponent.ListenForTagAddOrRemove(new int?(GameplayTagDefine.EGameplayTagId["怪物.角色怪.未出手状态_快充"]), new BaseTagComponent.TTagSwitchedCallback(this.OnFastChargeStateChanged), null);
				this.AttackReadyListenTask = baseTagComponent.ListenForTagAddOrRemove(new int?(GameplayTagDefine.EGameplayTagId["怪物.角色怪.准备状态"]), new BaseTagComponent.TTagSwitchedCallback(this.OnAttackReadyStateChanged), null);
				this.AttackBeginListenTask = baseTagComponent.ListenForTagAddOrRemove(new int?(GameplayTagDefine.EGameplayTagId["怪物.角色怪.出手状态"]), new BaseTagComponent.TTagSwitchedCallback(this.OnAttackBeginStateChanged), null);
				this.AttackEndListenTask = baseTagComponent.ListenForTagAddOrRemove(new int?(GameplayTagDefine.EGameplayTagId["怪物.角色怪.出手状态退出_弱"]), new BaseTagComponent.TTagSwitchedCallback(this.OnAttackEndStateChanged), null);
				this.AttackBrokenListenTask = baseTagComponent.ListenForTagAddOrRemove(new int?(GameplayTagDefine.EGameplayTagId["怪物.角色怪.出手状态退出_强"]), new BaseTagComponent.TTagSwitchedCallback(this.OnAttackBrokenStateChanged), null);
			}
		}

		// Token: 0x0603E1F4 RID: 254452 RVA: 0x00FDB290 File Offset: 0x00FD9490
		protected override void RemoveEntityEvents()
		{
			base.RemoveEntityEvents();
			Entity entity = this.Entity;
			BaseAttributeComponent baseAttributeComponent = (entity != null) ? entity.GetComponent<BaseAttributeComponent>() : null;
			if (baseAttributeComponent != null && baseAttributeComponent.Valid)
			{
				baseAttributeComponent.RemoveListener(EAttributeType.SpecialEnergy4, new Action<EAttributeType, float, float>(this.OnSpecialEnergy4Changed));
				baseAttributeComponent.RemoveListener(EAttributeType.SpecialEnergy4Max, new Action<EAttributeType, float, float>(this.OnSpecialEnergy4Changed));
			}
			ITagTask fastChargeListenTask = this.FastChargeListenTask;
			if (fastChargeListenTask != null)
			{
				fastChargeListenTask.EndTask();
			}
			this.FastChargeListenTask = null;
			ITagTask slowChargeListenTask = this.SlowChargeListenTask;
			if (slowChargeListenTask != null)
			{
				slowChargeListenTask.EndTask();
			}
			this.SlowChargeListenTask = null;
			ITagTask attackReadyListenTask = this.AttackReadyListenTask;
			if (attackReadyListenTask != null)
			{
				attackReadyListenTask.EndTask();
			}
			this.AttackReadyListenTask = null;
			ITagTask attackBeginListenTask = this.AttackBeginListenTask;
			if (attackBeginListenTask != null)
			{
				attackBeginListenTask.EndTask();
			}
			this.AttackBeginListenTask = null;
			ITagTask attackEndListenTask = this.AttackEndListenTask;
			if (attackEndListenTask != null)
			{
				attackEndListenTask.EndTask();
			}
			this.AttackEndListenTask = null;
			ITagTask attackBrokenListenTask = this.AttackBrokenListenTask;
			if (attackBrokenListenTask != null)
			{
				attackBrokenListenTask.EndTask();
			}
			this.AttackBrokenListenTask = null;
		}

		// Token: 0x0603E1F5 RID: 254453 RVA: 0x00FDB37B File Offset: 0x00FD957B
		[NullableContext(1)]
		public void BindOnSpecialEnergy4Changed(Action<EAttributeType, float, float> callback)
		{
			this.OnSpecialEnergy4ChangedCallback = callback;
		}

		// Token: 0x0603E1F6 RID: 254454 RVA: 0x00FDB384 File Offset: 0x00FD9584
		[NullableContext(1)]
		public void BindOnSlowChargeStateChanged(Action<int, bool> callback)
		{
			this.OnSlowChargeStateChangedCallback = callback;
		}

		// Token: 0x0603E1F7 RID: 254455 RVA: 0x00FDB38D File Offset: 0x00FD958D
		[NullableContext(1)]
		public void BindOnFastChargeStateChanged(Action<int, bool> callback)
		{
			this.OnFastChargeStateChangedCallback = callback;
		}

		// Token: 0x0603E1F8 RID: 254456 RVA: 0x00FDB396 File Offset: 0x00FD9596
		[NullableContext(1)]
		public void BindOnAttackReadyStateChanged(Action<int, bool> callback)
		{
			this.OnAttackReadyStateChangedCallback = callback;
		}

		// Token: 0x0603E1F9 RID: 254457 RVA: 0x00FDB39F File Offset: 0x00FD959F
		[NullableContext(1)]
		public void BindOnAttackBeginStateChanged(Action<int, bool> callback)
		{
			this.OnAttackBeginStateChangedCallback = callback;
		}

		// Token: 0x0603E1FA RID: 254458 RVA: 0x00FDB3A8 File Offset: 0x00FD95A8
		[NullableContext(1)]
		public void BindOnAttackEndStateChanged(Action<int, bool> callback)
		{
			this.OnAttackEndStateChangedCallback = callback;
		}

		// Token: 0x0603E1FB RID: 254459 RVA: 0x00FDB3B1 File Offset: 0x00FD95B1
		[NullableContext(1)]
		public void BindOnAttackBrokenStateChanged(Action<int, bool> callback)
		{
			this.OnAttackBrokenStateChangedCallback = callback;
		}

		// Token: 0x0603E1FC RID: 254460 RVA: 0x00FDB3BA File Offset: 0x00FD95BA
		private void OnSpecialEnergy4Changed(EAttributeType attributeId, float newValue, float oldValue)
		{
			Action<EAttributeType, float, float> onSpecialEnergy4ChangedCallback = this.OnSpecialEnergy4ChangedCallback;
			if (onSpecialEnergy4ChangedCallback == null)
			{
				return;
			}
			onSpecialEnergy4ChangedCallback(attributeId, newValue, oldValue);
		}

		// Token: 0x0603E1FD RID: 254461 RVA: 0x00FDB3CF File Offset: 0x00FD95CF
		private void OnSlowChargeStateChanged(int tagId, bool bTagExists)
		{
			Action<int, bool> onSlowChargeStateChangedCallback = this.OnSlowChargeStateChangedCallback;
			if (onSlowChargeStateChangedCallback == null)
			{
				return;
			}
			onSlowChargeStateChangedCallback(tagId, bTagExists);
		}

		// Token: 0x0603E1FE RID: 254462 RVA: 0x00FDB3E3 File Offset: 0x00FD95E3
		private void OnFastChargeStateChanged(int tagId, bool bTagExists)
		{
			Action<int, bool> onFastChargeStateChangedCallback = this.OnFastChargeStateChangedCallback;
			if (onFastChargeStateChangedCallback == null)
			{
				return;
			}
			onFastChargeStateChangedCallback(tagId, bTagExists);
		}

		// Token: 0x0603E1FF RID: 254463 RVA: 0x00FDB3F7 File Offset: 0x00FD95F7
		private void OnAttackReadyStateChanged(int tagId, bool bTagExists)
		{
			Action<int, bool> onAttackReadyStateChangedCallback = this.OnAttackReadyStateChangedCallback;
			if (onAttackReadyStateChangedCallback == null)
			{
				return;
			}
			onAttackReadyStateChangedCallback(tagId, bTagExists);
		}

		// Token: 0x0603E200 RID: 254464 RVA: 0x00FDB40B File Offset: 0x00FD960B
		private void OnAttackBeginStateChanged(int tagId, bool bTagExists)
		{
			Action<int, bool> onAttackBeginStateChangedCallback = this.OnAttackBeginStateChangedCallback;
			if (onAttackBeginStateChangedCallback == null)
			{
				return;
			}
			onAttackBeginStateChangedCallback(tagId, bTagExists);
		}

		// Token: 0x0603E201 RID: 254465 RVA: 0x00FDB41F File Offset: 0x00FD961F
		private void OnAttackEndStateChanged(int tagId, bool bTagExists)
		{
			Action<int, bool> onAttackEndStateChangedCallback = this.OnAttackEndStateChangedCallback;
			if (onAttackEndStateChangedCallback == null)
			{
				return;
			}
			onAttackEndStateChangedCallback(tagId, bTagExists);
		}

		// Token: 0x0603E202 RID: 254466 RVA: 0x00FDB433 File Offset: 0x00FD9633
		private void OnAttackBrokenStateChanged(int tagId, bool bTagExists)
		{
			Action<int, bool> onAttackBrokenStateChangedCallback = this.OnAttackBrokenStateChangedCallback;
			if (onAttackBrokenStateChangedCallback == null)
			{
				return;
			}
			onAttackBrokenStateChangedCallback(tagId, bTagExists);
		}

		// Token: 0x04022D24 RID: 142628
		private ITagTask SlowChargeListenTask;

		// Token: 0x04022D25 RID: 142629
		private ITagTask FastChargeListenTask;

		// Token: 0x04022D26 RID: 142630
		private ITagTask AttackReadyListenTask;

		// Token: 0x04022D27 RID: 142631
		private ITagTask AttackBeginListenTask;

		// Token: 0x04022D28 RID: 142632
		private ITagTask AttackEndListenTask;

		// Token: 0x04022D29 RID: 142633
		private ITagTask AttackBrokenListenTask;

		// Token: 0x04022D2A RID: 142634
		private Action<EAttributeType, float, float> OnSpecialEnergy4ChangedCallback;

		// Token: 0x04022D2B RID: 142635
		private Action<int, bool> OnSlowChargeStateChangedCallback;

		// Token: 0x04022D2C RID: 142636
		private Action<int, bool> OnFastChargeStateChangedCallback;

		// Token: 0x04022D2D RID: 142637
		private Action<int, bool> OnAttackReadyStateChangedCallback;

		// Token: 0x04022D2E RID: 142638
		private Action<int, bool> OnAttackBeginStateChangedCallback;

		// Token: 0x04022D2F RID: 142639
		private Action<int, bool> OnAttackEndStateChangedCallback;

		// Token: 0x04022D30 RID: 142640
		private Action<int, bool> OnAttackBrokenStateChangedCallback;
	}
}
