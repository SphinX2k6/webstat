using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x0200516E RID: 20846
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RoguelikePhantomSelectDragItem : GridProxyAbstract<IPhantomSelectItemData>
	{
		// Token: 0x06035A53 RID: 219731 RVA: 0x00D7979C File Offset: 0x00D7799C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickToggle));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06035A54 RID: 219732 RVA: 0x00D79863 File Offset: 0x00D77A63
		protected override void OnStart()
		{
			base.GetExtendToggle(0).CanExecuteChange.Bind(new Func<bool>(this.CanToggleStateChangeInternal));
		}

		// Token: 0x06035A55 RID: 219733 RVA: 0x00D79884 File Offset: 0x00D77A84
		private bool CanToggleStateChangeInternal()
		{
			if (this.CanToggleStateChange != null)
			{
				EToggleState toggleState = base.GetExtendToggle(0).GetToggleState();
				return this.CanToggleStateChange(toggleState == EToggleState.ETT_Checked);
			}
			return true;
		}

		// Token: 0x06035A56 RID: 219734 RVA: 0x00D798B7 File Offset: 0x00D77AB7
		private void OnClickToggle(EToggleState toggleState)
		{
			Action<IPhantomSelectItemData, bool> onSelectCallback = this.OnSelectCallback;
			if (onSelectCallback == null)
			{
				return;
			}
			onSelectCallback(this.CurrentData, toggleState == EToggleState.ETT_Checked);
		}

		// Token: 0x06035A57 RID: 219735 RVA: 0x00D798D3 File Offset: 0x00D77AD3
		public void SetToggleInteractive(bool bInteract)
		{
			base.GetExtendToggle(0).SetSelfInteractive(bInteract);
		}

		// Token: 0x06035A58 RID: 219736 RVA: 0x00D798E4 File Offset: 0x00D77AE4
		[NullableContext(1)]
		public override void Refresh(IPhantomSelectItemData data, bool isSelected, int gridIndex)
		{
			this.CurrentData = data;
			base.GetItem(2).SetUIActive(data.IsLock);
			RoguePokemon? roguePhantomConfig = ConfigBase<RoguelikeConfig>.Instance.GetRoguePhantomConfig(data.PhantomId);
			if (roguePhantomConfig == null)
			{
				return;
			}
			base.SetTextureByPath(roguePhantomConfig.Value.PokemonIcon, base.GetTexture(1), null, null);
		}

		// Token: 0x06035A59 RID: 219737 RVA: 0x00D7994B File Offset: 0x00D77B4B
		public override void OnDeselected(bool fireEvent)
		{
			base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_UnChecked, fireEvent, false, false);
		}

		// Token: 0x06035A5A RID: 219738 RVA: 0x00D7995E File Offset: 0x00D77B5E
		public override void OnSelected(bool fireEvent)
		{
			base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_Checked, fireEvent, false, false);
		}

		// Token: 0x0401ECD4 RID: 126164
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Action<IPhantomSelectItemData, bool> OnSelectCallback;

		// Token: 0x0401ECD5 RID: 126165
		public Func<bool, bool> CanToggleStateChange;

		// Token: 0x0401ECD6 RID: 126166
		private IPhantomSelectItemData CurrentData;

		// Token: 0x0200B11D RID: 45341
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x04036EFF RID: 225023
			public const int TogSelf = 0;

			// Token: 0x04036F00 RID: 225024
			public const int TexPhantom = 1;

			// Token: 0x04036F01 RID: 225025
			public const int ItemLock = 2;
		}
	}
}
