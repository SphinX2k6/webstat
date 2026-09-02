using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02006021 RID: 24609
	public class HeadIconEnergyBarRuibeika : HeadIconEnergyBarBase
	{
		// Token: 0x0603E03D RID: 254013 RVA: 0x00FD3328 File Offset: 0x00FD1528
		protected unsafe override void OnRegisterComponent()
		{
			int num = 7;
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
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603E03E RID: 254014 RVA: 0x00FD3438 File Offset: 0x00FD1638
		protected override UniTask OnBeforeStartAsync()
		{
			HeadIconEnergyBarRuibeika.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<HeadIconEnergyBarRuibeika.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603E03F RID: 254015 RVA: 0x00FD347C File Offset: 0x00FD167C
		[NullableContext(1)]
		private void InitDotItems(List<SpecialEnergyBarRuibeikaDot> arr, int org, int parent)
		{
			UUIItem item = base.GetItem(org);
			UUIItem item2 = base.GetItem(parent);
			int num = this.Config.Value.Params(0);
			int num2 = (num != 0) ? num : 9;
			for (int i = 0; i < num2; i++)
			{
				AActor actor = (i == 0) ? item.GetOwner() : Singleton<LguiUtil>.Instance.DuplicateActor(item.GetOwner(), item2);
				SpecialEnergyBarRuibeikaDot specialEnergyBarRuibeikaDot = new SpecialEnergyBarRuibeikaDot(0);
				specialEnergyBarRuibeikaDot.SkipDestroyActor = true;
				specialEnergyBarRuibeikaDot.Index = i;
				specialEnergyBarRuibeikaDot.CreateByActorAsync(actor, null, false);
				arr.Add(specialEnergyBarRuibeikaDot);
			}
		}

		// Token: 0x0603E040 RID: 254016 RVA: 0x00FD3514 File Offset: 0x00FD1714
		protected override void OnStart()
		{
			base.OnStart();
			for (int i = 3; i <= 6; i++)
			{
				base.InitTweenAnim(i);
			}
			base.ListenForTagAddOrRemoveChanged(GameplayTagDefine.EGameplayTagId["角色.R2T1RebeccaMd10011.状态.手枪状态"], this.<OnStart>g__onStateChanged|8_0(HeadIconEnergyBarRuibeika.EState.StateGun));
			base.ListenForTagAddOrRemoveChanged(GameplayTagDefine.EGameplayTagId["角色.R2T1RebeccaMd10011.状态.铁胆状态"], this.<OnStart>g__onStateChanged|8_0(HeadIconEnergyBarRuibeika.EState.StateRifle));
			this.SetState(this.GetCurrentStateByTag(), true);
		}

		// Token: 0x0603E041 RID: 254017 RVA: 0x00FD357F File Offset: 0x00FD177F
		protected override void OnBeforeShow()
		{
			this.CurState = this.GetCurrentStateByTag();
			base.OnBeforeShow();
			this.RefreshBarPercent(true, true);
		}

		// Token: 0x0603E042 RID: 254018 RVA: 0x00FD359C File Offset: 0x00FD179C
		private HeadIconEnergyBarRuibeika.EState GetCurrentStateByTag()
		{
			BaseTagComponent tagComponent = this.TagComponent;
			if (!((tagComponent != null) ? new bool?(tagComponent.HasTag(GameplayTagDefine.EGameplayTagId["角色.R2T1RebeccaMd10011.状态.铁胆状态"])) : null).GetValueOrDefault())
			{
				return HeadIconEnergyBarRuibeika.EState.StateGun;
			}
			return HeadIconEnergyBarRuibeika.EState.StateRifle;
		}

		// Token: 0x0603E043 RID: 254019 RVA: 0x00FD35E4 File Offset: 0x00FD17E4
		private int GetCurrentColorAnim()
		{
			if (this.CurState != HeadIconEnergyBarRuibeika.EState.StateGun)
			{
				return 3;
			}
			return 4;
		}

		// Token: 0x0603E044 RID: 254020 RVA: 0x00FD35F4 File Offset: 0x00FD17F4
		private void PlayCurrentColorAnim()
		{
			int currentColorAnim = this.GetCurrentColorAnim();
			base.StopTweenAnim((currentColorAnim == 4) ? 3 : 4);
			base.PlayTweenAnim(currentColorAnim);
		}

		// Token: 0x0603E045 RID: 254021 RVA: 0x00FD361D File Offset: 0x00FD181D
		private void SetState(HeadIconEnergyBarRuibeika.EState state, bool force = false)
		{
			if (this.CurState == state && !force)
			{
				return;
			}
			this.CurState = state;
			this.RefreshBarPercent(true, true);
		}

		// Token: 0x0603E046 RID: 254022 RVA: 0x00FD363B File Offset: 0x00FD183B
		protected override void OnBarPercentChanged()
		{
			this.RefreshBarPercent(false, false);
		}

		// Token: 0x0603E047 RID: 254023 RVA: 0x00FD3648 File Offset: 0x00FD1848
		private void RefreshBarPercent(bool bForce = false, bool forceColor = false)
		{
			float curPercent = this.PercentMachine.GetCurPercent();
			bool flag = curPercent >= 1f;
			List<SpecialEnergyBarRuibeikaDot> c1DotItems = this.C1DotItems;
			float num = 0.5f / (float)c1DotItems.Count;
			double num2 = flag ? ((double)c1DotItems.Count) : Math.Floor((double)(curPercent * (float)c1DotItems.Count));
			for (int i = 0; i < c1DotItems.Count; i++)
			{
				bool b = (i == 0) ? (curPercent > num) : ((double)i < num2);
				c1DotItems[i].SetVisible(b, this.CurState == HeadIconEnergyBarRuibeika.EState.StateGun, bForce);
			}
			UUIItem item = base.GetItem(2);
			if (item != null)
			{
				item.SetUIActive(flag);
			}
			if (forceColor || (flag && !this.IsFull))
			{
				this.PlayCurrentColorAnim();
			}
			this.IsFull = flag;
		}

		// Token: 0x0603E04A RID: 254026 RVA: 0x00FD3729 File Offset: 0x00FD1929
		[NullableContext(1)]
		[CompilerGenerated]
		private BaseTagComponent.TTagSwitchedCallback <OnStart>g__onStateChanged|8_0(HeadIconEnergyBarRuibeika.EState state)
		{
			return delegate(int tagId, bool tagExist)
			{
				if (tagExist)
				{
					this.SetState(state, false);
				}
			};
		}

		// Token: 0x04022C67 RID: 142439
		private HeadIconEnergyBarRuibeika.EState CurState;

		// Token: 0x04022C68 RID: 142440
		private bool IsFull;

		// Token: 0x04022C69 RID: 142441
		[Nullable(1)]
		private readonly List<SpecialEnergyBarRuibeikaDot> C1DotItems = new List<SpecialEnergyBarRuibeikaDot>();

		// Token: 0x0200C0CD RID: 49357
		private enum EState
		{
			// Token: 0x0403B5C8 RID: 243144
			StateGun,
			// Token: 0x0403B5C9 RID: 243145
			StateRifle,
			// Token: 0x0403B5CA RID: 243146
			StateUlt
		}

		// Token: 0x0200C0CE RID: 49358
		private class EChildType
		{
			// Token: 0x0403B5CB RID: 243147
			public const int PnlBarC1 = 0;

			// Token: 0x0403B5CC RID: 243148
			public const int PnlItemC1 = 1;

			// Token: 0x0403B5CD RID: 243149
			public const int FullCtrl = 2;

			// Token: 0x0403B5CE RID: 243150
			public const int AniRed = 3;

			// Token: 0x0403B5CF RID: 243151
			public const int AniGreen = 4;

			// Token: 0x0403B5D0 RID: 243152
			public const int AniR2G = 5;

			// Token: 0x0403B5D1 RID: 243153
			public const int AniG2R = 6;
		}
	}
}
