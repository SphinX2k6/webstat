using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x020063BB RID: 25531
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RoverlikeEventChoiceItem : GridProxyAbstract<IRoverlikeEventChoiceData>
	{
		// Token: 0x060401F4 RID: 262644 RVA: 0x0106FB14 File Offset: 0x0106DD14
		public void BindOnItemSelect(Action<IRoverlikeEventChoiceData> callback)
		{
			this.OnItemSelect = callback;
		}

		// Token: 0x060401F5 RID: 262645 RVA: 0x0106FB1D File Offset: 0x0106DD1D
		public override void OnSelected(bool fireEvent)
		{
			base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_Checked, false, false, false);
		}

		// Token: 0x060401F6 RID: 262646 RVA: 0x0106FB30 File Offset: 0x0106DD30
		public override void OnDeselected(bool fireEvent)
		{
			base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
		}

		// Token: 0x060401F7 RID: 262647 RVA: 0x0106FB44 File Offset: 0x0106DD44
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
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnTogCommonStateChanged));
			this.BtnBindInfo = list2;
		}

		// Token: 0x060401F8 RID: 262648 RVA: 0x0106FBEC File Offset: 0x0106DDEC
		public override void Refresh(IRoverlikeEventChoiceData data, bool isSelected, int gridIndex)
		{
			this.CurrentData = data;
			if (ConfigBase<RoverlikeConfig>.Instance.GetEventChoiceConfig(data.ConfigId) == null)
			{
				return;
			}
			this.RefreshDescMode();
			base.GetExtendToggle(0).SetToggleState(isSelected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
		}

		// Token: 0x060401F9 RID: 262649 RVA: 0x0106FC38 File Offset: 0x0106DE38
		public void RefreshDescMode()
		{
			if (this.CurrentData == null)
			{
				return;
			}
			RoverRogueEventChoice? eventChoiceConfig = ConfigBase<RoverlikeConfig>.Instance.GetEventChoiceConfig(this.CurrentData.ConfigId);
			if (eventChoiceConfig == null)
			{
				return;
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), eventChoiceConfig.Value.Desc, eventChoiceConfig.Value.Params());
		}

		// Token: 0x060401FA RID: 262650 RVA: 0x0106FC9D File Offset: 0x0106DE9D
		private void OnTogCommonStateChanged(EToggleState state)
		{
			if (state == EToggleState.ETT_Checked && this.CurrentData != null)
			{
				Action<IRoverlikeEventChoiceData> onItemSelect = this.OnItemSelect;
				if (onItemSelect == null)
				{
					return;
				}
				onItemSelect(this.CurrentData);
			}
		}

		// Token: 0x060401FB RID: 262651 RVA: 0x0106FCC4 File Offset: 0x0106DEC4
		protected override void OnStart()
		{
			ITermExplanationRegistryParam param = new TermExplanationRegistryParam
			{
				UiText = base.GetText(1),
				ViewType = ETermExplanationViewType.Center,
				ReportType = ETermExplanationReportType.Roverlike
			};
			ControllerBase<TermExplanationController>.Instance.RegisterTextHyperlinkByParam(param);
		}

		// Token: 0x060401FC RID: 262652 RVA: 0x0106FCFF File Offset: 0x0106DEFF
		protected override void OnBeforeDestroy()
		{
			ControllerBase<TermExplanationController>.Instance.UnRegisterTextHyperlink(base.GetText(1));
			this.OnItemSelect = null;
		}

		// Token: 0x04023FC4 RID: 147396
		[Nullable(2)]
		private IRoverlikeEventChoiceData CurrentData;

		// Token: 0x04023FC5 RID: 147397
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Action<IRoverlikeEventChoiceData> OnItemSelect;

		// Token: 0x0200C423 RID: 50211
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x0403C62C RID: 247340
			public const int TogCommon = 0;

			// Token: 0x0403C62D RID: 247341
			public const int TxtName = 1;
		}
	}
}
