using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x020060D2 RID: 24786
	public class SpecialEnergyBarLuosela : SpecialEnergyBarBase
	{
		// Token: 0x0603E997 RID: 256407 RVA: 0x01004940 File Offset: 0x01002B40
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>();
			for (int i = 0; i < 12; i++)
			{
				this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(i, typeof(UUIItem)));
			}
		}

		// Token: 0x0603E998 RID: 256408 RVA: 0x01004980 File Offset: 0x01002B80
		protected override UniTask OnBeforeStartAsync()
		{
			SpecialEnergyBarLuosela.<OnBeforeStartAsync>d__9 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<SpecialEnergyBarLuosela.<OnBeforeStartAsync>d__9>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603E999 RID: 256409 RVA: 0x010049C4 File Offset: 0x01002BC4
		private UniTask InitBarItem()
		{
			SpecialEnergyBarLuosela.<InitBarItem>d__10 <InitBarItem>d__;
			<InitBarItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitBarItem>d__.<>4__this = this;
			<InitBarItem>d__.<>1__state = -1;
			<InitBarItem>d__.<>t__builder.Start<SpecialEnergyBarLuosela.<InitBarItem>d__10>(ref <InitBarItem>d__);
			return <InitBarItem>d__.<>t__builder.Task;
		}

		// Token: 0x0603E99A RID: 256410 RVA: 0x01004A07 File Offset: 0x01002C07
		protected override void AddEvents()
		{
			base.AddEvents();
			base.ListenForTagAddOrRemoveChanged(GameplayTagDefine.EGameplayTagId["角色.R2T1LuoselaMd10011.状态.强化状态"], new BaseTagComponent.TTagSwitchedCallback(this.OnStateChanged));
		}

		// Token: 0x0603E99B RID: 256411 RVA: 0x01004A30 File Offset: 0x01002C30
		protected override void OnStart()
		{
			base.OnStart();
			this.ConfigList.Add(this.Config);
			this.ConfigList.Add(ModelBase<BattleUiModel>.Instance.SpecialEnergyBarData.GetSpecialEnergyBarInfo(110902));
			for (int i = 7; i <= 11; i++)
			{
				base.InitTweenAnim(i);
			}
			BaseTagComponent tagComponent = this.TagComponent;
			this.SetState((tagComponent != null && tagComponent.HasTag(GameplayTagDefine.EGameplayTagId["角色.R2T1LuoselaMd10011.状态.强化状态"])) ? SpecialEnergyBarLuosela.EState.StateB : SpecialEnergyBarLuosela.EState.StateA);
		}

		// Token: 0x0603E99C RID: 256412 RVA: 0x01004AB6 File Offset: 0x01002CB6
		private void OnStateChanged(int tagId, bool tagExist)
		{
			this.SetState(tagExist ? SpecialEnergyBarLuosela.EState.StateB : SpecialEnergyBarLuosela.EState.StateA);
		}

		// Token: 0x0603E99D RID: 256413 RVA: 0x01004AC8 File Offset: 0x01002CC8
		private void SetState(SpecialEnergyBarLuosela.EState state)
		{
			this.PointList.ForEach(delegate(SpecialEnergyBarLuoselaPoint logic)
			{
				logic.SetUlt(state == SpecialEnergyBarLuosela.EState.StateB);
			});
			if (state == SpecialEnergyBarLuosela.EState.StateA)
			{
				SpecialEnergyBarLuoselaSlot barSlot = this.BarSlot;
				if (barSlot != null)
				{
					barSlot.SwitchKeyItem(this.ConfigList[0]);
				}
			}
			else
			{
				SpecialEnergyBarLuoselaSlot barSlot2 = this.BarSlot;
				if (barSlot2 != null)
				{
					barSlot2.SwitchKeyItem(this.ConfigList[1]);
				}
			}
			SpecialEnergyBarLuoselaSlot barSlot3 = this.BarSlot;
			if (barSlot3 != null)
			{
				barSlot3.SetSlotUlt(state == SpecialEnergyBarLuosela.EState.StateB);
			}
			SpecialEnergyBarLuoselaSlot barSlot4 = this.BarSlot;
			if (barSlot4 != null)
			{
				barSlot4.SwitchPointColor(false);
			}
			this.CurState = state;
			this.OnBarPercentChanged();
		}

		// Token: 0x0603E99E RID: 256414 RVA: 0x01004B7C File Offset: 0x01002D7C
		protected override void OnBarPercentChanged()
		{
			int num = 0;
			if (this.CurState == SpecialEnergyBarLuosela.EState.StateA)
			{
				if (this.PercentMachine.GetCurPercent() >= 1f)
				{
					num = 1;
				}
			}
			else
			{
				num = 2;
			}
			for (int i = 0; i < this.BgItems.Count; i++)
			{
				this.BgItems[i].SetUIActive(num == i);
			}
			int num2 = -1;
			if (this.PercentMachine.GetCurPercent() >= 1f)
			{
				num2 = 2;
			}
			else if (this.PercentMachine.GetCurPercent() > 0.66f)
			{
				num2 = 1;
			}
			else if (this.PercentMachine.GetCurPercent() > 0.33f)
			{
				num2 = 0;
			}
			for (int j = 0; j < this.PointList.Count; j++)
			{
				this.PointList[j].SetVisible(j <= num2);
			}
			SpecialEnergyBarLuoselaSlot barSlot = this.BarSlot;
			if (barSlot != null)
			{
				barSlot.SetSlotPoint(num2);
			}
			int num3 = Math.Max(num2, 0);
			if (Math.Abs(this.LastPoint - num3) > 1)
			{
				base.PlayTweenAnim(11);
			}
			else if (this.LastPoint < num2)
			{
				base.PlayTweenAnim(num3 + 7);
			}
			else if (this.LastPoint > num2)
			{
				if (num2 == -1)
				{
					base.PlayTweenAnim(10);
				}
				else
				{
					base.PlayTweenAnim(num3 + 7);
				}
			}
			this.LastPoint = num2;
		}

		// Token: 0x0603E99F RID: 256415 RVA: 0x01004CBB File Offset: 0x01002EBB
		public override void Tick(float delta)
		{
			base.Tick(delta);
			SpecialEnergyBarLuoselaSlot barSlot = this.BarSlot;
			if (barSlot == null)
			{
				return;
			}
			barSlot.Tick(delta);
		}

		// Token: 0x0603E9A0 RID: 256416 RVA: 0x01004CD5 File Offset: 0x01002ED5
		protected override void OnBeforeDestroy()
		{
			this.BgItems.Clear();
			this.PointList.Clear();
			this.ConfigList.Clear();
			base.OnBeforeDestroy();
		}

		// Token: 0x040231A0 RID: 143776
		private const int BTN_CONFIG = 110902;

		// Token: 0x040231A1 RID: 143777
		[Nullable(2)]
		private SpecialEnergyBarLuoselaSlot BarSlot;

		// Token: 0x040231A2 RID: 143778
		[Nullable(1)]
		private readonly List<UUIItem> BgItems = new List<UUIItem>();

		// Token: 0x040231A3 RID: 143779
		[Nullable(1)]
		private readonly List<SpecialEnergyBarLuoselaPoint> PointList = new List<SpecialEnergyBarLuoselaPoint>();

		// Token: 0x040231A4 RID: 143780
		[Nullable(1)]
		private readonly List<SpecialEnergyBarInfo> ConfigList = new List<SpecialEnergyBarInfo>();

		// Token: 0x040231A5 RID: 143781
		private SpecialEnergyBarLuosela.EState CurState;

		// Token: 0x040231A6 RID: 143782
		private int LastPoint;

		// Token: 0x0200C219 RID: 49689
		private class EChildType
		{
			// Token: 0x0403BCFB RID: 244987
			public const int SlotItem = 0;

			// Token: 0x0403BCFC RID: 244988
			public const int PnlNor = 1;

			// Token: 0x0403BCFD RID: 244989
			public const int PnlFull = 2;

			// Token: 0x0403BCFE RID: 244990
			public const int PnlUltimate = 3;

			// Token: 0x0403BCFF RID: 244991
			public const int Photo1 = 4;

			// Token: 0x0403BD00 RID: 244992
			public const int Photo2 = 5;

			// Token: 0x0403BD01 RID: 244993
			public const int Photo3 = 6;

			// Token: 0x0403BD02 RID: 244994
			public const int AniState1 = 7;

			// Token: 0x0403BD03 RID: 244995
			public const int AniState2 = 8;

			// Token: 0x0403BD04 RID: 244996
			public const int AniState3 = 9;

			// Token: 0x0403BD05 RID: 244997
			public const int AniState0 = 10;

			// Token: 0x0403BD06 RID: 244998
			public const int AniDefault = 11;

			// Token: 0x0403BD07 RID: 244999
			public const int MaxCount = 12;
		}

		// Token: 0x0200C21A RID: 49690
		private enum EState
		{
			// Token: 0x0403BD09 RID: 245001
			StateA,
			// Token: 0x0403BD0A RID: 245002
			StateB
		}
	}
}
