using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.PhantomArena.Battle;
using CSharpScript.Game.Module.PhantomArena.Battle.Card;
using CSharpScript.Game.Module.PhantomArena.Battle.Model;
using CSharpScript.Game.Module.PhantomArena.Common.CardItem.Item;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Common.CardItem.Component.Bvb
{
	// Token: 0x02005565 RID: 21861
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class NewBattleCardComponent : CardComponentBase<PhantomCardData>, IBattleCardComponent
	{
		// Token: 0x17008F74 RID: 36724
		// (get) Token: 0x06037B87 RID: 228231 RVA: 0x00E20B32 File Offset: 0x00E1ED32
		// (set) Token: 0x06037B88 RID: 228232 RVA: 0x00E20B3A File Offset: 0x00E1ED3A
		public Action<EToggleState> CardClickCallback { get; set; }

		// Token: 0x17008F75 RID: 36725
		// (get) Token: 0x06037B89 RID: 228233 RVA: 0x00E20B43 File Offset: 0x00E1ED43
		// (set) Token: 0x06037B8A RID: 228234 RVA: 0x00E20B4B File Offset: 0x00E1ED4B
		public UiSequencePlayer RootUiSequencePlayer { get; set; }

		// Token: 0x06037B8B RID: 228235 RVA: 0x00E20B54 File Offset: 0x00E1ED54
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIText)),
				new ValueTuple<int, Type>(4, typeof(UUIText)),
				new ValueTuple<int, Type>(5, typeof(UUIItem)),
				new ValueTuple<int, Type>(6, typeof(UUIItem)),
				new ValueTuple<int, Type>(7, typeof(UUIItem)),
				new ValueTuple<int, Type>(8, typeof(UUIItem)),
				new ValueTuple<int, Type>(9, typeof(UUIItem)),
				new ValueTuple<int, Type>(10, typeof(UUIItem)),
				new ValueTuple<int, Type>(11, typeof(UUITexture)),
				new ValueTuple<int, Type>(12, typeof(UUIText)),
				new ValueTuple<int, Type>(13, typeof(UUIItem)),
				new ValueTuple<int, Type>(14, typeof(UUIItem)),
				new ValueTuple<int, Type>(15, typeof(UUIItem)),
				new ValueTuple<int, Type>(16, typeof(UUIItem)),
				new ValueTuple<int, Type>(17, typeof(UUIItem)),
				new ValueTuple<int, Type>(18, typeof(UUIItem)),
				new ValueTuple<int, Type>(19, typeof(UUIItem)),
				new ValueTuple<int, Type>(20, typeof(UUIItem)),
				new ValueTuple<int, Type>(21, typeof(UUIText)),
				new ValueTuple<int, Type>(22, typeof(UUIItem)),
				new ValueTuple<int, Type>(23, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.CardClick))
			};
		}

		// Token: 0x06037B8C RID: 228236 RVA: 0x00E20DAE File Offset: 0x00E1EFAE
		private void CardClick(EToggleState state)
		{
			Action<EToggleState> cardClickCallback = this.CardClickCallback;
			if (cardClickCallback == null)
			{
				return;
			}
			cardClickCallback(state);
		}

		// Token: 0x06037B8D RID: 228237 RVA: 0x00E20DC4 File Offset: 0x00E1EFC4
		protected UniTask InitElement()
		{
			NewBattleCardComponent.<InitElement>d__20 <InitElement>d__;
			<InitElement>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitElement>d__.<>4__this = this;
			<InitElement>d__.<>1__state = -1;
			<InitElement>d__.<>t__builder.Start<NewBattleCardComponent.<InitElement>d__20>(ref <InitElement>d__);
			return <InitElement>d__.<>t__builder.Task;
		}

		// Token: 0x06037B8E RID: 228238 RVA: 0x00E20E08 File Offset: 0x00E1F008
		private UniTask InitLoopEffect()
		{
			NewBattleCardComponent.<InitLoopEffect>d__21 <InitLoopEffect>d__;
			<InitLoopEffect>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitLoopEffect>d__.<>4__this = this;
			<InitLoopEffect>d__.<>1__state = -1;
			<InitLoopEffect>d__.<>t__builder.Start<NewBattleCardComponent.<InitLoopEffect>d__21>(ref <InitLoopEffect>d__);
			return <InitLoopEffect>d__.<>t__builder.Task;
		}

		// Token: 0x06037B8F RID: 228239 RVA: 0x00E20E4C File Offset: 0x00E1F04C
		private UniTask InitStartEffect()
		{
			NewBattleCardComponent.<InitStartEffect>d__22 <InitStartEffect>d__;
			<InitStartEffect>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitStartEffect>d__.<>4__this = this;
			<InitStartEffect>d__.<>1__state = -1;
			<InitStartEffect>d__.<>t__builder.Start<NewBattleCardComponent.<InitStartEffect>d__22>(ref <InitStartEffect>d__);
			return <InitStartEffect>d__.<>t__builder.Task;
		}

		// Token: 0x06037B90 RID: 228240 RVA: 0x00E20E90 File Offset: 0x00E1F090
		private UniTask InitHitLocationCurveX()
		{
			NewBattleCardComponent.<InitHitLocationCurveX>d__23 <InitHitLocationCurveX>d__;
			<InitHitLocationCurveX>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitHitLocationCurveX>d__.<>4__this = this;
			<InitHitLocationCurveX>d__.<>1__state = -1;
			<InitHitLocationCurveX>d__.<>t__builder.Start<NewBattleCardComponent.<InitHitLocationCurveX>d__23>(ref <InitHitLocationCurveX>d__);
			return <InitHitLocationCurveX>d__.<>t__builder.Task;
		}

		// Token: 0x06037B91 RID: 228241 RVA: 0x00E20ED4 File Offset: 0x00E1F0D4
		private UniTask InitHitLocationCurveY()
		{
			NewBattleCardComponent.<InitHitLocationCurveY>d__24 <InitHitLocationCurveY>d__;
			<InitHitLocationCurveY>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitHitLocationCurveY>d__.<>4__this = this;
			<InitHitLocationCurveY>d__.<>1__state = -1;
			<InitHitLocationCurveY>d__.<>t__builder.Start<NewBattleCardComponent.<InitHitLocationCurveY>d__24>(ref <InitHitLocationCurveY>d__);
			return <InitHitLocationCurveY>d__.<>t__builder.Task;
		}

		// Token: 0x06037B92 RID: 228242 RVA: 0x00E20F18 File Offset: 0x00E1F118
		protected override UniTask OnBeforeStartAsync()
		{
			NewBattleCardComponent.<OnBeforeStartAsync>d__25 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<NewBattleCardComponent.<OnBeforeStartAsync>d__25>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06037B93 RID: 228243 RVA: 0x00E20F5C File Offset: 0x00E1F15C
		protected override void OnStart()
		{
			this.Sequence = new UiSequencePlayer(base.GetItem(2));
			UUIItem item = base.GetItem(22);
			if (item != null)
			{
				item.SetUIActive(false);
			}
			this.TweenLogic = new PhantomArenaCardTweenLogic();
			this.TweenLogic.Init(base.GetItem(23));
			this.PlayHitEffect = new Func<UUIItem, UniTask>(this.PlayHitEffectInternal);
		}

		// Token: 0x06037B94 RID: 228244 RVA: 0x00E20FBF File Offset: 0x00E1F1BF
		protected override void OnBeforeDestroy()
		{
			this.Sequence.Clear();
			this.TweenLogic.Destroy();
		}

		// Token: 0x06037B95 RID: 228245 RVA: 0x00E20FD8 File Offset: 0x00E1F1D8
		private void RefreshCardAttrLogic(PhantomBattleCardAttr type, UUIText text, [Nullable(2)] string sequenceName = null)
		{
			int fightValueByAttr = this.Data.GetFightValueByAttr(type);
			EPhantomArenaCardValueChangeType ephantomArenaCardValueChangeType = this.Data.ValueChangeTypeByBuff(type);
			if (ephantomArenaCardValueChangeType == EPhantomArenaCardValueChangeType.None)
			{
				text.SetText(fightValueByAttr.ToString(), true);
				return;
			}
			if (sequenceName != null)
			{
				this.RootUiSequencePlayer.PlaySequence(sequenceName, false, null);
			}
			if (ephantomArenaCardValueChangeType == EPhantomArenaCardValueChangeType.Add)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "PhantomBattle_1101", new <>z__ReadOnlySingleElementList<object>(fightValueByAttr));
				return;
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "PhantomBattle_1102", new <>z__ReadOnlySingleElementList<object>(fightValueByAttr));
		}

		// Token: 0x06037B96 RID: 228246 RVA: 0x00E21068 File Offset: 0x00E1F268
		private void RefreshAttack()
		{
			UUIText text = base.GetText(1);
			this.RefreshCardAttrLogic(PhantomBattleCardAttr.AttackAbility, text, "NumUpChange");
		}

		// Token: 0x06037B97 RID: 228247 RVA: 0x00E2108C File Offset: 0x00E1F28C
		private void RefreshHealth()
		{
			UUIText text = base.GetText(3);
			this.RefreshCardAttrLogic(PhantomBattleCardAttr.LifeAbility, text, "NumDownChange");
		}

		// Token: 0x06037B98 RID: 228248 RVA: 0x00E210B0 File Offset: 0x00E1F2B0
		private void RefreshCost()
		{
			UUIText text = base.GetText(4);
			this.RefreshCardAttrLogic(PhantomBattleCardAttr.CostAbility, text, "NumDamageChange");
		}

		// Token: 0x06037B99 RID: 228249 RVA: 0x00E210D4 File Offset: 0x00E1F2D4
		private void RefreshElement()
		{
			if (this.Data.IsInFight && this.Data.HasClickActiveSkill)
			{
				UUIItem item = base.GetItem(8);
				if (item == null)
				{
					return;
				}
				item.SetUIActive(false);
				return;
			}
			else
			{
				ECardElement element = (ECardElement)ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleCardConfig(this.Data.ConfigId).Element;
				if (element != ECardElement.Physical)
				{
					UUIItem item2 = base.GetItem(8);
					if (item2 != null)
					{
						item2.SetUIActive(true);
					}
					this.ElementItem.Refresh(element, false, 0);
					return;
				}
				UUIItem item3 = base.GetItem(8);
				if (item3 == null)
				{
					return;
				}
				item3.SetUIActive(false);
				return;
			}
		}

		// Token: 0x06037B9A RID: 228250 RVA: 0x00E21163 File Offset: 0x00E1F363
		private void RefreshItem()
		{
			UUIItem item = base.GetItem(15);
			if (item != null)
			{
				item.SetUIActive(!this.Data.IsFourCost);
			}
			UUIItem item2 = base.GetItem(16);
			if (item2 == null)
			{
				return;
			}
			item2.SetUIActive(this.Data.IsFourCost);
		}

		// Token: 0x06037B9B RID: 228251 RVA: 0x00E211A4 File Offset: 0x00E1F3A4
		private void RefreshCostItem()
		{
			bool isField = this.Data.IsField;
			UUIItem item = base.GetItem(10);
			if (item != null)
			{
				item.SetUIActive(!isField);
			}
			if (!isField)
			{
				this.RefreshLightItem();
			}
		}

		// Token: 0x06037B9C RID: 228252 RVA: 0x00E211E0 File Offset: 0x00E1F3E0
		private void RefreshLightItem()
		{
			UUIItem item = base.GetItem(5);
			if (item != null)
			{
				item.SetUIActive(this.Data.UseCost >= 1);
			}
			UUIItem item2 = base.GetItem(6);
			if (item2 != null)
			{
				item2.SetUIActive(this.Data.UseCost >= 3);
			}
			UUIItem item3 = base.GetItem(7);
			if (item3 == null)
			{
				return;
			}
			item3.SetUIActive(this.Data.UseCost >= 3);
		}

		// Token: 0x06037B9D RID: 228253 RVA: 0x00E21258 File Offset: 0x00E1F458
		private void RefreshCardItem()
		{
			bool isNormal = this.Data.IsNormal;
			UUIItem item = base.GetItem(18);
			if (item != null)
			{
				item.SetUIActive(isNormal);
			}
			if (!isNormal)
			{
				return;
			}
			this.RefreshAttack();
			this.RefreshHealth();
			this.RefreshCost();
		}

		// Token: 0x06037B9E RID: 228254 RVA: 0x00E2129C File Offset: 0x00E1F49C
		private void RefreshFieldItem()
		{
			bool isField = this.Data.IsField;
			UUIItem item = base.GetItem(19);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(isField);
		}

		// Token: 0x06037B9F RID: 228255 RVA: 0x00E212C8 File Offset: 0x00E1F4C8
		private void RefreshToolItem()
		{
			bool isTool = this.Data.IsTool;
			UUIItem item = base.GetItem(20);
			if (item != null)
			{
				item.SetUIActive(isTool);
			}
			if (isTool)
			{
				UUIText text = base.GetText(21);
				if (text == null)
				{
					return;
				}
				text.SetText(this.Data.Durable.ToString(), true);
			}
		}

		// Token: 0x06037BA0 RID: 228256 RVA: 0x00E21320 File Offset: 0x00E1F520
		private UniTask RefreshCardFaceAsync()
		{
			NewBattleCardComponent.<RefreshCardFaceAsync>d__39 <RefreshCardFaceAsync>d__;
			<RefreshCardFaceAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshCardFaceAsync>d__.<>4__this = this;
			<RefreshCardFaceAsync>d__.<>1__state = -1;
			<RefreshCardFaceAsync>d__.<>t__builder.Start<NewBattleCardComponent.<RefreshCardFaceAsync>d__39>(ref <RefreshCardFaceAsync>d__);
			return <RefreshCardFaceAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06037BA1 RID: 228257 RVA: 0x00E21364 File Offset: 0x00E1F564
		private void RefreshEvolveItem()
		{
			int evolveNum = this.Data.EvolveNum;
			UUIItem item = base.GetItem(22);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(evolveNum != 0);
		}

		// Token: 0x06037BA2 RID: 228258 RVA: 0x00E21393 File Offset: 0x00E1F593
		public void SetCardData(PhantomCardData data)
		{
			this.Data = data;
		}

		// Token: 0x06037BA3 RID: 228259 RVA: 0x00E2139C File Offset: 0x00E1F59C
		public UniTask InitEffect()
		{
			NewBattleCardComponent.<InitEffect>d__42 <InitEffect>d__;
			<InitEffect>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitEffect>d__.<>4__this = this;
			<InitEffect>d__.<>1__state = -1;
			<InitEffect>d__.<>t__builder.Start<NewBattleCardComponent.<InitEffect>d__42>(ref <InitEffect>d__);
			return <InitEffect>d__.<>t__builder.Task;
		}

		// Token: 0x06037BA4 RID: 228260 RVA: 0x00E213E0 File Offset: 0x00E1F5E0
		public UniTask InitSpine()
		{
			NewBattleCardComponent.<InitSpine>d__43 <InitSpine>d__;
			<InitSpine>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitSpine>d__.<>4__this = this;
			<InitSpine>d__.<>1__state = -1;
			<InitSpine>d__.<>t__builder.Start<NewBattleCardComponent.<InitSpine>d__43>(ref <InitSpine>d__);
			return <InitSpine>d__.<>t__builder.Task;
		}

		// Token: 0x06037BA5 RID: 228261 RVA: 0x00E21424 File Offset: 0x00E1F624
		public void SetDebugText()
		{
			UUIText text = base.GetText(12);
			if (!GlobalData.IsPlayInEditor)
			{
				if (text != null)
				{
					text.SetUIActive(false);
				}
				return;
			}
			PhantomBattleCard phantomBattleCardConfig = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleCardConfig(this.Data.ConfigId);
			if (text != null)
			{
				text.SetUIActive(true);
			}
			List<int> list = new List<int>(phantomBattleCardConfig.CardFactorId());
			list.AddRange(this.Data.ExtraFactors);
			if (text != null)
			{
				UUIText uuitext = text;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(71, 8);
				defaultInterpolatedStringHandler.AppendLiteral("卡牌ID:  ");
				defaultInterpolatedStringHandler.AppendFormatted<int>(this.Data.CardId);
				defaultInterpolatedStringHandler.AppendLiteral("\n配置ID:  ");
				defaultInterpolatedStringHandler.AppendFormatted<int>(this.Data.ConfigId);
				defaultInterpolatedStringHandler.AppendLiteral("\n进化次数:  ");
				defaultInterpolatedStringHandler.AppendFormatted<int>(this.Data.EvolveNum);
				defaultInterpolatedStringHandler.AppendLiteral("\n被动技能Id:  ");
				defaultInterpolatedStringHandler.AppendFormatted<int[]>(phantomBattleCardConfig.GetPassiveSkillIdArray());
				defaultInterpolatedStringHandler.AppendLiteral("\n主动技能Id:  ");
				defaultInterpolatedStringHandler.AppendFormatted<int>(phantomBattleCardConfig.ActiveSkillId);
				defaultInterpolatedStringHandler.AppendLiteral("\n卡牌因子:  ");
				defaultInterpolatedStringHandler.AppendFormatted(string.Join<int>(", ", list));
				defaultInterpolatedStringHandler.AppendLiteral("\n实体配置Id:  ");
				defaultInterpolatedStringHandler.AppendFormatted<int>(phantomBattleCardConfig.EntityConfigId);
				defaultInterpolatedStringHandler.AppendLiteral("\n卡牌上阵倾向:  ");
				defaultInterpolatedStringHandler.AppendFormatted<int>(phantomBattleCardConfig.SlotTendency);
				uuitext.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
			}
		}

		// Token: 0x06037BA6 RID: 228262 RVA: 0x00E21588 File Offset: 0x00E1F788
		public void PlaySpineAnim(string animName, bool isLoop)
		{
			BattleCardSpineItem spineItem = this.SpineItem;
			if (spineItem == null)
			{
				return;
			}
			spineItem.PlaySpineAnim(animName, isLoop);
		}

		// Token: 0x06037BA7 RID: 228263 RVA: 0x00E2159C File Offset: 0x00E1F79C
		public override void Refresh(PhantomCardData data)
		{
			this.RefreshAsync(data).Forget();
		}

		// Token: 0x06037BA8 RID: 228264 RVA: 0x00E215AC File Offset: 0x00E1F7AC
		public UniTask RefreshAsync(PhantomCardData data)
		{
			NewBattleCardComponent.<RefreshAsync>d__47 <RefreshAsync>d__;
			<RefreshAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshAsync>d__.<>4__this = this;
			<RefreshAsync>d__.data = data;
			<RefreshAsync>d__.<>1__state = -1;
			<RefreshAsync>d__.<>t__builder.Start<NewBattleCardComponent.<RefreshAsync>d__47>(ref <RefreshAsync>d__);
			return <RefreshAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06037BA9 RID: 228265 RVA: 0x00E215F7 File Offset: 0x00E1F7F7
		public UUIExtendToggle GetCardToggle()
		{
			return base.GetExtendToggle(0);
		}

		// Token: 0x06037BAA RID: 228266 RVA: 0x00E21600 File Offset: 0x00E1F800
		public UUIItem GetTweenItem()
		{
			return base.GetItem(14);
		}

		// Token: 0x06037BAB RID: 228267 RVA: 0x00E2160A File Offset: 0x00E1F80A
		public void PlaySequence(string name)
		{
			if (this.Sequence.IsSequenceInPlaying(name))
			{
				return;
			}
			this.Sequence.StopPrevSequence(false, true);
			this.Sequence.PlaySequencePurely(name, false, false);
		}

		// Token: 0x06037BAC RID: 228268 RVA: 0x00E21636 File Offset: 0x00E1F836
		public void PlayEffect()
		{
			BattleCardEffectItem effectItem = this.EffectItem;
			if (effectItem == null)
			{
				return;
			}
			effectItem.PlayStartEffect();
		}

		// Token: 0x17008F76 RID: 36726
		// (get) Token: 0x06037BAD RID: 228269 RVA: 0x00E21648 File Offset: 0x00E1F848
		// (set) Token: 0x06037BAE RID: 228270 RVA: 0x00E21650 File Offset: 0x00E1F850
		public Func<UUIItem, UniTask> PlayHitEffect { get; set; }

		// Token: 0x06037BAF RID: 228271 RVA: 0x00E2165C File Offset: 0x00E1F85C
		private UniTask PlayHitEffectInternal(UUIItem toItem)
		{
			NewBattleCardComponent.<PlayHitEffectInternal>d__56 <PlayHitEffectInternal>d__;
			<PlayHitEffectInternal>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayHitEffectInternal>d__.<>4__this = this;
			<PlayHitEffectInternal>d__.toItem = toItem;
			<PlayHitEffectInternal>d__.<>1__state = -1;
			<PlayHitEffectInternal>d__.<>t__builder.Start<NewBattleCardComponent.<PlayHitEffectInternal>d__56>(ref <PlayHitEffectInternal>d__);
			return <PlayHitEffectInternal>d__.<>t__builder.Task;
		}

		// Token: 0x0401FE8F RID: 130703
		private CardElementItem ElementItem;

		// Token: 0x0401FE90 RID: 130704
		protected UiSequencePlayer Sequence;

		// Token: 0x0401FE92 RID: 130706
		protected PhantomCardData Data;

		// Token: 0x0401FE93 RID: 130707
		protected BattleCardLoopEffectItem LoopEffectItem;

		// Token: 0x0401FE94 RID: 130708
		protected BattleCardEffectItem EffectItem;

		// Token: 0x0401FE95 RID: 130709
		protected BattleCardSpineItem SpineItem;

		// Token: 0x0401FE96 RID: 130710
		protected PhantomArenaCardTweenLogic TweenLogic;

		// Token: 0x0401FE97 RID: 130711
		protected UCurveFloat HitLocationCurveX;

		// Token: 0x0401FE98 RID: 130712
		protected UCurveFloat HitLocationCurveY;

		// Token: 0x0200B50A RID: 46346
		[NullableContext(0)]
		private static class EComponentDefine
		{
			// Token: 0x040380A5 RID: 229541
			public const int Toggle = 0;

			// Token: 0x040380A6 RID: 229542
			public const int AttackText = 1;

			// Token: 0x040380A7 RID: 229543
			public const int ContentItem = 2;

			// Token: 0x040380A8 RID: 229544
			public const int HealthText = 3;

			// Token: 0x040380A9 RID: 229545
			public const int CostText = 4;

			// Token: 0x040380AA RID: 229546
			public const int MiddleHighLightItem = 5;

			// Token: 0x040380AB RID: 229547
			public const int LeftHighLightItem = 6;

			// Token: 0x040380AC RID: 229548
			public const int RightHighLightItem = 7;

			// Token: 0x040380AD RID: 229549
			public const int ElementItem = 8;

			// Token: 0x040380AE RID: 229550
			public const int ElementIconItem = 9;

			// Token: 0x040380AF RID: 229551
			public const int CostItem = 10;

			// Token: 0x040380B0 RID: 229552
			public const int CardFaceTexture = 11;

			// Token: 0x040380B1 RID: 229553
			public const int DebugText = 12;

			// Token: 0x040380B2 RID: 229554
			public const int AttachItem = 13;

			// Token: 0x040380B3 RID: 229555
			public const int TweenItem = 14;

			// Token: 0x040380B4 RID: 229556
			public const int GreenItem = 15;

			// Token: 0x040380B5 RID: 229557
			public const int RedItem = 16;

			// Token: 0x040380B6 RID: 229558
			public const int SpineAttachItem = 17;

			// Token: 0x040380B7 RID: 229559
			public const int NormalCardItem = 18;

			// Token: 0x040380B8 RID: 229560
			public const int FieldCardItem = 19;

			// Token: 0x040380B9 RID: 229561
			public const int ToolCardItem = 20;

			// Token: 0x040380BA RID: 229562
			public const int ToolCount = 21;

			// Token: 0x040380BB RID: 229563
			public const int EvolveItem = 22;

			// Token: 0x040380BC RID: 229564
			public const int HitItem = 23;
		}
	}
}
