using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Protocol;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x020060E1 RID: 24801
	public class SpecialEnergyBarSuisui : SpecialEnergyBarBase
	{
		// Token: 0x0603EA5F RID: 256607 RVA: 0x01009268 File Offset: 0x01007468
		protected unsafe override void OnRegisterComponent()
		{
			int num = 18;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(17, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603EA60 RID: 256608 RVA: 0x010094EB File Offset: 0x010076EB
		protected override void OnInitData()
		{
			this.EnhancedStateConfig = ModelBase<BattleUiModel>.Instance.SpecialEnergyBarData.GetSpecialEnergyBarInfo(111002);
		}

		// Token: 0x0603EA61 RID: 256609 RVA: 0x01009508 File Offset: 0x01007708
		protected override void AddEvents()
		{
			base.AddEvents();
			base.ListenForTagAddOrRemoveChanged(SpecialEnergyBarSuisui.EnhancedStateTagId, new BaseTagComponent.TTagSwitchedCallback(this.OnEnhancedStateTagChanged));
			base.ListenForTagAddOrRemoveChanged(SpecialEnergyBarSuisui.UltStateTagId, new BaseTagComponent.TTagSwitchedCallback(this.OnUltStateTagChanged));
			base.ListenForAttributeChanged(EAttributeType.SpecialEnergy2, new Action<EAttributeType, float, float>(this.OnEnhancedEnergyChanged));
		}

		// Token: 0x0603EA62 RID: 256610 RVA: 0x0100955D File Offset: 0x0100775D
		protected override void RemoveEvents()
		{
			base.RemoveEvents();
			base.RemoveListenAttributeChanged(EAttributeType.SpecialEnergy2, new Action<EAttributeType, float, float>(this.OnEnhancedEnergyChanged));
		}

		// Token: 0x0603EA63 RID: 256611 RVA: 0x0100957C File Offset: 0x0100777C
		protected override UniTask OnBeforeStartAsync()
		{
			SpecialEnergyBarSuisui.<OnBeforeStartAsync>d__22 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<SpecialEnergyBarSuisui.<OnBeforeStartAsync>d__22>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603EA64 RID: 256612 RVA: 0x010095C0 File Offset: 0x010077C0
		private UniTask InitBarItem()
		{
			SpecialEnergyBarSuisui.<InitBarItem>d__23 <InitBarItem>d__;
			<InitBarItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitBarItem>d__.<>4__this = this;
			<InitBarItem>d__.<>1__state = -1;
			<InitBarItem>d__.<>t__builder.Start<SpecialEnergyBarSuisui.<InitBarItem>d__23>(ref <InitBarItem>d__);
			return <InitBarItem>d__.<>t__builder.Task;
		}

		// Token: 0x0603EA65 RID: 256613 RVA: 0x01009604 File Offset: 0x01007804
		private UniTask InitEnhancedStateBarItem()
		{
			SpecialEnergyBarSuisui.<InitEnhancedStateBarItem>d__24 <InitEnhancedStateBarItem>d__;
			<InitEnhancedStateBarItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitEnhancedStateBarItem>d__.<>4__this = this;
			<InitEnhancedStateBarItem>d__.<>1__state = -1;
			<InitEnhancedStateBarItem>d__.<>t__builder.Start<SpecialEnergyBarSuisui.<InitEnhancedStateBarItem>d__24>(ref <InitEnhancedStateBarItem>d__);
			return <InitEnhancedStateBarItem>d__.<>t__builder.Task;
		}

		// Token: 0x0603EA66 RID: 256614 RVA: 0x01009648 File Offset: 0x01007848
		protected override void OnStart()
		{
			base.InitTweenAnim(4);
			base.InitTweenAnim(5);
			base.InitTweenAnim(6);
			base.InitTweenAnim(7);
			base.InitTweenAnim(8);
			base.InitTweenAnim(9);
			base.InitTweenAnim(10);
			base.InitTweenAnim(11);
			base.InitTweenAnim(12);
			base.InitTweenAnim(13);
			base.InitTweenAnim(14);
			base.InitTweenAnim(15);
			base.InitTweenAnim(16);
			base.InitTweenAnim(17);
			UUIItem item = base.GetItem(2);
			if (item != null)
			{
				item.SetAlpha(1f);
			}
			this.RefreshState(true);
		}

		// Token: 0x0603EA67 RID: 256615 RVA: 0x010096DE File Offset: 0x010078DE
		protected override void ClearAllTweenAnim()
		{
			base.StopTweenAnim(17);
			base.ClearAllTweenAnim();
		}

		// Token: 0x0603EA68 RID: 256616 RVA: 0x010096EE File Offset: 0x010078EE
		private void OnEnhancedStateTagChanged(int tagId, bool tagExist)
		{
			this.SetState(tagExist ? SpecialEnergyBarSuisui.EState.Enhanced : SpecialEnergyBarSuisui.EState.Normal, false);
		}

		// Token: 0x0603EA69 RID: 256617 RVA: 0x010096FE File Offset: 0x010078FE
		protected override void OnBarPercentChanged()
		{
			this.SetFullState(false);
		}

		// Token: 0x0603EA6A RID: 256618 RVA: 0x01009707 File Offset: 0x01007907
		private void OnEnhancedEnergyChanged(EAttributeType attributeId, float newValue, float oldValue)
		{
			this.SetEnhancedEnergyState(this.CalcEnhancedEnergyState(newValue), false);
		}

		// Token: 0x0603EA6B RID: 256619 RVA: 0x01009717 File Offset: 0x01007917
		private void OnUltStateTagChanged(int tagId, bool tagExist)
		{
			this.SetUltState(tagExist, false);
		}

		// Token: 0x0603EA6C RID: 256620 RVA: 0x01009724 File Offset: 0x01007924
		private void RefreshState(bool isForced = false)
		{
			BaseTagComponent tagComponent = this.TagComponent;
			this.SetState((tagComponent != null && tagComponent.HasTag(SpecialEnergyBarSuisui.EnhancedStateTagId)) ? SpecialEnergyBarSuisui.EState.Enhanced : SpecialEnergyBarSuisui.EState.Normal, isForced);
		}

		// Token: 0x0603EA6D RID: 256621 RVA: 0x01009757 File Offset: 0x01007957
		private void RefreshEnergy(bool isForced = false)
		{
			if (this.CurState == SpecialEnergyBarSuisui.EState.Enhanced)
			{
				this.RefreshEnhancedEnergyState(isForced);
				return;
			}
			this.SetFullState(isForced);
		}

		// Token: 0x0603EA6E RID: 256622 RVA: 0x01009774 File Offset: 0x01007974
		private void RefreshEnhancedEnergyState(bool isForced = false)
		{
			BaseAttributeComponent attributeComponent = this.AttributeComponent;
			float enhancedEnergy = (attributeComponent != null) ? attributeComponent.GetCurrentValue(EAttributeType.SpecialEnergy2) : 0f;
			this.SetEnhancedEnergyState(this.CalcEnhancedEnergyState(enhancedEnergy), isForced);
		}

		// Token: 0x0603EA6F RID: 256623 RVA: 0x010097A8 File Offset: 0x010079A8
		private void RefreshUltState(bool isForced = false)
		{
			BaseTagComponent tagComponent = this.TagComponent;
			bool isInUltState = tagComponent != null && tagComponent.HasTag(SpecialEnergyBarSuisui.UltStateTagId);
			this.SetUltState(isInUltState, isForced);
		}

		// Token: 0x0603EA70 RID: 256624 RVA: 0x010097D8 File Offset: 0x010079D8
		private SpecialEnergyBarSuisui.EEnhancedEnergyState CalcEnhancedEnergyState(float enhancedEnergy)
		{
			BaseAttributeComponent attributeComponent = this.AttributeComponent;
			float num = (attributeComponent != null) ? attributeComponent.GetCurrentValue(EAttributeType.SpecialEnergy2Max) : 0f;
			if (num <= 0f)
			{
				return SpecialEnergyBarSuisui.EEnhancedEnergyState.ZeroToOneThird;
			}
			float num2 = enhancedEnergy / num;
			if (num2 >= 1f)
			{
				return SpecialEnergyBarSuisui.EEnhancedEnergyState.Full;
			}
			if (num2 >= 0.6666667f)
			{
				return SpecialEnergyBarSuisui.EEnhancedEnergyState.TwoThirdToFull;
			}
			if (num2 >= 0.33333334f)
			{
				return SpecialEnergyBarSuisui.EEnhancedEnergyState.OneThirdToTwoThird;
			}
			return SpecialEnergyBarSuisui.EEnhancedEnergyState.ZeroToOneThird;
		}

		// Token: 0x0603EA71 RID: 256625 RVA: 0x0100982C File Offset: 0x01007A2C
		private void SetState(SpecialEnergyBarSuisui.EState state, bool isForced = false)
		{
			if (this.CurState == state && !isForced)
			{
				return;
			}
			this.CurState = state;
			if (this.CurState == SpecialEnergyBarSuisui.EState.Enhanced)
			{
				base.StopTweenAnim(5);
				base.PlayTweenAnim(4);
			}
			else
			{
				base.StopTweenAnim(4);
				base.PlayTweenAnim(5);
				this.PlayWarnAnim(false);
			}
			this.RefreshEnergy(true);
			if (this.CurState == SpecialEnergyBarSuisui.EState.Enhanced)
			{
				this.RefreshUltState(true);
			}
		}

		// Token: 0x0603EA72 RID: 256626 RVA: 0x01009894 File Offset: 0x01007A94
		private void SetFullState(bool isForced = false)
		{
			bool flag = this.PercentMachine.GetCurPercent() >= 1f;
			if (this.IsFull == flag && !isForced)
			{
				return;
			}
			this.IsFull = flag;
			if (flag)
			{
				base.StopTweenAnim(7);
				base.PlayTweenAnim(6);
				return;
			}
			base.StopTweenAnim(6);
			base.PlayTweenAnim(7);
		}

		// Token: 0x0603EA73 RID: 256627 RVA: 0x010098EC File Offset: 0x01007AEC
		private void SetEnhancedEnergyState(SpecialEnergyBarSuisui.EEnhancedEnergyState state, bool isForced = false)
		{
			if (this.CurEnhancedEnergyState == state && !isForced)
			{
				return;
			}
			this.CurEnhancedEnergyState = state;
			switch (state)
			{
			case SpecialEnergyBarSuisui.EEnhancedEnergyState.ZeroToOneThird:
				base.PlayTweenAnim(8);
				return;
			case SpecialEnergyBarSuisui.EEnhancedEnergyState.OneThirdToTwoThird:
				base.PlayTweenAnim(9);
				if (!isForced)
				{
					base.PlayTweenAnim(12);
					return;
				}
				break;
			case SpecialEnergyBarSuisui.EEnhancedEnergyState.TwoThirdToFull:
				base.PlayTweenAnim(10);
				if (!isForced)
				{
					base.PlayTweenAnim(13);
					return;
				}
				break;
			case SpecialEnergyBarSuisui.EEnhancedEnergyState.Full:
				base.PlayTweenAnim(11);
				if (!isForced)
				{
					base.PlayTweenAnim(14);
				}
				break;
			default:
				return;
			}
		}

		// Token: 0x0603EA74 RID: 256628 RVA: 0x01009967 File Offset: 0x01007B67
		private void SetUltState(bool isInUltState, bool isForced = false)
		{
			if (this.IsInUltState == isInUltState && !isForced)
			{
				return;
			}
			this.IsInUltState = isInUltState;
			if (isInUltState)
			{
				base.StopTweenAnim(16);
				base.PlayTweenAnim(15);
				return;
			}
			base.StopTweenAnim(15);
			base.PlayTweenAnim(16);
		}

		// Token: 0x0603EA75 RID: 256629 RVA: 0x010099A4 File Offset: 0x01007BA4
		public override void Tick(float delta)
		{
			base.Tick(delta);
			SpecialEnergyBarSlot barItem = this.BarItem;
			if (barItem != null)
			{
				barItem.Tick(delta);
			}
			SpecialEnergyBarSlot enhancedStateBarItem = this.EnhancedStateBarItem;
			if (enhancedStateBarItem != null)
			{
				enhancedStateBarItem.Tick(delta);
			}
			if (this.CurState == SpecialEnergyBarSuisui.EState.Normal)
			{
				this.PlayWarnAnim(false);
				return;
			}
			if (this.Buff != null)
			{
				CharacterBuffComponent buffComponent = this.BuffComponent;
				if (((buffComponent != null) ? buffComponent.GetBuffByHandle(this.BuffHandle) : null) != null)
				{
					goto IL_63;
				}
			}
			this.RefreshBuff();
			IL_63:
			if (this.Buff != null)
			{
				this.PlayWarnAnim(this.Buff.GetRemainDuration() < this.EnhancedStateConfig.ExtraFloatParams[0]);
				return;
			}
			this.PlayWarnAnim(false);
		}

		// Token: 0x0603EA76 RID: 256630 RVA: 0x01009A48 File Offset: 0x01007C48
		private void RefreshBuff()
		{
			if (this.EnhancedStateConfig != null && this.EnhancedStateConfig.BuffId != 0L)
			{
				CharacterBuffComponent buffComponent = this.BuffComponent;
				this.Buff = ((buffComponent != null) ? buffComponent.GetBuffById(this.EnhancedStateConfig.BuffId) : null);
				IActiveBuff buff = this.Buff;
				this.BuffHandle = ((buff != null) ? buff.Handle : 0);
				return;
			}
			this.Buff = null;
			this.BuffHandle = 0;
		}

		// Token: 0x0603EA77 RID: 256631 RVA: 0x01009AB4 File Offset: 0x01007CB4
		private void PlayWarnAnim(bool bPlay)
		{
			if (this.IsPlayWarnAnim == bPlay)
			{
				return;
			}
			this.IsPlayWarnAnim = bPlay;
			if (bPlay)
			{
				base.PlayTweenAnim(17);
				return;
			}
			base.StopTweenAnim(17);
			UUIItem item = base.GetItem(2);
			if (item == null)
			{
				return;
			}
			item.SetAlpha(1f);
		}

		// Token: 0x04023232 RID: 143922
		private const int EnhancedStateConfigId = 111002;

		// Token: 0x04023233 RID: 143923
		private const EAttributeType EnhancedEnergyAttrId = EAttributeType.SpecialEnergy2;

		// Token: 0x04023234 RID: 143924
		private const EAttributeType EnhancedEnergyMaxAttrId = EAttributeType.SpecialEnergy2Max;

		// Token: 0x04023235 RID: 143925
		[StaticVariableRuleIgnore]
		private static readonly int EnhancedStateTagId = GameplayTagDefine.EGameplayTagId["角色.R2T1SuisuiMd10011.形态.强化"];

		// Token: 0x04023236 RID: 143926
		[StaticVariableRuleIgnore]
		private static readonly int UltStateTagId = GameplayTagDefine.EGameplayTagId["角色.R2T1SuisuiMd10011.领域.领域生效中"];

		// Token: 0x04023237 RID: 143927
		[Nullable(2)]
		private SpecialEnergyBarInfo EnhancedStateConfig;

		// Token: 0x04023238 RID: 143928
		[Nullable(2)]
		private SpecialEnergyBarSlot BarItem;

		// Token: 0x04023239 RID: 143929
		[Nullable(2)]
		private SpecialEnergyBarSlot EnhancedStateBarItem;

		// Token: 0x0402323A RID: 143930
		private bool IsFull;

		// Token: 0x0402323B RID: 143931
		private bool IsInUltState;

		// Token: 0x0402323C RID: 143932
		private SpecialEnergyBarSuisui.EState CurState;

		// Token: 0x0402323D RID: 143933
		private SpecialEnergyBarSuisui.EEnhancedEnergyState CurEnhancedEnergyState;

		// Token: 0x0402323E RID: 143934
		[Nullable(2)]
		private IActiveBuff Buff;

		// Token: 0x0402323F RID: 143935
		private int BuffHandle;

		// Token: 0x04023240 RID: 143936
		private bool IsPlayWarnAnim;

		// Token: 0x0200C242 RID: 49730
		private enum EChildType
		{
			// Token: 0x0403BE08 RID: 245256
			PnlState01,
			// Token: 0x0403BE09 RID: 245257
			BarSlotState01,
			// Token: 0x0403BE0A RID: 245258
			PnlState02,
			// Token: 0x0403BE0B RID: 245259
			BarSlotState02,
			// Token: 0x0403BE0C RID: 245260
			AnimState01To02,
			// Token: 0x0403BE0D RID: 245261
			AnimState02To01,
			// Token: 0x0403BE0E RID: 245262
			AnimState01ToFull,
			// Token: 0x0403BE0F RID: 245263
			AnimState01ToNotFull,
			// Token: 0x0403BE10 RID: 245264
			AnimState2Zero,
			// Token: 0x0403BE11 RID: 245265
			AnimState2OneThird,
			// Token: 0x0403BE12 RID: 245266
			AnimState2TwoThird,
			// Token: 0x0403BE13 RID: 245267
			AnimState2Full,
			// Token: 0x0403BE14 RID: 245268
			AniState2ZeroToOneThird,
			// Token: 0x0403BE15 RID: 245269
			AniState2OneToTwoThird,
			// Token: 0x0403BE16 RID: 245270
			AniState2TwoThirdToFull,
			// Token: 0x0403BE17 RID: 245271
			AnimState02R,
			// Token: 0x0403BE18 RID: 245272
			AnimState02NotR,
			// Token: 0x0403BE19 RID: 245273
			AnimWarning
		}

		// Token: 0x0200C243 RID: 49731
		private enum EState
		{
			// Token: 0x0403BE1B RID: 245275
			Normal,
			// Token: 0x0403BE1C RID: 245276
			Enhanced
		}

		// Token: 0x0200C244 RID: 49732
		private enum EEnhancedEnergyState
		{
			// Token: 0x0403BE1E RID: 245278
			ZeroToOneThird,
			// Token: 0x0403BE1F RID: 245279
			OneThirdToTwoThird,
			// Token: 0x0403BE20 RID: 245280
			TwoThirdToFull,
			// Token: 0x0403BE21 RID: 245281
			Full
		}
	}
}
