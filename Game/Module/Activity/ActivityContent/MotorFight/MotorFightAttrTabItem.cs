using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MotorFight
{
	// Token: 0x020066E9 RID: 26345
	public class MotorFightAttrTabItem : GridProxyAbstract<EMotorFightAttrShowType>
	{
		// Token: 0x06041C3A RID: 269370 RVA: 0x010DE7A7 File Offset: 0x010DC9A7
		protected override void OnStart()
		{
			base.GetExtendToggle(1).bLockStateOnSelect = true;
			this.SetToggleState(false);
		}

		// Token: 0x06041C3B RID: 269371 RVA: 0x010DE7C0 File Offset: 0x010DC9C0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(1, new Action<EToggleState>(this.OnToggleClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06041C3C RID: 269372 RVA: 0x010DE887 File Offset: 0x010DCA87
		public override void Refresh(EMotorFightAttrShowType type, bool isSelected, int gridIndex)
		{
			this.Type = type;
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), MotorFightDefine.motorFightAttrShowTypeToName[type], Array.Empty<object>());
			UUIItem item = base.GetItem(2);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(false);
		}

		// Token: 0x06041C3D RID: 269373 RVA: 0x010DE8C3 File Offset: 0x010DCAC3
		private void OnToggleClick(EToggleState _)
		{
			this.OnToggleClickCallBack(this.Type);
		}

		// Token: 0x06041C3E RID: 269374 RVA: 0x010DE8D6 File Offset: 0x010DCAD6
		[NullableContext(1)]
		public override object GetKey(EMotorFightAttrShowType data, int displayIndex)
		{
			return data;
		}

		// Token: 0x06041C3F RID: 269375 RVA: 0x010DE8E0 File Offset: 0x010DCAE0
		public void SetToggleState(bool state)
		{
			EToggleState state2 = state ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
			base.GetExtendToggle(1).SetToggleState(state2, false, false, false);
		}

		// Token: 0x06041C40 RID: 269376 RVA: 0x010DE906 File Offset: 0x010DCB06
		public override void OnSelected(bool fireEvent)
		{
			this.SetToggleState(true);
		}

		// Token: 0x06041C41 RID: 269377 RVA: 0x010DE90F File Offset: 0x010DCB0F
		public override void OnDeselected(bool fireEvent)
		{
			this.SetToggleState(false);
		}

		// Token: 0x04024B0C RID: 150284
		private EMotorFightAttrShowType Type;

		// Token: 0x04024B0D RID: 150285
		[Nullable(1)]
		public Action<EMotorFightAttrShowType> OnToggleClickCallBack = delegate(EMotorFightAttrShowType type)
		{
		};

		// Token: 0x0200C723 RID: 50979
		private class ETabComponent
		{
			// Token: 0x0403D4E6 RID: 251110
			public const int TextName = 0;

			// Token: 0x0403D4E7 RID: 251111
			public const int ToggleRoot = 1;

			// Token: 0x0403D4E8 RID: 251112
			public const int ItemRedDot = 2;
		}
	}
}
