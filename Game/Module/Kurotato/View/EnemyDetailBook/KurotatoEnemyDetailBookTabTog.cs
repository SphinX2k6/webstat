using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Kurotato.View.EnemyDetailBook
{
	// Token: 0x02005AC3 RID: 23235
	public class KurotatoEnemyDetailBookTabTog : GridProxyAbstract<EKurotatoEnemyDetailBookTabAllOrWave>
	{
		// Token: 0x0603ABF3 RID: 240627 RVA: 0x00EE5010 File Offset: 0x00EE3210
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
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnTogClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603ABF4 RID: 240628 RVA: 0x00EE50D7 File Offset: 0x00EE32D7
		protected override void OnStart()
		{
			base.GetExtendToggle(0).CanExecuteChange.Bind(() => this.CanExecuteChangeFunc == null || this.CanExecuteChangeFunc(base.GridIndex));
		}

		// Token: 0x0603ABF5 RID: 240629 RVA: 0x00EE50F6 File Offset: 0x00EE32F6
		private void OnTogClick(EToggleState state)
		{
			if (this.Data != null)
			{
				Action<EKurotatoEnemyDetailBookTabAllOrWave> onTogClickCallBack = this.OnTogClickCallBack;
				if (onTogClickCallBack == null)
				{
					return;
				}
				onTogClickCallBack(this.Data.Value);
			}
		}

		// Token: 0x0603ABF6 RID: 240630 RVA: 0x00EE5120 File Offset: 0x00EE3320
		public override void Refresh(EKurotatoEnemyDetailBookTabAllOrWave data, bool isSelected, int gridIndex)
		{
			this.Data = new EKurotatoEnemyDetailBookTabAllOrWave?(data);
			string textStringId = (data == EKurotatoEnemyDetailBookTabAllOrWave.All) ? "Survivor_Monster_Type" : "Survivor_Monster_Wave";
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), textStringId, Array.Empty<object>());
		}

		// Token: 0x0603ABF7 RID: 240631 RVA: 0x00EE5160 File Offset: 0x00EE3360
		public override void OnSelected(bool fireEvent)
		{
			this.SetToggleState(true);
		}

		// Token: 0x0603ABF8 RID: 240632 RVA: 0x00EE5169 File Offset: 0x00EE3369
		public override void OnDeselected(bool fireEvent)
		{
			this.SetToggleState(false);
		}

		// Token: 0x0603ABF9 RID: 240633 RVA: 0x00EE5174 File Offset: 0x00EE3374
		private void SetToggleState(bool state)
		{
			EToggleState state2 = state ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
			base.GetExtendToggle(0).SetToggleState(state2, false, false, false);
		}

		// Token: 0x04021375 RID: 136053
		public EKurotatoEnemyDetailBookTabAllOrWave? Data;

		// Token: 0x04021376 RID: 136054
		[Nullable(2)]
		public Action<EKurotatoEnemyDetailBookTabAllOrWave> OnTogClickCallBack;

		// Token: 0x04021377 RID: 136055
		[Nullable(2)]
		public Func<int, bool> CanExecuteChangeFunc;

		// Token: 0x0200BAD8 RID: 47832
		private class ETabItemComponent
		{
			// Token: 0x04039AD1 RID: 236241
			public const int TogSelf = 0;

			// Token: 0x04039AD2 RID: 236242
			public const int TextTitle = 1;

			// Token: 0x04039AD3 RID: 236243
			public const int RedDot = 2;
		}
	}
}
