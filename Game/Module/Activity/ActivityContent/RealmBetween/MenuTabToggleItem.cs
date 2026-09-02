using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RealmBetween
{
	// Token: 0x0200655F RID: 25951
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class MenuTabToggleItem : GridProxyAbstract<MotorChallengePlayData>
	{
		// Token: 0x06040D5B RID: 265563 RVA: 0x010A054C File Offset: 0x0109E74C
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIItem)),
				new ValueTuple<int, Type>(5, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnExtendToggleClick))
			};
		}

		// Token: 0x06040D5C RID: 265564 RVA: 0x010A060C File Offset: 0x0109E80C
		protected override UniTask OnBeforeStartAsync()
		{
			MenuTabToggleItem.<OnBeforeStartAsync>d__3 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<MenuTabToggleItem.<OnBeforeStartAsync>d__3>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06040D5D RID: 265565 RVA: 0x010A064F File Offset: 0x0109E84F
		private bool CanExecuteChange()
		{
			return true;
		}

		// Token: 0x06040D5E RID: 265566 RVA: 0x010A0654 File Offset: 0x0109E854
		public override void Refresh(MotorChallengePlayData data, bool isSelected, int gridIndex)
		{
			this.Data = data;
			UUIText text = base.GetText(1);
			if (text != null)
			{
				text.ShowTextNew(data.NameTextId);
			}
			base.GetItem(2).SetUIActive(data.IsFinished);
			base.GetItem(3).SetUIActive(!data.IsUnlock);
			base.GetItem(4).SetUIActive(data.HasRedDot);
			base.GetItem(5).SetUIActive(data.IsUnlock && data.IsNew && !data.HasRedDot);
			this.SetIsSelect(isSelected, false);
		}

		// Token: 0x06040D5F RID: 265567 RVA: 0x010A06E9 File Offset: 0x0109E8E9
		public override void OnSelected(bool fireEvent)
		{
			this.SetIsSelect(true, fireEvent);
		}

		// Token: 0x06040D60 RID: 265568 RVA: 0x010A06F3 File Offset: 0x0109E8F3
		public void SetItemNewVisible(bool bVisible)
		{
			base.GetItem(5).SetUIActive(bVisible);
		}

		// Token: 0x06040D61 RID: 265569 RVA: 0x010A0702 File Offset: 0x0109E902
		private void OnExtendToggleClick(EToggleState state)
		{
			Action<MotorChallengePlayData, MenuTabToggleItem> onChildToggleCallback = this.OnChildToggleCallback;
			if (onChildToggleCallback == null)
			{
				return;
			}
			onChildToggleCallback(this.Data, this);
		}

		// Token: 0x06040D62 RID: 265570 RVA: 0x010A071B File Offset: 0x0109E91B
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

		// Token: 0x0402461C RID: 149020
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		public Action<MotorChallengePlayData, MenuTabToggleItem> OnChildToggleCallback;

		// Token: 0x0402461D RID: 149021
		[Nullable(2)]
		private MotorChallengePlayData Data;
	}
}
