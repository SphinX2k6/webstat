using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Prepare.DeckBuilder
{
	// Token: 0x020054E7 RID: 21735
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class DeckBuilderCardDeleteFilterItem : GridProxyAbstract<IDeckBuilderCardDeleteFilterItemData>
	{
		// Token: 0x06037643 RID: 226883 RVA: 0x00E0E2B0 File Offset: 0x00E0C4B0
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUITexture)),
				new ValueTuple<int, Type>(3, typeof(UUISprite)),
				new ValueTuple<int, Type>(4, typeof(UUIText))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnItemToggleClickInternal))
			};
		}

		// Token: 0x06037644 RID: 226884 RVA: 0x00E0E35C File Offset: 0x00E0C55C
		[NullableContext(1)]
		public override void Refresh(IDeckBuilderCardDeleteFilterItemData data, bool isSelected, int gridIndex)
		{
			this.Data = data;
			PhantomBattleCardElement phantomBattleElementConfig = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleElementConfig((int)data.Element);
			base.SetTextureByPath(phantomBattleElementConfig.DeleteFilterIcon, base.GetTexture(2), null, null);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), phantomBattleElementConfig.Name, Array.Empty<object>());
			if (data.Enabled)
			{
				EToggleState state = data.Selected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
				base.GetExtendToggle(0).SetToggleState(state, false, false, false);
				return;
			}
			base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_UnDetermined, false, false, false);
		}

		// Token: 0x06037645 RID: 226885 RVA: 0x00E0E3F4 File Offset: 0x00E0C5F4
		private void OnItemToggleClickInternal(EToggleState toggleState)
		{
			EToggleState toggleState2 = base.GetExtendToggle(0).GetToggleState();
			Action<int, EToggleState> onItemToggleStateChange = this.OnItemToggleStateChange;
			if (onItemToggleStateChange == null)
			{
				return;
			}
			onItemToggleStateChange(base.GridIndex, toggleState2);
		}

		// Token: 0x0401FCD7 RID: 130263
		protected IDeckBuilderCardDeleteFilterItemData Data;

		// Token: 0x0401FCD8 RID: 130264
		public Action<int, EToggleState> OnItemToggleStateChange;

		// Token: 0x0200B463 RID: 46179
		[NullableContext(0)]
		private static class EComponents
		{
			// Token: 0x04037D75 RID: 228725
			public const int ItemToggle = 0;

			// Token: 0x04037D76 RID: 228726
			public const int IconRootItem = 1;

			// Token: 0x04037D77 RID: 228727
			public const int IconTexture = 2;

			// Token: 0x04037D78 RID: 228728
			public const int IconSprite = 3;

			// Token: 0x04037D79 RID: 228729
			public const int NameText = 4;
		}
	}
}
