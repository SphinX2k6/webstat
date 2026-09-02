using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Module.PhantomArena.Battle.Card;
using CSharpScript.Game.Module.PhantomArena.Battle.Model;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Battle.View.Panel
{
	// Token: 0x020055BB RID: 21947
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomArenaCardRecycle : UiPanelBase
	{
		// Token: 0x06037E2A RID: 228906 RVA: 0x00E28E10 File Offset: 0x00E27010
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIText)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIItem))
			};
		}

		// Token: 0x06037E2B RID: 228907 RVA: 0x00E28E98 File Offset: 0x00E27098
		protected override void OnStart()
		{
			this.Sequence = new UiSequencePlayer(this.RootItem);
			this.Sequence.BindOnEndSequenceEvent(new Action<string>(this.SequenceEnd));
			global::Transform itemWorldTrans = this.ItemWorldTrans;
			FTransform ftransform = this.RootItem.K2_GetComponentToWorld();
			itemWorldTrans.FromUeTransform(ftransform);
			this.TotalWidth = this.RootItem.GetWidth();
			this.TotalHeight = this.RootItem.GetHeight();
			this.Pivot.FromUeVector2D(this.RootItem.GetPivot());
			this.EffectItem = base.GetItem(1);
			this.SealEffectItem = base.GetItem(4);
			this.LightSequence = new UiSequencePlayer(this.EffectItem);
			this.SealLightSequence = new UiSequencePlayer(this.SealEffectItem);
			this.EffectItem.SetUIActive(false);
			this.SealEffectItem.SetUIActive(false);
			UUIItem item = base.GetItem(3);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(false);
		}

		// Token: 0x06037E2C RID: 228908 RVA: 0x00E28F89 File Offset: 0x00E27189
		protected override void OnBeforeDestroy()
		{
			this.Sequence.Clear();
			this.LightSequence.Clear();
			this.SealLightSequence.Clear();
		}

		// Token: 0x06037E2D RID: 228909 RVA: 0x00E28FAC File Offset: 0x00E271AC
		private void SequenceEnd(string sequenceName)
		{
			if (sequenceName == "RecycleDisactive" || sequenceName == "RecycleSuccess")
			{
				this.EffectItem.SetUIActive(false);
				return;
			}
			if (sequenceName == "BanSuccess" || sequenceName == "BanDisactive")
			{
				this.SealEffectItem.SetUIActive(false);
			}
		}

		// Token: 0x06037E2E RID: 228910 RVA: 0x00E29008 File Offset: 0x00E27208
		public bool CheckCardInRecycleArea(PhantomArenaCard card)
		{
			this.TempCardPos.FromUeVector(card.GetWorldLocation());
			this.ItemWorldTrans.InverseTransformPosition(this.TempCardPos, this.TempCardPos);
			return this.TempCardPos.X >= -this.Pivot.X * (double)this.TotalWidth;
		}

		// Token: 0x06037E2F RID: 228911 RVA: 0x00E29064 File Offset: 0x00E27264
		public void SetEffectActive(ERecycleSequenceType type)
		{
			bool flag = type == ERecycleSequenceType.Active;
			if (this.EffectItemActive == flag)
			{
				return;
			}
			this.EffectItemActive = flag;
			bool recycleIsInSeal = ModelBase<PhantomArenaBattleModel>.Instance.OwnData.RecycleIsInSeal;
			if (type == ERecycleSequenceType.Active)
			{
				this.EffectItem.SetUIActive(!recycleIsInSeal);
				this.SealEffectItem.SetUIActive(recycleIsInSeal);
				this.Sequence.StopPrevSequence(false, true);
				string sequenceName = recycleIsInSeal ? "BanActive" : "RecycleActive";
				this.Sequence.PlaySequencePurely(sequenceName, false, false);
				return;
			}
			if (type == ERecycleSequenceType.DisActive)
			{
				this.Sequence.StopPrevSequence(false, true);
				string sequenceName2 = recycleIsInSeal ? "BanDisactive" : "RecycleDisactive";
				this.Sequence.PlaySequencePurely(sequenceName2, false, false);
				return;
			}
			this.Sequence.StopPrevSequence(false, true);
			string sequenceName3 = recycleIsInSeal ? "BanSuccess" : "RecycleSuccess";
			this.Sequence.PlaySequencePurely(sequenceName3, false, false);
			this.SealLightSequenceName = "RecycleLightRedClose";
			this.LightSequenceName = "RecycleLightClose";
		}

		// Token: 0x06037E30 RID: 228912 RVA: 0x00E29154 File Offset: 0x00E27354
		protected bool CheckSettingGuideCondition(int cardId)
		{
			int handIndexByCardId = ModelBase<PhantomArenaBattleModel>.Instance.OwnData.GetHandIndexByCardId(cardId);
			return this.ViewProxy.GuideManager.CheckCanExecuteAndShowFailTips(EBvbPlayerOperationType.BvbRecycleHandCard, new object[]
			{
				handIndexByCardId
			});
		}

		// Token: 0x06037E31 RID: 228913 RVA: 0x00E29192 File Offset: 0x00E27392
		protected bool CheckEvolveGuideCondition(int index)
		{
			return this.ViewProxy.GuideManager.CheckCanExecuteAndShowFailTips(EBvbPlayerOperationType.BvbRecycleBoardCard, new object[]
			{
				index
			});
		}

		// Token: 0x06037E32 RID: 228914 RVA: 0x00E291B4 File Offset: 0x00E273B4
		public void RefreshCardRecycleArea(PhantomArenaCard card)
		{
			bool flag = this.CheckCardInRecycleArea(card);
			if (ModelBase<PhantomArenaBattleModel>.Instance.OwnData.RecycleIsInSeal)
			{
				string text = flag ? "RecycleLightRed" : "RecycleLightRedClose";
				if (this.SealLightSequenceName == text)
				{
					return;
				}
				this.SealLightSequenceName = text;
				this.SealLightSequence.PlaySequence(text, false, null);
				return;
			}
			else
			{
				string text2 = flag ? "RecycleLight" : "RecycleLightClose";
				if (this.LightSequenceName == text2)
				{
					return;
				}
				this.LightSequenceName = text2;
				this.LightSequence.PlaySequence(text2, false, null);
				return;
			}
		}

		// Token: 0x06037E33 RID: 228915 RVA: 0x00E29254 File Offset: 0x00E27454
		[NullableContext(0)]
		public UniTask<bool> TrySettingCardByHand([Nullable(1)] PhantomArenaCard card, bool fromGamepad = false)
		{
			PhantomArenaCardRecycle.<TrySettingCardByHand>d__25 <TrySettingCardByHand>d__;
			<TrySettingCardByHand>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<TrySettingCardByHand>d__.<>4__this = this;
			<TrySettingCardByHand>d__.card = card;
			<TrySettingCardByHand>d__.fromGamepad = fromGamepad;
			<TrySettingCardByHand>d__.<>1__state = -1;
			<TrySettingCardByHand>d__.<>t__builder.Start<PhantomArenaCardRecycle.<TrySettingCardByHand>d__25>(ref <TrySettingCardByHand>d__);
			return <TrySettingCardByHand>d__.<>t__builder.Task;
		}

		// Token: 0x06037E34 RID: 228916 RVA: 0x00E292A8 File Offset: 0x00E274A8
		[NullableContext(0)]
		public UniTask<bool> TrySettingCardByFunctional([Nullable(1)] PhantomArenaCard card, int index, bool fromGamepad = false)
		{
			PhantomArenaCardRecycle.<TrySettingCardByFunctional>d__26 <TrySettingCardByFunctional>d__;
			<TrySettingCardByFunctional>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<TrySettingCardByFunctional>d__.<>4__this = this;
			<TrySettingCardByFunctional>d__.card = card;
			<TrySettingCardByFunctional>d__.index = index;
			<TrySettingCardByFunctional>d__.fromGamepad = fromGamepad;
			<TrySettingCardByFunctional>d__.<>1__state = -1;
			<TrySettingCardByFunctional>d__.<>t__builder.Start<PhantomArenaCardRecycle.<TrySettingCardByFunctional>d__26>(ref <TrySettingCardByFunctional>d__);
			return <TrySettingCardByFunctional>d__.<>t__builder.Task;
		}

		// Token: 0x06037E35 RID: 228917 RVA: 0x00E29304 File Offset: 0x00E27504
		public void RefreshCostNum()
		{
			int battleStatusValue = ModelBase<PhantomArenaBattleModel>.Instance.OwnData.GetBattleStatusValue(PhantomBattleRoleStatus.PhantomBattleCostPoint);
			int challengeId = ModelBase<PhantomArenaBattleModel>.Instance.ChallengeId;
			PhantomBattleChallenge phantomBattleChallenge = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleChallenge(challengeId);
			base.GetText(0).SetText(battleStatusValue.ToString() + "/" + phantomBattleChallenge.RecoverCostPoint.ToString(), true);
		}

		// Token: 0x06037E36 RID: 228918 RVA: 0x00E29366 File Offset: 0x00E27566
		public EPhantomCardSettingFailReason GetSettingFailReason()
		{
			return this.SettingFailReason;
		}

		// Token: 0x06037E37 RID: 228919 RVA: 0x00E2936E File Offset: 0x00E2756E
		public void ResetSettingFailReason()
		{
			this.SettingFailReason = EPhantomCardSettingFailReason.None;
		}

		// Token: 0x06037E38 RID: 228920 RVA: 0x00E2937B File Offset: 0x00E2757B
		public void RegisterViewProxy(PhantomArenaBattleProxy proxy)
		{
			this.ViewProxy = proxy;
		}

		// Token: 0x0401FFB2 RID: 130994
		protected PhantomArenaBattleProxy ViewProxy;

		// Token: 0x0401FFB3 RID: 130995
		protected readonly global::Vector TempCardPos = global::Vector.Create();

		// Token: 0x0401FFB4 RID: 130996
		protected readonly global::Transform ItemWorldTrans = global::Transform.Create();

		// Token: 0x0401FFB5 RID: 130997
		protected float TotalWidth;

		// Token: 0x0401FFB6 RID: 130998
		protected float TotalHeight;

		// Token: 0x0401FFB7 RID: 130999
		protected Vector2D Pivot = Vector2D.Create(0.0, 0.0);

		// Token: 0x0401FFB8 RID: 131000
		protected UUIItem EffectItem;

		// Token: 0x0401FFB9 RID: 131001
		protected UUIItem SealEffectItem;

		// Token: 0x0401FFBA RID: 131002
		protected bool EffectItemActive;

		// Token: 0x0401FFBB RID: 131003
		protected EPhantomCardSettingFailReason SettingFailReason = EPhantomCardSettingFailReason.None;

		// Token: 0x0401FFBC RID: 131004
		protected UiSequencePlayer Sequence;

		// Token: 0x0401FFBD RID: 131005
		protected UiSequencePlayer LightSequence;

		// Token: 0x0401FFBE RID: 131006
		protected UiSequencePlayer SealLightSequence;

		// Token: 0x0401FFBF RID: 131007
		protected string LightSequenceName = "RecycleLightClose";

		// Token: 0x0401FFC0 RID: 131008
		protected string SealLightSequenceName = "RecycleLightRedClose";

		// Token: 0x0200B57F RID: 46463
		[NullableContext(0)]
		private class EComponentDefine
		{
			// Token: 0x040382A3 RID: 230051
			public const int CostNum = 0;

			// Token: 0x040382A4 RID: 230052
			public const int EffectItem = 1;

			// Token: 0x040382A5 RID: 230053
			public const int AddNum = 2;

			// Token: 0x040382A6 RID: 230054
			public const int SealCount = 3;

			// Token: 0x040382A7 RID: 230055
			public const int SealEffectItem = 4;
		}
	}
}
