using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001822 RID: 6178
[NullableContext(1)]
[Nullable(0)]
public class VisionRefineSubResultView : UiViewBase
{
	// Token: 0x0600AFFD RID: 45053 RVA: 0x002EE835 File Offset: 0x002ECA35
	public VisionRefineSubResultView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600AFFE RID: 45054 RVA: 0x002EE840 File Offset: 0x002ECA40
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIVerticalLayout)),
			new ValueTuple<int, Type>(2, typeof(UUIVerticalLayout)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIText)),
			new ValueTuple<int, Type>(7, typeof(UUIText)),
			new ValueTuple<int, Type>(8, typeof(UUIText))
		};
	}

	// Token: 0x0600AFFF RID: 45055 RVA: 0x002EE920 File Offset: 0x002ECB20
	protected override UniTask OnBeforeStartAsync()
	{
		VisionRefineSubResultView.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<VisionRefineSubResultView.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600B000 RID: 45056 RVA: 0x002EE963 File Offset: 0x002ECB63
	private VisionRefineAttributeItem InitAttrItem()
	{
		return new VisionRefineAttributeItem();
	}

	// Token: 0x0600B001 RID: 45057 RVA: 0x002EE96C File Offset: 0x002ECB6C
	private void RefreshAvailableAttrTips(VisionRefineBatchResultViewData data)
	{
		if (!data.HasRecommendData)
		{
			UUIText text = base.GetText(7);
			if (text != null)
			{
				text.SetUIActive(false);
			}
			UUIText text2 = base.GetText(8);
			if (text2 == null)
			{
				return;
			}
			text2.SetUIActive(false);
			return;
		}
		else
		{
			int num = this.CalcRecommentCount(data.LeftAttrList);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(7), "Text_Refresh_HaveAvailableAttr", new <>z__ReadOnlySingleElementList<object>(num.ToString()));
			UUIText text3 = base.GetText(7);
			if (text3 != null)
			{
				text3.SetUIActive(true);
			}
			int num2 = this.CalcRecommentCount(data.RightAttrList);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(8), "Text_Refresh_HaveAvailableAttr", new <>z__ReadOnlySingleElementList<object>(num2.ToString()));
			UUIText text4 = base.GetText(8);
			if (text4 == null)
			{
				return;
			}
			text4.SetUIActive(true);
			return;
		}
	}

	// Token: 0x0600B002 RID: 45058 RVA: 0x002EEA2C File Offset: 0x002ECC2C
	private int CalcRecommentCount(VisionRefineAttributeItemData[] attrList)
	{
		int num = 0;
		for (int i = 0; i < attrList.Length; i++)
		{
			if (attrList[i].IsRecommend)
			{
				num++;
			}
		}
		return num;
	}

	// Token: 0x0600B003 RID: 45059 RVA: 0x002EEA5C File Offset: 0x002ECC5C
	private void OnClickCancel()
	{
		VisionRefineBatchResultViewData visionRefineBatchResultViewData = this.OpenParam as VisionRefineBatchResultViewData;
		int num = this.CalcRecommentCount(visionRefineBatchResultViewData.LeftAttrList);
		int num2 = this.CalcRecommentCount(visionRefineBatchResultViewData.RightAttrList);
		if (num < num2)
		{
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.VisionRefineSubResultConfirm);
			Action value = delegate()
			{
				this.OnClickCancelInternal().Forget();
			};
			confirmBoxDataNew.FunctionMap[2] = value;
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
			return;
		}
		if (!ModelBase<PhantomBattleModel>.Instance.PhantomRefineRejectIgnore)
		{
			ConfirmBoxDataNew confirmBoxDataNew2 = new ConfirmBoxDataNew(EConfirmBoxConfigId.PhantomRefreshRejectConfirm);
			Action value2 = delegate()
			{
				this.OnClickCancelInternal().Forget();
			};
			confirmBoxDataNew2.FunctionMap[2] = value2;
			confirmBoxDataNew2.HasToggle = true;
			confirmBoxDataNew2.ToggleTextKey = "PhantomProject_CommonText";
			confirmBoxDataNew2.SetToggleFunction(delegate(bool isSelect)
			{
				ModelBase<PhantomBattleModel>.Instance.PhantomRefineRejectIgnore = isSelect;
			});
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew2);
			return;
		}
		this.OnClickCancelInternal().Forget();
	}

	// Token: 0x0600B004 RID: 45060 RVA: 0x002EEB4C File Offset: 0x002ECD4C
	private UniTask OnClickCancelInternal()
	{
		VisionRefineSubResultView.<OnClickCancelInternal>d__13 <OnClickCancelInternal>d__;
		<OnClickCancelInternal>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnClickCancelInternal>d__.<>4__this = this;
		<OnClickCancelInternal>d__.<>1__state = -1;
		<OnClickCancelInternal>d__.<>t__builder.Start<VisionRefineSubResultView.<OnClickCancelInternal>d__13>(ref <OnClickCancelInternal>d__);
		return <OnClickCancelInternal>d__.<>t__builder.Task;
	}

	// Token: 0x0600B005 RID: 45061 RVA: 0x002EEB90 File Offset: 0x002ECD90
	private void OnClickConfirm()
	{
		if (ModelBase<PhantomBattleModel>.Instance.PhantomRefineAcceptIgnore)
		{
			this.OnClickConfirmInternal().Forget();
			return;
		}
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.PhantomRefreshAcceptConfirm);
		Action value = delegate()
		{
			this.OnClickConfirmInternal().Forget();
		};
		confirmBoxDataNew.FunctionMap[2] = value;
		confirmBoxDataNew.HasToggle = true;
		confirmBoxDataNew.ToggleTextKey = "PhantomProject_CommonText";
		confirmBoxDataNew.SetToggleFunction(delegate(bool isSelect)
		{
			ModelBase<PhantomBattleModel>.Instance.PhantomRefineAcceptIgnore = isSelect;
		});
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
	}

	// Token: 0x0600B006 RID: 45062 RVA: 0x002EEC20 File Offset: 0x002ECE20
	private UniTask OnClickConfirmInternal()
	{
		VisionRefineSubResultView.<OnClickConfirmInternal>d__15 <OnClickConfirmInternal>d__;
		<OnClickConfirmInternal>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnClickConfirmInternal>d__.<>4__this = this;
		<OnClickConfirmInternal>d__.<>1__state = -1;
		<OnClickConfirmInternal>d__.<>t__builder.Start<VisionRefineSubResultView.<OnClickConfirmInternal>d__15>(ref <OnClickConfirmInternal>d__);
		return <OnClickConfirmInternal>d__.<>t__builder.Task;
	}

	// Token: 0x04005369 RID: 21353
	[Nullable(2)]
	private VisionRefineSlotItem SlotItem;

	// Token: 0x0400536A RID: 21354
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<VisionRefineAttributeItem, VisionRefineAttributeItemData> LeftVert;

	// Token: 0x0400536B RID: 21355
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<VisionRefineAttributeItem, VisionRefineAttributeItemData> RightVert;

	// Token: 0x0400536C RID: 21356
	[Nullable(2)]
	private VisionRefineBatchResultButton LeftBtn;

	// Token: 0x0400536D RID: 21357
	[Nullable(2)]
	private VisionRefineBatchResultButton RightBtn;

	// Token: 0x02007BA7 RID: 31655
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402A445 RID: 173125
		SlotItem,
		// Token: 0x0402A446 RID: 173126
		LeftVertical,
		// Token: 0x0402A447 RID: 173127
		RightVertical,
		// Token: 0x0402A448 RID: 173128
		VerticalItem,
		// Token: 0x0402A449 RID: 173129
		LeftButtonItem,
		// Token: 0x0402A44A RID: 173130
		RightButtonItem,
		// Token: 0x0402A44B RID: 173131
		MidDownTipText,
		// Token: 0x0402A44C RID: 173132
		LeftVerticalTips,
		// Token: 0x0402A44D RID: 173133
		RightVerticalTips
	}
}
