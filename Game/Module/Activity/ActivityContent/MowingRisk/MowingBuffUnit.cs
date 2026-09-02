using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MowingRisk
{
	// Token: 0x020066A3 RID: 26275
	[NullableContext(1)]
	[Nullable(0)]
	public class MowingBuffUnit : UiPanelBase
	{
		// Token: 0x060419D0 RID: 268752 RVA: 0x010D2DBC File Offset: 0x010D0FBC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 8;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(6, new Action<EToggleState>(this.HandleOnClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x060419D1 RID: 268753 RVA: 0x010D2F28 File Offset: 0x010D1128
		protected override void OnStart()
		{
			this.Player = new UiSequencePlayer(this.RootItem);
			base.GetExtendToggle(6).CanExecuteChange.Bind(new Func<bool>(this.HandleCanExecuteChange));
		}

		// Token: 0x060419D2 RID: 268754 RVA: 0x010D2F58 File Offset: 0x010D1158
		protected override void OnBeforeDestroy()
		{
			base.GetExtendToggle(6).CanExecuteChange.Unbind();
		}

		// Token: 0x060419D3 RID: 268755 RVA: 0x010D2F6C File Offset: 0x010D116C
		public void RefreshByCustomData(IMowingBuffUnitData data)
		{
			this.PassData = data;
			UUITexture texture = base.GetTexture(3);
			if (texture != null)
			{
				texture.SetUIActive(data.IconPath != null);
			}
			if (!string.IsNullOrEmpty(data.IconPath))
			{
				base.SetTextureByPath(data.IconPath, texture, null, null);
			}
			this.UpdateUnlockState(data.IsActive);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), data.NameTextId, Array.Empty<object>());
			base.GetText(5).SetText(data.ThresholdCount.ToString(), true);
			base.GetExtendToggle(6).SetToggleStateForce(data.IsChosen ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
			base.GetItem(7).SetUIActive(false);
		}

		// Token: 0x060419D4 RID: 268756 RVA: 0x010D302C File Offset: 0x010D122C
		public void UpdateUnlockState(bool isUnlock)
		{
			base.GetSprite(0).SetUIActive(isUnlock);
			base.GetItem(1).SetUIActive(isUnlock);
			base.GetItem(2).SetUIActive(!isUnlock);
			UUITexture texture = base.GetTexture(3);
			if (texture != null)
			{
				texture.SetIsGray(!isUnlock);
			}
			if (texture == null)
			{
				return;
			}
			texture.SetAlpha(isUnlock ? 1f : 0.85f);
		}

		// Token: 0x060419D5 RID: 268757 RVA: 0x010D3093 File Offset: 0x010D1293
		public void PlayUnlockSequence()
		{
			base.GetItem(7).SetUIActive(true);
			this.UpdateUnlockState(true);
			this.Player.LitePlayAsync("Unlock", true, false).Forget<bool>();
		}

		// Token: 0x060419D6 RID: 268758 RVA: 0x010D30C0 File Offset: 0x010D12C0
		private void HandleOnClick(EToggleState toggleState)
		{
			ModelBase<MowingRiskModel>.Instance.CurrentChosenProgressIndex = new int?(this.PassData.Index);
			Singleton<EventSystem>.Instance.Emit(EEventName.MowingSuperBuffGridItemClick);
		}

		// Token: 0x060419D7 RID: 268759 RVA: 0x010D30EC File Offset: 0x010D12EC
		private bool HandleCanExecuteChange()
		{
			return !this.PassData.IsChosen;
		}

		// Token: 0x04024A38 RID: 150072
		private const float GRAY_ALPHA = 0.85f;

		// Token: 0x04024A39 RID: 150073
		private IMowingBuffUnitData PassData;

		// Token: 0x04024A3A RID: 150074
		private UiSequencePlayer Player;

		// Token: 0x0200C6BA RID: 50874
		[NullableContext(0)]
		private class EComponent
		{
			// Token: 0x0403D30B RID: 250635
			public const int StarSprite = 0;

			// Token: 0x0403D30C RID: 250636
			public const int ActiveItem = 1;

			// Token: 0x0403D30D RID: 250637
			public const int InactiveItem = 2;

			// Token: 0x0403D30E RID: 250638
			public const int IconTexture = 3;

			// Token: 0x0403D30F RID: 250639
			public const int NameText = 4;

			// Token: 0x0403D310 RID: 250640
			public const int CountText = 5;

			// Token: 0x0403D311 RID: 250641
			public const int BuffToggle = 6;

			// Token: 0x0403D312 RID: 250642
			public const int UnlockAnimItem = 7;
		}
	}
}
