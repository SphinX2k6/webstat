using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004E48 RID: 20040
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class TrapDefenseRewardTabItem : GridProxyAbstract<TrapDefenseRewardTabData>
	{
		// Token: 0x06033CB7 RID: 212151 RVA: 0x00CF29C0 File Offset: 0x00CF0BC0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06033CB8 RID: 212152 RVA: 0x00CF2AC9 File Offset: 0x00CF0CC9
		protected override void OnStart()
		{
			ModelBase<TrapDefenseModel>.Instance.ViewModelReward.RegisterOnSelectRewardTypeChange(new Action<ETrapDefenseRewardType>(this.OnSelectedTypeChange));
			Singleton<EventSystem>.Instance.Add(EEventName.RedDotUpdateTrapDefenseLimitReward, new Action(this.OnRedDotUpdate));
		}

		// Token: 0x06033CB9 RID: 212153 RVA: 0x00CF2B02 File Offset: 0x00CF0D02
		protected override void OnBeforeDestroy()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.RedDotUpdateTrapDefenseLimitReward, new Action(this.OnRedDotUpdate));
			ModelBase<TrapDefenseModel>.Instance.ViewModelReward.UnregisterOnSelectRewardTypeChange(new Action<ETrapDefenseRewardType>(this.OnSelectedTypeChange));
		}

		// Token: 0x06033CBA RID: 212154 RVA: 0x00CF2B3C File Offset: 0x00CF0D3C
		public override void Refresh(TrapDefenseRewardTabData data, bool isSelected, int gridIndex)
		{
			if (data == null)
			{
				return;
			}
			this.Data = data;
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), data.GetTitle(), Array.Empty<object>());
			base.GetText(2).SetText(data.GetProgressText(), true);
			base.GetTexture(3).SetUIActive(data.IsFinished());
			base.GetItem(4).SetUIActive(data.HasRedDot());
		}

		// Token: 0x06033CBB RID: 212155 RVA: 0x00CF2BAC File Offset: 0x00CF0DAC
		public override void OnSelected(bool fireEvent)
		{
			this.SetToggleState(EToggleState.ETT_Checked, fireEvent);
			TrapDefenseModel instance = ModelBase<TrapDefenseModel>.Instance;
			if (instance.ViewModelReward.CurSelectRewardType == this.Data.Type)
			{
				return;
			}
			instance.ViewModelReward.SetCurSelectRewardType(this.Data.Type);
		}

		// Token: 0x06033CBC RID: 212156 RVA: 0x00CF2BF6 File Offset: 0x00CF0DF6
		public override void OnDeselected(bool fireEvent)
		{
			this.SetToggleState(EToggleState.ETT_UnChecked, fireEvent);
		}

		// Token: 0x06033CBD RID: 212157 RVA: 0x00CF2C00 File Offset: 0x00CF0E00
		private void SetToggleState(EToggleState state, bool fireEvent)
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (extendToggle != null)
			{
				extendToggle.SetToggleState(state, fireEvent, false, false);
			}
		}

		// Token: 0x06033CBE RID: 212158 RVA: 0x00CF2C23 File Offset: 0x00CF0E23
		private void OnClick(EToggleState state)
		{
			this.OnSelected(false);
		}

		// Token: 0x06033CBF RID: 212159 RVA: 0x00CF2C2C File Offset: 0x00CF0E2C
		private void OnSelectedTypeChange(ETrapDefenseRewardType type)
		{
			if (this.Data == null)
			{
				return;
			}
			if (type != this.Data.Type)
			{
				this.OnDeselected(false);
			}
		}

		// Token: 0x06033CC0 RID: 212160 RVA: 0x00CF2C4C File Offset: 0x00CF0E4C
		private void OnRedDotUpdate()
		{
			if (this.Data == null)
			{
				return;
			}
			UUIItem item = base.GetItem(4);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(this.Data.HasRedDot());
		}

		// Token: 0x0401DF95 RID: 122773
		private TrapDefenseRewardTabData Data;

		// Token: 0x0200ADDB RID: 44507
		[NullableContext(0)]
		private class EComponentDefine
		{
			// Token: 0x04035FBD RID: 221117
			public const int TogSelf = 0;

			// Token: 0x04035FBE RID: 221118
			public const int TextTitle = 1;

			// Token: 0x04035FBF RID: 221119
			public const int TextProgress = 2;

			// Token: 0x04035FC0 RID: 221120
			public const int TextureFinished = 3;

			// Token: 0x04035FC1 RID: 221121
			public const int ItemRedDot = 4;
		}
	}
}
