using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02005FB7 RID: 24503
	[NullableContext(1)]
	[Nullable(0)]
	public class BattleEntityChildView : BattleChildView
	{
		// Token: 0x0603D9C6 RID: 252358 RVA: 0x00FB2334 File Offset: 0x00FB0534
		public override void Reset()
		{
			this.Deactivate(this.Entity);
			base.Reset();
		}

		// Token: 0x0603D9C7 RID: 252359 RVA: 0x00FB2348 File Offset: 0x00FB0548
		public void Reactivate(Entity entity)
		{
			if (!Singleton<ObjectSystem>.Instance.IsValid(entity))
			{
				return;
			}
			if (this.IsValid())
			{
				int? entityId = this.GetEntityId();
				int id = entity.Id;
				if (!(entityId.GetValueOrDefault() == id & entityId != null))
				{
					this.Deactivate(this.GetEntity());
					this.Activate(entity);
					return;
				}
			}
			else
			{
				this.Activate(entity);
			}
		}

		// Token: 0x0603D9C8 RID: 252360 RVA: 0x00FB23A8 File Offset: 0x00FB05A8
		public void Activate(Entity entity)
		{
			if (!Singleton<ObjectSystem>.Instance.IsValid(entity))
			{
				return;
			}
			this.Entity = entity;
			this.OnActivate();
			this.AddEntityEvents(entity);
		}

		// Token: 0x0603D9C9 RID: 252361 RVA: 0x00FB23CC File Offset: 0x00FB05CC
		[NullableContext(2)]
		public void Deactivate(Entity entity)
		{
			if (!Singleton<ObjectSystem>.Instance.IsValid(entity))
			{
				return;
			}
			if (!Singleton<ObjectSystem>.Instance.IsValid(this.Entity))
			{
				Singleton<Log>.Instance.Error(ELogModule.Battle, ELogAuthor.CFT, "在休眠时，当前实体不存在，请先调用Activate", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			int? entityId = this.GetEntityId();
			int id = entity.Id;
			if (!(entityId.GetValueOrDefault() == id & entityId != null))
			{
				Singleton<Log>.Instance.Error(ELogModule.Battle, ELogAuthor.CFT, "在休眠时，休眠实体不是当前实体", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			this.RemoveEntityEvents(entity);
			this.OnDeactivate();
			this.Entity = null;
		}

		// Token: 0x0603D9CA RID: 252362 RVA: 0x00FB2469 File Offset: 0x00FB0669
		protected virtual void OnActivate()
		{
		}

		// Token: 0x0603D9CB RID: 252363 RVA: 0x00FB246B File Offset: 0x00FB066B
		protected virtual void OnDeactivate()
		{
		}

		// Token: 0x0603D9CC RID: 252364 RVA: 0x00FB246D File Offset: 0x00FB066D
		protected virtual void AddEntityEvents(Entity entity)
		{
		}

		// Token: 0x0603D9CD RID: 252365 RVA: 0x00FB246F File Offset: 0x00FB066F
		protected virtual void RemoveEntityEvents(Entity entity)
		{
			this.ClearAllAttributeChangedCallback(entity);
			this.ClearAllTagCountChangedCallback();
			this.ClearAllTagSignificantChangedCallback();
			this.ClearAllGameplayEffectAppliedCallback();
		}

		// Token: 0x0603D9CE RID: 252366 RVA: 0x00FB248A File Offset: 0x00FB068A
		[NullableContext(2)]
		public Entity GetEntity()
		{
			return this.Entity;
		}

		// Token: 0x0603D9CF RID: 252367 RVA: 0x00FB2494 File Offset: 0x00FB0694
		public int? GetEntityId()
		{
			Entity entity = this.Entity;
			if (entity == null)
			{
				return null;
			}
			return new int?(entity.Id);
		}

		// Token: 0x0603D9D0 RID: 252368 RVA: 0x00FB24BF File Offset: 0x00FB06BF
		public virtual bool IsValid()
		{
			return Singleton<ObjectSystem>.Instance.IsValid(this.Entity);
		}

		// Token: 0x0603D9D1 RID: 252369 RVA: 0x00FB24D4 File Offset: 0x00FB06D4
		protected void ListenForAttributeChanged(Entity entity, EAttributeType attributeId, Action<EAttributeType, float, float> onAttributeChanged)
		{
			BaseAttributeComponent component = entity.GetComponent<BaseAttributeComponent>();
			if (component == null)
			{
				return;
			}
			component.AddListener(attributeId, onAttributeChanged, null);
			this.AttributeChangedCallbackMap[attributeId] = onAttributeChanged;
		}

		// Token: 0x0603D9D2 RID: 252370 RVA: 0x00FB2504 File Offset: 0x00FB0704
		protected void RemoveListenAttributeChanged(Entity entity, EAttributeType attributeId, Action<EAttributeType, float, float> onAttributeChanged)
		{
			BaseAttributeComponent component = entity.GetComponent<BaseAttributeComponent>();
			if (component == null)
			{
				return;
			}
			component.RemoveListener(attributeId, onAttributeChanged);
			this.AttributeChangedCallbackMap.Remove(attributeId);
		}

		// Token: 0x0603D9D3 RID: 252371 RVA: 0x00FB2534 File Offset: 0x00FB0734
		private void ClearAllAttributeChangedCallback(Entity entity)
		{
			BaseAttributeComponent component = entity.GetComponent<BaseAttributeComponent>();
			if (component == null)
			{
				return;
			}
			foreach (KeyValuePair<EAttributeType, Action<EAttributeType, float, float>> keyValuePair in this.AttributeChangedCallbackMap)
			{
				EAttributeType eattributeType;
				Action<EAttributeType, float, float> action;
				keyValuePair.Deconstruct(out eattributeType, out action);
				EAttributeType attrId = eattributeType;
				Action<EAttributeType, float, float> callback = action;
				component.RemoveListener(attrId, callback);
			}
		}

		// Token: 0x0603D9D4 RID: 252372 RVA: 0x00FB25A8 File Offset: 0x00FB07A8
		protected void ListenForTagCountChanged(Entity entity, [Nullable(new byte[]
		{
			0,
			1
		})] OneOf<int, string> effectGameplayTag, BaseTagComponent.TTagChangedCallback onGameplayEffectStackChange)
		{
			BaseTagComponent component = entity.GetComponent<BaseTagComponent>();
			if (component == null)
			{
				return;
			}
			int tagId = 0;
			if (effectGameplayTag.IsT1)
			{
				tagId = effectGameplayTag.AsT1;
			}
			else if (effectGameplayTag.IsT2)
			{
				tagId = GameplayTagUtils.GetTagIdByName(effectGameplayTag.AsT2);
			}
			ITagTask item = component.ListenForTagAnyCountChanged(tagId, onGameplayEffectStackChange);
			this.TagCountChangeTaskList.Add(item);
		}

		// Token: 0x0603D9D5 RID: 252373 RVA: 0x00FB2600 File Offset: 0x00FB0800
		private void ClearAllTagCountChangedCallback()
		{
			foreach (ITagTask tagTask in this.TagCountChangeTaskList)
			{
				tagTask.EndTask();
			}
			this.TagCountChangeTaskList.Clear();
		}

		// Token: 0x0603D9D6 RID: 252374 RVA: 0x00FB265C File Offset: 0x00FB085C
		protected void ListenForTagSignificantChanged(Entity entity, int gameplayTagId, BaseTagComponent.TTagSwitchedCallback callback)
		{
			BaseTagComponent component = entity.GetComponent<BaseTagComponent>();
			if (component == null)
			{
				return;
			}
			ITagTask item = component.ListenForTagAddOrRemove(new int?(gameplayTagId), callback, null);
			this.TagSignificantChangedTaskList.Add(item);
		}

		// Token: 0x0603D9D7 RID: 252375 RVA: 0x00FB2690 File Offset: 0x00FB0890
		protected void ListenForTagAddNewOrRemovedWithTag(BaseTagComponent tagComponent, int gameplayTagId, BaseTagComponent.TTagSwitchedCallback callback, [Nullable(2)] Stat callbackStat = null)
		{
			ITagTask item = tagComponent.ListenForTagAddOrRemove(new int?(gameplayTagId), callback, callbackStat);
			this.TagSignificantChangedTaskList.Add(item);
		}

		// Token: 0x0603D9D8 RID: 252376 RVA: 0x00FB26BC File Offset: 0x00FB08BC
		private void ClearAllTagSignificantChangedCallback()
		{
			foreach (ITagTask tagTask in this.TagSignificantChangedTaskList)
			{
				tagTask.EndTask();
			}
			this.TagSignificantChangedTaskList.Clear();
		}

		// Token: 0x0603D9D9 RID: 252377 RVA: 0x00FB2718 File Offset: 0x00FB0918
		private void ClearAllGameplayEffectAppliedCallback()
		{
			foreach (UAsyncTaskEffectApplied uasyncTaskEffectApplied in this.GameplayEffectAppliedTaskList)
			{
				uasyncTaskEffectApplied.EndTask();
			}
			this.GameplayEffectAppliedTaskList.Clear();
		}

		// Token: 0x04022960 RID: 141664
		[Nullable(2)]
		private Entity Entity;

		// Token: 0x04022961 RID: 141665
		private readonly Dictionary<EAttributeType, Action<EAttributeType, float, float>> AttributeChangedCallbackMap = new Dictionary<EAttributeType, Action<EAttributeType, float, float>>();

		// Token: 0x04022962 RID: 141666
		private readonly List<ITagTask> TagCountChangeTaskList = new List<ITagTask>();

		// Token: 0x04022963 RID: 141667
		private readonly List<ITagTask> TagSignificantChangedTaskList = new List<ITagTask>();

		// Token: 0x04022964 RID: 141668
		private readonly List<UAsyncTaskEffectApplied> GameplayEffectAppliedTaskList = new List<UAsyncTaskEffectApplied>();
	}
}
