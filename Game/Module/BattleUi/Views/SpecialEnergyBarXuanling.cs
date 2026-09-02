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
	// Token: 0x020060EB RID: 24811
	public class SpecialEnergyBarXuanling : SpecialEnergyBarBase
	{
		// Token: 0x0603EADE RID: 256734 RVA: 0x0100BA98 File Offset: 0x01009C98
		protected unsafe override void OnRegisterComponent()
		{
			int num = 12;
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
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603EADF RID: 256735 RVA: 0x0100BC50 File Offset: 0x01009E50
		protected override UniTask OnBeforeStartAsync()
		{
			SpecialEnergyBarXuanling.<OnBeforeStartAsync>d__12 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<SpecialEnergyBarXuanling.<OnBeforeStartAsync>d__12>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603EAE0 RID: 256736 RVA: 0x0100BC94 File Offset: 0x01009E94
		private UniTask InitBarItem()
		{
			SpecialEnergyBarXuanling.<InitBarItem>d__13 <InitBarItem>d__;
			<InitBarItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitBarItem>d__.<>4__this = this;
			<InitBarItem>d__.<>1__state = -1;
			<InitBarItem>d__.<>t__builder.Start<SpecialEnergyBarXuanling.<InitBarItem>d__13>(ref <InitBarItem>d__);
			return <InitBarItem>d__.<>t__builder.Task;
		}

		// Token: 0x0603EAE1 RID: 256737 RVA: 0x0100BCD8 File Offset: 0x01009ED8
		protected override void AddEvents()
		{
			base.AddEvents();
			base.ListenForTagAddOrRemoveChanged(SpecialEnergyBarXuanling.SoftSwordTagId, new BaseTagComponent.TTagSwitchedCallback(this.OnSoftSwordTagChanged));
			base.ListenForTagAddOrRemoveChanged(SpecialEnergyBarXuanling.EnergyEmptyTagId, new BaseTagComponent.TTagSwitchedCallback(this.OnEnergyEmptyTagChanged));
			base.ListenForAttributeChanged(EAttributeType.SpecialEnergy2, new Action<EAttributeType, float, float>(this.OnSpEnergyChanged));
		}

		// Token: 0x0603EAE2 RID: 256738 RVA: 0x0100BD2D File Offset: 0x01009F2D
		protected override void RemoveEvents()
		{
			base.RemoveEvents();
			base.RemoveListenAttributeChanged(EAttributeType.SpecialEnergy2, new Action<EAttributeType, float, float>(this.OnSpEnergyChanged));
		}

		// Token: 0x0603EAE3 RID: 256739 RVA: 0x0100BD4C File Offset: 0x01009F4C
		protected override void OnStart()
		{
			base.InitTweenAnim(2);
			base.InitTweenAnim(3);
			base.InitTweenAnim(4);
			base.InitTweenAnim(5);
			base.InitTweenAnim(6);
			base.InitTweenAnim(7);
			base.InitTweenAnim(8);
			base.InitTweenAnim(9);
			base.InitTweenAnim(10);
			base.InitTweenAnim(11);
			this.RefreshState(true);
			this.RefreshEmptyState(true);
			this.RefreshSpEnergyState(true);
		}

		// Token: 0x0603EAE4 RID: 256740 RVA: 0x0100BDB7 File Offset: 0x01009FB7
		private void OnSoftSwordTagChanged(int tagId, bool tagExist)
		{
			this.SetSwordState(tagExist ? SpecialEnergyBarXuanling.ESwordState.SoftSword : SpecialEnergyBarXuanling.ESwordState.HardSword, false);
		}

		// Token: 0x0603EAE5 RID: 256741 RVA: 0x0100BDC7 File Offset: 0x01009FC7
		private void OnEnergyEmptyTagChanged(int tagId, bool tagExist)
		{
			this.SetEmptyState(tagExist, false);
		}

		// Token: 0x0603EAE6 RID: 256742 RVA: 0x0100BDD1 File Offset: 0x01009FD1
		private void OnSpEnergyChanged(EAttributeType attributeId, float newValue, float oldValue)
		{
			this.SetSpEnergyState(this.CalcSpEnergyState(newValue), false);
		}

		// Token: 0x0603EAE7 RID: 256743 RVA: 0x0100BDE4 File Offset: 0x01009FE4
		private void RefreshState(bool isStart = false)
		{
			BaseTagComponent tagComponent = this.TagComponent;
			this.SetSwordState((tagComponent != null && tagComponent.HasTag(SpecialEnergyBarXuanling.SoftSwordTagId)) ? SpecialEnergyBarXuanling.ESwordState.SoftSword : SpecialEnergyBarXuanling.ESwordState.HardSword, isStart);
		}

		// Token: 0x0603EAE8 RID: 256744 RVA: 0x0100BE18 File Offset: 0x0100A018
		private void RefreshEmptyState(bool isStart = false)
		{
			BaseTagComponent tagComponent = this.TagComponent;
			bool isEmpty = tagComponent != null && tagComponent.HasTag(SpecialEnergyBarXuanling.EnergyEmptyTagId);
			this.SetEmptyState(isEmpty, isStart);
		}

		// Token: 0x0603EAE9 RID: 256745 RVA: 0x0100BE48 File Offset: 0x0100A048
		private void RefreshSpEnergyState(bool isStart = false)
		{
			BaseAttributeComponent attributeComponent = this.AttributeComponent;
			float spEnergy = (attributeComponent != null) ? attributeComponent.GetCurrentValue(EAttributeType.SpecialEnergy2) : 0f;
			this.SetSpEnergyState(this.CalcSpEnergyState(spEnergy), isStart);
		}

		// Token: 0x0603EAEA RID: 256746 RVA: 0x0100BE7C File Offset: 0x0100A07C
		private SpecialEnergyBarXuanling.ESpEnergyState CalcSpEnergyState(float spEnergy)
		{
			if (spEnergy <= 0f)
			{
				return SpecialEnergyBarXuanling.ESpEnergyState.Zero;
			}
			BaseAttributeComponent attributeComponent = this.AttributeComponent;
			float num = (attributeComponent != null) ? attributeComponent.GetCurrentValue(EAttributeType.SpecialEnergy2Max) : 0f;
			if (num > 0f && spEnergy >= num)
			{
				return SpecialEnergyBarXuanling.ESpEnergyState.Full;
			}
			return SpecialEnergyBarXuanling.ESpEnergyState.Half;
		}

		// Token: 0x0603EAEB RID: 256747 RVA: 0x0100BEBC File Offset: 0x0100A0BC
		private void SetSwordState(SpecialEnergyBarXuanling.ESwordState state, bool isStart = false)
		{
			if (this.CurSwordState == state && !isStart)
			{
				return;
			}
			this.CurSwordState = state;
			if (state == SpecialEnergyBarXuanling.ESwordState.SoftSword)
			{
				base.StopTweenAnim(8);
				base.PlayTweenAnim(4);
			}
			else
			{
				base.StopTweenAnim(4);
				base.PlayTweenAnim(8);
			}
			this.SetSpEnergyState(this.CurSpEnergyState, true);
		}

		// Token: 0x0603EAEC RID: 256748 RVA: 0x0100BF0C File Offset: 0x0100A10C
		private void SetEmptyState(bool isEmpty, bool isStart = false)
		{
			if (this.IsEmpty == isEmpty && !isStart)
			{
				return;
			}
			this.IsEmpty = isEmpty;
			if (isEmpty)
			{
				base.StopTweenAnim(3);
				base.PlayTweenAnim(2);
				return;
			}
			base.StopTweenAnim(2);
			base.PlayTweenAnim(3);
		}

		// Token: 0x0603EAED RID: 256749 RVA: 0x0100BF44 File Offset: 0x0100A144
		private void SetSpEnergyState(SpecialEnergyBarXuanling.ESpEnergyState state, bool isStart = false)
		{
			if (this.CurSpEnergyState == state && !isStart)
			{
				return;
			}
			this.CurSpEnergyState = state;
			SpecialEnergyBarXuanlingSlot barItem = this.BarItem;
			if (barItem != null)
			{
				barItem.SetKeyActionBySpEnergy(state == SpecialEnergyBarXuanling.ESpEnergyState.Full, isStart);
			}
			if (this.CurSwordState == SpecialEnergyBarXuanling.ESwordState.SoftSword)
			{
				switch (state)
				{
				case SpecialEnergyBarXuanling.ESpEnergyState.Zero:
					base.StopTweenAnim(6);
					base.StopTweenAnim(7);
					base.PlayTweenAnim(5);
					return;
				case SpecialEnergyBarXuanling.ESpEnergyState.Half:
					base.StopTweenAnim(5);
					base.StopTweenAnim(7);
					base.PlayTweenAnim(6);
					return;
				case SpecialEnergyBarXuanling.ESpEnergyState.Full:
					base.StopTweenAnim(5);
					base.StopTweenAnim(6);
					base.PlayTweenAnim(7);
					return;
				default:
					return;
				}
			}
			else
			{
				switch (state)
				{
				case SpecialEnergyBarXuanling.ESpEnergyState.Zero:
					base.StopTweenAnim(10);
					base.StopTweenAnim(11);
					base.PlayTweenAnim(9);
					return;
				case SpecialEnergyBarXuanling.ESpEnergyState.Half:
					base.StopTweenAnim(9);
					base.StopTweenAnim(11);
					base.PlayTweenAnim(10);
					return;
				case SpecialEnergyBarXuanling.ESpEnergyState.Full:
					base.StopTweenAnim(9);
					base.StopTweenAnim(10);
					base.PlayTweenAnim(11);
					return;
				default:
					return;
				}
			}
		}

		// Token: 0x0603EAEE RID: 256750 RVA: 0x0100C036 File Offset: 0x0100A236
		public override void Tick(float delta)
		{
			base.Tick(delta);
			SpecialEnergyBarXuanlingSlot barItem = this.BarItem;
			if (barItem == null)
			{
				return;
			}
			barItem.Tick(delta);
		}

		// Token: 0x04023271 RID: 143985
		[StaticVariableRuleIgnore]
		private static readonly int SoftSwordTagId = GameplayTagDefine.EGameplayTagId["角色.R2T1XuanlingMd10011.逻辑.副武器"];

		// Token: 0x04023272 RID: 143986
		[StaticVariableRuleIgnore]
		private static readonly int EnergyEmptyTagId = GameplayTagDefine.EGameplayTagId["角色.R2T1XuanlingMd10011.状态.满特殊能量1"];

		// Token: 0x04023273 RID: 143987
		private const EAttributeType SpEnergyAttrId = EAttributeType.SpecialEnergy2;

		// Token: 0x04023274 RID: 143988
		private const EAttributeType SpEnergyMaxAttrId = EAttributeType.SpecialEnergy2Max;

		// Token: 0x04023275 RID: 143989
		[Nullable(2)]
		private SpecialEnergyBarXuanlingSlot BarItem;

		// Token: 0x04023276 RID: 143990
		private bool IsEmpty;

		// Token: 0x04023277 RID: 143991
		private SpecialEnergyBarXuanling.ESwordState CurSwordState;

		// Token: 0x04023278 RID: 143992
		private SpecialEnergyBarXuanling.ESpEnergyState CurSpEnergyState;

		// Token: 0x0200C25F RID: 49759
		private enum EChildType
		{
			// Token: 0x0403BEB8 RID: 245432
			SlotBarItem,
			// Token: 0x0403BEB9 RID: 245433
			PnlWing,
			// Token: 0x0403BEBA RID: 245434
			EmptyStart,
			// Token: 0x0403BEBB RID: 245435
			EmptyClose,
			// Token: 0x0403BEBC RID: 245436
			LogicAnimSoft,
			// Token: 0x0403BEBD RID: 245437
			LogicAnimSoftSPZero,
			// Token: 0x0403BEBE RID: 245438
			LogicAnimSoftSPHalf,
			// Token: 0x0403BEBF RID: 245439
			LogicAnimSoftSPFull,
			// Token: 0x0403BEC0 RID: 245440
			LogicAnimHard,
			// Token: 0x0403BEC1 RID: 245441
			LogicAnimHardZero,
			// Token: 0x0403BEC2 RID: 245442
			LogicAnimHardHalf,
			// Token: 0x0403BEC3 RID: 245443
			LogicAnimHardFull
		}

		// Token: 0x0200C260 RID: 49760
		private enum ESwordState
		{
			// Token: 0x0403BEC5 RID: 245445
			HardSword,
			// Token: 0x0403BEC6 RID: 245446
			SoftSword
		}

		// Token: 0x0200C261 RID: 49761
		private enum ESpEnergyState
		{
			// Token: 0x0403BEC8 RID: 245448
			Zero,
			// Token: 0x0403BEC9 RID: 245449
			Half,
			// Token: 0x0403BECA RID: 245450
			Full
		}
	}
}
