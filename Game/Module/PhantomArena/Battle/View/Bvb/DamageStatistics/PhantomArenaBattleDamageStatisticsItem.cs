using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.PhantomArena.Battle.Model;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Battle.View.Bvb.DamageStatistics
{
	// Token: 0x020055DE RID: 21982
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomArenaBattleDamageStatisticsItem : UiPanelBase
	{
		// Token: 0x06038036 RID: 229430 RVA: 0x00E3091C File Offset: 0x00E2EB1C
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUITexture)),
				new ValueTuple<int, Type>(3, typeof(UUIText)),
				new ValueTuple<int, Type>(4, typeof(UUISprite)),
				new ValueTuple<int, Type>(5, typeof(UUIText))
			};
		}

		// Token: 0x06038037 RID: 229431 RVA: 0x00E309B8 File Offset: 0x00E2EBB8
		protected override void OnStart()
		{
			this.ValueSprite = base.GetSprite(4);
			this.ValueTween = new LguiFloatTween();
			this.ValueTween.BindUpdateTween(new Action<float>(this.UpdateSlider));
			this.OffsetTween = new LguiIntTween();
			this.OffsetTween.BindUpdateTween(new Action<int>(this.UpdateOffsetY));
		}

		// Token: 0x06038038 RID: 229432 RVA: 0x00E30A16 File Offset: 0x00E2EC16
		protected override void OnDestroy()
		{
			this.ValueTween.Destroy();
			this.OffsetTween.Destroy();
			this.RemoveEntityEvents(this.Entity);
			this.Entity = null;
		}

		// Token: 0x06038039 RID: 229433 RVA: 0x00E30A44 File Offset: 0x00E2EC44
		private void RefreshIcon()
		{
			PhantomCardData cardDataByEntityId = ModelBase<PhantomArenaBattleModel>.Instance.BattleData.GetCardDataByEntityId(this.EntityId);
			base.SetTextureByPath(ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleCardConfig(cardDataByEntityId.ConfigId).BvbIcon, base.GetTexture(2), null, null);
		}

		// Token: 0x0603803A RID: 229434 RVA: 0x00E30A98 File Offset: 0x00E2EC98
		private void RefreshName()
		{
			PhantomCardData cardDataByEntityId = ModelBase<PhantomArenaBattleModel>.Instance.BattleData.GetCardDataByEntityId(this.EntityId);
			PhantomBattleCard phantomBattleCardConfig = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleCardConfig(cardDataByEntityId.ConfigId);
			UUIText text = base.GetText(3);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, phantomBattleCardConfig.Name, Array.Empty<object>());
			UUIItem uuiitem = text;
			bool isNpcCard = cardDataByEntityId.IsNpcCard;
			FColor? fcolor = new FColor?(text.changeColor);
			uuiitem.SetChangeColor(isNpcCard, fcolor);
		}

		// Token: 0x0603803B RID: 229435 RVA: 0x00E30B08 File Offset: 0x00E2ED08
		private void RefreshBg()
		{
			PhantomCardData cardDataByEntityId = ModelBase<PhantomArenaBattleModel>.Instance.BattleData.GetCardDataByEntityId(this.EntityId);
			base.GetItem(0).SetUIActive(!cardDataByEntityId.IsNpcCard);
			base.GetItem(1).SetUIActive(cardDataByEntityId.IsNpcCard);
			UUIItem valueSprite = this.ValueSprite;
			bool isNpcCard = cardDataByEntityId.IsNpcCard;
			FColor? fcolor = new FColor?(this.ValueSprite.changeColor);
			valueSprite.SetChangeColor(isNpcCard, fcolor);
		}

		// Token: 0x0603803C RID: 229436 RVA: 0x00E30B78 File Offset: 0x00E2ED78
		public void Init(long entityId, UCurveFloat lerpCurve, float offsetY)
		{
			this.RemoveEntityEvents(this.Entity);
			this.LerpCurve = lerpCurve;
			this.EntityId = entityId;
			EntityHandle entity = ModelBase<CreatureModel>.Instance.GetEntity(entityId);
			this.Entity = ((entity != null) ? entity.Entity : null);
			Entity entity2 = this.Entity;
			this.AttributeComp = ((entity2 != null) ? entity2.GetComponent<BaseAttributeComponent>() : null);
			this.AddEntityEvents(this.Entity);
			this.GetOriginalItem().SetAnchorOffsetY(offsetY);
			this.RefreshIcon();
			this.RefreshName();
			this.RefreshBg();
		}

		// Token: 0x0603803D RID: 229437 RVA: 0x00E30C00 File Offset: 0x00E2EE00
		public void RefreshOffsetY(float offsetY)
		{
			float anchorOffsetY = this.GetOriginalItem().GetAnchorOffsetY();
			this.OffsetTween.PlayTween((int)anchorOffsetY, (int)offsetY, 0.3f, null);
		}

		// Token: 0x0603803E RID: 229438 RVA: 0x00E30C30 File Offset: 0x00E2EE30
		public void RefreshCount()
		{
			int num = this.GetAllCount();
			if (num == 0)
			{
				this.ValueSprite.SetFillAmount(0f);
				base.GetText(5).SetText("0", true);
				return;
			}
			int num2 = this.GetCount(this.EntityId);
			float fillAmount = this.ValueSprite.GetFillAmount();
			float end = (float)num2 / (float)num;
			this.ValueTween.PlayTween(fillAmount, end, 0.3f, null);
			base.GetText(5).SetText(num2.ToString(), true);
		}

		// Token: 0x0603803F RID: 229439 RVA: 0x00E30CBC File Offset: 0x00E2EEBC
		private void AddEntityEvents(Entity entity)
		{
			if (entity == null)
			{
				return;
			}
			if (!Singleton<EventSystem>.Instance.HasWithTarget<Entity, Entity, RequirementPayload, DamageResult, FVectorDouble>(entity, EEventName.CharBeDamage, new Action<Entity, Entity, RequirementPayload, DamageResult, FVectorDouble>(this.OnEntityInjury)))
			{
				Singleton<EventSystem>.Instance.AddWithTarget<Entity, Entity, RequirementPayload, DamageResult, FVectorDouble>(entity, EEventName.CharBeDamage, new Action<Entity, Entity, RequirementPayload, DamageResult, FVectorDouble>(this.OnEntityInjury));
			}
			if (!Singleton<EventSystem>.Instance.HasWithTarget<Entity, Entity, RequirementPayload, DamageResult, FVectorDouble>(entity, EEventName.CharDamage, new Action<Entity, Entity, RequirementPayload, DamageResult, FVectorDouble>(this.OnEntityDamage)))
			{
				Singleton<EventSystem>.Instance.AddWithTarget<Entity, Entity, RequirementPayload, DamageResult, FVectorDouble>(entity, EEventName.CharDamage, new Action<Entity, Entity, RequirementPayload, DamageResult, FVectorDouble>(this.OnEntityDamage));
			}
		}

		// Token: 0x06038040 RID: 229440 RVA: 0x00E30D38 File Offset: 0x00E2EF38
		private void RemoveEntityEvents(Entity entity)
		{
			if (entity == null)
			{
				return;
			}
			if (Singleton<EventSystem>.Instance.HasWithTarget<Entity, Entity, RequirementPayload, DamageResult, FVectorDouble>(entity, EEventName.CharBeDamage, new Action<Entity, Entity, RequirementPayload, DamageResult, FVectorDouble>(this.OnEntityInjury)))
			{
				Singleton<EventSystem>.Instance.RemoveWithTarget<Entity, Entity, RequirementPayload, DamageResult, FVectorDouble>(entity, EEventName.CharBeDamage, new Action<Entity, Entity, RequirementPayload, DamageResult, FVectorDouble>(this.OnEntityInjury));
			}
			if (Singleton<EventSystem>.Instance.HasWithTarget<Entity, Entity, RequirementPayload, DamageResult, FVectorDouble>(entity, EEventName.CharDamage, new Action<Entity, Entity, RequirementPayload, DamageResult, FVectorDouble>(this.OnEntityDamage)))
			{
				Singleton<EventSystem>.Instance.RemoveWithTarget<Entity, Entity, RequirementPayload, DamageResult, FVectorDouble>(entity, EEventName.CharDamage, new Action<Entity, Entity, RequirementPayload, DamageResult, FVectorDouble>(this.OnEntityDamage));
			}
		}

		// Token: 0x06038041 RID: 229441 RVA: 0x00E30DB4 File Offset: 0x00E2EFB4
		private void OnEntityInjury(Entity attacker, Entity victim, RequirementPayload requirements, DamageResult damageResult, FVectorDouble _)
		{
			int arg = (int)this.AttributeComp.GetCurrentValue(EAttributeType.LifeMax);
			Action<long, int, int, EDamageStatisticsRankType> notifyValueChange = this.NotifyValueChange;
			if (notifyValueChange == null)
			{
				return;
			}
			notifyValueChange(this.EntityId, (int)Math.Abs(damageResult.Damage), arg, EDamageStatisticsRankType.Injury);
		}

		// Token: 0x06038042 RID: 229442 RVA: 0x00E30DF4 File Offset: 0x00E2EFF4
		private void OnEntityDamage(Entity attacker, Entity victim, RequirementPayload requirements, DamageResult damageResult, FVectorDouble _)
		{
			if (damageResult.DamageData.Id == 700020001L)
			{
				return;
			}
			if (damageResult.DamageData.CalculateType != 0)
			{
				return;
			}
			int arg = (int)victim.GetComponent<BaseAttributeComponent>().GetCurrentValue(EAttributeType.LifeMax);
			Action<long, int, int, EDamageStatisticsRankType> notifyValueChange = this.NotifyValueChange;
			if (notifyValueChange == null)
			{
				return;
			}
			notifyValueChange(this.EntityId, (int)Math.Abs(damageResult.Damage), arg, EDamageStatisticsRankType.Damage);
		}

		// Token: 0x06038043 RID: 229443 RVA: 0x00E30E58 File Offset: 0x00E2F058
		private void UpdateSlider(float value)
		{
			this.ValueSprite.SetFillAmount(value);
		}

		// Token: 0x06038044 RID: 229444 RVA: 0x00E30E66 File Offset: 0x00E2F066
		private void UpdateOffsetY(int value)
		{
			this.GetOriginalItem().SetAnchorOffsetY((float)value);
		}

		// Token: 0x0402006C RID: 131180
		private const int BURN_BLOOD_BUFF_RESULT_ID = 700020001;

		// Token: 0x0402006D RID: 131181
		protected LguiFloatTween ValueTween;

		// Token: 0x0402006E RID: 131182
		protected LguiIntTween OffsetTween;

		// Token: 0x0402006F RID: 131183
		protected long EntityId;

		// Token: 0x04020070 RID: 131184
		protected Entity Entity;

		// Token: 0x04020071 RID: 131185
		protected BaseAttributeComponent AttributeComp;

		// Token: 0x04020072 RID: 131186
		protected UUISprite ValueSprite;

		// Token: 0x04020073 RID: 131187
		protected UCurveFloat LerpCurve;

		// Token: 0x04020074 RID: 131188
		public Func<int> GetAllCount;

		// Token: 0x04020075 RID: 131189
		public Func<long, int> GetCount;

		// Token: 0x04020076 RID: 131190
		public Action<long, int, int, EDamageStatisticsRankType> NotifyValueChange;

		// Token: 0x0200B5E5 RID: 46565
		[NullableContext(0)]
		private class EComponentDefine
		{
			// Token: 0x0403847F RID: 230527
			public const int OwnBg = 0;

			// Token: 0x04038480 RID: 230528
			public const int OpponentBg = 1;

			// Token: 0x04038481 RID: 230529
			public const int Icon = 2;

			// Token: 0x04038482 RID: 230530
			public const int Name = 3;

			// Token: 0x04038483 RID: 230531
			public const int ValueSprite = 4;

			// Token: 0x04038484 RID: 230532
			public const int Count = 5;
		}
	}
}
