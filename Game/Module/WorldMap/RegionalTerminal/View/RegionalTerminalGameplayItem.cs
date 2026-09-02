using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Module.WorldMap.RegionalTerminal.Data;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.WorldMap.RegionalTerminal.View
{
	// Token: 0x02004BF1 RID: 19441
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RegionalTerminalGameplayItem : GridProxyAbstract<RegionalTerminalGameplayData>
	{
		// Token: 0x06032B9E RID: 207774 RVA: 0x00CB4FCC File Offset: 0x00CB31CC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 9;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIExtendToggleTextureTransition));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickToggle));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06032B9F RID: 207775 RVA: 0x00CB515C File Offset: 0x00CB335C
		public override UniTask RefreshAsync(RegionalTerminalGameplayData data, bool isSelected, int gridIndex)
		{
			RegionalTerminalGameplayItem.<RefreshAsync>d__10 <RefreshAsync>d__;
			<RefreshAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshAsync>d__.<>4__this = this;
			<RefreshAsync>d__.data = data;
			<RefreshAsync>d__.<>1__state = -1;
			<RefreshAsync>d__.<>t__builder.Start<RegionalTerminalGameplayItem.<RefreshAsync>d__10>(ref <RefreshAsync>d__);
			return <RefreshAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06032BA0 RID: 207776 RVA: 0x00CB51A7 File Offset: 0x00CB33A7
		protected override void OnBeforeDestroy()
		{
			this.UnBindRedDot();
		}

		// Token: 0x06032BA1 RID: 207777 RVA: 0x00CB51B0 File Offset: 0x00CB33B0
		private void BindRedDot()
		{
			UUIItem item = base.GetItem(7);
			if (item == null)
			{
				return;
			}
			if (!this.EnableRedDot)
			{
				item.SetUIActive(false);
				return;
			}
			this.UnBindRedDot();
			this.RedDotName = this.Data.GetRedDotName();
			this.RedDotId = this.Data.GetRedDotId();
			if (this.RedDotName != null)
			{
				ControllerBase<RedDotController>.Instance.BindRedDot(this.RedDotName.Value, item, null, this.RedDotId);
				return;
			}
			item.SetUIActive(this.Data.GetRedDotState());
		}

		// Token: 0x06032BA2 RID: 207778 RVA: 0x00CB5240 File Offset: 0x00CB3440
		private void UnBindRedDot()
		{
			if (this.RedDotName != null)
			{
				UUIItem item = base.GetItem(7);
				ControllerBase<RedDotController>.Instance.UnBindGivenUi(this.RedDotName.Value, item, this.RedDotId);
				this.RedDotId = 0;
				this.RedDotName = null;
			}
		}

		// Token: 0x06032BA3 RID: 207779 RVA: 0x00CB5291 File Offset: 0x00CB3491
		public void SetPin(bool visible)
		{
			UUIItem item = base.GetItem(5);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(visible);
		}

		// Token: 0x06032BA4 RID: 207780 RVA: 0x00CB52A8 File Offset: 0x00CB34A8
		public void RefreshFunctional()
		{
			bool lockState = this.Data.GetLockState();
			UUITexture texture = base.GetTexture(2);
			if (texture != null)
			{
				UUIItem uuiitem = texture;
				bool bUseChangeColor = lockState;
				FColor? fcolor = new FColor?(texture.changeColor);
				uuiitem.SetChangeColor(bUseChangeColor, fcolor);
			}
			this.SetPin(ModelBase<RegionalTerminalModel>.Instance.IsGameplayPin(this.Data.Id));
			UUIItem item = base.GetItem(6);
			if (item != null)
			{
				item.SetUIActive(lockState);
			}
			if (this.RedDotName == null)
			{
				UUIItem item2 = base.GetItem(7);
				if (item2 != null)
				{
					item2.SetUIActive(this.Data.GetRedDotState());
				}
			}
		}

		// Token: 0x06032BA5 RID: 207781 RVA: 0x00CB5338 File Offset: 0x00CB3538
		private void RefreshTextState(bool state)
		{
			float alpha = (!state && this.Data.GetLockState()) ? 0.2f : 1f;
			UUIItem item = base.GetItem(8);
			if (item == null)
			{
				return;
			}
			item.SetAlpha(alpha);
		}

		// Token: 0x06032BA6 RID: 207782 RVA: 0x00CB5374 File Offset: 0x00CB3574
		private void OnClickToggle(EToggleState state)
		{
			this.RefreshTextState(state == EToggleState.ETT_Checked);
			Action<bool, RegionalTerminalGameplayData> onClickToggleCallBack = this.OnClickToggleCallBack;
			if (onClickToggleCallBack == null)
			{
				return;
			}
			onClickToggleCallBack(state == EToggleState.ETT_Checked, this.Data);
		}

		// Token: 0x06032BA7 RID: 207783 RVA: 0x00CB539C File Offset: 0x00CB359C
		private void SetToggleState(bool state)
		{
			EToggleState state2 = state ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (extendToggle != null)
			{
				extendToggle.SetToggleState(state2, false, false, false);
			}
			this.RefreshTextState(state);
		}

		// Token: 0x06032BA8 RID: 207784 RVA: 0x00CB53CF File Offset: 0x00CB35CF
		public override void OnSelected(bool fireEvent)
		{
			this.SetToggleState(true);
		}

		// Token: 0x06032BA9 RID: 207785 RVA: 0x00CB53D8 File Offset: 0x00CB35D8
		public override void OnDeselected(bool fireEvent)
		{
			this.SetToggleState(false);
		}

		// Token: 0x06032BAA RID: 207786 RVA: 0x00CB53E1 File Offset: 0x00CB35E1
		public override object GetKey(RegionalTerminalGameplayData data, int displayIndex)
		{
			return data.Id;
		}

		// Token: 0x0401D868 RID: 120936
		[Nullable(2)]
		private RegionalTerminalGameplayData Data;

		// Token: 0x0401D869 RID: 120937
		private ERedDotName? RedDotName;

		// Token: 0x0401D86A RID: 120938
		private int RedDotId;

		// Token: 0x0401D86B RID: 120939
		public bool EnableRedDot = true;

		// Token: 0x0401D86C RID: 120940
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Action<bool, RegionalTerminalGameplayData> OnClickToggleCallBack;

		// Token: 0x0401D86D RID: 120941
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Func<RegionalTerminalGameplayData, bool> IsToggleSelectOn;

		// Token: 0x0401D86E RID: 120942
		private const float LOCK_TEXT_ALPHA = 0.2f;

		// Token: 0x0401D86F RID: 120943
		private const float NORMAL_TEXT_ALPHA = 1f;

		// Token: 0x0200ACE0 RID: 44256
		[NullableContext(0)]
		public static class EComponents
		{
			// Token: 0x04035B1F RID: 219935
			public const int Toggle = 0;

			// Token: 0x04035B20 RID: 219936
			public const int TexBg = 1;

			// Token: 0x04035B21 RID: 219937
			public const int TexIcon = 2;

			// Token: 0x04035B22 RID: 219938
			public const int TxtName = 3;

			// Token: 0x04035B23 RID: 219939
			public const int TxtTag = 4;

			// Token: 0x04035B24 RID: 219940
			public const int ItemPin = 5;

			// Token: 0x04035B25 RID: 219941
			public const int ItemLock = 6;

			// Token: 0x04035B26 RID: 219942
			public const int ItemRedDot = 7;

			// Token: 0x04035B27 RID: 219943
			public const int PanelText = 8;
		}
	}
}
