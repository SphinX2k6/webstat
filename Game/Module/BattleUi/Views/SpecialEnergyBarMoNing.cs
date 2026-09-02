using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x020060D7 RID: 24791
	public class SpecialEnergyBarMoNing : SpecialEnergyBarBase
	{
		// Token: 0x0603E9CC RID: 256460 RVA: 0x01005E64 File Offset: 0x01004064
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>();
			for (int i = 0; i < 12; i++)
			{
				this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(i, typeof(UUIItem)));
			}
		}

		// Token: 0x0603E9CD RID: 256461 RVA: 0x01005EA4 File Offset: 0x010040A4
		protected override void AddEvents()
		{
			base.AddEvents();
			base.ListenForTagAddOrRemoveChanged(GameplayTagDefine.EGameplayTagId["角色.R2T1MoneMd10011.状态标识.清扫模式"], new BaseTagComponent.TTagSwitchedCallback(this.OnTagChanged));
		}

		// Token: 0x0603E9CE RID: 256462 RVA: 0x01005ECD File Offset: 0x010040CD
		private void OnTagChanged(int tagId, bool tagExist)
		{
			this.SetState(tagExist ? SpecialEnergyBarMoNing.EState.Blue : SpecialEnergyBarMoNing.EState.Red, false);
		}

		// Token: 0x0603E9CF RID: 256463 RVA: 0x01005EE0 File Offset: 0x010040E0
		protected override UniTask OnBeforeStartAsync()
		{
			SpecialEnergyBarMoNing.<OnBeforeStartAsync>d__10 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<SpecialEnergyBarMoNing.<OnBeforeStartAsync>d__10>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603E9D0 RID: 256464 RVA: 0x01005F24 File Offset: 0x01004124
		protected UniTask InitBarItem1()
		{
			SpecialEnergyBarMoNing.<InitBarItem1>d__11 <InitBarItem1>d__;
			<InitBarItem1>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitBarItem1>d__.<>4__this = this;
			<InitBarItem1>d__.<>1__state = -1;
			<InitBarItem1>d__.<>t__builder.Start<SpecialEnergyBarMoNing.<InitBarItem1>d__11>(ref <InitBarItem1>d__);
			return <InitBarItem1>d__.<>t__builder.Task;
		}

		// Token: 0x0603E9D1 RID: 256465 RVA: 0x01005F68 File Offset: 0x01004168
		protected UniTask InitBarItem2()
		{
			SpecialEnergyBarMoNing.<InitBarItem2>d__12 <InitBarItem2>d__;
			<InitBarItem2>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitBarItem2>d__.<>4__this = this;
			<InitBarItem2>d__.<>1__state = -1;
			<InitBarItem2>d__.<>t__builder.Start<SpecialEnergyBarMoNing.<InitBarItem2>d__12>(ref <InitBarItem2>d__);
			return <InitBarItem2>d__.<>t__builder.Task;
		}

		// Token: 0x0603E9D2 RID: 256466 RVA: 0x01005FAB File Offset: 0x010041AB
		protected override void OnStart()
		{
			base.InitTweenAnim(5);
			base.InitTweenAnim(8);
			base.InitTweenAnim(10);
			base.InitTweenAnim(9);
			base.InitTweenAnim(6);
			base.InitTweenAnim(7);
			this.RefreshState(true);
			this.OnBarPercentChanged();
		}

		// Token: 0x0603E9D3 RID: 256467 RVA: 0x01005FE6 File Offset: 0x010041E6
		protected override void ClearAllTweenAnim()
		{
			BattleUiTweenAnimPlayer tweenAnimPlayer = this.TweenAnimPlayer;
			if (tweenAnimPlayer != null)
			{
				tweenAnimPlayer.Clear(true);
			}
			base.ClearAllTweenAnim();
		}

		// Token: 0x0603E9D4 RID: 256468 RVA: 0x01006000 File Offset: 0x01004200
		protected override void OnBarPercentChanged()
		{
			float curPercent = this.PercentMachine.GetCurPercent();
			bool flag = this.LastPercent >= 1f && curPercent < 1f;
			bool flag2 = this.LastPercent < 1f && curPercent >= 1f;
			int num = 0;
			if ((double)curPercent <= 1E-08)
			{
				num = -1;
			}
			else if ((double)curPercent >= 0.99999999)
			{
				num = 1;
			}
			if (this.CurState == SpecialEnergyBarMoNing.EState.Blue)
			{
				if (flag)
				{
					base.PlayTweenAnim(8);
				}
				else if (flag2)
				{
					base.PlayTweenAnim(7);
				}
			}
			else
			{
				if (num != 1)
				{
					base.GetItem(3).SetUIActive(true);
				}
				base.GetItem(4).SetUIActive(num == 1);
				if (flag2)
				{
					base.PlayTweenAnim(5);
				}
			}
			this.LastPercent = curPercent;
		}

		// Token: 0x0603E9D5 RID: 256469 RVA: 0x010060C3 File Offset: 0x010042C3
		private void RefreshState(bool isStart = false)
		{
			BaseTagComponent tagComponent = this.TagComponent;
			if (tagComponent != null && tagComponent.HasTag(GameplayTagDefine.EGameplayTagId["角色.R2T1MoneMd10011.状态标识.清扫模式"]))
			{
				this.SetState(SpecialEnergyBarMoNing.EState.Blue, isStart);
				return;
			}
			this.SetState(SpecialEnergyBarMoNing.EState.Red, isStart);
		}

		// Token: 0x0603E9D6 RID: 256470 RVA: 0x010060FC File Offset: 0x010042FC
		private void SetState(SpecialEnergyBarMoNing.EState state, bool isStart = false)
		{
			if (state == this.CurState && !isStart)
			{
				return;
			}
			this.CurState = state;
			this.LastPercent = -1f;
			SpecialEnergyBarMoNing.EState curState = this.CurState;
			if (curState != SpecialEnergyBarMoNing.EState.Red)
			{
				if (curState == SpecialEnergyBarMoNing.EState.Blue)
				{
					UUIItem item = base.GetItem(1);
					if (item != null)
					{
						item.SetUIActive(true);
					}
					UUIItem item2 = base.GetItem(2);
					if (item2 != null)
					{
						item2.SetUIActive(false);
					}
					base.PlayTweenAnim(6);
				}
			}
			else
			{
				UUIItem item3 = base.GetItem(1);
				if (item3 != null)
				{
					item3.SetUIActive(false);
				}
				UUIItem item4 = base.GetItem(2);
				if (item4 != null)
				{
					item4.SetUIActive(true);
				}
				base.PlayTweenAnim(9);
			}
			base.GetItem(0).SetUIActive(state == SpecialEnergyBarMoNing.EState.Red);
			base.GetItem(11).SetUIActive(state == SpecialEnergyBarMoNing.EState.Blue);
		}

		// Token: 0x0603E9D7 RID: 256471 RVA: 0x010061B6 File Offset: 0x010043B6
		public override void Tick(float delta)
		{
			base.Tick(delta);
			SpecialEnergyBarMoNingSlot barSlotRed = this.BarSlotRed;
			if (barSlotRed != null)
			{
				barSlotRed.Tick(delta);
			}
			SpecialEnergyBarMoNingSlot barSlotBlue = this.BarSlotBlue;
			if (barSlotBlue == null)
			{
				return;
			}
			barSlotBlue.Tick(delta);
		}

		// Token: 0x040231C7 RID: 143815
		private const int DOMAIN_CONFIG = 120901;

		// Token: 0x040231C8 RID: 143816
		[Nullable(2)]
		private SpecialEnergyBarMoNingSlot BarSlotRed;

		// Token: 0x040231C9 RID: 143817
		[Nullable(2)]
		private SpecialEnergyBarMoNingSlot BarSlotBlue;

		// Token: 0x040231CA RID: 143818
		private SpecialEnergyBarMoNing.EState CurState;

		// Token: 0x040231CB RID: 143819
		private float LastPercent = -1f;

		// Token: 0x0200C225 RID: 49701
		private enum EState
		{
			// Token: 0x0403BD46 RID: 245062
			Red,
			// Token: 0x0403BD47 RID: 245063
			Blue
		}

		// Token: 0x0200C226 RID: 49702
		private enum EChildType
		{
			// Token: 0x0403BD49 RID: 245065
			SlotBarItem1,
			// Token: 0x0403BD4A RID: 245066
			PnlBlue,
			// Token: 0x0403BD4B RID: 245067
			PnlRed,
			// Token: 0x0403BD4C RID: 245068
			PnlRedBg,
			// Token: 0x0403BD4D RID: 245069
			PnlRedFullBg,
			// Token: 0x0403BD4E RID: 245070
			AnimRedFull,
			// Token: 0x0403BD4F RID: 245071
			AnimBlueDefault,
			// Token: 0x0403BD50 RID: 245072
			AnimBlueFull,
			// Token: 0x0403BD51 RID: 245073
			AnimBlueEmpty,
			// Token: 0x0403BD52 RID: 245074
			AnimBlueToRed,
			// Token: 0x0403BD53 RID: 245075
			AnimBlueToRedFull,
			// Token: 0x0403BD54 RID: 245076
			SlotBarItem2,
			// Token: 0x0403BD55 RID: 245077
			MaxCount
		}
	}
}
