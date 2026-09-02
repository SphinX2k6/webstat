using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x020060CC RID: 24780
	public class SpecialEnergyBarLuhes : SpecialEnergyBarBase
	{
		// Token: 0x0603E968 RID: 256360 RVA: 0x01003BF0 File Offset: 0x01001DF0
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>();
			for (int i = 0; i < 9; i++)
			{
				this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(i, typeof(UUIItem)));
			}
		}

		// Token: 0x0603E969 RID: 256361 RVA: 0x01003C30 File Offset: 0x01001E30
		protected override void OnInitData()
		{
			base.OnInitData();
			this.ConfigList.Add(this.Config);
			this.ConfigList.Add(ModelBase<BattleUiModel>.Instance.SpecialEnergyBarData.GetSpecialEnergyBarInfo(151002));
		}

		// Token: 0x0603E96A RID: 256362 RVA: 0x01003C68 File Offset: 0x01001E68
		protected override void AddEvents()
		{
			base.AddEvents();
			base.ListenForTagAddOrRemoveChanged(GameplayTagDefine.EGameplayTagId["角色.R2T1LuhesiMd10011.状态.超级强化状态"], new BaseTagComponent.TTagSwitchedCallback(this.OnStateChanged));
			base.ListenForTagCountChanged(GameplayTagDefine.EGameplayTagId["角色.R2T1LuhesiMd10011.技能.强化E使用次数"], new BaseTagComponent.TTagChangedCallback(this.OnAdvanceCountChanged));
		}

		// Token: 0x0603E96B RID: 256363 RVA: 0x01003CC0 File Offset: 0x01001EC0
		protected override UniTask OnBeforeStartAsync()
		{
			SpecialEnergyBarLuhes.<OnBeforeStartAsync>d__10 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<SpecialEnergyBarLuhes.<OnBeforeStartAsync>d__10>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603E96C RID: 256364 RVA: 0x01003D04 File Offset: 0x01001F04
		protected UniTask InitBarItem()
		{
			SpecialEnergyBarLuhes.<InitBarItem>d__11 <InitBarItem>d__;
			<InitBarItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitBarItem>d__.<>4__this = this;
			<InitBarItem>d__.<>1__state = -1;
			<InitBarItem>d__.<>t__builder.Start<SpecialEnergyBarLuhes.<InitBarItem>d__11>(ref <InitBarItem>d__);
			return <InitBarItem>d__.<>t__builder.Task;
		}

		// Token: 0x0603E96D RID: 256365 RVA: 0x01003D47 File Offset: 0x01001F47
		protected override void OnStart()
		{
			base.InitTweenAnim(5);
			base.InitTweenAnim(6);
			base.InitTweenAnim(7);
			base.InitTweenAnim(8);
		}

		// Token: 0x0603E96E RID: 256366 RVA: 0x01003D65 File Offset: 0x01001F65
		protected override void OnBeforeShow()
		{
			this.EnteredC = false;
			this.RefreshState();
			BaseTagComponent tagComponent = this.TagComponent;
			this.UpdatePoint((tagComponent != null) ? tagComponent.GetTagCount(GameplayTagDefine.EGameplayTagId["角色.R2T1LuhesiMd10011.技能.强化E使用次数"]) : 0, true);
		}

		// Token: 0x0603E96F RID: 256367 RVA: 0x01003D9C File Offset: 0x01001F9C
		protected override void ClearAllTweenAnim()
		{
			BattleUiTweenAnimPlayer tweenAnimPlayer = this.TweenAnimPlayer;
			if (tweenAnimPlayer != null)
			{
				tweenAnimPlayer.Clear(true);
			}
			base.ClearAllTweenAnim();
		}

		// Token: 0x0603E970 RID: 256368 RVA: 0x01003DB6 File Offset: 0x01001FB6
		private void OnStateChanged(int tagId, bool tagExist)
		{
			this.RefreshState();
		}

		// Token: 0x0603E971 RID: 256369 RVA: 0x01003DBE File Offset: 0x01001FBE
		private void OnAdvanceCountChanged(int count, int tagId, int exactTagId, int oldCount)
		{
			this.UpdatePoint(count, false);
		}

		// Token: 0x0603E972 RID: 256370 RVA: 0x01003DC8 File Offset: 0x01001FC8
		private void SwitchKeyItem()
		{
			SpecialEnergyBarLuhesSlot barSlot = this.BarSlot;
			if (barSlot != null)
			{
				barSlot.SwitchKeyItem((this.CurState == SpecialEnergyBarLuhes.EState.Normal) ? this.ConfigList[0] : this.ConfigList[1]);
			}
			SpecialEnergyBarLuhesSlot barSlot2 = this.BarSlot;
			if (barSlot2 == null)
			{
				return;
			}
			barSlot2.SetBarState(this.CurState == SpecialEnergyBarLuhes.EState.Advance);
		}

		// Token: 0x0603E973 RID: 256371 RVA: 0x01003E21 File Offset: 0x01002021
		private void RefreshState()
		{
			this.CurState = (this.TagComponent.HasTag(GameplayTagDefine.EGameplayTagId["角色.R2T1LuhesiMd10011.状态.超级强化状态"]) ? SpecialEnergyBarLuhes.EState.Advance : SpecialEnergyBarLuhes.EState.Normal);
			this.SwitchKeyItem();
		}

		// Token: 0x0603E974 RID: 256372 RVA: 0x01003E50 File Offset: 0x01002050
		private void UpdatePoint(int point, bool isStart = false)
		{
			if (point == 0)
			{
				this.EnteredC = false;
				BattleUiTweenAnimPlayer tweenAnimPlayer = this.TweenAnimPlayer;
				if (tweenAnimPlayer == null)
				{
					return;
				}
				tweenAnimPlayer.PlayTweenAnim(isStart ? 5 : 6);
				return;
			}
			else
			{
				if (point != 1)
				{
					if (!this.EnteredC)
					{
						this.EnteredC = true;
						BattleUiTweenAnimPlayer tweenAnimPlayer2 = this.TweenAnimPlayer;
						if (tweenAnimPlayer2 == null)
						{
							return;
						}
						tweenAnimPlayer2.PlayTweenAnim(8);
					}
					return;
				}
				this.EnteredC = false;
				BattleUiTweenAnimPlayer tweenAnimPlayer3 = this.TweenAnimPlayer;
				if (tweenAnimPlayer3 == null)
				{
					return;
				}
				tweenAnimPlayer3.PlayTweenAnim(7);
				return;
			}
		}

		// Token: 0x0603E975 RID: 256373 RVA: 0x01003EBC File Offset: 0x010020BC
		public override void Tick(float delta)
		{
			base.Tick(delta);
			SpecialEnergyBarLuhesSlot barSlot = this.BarSlot;
			if (barSlot == null)
			{
				return;
			}
			barSlot.Tick(delta);
		}

		// Token: 0x04023189 RID: 143753
		private const int ADV_BAR_ID = 151002;

		// Token: 0x0402318A RID: 143754
		[Nullable(2)]
		private SpecialEnergyBarLuhesSlot BarSlot;

		// Token: 0x0402318B RID: 143755
		private SpecialEnergyBarLuhes.EState CurState;

		// Token: 0x0402318C RID: 143756
		[Nullable(1)]
		private readonly List<SpecialEnergyBarInfo> ConfigList = new List<SpecialEnergyBarInfo>();

		// Token: 0x0402318D RID: 143757
		private bool EnteredC;

		// Token: 0x0200C20F RID: 49679
		private enum EState
		{
			// Token: 0x0403BCC9 RID: 244937
			Normal,
			// Token: 0x0403BCCA RID: 244938
			Advance
		}

		// Token: 0x0200C210 RID: 49680
		private enum EChildType
		{
			// Token: 0x0403BCCC RID: 244940
			SlotBarItem,
			// Token: 0x0403BCCD RID: 244941
			PnlState1,
			// Token: 0x0403BCCE RID: 244942
			PnlState2,
			// Token: 0x0403BCCF RID: 244943
			PnlState3,
			// Token: 0x0403BCD0 RID: 244944
			Point1,
			// Token: 0x0403BCD1 RID: 244945
			AniDefA,
			// Token: 0x0403BCD2 RID: 244946
			AniC2A,
			// Token: 0x0403BCD3 RID: 244947
			AniA2B,
			// Token: 0x0403BCD4 RID: 244948
			AniB2C,
			// Token: 0x0403BCD5 RID: 244949
			MaxCount
		}
	}
}
