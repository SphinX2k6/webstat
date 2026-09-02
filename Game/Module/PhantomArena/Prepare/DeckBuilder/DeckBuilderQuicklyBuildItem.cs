using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Prepare.DeckBuilder
{
	// Token: 0x02005503 RID: 21763
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class DeckBuilderQuicklyBuildItem : GridProxyAbstract<DeckInfo>
	{
		// Token: 0x060377A8 RID: 227240 RVA: 0x00E11728 File Offset: 0x00E0F928
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUIText)),
				new ValueTuple<int, Type>(3, typeof(UUITexture)),
				new ValueTuple<int, Type>(4, typeof(UUITexture))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnToggleStateChangeInternal))
			};
		}

		// Token: 0x060377A9 RID: 227241 RVA: 0x00E117D4 File Offset: 0x00E0F9D4
		protected override void OnStart()
		{
			for (int i = 3; i <= 4; i++)
			{
				this.CardTextureList.Add(base.GetTexture(i));
			}
		}

		// Token: 0x060377AA RID: 227242 RVA: 0x00E11800 File Offset: 0x00E0FA00
		public override void Refresh(DeckInfo data, bool isSelected, int gridIndex)
		{
			this.Data = data;
			base.GetText(1).SetText(data.GetDeckName(), true);
			this.RefreshCountText();
			base.GetExtendToggle(0).SetToggleState(isSelected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
			List<ECardElement> elementList = data.GetElementList();
			if (elementList.Count > this.CardTextureList.Count)
			{
				Singleton<Log>.Instance.Error(ELogModule.PhantomArena, ELogAuthor.LZK, "元素数量超过上限", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			for (int i = 0; i < elementList.Count; i++)
			{
				this.CardTextureList[i].SetUIActive(true);
				base.SetTextureByPath(ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleElementConfig((int)elementList[i]).QuicklyBuildFilterIcon, this.CardTextureList[i], null, null);
			}
			for (int j = elementList.Count; j < this.CardTextureList.Count; j++)
			{
				this.CardTextureList[j].SetUIActive(false);
			}
		}

		// Token: 0x060377AB RID: 227243 RVA: 0x00E1190C File Offset: 0x00E0FB0C
		public void RefreshCountText()
		{
			if (this.Data == null)
			{
				return;
			}
			int unlockCardCountInDeck = ModelBase<PhantomArenaModel>.Instance.GetUnlockCardCountInDeck(this.Data);
			int totalCardCount = this.Data.GetTotalCardCount();
			if (unlockCardCountInDeck == totalCardCount)
			{
				UUIText text = base.GetText(2);
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
				defaultInterpolatedStringHandler.AppendFormatted<int>(unlockCardCountInDeck);
				defaultInterpolatedStringHandler.AppendLiteral("/");
				defaultInterpolatedStringHandler.AppendFormatted<int>(totalCardCount);
				text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
				return;
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), "PhantomBattle_1078", new <>z__ReadOnlyArray<object>(new object[]
			{
				unlockCardCountInDeck,
				totalCardCount
			}));
		}

		// Token: 0x060377AC RID: 227244 RVA: 0x00E119B0 File Offset: 0x00E0FBB0
		public override void OnSelected(bool fireEvent)
		{
			base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_Checked, fireEvent, false, false);
		}

		// Token: 0x060377AD RID: 227245 RVA: 0x00E119C3 File Offset: 0x00E0FBC3
		public override void OnDeselected(bool fireEvent)
		{
			base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_UnChecked, fireEvent, false, false);
		}

		// Token: 0x060377AE RID: 227246 RVA: 0x00E119D6 File Offset: 0x00E0FBD6
		private void OnToggleStateChangeInternal(EToggleState toggleState)
		{
			if (this.OnToggleStateChange != null)
			{
				this.OnToggleStateChange(base.GridIndex);
			}
		}

		// Token: 0x0401FD58 RID: 130392
		[Nullable(2)]
		protected DeckInfo Data;

		// Token: 0x0401FD59 RID: 130393
		protected List<UUITexture> CardTextureList = new List<UUITexture>();

		// Token: 0x0401FD5A RID: 130394
		[Nullable(2)]
		public Action<int> OnToggleStateChange;

		// Token: 0x0200B47B RID: 46203
		[NullableContext(0)]
		private static class EComponents
		{
			// Token: 0x04037DF4 RID: 228852
			public const int ItemToggle = 0;

			// Token: 0x04037DF5 RID: 228853
			public const int DeckNameText = 1;

			// Token: 0x04037DF6 RID: 228854
			public const int CardCountText = 2;

			// Token: 0x04037DF7 RID: 228855
			public const int ElementTexture1 = 3;

			// Token: 0x04037DF8 RID: 228856
			public const int ElementTexture2 = 4;
		}
	}
}
