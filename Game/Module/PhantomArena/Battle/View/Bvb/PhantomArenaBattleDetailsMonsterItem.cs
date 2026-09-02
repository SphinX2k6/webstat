using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.BattleUi.Views;
using CSharpScript.Game.Module.PhantomArena.Battle.Model;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Battle.View.Bvb
{
	// Token: 0x020055D4 RID: 21972
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomArenaBattleDetailsMonsterItem : GridProxyAbstract<long>
	{
		// Token: 0x06037FA4 RID: 229284 RVA: 0x00E2D9A8 File Offset: 0x00E2BBA8
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(1, typeof(UUITexture)),
				new ValueTuple<int, Type>(2, typeof(UUIText)),
				new ValueTuple<int, Type>(3, typeof(UUISprite)),
				new ValueTuple<int, Type>(4, typeof(UUISprite)),
				new ValueTuple<int, Type>(5, typeof(UUIItem)),
				new ValueTuple<int, Type>(6, typeof(UUIItem)),
				new ValueTuple<int, Type>(7, typeof(UUIText)),
				new ValueTuple<int, Type>(8, typeof(UUINiagara)),
				new ValueTuple<int, Type>(9, typeof(UUIItem)),
				new ValueTuple<int, Type>(10, typeof(UUIText)),
				new ValueTuple<int, Type>(11, typeof(UUISprite))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action(this.OnClick))
			};
		}

		// Token: 0x06037FA5 RID: 229285 RVA: 0x00E2DAF0 File Offset: 0x00E2BCF0
		protected override void OnStart()
		{
			this.RefreshBarActive();
			this.DelegateX = global::DelegateUtils.ToManualReleaseDelegate<FLTweenFloatSetterDynamic>(new Action<float>(this.TweenCallX));
			this.DelegateZ = global::DelegateUtils.ToManualReleaseDelegate<FLTweenFloatSetterDynamic>(new Action<float>(this.TweenerCallZ));
			UUIItem item = base.GetItem(9);
			if (item != null)
			{
				item.SetUIActive(false);
			}
			UUIText text = base.GetText(10);
			if (text != null)
			{
				text.SetUIActive(false);
			}
			UUINiagara uiNiagara = base.GetUiNiagara(8);
			if (uiNiagara != null)
			{
				uiNiagara.SetUIActive(false);
			}
			this.SequencePlayer = new LevelSequencePlayer(this.RootItem);
		}

		// Token: 0x06037FA6 RID: 229286 RVA: 0x00E2DB80 File Offset: 0x00E2BD80
		protected override void OnBeforeDestroy()
		{
			this.RemoveAttributeListener();
			if (this.TweenerX != null)
			{
				this.TweenerX = null;
			}
			if (this.TweenerZ != null)
			{
				this.TweenerZ = null;
			}
			global::DelegateUtils.ReleaseManualReleaseDelegate(new Action<float>(this.TweenCallX));
			global::DelegateUtils.ReleaseManualReleaseDelegate(new Action<float>(this.TweenerCallZ));
		}

		// Token: 0x06037FA7 RID: 229287 RVA: 0x00E2DBD3 File Offset: 0x00E2BDD3
		private void OnClick()
		{
			Action<long> onClickCb = this.OnClickCb;
			if (onClickCb == null)
			{
				return;
			}
			onClickCb(this.EntityId);
		}

		// Token: 0x06037FA8 RID: 229288 RVA: 0x00E2DBEB File Offset: 0x00E2BDEB
		private void AttributeRefreshLifeBar(EAttributeType type, float cur, float max)
		{
			this.RefreshLifeBar();
		}

		// Token: 0x06037FA9 RID: 229289 RVA: 0x00E2DBF4 File Offset: 0x00E2BDF4
		private void RefreshLifeBar()
		{
			BaseAttributeComponent attributeComp = this.AttributeComp;
			int num = (int)((attributeComp != null) ? attributeComp.GetCurrentValue(EAttributeType.Life) : 0f);
			BaseAttributeComponent attributeComp2 = this.AttributeComp;
			int num2 = (int)((attributeComp2 != null) ? attributeComp2.GetCurrentValue(EAttributeType.LifeMax) : ((float)this.MaxLife));
			if (num2 != 0)
			{
				this.MaxLife = num2;
			}
			float num3 = (float)num / (float)num2;
			if (this.OldLife <= num)
			{
				base.GetSprite(11).SetFillAmount(num3);
				this.HpMachine.Reset();
			}
			else
			{
				this.HpMachine.GetHit(num3, (float)this.OldLife / (float)num2);
			}
			this.OldLife = num;
			base.GetSprite(4).SetFillAmount(num3);
			base.GetSprite(3).SetFillAmount(num3);
			if (this.OldLife == 0)
			{
				UUIItem item = base.GetItem(9);
				if (item != null)
				{
					item.SetUIActive(true);
				}
				LevelSequencePlayer sequencePlayer = this.SequencePlayer;
				if (sequencePlayer == null)
				{
					return;
				}
				sequencePlayer.PlayLevelSequenceByName(EPhantomBattleHeadAnim.Kill.ToString(), false, null, false);
			}
		}

		// Token: 0x06037FAA RID: 229290 RVA: 0x00E2DCE7 File Offset: 0x00E2BEE7
		private void RefreshCostNum(int settlePoint)
		{
			this.DamageCount = settlePoint;
			base.GetText(2).SetText(settlePoint.ToString(), true);
		}

		// Token: 0x06037FAB RID: 229291 RVA: 0x00E2DD04 File Offset: 0x00E2BF04
		private void RefreshIcon(long entityId)
		{
			PhantomCardData cardDataByEntityId = ModelBase<PhantomArenaBattleModel>.Instance.BattleData.GetCardDataByEntityId(entityId);
			base.SetTextureByPath(ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleCardConfig(cardDataByEntityId.ConfigId).BvbIcon, base.GetTexture(1), null, null);
		}

		// Token: 0x06037FAC RID: 229292 RVA: 0x00E2DD51 File Offset: 0x00E2BF51
		private void RefreshBarActive()
		{
			base.GetSprite(3).SetUIActive(this.IsOwn);
			base.GetSprite(4).SetUIActive(!this.IsOwn);
		}

		// Token: 0x06037FAD RID: 229293 RVA: 0x00E2DD7C File Offset: 0x00E2BF7C
		private void RefreshFactor(int cardId, List<int> extraFactors)
		{
			EPhantomBattleHeadAnim ephantomBattleHeadAnim = this.IsOwn ? EPhantomBattleHeadAnim.FactorMeShow : EPhantomBattleHeadAnim.FactorOtherShow;
			if (this.HasTickInit)
			{
				this.CurPlayingIndex = -1;
				this.BeforeBattleFactor.Clear();
				this.HadPlayFactor.Clear();
				LevelSequencePlayer sequencePlayer = this.SequencePlayer;
				if (sequencePlayer != null && sequencePlayer.IsPlayingSequence(ephantomBattleHeadAnim.ToString()))
				{
					LevelSequencePlayer sequencePlayer2 = this.SequencePlayer;
					if (sequencePlayer2 == null)
					{
						return;
					}
					sequencePlayer2.StopPlayingSequence(false, true);
				}
				return;
			}
			this.BeforeBattleFactor.Clear();
			foreach (int num in extraFactors)
			{
				if (ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleFactorConfig(num).IsBeforeBattle)
				{
					this.BeforeBattleFactor.Add(num);
				}
			}
			this.BeforeBattleFactor.Sort(delegate(int a, int b)
			{
				PhantomBattleFactor phantomBattleFactorConfig = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleFactorConfig(a);
				return ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleFactorConfig(b).Sort - phantomBattleFactorConfig.Sort;
			});
			if (this.BeforeBattleFactor.Count > 0)
			{
				this.CurPlayingIndex = 0;
			}
			this.HasTickInit = true;
		}

		// Token: 0x06037FAE RID: 229294 RVA: 0x00E2DEA4 File Offset: 0x00E2C0A4
		private void RefreshFactorShow(int factorId)
		{
			PhantomBattleFactor phantomBattleFactorConfig = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleFactorConfig(factorId);
			bool isBeforeBattle = phantomBattleFactorConfig.IsBeforeBattle;
			string name = phantomBattleFactorConfig.Name;
			UUIText text = base.GetText(7);
			UUIItem item = base.GetItem(5);
			if (item != null)
			{
				item.SetUIActive(!isBeforeBattle);
			}
			UUIItem item2 = base.GetItem(6);
			if (item2 != null)
			{
				item2.SetUIActive(isBeforeBattle);
			}
			if (text != null)
			{
				text.SetUIActive(true);
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, name, Array.Empty<object>());
		}

		// Token: 0x06037FAF RID: 229295 RVA: 0x00E2DF1C File Offset: 0x00E2C11C
		public void Tick(float deltaTime)
		{
			if (!this.HasTickInit)
			{
				return;
			}
			float num = this.HpMachine.UpdatePercent(deltaTime);
			if (num >= 0f)
			{
				UUISprite sprite = base.GetSprite(11);
				if (sprite != null)
				{
					sprite.SetFillAmount(num);
				}
			}
			EntityHandle entity = ModelBase<CreatureModel>.Instance.GetEntity(this.EntityId);
			if ((entity == null || !entity.Valid) && this.OldLife != 0 && !this.AnimPlayed)
			{
				BaseAttributeComponent attributeComp = this.AttributeComp;
				if (attributeComp != null)
				{
					attributeComp.RemoveListeners(new EAttributeType[]
					{
						EAttributeType.Life,
						EAttributeType.LifeMax
					}, new Action<EAttributeType, float, float>(this.AttributeRefreshLifeBar));
				}
				BaseAttributeComponent attributeComp2 = this.AttributeComp;
				if (attributeComp2 != null)
				{
					attributeComp2.RemoveListener(EAttributeType.SpecialEnergy4, new Action<EAttributeType, float, float>(this.AttributeRefreshSettlePoint));
				}
				this.AttributeComp = null;
				this.RefreshLifeBar();
			}
			this.RefreshAnim();
		}

		// Token: 0x06037FB0 RID: 229296 RVA: 0x00E2DFEC File Offset: 0x00E2C1EC
		private void RefreshAnim()
		{
			int? num = this.CheckTagCurrent();
			EPhantomBattleHeadAnim ephantomBattleHeadAnim = this.IsOwn ? EPhantomBattleHeadAnim.FactorMeShow : EPhantomBattleHeadAnim.FactorOtherShow;
			if (num == null)
			{
				if (this.CurPlayingIndex < 0 || this.CurPlayingIndex >= this.BeforeBattleFactor.Count)
				{
					return;
				}
				LevelSequencePlayer sequencePlayer = this.SequencePlayer;
				if (sequencePlayer == null || !sequencePlayer.IsPlayingSequence(ephantomBattleHeadAnim.ToString()))
				{
					this.RefreshFactorShow(this.BeforeBattleFactor[this.CurPlayingIndex]);
					LevelSequencePlayer sequencePlayer2 = this.SequencePlayer;
					if (sequencePlayer2 != null)
					{
						sequencePlayer2.PlayLevelSequenceByName(ephantomBattleHeadAnim.ToString(), false, null, false);
					}
					this.CurPlayingIndex++;
					return;
				}
			}
			else
			{
				if (this.BeforeBattleFactor.Count > 0)
				{
					this.BeforeBattleFactor.Clear();
					this.CurPlayingIndex = -1;
				}
				LevelSequencePlayer sequencePlayer3 = this.SequencePlayer;
				if (sequencePlayer3 == null || !sequencePlayer3.IsPlayingSequence(ephantomBattleHeadAnim.ToString()))
				{
					LevelSequencePlayer sequencePlayer4 = this.SequencePlayer;
					if (sequencePlayer4 != null)
					{
						sequencePlayer4.PlayLevelSequenceByName(ephantomBattleHeadAnim.ToString(), false, null, false);
					}
				}
				else
				{
					LevelSequencePlayer sequencePlayer5 = this.SequencePlayer;
					if (sequencePlayer5 != null)
					{
						sequencePlayer5.ReplaySequenceByKey(ephantomBattleHeadAnim.ToString());
					}
				}
				this.RefreshFactorShow(num.Value);
			}
		}

		// Token: 0x06037FB1 RID: 229297 RVA: 0x00E2E14E File Offset: 0x00E2C34E
		private void AttributeRefreshSettlePoint(EAttributeType type, float cur, float max)
		{
			this.RefreshSettlePoint();
		}

		// Token: 0x06037FB2 RID: 229298 RVA: 0x00E2E158 File Offset: 0x00E2C358
		private void RefreshSettlePoint()
		{
			BaseAttributeComponent attributeComp = this.AttributeComp;
			int settlePoint = (int)((attributeComp != null) ? attributeComp.GetCurrentValue(EAttributeType.SpecialEnergy4) : 0f);
			if (this.IsOwn)
			{
				this.Proxy.SetOwnAllSettlePoint(this.EntityId, settlePoint);
				return;
			}
			this.Proxy.SetOpponentSettlePoint(this.EntityId, settlePoint);
		}

		// Token: 0x06037FB3 RID: 229299 RVA: 0x00E2E1AC File Offset: 0x00E2C3AC
		private void AddAttributeListener()
		{
			if (this.AttributeComp == null)
			{
				return;
			}
			BaseAttributeComponent attributeComp = this.AttributeComp;
			if (attributeComp != null)
			{
				attributeComp.AddListeners(new EAttributeType[]
				{
					EAttributeType.Life,
					EAttributeType.LifeMax
				}, new Action<EAttributeType, float, float>(this.AttributeRefreshLifeBar), null);
			}
			BaseAttributeComponent attributeComp2 = this.AttributeComp;
			if (attributeComp2 == null)
			{
				return;
			}
			attributeComp2.AddListener(EAttributeType.SpecialEnergy4, new Action<EAttributeType, float, float>(this.AttributeRefreshSettlePoint), null);
		}

		// Token: 0x06037FB4 RID: 229300 RVA: 0x00E2E210 File Offset: 0x00E2C410
		private void RemoveAttributeListener()
		{
			if (this.AttributeComp == null)
			{
				return;
			}
			BaseAttributeComponent attributeComp = this.AttributeComp;
			if (attributeComp != null)
			{
				attributeComp.RemoveListeners(new EAttributeType[]
				{
					EAttributeType.Life,
					EAttributeType.LifeMax
				}, new Action<EAttributeType, float, float>(this.AttributeRefreshLifeBar));
			}
			BaseAttributeComponent attributeComp2 = this.AttributeComp;
			if (attributeComp2 == null)
			{
				return;
			}
			attributeComp2.RemoveListener(EAttributeType.SpecialEnergy4, new Action<EAttributeType, float, float>(this.AttributeRefreshSettlePoint));
		}

		// Token: 0x06037FB5 RID: 229301 RVA: 0x00E2E270 File Offset: 0x00E2C470
		public void RegisterProxy(PhantomArenaBattleDetailsViewProxy proxy)
		{
			this.Proxy = proxy;
		}

		// Token: 0x06037FB6 RID: 229302 RVA: 0x00E2E27C File Offset: 0x00E2C47C
		public override void Refresh(long entityId, bool isSelected, int gridIndex)
		{
			this.EntityId = entityId;
			this.RemoveAttributeListener();
			EntityHandle entity = ModelBase<CreatureModel>.Instance.GetEntity(entityId);
			BaseAttributeComponent attributeComp;
			if (entity == null)
			{
				attributeComp = null;
			}
			else
			{
				WorldEntity entity2 = entity.Entity;
				attributeComp = ((entity2 != null) ? entity2.GetComponent<BaseAttributeComponent>() : null);
			}
			this.AttributeComp = attributeComp;
			this.AddAttributeListener();
			PhantomCardData cardData = ModelBase<PhantomArenaBattleModel>.Instance.BattleData.GetCardDataByEntityId(entityId);
			int fightValueByAttr = cardData.GetFightValueByAttr(PhantomBattleCardAttr.CostAbility);
			this.RefreshCostNum(fightValueByAttr);
			this.RefreshIcon(entityId);
			this.RefreshLifeBar();
			TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
			{
				this.RefreshFactor(cardData.ConfigId, cardData.ExtraFactors);
			}, 600f, null, null, true, 1f);
		}

		// Token: 0x06037FB7 RID: 229303 RVA: 0x00E2E330 File Offset: 0x00E2C530
		private int? CheckTagCurrent()
		{
			if (this.CurShowTime + 600.0 > Singleton<Time>.Instance.Now)
			{
				return null;
			}
			EntityHandle entity = ModelBase<CreatureModel>.Instance.GetEntity(this.EntityId);
			BaseTagComponent baseTagComponent;
			if (entity == null)
			{
				baseTagComponent = null;
			}
			else
			{
				WorldEntity entity2 = entity.Entity;
				baseTagComponent = ((entity2 != null) ? entity2.GetComponent<BaseTagComponent>() : null);
			}
			BaseTagComponent baseTagComponent2 = baseTagComponent;
			if (baseTagComponent2 == null)
			{
				return null;
			}
			List<int> list = new List<int>();
			foreach (KeyValuePair<int, int> keyValuePair in ModelBase<PhantomArenaBattleModel>.Instance.GetPhantomTagMap())
			{
				if (baseTagComponent2.HasTag(keyValuePair.Key) && !this.HadPlayFactor.Contains(keyValuePair.Value))
				{
					list.Add(keyValuePair.Value);
				}
			}
			if (list.Count == 0)
			{
				return null;
			}
			list.Sort(delegate(int a, int b)
			{
				PhantomBattleFactor phantomBattleFactorConfig = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleFactorConfig(a);
				return ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleFactorConfig(b).Sort - phantomBattleFactorConfig.Sort;
			});
			this.HadPlayFactor.Add(list[0]);
			this.CurShowTime = Singleton<Time>.Instance.Now;
			return new int?(list[0]);
		}

		// Token: 0x06037FB8 RID: 229304 RVA: 0x00E2E47C File Offset: 0x00E2C67C
		public int GetDamage()
		{
			BaseAttributeComponent attributeComp = this.AttributeComp;
			this.LastLife = (int)((attributeComp != null) ? new float?(attributeComp.GetCurrentValue(EAttributeType.Life)) : null).Value;
			if (this.LastLife == 0)
			{
				return 0;
			}
			return this.DamageCount;
		}

		// Token: 0x06037FB9 RID: 229305 RVA: 0x00E2E4C8 File Offset: 0x00E2C6C8
		public int ShowWinAnim()
		{
			EPhantomBattleHeadAnim ephantomBattleHeadAnim = this.IsOwn ? EPhantomBattleHeadAnim.FactorMeShow : EPhantomBattleHeadAnim.FactorOtherShow;
			LevelSequencePlayer sequencePlayer = this.SequencePlayer;
			if (sequencePlayer != null && sequencePlayer.IsPlayingSequence(ephantomBattleHeadAnim.ToString()))
			{
				LevelSequencePlayer sequencePlayer2 = this.SequencePlayer;
				if (sequencePlayer2 != null)
				{
					sequencePlayer2.StopCurrentSequence(false, true);
				}
			}
			BaseAttributeComponent attributeComp = this.AttributeComp;
			this.LastLife = (int)((attributeComp != null) ? new float?(attributeComp.GetCurrentValue(EAttributeType.Life)) : null).Value;
			if (this.LastLife == 0)
			{
				return 0;
			}
			LevelSequencePlayer sequencePlayer3 = this.SequencePlayer;
			if (sequencePlayer3 != null)
			{
				sequencePlayer3.PlayLevelSequenceByName(EPhantomBattleHeadAnim.DamageAccumulate.ToString(), false, null, false);
			}
			this.AnimPlayed = true;
			return this.DamageCount;
		}

		// Token: 0x06037FBA RID: 229306 RVA: 0x00E2E590 File Offset: 0x00E2C790
		public void OnAccumulateEvent(float endX, float endZ, UCurveFloat curveX, UCurveFloat curveZ)
		{
			if (this.LastLife == 0)
			{
				return;
			}
			base.GetUiNiagara(8).SetUIActive(true);
			float duration = 0.3f;
			FVectorDouble fvectorDouble = base.GetButton(0).RootUIComp.Get().D_K2_GetComponentLocation();
			this.TweenerX = ULTweenBPLibrary.FloatTo(GlobalData.World, this.DelegateX, (float)fvectorDouble.X, endX, duration, 0f, LTweenEase.OutCubic);
			this.TweenerZ = ULTweenBPLibrary.FloatTo(GlobalData.World, this.DelegateZ, (float)fvectorDouble.Z, endZ, duration, 0f, LTweenEase.OutCubic);
			if (this.TweenerX != null)
			{
				this.TweenerX.OnCompleteCallBack.Bind(new Action(this.OnTweenerXEnd));
				this.TweenerX.SetEase(LTweenEase.CurveFloat);
				this.TweenerX.SetCurveFloat(curveX);
			}
			if (this.TweenerZ != null)
			{
				this.TweenerZ.OnCompleteCallBack.Bind(new Action(this.OnTweenerZEnd));
				this.TweenerZ.SetEase(LTweenEase.CurveFloat);
				this.TweenerZ.SetCurveFloat(curveZ);
			}
		}

		// Token: 0x06037FBB RID: 229307 RVA: 0x00E2E69C File Offset: 0x00E2C89C
		private void TweenCallX(float value)
		{
			FVectorDouble fvectorDouble = base.GetUiNiagara(8).D_K2_GetComponentLocation();
			FVectorDouble newLocation = global::Vector.Create((double)value, fvectorDouble.Y, fvectorDouble.Z).ToUeVector(false);
			base.GetUiNiagara(8).D_K2_SetWorldLocation(newLocation, false, ref WorldGlobal.SweepHitResult, false);
		}

		// Token: 0x06037FBC RID: 229308 RVA: 0x00E2E6E4 File Offset: 0x00E2C8E4
		private void TweenerCallZ(float value)
		{
			FVectorDouble fvectorDouble = base.GetUiNiagara(8).D_K2_GetComponentLocation();
			FVectorDouble newLocation = global::Vector.Create(fvectorDouble.X, fvectorDouble.Y, (double)value).ToUeVector(false);
			base.GetUiNiagara(8).D_K2_SetWorldLocation(newLocation, false, ref WorldGlobal.SweepHitResult, false);
		}

		// Token: 0x06037FBD RID: 229309 RVA: 0x00E2E72C File Offset: 0x00E2C92C
		private void OnTweenerXEnd()
		{
			if (this.TweenerX != null)
			{
				this.TweenerX = null;
			}
			base.GetUiNiagara(8).SetUIActive(false);
		}

		// Token: 0x06037FBE RID: 229310 RVA: 0x00E2E74A File Offset: 0x00E2C94A
		private void OnTweenerZEnd()
		{
			if (this.TweenerZ != null)
			{
				this.TweenerZ = null;
			}
		}

		// Token: 0x0402001B RID: 131099
		private const int FACTOR_INTERVAL = 600;

		// Token: 0x0402001C RID: 131100
		protected PhantomArenaBattleDetailsViewProxy Proxy;

		// Token: 0x0402001D RID: 131101
		protected BaseAttributeComponent AttributeComp;

		// Token: 0x0402001E RID: 131102
		protected long EntityId;

		// Token: 0x0402001F RID: 131103
		protected bool HasTickInit;

		// Token: 0x04020020 RID: 131104
		protected List<int> BeforeBattleFactor = new List<int>();

		// Token: 0x04020021 RID: 131105
		protected HashSet<int> HadPlayFactor = new HashSet<int>();

		// Token: 0x04020022 RID: 131106
		protected double CurShowTime;

		// Token: 0x04020023 RID: 131107
		protected int CurPlayingIndex = -1;

		// Token: 0x04020024 RID: 131108
		protected LevelSequencePlayer SequencePlayer;

		// Token: 0x04020025 RID: 131109
		public bool IsOwn;

		// Token: 0x04020026 RID: 131110
		protected ULTweener TweenerX;

		// Token: 0x04020027 RID: 131111
		protected ULTweener TweenerZ;

		// Token: 0x04020028 RID: 131112
		protected FLTweenFloatSetterDynamic DelegateX;

		// Token: 0x04020029 RID: 131113
		protected FLTweenFloatSetterDynamic DelegateZ;

		// Token: 0x0402002A RID: 131114
		protected int DamageCount;

		// Token: 0x0402002B RID: 131115
		protected HpBufferStateMachine HpMachine = new HpBufferStateMachine();

		// Token: 0x0402002C RID: 131116
		protected int OldLife;

		// Token: 0x0402002D RID: 131117
		protected int MaxLife;

		// Token: 0x0402002E RID: 131118
		protected int LastLife;

		// Token: 0x0402002F RID: 131119
		protected bool AnimPlayed;

		// Token: 0x04020030 RID: 131120
		public Action<long> OnClickCb;

		// Token: 0x0200B5CC RID: 46540
		[NullableContext(0)]
		private class EMonsterItem
		{
			// Token: 0x04038407 RID: 230407
			public const int Button = 0;

			// Token: 0x04038408 RID: 230408
			public const int Icon = 1;

			// Token: 0x04038409 RID: 230409
			public const int CostNum = 2;

			// Token: 0x0403840A RID: 230410
			public const int OwnBar = 3;

			// Token: 0x0403840B RID: 230411
			public const int OpponentBar = 4;

			// Token: 0x0403840C RID: 230412
			public const int AttackTexBg = 5;

			// Token: 0x0403840D RID: 230413
			public const int NormalTexBg = 6;

			// Token: 0x0403840E RID: 230414
			public const int TxtSkill = 7;

			// Token: 0x0403840F RID: 230415
			public const int NiagaraPoint = 8;

			// Token: 0x04038410 RID: 230416
			public const int PanelHit = 9;

			// Token: 0x04038411 RID: 230417
			public const int TxtHitNum = 10;

			// Token: 0x04038412 RID: 230418
			public const int DamageBar = 11;
		}
	}
}
