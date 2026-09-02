using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x020060E3 RID: 24803
	public class SpecialEnergyBarSuizhe : SpecialEnergyBarBase
	{
		// Token: 0x0603EA7C RID: 256636 RVA: 0x01009B88 File Offset: 0x01007D88
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>();
			for (int i = 0; i < 4; i++)
			{
				this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(i, typeof(UUIItem)));
			}
		}

		// Token: 0x0603EA7D RID: 256637 RVA: 0x01009BC7 File Offset: 0x01007DC7
		protected override void AddEvents()
		{
			base.AddEvents();
			base.ListenForTagAddOrRemoveChanged(SpecialEnergyBarSuizhe.AdvanceStateTagId, new BaseTagComponent.TTagSwitchedCallback(this.OnStateChanged));
		}

		// Token: 0x0603EA7E RID: 256638 RVA: 0x01009BE8 File Offset: 0x01007DE8
		protected override UniTask OnBeforeStartAsync()
		{
			SpecialEnergyBarSuizhe.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<SpecialEnergyBarSuizhe.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603EA7F RID: 256639 RVA: 0x01009C2C File Offset: 0x01007E2C
		protected UniTask InitBarItem()
		{
			SpecialEnergyBarSuizhe.<InitBarItem>d__8 <InitBarItem>d__;
			<InitBarItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitBarItem>d__.<>4__this = this;
			<InitBarItem>d__.<>1__state = -1;
			<InitBarItem>d__.<>t__builder.Start<SpecialEnergyBarSuizhe.<InitBarItem>d__8>(ref <InitBarItem>d__);
			return <InitBarItem>d__.<>t__builder.Task;
		}

		// Token: 0x0603EA80 RID: 256640 RVA: 0x01009C70 File Offset: 0x01007E70
		protected override void OnStart()
		{
			BaseTagComponent tagComponent = this.TagComponent;
			SpecialEnergyBarSuizhe.EState state = (tagComponent != null && tagComponent.HasTag(SpecialEnergyBarSuizhe.AdvanceStateTagId)) ? SpecialEnergyBarSuizhe.EState.Advance : SpecialEnergyBarSuizhe.EState.Normal;
			this.SetState(state);
		}

		// Token: 0x0603EA81 RID: 256641 RVA: 0x01009CA2 File Offset: 0x01007EA2
		private void OnStateChanged(int tagId, bool tagExist)
		{
			this.SetState(tagExist ? SpecialEnergyBarSuizhe.EState.Advance : SpecialEnergyBarSuizhe.EState.Normal);
		}

		// Token: 0x0603EA82 RID: 256642 RVA: 0x01009CB1 File Offset: 0x01007EB1
		private void SetState(SpecialEnergyBarSuizhe.EState state)
		{
			base.GetItem(1).SetUIActive(state == SpecialEnergyBarSuizhe.EState.Advance);
			SpecialEnergyBarSlot barSlotA = this.BarSlotA;
			if (barSlotA != null)
			{
				barSlotA.SetUiActive(state == SpecialEnergyBarSuizhe.EState.Normal);
			}
			SpecialEnergyBarSlot barSlotB = this.BarSlotB;
			if (barSlotB == null)
			{
				return;
			}
			barSlotB.SetUiActive(state == SpecialEnergyBarSuizhe.EState.Advance);
		}

		// Token: 0x0603EA83 RID: 256643 RVA: 0x01009CEC File Offset: 0x01007EEC
		public override void Tick(float delta)
		{
			base.Tick(delta);
			SpecialEnergyBarSlot barSlotA = this.BarSlotA;
			if (barSlotA != null)
			{
				barSlotA.Tick(delta);
			}
			SpecialEnergyBarSlot barSlotB = this.BarSlotB;
			if (barSlotB == null)
			{
				return;
			}
			barSlotB.Tick(delta);
		}

		// Token: 0x04023241 RID: 143937
		[StaticVariableRuleIgnore]
		private static readonly int AdvanceStateTagId = GameplayTagDefine.EGameplayTagId["怪物.MB1SuiZheMd00501.状态.登神解放状态"];

		// Token: 0x04023242 RID: 143938
		[Nullable(2)]
		private SpecialEnergyBarSlot BarSlotA;

		// Token: 0x04023243 RID: 143939
		[Nullable(2)]
		private SpecialEnergyBarSlot BarSlotB;

		// Token: 0x0200C248 RID: 49736
		private enum EChildType
		{
			// Token: 0x0403BE2F RID: 245295
			BgNormal,
			// Token: 0x0403BE30 RID: 245296
			BgFull,
			// Token: 0x0403BE31 RID: 245297
			SlotBarItemA,
			// Token: 0x0403BE32 RID: 245298
			SlotBarItemB,
			// Token: 0x0403BE33 RID: 245299
			MaxCount
		}

		// Token: 0x0200C249 RID: 49737
		private enum EState
		{
			// Token: 0x0403BE35 RID: 245301
			Normal,
			// Token: 0x0403BE36 RID: 245302
			Advance
		}
	}
}
