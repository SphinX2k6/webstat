using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Functional
{
	// Token: 0x02005D1C RID: 23836
	public class FunctionItem : UiPanelBase
	{
		// Token: 0x0603C1B0 RID: 246192 RVA: 0x00F3DCBF File Offset: 0x00F3BEBF
		[NullableContext(1)]
		public FunctionItem(UUIItem uiItem)
		{
			base.CreateThenShowByActor(uiItem.GetOwner(), null);
		}

		// Token: 0x0603C1B1 RID: 246193 RVA: 0x00F3DCD4 File Offset: 0x00F3BED4
		[NullableContext(2)]
		public UUIItem GetButtonItem()
		{
			UUIButtonComponent button = base.GetButton(2);
			TWeakObjectPtr<UUIItem>? tweakObjectPtr = (button != null) ? new TWeakObjectPtr<UUIItem>?(button.RootUIComp) : null;
			if (tweakObjectPtr == null)
			{
				return null;
			}
			return tweakObjectPtr.GetValueOrDefault();
		}

		// Token: 0x0603C1B2 RID: 246194 RVA: 0x00F3DD1C File Offset: 0x00F3BF1C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISpriteTransition));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.ButtonClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603C1B3 RID: 246195 RVA: 0x00F3DE28 File Offset: 0x00F3C028
		private void ButtonClick()
		{
			if (this.FunctionId != 0)
			{
				ControllerBase<FunctionController>.Instance.OpenFunctionRelateView((EFunctionType)this.FunctionId);
				OnClickFunctionItemLogEvent onClickFunctionItemLogEvent = new OnClickFunctionItemLogEvent();
				onClickFunctionItemLogEvent.i_id = this.FunctionId;
				onClickFunctionItemLogEvent.i_type = 1;
				ControllerBase<LogReportController>.Instance.LogReport(onClickFunctionItemLogEvent);
				if (this.FunctionId == 10010 || this.FunctionId == 10040)
				{
					OnClickFunctionViewButtonLogEvent onClickFunctionViewButtonLogEvent = new OnClickFunctionViewButtonLogEvent();
					onClickFunctionViewButtonLogEvent.i_id = this.FunctionId;
					ControllerBase<LogReportController>.Instance.LogReport(onClickFunctionViewButtonLogEvent);
				}
			}
		}

		// Token: 0x0603C1B4 RID: 246196 RVA: 0x00F3DEA8 File Offset: 0x00F3C0A8
		public void UpdateItem(int functionId)
		{
			this.FunctionId = functionId;
			FunctionMenu? functionConfig = ConfigBase<FunctionConfig>.Instance.GetFunctionConfig(functionId);
			if (functionConfig == null)
			{
				return;
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), functionConfig.Value.FunctionName, Array.Empty<object>());
			bool flag = ModelBase<FunctionModel>.Instance.IsOpen(functionId);
			UUIItem item = base.GetItem(0);
			if (item != null)
			{
				item.SetUIActive(!flag);
			}
			UUISpriteTransition uiSpriteTransition = base.GetUiSpriteTransition(3);
			if (functionId == 10001)
			{
				string roleFunctionIconPath = ConfigBase<FunctionConfig>.Instance.GetRoleFunctionIconPath();
				base.SetSpriteTransitionByPath(roleFunctionIconPath, uiSpriteTransition, EUISelectableSelectionState.EUISelectableSelectionState_MAX);
			}
			else
			{
				base.SetSpriteTransitionByPath(functionConfig.Value.FunctionIcon, uiSpriteTransition, EUISelectableSelectionState.EUISelectableSelectionState_MAX);
			}
			this.BindRedDot();
		}

		// Token: 0x0603C1B5 RID: 246197 RVA: 0x00F3DF60 File Offset: 0x00F3C160
		private void BindRedDot()
		{
			if (this.FunctionId == 0)
			{
				return;
			}
			this.RedDotName = ModelBase<FunctionModel>.Instance.GetFunctionItemRedDotName(this.FunctionId);
			UUIItem item = base.GetItem(4);
			if (this.RedDotName != null)
			{
				ControllerBase<RedDotController>.Instance.BindRedDot(this.RedDotName.Value, item, null, 0);
				return;
			}
			if (item != null)
			{
				item.SetUIActive(false);
			}
		}

		// Token: 0x0603C1B6 RID: 246198 RVA: 0x00F3DFC4 File Offset: 0x00F3C1C4
		private void UnBindRedDot()
		{
			if (this.RedDotName != null)
			{
				UUIItem item = base.GetItem(4);
				ControllerBase<RedDotController>.Instance.UnBindGivenUi(this.RedDotName.Value, item, 0);
				this.RedDotName = null;
			}
		}

		// Token: 0x0603C1B7 RID: 246199 RVA: 0x00F3E009 File Offset: 0x00F3C209
		protected override void OnBeforeDestroy()
		{
			this.UnBindRedDot();
			UUIButtonComponent button = base.GetButton(2);
			if (button != null)
			{
				button.OnPointEnterCallBack.Unbind();
			}
			if (button == null)
			{
				return;
			}
			button.OnPointExitCallBack.Unbind();
		}

		// Token: 0x04021BE9 RID: 138217
		protected int FunctionId;

		// Token: 0x04021BEA RID: 138218
		private ERedDotName? RedDotName;

		// Token: 0x0200BD8D RID: 48525
		private class EFunctionItemDefine
		{
			// Token: 0x0403A60E RID: 239118
			public const int LockIcon = 0;

			// Token: 0x0403A60F RID: 239119
			public const int FunctionName = 1;

			// Token: 0x0403A610 RID: 239120
			public const int Button = 2;

			// Token: 0x0403A611 RID: 239121
			public const int IconSpriteTransition = 3;

			// Token: 0x0403A612 RID: 239122
			public const int RedDotItem = 4;
		}
	}
}
