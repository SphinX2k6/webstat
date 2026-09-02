using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.KuroSimpleCombat
{
	// Token: 0x02006FBB RID: 28603
	[NullableContext(2)]
	[Nullable(0)]
	public class KscEntityHandle
	{
		// Token: 0x06045275 RID: 283253 RVA: 0x0120B8C2 File Offset: 0x01209AC2
		public KscEntityHandle(AKSC_Entity kscEntity, long creatureDataId = 0L)
		{
			this.KscEntity = kscEntity;
			this.CreatureDataId = creatureDataId;
		}

		// Token: 0x1700A4A9 RID: 42153
		// (get) Token: 0x06045276 RID: 283254 RVA: 0x0120B8E3 File Offset: 0x01209AE3
		public bool Valid
		{
			get
			{
				AKSC_Entity kscEntity = this.KscEntity;
				return kscEntity != null && kscEntity.IsValid();
			}
		}

		// Token: 0x06045277 RID: 283255 RVA: 0x0120B8F6 File Offset: 0x01209AF6
		[NullableContext(1)]
		public void SetKscEntity(AKSC_Entity kscEntity)
		{
			this.KscEntity = kscEntity;
		}

		// Token: 0x06045278 RID: 283256 RVA: 0x0120B8FF File Offset: 0x01209AFF
		public void SetCreatureDataId(int creatureDataId)
		{
			this.CreatureDataId = (long)creatureDataId;
		}

		// Token: 0x06045279 RID: 283257 RVA: 0x0120B909 File Offset: 0x01209B09
		public void SetAttr(EKSC_AttrType attrType, int attrValue)
		{
			this.ServerAttributeMap[attrType] = attrValue;
		}

		// Token: 0x0604527A RID: 283258 RVA: 0x0120B918 File Offset: 0x01209B18
		public unsafe void ApplyAttrDelta(Dictionary<int, int> newAttributes)
		{
			if (this.KscEntity == null || newAttributes == null || newAttributes.Count == 0)
			{
				return;
			}
			foreach (KeyValuePair<int, int> keyValuePair in newAttributes)
			{
				EKSC_AttrType eksc_AttrType = (EKSC_AttrType)keyValuePair.Key;
				int value = keyValuePair.Value;
				if (eksc_AttrType != EKSC_AttrType.Life)
				{
					int num2;
					int num = this.ServerAttributeMap.TryGetValue(eksc_AttrType, out num2) ? num2 : 0;
					if (num != value)
					{
						this.ServerAttributeMap[eksc_AttrType] = value;
						int num3 = value - num;
						this.KscEntity.AddAttr(eksc_AttrType, num3);
						if (eksc_AttrType == EKSC_AttrType.LifeMax)
						{
							UKSC_SkillComp skillComp = this.KscEntity.GetSkillComp();
							TMap<EKSC_AttrType, int> tmap;
							if (skillComp == null)
							{
								tmap = null;
							}
							else
							{
								UKSC_AttrSet attrSet_ = skillComp.AttrSet_;
								tmap = ((attrSet_ != null) ? attrSet_.Attrs_ : null);
							}
							TMap<EKSC_AttrType, int> tmap2 = tmap;
							if (tmap2 != null)
							{
								int valueOrDefault = tmap2.GetValueOrDefault(EKSC_AttrType.LifeMax, 0);
								int valueOrDefault2 = tmap2.GetValueOrDefault(EKSC_AttrType.Life, 0);
								int num4 = (num3 > 0) ? Math.Min(valueOrDefault, valueOrDefault2 + num3) : Math.Min(valueOrDefault, valueOrDefault2);
								this.KscEntity.SetAttr(EKSC_AttrType.Life, num4);
								KscLog.EModule flag = KscLog.EModule.Attr;
								ELogAuthor author = ELogAuthor.HCW;
								UObject kscWorld = Singleton<KscEnv>.Instance.KscWorld;
								string log = "更新最大生命值";
								<>y__InlineArray5<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray5<ValueTuple<string, object>>);
								*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("entityId", this.KscEntity.EntityId_);
								*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("LifeMax", valueOrDefault);
								*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("Life", valueOrDefault2);
								*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("Delta", num3);
								*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 4) = new ValueTuple<string, object>("NewLife", num4);
								KscLog.Debug(flag, author, kscWorld, log, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray5<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 5));
							}
							else
							{
								KscLog.EModule flag2 = KscLog.EModule.Attr;
								ELogAuthor author2 = ELogAuthor.HCW;
								UObject kscWorld2 = Singleton<KscEnv>.Instance.KscWorld;
								string log2 = "最大生命值没有下发";
								<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
								*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("entityId", this.KscEntity.EntityId_);
								ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1);
								string item = "EntityFaction";
								UKSC_DA_Entity daEntity_ = this.KscEntity.DaEntity_;
								ptr = new ValueTuple<string, object>(item, (daEntity_ != null) ? daEntity_.Default_Faction : EKSC_Faction.Faction0);
								KscLog.Error(flag2, author2, kscWorld2, log2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
							}
						}
					}
				}
			}
		}

		// Token: 0x0604527B RID: 283259 RVA: 0x0120BBA8 File Offset: 0x01209DA8
		private bool ShouldSync()
		{
			if (this.CreatureDataId == 0L)
			{
				return false;
			}
			CreatureModel instance = ModelBase<CreatureModel>.Instance;
			EntityHandle entityHandle = (instance != null) ? instance.GetEntity(this.CreatureDataId) : null;
			if (entityHandle == null || entityHandle.Entity == null || !this.Valid)
			{
				return false;
			}
			BaseActorComponent component = entityHandle.Entity.GetComponent<BaseActorComponent>();
			AActor aactor = (component != null) ? component.Owner : null;
			FTransformDouble? ftransformDouble = (aactor != null) ? new FTransformDouble?(aactor.D_GetTransform()) : null;
			return ftransformDouble != null;
		}

		// Token: 0x0604527C RID: 283260 RVA: 0x0120BC2C File Offset: 0x01209E2C
		public void SyncEntityLocation()
		{
			if (!this.ShouldSync())
			{
				return;
			}
			FTransformDouble ftransformDouble = ModelBase<CreatureModel>.Instance.GetEntity(this.CreatureDataId).Entity.GetComponent<BaseActorComponent>().Owner.D_GetTransform();
			this.KscEntity.SetTransformByWorld(ftransformDouble);
		}

		// Token: 0x0402694E RID: 158030
		public AKSC_Entity KscEntity;

		// Token: 0x0402694F RID: 158031
		public long CreatureDataId;

		// Token: 0x04026950 RID: 158032
		[Nullable(1)]
		private readonly Dictionary<EKSC_AttrType, int> ServerAttributeMap = new Dictionary<EKSC_AttrType, int>();
	}
}
