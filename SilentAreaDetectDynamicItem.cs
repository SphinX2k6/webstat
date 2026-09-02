using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.AdventureGuide;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001768 RID: 5992
[NullableContext(1)]
[Nullable(0)]
public class SilentAreaDetectDynamicItem : UiPanelBase, IDynamicScrollItem<ISilentAreaDetectionDynamicData>
{
	// Token: 0x0600A874 RID: 43124 RVA: 0x002CD818 File Offset: 0x002CBA18
	public UniTask Init(UUIItem actor)
	{
		SilentAreaDetectDynamicItem.<Init>d__6 <Init>d__;
		<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<Init>d__.<>4__this = this;
		<Init>d__.actor = actor;
		<Init>d__.<>1__state = -1;
		<Init>d__.<>t__builder.Start<SilentAreaDetectDynamicItem.<Init>d__6>(ref <Init>d__);
		return <Init>d__.<>t__builder.Task;
	}

	// Token: 0x0600A875 RID: 43125 RVA: 0x002CD864 File Offset: 0x002CBA64
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600A876 RID: 43126 RVA: 0x002CD8CD File Offset: 0x002CBACD
	protected override void OnStart()
	{
		if (this.SilentCategoryItem == null)
		{
			this.SilentCategoryItem = new SilentCategoryItem(base.GetItem(0));
		}
		if (this.SilentResultItem == null)
		{
			this.SilentResultItem = new SilentResultItem(base.GetItem(1));
		}
	}

	// Token: 0x0600A877 RID: 43127 RVA: 0x002CD903 File Offset: 0x002CBB03
	public AUIBaseActor GetUsingItem(ISilentAreaDetectionDynamicData data)
	{
		if (data.SilentAreaDetectionData != null)
		{
			return base.GetItem(1).GetOwner() as AUIBaseActor;
		}
		return base.GetItem(0).GetOwner() as AUIBaseActor;
	}

	// Token: 0x0600A878 RID: 43128 RVA: 0x002CD930 File Offset: 0x002CBB30
	public void Update(ISilentAreaDetectionDynamicData data, int index)
	{
		this.Data = data;
		this.SilentResultItem.SetActive(false);
		this.SilentCategoryItem.SetActive(false);
		if (data.SilentAreaDetectionData != null)
		{
			this.SilentResultItem.SetActive(true);
			this.SilentResultItem.Update(data.SilentAreaDetectionData);
			this.SilentResultItem.BindResultCallback(this.OnResultCallback);
			return;
		}
		this.SilentCategoryItem.SetActive(true);
		this.SilentCategoryItem.Update(data.SilentAreaTitleData, data.IsShow);
		this.SilentCategoryItem.BindCategoryCallback(this.OnCategoryCallback);
	}

	// Token: 0x0600A879 RID: 43129 RVA: 0x002CD9C7 File Offset: 0x002CBBC7
	public void BindClickCategoryCallback(Action<int, UUIExtendToggle, bool> onCategoryCallback)
	{
		this.OnCategoryCallback = onCategoryCallback;
	}

	// Token: 0x0600A87A RID: 43130 RVA: 0x002CD9D0 File Offset: 0x002CBBD0
	public void BindClickResultCallback(Action<int, UUIExtendToggle> onResultCallback)
	{
		this.OnResultCallback = onResultCallback;
	}

	// Token: 0x0600A87B RID: 43131 RVA: 0x002CD9D9 File Offset: 0x002CBBD9
	public void ClearItem()
	{
		base.Destroy(null);
	}

	// Token: 0x0600A87C RID: 43132 RVA: 0x002CD9E2 File Offset: 0x002CBBE2
	protected override void OnBeforeDestroy()
	{
		if (this.SilentCategoryItem != null)
		{
			this.SilentCategoryItem.Destroy(null);
			this.SilentCategoryItem = null;
		}
		if (this.SilentResultItem != null)
		{
			this.SilentResultItem.Destroy(null);
			this.SilentResultItem = null;
		}
	}

	// Token: 0x04004F5C RID: 20316
	[Nullable(2)]
	protected ISilentAreaDetectionDynamicData Data;

	// Token: 0x04004F5D RID: 20317
	[Nullable(2)]
	private SilentCategoryItem SilentCategoryItem;

	// Token: 0x04004F5E RID: 20318
	[Nullable(2)]
	private SilentResultItem SilentResultItem;

	// Token: 0x04004F5F RID: 20319
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Action<int, UUIExtendToggle, bool> OnCategoryCallback;

	// Token: 0x04004F60 RID: 20320
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Action<int, UUIExtendToggle> OnResultCallback;

	// Token: 0x02007AC9 RID: 31433
	[NullableContext(0)]
	public enum ESilentAreaDefine
	{
		// Token: 0x0402A0F1 RID: 172273
		SilentCategoryItem,
		// Token: 0x0402A0F2 RID: 172274
		SilentResultItem
	}
}
