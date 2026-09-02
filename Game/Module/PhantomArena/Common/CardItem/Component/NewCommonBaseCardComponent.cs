using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.PhantomArena.Battle;
using CSharpScript.Game.Module.PhantomArena.Common.CardItem.Item;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Common.CardItem.Component
{
	// Token: 0x0200555D RID: 21853
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class NewCommonBaseCardComponent : CardComponentBase<ICommonBaseCardComponentData>, ICommonBaseCardComponent
	{
		// Token: 0x06037B17 RID: 228119 RVA: 0x00E1F490 File Offset: 0x00E1D690
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
				new ValueTuple<int, Type>(8, typeof(UUIItem)),
				new ValueTuple<int, Type>(9, typeof(UUIItem)),
				new ValueTuple<int, Type>(10, typeof(UUIItem)),
				new ValueTuple<int, Type>(11, typeof(UUITexture)),
				new ValueTuple<int, Type>(12, typeof(UUIItem)),
				new ValueTuple<int, Type>(13, typeof(UUIItem)),
				new ValueTuple<int, Type>(14, typeof(UUIItem)),
				new ValueTuple<int, Type>(15, typeof(UUIItem)),
				new ValueTuple<int, Type>(16, typeof(UUIText))
			};
		}

		// Token: 0x06037B18 RID: 228120 RVA: 0x00E1F628 File Offset: 0x00E1D828
		protected override UniTask OnBeforeStartAsync()
		{
			NewCommonBaseCardComponent.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<NewCommonBaseCardComponent.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06037B19 RID: 228121 RVA: 0x00E1F66C File Offset: 0x00E1D86C
		protected override void OnStart()
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			extendToggle.OnStateChange.Add(new Action<EToggleState>(this.OnToggleStateChanged));
			extendToggle.CanExecuteChange.Bind(new Func<bool>(this.CanToggleExecuteChange));
			extendToggle.OnPointUpCallBack.Bind(new Action<EToggleState>(this.OnPointerUp));
			base.GetTexture(11).SetUIActive(false);
			base.GetItem(6).SetUIActive(false);
			base.GetItem(5).SetUIActive(false);
			base.GetItem(7).SetUIActive(false);
			base.GetItem(10).SetUIActive(false);
		}

		// Token: 0x06037B1A RID: 228122 RVA: 0x00E1F708 File Offset: 0x00E1D908
		public override void Refresh(ICommonBaseCardComponentData data)
		{
			NewCommonBaseCardComponent.<>c__DisplayClass6_0 CS$<>8__locals1 = new NewCommonBaseCardComponent.<>c__DisplayClass6_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.data = data;
			new UiAsyncTask("Refresh", delegate()
			{
				NewCommonBaseCardComponent.<>c__DisplayClass6_0.<<Refresh>b__0>d <<Refresh>b__0>d;
				<<Refresh>b__0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
				<<Refresh>b__0>d.<>4__this = CS$<>8__locals1;
				<<Refresh>b__0>d.<>1__state = -1;
				<<Refresh>b__0>d.<>t__builder.Start<NewCommonBaseCardComponent.<>c__DisplayClass6_0.<<Refresh>b__0>d>(ref <<Refresh>b__0>d);
				return <<Refresh>b__0>d.<>t__builder.Task;
			}, null).Run();
		}

		// Token: 0x06037B1B RID: 228123 RVA: 0x00E1F748 File Offset: 0x00E1D948
		public UniTask RefreshAsync(ICommonBaseCardComponentData data)
		{
			NewCommonBaseCardComponent.<RefreshAsync>d__7 <RefreshAsync>d__;
			<RefreshAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshAsync>d__.<>4__this = this;
			<RefreshAsync>d__.data = data;
			<RefreshAsync>d__.<>1__state = -1;
			<RefreshAsync>d__.<>t__builder.Start<NewCommonBaseCardComponent.<RefreshAsync>d__7>(ref <RefreshAsync>d__);
			return <RefreshAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06037B1C RID: 228124 RVA: 0x00E1F794 File Offset: 0x00E1D994
		private void RefreshCardType()
		{
			this.CardType = (EPhantomArenaCardType)ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleCardConfig(this.Data.CardId).Type;
		}

		// Token: 0x06037B1D RID: 228125 RVA: 0x00E1F7C4 File Offset: 0x00E1D9C4
		private void RefreshAttack()
		{
			base.GetText(1).SetText(this.Data.Attack.ToString(), true);
		}

		// Token: 0x06037B1E RID: 228126 RVA: 0x00E1F7F4 File Offset: 0x00E1D9F4
		private void RefreshLife()
		{
			base.GetText(3).SetText(this.Data.Life.ToString(), true);
		}

		// Token: 0x06037B1F RID: 228127 RVA: 0x00E1F824 File Offset: 0x00E1DA24
		private void RefreshCost()
		{
			base.GetText(4).SetText(this.Data.Cost.ToString(), true);
		}

		// Token: 0x06037B20 RID: 228128 RVA: 0x00E1F851 File Offset: 0x00E1DA51
		public void RefreshElementIcon()
		{
			this.ElementItem.Refresh((ECardElement)this.Data.Element, false, 0);
		}

		// Token: 0x06037B21 RID: 228129 RVA: 0x00E1F86B File Offset: 0x00E1DA6B
		public void RefreshElementFrame()
		{
			base.GetItem(8).SetUIActive(this.Data.Element != 0);
		}

		// Token: 0x06037B22 RID: 228130 RVA: 0x00E1F887 File Offset: 0x00E1DA87
		public void RefreshCardFace()
		{
			new UiAsyncTask("Refresh", delegate()
			{
				NewCommonBaseCardComponent.<<RefreshCardFace>b__14_0>d <<RefreshCardFace>b__14_0>d;
				<<RefreshCardFace>b__14_0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
				<<RefreshCardFace>b__14_0>d.<>4__this = this;
				<<RefreshCardFace>b__14_0>d.<>1__state = -1;
				<<RefreshCardFace>b__14_0>d.<>t__builder.Start<NewCommonBaseCardComponent.<<RefreshCardFace>b__14_0>d>(ref <<RefreshCardFace>b__14_0>d);
				return <<RefreshCardFace>b__14_0>d.<>t__builder.Task;
			}, null).Run();
		}

		// Token: 0x06037B23 RID: 228131 RVA: 0x00E1F8A8 File Offset: 0x00E1DAA8
		public UniTask RefreshCardFaceAsync()
		{
			NewCommonBaseCardComponent.<RefreshCardFaceAsync>d__15 <RefreshCardFaceAsync>d__;
			<RefreshCardFaceAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshCardFaceAsync>d__.<>4__this = this;
			<RefreshCardFaceAsync>d__.<>1__state = -1;
			<RefreshCardFaceAsync>d__.<>t__builder.Start<NewCommonBaseCardComponent.<RefreshCardFaceAsync>d__15>(ref <RefreshCardFaceAsync>d__);
			return <RefreshCardFaceAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06037B24 RID: 228132 RVA: 0x00E1F8EC File Offset: 0x00E1DAEC
		private void RefreshCardItem()
		{
			bool flag = this.CardType == EPhantomArenaCardType.Normal;
			UUIItem item = base.GetItem(12);
			if (item != null)
			{
				item.SetUIActive(flag);
			}
			if (!flag)
			{
				return;
			}
			this.RefreshAttack();
			this.RefreshLife();
			this.RefreshCost();
		}

		// Token: 0x06037B25 RID: 228133 RVA: 0x00E1F930 File Offset: 0x00E1DB30
		private void RefreshFieldItem()
		{
			bool uiactive = this.CardType == EPhantomArenaCardType.Field;
			UUIItem item = base.GetItem(14);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(uiactive);
		}

		// Token: 0x06037B26 RID: 228134 RVA: 0x00E1F95C File Offset: 0x00E1DB5C
		private void RefreshToolItem()
		{
			bool flag = this.CardType == EPhantomArenaCardType.Tool;
			UUIItem item = base.GetItem(15);
			if (item != null)
			{
				item.SetUIActive(flag);
			}
			if (flag)
			{
				PhantomBattleCard phantomBattleCardConfig = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleCardConfig(this.Data.CardId);
				int value = phantomBattleCardConfig.InitAttack().ContainsKey(12) ? phantomBattleCardConfig.InitAttack()[12] : 0;
				UUIText text = base.GetText(16);
				if (text == null)
				{
					return;
				}
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
				defaultInterpolatedStringHandler.AppendFormatted<int>(value);
				text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
			}
		}

		// Token: 0x06037B27 RID: 228135 RVA: 0x00E1F9F0 File Offset: 0x00E1DBF0
		public void RefreshToggleState()
		{
			base.GetExtendToggle(0).SetToggleState(this.Data.ToggleState.GetValueOrDefault(), false, false, false);
		}

		// Token: 0x06037B28 RID: 228136 RVA: 0x00E1FA20 File Offset: 0x00E1DC20
		public void RefreshLightItem()
		{
			int phantomArenaCardCoreCost = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomArenaCardCoreCost();
			PhantomBattleCard phantomBattleCardConfig = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleCardConfig(this.Data.CardId);
			bool flag = phantomBattleCardConfig.Cost == phantomArenaCardCoreCost;
			bool flag2 = phantomBattleCardConfig.Type == 3;
			int num = (flag || flag2) ? 0 : phantomBattleCardConfig.Cost;
			UUIItem item = base.GetItem(10);
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
			UUIItem item4 = base.GetItem(7);
			if (item4 == null)
			{
				return;
			}
			item4.SetUIActive(num >= 3);
		}

		// Token: 0x06037B29 RID: 228137 RVA: 0x00E1FAD3 File Offset: 0x00E1DCD3
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

		// Token: 0x06037B2A RID: 228138 RVA: 0x00E1FAEF File Offset: 0x00E1DCEF
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

		// Token: 0x06037B2B RID: 228139 RVA: 0x00E1FB0C File Offset: 0x00E1DD0C
		private bool CanToggleExecuteChange()
		{
			ICommonBaseCardComponentData data = this.Data;
			return ((data != null) ? data.CanToggleExecuteChange : null) == null || this.Data.CanToggleExecuteChange();
		}

		// Token: 0x06037B2C RID: 228140 RVA: 0x00E1FB34 File Offset: 0x00E1DD34
		public void RefreshOutlook()
		{
			this.RefreshElementFrame();
			this.RefreshCardFace();
		}

		// Token: 0x0401FE7B RID: 130683
		protected ICommonBaseCardComponentData Data;

		// Token: 0x0401FE7C RID: 130684
		private CardElementItem ElementItem;

		// Token: 0x0401FE7D RID: 130685
		private EPhantomArenaCardType CardType;

		// Token: 0x0200B4E8 RID: 46312
		[NullableContext(0)]
		private static class EComponents
		{
			// Token: 0x04037FFB RID: 229371
			public const int CardItemToggle = 0;

			// Token: 0x04037FFC RID: 229372
			public const int AttackText = 1;

			// Token: 0x04037FFD RID: 229373
			public const int ContentItem = 2;

			// Token: 0x04037FFE RID: 229374
			public const int LifeText = 3;

			// Token: 0x04037FFF RID: 229375
			public const int CostText = 4;

			// Token: 0x04038000 RID: 229376
			public const int MiddleHighLightItem = 5;

			// Token: 0x04038001 RID: 229377
			public const int LeftHighLightItem = 6;

			// Token: 0x04038002 RID: 229378
			public const int RightHighLightItem = 7;

			// Token: 0x04038003 RID: 229379
			public const int ElementItem = 8;

			// Token: 0x04038004 RID: 229380
			public const int ElementIconItem = 9;

			// Token: 0x04038005 RID: 229381
			public const int CostItem = 10;

			// Token: 0x04038006 RID: 229382
			public const int CardFaceTexture = 11;

			// Token: 0x04038007 RID: 229383
			public const int NormalCardItem = 12;

			// Token: 0x04038008 RID: 229384
			public const int SpineRootItem = 13;

			// Token: 0x04038009 RID: 229385
			public const int FieldCardItem = 14;

			// Token: 0x0403800A RID: 229386
			public const int ToolCardItem = 15;

			// Token: 0x0403800B RID: 229387
			public const int ToolCount = 16;
		}
	}
}
