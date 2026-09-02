using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MotorFight
{
	// Token: 0x020066E3 RID: 26339
	[NullableContext(1)]
	[Nullable(0)]
	public class MotorFightTaskTabItem : GridProxyAbstract<MotorFightTaskTab>
	{
		// Token: 0x06041C18 RID: 269336 RVA: 0x010DDD5C File Offset: 0x010DBF5C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnToggleClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06041C19 RID: 269337 RVA: 0x010DDE24 File Offset: 0x010DC024
		public override void Refresh(MotorFightTaskTab data, bool isSelected, int gridIndex)
		{
			this.Data = new MotorFightTaskTab?(data);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), data.TabTitle, Array.Empty<object>());
			bool uiactive = this.ActivityData.IsTaskHasRedDotByTab(data.Id);
			UUIItem item = base.GetItem(2);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(uiactive);
		}

		// Token: 0x06041C1A RID: 269338 RVA: 0x010DDE80 File Offset: 0x010DC080
		private void OnToggleClick(EToggleState _)
		{
			this.OnToggleClickCallBack(this.Data.Value.Id);
		}

		// Token: 0x06041C1B RID: 269339 RVA: 0x010DDEAB File Offset: 0x010DC0AB
		public override object GetKey(MotorFightTaskTab data, int displayIndex)
		{
			return data.Id;
		}

		// Token: 0x06041C1C RID: 269340 RVA: 0x010DDEBC File Offset: 0x010DC0BC
		public void SetToggleState(bool state)
		{
			EToggleState state2 = state ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
			base.GetExtendToggle(0).SetToggleState(state2, false, false, false);
		}

		// Token: 0x06041C1D RID: 269341 RVA: 0x010DDEE2 File Offset: 0x010DC0E2
		public override void OnSelected(bool fireEvent)
		{
			this.SetToggleState(true);
		}

		// Token: 0x06041C1E RID: 269342 RVA: 0x010DDEEB File Offset: 0x010DC0EB
		public override void OnDeselected(bool fireEvent)
		{
			this.SetToggleState(false);
		}

		// Token: 0x04024AFD RID: 150269
		private MotorFightTaskTab? Data;

		// Token: 0x04024AFE RID: 150270
		public MotorFightActivityData ActivityData;

		// Token: 0x04024AFF RID: 150271
		public Action<int> OnToggleClickCallBack = delegate(int tabId)
		{
		};

		// Token: 0x0200C719 RID: 50969
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x0403D4C7 RID: 251079
			public const int ToggleRoot = 0;

			// Token: 0x0403D4C8 RID: 251080
			public const int TextTabName = 1;

			// Token: 0x0403D4C9 RID: 251081
			public const int ItemRedDot = 2;
		}
	}
}
