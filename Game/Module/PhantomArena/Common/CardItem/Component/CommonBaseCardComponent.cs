using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.PhantomArena.Common.CardItem.Item;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Common.CardItem.Component
{
	// Token: 0x02005559 RID: 21849
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class CommonBaseCardComponent : CardComponentBase<ICommonBaseCardComponentData>, ICommonBaseCardComponent
	{
		// Token: 0x06037AD0 RID: 228048 RVA: 0x00E1ED94 File Offset: 0x00E1CF94
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIText)),
				new ValueTuple<int, Type>(4, typeof(UUIText)),
				new ValueTuple<int, Type>(6, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIItem)),
				new ValueTuple<int, Type>(15, typeof(UUIItem)),
				new ValueTuple<int, Type>(7, typeof(UUIItem)),
				new ValueTuple<int, Type>(8, typeof(UUITexture)),
				new ValueTuple<int, Type>(9, typeof(UUIItem)),
				new ValueTuple<int, Type>(10, typeof(UUIItem)),
				new ValueTuple<int, Type>(11, typeof(UUIItem)),
				new ValueTuple<int, Type>(12, typeof(UUIItem)),
				new ValueTuple<int, Type>(13, typeof(UUIItem)),
				new ValueTuple<int, Type>(14, typeof(UUIItem))
			};
		}

		// Token: 0x06037AD1 RID: 228049 RVA: 0x00E1EF14 File Offset: 0x00E1D114
		protected override UniTask OnBeforeStartAsync()
		{
			CommonBaseCardComponent.<OnBeforeStartAsync>d__3 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<CommonBaseCardComponent.<OnBeforeStartAsync>d__3>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06037AD2 RID: 228050 RVA: 0x00E1EF58 File Offset: 0x00E1D158
		protected override void OnStart()
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			extendToggle.OnStateChange.Add(new Action<EToggleState>(this.OnToggleStateChanged));
			extendToggle.CanExecuteChange.Bind(new Func<bool>(this.CanToggleExecuteChange));
			extendToggle.OnPointUpCallBack.Bind(new Action<EToggleState>(this.OnPointerUp));
			base.GetTexture(8).SetUIActive(false);
			base.GetItem(6).SetUIActive(false);
			base.GetItem(5).SetUIActive(false);
			base.GetItem(15).SetUIActive(false);
			base.GetItem(14).SetUIActive(false);
		}

		// Token: 0x06037AD3 RID: 228051 RVA: 0x00E1EFF4 File Offset: 0x00E1D1F4
		public override void Refresh(ICommonBaseCardComponentData data)
		{
			CommonBaseCardComponent.<>c__DisplayClass5_0 CS$<>8__locals1 = new CommonBaseCardComponent.<>c__DisplayClass5_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.data = data;
			new UiAsyncTask("Refresh", delegate()
			{
				CommonBaseCardComponent.<>c__DisplayClass5_0.<<Refresh>b__0>d <<Refresh>b__0>d;
				<<Refresh>b__0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
				<<Refresh>b__0>d.<>4__this = CS$<>8__locals1;
				<<Refresh>b__0>d.<>1__state = -1;
				<<Refresh>b__0>d.<>t__builder.Start<CommonBaseCardComponent.<>c__DisplayClass5_0.<<Refresh>b__0>d>(ref <<Refresh>b__0>d);
				return <<Refresh>b__0>d.<>t__builder.Task;
			}, null).Run();
		}

		// Token: 0x06037AD4 RID: 228052 RVA: 0x00E1F034 File Offset: 0x00E1D234
		public UniTask RefreshAsync(ICommonBaseCardComponentData data)
		{
			CommonBaseCardComponent.<RefreshAsync>d__6 <RefreshAsync>d__;
			<RefreshAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshAsync>d__.<>4__this = this;
			<RefreshAsync>d__.data = data;
			<RefreshAsync>d__.<>1__state = -1;
			<RefreshAsync>d__.<>t__builder.Start<CommonBaseCardComponent.<RefreshAsync>d__6>(ref <RefreshAsync>d__);
			return <RefreshAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06037AD5 RID: 228053 RVA: 0x00E1F080 File Offset: 0x00E1D280
		public void RefreshAttack()
		{
			base.GetText(1).SetText(this.Data.Attack.ToString(), true);
		}

		// Token: 0x06037AD6 RID: 228054 RVA: 0x00E1F0B0 File Offset: 0x00E1D2B0
		public void RefreshLife()
		{
			base.GetText(3).SetText(this.Data.Life.ToString(), true);
		}

		// Token: 0x06037AD7 RID: 228055 RVA: 0x00E1F0E0 File Offset: 0x00E1D2E0
		public void RefreshCost()
		{
			base.GetText(4).SetText(this.Data.Cost.ToString(), true);
		}

		// Token: 0x06037AD8 RID: 228056 RVA: 0x00E1F10D File Offset: 0x00E1D30D
		public void RefreshElementIcon()
		{
			this.ElementItem.Refresh((ECardElement)this.Data.Element, false, 0);
		}

		// Token: 0x06037AD9 RID: 228057 RVA: 0x00E1F128 File Offset: 0x00E1D328
		public void RefreshElementFrame()
		{
			base.GetItem(9).SetUIActive(this.Data.Element != 0 && !this.Data.OutlookUnlocked);
			base.GetItem(11).SetUIActive(this.Data.Element != 0 && this.Data.OutlookUnlocked);
		}

		// Token: 0x06037ADA RID: 228058 RVA: 0x00E1F188 File Offset: 0x00E1D388
		public void RefreshCardFace()
		{
			new UiAsyncTask("Refresh", delegate()
			{
				CommonBaseCardComponent.<<RefreshCardFace>b__12_0>d <<RefreshCardFace>b__12_0>d;
				<<RefreshCardFace>b__12_0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
				<<RefreshCardFace>b__12_0>d.<>4__this = this;
				<<RefreshCardFace>b__12_0>d.<>1__state = -1;
				<<RefreshCardFace>b__12_0>d.<>t__builder.Start<CommonBaseCardComponent.<<RefreshCardFace>b__12_0>d>(ref <<RefreshCardFace>b__12_0>d);
				return <<RefreshCardFace>b__12_0>d.<>t__builder.Task;
			}, null).Run();
		}

		// Token: 0x06037ADB RID: 228059 RVA: 0x00E1F1A8 File Offset: 0x00E1D3A8
		public UniTask RefreshCardFaceAsync()
		{
			CommonBaseCardComponent.<RefreshCardFaceAsync>d__13 <RefreshCardFaceAsync>d__;
			<RefreshCardFaceAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshCardFaceAsync>d__.<>4__this = this;
			<RefreshCardFaceAsync>d__.<>1__state = -1;
			<RefreshCardFaceAsync>d__.<>t__builder.Start<CommonBaseCardComponent.<RefreshCardFaceAsync>d__13>(ref <RefreshCardFaceAsync>d__);
			return <RefreshCardFaceAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06037ADC RID: 228060 RVA: 0x00E1F1EC File Offset: 0x00E1D3EC
		public void RefreshToggleState()
		{
			base.GetExtendToggle(0).SetToggleState(this.Data.ToggleState.GetValueOrDefault(), false, false, false);
		}

		// Token: 0x06037ADD RID: 228061 RVA: 0x00E1F21C File Offset: 0x00E1D41C
		public void RefreshCardFrame()
		{
			base.GetItem(10).SetUIActive(!this.Data.OutlookUnlocked);
			base.GetItem(12).SetUIActive(this.Data.OutlookUnlocked);
		}

		// Token: 0x06037ADE RID: 228062 RVA: 0x00E1F254 File Offset: 0x00E1D454
		public void RefreshLightItem()
		{
			int phantomArenaCardCoreCost = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomArenaCardCoreCost();
			PhantomBattleCard phantomBattleCardConfig = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleCardConfig(this.Data.CardId);
			int num = (phantomBattleCardConfig.Cost == phantomArenaCardCoreCost) ? 0 : phantomBattleCardConfig.Cost;
			UUIItem item = base.GetItem(14);
			if (item != null)
			{
				item.SetUIActive(num != 0);
			}
			UUIItem item2 = base.GetItem(5);
			if (item2 != null)
			{
				item2.SetUIActive(num >= 1);
			}
			UUIItem item3 = base.GetItem(6);
			if (item3 != null)
			{
				item3.SetUIActive(num >= 3);
			}
			UUIItem item4 = base.GetItem(15);
			if (item4 == null)
			{
				return;
			}
			item4.SetUIActive(num >= 3);
		}

		// Token: 0x06037ADF RID: 228063 RVA: 0x00E1F2FB File Offset: 0x00E1D4FB
		private void OnPointerUp(EToggleState _)
		{
			ICommonBaseCardComponentData data = this.Data;
			if (data == null)
			{
				return;
			}
			Action onPointerUp = data.OnPointerUp;
			if (onPointerUp == null)
			{
				return;
			}
			onPointerUp();
		}

		// Token: 0x06037AE0 RID: 228064 RVA: 0x00E1F317 File Offset: 0x00E1D517
		private void OnToggleStateChanged(EToggleState state)
		{
			ICommonBaseCardComponentData data = this.Data;
			if (data == null)
			{
				return;
			}
			Action<EToggleState> onToggleStateChanged = data.OnToggleStateChanged;
			if (onToggleStateChanged == null)
			{
				return;
			}
			onToggleStateChanged(state);
		}

		// Token: 0x06037AE1 RID: 228065 RVA: 0x00E1F334 File Offset: 0x00E1D534
		private bool CanToggleExecuteChange()
		{
			ICommonBaseCardComponentData data = this.Data;
			return ((data != null) ? data.CanToggleExecuteChange : null) == null || this.Data.CanToggleExecuteChange();
		}

		// Token: 0x06037AE2 RID: 228066 RVA: 0x00E1F35C File Offset: 0x00E1D55C
		public void RefreshOutlook()
		{
			this.RefreshElementFrame();
			this.RefreshCardFrame();
			this.RefreshCardFace();
		}

		// Token: 0x0401FE6D RID: 130669
		protected ICommonBaseCardComponentData Data;

		// Token: 0x0401FE6E RID: 130670
		private CardElementItem ElementItem;

		// Token: 0x0200B4E2 RID: 46306
		[NullableContext(0)]
		private static class EComponents
		{
			// Token: 0x04037FD7 RID: 229335
			public const int CardItemToggle = 0;

			// Token: 0x04037FD8 RID: 229336
			public const int AttackText = 1;

			// Token: 0x04037FD9 RID: 229337
			public const int ContentItem = 2;

			// Token: 0x04037FDA RID: 229338
			public const int LifeText = 3;

			// Token: 0x04037FDB RID: 229339
			public const int CostText = 4;

			// Token: 0x04037FDC RID: 229340
			public const int MiddleHighLightItem = 5;

			// Token: 0x04037FDD RID: 229341
			public const int LeftHighLightItem = 6;

			// Token: 0x04037FDE RID: 229342
			public const int ElementItem = 7;

			// Token: 0x04037FDF RID: 229343
			public const int CardFaceTexture = 8;

			// Token: 0x04037FE0 RID: 229344
			public const int NormalElementFrameItem = 9;

			// Token: 0x04037FE1 RID: 229345
			public const int NormalCardFrameItem = 10;

			// Token: 0x04037FE2 RID: 229346
			public const int GoldElementFrameItem = 11;

			// Token: 0x04037FE3 RID: 229347
			public const int GoldCardFrameItem = 12;

			// Token: 0x04037FE4 RID: 229348
			public const int SpineRootItem = 13;

			// Token: 0x04037FE5 RID: 229349
			public const int HighLightBgItem = 14;

			// Token: 0x04037FE6 RID: 229350
			public const int RightHighLightItem = 15;
		}
	}
}
