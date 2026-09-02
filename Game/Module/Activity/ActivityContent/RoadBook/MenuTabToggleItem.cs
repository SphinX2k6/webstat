using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RoadBook
{
	// Token: 0x020064C1 RID: 25793
	public class MenuTabToggleItem : UiPanelBase
	{
		// Token: 0x06040A0F RID: 264719 RVA: 0x01091204 File Offset: 0x0108F404
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUISprite)),
				new ValueTuple<int, Type>(3, typeof(UUISprite)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnExtendToggleClick))
			};
		}

		// Token: 0x06040A10 RID: 264720 RVA: 0x010912C4 File Offset: 0x0108F4C4
		protected override UniTask OnBeforeStartAsync()
		{
			MenuTabToggleItem.<OnBeforeStartAsync>d__3 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<MenuTabToggleItem.<OnBeforeStartAsync>d__3>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06040A11 RID: 264721 RVA: 0x01091307 File Offset: 0x0108F507
		private bool CanExecuteChange()
		{
			return true;
		}

		// Token: 0x06040A12 RID: 264722 RVA: 0x0109130C File Offset: 0x0108F50C
		[NullableContext(1)]
		public void Refresh(MotorChallengePlayData data)
		{
			this.Data = data;
			UUIText text = base.GetText(1);
			if (text != null)
			{
				text.ShowTextNew(data.NameTextId);
			}
			base.GetSprite(2).SetUIActive(data.IsFinished);
			base.GetSprite(3).SetUIActive(!data.IsUnlock);
			base.GetItem(4).SetUIActive(data.HasRedDot);
			base.GetItem(5).SetUIActive(data.IsUnlock && data.IsNew && !data.HasRedDot);
		}

		// Token: 0x06040A13 RID: 264723 RVA: 0x01091399 File Offset: 0x0108F599
		public void SetItemNewVisible(bool bVisible)
		{
			base.GetItem(5).SetUIActive(bVisible);
		}

		// Token: 0x06040A14 RID: 264724 RVA: 0x010913A8 File Offset: 0x0108F5A8
		private void OnExtendToggleClick(EToggleState state)
		{
			Action<MotorChallengePlayData, MenuTabToggleItem> onChildToggleCallback = this.OnChildToggleCallback;
			if (onChildToggleCallback == null)
			{
				return;
			}
			onChildToggleCallback(this.Data, this);
		}

		// Token: 0x06040A15 RID: 264725 RVA: 0x010913C1 File Offset: 0x0108F5C1
		public void SetIsSelect(bool isSelect, bool fireEvent = false)
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(0);
			if (extendToggle != null)
			{
				extendToggle.SetToggleStateForce(isSelect ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
			}
			if (fireEvent)
			{
				Action<MotorChallengePlayData, MenuTabToggleItem> onChildToggleCallback = this.OnChildToggleCallback;
				if (onChildToggleCallback == null)
				{
					return;
				}
				onChildToggleCallback(this.Data, this);
			}
		}

		// Token: 0x04024327 RID: 148263
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		public Action<MotorChallengePlayData, MenuTabToggleItem> OnChildToggleCallback;

		// Token: 0x04024328 RID: 148264
		[Nullable(2)]
		private MotorChallengePlayData Data;
	}
}
