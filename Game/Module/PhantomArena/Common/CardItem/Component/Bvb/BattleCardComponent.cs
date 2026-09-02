using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.PhantomArena.Battle;
using CSharpScript.Game.Module.PhantomArena.Battle.Model;
using CSharpScript.Game.Module.PhantomArena.Common.CardItem.Item;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Common.CardItem.Component.Bvb
{
	// Token: 0x0200555E RID: 21854
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class BattleCardComponent : CardComponentBase<PhantomCardData>, IBattleCardComponent
	{
		// Token: 0x17008F6E RID: 36718
		// (get) Token: 0x06037B2F RID: 228143 RVA: 0x00E1FB8F File Offset: 0x00E1DD8F
		// (set) Token: 0x06037B30 RID: 228144 RVA: 0x00E1FB97 File Offset: 0x00E1DD97
		public Action<EToggleState> CardClickCallback { get; set; }

		// Token: 0x17008F6F RID: 36719
		// (get) Token: 0x06037B31 RID: 228145 RVA: 0x00E1FBA0 File Offset: 0x00E1DDA0
		// (set) Token: 0x06037B32 RID: 228146 RVA: 0x00E1FBA8 File Offset: 0x00E1DDA8
		public UiSequencePlayer RootUiSequencePlayer { get; set; }

		// Token: 0x06037B33 RID: 228147 RVA: 0x00E1FBB4 File Offset: 0x00E1DDB4
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
				new ValueTuple<int, Type>(8, typeof(UUITexture)),
				new ValueTuple<int, Type>(9, typeof(UUIText)),
				new ValueTuple<int, Type>(10, typeof(UUIItem)),
				new ValueTuple<int, Type>(11, typeof(UUIItem)),
				new ValueTuple<int, Type>(12, typeof(UUIItem)),
				new ValueTuple<int, Type>(13, typeof(UUIItem)),
				new ValueTuple<int, Type>(14, typeof(UUIItem)),
				new ValueTuple<int, Type>(15, typeof(UUIItem)),
				new ValueTuple<int, Type>(17, typeof(UUIItem)),
				new ValueTuple<int, Type>(16, typeof(UUIItem)),
				new ValueTuple<int, Type>(18, typeof(UUIItem)),
				new ValueTuple<int, Type>(19, typeof(UUIItem)),
				new ValueTuple<int, Type>(20, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.CardClick))
			};
		}

		// Token: 0x06037B34 RID: 228148 RVA: 0x00E1FDC9 File Offset: 0x00E1DFC9
		private void CardClick(EToggleState state)
		{
			Action<EToggleState> cardClickCallback = this.CardClickCallback;
			if (cardClickCallback == null)
			{
				return;
			}
			cardClickCallback(state);
		}

		// Token: 0x06037B35 RID: 228149 RVA: 0x00E1FDDC File Offset: 0x00E1DFDC
		protected UniTask InitElement()
		{
			BattleCardComponent.<InitElement>d__19 <InitElement>d__;
			<InitElement>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitElement>d__.<>4__this = this;
			<InitElement>d__.<>1__state = -1;
			<InitElement>d__.<>t__builder.Start<BattleCardComponent.<InitElement>d__19>(ref <InitElement>d__);
			return <InitElement>d__.<>t__builder.Task;
		}

		// Token: 0x06037B36 RID: 228150 RVA: 0x00E1FE20 File Offset: 0x00E1E020
		protected override UniTask OnBeforeStartAsync()
		{
			BattleCardComponent.<OnBeforeStartAsync>d__20 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<BattleCardComponent.<OnBeforeStartAsync>d__20>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06037B37 RID: 228151 RVA: 0x00E1FE63 File Offset: 0x00E1E063
		protected override void OnStart()
		{
			this.Sequence = new UiSequencePlayer(base.GetItem(2));
		}

		// Token: 0x06037B38 RID: 228152 RVA: 0x00E1FE77 File Offset: 0x00E1E077
		protected override void OnBeforeDestroy()
		{
			this.Sequence.Clear();
		}

		// Token: 0x06037B39 RID: 228153 RVA: 0x00E1FE84 File Offset: 0x00E1E084
		private void RefreshCardAttrLogic(PhantomBattleCardAttr type, UUIText text)
		{
			int fightValueByAttr = this.Data.GetFightValueByAttr(type);
			EPhantomArenaCardValueChangeType ephantomArenaCardValueChangeType = this.Data.ValueChangeTypeByBuff(type);
			if (ephantomArenaCardValueChangeType == EPhantomArenaCardValueChangeType.None)
			{
				text.SetText(fightValueByAttr.ToString(), true);
				return;
			}
			if (ephantomArenaCardValueChangeType == EPhantomArenaCardValueChangeType.Add)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "PhantomBattle_1101", new <>z__ReadOnlySingleElementList<object>(fightValueByAttr));
				return;
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "PhantomBattle_1102", new <>z__ReadOnlySingleElementList<object>(fightValueByAttr));
		}

		// Token: 0x06037B3A RID: 228154 RVA: 0x00E1FEF8 File Offset: 0x00E1E0F8
		private void RefreshAttack()
		{
			UUIText text = base.GetText(1);
			this.RefreshCardAttrLogic(PhantomBattleCardAttr.AttackAbility, text);
		}

		// Token: 0x06037B3B RID: 228155 RVA: 0x00E1FF18 File Offset: 0x00E1E118
		private void RefreshHealth()
		{
			UUIText text = base.GetText(3);
			this.RefreshCardAttrLogic(PhantomBattleCardAttr.LifeAbility, text);
		}

		// Token: 0x06037B3C RID: 228156 RVA: 0x00E1FF38 File Offset: 0x00E1E138
		private void RefreshCost()
		{
			UUIText text = base.GetText(4);
			this.RefreshCardAttrLogic(PhantomBattleCardAttr.CostAbility, text);
		}

		// Token: 0x06037B3D RID: 228157 RVA: 0x00E1FF58 File Offset: 0x00E1E158
		private void RefreshElement()
		{
			int element = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleCardConfig(this.Data.ConfigId).Element;
			this.ElementItem.Refresh((ECardElement)element, false, 0);
		}

		// Token: 0x06037B3E RID: 228158 RVA: 0x00E1FF91 File Offset: 0x00E1E191
		private void RefreshItem()
		{
			UUIItem item = base.GetItem(13);
			if (item != null)
			{
				item.SetUIActive(!this.Data.IsFourCost);
			}
			UUIItem item2 = base.GetItem(14);
			if (item2 == null)
			{
				return;
			}
			item2.SetUIActive(this.Data.IsFourCost);
		}

		// Token: 0x06037B3F RID: 228159 RVA: 0x00E1FFD4 File Offset: 0x00E1E1D4
		private void RefreshElementFrame()
		{
			PhantomBattleCard phantomBattleCardConfig = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleCardConfig(this.Data.ConfigId);
			bool flag = this.IsOutlookUnlocked();
			base.GetItem(10).SetUIActive(phantomBattleCardConfig.Element != 0 && !flag);
			base.GetItem(17).SetUIActive(phantomBattleCardConfig.Element != 0 && flag);
		}

		// Token: 0x06037B40 RID: 228160 RVA: 0x00E20034 File Offset: 0x00E1E234
		private void RefreshCardFrame()
		{
			bool flag = this.IsOutlookUnlocked();
			base.GetItem(15).SetUIActive(!flag);
			base.GetItem(16).SetUIActive(flag);
		}

		// Token: 0x06037B41 RID: 228161 RVA: 0x00E20068 File Offset: 0x00E1E268
		private UniTask RefreshCardFaceAsync()
		{
			BattleCardComponent.<RefreshCardFaceAsync>d__31 <RefreshCardFaceAsync>d__;
			<RefreshCardFaceAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshCardFaceAsync>d__.<>4__this = this;
			<RefreshCardFaceAsync>d__.<>1__state = -1;
			<RefreshCardFaceAsync>d__.<>t__builder.Start<BattleCardComponent.<RefreshCardFaceAsync>d__31>(ref <RefreshCardFaceAsync>d__);
			return <RefreshCardFaceAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06037B42 RID: 228162 RVA: 0x00E200AC File Offset: 0x00E1E2AC
		private UniTask RefreshGoldEvolveItem()
		{
			BattleCardComponent.<RefreshGoldEvolveItem>d__32 <RefreshGoldEvolveItem>d__;
			<RefreshGoldEvolveItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshGoldEvolveItem>d__.<>4__this = this;
			<RefreshGoldEvolveItem>d__.<>1__state = -1;
			<RefreshGoldEvolveItem>d__.<>t__builder.Start<BattleCardComponent.<RefreshGoldEvolveItem>d__32>(ref <RefreshGoldEvolveItem>d__);
			return <RefreshGoldEvolveItem>d__.<>t__builder.Task;
		}

		// Token: 0x06037B43 RID: 228163 RVA: 0x00E200F0 File Offset: 0x00E1E2F0
		private UniTask RefreshNormalEvolveItem()
		{
			BattleCardComponent.<RefreshNormalEvolveItem>d__33 <RefreshNormalEvolveItem>d__;
			<RefreshNormalEvolveItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshNormalEvolveItem>d__.<>4__this = this;
			<RefreshNormalEvolveItem>d__.<>1__state = -1;
			<RefreshNormalEvolveItem>d__.<>t__builder.Start<BattleCardComponent.<RefreshNormalEvolveItem>d__33>(ref <RefreshNormalEvolveItem>d__);
			return <RefreshNormalEvolveItem>d__.<>t__builder.Task;
		}

		// Token: 0x06037B44 RID: 228164 RVA: 0x00E20134 File Offset: 0x00E1E334
		private void RefreshLightItem()
		{
			UUIItem item = base.GetItem(19);
			if (item != null)
			{
				item.SetUIActive(this.Data.UseCost != 0);
			}
			UUIItem item2 = base.GetItem(5);
			if (item2 != null)
			{
				item2.SetUIActive(this.Data.UseCost >= 1);
			}
			UUIItem item3 = base.GetItem(6);
			if (item3 != null)
			{
				item3.SetUIActive(this.Data.UseCost >= 3);
			}
			UUIItem item4 = base.GetItem(20);
			if (item4 == null)
			{
				return;
			}
			item4.SetUIActive(this.Data.UseCost >= 3);
		}

		// Token: 0x06037B45 RID: 228165 RVA: 0x00E201CC File Offset: 0x00E1E3CC
		private UniTask RefreshEvolveItem()
		{
			BattleCardComponent.<RefreshEvolveItem>d__35 <RefreshEvolveItem>d__;
			<RefreshEvolveItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshEvolveItem>d__.<>4__this = this;
			<RefreshEvolveItem>d__.<>1__state = -1;
			<RefreshEvolveItem>d__.<>t__builder.Start<BattleCardComponent.<RefreshEvolveItem>d__35>(ref <RefreshEvolveItem>d__);
			return <RefreshEvolveItem>d__.<>t__builder.Task;
		}

		// Token: 0x06037B46 RID: 228166 RVA: 0x00E2020F File Offset: 0x00E1E40F
		public void SetCardData(PhantomCardData data)
		{
			this.Data = data;
		}

		// Token: 0x06037B47 RID: 228167 RVA: 0x00E20218 File Offset: 0x00E1E418
		private bool IsOutlookUnlocked()
		{
			return !this.Data.IsNpcCard && ModelBase<PhantomArenaModel>.Instance.IsCardOutlookUnlock(this.Data.ConfigId);
		}

		// Token: 0x06037B48 RID: 228168 RVA: 0x00E20240 File Offset: 0x00E1E440
		private UniTask InitLoopEffect()
		{
			BattleCardComponent.<InitLoopEffect>d__38 <InitLoopEffect>d__;
			<InitLoopEffect>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitLoopEffect>d__.<>4__this = this;
			<InitLoopEffect>d__.<>1__state = -1;
			<InitLoopEffect>d__.<>t__builder.Start<BattleCardComponent.<InitLoopEffect>d__38>(ref <InitLoopEffect>d__);
			return <InitLoopEffect>d__.<>t__builder.Task;
		}

		// Token: 0x06037B49 RID: 228169 RVA: 0x00E20284 File Offset: 0x00E1E484
		private UniTask InitStartEffect()
		{
			BattleCardComponent.<InitStartEffect>d__39 <InitStartEffect>d__;
			<InitStartEffect>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitStartEffect>d__.<>4__this = this;
			<InitStartEffect>d__.<>1__state = -1;
			<InitStartEffect>d__.<>t__builder.Start<BattleCardComponent.<InitStartEffect>d__39>(ref <InitStartEffect>d__);
			return <InitStartEffect>d__.<>t__builder.Task;
		}

		// Token: 0x06037B4A RID: 228170 RVA: 0x00E202C8 File Offset: 0x00E1E4C8
		public UniTask InitEffect()
		{
			BattleCardComponent.<InitEffect>d__40 <InitEffect>d__;
			<InitEffect>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitEffect>d__.<>4__this = this;
			<InitEffect>d__.<>1__state = -1;
			<InitEffect>d__.<>t__builder.Start<BattleCardComponent.<InitEffect>d__40>(ref <InitEffect>d__);
			return <InitEffect>d__.<>t__builder.Task;
		}

		// Token: 0x06037B4B RID: 228171 RVA: 0x00E2030C File Offset: 0x00E1E50C
		public UniTask InitSpine()
		{
			BattleCardComponent.<InitSpine>d__41 <InitSpine>d__;
			<InitSpine>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitSpine>d__.<>4__this = this;
			<InitSpine>d__.<>1__state = -1;
			<InitSpine>d__.<>t__builder.Start<BattleCardComponent.<InitSpine>d__41>(ref <InitSpine>d__);
			return <InitSpine>d__.<>t__builder.Task;
		}

		// Token: 0x06037B4C RID: 228172 RVA: 0x00E20350 File Offset: 0x00E1E550
		public void SetDebugText()
		{
			UUIText text = base.GetText(9);
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

		// Token: 0x06037B4D RID: 228173 RVA: 0x00E204B4 File Offset: 0x00E1E6B4
		public void PlaySpineAnim(string animName, bool isLoop)
		{
			BattleCardSpineItem spineItem = this.SpineItem;
			if (spineItem == null)
			{
				return;
			}
			spineItem.PlaySpineAnim(animName, isLoop);
		}

		// Token: 0x06037B4E RID: 228174 RVA: 0x00E204C8 File Offset: 0x00E1E6C8
		public override void Refresh(PhantomCardData data)
		{
			this.RefreshAsync(data).Forget();
		}

		// Token: 0x06037B4F RID: 228175 RVA: 0x00E204D8 File Offset: 0x00E1E6D8
		public UniTask RefreshAsync(PhantomCardData data)
		{
			BattleCardComponent.<RefreshAsync>d__45 <RefreshAsync>d__;
			<RefreshAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshAsync>d__.<>4__this = this;
			<RefreshAsync>d__.data = data;
			<RefreshAsync>d__.<>1__state = -1;
			<RefreshAsync>d__.<>t__builder.Start<BattleCardComponent.<RefreshAsync>d__45>(ref <RefreshAsync>d__);
			return <RefreshAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06037B50 RID: 228176 RVA: 0x00E20523 File Offset: 0x00E1E723
		public UUIExtendToggle GetCardToggle()
		{
			return base.GetExtendToggle(0);
		}

		// Token: 0x06037B51 RID: 228177 RVA: 0x00E2052C File Offset: 0x00E1E72C
		public UUIItem GetTweenItem()
		{
			return base.GetItem(12);
		}

		// Token: 0x06037B52 RID: 228178 RVA: 0x00E20536 File Offset: 0x00E1E736
		public void PlaySequence(string name)
		{
			if (this.Sequence.IsSequenceInPlaying(name))
			{
				return;
			}
			this.Sequence.StopPrevSequence(false, true);
			this.Sequence.PlaySequencePurely(name, false, false);
		}

		// Token: 0x06037B53 RID: 228179 RVA: 0x00E20562 File Offset: 0x00E1E762
		public void PlayEffect()
		{
			BattleCardEffectItem effectItem = this.EffectItem;
			if (effectItem == null)
			{
				return;
			}
			effectItem.PlayStartEffect();
		}

		// Token: 0x17008F70 RID: 36720
		// (get) Token: 0x06037B54 RID: 228180 RVA: 0x00E20574 File Offset: 0x00E1E774
		// (set) Token: 0x06037B55 RID: 228181 RVA: 0x00E2057C File Offset: 0x00E1E77C
		public Func<UUIItem, UniTask> PlayHitEffect { get; set; }

		// Token: 0x0401FE7F RID: 130687
		private CardElementItem ElementItem;

		// Token: 0x0401FE80 RID: 130688
		protected UiSequencePlayer Sequence;

		// Token: 0x0401FE82 RID: 130690
		protected PhantomCardData Data;

		// Token: 0x0401FE83 RID: 130691
		protected BattleCardLoopEffectItem LoopEffectItem;

		// Token: 0x0401FE84 RID: 130692
		protected BattleCardEffectItem EffectItem;

		// Token: 0x0401FE85 RID: 130693
		protected BattleCardSpineItem SpineItem;

		// Token: 0x0401FE86 RID: 130694
		protected EvolveProxy NormalEvolveItem;

		// Token: 0x0401FE87 RID: 130695
		protected EvolveProxy GoldEvolveItem;

		// Token: 0x0200B4EE RID: 46318
		[NullableContext(0)]
		private static class EComponentDefine
		{
			// Token: 0x04038020 RID: 229408
			public const int Toggle = 0;

			// Token: 0x04038021 RID: 229409
			public const int AttackText = 1;

			// Token: 0x04038022 RID: 229410
			public const int ContentItem = 2;

			// Token: 0x04038023 RID: 229411
			public const int HealthText = 3;

			// Token: 0x04038024 RID: 229412
			public const int CostText = 4;

			// Token: 0x04038025 RID: 229413
			public const int MiddleHighLightItem = 5;

			// Token: 0x04038026 RID: 229414
			public const int LeftHighLightItem = 6;

			// Token: 0x04038027 RID: 229415
			public const int ElementItem = 7;

			// Token: 0x04038028 RID: 229416
			public const int CardFaceTexture = 8;

			// Token: 0x04038029 RID: 229417
			public const int DebugText = 9;

			// Token: 0x0403802A RID: 229418
			public const int NormalElementFrameItem = 10;

			// Token: 0x0403802B RID: 229419
			public const int AttachItem = 11;

			// Token: 0x0403802C RID: 229420
			public const int TweenItem = 12;

			// Token: 0x0403802D RID: 229421
			public const int GreenItem = 13;

			// Token: 0x0403802E RID: 229422
			public const int RedItem = 14;

			// Token: 0x0403802F RID: 229423
			public const int NormalCardFrameItem = 15;

			// Token: 0x04038030 RID: 229424
			public const int GoldCardFrameItem = 16;

			// Token: 0x04038031 RID: 229425
			public const int GoldElementFrameItem = 17;

			// Token: 0x04038032 RID: 229426
			public const int SpineAttachItem = 18;

			// Token: 0x04038033 RID: 229427
			public const int LightBgItem = 19;

			// Token: 0x04038034 RID: 229428
			public const int RightHighLightItem = 20;
		}
	}
}
