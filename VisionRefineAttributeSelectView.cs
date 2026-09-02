using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001816 RID: 6166
[NullableContext(1)]
[Nullable(0)]
public class VisionRefineAttributeSelectView : UiViewBase
{
	// Token: 0x0600AF81 RID: 44929 RVA: 0x002EC377 File Offset: 0x002EA577
	public VisionRefineAttributeSelectView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600AF82 RID: 44930 RVA: 0x002EC394 File Offset: 0x002EA594
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(1, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIText)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIText)),
			new ValueTuple<int, Type>(7, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(1, new Action(this.OnClickConfirm))
		};
	}

	// Token: 0x0600AF83 RID: 44931 RVA: 0x002EC480 File Offset: 0x002EA680
	protected override UniTask OnBeforeStartAsync()
	{
		VisionRefineAttributeSelectView.<OnBeforeStartAsync>d__9 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<VisionRefineAttributeSelectView.<OnBeforeStartAsync>d__9>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600AF84 RID: 44932 RVA: 0x002EC4C4 File Offset: 0x002EA6C4
	protected override void OnStart()
	{
		IRefineAttrSelectViewOpenParam refineAttrSelectViewOpenParam = this.OpenParam as IRefineAttrSelectViewOpenParam;
		this.IncId = refineAttrSelectViewOpenParam.IncId;
		this.CallbackConfirm = refineAttrSelectViewOpenParam.Callback;
		this.GetSelectedPropItemIdList = refineAttrSelectViewOpenParam.GetSelectedPropItemIdList;
		this.Selection = refineAttrSelectViewOpenParam.SelectAttribute;
		PhantomDataBase phantomDataBase = ModelBase<PhantomBattleModel>.Instance.GetPhantomDataBase(this.IncId);
		AttrListScrollData attrListScrollData = phantomDataBase.GetMainPropShowAttributeList(CommonComponentDefine.EAttributeType.PhantomType, false)[0];
		int[] visionRefineRecommendAttributes = ModelBase<CalabashModel>.Instance.GetVisionRefineRecommendAttributes(phantomDataBase.GetCost(), phantomDataBase.GetFetterGroupId());
		int[] phantomMainPropItemRefineAvailableIdList = ModelBase<PhantomBattleModel>.Instance.GetPhantomMainPropItemRefineAvailableIdList(phantomDataBase.GetConfigId(false));
		List<IRefineAttrItemData> list = new List<IRefineAttrItemData>();
		int? chosenIndex = null;
		for (int i = 0; i < phantomMainPropItemRefineAvailableIdList.Length; i++)
		{
			int num = phantomMainPropItemRefineAvailableIdList[i];
			PhantomMainPropItem phantomMainPropertyItemId = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomMainPropertyItemId(num);
			RefineAttrItemData item = new RefineAttrItemData
			{
				PropItemId = num,
				PropIndexId = phantomMainPropertyItemId.PropId,
				IsRecommend = (refineAttrSelectViewOpenParam.DataConfirmed && visionRefineRecommendAttributes.Contains(phantomMainPropertyItemId.PropId)),
				IsDisable = (refineAttrSelectViewOpenParam.DataConfirmed && attrListScrollData.Id == phantomMainPropertyItemId.PropId)
			};
			list.Add(item);
			if (refineAttrSelectViewOpenParam.SelectAttribute != null && refineAttrSelectViewOpenParam.SelectAttribute.PropItemId == num)
			{
				chosenIndex = new int?(i);
			}
		}
		this.Attributes = list.ToArray();
		this.AttributeLayout.RefreshByData(this.Attributes, chosenIndex);
		this.RefreshTips();
	}

	// Token: 0x0600AF85 RID: 44933 RVA: 0x002EC63D File Offset: 0x002EA83D
	protected override void OnBeforeShow()
	{
		this.RefreshConfirm();
	}

	// Token: 0x0600AF86 RID: 44934 RVA: 0x002EC645 File Offset: 0x002EA845
	private void RefreshConfirm()
	{
		if (this.Selection == null)
		{
			base.GetButton(1).SetSelfInteractive(false);
			return;
		}
		base.GetButton(1).SetSelfInteractive(true);
	}

	// Token: 0x0600AF87 RID: 44935 RVA: 0x002EC66C File Offset: 0x002EA86C
	private void RefreshTips()
	{
		if (this.GetSelectedPropItemIdList != null)
		{
			int[] array = this.GetSelectedPropItemIdList();
			IRefineAttrItemData selection = this.Selection;
			int? num = (selection != null) ? new int?(selection.PropItemId) : null;
			if (num != null && array.Length != 0)
			{
				int num2 = 0;
				foreach (int num3 in array)
				{
					int? num4 = num;
					if (num3 == num4.GetValueOrDefault() & num4 != null)
					{
						num2++;
					}
				}
				if (num2 > 0)
				{
					UUIItem item = base.GetItem(5);
					if (item != null)
					{
						item.SetUIActive(true);
					}
					Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(6), "Text_VisionRefine_CanRefineWithNumber_Text", new <>z__ReadOnlySingleElementList<object>(num2.ToString()));
					return;
				}
			}
		}
		UUIItem item2 = base.GetItem(5);
		if (item2 == null)
		{
			return;
		}
		item2.SetUIActive(false);
	}

	// Token: 0x0600AF88 RID: 44936 RVA: 0x002EC73F File Offset: 0x002EA93F
	private void OnClickConfirm()
	{
		if (this.CallbackConfirm != null)
		{
			this.CallbackConfirm(this.Selection);
		}
		base.CloseMe(null);
	}

	// Token: 0x0600AF89 RID: 44937 RVA: 0x002EC761 File Offset: 0x002EA961
	private void OnClickAttribute(IRefineAttrItemData data)
	{
		this.Selection = data;
		this.RefreshConfirm();
		this.RefreshTips();
	}

	// Token: 0x04005336 RID: 21302
	private int IncId = -1;

	// Token: 0x04005337 RID: 21303
	[Nullable(2)]
	private IRefineAttrItemData Selection;

	// Token: 0x04005338 RID: 21304
	private IRefineAttrItemData[] Attributes = new IRefineAttrItemData[0];

	// Token: 0x04005339 RID: 21305
	[Nullable(2)]
	private AttributeSelectPanel AttributeLayout;

	// Token: 0x0400533A RID: 21306
	[Nullable(2)]
	private Action<IRefineAttrItemData> CallbackConfirm;

	// Token: 0x0400533B RID: 21307
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Func<int[]> GetSelectedPropItemIdList;

	// Token: 0x02007B99 RID: 31641
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402A3E9 RID: 173033
		ClearButton,
		// Token: 0x0402A3EA RID: 173034
		ConfirmButton,
		// Token: 0x0402A3EB RID: 173035
		BaseLayout,
		// Token: 0x0402A3EC RID: 173036
		AttributeLayout,
		// Token: 0x0402A3ED RID: 173037
		TitleText,
		// Token: 0x0402A3EE RID: 173038
		DownLeftRoot,
		// Token: 0x0402A3EF RID: 173039
		TipsText,
		// Token: 0x0402A3F0 RID: 173040
		IconItem
	}
}
