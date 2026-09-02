using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MotorParkour
{
	// Token: 0x020066BC RID: 26300
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class MotorParkourTaskTabItem : GridProxyAbstract<MotorParkourLevelData>
	{
		// Token: 0x06041AB1 RID: 268977 RVA: 0x010D6C30 File Offset: 0x010D4E30
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIExtendToggleSpriteTransition));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnToggleClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06041AB2 RID: 268978 RVA: 0x010D6D39 File Offset: 0x010D4F39
		protected override void OnStart()
		{
			base.GetExtendToggle(0).bLockStateOnSelect = true;
		}

		// Token: 0x06041AB3 RID: 268979 RVA: 0x010D6D48 File Offset: 0x010D4F48
		public override void Refresh(MotorParkourLevelData data, bool isSelected, int gridIndex)
		{
			this.Data = data;
			this.SetSpriteByPath(data.RomanNum, base.GetSprite(1), false, null, delegate(bool _)
			{
				base.GetUiExtendToggleSpriteTransition(3).SetAllStateSprite(base.GetSprite(1).GetSprite());
			});
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), data.LevelName, Array.Empty<object>());
			UUIItem item = base.GetItem(4);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(data.HasRewardRedDot);
		}

		// Token: 0x06041AB4 RID: 268980 RVA: 0x010D6DB8 File Offset: 0x010D4FB8
		private void OnToggleClick(EToggleState _)
		{
			Action<MotorParkourLevelData> onToggleCallback = this.OnToggleCallback;
			if (onToggleCallback == null)
			{
				return;
			}
			onToggleCallback(this.Data);
		}

		// Token: 0x06041AB5 RID: 268981 RVA: 0x010D6DD0 File Offset: 0x010D4FD0
		public override void OnSelected(bool fireEvent)
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (extendToggle == null)
			{
				return;
			}
			extendToggle.SetToggleState(EToggleState.ETT_Checked, false, false, false);
		}

		// Token: 0x06041AB6 RID: 268982 RVA: 0x010D6DE8 File Offset: 0x010D4FE8
		public override void OnDeselected(bool fireEvent)
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (extendToggle == null)
			{
				return;
			}
			extendToggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
		}

		// Token: 0x06041AB7 RID: 268983 RVA: 0x010D6E00 File Offset: 0x010D5000
		public override object GetKey(MotorParkourLevelData data, int displayIndex)
		{
			return data.Id;
		}

		// Token: 0x04024A7C RID: 150140
		private MotorParkourLevelData Data;

		// Token: 0x04024A7D RID: 150141
		public Action<MotorParkourLevelData> OnToggleCallback = delegate(MotorParkourLevelData data)
		{
		};

		// Token: 0x0200C6E3 RID: 50915
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x0403D3BF RID: 250815
			public const int ToggleRoot = 0;

			// Token: 0x0403D3C0 RID: 250816
			public const int SpriteNum = 1;

			// Token: 0x0403D3C1 RID: 250817
			public const int TextName = 2;

			// Token: 0x0403D3C2 RID: 250818
			public const int SpriteTransitionNum = 3;

			// Token: 0x0403D3C3 RID: 250819
			public const int ItemRedDot = 4;
		}
	}
}
