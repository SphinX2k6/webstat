using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020024EA RID: 9450
[NullableContext(1)]
[Nullable(0)]
public class VisionAssembleStaticItem : UiPanelBase
{
	// Token: 0x060125BE RID: 75198 RVA: 0x0050C6E4 File Offset: 0x0050A8E4
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickToggle))
		};
	}

	// Token: 0x060125BF RID: 75199 RVA: 0x0050C7A3 File Offset: 0x0050A9A3
	public void BindClickCallBack(Action callBack)
	{
		this.OnClickCallBack = callBack;
	}

	// Token: 0x060125C0 RID: 75200 RVA: 0x0050C7AC File Offset: 0x0050A9AC
	private void OnClickToggle(EToggleState toggleState)
	{
		Action onClickCallBack = this.OnClickCallBack;
		if (onClickCallBack == null)
		{
			return;
		}
		onClickCallBack();
	}

	// Token: 0x060125C1 RID: 75201 RVA: 0x0050C7C0 File Offset: 0x0050A9C0
	protected override UniTask OnBeforeStartAsync()
	{
		VisionAssembleStaticItem.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<VisionAssembleStaticItem.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060125C2 RID: 75202 RVA: 0x0050C804 File Offset: 0x0050AA04
	public void RefreshSelectState(bool state, bool compareMode)
	{
		if (compareMode)
		{
			base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_UnDetermined, false, false, false);
			base.GetExtendToggle(0).SetSelfInteractive(false);
			return;
		}
		base.GetExtendToggle(0).SetToggleState(state ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
		base.GetExtendToggle(0).SetSelfInteractive(true);
	}

	// Token: 0x060125C3 RID: 75203 RVA: 0x0050C858 File Offset: 0x0050AA58
	public void Refresh(int roleId)
	{
		foreach (VisionAssembleItem visionAssembleItem in this.AssembleItemList)
		{
			visionAssembleItem.Reset();
		}
		foreach (KeyValuePair<int, PhantomDataBase> keyValuePair in ModelBase<RoleModel>.Instance.GetRoleDataById(roleId, true).GetPhantomData().GetDataMap())
		{
			PhantomDataBase value = keyValuePair.Value;
			if (value != null)
			{
				int key = keyValuePair.Key;
				if (key < this.AssembleItemList.Count)
				{
					this.AssembleItemList[key].Update(value.GetIncrId());
				}
			}
		}
	}

	// Token: 0x04008F24 RID: 36644
	private readonly List<VisionAssembleItem> AssembleItemList = new List<VisionAssembleItem>();

	// Token: 0x04008F25 RID: 36645
	[Nullable(2)]
	private Action OnClickCallBack;
}
