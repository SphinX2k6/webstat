using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Monster
{
	// Token: 0x020065F1 RID: 26097
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class PinballMonsterSkillTabItem : GridProxyAbstract<IPinballMonsterSkillTabItemData>
	{
		// Token: 0x06041324 RID: 267044 RVA: 0x010B9CA8 File Offset: 0x010B7EA8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnItemToggleStateChange));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06041325 RID: 267045 RVA: 0x010B9D4E File Offset: 0x010B7F4E
		[NullableContext(1)]
		public override void Refresh(IPinballMonsterSkillTabItemData data, bool isSelected, int gridIndex)
		{
			this.Data = data;
			this.RefreshToggle(true);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), data.Name, Array.Empty<object>());
		}

		// Token: 0x06041326 RID: 267046 RVA: 0x010B9D7C File Offset: 0x010B7F7C
		public void RefreshToggle(bool bJumpToEnd)
		{
			if (this.Data == null)
			{
				return;
			}
			EToggleState state = this.Data.IsSelected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (extendToggle == null)
			{
				return;
			}
			extendToggle.SetToggleState(state, false, false, bJumpToEnd);
		}

		// Token: 0x06041327 RID: 267047 RVA: 0x010B9DBA File Offset: 0x010B7FBA
		private void OnItemToggleStateChange(EToggleState state)
		{
			if (this.Data == null)
			{
				return;
			}
			this.Data.OnSelected(base.GridIndex);
		}

		// Token: 0x04024809 RID: 149513
		[Nullable(2)]
		private IPinballMonsterSkillTabItemData Data;

		// Token: 0x0200C5F9 RID: 50681
		private enum EComponents
		{
			// Token: 0x0403CF0E RID: 249614
			ItemToggle,
			// Token: 0x0403CF0F RID: 249615
			NameText
		}
	}
}
