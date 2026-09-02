using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002750 RID: 10064
[NullableContext(1)]
[Nullable(0)]
public class RecommendQualityView : UiViewBase
{
	// Token: 0x06013DE4 RID: 81380 RVA: 0x00589647 File Offset: 0x00587847
	public RecommendQualityView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06013DE5 RID: 81381 RVA: 0x00589650 File Offset: 0x00587850
	protected override void OnBeforeCreate()
	{
		this.Model = ModelBase<RecommendQualityModel>.Instance;
	}

	// Token: 0x06013DE6 RID: 81382 RVA: 0x00589660 File Offset: 0x00587860
	protected unsafe override void OnRegisterComponent()
	{
		int num = 3;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.BtnSureClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06013DE7 RID: 81383 RVA: 0x00589728 File Offset: 0x00587928
	protected override UniTask OnBeforeStartAsync()
	{
		RecommendQualityView.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<RecommendQualityView.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06013DE8 RID: 81384 RVA: 0x0058976B File Offset: 0x0058796B
	protected override void OnAfterDestroy()
	{
		this.AreaLayout = null;
		Singleton<UiManager>.Instance.CloseView(EUiViewName.CreateCharacterView, null);
	}

	// Token: 0x06013DE9 RID: 81385 RVA: 0x00589784 File Offset: 0x00587984
	protected override void OnAfterShow()
	{
		RecommendQualityModel model = this.Model;
		if (model == null)
		{
			return;
		}
		model.FinishRecommendQualityShow();
	}

	// Token: 0x06013DEA RID: 81386 RVA: 0x00589798 File Offset: 0x00587998
	private void BtnSureClick()
	{
		if (this.AreaLayout == null)
		{
			return;
		}
		int selectedGridIndex = this.AreaLayout.GetSelectedGridIndex();
		IRecommendQualityItemData recommendQualityItemData = this.AreaLayout.GetDatas()[selectedGridIndex];
		RecommendQualityModel model = this.Model;
		if (model != null)
		{
			model.SaveApply(recommendQualityItemData.Quality);
		}
		base.CloseMe(null);
	}

	// Token: 0x06013DEB RID: 81387 RVA: 0x005897EA File Offset: 0x005879EA
	private RecommendQualityItem InitItem()
	{
		return new RecommendQualityItem();
	}

	// Token: 0x04009A81 RID: 39553
	private RecommendQualityModel Model;

	// Token: 0x04009A82 RID: 39554
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<RecommendQualityItem, IRecommendQualityItemData> AreaLayout;

	// Token: 0x02008B0F RID: 35599
	[NullableContext(0)]
	private class EChildType
	{
		// Token: 0x0402EE60 RID: 192096
		public const int ItemLayout = 0;

		// Token: 0x0402EE61 RID: 192097
		public const int Item = 1;

		// Token: 0x0402EE62 RID: 192098
		public const int BtnSure = 2;
	}
}
